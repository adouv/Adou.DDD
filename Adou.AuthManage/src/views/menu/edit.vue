<template>
  <div class="page ad-menu-edit">
    <div class="col-sm-12 col-md-12">
      <div class="example-wrap">
        <h4 class="example-title">
          <span style="color:#f00;padding-right:5px;">*</span>菜单名称
        </h4>
        <input type="text" class="form-control" v-model="params.Title" placeholder="菜单名称" />
      </div>

      <div class="example-wrap">
        <h4 class="example-title">是否导航目录</h4>
        <ul class="list-unstyled list-inline">
          <li class="list-inline-item" v-for="item in noList" :key="item.key">
            <div class="radio-custom radio-primary">
              <input
                type="radio"
                :id="`IsNo${item.key}`"
                :name="`IsNo${item.key}`"
                v-model="params.IsNo"
                :value="item.key"
              />
              <label :for="`IsNo${item.key}`">{{item.val}}</label>
            </div>
          </li>
        </ul>
      </div>

      <div class="example-wrap">
        <h4 class="example-title">地址</h4>
        <input type="text" class="form-control" v-model="params.MenuUrl" placeholder="地址" :disabled="params.IsNo===0" />
      </div>

      <!-- <div class="example-wrap" v-if="params.IsNo===0">
        <h4 class="example-title">图标</h4>
        <input type="text" class="form-control" v-model="params.MenuIcon" placeholder="图标" />
      </div>-->

      <div class="example-wrap">
        <h4 class="example-title">排序</h4>
        <input type="text" class="form-control" v-model="params.Sort" placeholder="排序" />
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "AdMenuEditComponent",
  props: {
    params: {
      type: Object,
      default: {}
    }
  },
  data() {
    return {
      noList: [{ key: 0, val: "是" }, { key: 1, val: "否" }]
    };
  }
};
</script>
