<template>
  <div class="adou-page-aside-left" :class="className">
    <div class="adou-page">
      <div class="adou-page-aside">
        <div class="adou-page-aside-inner">
          <slot name="left"></slot>
        </div>
      </div>
      <div class="page-main" style="height:auto !important;">
        <div class="page-header">
          <h1 class="page-title">{{title}}</h1>
        </div>
        <div class="page-content">
          <div class="panel" style="padding-bottom:20px;">
            <slot name="main"></slot>
          </div>
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
  name: "AdLeftMainComponent"
};
</script>

<style lang="scss">
.adou-page-aside-left {
  .adou-page {
    display: flex;
    .adou-page-aside {
      background: #fff;
      width: 220px;
    }
    .page-main {
      flex: 1;
    }
  }
}
</style>

