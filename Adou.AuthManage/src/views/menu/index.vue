<template>
  <ad-main title="菜单管理" class="ad-account">
    <div class="row row-lg">
      <div class="col-sm-12 col-md-12">
        <ad-button type="inverse" @click.native="getList();">搜索</ad-button>
        <ad-button type="primary" @click.native="btnEditHandller({});">添加</ad-button>
      </div>
    </div>

    <ad-table :headers="headers" :list="list">
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
          <td>{{item.CreateTime|dateTimeFormats}}</td>
          <td>
            <ad-button type="danger" size="sm" @click.native="btnDeleteHandller(item);">删除</ad-button>
            <ad-button type="primary" size="sm" @click.native="btnEditHandller(item);">编辑</ad-button>
          </td>
        </tr>
        <tr v-for="items in item.children" :key="items.Id">
          <td></td>
          <td>{{items.Id}}</td>
          <td>
            <i class="fa fa-angle-right"></i>
            <i class="fa fa-angle-right"></i>
            <i class="fa fa-angle-right"></i>
            &nbsp;{{items.Title}}
          </td>
          <td>{{items.MenuUrl}}</td>
          <td>{{items.CreateTime|dateTimeFormats}}</td>
          <td>
            <ad-button type="danger" size="sm" @click.native="btnDeleteHandller(items);">删除</ad-button>
            <ad-button type="primary" size="sm" @click.native="btnEditHandller(items);">编辑</ad-button>
          </td>
        </tr>
      </tbody>
    </ad-table>
  </ad-main>
</template>

<script>
import adMenuService from "../../_api/adMenu.service";
import AdMenuEditComponent from "./edit.vue";
export default {
  name: "AdMenuComponent",
  data() {
    return {
      headers: ["", "编号", "菜单名称", "地址", "创建时间", "操作"],
      list: [],
      request: {}
    };
  },
  mounted() {
    this.getList();
  },
  methods: {
    getList() {
      this.list = [];

      adMenuService.getMenuList(this.request).then(response => {
        if (response.Data !== null && response.Data.length !== 0) {
          response.Data.forEach(element => {
            let children = [];

            if (element.FatherId === 0) {
              this.list.push({
                Id: element.Id,
                Title: element.Title,
                MenuIcon: element.MenuIcon,
                MenuUrl: "#",
                FatherId: element.FatherId,
                LevelId: element.LevelId,
                isSubShow: false,
                children: children
              });
            }

            response.Data.forEach(subElement => {
              if (subElement.FatherId === element.Id) {
                children.push({
                  Id: subElement.Id,
                  Title: subElement.Title,
                  MenuIcon: "",
                  MenuUrl: subElement.MenuUrl,
                  FatherId: subElement.FatherId,
                  LevelId: subElement.LevelId
                });
              }
            });
          });
        }
      });
    },
    btnEditHandller(item) {
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
      options.params.FatherId = IsUndefined ? item.FatherId : 0;
      options.params.LevelId = IsUndefined ? item.LevelId : 0;

      options.save = (params, close) => {
        params.LevelId = params.FatherId === 0 ? 0 : 1;

        if (!params.Title) {
          this.$tip("请填写菜单名称");
          return;
        }

        console.log(params);

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
      options.params.IsDel = 1;

      options.save = (params, close) => {
        console.log(params);
        adMenuService.deleteMenuById(params).then(response => {
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

