<template>
  <ad-left-main title="菜单管理" class="ad-menu">
    <div slot="left">
      <section class="page-aside-section" style="height:auto !important;">
        <h5 class="page-aside-title">
          导航目录
          <i class="icon ti-reload" @click="getMenuList();"></i>
        </h5>
        <div class="list-group">
          <a
            class="list-group-item"
            href="javascript:;"
            v-for="(item,index) in typeList"
            :key="index"
            :class="request.FatherId===item.Id?'active':''"
            @click="getList(item.Id);"
          >
            <i :class="item.MenuIcon" aria-hidden="true"></i>
            {{item.Title}}
            <p>
              <span class="icon ti-pencil" @click="btnEditHandller(item,0)"></span>
              <span class="icon ti-trash" @click="btnDeleteHandller(item,0)"></span>
            </p>
          </a>
        </div>
      </section>
    </div>
    <div slot="main">
      <div class="row row-lg" style="padding:0px !important;margin:0px !important;">
        <div class="col-sm-6 col-md-4">
          <div class="example-wrap">
            <h4 class="example-title">菜单名称</h4>
            <el-input
              size="small"
              v-model="request.Title"
              style="width:100%;"
              placeholder="请输入菜单名称"
            ></el-input>
          </div>
        </div>

        <div class="col-sm-12 col-md-12">
          <ad-button type="inverse" @click.native="getList(request.FatherId);">搜索</ad-button>
          <ad-button type="primary" @click.native="btnEditHandller({});">添加</ad-button>
        </div>
      </div>

      <ad-table :headers="headers" :list="list" style="padding:0 24px !important;">
        <tbody v-for="item in list" :key="item.Id">
          <tr>
            <td>
              <i class="fa fa-angle-right" style="cursor: pointer;"></i>
            </td>
            <td>{{item.Id}}</td>
            <td>
              <i :class="item.MenuIcon"></i>
              &nbsp;&nbsp;{{item.Title}}
            </td>
            <td>{{item.MenuUrl}}</td>
            <td>
              <input
                type="text"
                style="width:50px;text-align:center;"
                class="form-control"
                v-model="item.Sort"
                @blur="btnSortHandller(item)"
              />
            </td>
            <td>{{item.ModifyTime|dateFormats}}</td>
            <td>
              <ad-button type="danger" size="sm" @click.native="btnDeleteHandller(item);">删除</ad-button>
              <ad-button type="primary" size="sm" @click.native="btnEditHandller(item);">编辑</ad-button>
            </td>
          </tr>
        </tbody>
      </ad-table>
    </div>
  </ad-left-main>
</template>

<script>
import adMenuService from "../../_api/adMenu.service";
import AdMenuEditComponent from "./edit";
export default {
  name: "AdMenuComponent",
  data() {
    return {
      headers: ["", "编号", "菜单名称", "地址", "排序", "最后更新时间", "操作"],
      list: [],
      typeList: [],
      request: {
        Title: "",
        FatherId: 0,
        OrderBy: "Sort",
        IsDesc: false
      },
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

    this.getMenuList();
  },
  methods: {
    async getMenuList() {
      let params = {
        FatherId: 0,
        OrderBy: "Sort",
        IsDesc: false
      };

      let response = await adMenuService.getMenuList(params);

      if (response.Data.length > 0 && response.Data) {
        this.typeList = response.Data;

        this.getList(this.typeList[0].Id);
      }
    },
    async getList(type = 0) {
      try {
        this.list = [];

        this.request.FatherId = type === 0 ? this.typeList[0].Id : type;

        let response = await adMenuService.getMenuList(this.request);

        if (response.Data && response.Data.length !== 0) {
          this.list = response.Data;
        }
        this.loading.close();
      } catch (error) {
        this.loading.close();
      }
    },
    btnEditHandller(item = {}, no = 1) {
      let IsUndefined = item.Id !== undefined;
      let options = {};
      options.title = IsUndefined ? "修改菜单" : "添加菜单";
      options.componentName = AdMenuEditComponent;
      options.height = 350;
      options.params = {};
      options.params.Id = IsUndefined ? item.Id : 0;
      options.params.Title = IsUndefined ? item.Title : "";
      options.params.MenuIcon = IsUndefined ? item.MenuIcon : "";
      options.params.MenuUrl = IsUndefined ? item.MenuUrl : "#";
      options.params.FatherId = this.request.FatherId;
      options.params.LevelId = 0;
      options.params.Sort = IsUndefined ? item.Sort : 100;
      options.params.IsNo = item.FatherId === 0 ? 0 : 1;
      options.save = (params, close) => {
        if (!params.Title) {
          this.$tip("请填写菜单名称");
          return;
        }

        if (params.Sort === 0 && !params.Sort) {
          params.Sort = 100;
        }

        params.LevelId = params.FatherId === 0 ? 0 : 1;

        if (params.IsNo === 0) {
          params.FatherId = 0;
          params.MenuIcon = "fa fa-dashboard";
        }

        let result = null;

        if (params.Id === 0) {
          result = adMenuService.insertMenu(params);
        } else {
          result = adMenuService.updateMenuById(params);
        }

        result.then(response => {
          if (response.Data > 0 && response.Data !== null) {
            this.$tip("保存成功");
          }

          if (no === 1) {
            this.getList(this.request.FatherId);
          } else {
            this.getMenuList();
          }

          close();
        });
      };
      this.modal$(options);
    },
    btnDeleteHandller(item, no = 1) {
      let options = {};
      options.title = "确认提示";
      options.message = "确认要删除吗？";

      options.params = {};
      options.params.Id = item.Id;

      options.save = (params, close) => {
        console.log(params);
        adMenuService.deleteMenuById(params).then(response => {
          if (response.Data > 0 && response.Data !== null) {
            this.$tip("删除成功");
          }

          if (no === 1) {
            this.getList(this.request.FatherId);
          } else {
            this.getMenuList();
          }

          close();
        });
      };

      this.confirm$(options);
    },
    btnSortHandller(item) {
      let params = {};
      params.Id = item.Id;
      params.Sort = item.Sort;
      adMenuService.updateMenuSortById(params).then(response => {
        console.log(response);
        this.getList(this.request.FatherId);
      });
    }
  }
};
</script>

<style lang="scss">
.ad-menu {
  .page-aside-section {
    .page-aside-title {
      i {
        margin-left: 30px;
        cursor: pointer;
      }
    }
    .list-group {
      display: flex;
      flex-direction: column;
      padding-left: 0;
      margin-bottom: 22px;
      -webkit-box-orient: vertical;
      -webkit-box-direction: normal;
      a {
        position: relative;
        display: block;
        padding: 13px 20px;
        margin-bottom: 1px;
        border: 0;
        overflow: hidden;
        text-overflow: ellipsis;
        white-space: nowrap;
        text-decoration: none;
        background: none;
        &:hover{
          p{
            display: block;
          }
        }
        p {
          width: auto;
          position: absolute;
          right: 10px;
          top: 0;
          height: 48px;
          line-height: 48px;
          text-align: center;
          display: none;
          span {
            margin: 0px !important;
            padding: 0 5px;
            cursor: pointer;
          }
        }
        
        &.active {
          color: #3e8ef7;
          background-color: #f3f7f9;
        }
      }
    }
  }
}
</style>

