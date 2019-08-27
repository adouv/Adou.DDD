<template>
  <ad-main title="账户管理" class="ad-account">
    <div class="row row-lg">
      <div class="col-sm-6 col-md-4">
        <div class="example-wrap">
          <h4 class="example-title">标题</h4>
          <el-input size="small" v-model="request.Title" style="width:100%;" placeholder="请输入标题"></el-input>
        </div>
      </div>

      <div class="col-sm-6 col-md-4">
        <div class="example-wrap">
          <h4 class="example-title">分类</h4>
          <select class="form-control" v-model="request.Type">
            <option :value="-1">请选择</option>
            <option v-for="(item,index) in typeData" :key="index" :value="item.key">{{item.val}}</option>
          </select>
        </div>
      </div>

      <div class="col-sm-12 col-md-12">
        <ad-button type="inverse" @click.native="getList();">搜索</ad-button>
        <ad-button type="primary" @click.native="btnEditHandller({});">添加</ad-button>
      </div>
    </div>

    <div
      class="alert alert-alt alert-warning alert-dismissible"
      style="margin-top:20px;"
      role="alert"
    >双击表格查看详情！</div>

    <ad-table :headers="headers" :list="list">
      <tbody>
        <tr
          v-for="item in list"
          :key="item.Id"
          style="cursor:pointer;"
          @dblclick="btnDetailHandller(item);"
        >
          <td>{{item.Id}}</td>
          <td>{{item.Title}}</td>
          <td>{{typeData.find(e=>e.key===item.Type).val}}</td>
          <td>{{item.Account}}</td>
          <td>{{item.Mobile|emptyFormats}}</td>
          <td>
            <el-link type="primary" :href="item.Url">网址</el-link>
          </td>
          <td>{{item.CreateTime|dateFormats}}</td>
          <td>
            <ad-button type="danger" size="sm" @click.native="btnDeleteHandller(item);">删除</ad-button>
            <ad-button type="primary" size="sm" @click.native="btnEditHandller(item);">编辑</ad-button>
          </td>
        </tr>
      </tbody>
    </ad-table>

    <ad-pagination
      v-if="list.length!=0"
      :total="TotalItems"
      :pageIndex="request.PageIndex"
      @currentChange="getList"
    ></ad-pagination>
  </ad-main>
</template>

<script>
import AdAccountEditComponent from "./edit";
import AdAccountDetailComponent from "./detail";
import adAccountService from "../../_api/adAccount.service";
export default {
  name: "AdAccountComponent",
  data() {
    return {
      headers: [
        "编号",
        "标题",
        "类型",
        "账号",
        "手机号",
        "地址",
        "注册时间",
        "操作"
      ],
      list: [],
      request: {
        Title: "",
        Type: -1,
        PageIndex: 1,
        PageSize: 10,
        OrderBy: "",
        IsDesc: true
      },
      TotalItems: 0,
      typeData: [
        {
          key: 0,
          val: "个人"
        },
        {
          key: 1,
          val: "工汇科技(公司)"
        },
        {
          key: 2,
          val: "添丁"
        }
      ],
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

      adAccountService
        .getAccountPageList(this.request)
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
      options.params.Type = IsUndefined ? item.Type : -1;
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

        if (params.Mobile && !this.valid$.isMobileValid(params.Mobile)) {
          this.$tip("请填写正确的手机号");
          return;
        }

        if (params.Email && !this.valid$.isEmailValid(params.Email)) {
          this.$tip("请填写正确的邮箱");
          return;
        }

        let result = null;

        if (params.Id === 0) {
          result = adAccountService.insertAccount(params);
        } else {
          result = adAccountService.updateAccountById(params);
        }

        result.then(response => {
          if (response.Data > 0 && response.Data !== null) {
            this.$tip("保存成功");
          }
          this.getList();
          close();
        });
      };
      this.modal$(options);
    },
    btnDeleteHandller(item) {
      let options = {};
      options.title = "确认提示";
      options.message = "确认要删除吗？";

      options.params = {};
      options.params.Id = item.Id;

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
    },
    btnDetailHandller(item) {
      let options = {
        title: item.Title,
        componentName: AdAccountDetailComponent,
        width: 400,
        height: 350,
        params: item,
        showSave: false
      };

      this.modal$(options);
    }
  }
};
</script>
