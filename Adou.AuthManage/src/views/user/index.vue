<template>
  <ad-main title="账户管理" class="ad-user">
    <div class="row row-lg">
      <div class="col-sm-6 col-md-4">
        <div class="example-wrap">
          <h4 class="example-title">用户名</h4>
          <el-input
            size="small"
            v-model="request.UserName"
            style="width:100%;"
            placeholder="请输入用户名"
          ></el-input>
        </div>
      </div>

      <div class="col-sm-12 col-md-12">
        <ad-button type="inverse" @click.native="getList();">搜索</ad-button>
        <ad-button
          type="primary"
          @click.native="$router.push({ name: 'adUserEdit', params: {} })"
        >添加</ad-button>
      </div>
    </div>

    <ad-table :headers="headers" :list="list">
      <tbody>
        <tr v-for="item in list" :key="item.Id">
          <td>{{item.Id}}</td>
          <td>{{item.UserName}}</td>
          <td>{{item.UserType===0?'管理员':'超级管理员'}}</td>
          <td>{{item.UserStatus===0?'禁用':'启用'}}</td>
          <td>
            <span
              v-for="role in item.RoleList"
              :key="role.Id"
              style="display:block;"
            >{{role.RoleName}}</span>
          </td>
          <td>{{item.Sort}}</td>
          <td>{{item.CreateTime|dateFormats}}</td>
          <td>
            <ad-button type="danger" size="sm" @click.native="btnDeleteHandller(item);">删除</ad-button>
            <ad-button
              type="primary"
              size="sm"
              @click.native="$router.push({ name: 'adUserEdit', params: item })"
            >编辑</ad-button>
          </td>
        </tr>
      </tbody>
    </ad-table>

    <ad-pagination :total="TotalItems" :pageIndex="request.PageIndex" @currentChange="getList"></ad-pagination>
  </ad-main>
</template>

<script>
import adUserService from "../../_api/adUser.service";
import adRoleService from "../../_api/adRole.service";
export default {
  name: "AdUserComponent",
  data() {
    return {
      headers: [
        "编号",
        "用户名",
        "用户类型",
        "用户状态",
        "角色",
        "排序",
        "注册时间",
        "操作"
      ],
      list: [],
      request: {
        UserName: "",
        PageIndex: 1,
        PageSize: 10,
        OrderBy: "",
        IsDesc: true
      },
      TotalItems: 0
    };
  },
  mounted() {
    this.getList();
  },
  methods: {
    async getList(PageIndex = 1) {
      this.list = [];

      this.request.PageIndex = PageIndex;

      let response = await adUserService.getUserPageList(this.request);

      if (response.Data !== null && response.Data.Items.length !== 0) {
        this.TotalItems = response.Data.TotalItems;
        this.request.PageIndex = response.Data.CurrentPage;

        let promiseAll = [];
        response.Data.Items.forEach(element => {
          let params = {
            UserId: element.Id
          };
          promiseAll.push(adRoleService.getRoleListByUserId(params));
        });

        let result = await this.http$.all(promiseAll);

        response.Data.Items.forEach((element, index) => {
          element.RoleList = result[index].Data;
          this.list.push(element);
        });
      }
    },
    btnDeleteHandller(item) {
      let options = {};
      options.title = "确认提示";
      options.message = "确认要删除吗？";

      options.params = {};
      options.params.Id = item.Id;
      options.params.IsDel = 1;

      options.save = (params, close) => {
        console.log(params);
        let args = {
          UserId: params.Id
        };

        this.http$
          .all([
            adUserService.updateUserIsDelById(params),
            adUserService.deleteUserAndRoleByUserId(args)
          ])
          .then(response => {
            if (response[0].Data > 0) {
              this.$tip("删除成功");
            }
            this.getList();
            close();
          });
      };

      this.confirm$(options);
    }
  }
};
</script>
