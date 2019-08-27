<template>
  <ad-main title="菜单管理" class="ad-account">
    <div class="row row-lg">
      <div class="col-sm-12 col-md-12">
        <ad-button type="inverse" @click.native="getList();">搜索</ad-button>
        <ad-button
          type="primary"
          @click.native="$router.push({ name: 'adMenuEdit', params: {} })"
        >添加</ad-button>
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
          <td>
            <input
              type="text"
              style="width:50px;text-align:center;"
              class="form-control"
              v-model="item.Sort"
              @blur="sortHandller(item)"
            />
          </td>
          <td>{{item.CreateTime|dateFormats}}</td>
          <td>
            <ad-button type="danger" size="sm" @click.native="btnDeleteHandller(item);">删除</ad-button>
            <ad-button
              type="primary"
              size="sm"
              @click.native="$router.push({ name: 'adMenuEdit', params: item })"
            >编辑</ad-button>
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
          <td>
            <input
              type="text"
              style="width:50px;text-align:center;"
              class="form-control"
              v-model="items.Sort"
              @blur="sortHandller(items)"
            />
          </td>
          <td>{{items.CreateTime|dateFormats}}</td>
          <td>
            <ad-button type="danger" size="sm" @click.native="btnDeleteHandller(items);">删除</ad-button>
            <ad-button
              type="primary"
              size="sm"
              @click.native="$router.push({ name: 'adMenuEdit', params: items })"
            >编辑</ad-button>
          </td>
        </tr>
      </tbody>
    </ad-table>
  </ad-main>
</template>

<script>
import adMenuService from "../../_api/adMenu.service";
export default {
  name: "AdMenuComponent",
  data() {
    return {
      headers: ["", "编号", "菜单名称", "地址", "排序", "创建时间", "操作"],
      list: [],
      request: {
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

    this.getList();
  },
  methods: {
    getList() {
      this.list = [];

      adMenuService
        .getMenuList(this.request)
        .then(response => {
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
                  Sort: element.Sort,
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
                    LevelId: subElement.LevelId,
                    Sort: subElement.Sort
                  });
                }
              });
            });
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
    },
    sortHandller(item) {
      let params = {};
      params.Id = item.Id;
      params.Sort = item.Sort;
      adMenuService.updateMenuSortById(params).then(response => {
        console.log(response);
        this.getList();
      });
    }
  }
};
</script>

