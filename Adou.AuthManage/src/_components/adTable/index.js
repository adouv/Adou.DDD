import AdTableComponent from "./index.vue";
/** 
 * 表格组件
 */
export const adTableInstall = (Vue) => {
    const Constructor = Vue.extend(AdTableComponent);
    Vue.component('ad-table', Constructor);
}