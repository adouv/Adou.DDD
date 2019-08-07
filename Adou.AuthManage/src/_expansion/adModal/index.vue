<template>
  <div class="modal-extends" v-if="show">
    <div
      class="modal fade"
      v-if="show"
      v-bind:class="{in:show}"
      id="examplePositionTop"
      aria-hidden="true"
      aria-labelledby="examplePositionTop"
      role="dialog"
      tabindex="-1"
    >
      <div
        class="modal-dialog"
        :style="{width:`${modalOptions.width}px`}"
        :class="modalOptions.position"
      >
        <div class="modal-content">
          <div class="modal-header" v-if="modalOptions.showTitle">
            <button type="button" class="close" @click="btnClose();">
              <span aria-hidden="true">×</span>
            </button>
            <h4 class="modal-title" id="exampleModalTitle">{{modalOptions.title}}</h4>
          </div>
          <div
            class="modal-body"
            :class="modalOptions.className"
            :style="{maxHeight:modalOptions.height+'px'}"
          >
            <component :is="modalOptions.componentName" :params="modalOptions.params"></component>
          </div>
          <div class="modal-footer">
            <button
              type="button"
              class="btn btn-default"
              @click="btnClose();"
            >{{modalOptions.cleanText}}</button>
            <button
              type="button"
              class="btn btn-primary"
              v-if="modalOptions.showSave"
              @click="btnSave();"
            >{{modalOptions.saveText}}</button>
          </div>
        </div>
      </div>
    </div>
    <div class="modal-backdrop fade" v-if="show" v-bind:class="{in:show}"></div>
  </div>
</template>

<script>
export default {
  name: "AdModalComponent",
  props: {},
  data() {
    return {
      show: false,
      modalOptions: {
        title: "默认标题",
        showTitle: true,
        saveText: "保存",
        cleanText: "取消",
        showSave: true,
        position: "modal-top",
        componentName: null,
        width: 500,
        height: 500,
        params: {},
        className: "",
        save: (params, close) => {},
        close: params => {}
      }
    };
  },
  methods: {
    btnClose() {
      this.show = !this.show;
      this.modalOptions.close(this.modalOptions.params);
    },
    close() {
      this.show = !this.show;
    },
    btnSave() {
      this.modalOptions.save(this.modalOptions.params, this.close);
    }
  },
  computed: {},
  created() {},
  beforeDestroy() {},
  watch: {}
};
</script>

<style lang="scss" scoped>
@import "@/assets/scss/ddd/mixin.scss";
.modal {
  position: fixed;
  top: 0;
  right: 0;
  bottom: 0;
  left: 0;
  z-index: 1050;
  display: block;
  overflow: hidden;
  -webkit-overflow-scrolling: touch;
  outline: 0;
  .modal-body {
    overflow-x: auto;
    @include scroll-bar(6px);
  }
  @media (max-width: 768px) {
    .modal-dialog {
      width: 100% !important;
    }
  }
}
</style>

