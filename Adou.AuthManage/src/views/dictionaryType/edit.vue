<template>
  <div class="page right-edit">
    <div class="example-wrap">
      <h4 class="example-title">编码</h4>
      <input type="text" class="form-control" v-model="params.Coding" placeholder="标题" />
    </div>

    <div class="example-wrap">
      <h4 class="example-title">
        <span style="color:#f00;padding-right:5px;">*</span>名称
      </h4>
      <input
        type="text"
        class="form-control"
        autocomplete="off"
        v-model="params.Name"
        placeholder="名称"
      />
    </div>

    <div class="example-wrap">
      <h4 class="example-title">排序</h4>
      <input type="text" class="form-control" v-model="params.Sort" placeholder="排序" />
    </div>

    <div class="example-wrap">
      <h4 class="example-title">备注</h4>
      <input type="text" class="form-control" v-model="params.Remark" placeholder="备注" />
    </div>
  </div>
</template>

<script>
export default {
  name: "AdDictionaryTypeEditComponent",
  props: {
    params: {
      type: Object,
      default: {}
    }
  }
};
</script>
