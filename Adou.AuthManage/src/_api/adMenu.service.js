import Vue from 'vue'
/** 
 * 菜单服务
 */
export default {
    /**
     * 菜单列表
     * @param {*} [params={}]
     * @param {*} [config={}]
     * @returns
     */
    async getMenuList(params = {}, config = {}) {
        let result = await Vue.http.post('/api/Adou/Menu/GetMenuList', params, config);
        return result;
    }
}