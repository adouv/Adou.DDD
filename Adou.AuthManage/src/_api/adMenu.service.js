import Vue from "vue";
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
        let result = await Vue.http.post("Menu/GetMenuList", newParams, config);
        return result;
    },
    /**
     * 通过父级编号获取菜单列表
     * @param {*} [params={}]
     * @param {*} [config={}]
     * @returns
     */
    async getMenuListByFatherId(params = {}, config = {}) {
        let newParams = Vue.utils.requestParamsFormat(params);
        let result = await Vue.http.post(
            "Menu/GetMenuListByFatherId",
            newParams,
            config
        );
        return result;
    },
    /**
     * 获取单个菜单信息
     * @param {*} [params={}]
     * @param {*} [config={}]
     * @returns
     */
    async getSingleMenuByFatherId(params = {}, config = {}) {
        let newParams = Vue.utils.requestParamsFormat(params);
        let result = await Vue.http.post(
            "Menu/GetSingleMenuByFatherId",
            newParams,
            config
        );
        return result;
    },
    /**
     * 添加菜单
     * @param {*} [params={}]
     * @param {*} [config={}]
     * @returns
     */
    async insertMenu(params = {}, config = {}) {
        let result = await Vue.http.post("Menu/InsertMenu", params, config);
        return result;
    },
    /**
     * 修改菜单
     * @param {*} [params={}]
     * @param {*} [config={}]
     * @returns
     */
    async updateMenuById(params = {}, config = {}) {
        let result = await Vue.http.post("Menu/UpdateMenuById", params, config);
        return result;
    },
    /**
     * 删除菜单
     * @param {*} [params={}]
     * @param {*} [config={}]
     * @returns
     */
    async deleteMenuById(params = {}, config = {}) {
        let result = await Vue.http.post("Menu/DeleteMenuById", params, config);
        return result;
    }
};