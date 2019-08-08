import Vue from 'vue'
/** 
 * 菜单管理服务
 */
export default {
    /**
     * 菜单列表
     * @param {*} [params={}]
     * @param {*} [config={}]
     * @returns
     */
    async getMenuList(params = {}, config = {}) {
        let newParams = Vue.utils.requestParamsFormat(params);
        let result = await Vue.http.post('Menu/GetMenuList', newParams, config);
        return result;
    }
}