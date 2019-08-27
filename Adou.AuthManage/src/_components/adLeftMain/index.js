import AdLeftMainComponent from "./index.vue";
/** 
 * 带左侧菜单主体组件
 */
export const adLeftMainInstall = (Vue) => {
    const Constructor = Vue.extend(AdLeftMainComponent);
    Vue.component('ad-left-main', Constructor);
}