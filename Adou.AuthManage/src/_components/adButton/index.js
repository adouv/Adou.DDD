import AdButtonComponent from "./index.vue";
/** 
 * 按钮组件
 */
export const adButtonInstall = (Vue) => {
    const Constructor = Vue.extend(AdButtonComponent);
    Vue.component('ad-button', Constructor);
}