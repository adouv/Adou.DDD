<template>
  <div class="page material ad-main-component" :class="className">
    <div class="page-header">
      <h1 class="page-title">{{title}}</h1>
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
  props: ["title", "className"],
  name: "AdMainComponent",
  data() {
    return {};
  }
};
</script>

