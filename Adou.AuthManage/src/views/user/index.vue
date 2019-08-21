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
        <ad-button type="primary" @click.native="$router.push({ name: 'adUserEdit', params: {} })">添加</ad-button>
      </div>
    </div>

    <ad-table :headers="headers" :list="list">
      <tbody>
        <tr v-for="item in list" :key="item.Id">
          <td>{{item.Id}}</td>
          <td>{{item.UserName}}</td>
          <td>{{item.UserType===0?'管理员':'超级管理员'}}</td>
          <td>{{item.UserStatus===0?'禁用':'启用'}}</td>
          <td>{{item.Sort}}</td>
          <td>{{item.CreateTime|dateFormats}}</td>
          <td>
            <ad-button type="danger" size="sm" @click.native="btnDeleteHandller(item);">删除</ad-button>
            <ad-button type="primary" size="sm" @click.native="$router.push({ name: 'adUserEdit', params: item })">编辑</ad-button>
          </td>
        </tr>
      </tbody>
    </ad-table>

    <ad-pagination :total="TotalItems" :pageIndex="request.PageIndex" @currentChange="getList"></ad-pagination>
  </ad-main>
</template>

<script>
import adUserService from "../../_api/adUser.service";
import AdUserEditComponent from "./edit";
export default {
  name: "AdUserComponent",
  data() {
    return {
      headers: [
        "编号",
        "用户名",
        "用户类型",
        "用户状态",
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
    getList(PageIndex = 1) {
      this.list = [];

      this.request.PageIndex = PageIndex;

      adUserService.getUserPageList(this.request).then(response => {
        if (response.Data !== null && response.Data.Items.length !== 0) {
          this.list = response.Data.Items;
          this.TotalItems = response.Data.TotalItems;
          this.request.PageIndex = response.Data.CurrentPage;
        }
      });
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
        adUserService.updateUserIsDelById(params).then(response => {
          if (response.Data > 0 && response.Data !== null) {
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
