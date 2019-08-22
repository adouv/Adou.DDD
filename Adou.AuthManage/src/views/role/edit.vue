<template>
  <ad-main :title="`角色管理 / ${params.Id===0?'添加':'编辑'}角色`" :back="true" class="ad-role-edit">
    <div class="row row-lg">
      <div class="col-sm-12 col-md-12">
        <div class="example-wrap">
          <h4 class="example-title">
            <span style="color:#f00;padding-left:5px;">*</span>角色名称
          </h4>
          <input
            type="text"
            class="form-control"
            autocomplete="off"
            v-model="params.RoleName"
            placeholder="角色名称"
          />
        </div>
      </div>

      <div class="col-sm-12 col-md-12">
        <div class="example-wrap">
          <h4 class="example-title">排序</h4>
          <input type="text" class="form-control" v-model="params.Sort" placeholder="排序" />
        </div>
      </div>

      <div class="col-sm-12 col-md-12">
        <ad-button type="secondary" @click.native="$router.push({ name: 'adRole' })">返回</ad-button>
        <ad-button type="primary" @click.native="btnSave()">保存</ad-button>
      </div>
    </div>
  </ad-main>
</template>

<script>
import adRoleService from "../../_api/adRole.service";
export default {
  name: "AdRoleEditComponent",
  data() {
    return {
      params: {}
    };
  },
  mounted() {
    this.params = this.$route.params;

    if (this.params.Id === undefined) {
      this.params.Id = 0;
      this.params.RoleName = "";
      this.params.IsDel = false;
      this.params.Sort = 100;
    }
  },
  methods: {
    btnSave() {
      if (!this.params.RoleName) {
        this.$tip("请填写角色名称");
        return;
      }

      if (!this.params.Sort) {
        this.params.Sort=100;
      }

      let result = null;

      if (this.params.Id === 0) {
        result = adRoleService.insertRole(this.params);
      } else {
        result = adRoleService.updateRoleById(this.params);
      }

      result.then(response => {
        if (response.Data > 0 && response.Data !== null) {
          this.$tip("保存成功");
        }
        this.$router.push({ name: "adRole" });
      });
    }
  }
};
</script>
