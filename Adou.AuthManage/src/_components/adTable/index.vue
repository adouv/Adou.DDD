<template>
  <div class="example table-responsive td-table" :class="className">
    <div>
      <table class="table table-striped" v-if="list.length!==0">
        <thead>
          <tr>
            <th v-for="(item,index) in headers" :key="index">{{item}}</th>
          </tr>
        </thead>
        <slot></slot>
      </table>
      <div class="page-content" style="text-align:center;height:200px;line-height:200px;" v-if="list.length===0">
        <header>
          <h3>暂无数据</h3>
        </header>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "AdTableComponent",
  props: ["headers", "list", "className"]
};
</script>
