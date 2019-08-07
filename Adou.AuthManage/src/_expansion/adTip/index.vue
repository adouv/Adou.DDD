<template>
    <div v-if="show" class="alertify-logs" @click="btnClose();">
        <div class="default show" style="text-align:center;">{{message}}</div>
    </div>
</template>

<script>
export default {
  name: "AdTipComponent",
  data() {
    return {
      show: false,
      message: "10秒后消失"
    };
  },
  methods: {
    btnClose() {
      this.show = false;
    }
  }
};
</script>