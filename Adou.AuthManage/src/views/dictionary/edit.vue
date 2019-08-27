<template>
  <div class="page ad-dictionary-edit">
    <div class="example-wrap">
      <h4 class="example-title">编码</h4>
      <input type="text" class="form-control" v-model="params.DicCoding" placeholder="编码" />
    </div>

    <div class="example-wrap">
      <h4 class="example-title">
        <span style="color:#f00;padding-right:5px;">*</span>键
      </h4>
      <input
        type="text"
        class="form-control"
        autocomplete="off"
        v-model="params.DicKey"
        placeholder="键"
      />
    </div>

    <div class="example-wrap">
      <h4 class="example-title">
        <span style="color:#f00;padding-right:5px;">*</span>值
      </h4>
      <input
        type="text"
        class="form-control"
        autocomplete="off"
        v-model="params.DicValue"
        placeholder="值"
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

    <div class="example-wrap">
      <h4 class="example-title">备注</h4>
      <input
        type="text"
        class="form-control"
        autocomplete="off"
        v-model="params.Remark"
        placeholder="备注"
      />
    </div>
  </div>
</template>

<script>
import adDictionaryService from "../../_api/adDictionary.service";
export default {
  name: "AdDictionaryEditComponent",
  props: {
    params: {
      type: Object,
      default: {}
    }
  }
};
</script>
