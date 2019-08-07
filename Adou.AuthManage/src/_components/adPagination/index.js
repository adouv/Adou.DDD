import AdPaginationComponent from "./index.vue";
/** 
 * 分页组件
 */
export const adPaginationInstall = (Vue) => {
    const Constructor = Vue.extend(AdPaginationComponent);
    Vue.component('ad-pagination', Constructor);
}