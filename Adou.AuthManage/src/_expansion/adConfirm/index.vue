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
        :style="{width:`${confirmOptions.width}px`}"
        :class="confirmOptions.position"
      >
        <div class="modal-content">
          <div class="modal-header" v-if="confirmOptions.showTitle">
            <button type="button" class="close" @click="btnClose();">
              <span aria-hidden="true">×</span>
            </button>
            <h4 class="modal-title" id="exampleModalTitle">{{confirmOptions.title}}</h4>
          </div>
          <div
            class="modal-body"
            :style="{maxHeight:`${confirmOptions.height}px`}"
          >{{confirmOptions.message}}</div>
          <div class="modal-footer">
            <button
              type="button"
              class="btn btn-default"
              @click="btnClose();"
            >{{confirmOptions.cleanText}}</button>
            <button
              type="button"
              class="btn btn-primary"
              v-if="confirmOptions.showSave"
              @click="btnSave();"
            >{{confirmOptions.saveText}}</button>
          </div>
        </div>
      </div>
    </div>
    <div class="modal-backdrop fade" v-if="show" v-bind:class="{in:show}"></div>
  </div>
</template>

<script>
export default {
  name: "AdConfirmComponent",
  props: {},
  data() {
    return {
      show: false,
      confirmOptions: {
        title: "默认标题",
        showTitle: true,
        saveText: "确认",
        cleanText: "取消",
        showSave: true,
        position: "modal-center",
        message: "",
        width: 300,
        height: 500,
        params: {},
        save: (params, close) => {},
        clean: params => {}
      }
    };
  },
  methods: {
    btnClose() {
      this.show = !this.show;
      this.confirmOptions.clean(this.confirmOptions.params);
    },
    btnSave() {
      this.confirmOptions.save(this.confirmOptions.params, this.btnClose);
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
}
</style>

