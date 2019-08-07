import { adPaginationInstall } from "./adPagination/index";
import { adMainInstall } from "./adMain/index";
/**
 * 全局组件注册
 */
export const ComponentInstall = Vue => {
    adPaginationInstall(Vue);
    adMainInstall(Vue);
};