<template>
  <ad-main title="账户管理" class="ad-account">
    <div class="row row-lg">
      <div class="col-sm-6 col-md-4">
        <div class="example-wrap">
          <h4 class="example-title">标题</h4>
          <el-input size="small" v-model="request.Title" style="width:100%;" placeholder="请输入标题"></el-input>
        </div>
      </div>

      <div class="col-sm-12 col-md-12">
        <ad-button type="inverse" @click.native="getList();">搜索</ad-button>
        <ad-button type="primary" @click.native="btnEditHandller({});">添加</ad-button>
      </div>
    </div>

    <ad-table :headers="headers" :list="list">
      <tr v-for="item in list" :key="item.Id">
        <td>{{item.Id}}</td>
        <td>{{item.Title}}</td>
        <td>{{item.Account}}</td>
        <td>
          <el-tag size="mini">查看密码</el-tag>
        </td>
        <td>{{item.Email}}</td>
        <td>{{item.Mobile}}</td>
        <td>
          <a :href="item.Url" target="_blank">网址</a>
        </td>
        <td>{{item.CreateTime|dateTimeFormats}}</td>
        <td>
          <ad-button type="danger" size="sm" @click.native="btnDeleteHandller(item);">删除</ad-button>
          <ad-button type="primary" size="sm" @click.native="btnEditHandller(item);">编辑</ad-button>
        </td>
      </tr>
    </ad-table>
  </ad-main>
</template>

<script>
import AdAccountEditComponent from "./edit";
import adAccountService from "../../_api/adAccount.service";
export default {
  name: "adAccountComponent",
  data() {
    return {
      headers: [
        "编号",
        "标题",
        "账号",
        "密码",
        "邮箱",
        "手机号",
        "地址",
        "注册时间",
        "操作"
      ],
      list: [],
      request: {
        Title: ""
      }
    };
  },
  mounted() {
    this.getList();
  },
  methods: {
    getList() {
      this.list = [];

      adAccountService.getAccountList(this.request).then(response => {
        if (response.Data !== null && response.Data.length !== 0) {
          this.list = response.Data;
        }
      });
    },
    btnEditHandller(item = {}) {
      let IsUndefined = item.Id !== undefined;
      let options = {};
      options.title = IsUndefined ? "修改账户" : "添加账户";
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
            this.getList();
            close();
          });
        } else {
          adAccountService.updateAccount(params).then(response => {
            if (response.Data > 0 && response.Data !== null) {
              this.$tip("保存成功");
            }
            this.getList();
            close();
          });
        }
        console.log(123);
      };
      this.modal$(options);
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
        adAccountService.deleteAccountById(params).then(response => {
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
