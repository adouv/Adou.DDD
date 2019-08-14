<template>
  <div class="page right-edit">
    <div class="form-group row">
      <label class="col-md-3 col-form-label">标题：</label>
      <div class="col-md-9">{{params.Title}}</div>
    </div>

    <div class="form-group row">
      <label class="col-md-3 col-form-label">类型：</label>
      <div class="col-md-9">{{typeData.find(e=>e.key===params.Type).val}}</div>
    </div>

    <div class="form-group row">
      <label class="col-md-3 col-form-label">账号：</label>
      <div class="col-md-9">{{params.Account}}</div>
    </div>

    <div class="form-group row">
      <label class="col-md-3 col-form-label">密码：</label>
      <div class="col-md-9">{{params.Password}}</div>
    </div>

    <div class="form-group row">
      <label class="col-md-3 col-form-label">链接：</label>
      <div class="col-md-9">{{params.Url}}</div>
    </div>

    <div class="form-group row">
      <label class="col-md-3 col-form-label">手机号：</label>
      <div class="col-md-9">{{params.Mobile|emptyFormats}}</div>
    </div>

    <div class="form-group row">
      <label class="col-md-3 col-form-label">邮箱：</label>
      <div class="col-md-9">{{params.Email|emptyFormats}}</div>
    </div>

    <div class="form-group row">
      <label class="col-md-3 col-form-label">关键词：</label>
      <div class="col-md-9">{{params.Keyword|emptyFormats}}</div>
    </div>

    <div class="form-group row">
      <label class="col-md-3 col-form-label">描述：</label>
      <div class="col-md-9">{{params.Descript|emptyFormats}}</div>
    </div>
  </div>
</template>

<script>
export default {
  name: "AdAccountDetailComponent",
  props: {
    params: {
      type: Object,
      default: {}
    }
  },
  data() {
    return {
      typeData: [
        {
          key: 0,
          val: "个人"
        },
        {
          key: 1,
          val: "工汇科技(公司)"
        },
        {
          key: 2,
          val: "添丁"
        }
      ]
    };
  }
};
</script>
