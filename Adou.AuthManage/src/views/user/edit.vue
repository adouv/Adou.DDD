<template>
  <div class="page right-edit">
    <div class="example-wrap">
      <h4 class="example-title">
        用户名
        <span style="color:#f00;padding-left:5px;">*</span>
      </h4>
      <input type="text" class="form-control" autocomplete="off" v-model="params.UserName" placeholder="用户名" />
    </div>

    <div class="example-wrap">
      <h4 class="example-title">
        密码
        <span style="color:#f00;padding-left:5px;">*</span>
      </h4>
      <input type="password" class="form-control" autocomplete="off" v-model="params.UserPwd" placeholder="密码" />
    </div>

    <div class="example-wrap">
      <h4 class="example-title">
        确认密码
        <span style="color:#f00;padding-left:5px;">*</span>
      </h4>
      <input type="password" class="form-control" autocomplete="off" v-model="params.ReUserPwd" placeholder="确认密码" />
    </div>

    <div class="example-wrap">
      <h4 class="example-title">排序</h4>
      <input type="text" class="form-control" v-model="params.Sort" placeholder="排序" />
    </div>

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
</template>

<script>
export default {
  name: "AdUserEditComponent",
  props: {
    params: {
      type: Object,
      default: {}
    }
  },
  data() {
    return {
      UserStatusData: [{ key: 0, val: "禁用" }, { key: 1, val: "启用" }],
      UserTypeData: [{ key: 0, val: "否" }, { key: 1, val: "是" }]
    };
  }
};
</script>
