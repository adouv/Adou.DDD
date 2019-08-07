<template>
  <div class="page right-edit">
    <div class="example-wrap">
      <h4 class="example-title">标题<span style="color:#f00;padding-left:5px;">*</span></h4>
      <input type="text" class="form-control" v-model="params.Title" placeholder="标题" />
    </div>

    <div class="example-wrap">
      <h4 class="example-title">账号<span style="color:#f00;padding-left:5px;">*</span></h4>
      <input type="text" class="form-control" autocomplete="off" v-model="params.Account" placeholder="账号" />
    </div>

    <div class="example-wrap">
      <h4 class="example-title">密码<span style="color:#f00;padding-left:5px;">*</span></h4>
      <input type="password" class="form-control" autocomplete="off" v-model="params.Password" placeholder="密码" />
    </div>

    <div class="example-wrap">
      <h4 class="example-title">链接</h4>
      <input type="text" class="form-control" v-model="params.Url" placeholder="链接" />
    </div>

    <div class="example-wrap">
      <h4 class="example-title">手机号</h4>
      <input type="text" class="form-control" v-model="params.Mobile" placeholder="手机号" />
    </div>

    <div class="example-wrap">
      <h4 class="example-title">邮箱</h4>
      <input type="text" class="form-control" v-model="params.Email" placeholder="邮箱" />
    </div>

    <div class="example-wrap">
      <h4 class="example-title">关键词</h4>
      <input type="text" class="form-control" v-model="params.Keyword" placeholder="关键词" />
    </div>

    <div class="example-wrap">
      <h4 class="example-title">描述</h4>
      <textarea class="form-control" v-model="params.Descript" rows="3" placeholder="描述"></textarea>
    </div>
  </div>
</template>

<script>
export default {
  name: "AdAccountEditComponent",
  props: {
    params: {
      type: Object,
      default: {}
    }
  }
};
</script>
