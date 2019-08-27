<template>
  <ad-main
    :title="`数据字典管理 / ${params.Id==undefined?'添加':'编辑'}数据字典`"
    :back="true"
    class="ad-dictionary-edit"
  >
    <div class="row row-lg">
      <div class="col-sm-12 col-md-12">
        <div class="example-wrap">
          <h4 class="example-title">编码</h4>
          <input type="text" class="form-control" v-model="params.DicCoding" placeholder="编码" />
        </div>
      </div>

      <div class="col-sm-12 col-md-12">
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
      </div>

      <div class="col-sm-12 col-md-12">
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
      </div>

      <div class="col-sm-12 col-md-12">
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

      <div class="col-sm-12 col-md-12">
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

      <div class="col-sm-12 col-md-12">
        <ad-button
          type="secondary"
          @click.native="$router.push({ name: 'adDictionary',params:{DicType:params.DicType} })"
        >返回</ad-button>
        <ad-button type="primary" @click.native="btnSave()">保存</ad-button>
      </div>
    </div>
  </ad-main>
</template>

<script>
import adDictionaryService from "../../_api/adDictionary.service";
export default {
  name: "AdDictionaryEditComponent",
  data() {
    return {
      params: {
        Id: 0,
        DicKey: "",
        DicValue: "",
        DicCoding: "",
        DicType: 0,
        Sort: 100,
        Remark: ""
      },
      list: []
    };
  },
  mounted() {

    let params = this.$route.params;

    if (params.Id !== undefined) {
      this.params = params;
    } else {
      this.params.DicType = params.DicType;
    }

    console.log(this.params);
  },
  methods: {
    btnSave() {
      if (!this.params.DicKey) {
        this.$tip("请填写键");
        return;
      }

      if (!this.params.DicValue) {
        this.$tip("请填写值");
        return;
      }

      if (this.params.Sort === 0 && !this.params.Sort) {
        this.params.Sort = 100;
      }

      let result = null;

      if (this.params.Id === 0) {
        result = adDictionaryService.insertDictionary(this.params);
      } else {
        result = adDictionaryService.updateDictionaryById(this.params);
      }

      result.then(response => {
        if (response.Data > 0 && response.Data !== null) {
          this.$tip("保存成功");
        }
        this.$router.push({
          name: "adDictionary",
          params: { DicType: this.params.DicType }
        });
      });
    }
  }
};
</script>
