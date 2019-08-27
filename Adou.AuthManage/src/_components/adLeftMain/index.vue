<template>
  <div class="page-aside-fixed page-aside-left site-contabs-open site-menubar-unfold" :class="className">
    <div class="page animation-fade">
      <div class="page-aside">
        <div class="page-aside-switch">
          <i class="icon wb-chevron-left" aria-hidden="true"></i>
          <i class="icon wb-chevron-right" aria-hidden="true"></i>
        </div>

        <div
          class="page-aside-inner page-aside-scroll mCustomScrollbar _mCS_1 mCS-autoHide"
          data-plugin="mCustomScrollbar"
        >
          <div
            id="mCSB_1"
            class="mCustomScrollBox mCS-dark mCSB_vertical mCSB_inside"
            tabindex="0"
            style="max-height: none;"
          >
            <div
              id="mCSB_1_container"
              class="mCSB_container"
              style="position: relative; top: 0px; left: 0px;"
              dir="ltr"
            >
              <div data-role="container">
                <div data-role="content">
                  <slot name="left"></slot>
                </div>
              </div>
            </div>
            <div
              id="mCSB_1_scrollbar_vertical"
              class="mCSB_scrollTools mCSB_1_scrollbar mCS-dark mCSB_scrollTools_vertical"
              style="display: block;"
            >
              <div class="mCSB_draggerContainer">
                <div
                  id="mCSB_1_dragger_vertical"
                  class="mCSB_dragger"
                  style="position: absolute; min-height: 0px; display: block; height: 584px; max-height: 610px; top: 0px;"
                >
                  <div class="mCSB_dragger_bar" style="line-height: 0px;"></div>
                </div>
                <div class="mCSB_draggerRail"></div>
              </div>
            </div>
          </div>
        </div>
      </div>
      <div class="page-main">
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

