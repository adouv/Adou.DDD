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
    async updateAccountById(params = {}, config = {}) {
        let result = await Vue.http.post('Account/UpdateAccountById', params, config);
        return result;
    },
    /**
     * 获取账户列表
     * @param {*} params 
     * @param {*} config 
     */
    async getAccountList(params = {}, config = {}) {
        let newParams = Vue.utils.requestParamsFormat(params);
        let result = await Vue.http.post('Account/GetAccountList', newParams, config);
        return result;
    },
    /**
     * 分页获取账户列表
     * @param {*} params 
     * @param {*} config 
     */
    async getAccountPageList(params = {}, config = {}) {
        let newParams = Vue.utils.requestParamsFormat(params);
        let result = await Vue.http.post('Account/GetAccountPageList', newParams, config);
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