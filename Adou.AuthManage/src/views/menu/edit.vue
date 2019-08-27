<template>
  <ad-main :title="`菜单管理 / ${params.Id==undefined?'添加':'编辑'}菜单`" :back="true" class="ad-menu-edit">
    <div class="row row-lg">
      <div class="col-sm-12 col-md-12">
        <div class="example-wrap">
          <h4 class="example-title">
            <span style="color:#f00;padding-left:5px;">*</span>菜单名称
          </h4>
          <input type="text" class="form-control" v-model="params.Title" placeholder="菜单名称" />
        </div>
      </div>

      <div class="col-sm-12 col-md-12">
        <div class="example-wrap">
          <h4 class="example-title">父级</h4>
          <select class="form-control" v-model="params.FatherId">
            <option :value="0">请选择父级</option>
            <option v-for="(item,index) in list" :key="index" :value="item.Id">{{item.Title}}</option>
          </select>
        </div>
      </div>

      <div class="col-sm-12 col-md-12">
        <div class="example-wrap">
          <h4 class="example-title">地址</h4>
          <input
            type="text"
            class="form-control"
            autocomplete="off"
            v-model="params.MenuUrl"
            placeholder="地址"
          />
        </div>
      </div>

      <div class="col-sm-12 col-md-12">
        <div class="example-wrap">
          <h4 class="example-title">图标</h4>
          <input
            type="text"
            class="form-control"
            autocomplete="off"
            v-model="params.MenuIcon"
            placeholder="图标"
          />
        </div>
      </div>

      <div class="col-sm-12 col-md-12">
        <div class="example-wrap">
          <h4 class="example-title">排序</h4>
          <input
            type="text"
            class="form-control"
            autocomplete="off"
            v-model="params.Sort"
            placeholder="排序"
          />
        </div>
      </div>

      <div class="col-sm-12 col-md-12">
        <ad-button type="secondary" @click.native="$router.push({ name: 'adMenu' })">返回</ad-button>
        <ad-button type="primary" @click.native="btnSave()">保存</ad-button>
      </div>
    </div>
  </ad-main>
</template>

<script>
import adMenuService from "../../_api/adMenu.service";
export default {
  name: "AdMenuEditComponent",
  data() {
    return {
      params: {
        Id: 0,
        Title: "",
        MenuIcon: "",
        MenuUrl: "#",
        FatherId: 0,
        LevelId: 0,
        Sort: 100
      },
      list: [],
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

    let params = this.$route.params;

    if (params.Id !== undefined) {
      this.params = params;
    }

    console.log(this.params);

    this.getMenuListByFatherId();
  },
  methods: {
    getMenuListByFatherId() {
      this.list = [];

      let params = {};
      params.FatherId = 0;
      params.IsDesc = true;

      adMenuService
        .getMenuListByFatherId(params)
        .then(response => {
          if (response.Data !== null && response.Data.length !== 0) {
            this.list = response.Data;
          }

          this.loading.close();
        })
        .catch(err => {
          this.loading.close();
        });
    },
    btnSave() {
      this.params.LevelId = this.params.FatherId === 0 ? 0 : 1;

      if (!this.params.Title) {
        this.$tip("请填写菜单名称");
        return;
      }

      let result = null;

      if (this.params.Id === 0) {
        result = adMenuService.insertMenu(this.params);
      } else {
        result = adMenuService.updateMenuById(this.params);
      }

      result.then(response => {
        if (response.Data > 0 && response.Data !== null) {
          this.$tip("保存成功");
        }
        this.$router.push({ name: "adMenu" });
      });
    }
  }
};
</script>
