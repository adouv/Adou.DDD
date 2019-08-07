import Vue from 'vue'
/** 
 * 账户管理服务
 */
export default {
    /**
     * 添加账户
     * @param {*} [params={}]
     * @param {*} [config={}]
     * @returns
     */
    async insertAccount(params = {}, config = {}) {
        let result = await Vue.http.post('Account/InsertAccount', params, config);
        return result;
    }
}