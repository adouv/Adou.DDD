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
    },
    /**
     * 获取账户列表
     * @param {*} params 
     * @param {*} config 
     */
    async getAccountList(params = {}, config = {}) {
        let result = await Vue.http.post('Account/GetAccountList', params, config);
        return result;
    }
}