import AdMainComponent from "./index.vue";
/** 
 * 主体组件
 */
export const adMainInstall = (Vue) => {
    const Constructor = Vue.extend(AdMainComponent);
    Vue.component('ad-main', Constructor);
}