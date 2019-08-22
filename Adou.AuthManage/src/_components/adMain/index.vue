<template>
  <div class="page material ad-main-component" :class="className">
    <div class="page-header">
      <h1 class="page-title">
        {{title}}
        <span v-if="back" @click="btnBackHandller">
          <i class="icon ti-back-left" aria-hidden="true"></i>返回
        </span>
      </h1>
    </div>
    <div class="page-content">
      <div class="panel">
        <div class="panel-body container-fluid">
          <slot></slot>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  props: {
    title: {
      type: String,
      default: ""
    },
    back: {
      type: Boolean,
      default: false
    },
    backUrl: {
      type: String,
      default: ""
    },
    className: {
      type: String,
      default: ""
    }
  },
  name: "AdMainComponent",
  data() {
    return {};
  },
  mounted() {},
  methods: {
    /**
     * 返回回调事件
     */
    btnBackHandller() {
      if (this.backUrl) {
        this.$router.push({ name: this.backUrl });
      } else {
        this.$router.go(-1);
      }
    }
  }
};
</script>

<style lang="scss">
.ad-main-component {
  .page-header {
    .page-title {
      span {
        font-size: 12px;
        margin-left: 20px;
        cursor: pointer;
      }
    }
  }
}
</style>

