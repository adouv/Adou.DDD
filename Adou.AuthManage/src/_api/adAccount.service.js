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
     * 编辑账户
     * @param {*} [params={}]
     * @param {*} [config={}]
     * @returns
     */
    async updateAccount(params = {}, config = {}) {
        let result = await Vue.http.post('Account/UpdateAccount', params, config);
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
    },
    /**
     * 通过Id删除账户
     * @param {*} params 
     * @param {*} config 
     */
    async deleteAccountById(params = {}, config = {}) {
        let result = await Vue.http.post('Account/DeleteAccountById', params, config);
        return result;
    }
}