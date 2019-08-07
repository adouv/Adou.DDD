import { adConfirmInstall } from './adConfirm/index';
import { adModalInstall } from './adModal/index';
import { adTipInstall } from './adTip/index';
/** 
 * 全局扩展注册
 */
export const ExpansionInstall = (Vue) => {
    adConfirmInstall(Vue);
    adModalInstall(Vue);
    adTipInstall(Vue);
}