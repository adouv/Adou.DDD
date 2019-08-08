import { adPaginationInstall } from "./adPagination/index";
import { adMainInstall } from "./adMain/index";
import { adTableInstall } from "./adTable/index";
import { adButtonInstall } from "./adButton/index";
/**
 * 全局组件注册
 */
export const ComponentInstall = Vue => {
    adPaginationInstall(Vue);
    adMainInstall(Vue);
    adTableInstall(Vue);
    adButtonInstall(Vue);
};