<template>
  <div class="page right-edit">
    <div class="example-wrap">
      <h4 class="example-title">
        菜单名称
        <span style="color:#f00;padding-left:5px;">*</span>
      </h4>
      <input type="text" class="form-control" v-model="params.Title" placeholder="菜单名称" />
    </div>

    <div class="example-wrap">
      <h4 class="example-title">父级</h4>
      <select class="form-control" v-model="params.FatherId">
        <option :value="0">请选择父级</option>
        <option v-for="(item,index) in list" :key="index" :value="item.Id">{{item.Title}}</option>
      </select>
    </div>

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

    <div class="example-wrap" v-if="params.FatherId===0">
      <h4 class="example-title">图标</h4>
      <input
        type="text"
        class="form-control"
        autocomplete="off"
        v-model="params.MenuIcon"
        placeholder="图标"
      />
    </div>

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
</template>

<script>
import adMenuService from "../../_api/adMenu.service";
export default {
  name: "AdMenuEditComponent",
  props: {
    params: {
      type: Object,
      default: {}
    }
  },
  data() {
    return {
      list: []
    };
  },
  mounted() {
    this.getMenuListByFatherId();
  },
  methods: {
    getMenuListByFatherId() {
      this.list = [];

      let params = {};
      params.FatherId = 0;
      params.IsDesc = true;

      adMenuService.getMenuListByFatherId(params).then(response => {
        if (response.Data !== null && response.Data.length !== 0) {
          this.list = response.Data;
        }
      });
    }
  }
};
</script>
