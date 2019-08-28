<template>
  <ad-main :title="`用户管理 / ${params.Id===0?'添加':'编辑'}用户`" :back="true" class="ad-user-edit">
    <div class="row row-lg">
      <div class="col-sm-12 col-md-12">
        <div class="example-wrap">
          <h4 class="example-title">
            <span style="color:#f00;padding-left:5px;">*</span>用户名
          </h4>
          <input
            type="text"
            class="form-control"
            autocomplete="off"
            v-model="params.UserName"
            placeholder="用户名"
          />
        </div>
      </div>

      <div class="col-sm-12 col-md-12">
        <div class="example-wrap">
          <h4 class="example-title">
            <span style="color:#f00;padding-left:5px;">*</span>密码
          </h4>
          <input
            type="password"
            class="form-control"
            autocomplete="off"
            v-model="params.UserPwd"
            placeholder="密码"
          />
        </div>
      </div>

      <div class="col-sm-12 col-md-12">
        <div class="example-wrap">
          <h4 class="example-title">
            <span style="color:#f00;padding-left:5px;">*</span>确认密码
          </h4>
          <input
            type="password"
            class="form-control"
            autocomplete="off"
            v-model="params.ReUserPwd"
            placeholder="确认密码"
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
          <h4 class="example-title">是否超级管理员</h4>
          <ul class="list-unstyled list-inline">
            <li class="list-inline-item" v-for="item in UserTypeData" :key="item.key">
              <div class="radio-custom radio-primary">
                <input
                  type="radio"
                  :id="`UserType${item.key}`"
                  :name="`UserType${item.key}`"
                  v-model="params.UserType"
                  :value="item.key"
                />
                <label :for="`UserType${item.key}`">{{item.val}}</label>
              </div>
            </li>
          </ul>
        </div>
      </div>

      <div class="col-sm-12 col-md-12" v-if="params.UserType===0">
        <div class="example-wrap">
          <h4 class="example-title">角色</h4>
          <el-select
            v-model="roleIds"
            size="mini"
            clearable
            multiple
            placeholder="请选择"
            style="width:100%;"
          >
            <el-option
              v-for="(item,index) in roleList"
              :key="index"
              :label="item.RoleName"
              :value="item.Id"
            ></el-option>
          </el-select>
        </div>
      </div>

      <div class="col-sm-12 col-md-12">
        <div class="example-wrap">
          <h4 class="example-title">是否启用</h4>
          <ul class="list-unstyled list-inline">
            <li class="list-inline-item" v-for="item in UserStatusData" :key="item.key">
              <div class="radio-custom radio-primary">
                <input
                  type="radio"
                  :id="`UserStatus${item.key}`"
                  :name="`UserStatus${item.key}`"
                  v-model="params.UserStatus"
                  :value="item.key"
                />
                <label :for="`UserStatus${item.key}`">{{item.val}}</label>
              </div>
            </li>
          </ul>
        </div>
      </div>

      <div class="col-sm-12 col-md-12">
        <ad-button type="secondary" @click.native="$router.push({ name: 'adUser' })">返回</ad-button>
        <ad-button type="primary" @click.native="btnSave()">保存</ad-button>
      </div>
    </div>
  </ad-main>
</template>

<script>
import adUserService from "../../_api/adUser.service";
import adRoleService from "../../_api/adRole.service";
export default {
  name: "AdUserEditComponent",
  data() {
    return {
      params: {
        Id: 0,
        UserName: "",
        UserPwd: "",
        ReUserPwd: "",
        UserHead: "",
        UserType: 0,
        UserStatus: 0,
        RoleId: 0,
        Sort: 100
      },
      roleList: [],
      roleIds: [],
      UserStatusData: [{ key: 0, val: "禁用" }, { key: 1, val: "启用" }],
      UserTypeData: [{ key: 0, val: "否" }, { key: 1, val: "是" }],
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

    this.params.UserPwd = "";
    this.params.ReUserPwd = "";

    this.getRoleList();
  },
  methods: {
    getRoleList() {
      let params = {};

      adRoleService
        .getRoleList(params)
        .then(response => {
          if (response.Data) {
            this.roleList = response.Data;
          }

          if (this.roleList.length > 0 && this.params.Id > 0) {
            this.params.RoleList.forEach(element => {
              this.roleIds.push(element.Id);
            });
          }

          this.loading.close();
        })
        .catch(err => {
          this.loading.close();
        });
    },
    async btnSave() {
      if (!this.params.UserName) {
        this.$tip("请填写用户名");
        return;
      }

      if (this.params.Id === 0) {
        if (!this.params.UserPwd) {
          this.$tip("请填写密码");
          return;
        }

        if (!this.params.ReUserPwd) {
          this.$tip("请填写确认密码");
          return;
        }

        if (this.params.UserPwd !== this.params.ReUserPwd) {
          this.$tip("两次输入密码不一致");
          return;
        }
      } else {
        if (this.params.UserPwd || this.params.ReUserPwd) {
          if (this.params.UserPwd !== this.params.ReUserPwd) {
            this.$tip("两次输入密码不一致");
            return;
          }
        }
      }

      if (!this.params.Sort) {
        this.$tip("请填写排序值");
        return;
      }

      if (this.params.UserType === 0) {
        if (this.roleIds.length === 0) {
          this.$tip("请选择角色");
          return;
        }
      }

      this.params.RoleArr = this.roleIds;

      console.log(this.params);

      let result = null;

      try {
        if (this.params.Id === 0) {
          result = adUserService.insertUserAndRole(this.params);
        } else {
          result = adUserService.updateUserAndRoleById(this.params);
        }

        let response = await result;

        if (response.Data > 0 && response.Data !== null) {
          this.$tip("保存成功");
        }

        this.$router.push({ name: "adUser" });
      } catch (error) {
        this.$tip("保存失败");
      }
    }
  }
};
</script>
