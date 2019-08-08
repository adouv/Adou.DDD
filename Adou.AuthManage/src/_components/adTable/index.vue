<template>
  <div class="example table-responsive td-table" :class="className">
    <div>
      <table class="table table-striped">
        <thead>
          <tr>
            <th v-for="(item,index) in headers" :key="index">{{item}}</th>
          </tr>
        </thead>
        <tbody>
          <slot></slot>
        </tbody>
      </table>
    </div>
  </div>
</template>

<script>
export default {
  name: "AdTableComponent",
  props: ["headers", "list", "className"]
};
</script>
