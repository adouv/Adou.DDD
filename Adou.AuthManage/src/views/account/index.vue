<template>
  <ad-main title="账户管理" class="ad-account">
    <div class="row row-lg">
      <div class="col-sm-6 col-md-4">
        <div class="example-wrap">
          <h4 class="example-title">标题</h4>
          <el-input size="small" style="width:100%;" placeholder="请输入标题"></el-input>
        </div>
      </div>

      <div class="col-sm-12 col-md-12">
        <el-button size="small">搜索</el-button>
        <el-button type="primary" size="small" @click="btnEditHandller({});">添加</el-button>
      </div>
    </div>

    <div class="example table-responsive td-table" style="width:100% !important;">
      <div>
        <table class="table table-striped" style="width:100% !important;">
          <thead>
            <tr>
              <th>编号</th>
              <th>标题</th>
              <th>账号</th>
              <th>邮箱</th>
              <th>手机号</th>
              <th>地址</th>
              <th>注册时间</th>
              <th>修改时间</th>
              <th>操作</th>
            </tr>
          </thead>
          <tbody></tbody>
        </table>
      </div>
    </div>
  </ad-main>
</template>

<script>
import AdAccountEditComponent from "./edit";
import adAccountService from "../../_api/adAccount.service";
export default {
  name: "adAccountComponent",
  data() {
    return {};
  },
  methods: {
    btnEditHandller(item = {}) {
      let IsUndefined = item.Id !== undefined;
      let options = {};
      options.title = item.Id !== undefined ? "修改账户" : "添加账户";
      options.componentName = AdAccountEditComponent;
      options.height = 350;
      options.params = {};
      options.params.Id = IsUndefined ? item.Id : 0;
      options.params.Title = IsUndefined ? item.Title : "";
      options.params.Url = IsUndefined ? item.Url : "#";
      options.params.Account = IsUndefined ? item.Account : "";
      options.params.Password = IsUndefined ? item.Password : "";
      options.params.Email = IsUndefined ? item.Email : "";
      options.params.Mobile = IsUndefined ? item.Mobile : "";
      options.params.Keyword = IsUndefined ? item.Keyword : "";
      options.params.Descript = IsUndefined ? item.Descript : "";
      options.save = (params, close) => {
        console.log(params);
        if (!params.Title) {
          this.$tip("请填写标题");
          return;
        }

        if (!params.Account) {
          this.$tip("请填写账号");
          return;
        }

        if (!params.Password) {
          this.$tip("请填写密码");
          return;
        }

        if (params.Mobile && !this.valid$.isMobileValid(params.Mobile)) {
          this.$tip("请填写正确的手机号");
          return;
        }

        if (params.Email && !this.valid$.isEmailValid(params.Email)) {
          this.$tip("请填写正确的邮箱");
          return;
        }

        if (params.Id === 0) {
          adAccountService.insertAccount(params).then(response => {
            if (response.Data > 0 && response.Data !== null) {
              this.$tip("保存成功");
            }
            close();
          });
        }
        console.log(123);
      };
      this.modal$(options);
    }
  }
};
</script>
