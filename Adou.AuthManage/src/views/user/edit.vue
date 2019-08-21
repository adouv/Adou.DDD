<template>
  <ad-main :title="`用户管理 - ${params.Id==undefined?'添加':'编辑'}用户`" class="ad-user-edit">
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
            <li class="list-inline-item" v-for="item in UserTypeData" :key="item.id">
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

      <div class="col-sm-12 col-md-12">
        <div class="example-wrap">
          <h4 class="example-title">是否启用</h4>
          <ul class="list-unstyled list-inline">
            <li class="list-inline-item" v-for="item in UserStatusData" :key="item.id">
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
export default {
  name: "AdUserEditComponent",
  data() {
    return {
      params: {},
      UserStatusData: [{ key: 0, val: "禁用" }, { key: 1, val: "启用" }],
      UserTypeData: [{ key: 0, val: "否" }, { key: 1, val: "是" }]
    };
  },
  mounted() {
    this.params = this.$route.params;

    this.params.UserPwd = "";
    this.params.ReUserPwd = "";

    if (this.params.Id === undefined) {
      this.params.Id = 0;
      this.params.UserName = "";
      this.params.UserHead = "";
      this.params.UserType = 0;
      this.params.UserStatus = 0;
      this.params.RoleId = 0;
      this.params.Sort = 100;
    }
  },
  methods: {}
};
</script>
