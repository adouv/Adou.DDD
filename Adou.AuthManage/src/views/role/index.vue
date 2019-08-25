<template>
  <ad-main title="角色管理" class="ad-role">
    <div class="row row-lg">
      <div class="col-sm-6 col-md-4">
        <div class="example-wrap">
          <h4 class="example-title">角色名称</h4>
          <el-input
            size="small"
            v-model="request.UserName"
            style="width:100%;"
            placeholder="请输入角色名称"
          ></el-input>
        </div>
      </div>

      <div class="col-sm-12 col-md-12">
        <ad-button type="inverse" @click.native="getList();">搜索</ad-button>
        <ad-button
          type="primary"
          @click.native="$router.push({ name: 'adRoleEdit', params: {} })"
        >添加</ad-button>
      </div>
    </div>

    <ad-table :headers="headers" :list="list">
      <tbody>
        <tr v-for="item in list" :key="item.Id">
          <td>{{item.Id}}</td>
          <td>{{item.RoleName}}</td>
          <td>{{item.Sort}}</td>
          <td>{{item.CreateTime|dateFormats}}</td>
          <td>
            <ad-button type="danger" size="sm" @click.native="btnDeleteHandller(item);">删除</ad-button>
            <ad-button
              type="primary"
              size="sm"
              @click.native="$router.push({ name: 'adRoleEdit', params: item })"
            >编辑</ad-button>
          </td>
        </tr>
      </tbody>
    </ad-table>

    <ad-pagination :total="TotalItems" :pageIndex="request.PageIndex" @currentChange="getList"></ad-pagination>
  </ad-main>
</template>

<script>
import adRoleService from "../../_api/adRole.service";
export default {
  name: "AdRoleComponent",
  data() {
    return {
      headers: ["编号", "角色名称", "排序", "创建时间", "操作"],
      list: [],
      request: {
        RoleName: "",
        PageIndex: 1,
        PageSize: 10,
        OrderBy: "",
        IsDesc: true
      },
      TotalItems: 0,
      loading: null
    };
  },
  mounted() {
    this.loading = this.loading$({
      lock: true,
      text: "正在加载...",
      spinner: "el-icon-loading",
      background: "rgba(0, 0, 0, 0.7)"
    });

    this.getList();
  },
  methods: {
    getList(PageIndex = 1) {
      this.list = [];

      this.request.PageIndex = PageIndex;

      adRoleService
        .getRolePageList(this.request)
        .then(response => {
          if (response.Data !== null && response.Data.Items.length !== 0) {
            this.list = response.Data.Items;
            this.TotalItems = response.Data.TotalItems;
            this.request.PageIndex = response.Data.CurrentPage;
          }
          this.loading.close();
        })
        .catch(err => {
          this.loading.close();
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
        adRoleService.updateRoleIsDelById(params).then(response => {
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
