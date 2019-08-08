<template>
  <button type="button" :class="`btn ${type?'btn-'+type:'btn-default'} ${size?'btn-'+size:''}`">
      <slot></slot>
  </button>
</template>

<script>
/**
 * @param type {default、secondary、primary、success、info、warning、danger、dark、light、inverse}
 * @param size {lg、sm}
 */
export default {
  name: "AdButtonComponent",
  props: ["type", "size"]
};
</script>

