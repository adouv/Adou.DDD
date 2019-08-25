<template>
  <ad-main :title="`角色管理 / ${params.Id===0?'添加':'编辑'}角色`" :back="true" class="ad-role-edit">
    <div class="row row-lg">
      <div class="col-sm-12 col-md-12">
        <div class="example-wrap">
          <h4 class="example-title">
            <span style="color:#f00;padding-right:5px;">*</span>角色名称
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
        <div class="example-wrap">
          <h4 class="example-title">菜单</h4>
          <el-tree
            v-if="menuList.length!==0"
            :data="menuList"
            show-checkbox
            node-key="id"
            default-expand-all
            :default-checked-keys="defaultCheckedKeys"
            :props="defaultProps"
            ref="tree"
          ></el-tree>
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
import adMenuService from "../../_api/adMenu.service";
export default {
  name: "AdRoleEditComponent",
  data() {
    return {
      params: {
        CreateTime: "",
        CreateUser: "",
        Id: 0,
        IsDel: false,
        MenuList: [],
        ModifyTime: "",
        ModifyUser: "",
        RoleName: "",
        Sort: 0
      },
      menuList: [],
      defaultCheckedKeys: [],
      defaultProps: {
        children: "children",
        label: "label"
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

    let params = this.$route.params;

    if (params.Id !== undefined) {
      this.params = params;
    }

    console.log(this.params);
    console.log(this.defaultCheckedKeys);

    this.getMenuList();
  },
  methods: {
    async getMenuList() {
      let response = await adMenuService.getMenuList(this.request);

      try {
        if (response.Data !== null && response.Data.length !== 0) {
          response.Data.forEach(element => {
            let children = [];

            if (element.FatherId === 0) {
              this.menuList.push({
                id: element.Id,
                label: element.Title,
                icon: element.MenuIcon,
                url: "#",
                pid: element.FatherId,
                lid: element.LevelId,
                children: children
              });
            }

            response.Data.forEach(subElement => {
              if (subElement.FatherId === element.Id) {
                children.push({
                  id: subElement.Id,
                  label: subElement.Title,
                  icon: "",
                  url: subElement.MenuUrl,
                  pid: subElement.FatherId,
                  lid: subElement.LevelId
                });
              }
            });
          });
        }

        if (this.menuList.length > 0 && this.params.Id > 0) {
          this.params.MenuList.forEach(element => {
            if (element.FatherId !== 0) {
              this.defaultCheckedKeys.push(element.Id);
            }
          });

          this.$refs.tree.setCheckedKeys(this.defaultCheckedKeys);
        }

        this.loading.close();
      } catch (error) {
        this.loading.close();
      }
    },
    async btnSave() {
      let checkKeys = this.$refs.tree.getCheckedKeys();
      let halfKeys = this.$refs.tree.getHalfCheckedKeys();
      let keys = checkKeys.concat(halfKeys);
      console.log(keys);

      if (!this.params.RoleName) {
        this.$tip("请填写角色名称");
        return;
      }

      if (!this.params.Sort) {
        this.params.Sort = 100;
      }

      let result = null;

      try {
        if (this.params.Id === 0) {
          result = adRoleService.insertRole(this.params);
        } else {
          result = adRoleService.updateRoleById(this.params);
        }

        let response = await result;

        if (response.Data > 0 && response.Data !== null) {
          let promiseAll = [];

          let rid = this.params.Id > 0 ? this.params.Id : response.Data;

          keys.forEach(menu => {
            let args = {
              RoleId: rid,
              MenuId: menu
            };

            promiseAll.push(adRoleService.insertRoleAndMenu(args));
          });

          let r = await this.http$.all(promiseAll);

          if (r.length > 0) {
            this.$tip("保存成功");
          }

          if (r.length === 0) {
            this.$tip("菜单保存失败");
          }
        }
        this.$router.push({ name: "adRole" });
      } catch (error) {
        this.$tip("保存失败");
      }
    }
  }
};
</script>

<style lang="scss">
.ad-role-edit {
  .el-tree {
    border: 1px solid #e4eaec;
    .el-tree-node {
      line-height: 28px !important;
      .el-checkbox {
        margin-right: 5px;
        padding-top: 4px;
      }
    }
  }
}
</style>