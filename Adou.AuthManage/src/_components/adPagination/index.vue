<template>
  <div class="ad-pagination-component" v-if="total!==0">
    <el-pagination
      background
      @current-change="handleCurrentChange"
      :current-page="pageIndex"
      layout="slot,total, prev, pager, next"
      :total="total"
    >
      <span style="margin-right:10px;">当前第&nbsp;{{pageIndex}}&nbsp;页</span>
    </el-pagination>
  </div>
</template>

<script>
export default {
  props: ["total", "pageIndex"],
  name: "AdPaginationComponent",
  data() {
    return {};
  },
  mounted() {},
  methods: {
    handleCurrentChange(event) {
      this.$emit("currentChange", event);
    }
  }
};
</script>
