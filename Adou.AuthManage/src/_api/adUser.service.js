import Vue from "vue";
/**
 * 用户管理服务
 */
export default {
    /**
     * 获取用户列表
     * @param {*} params 
     * @param {*} config 
     */
    async getUserList(params = {}, config = {}) {
        let result = await Vue.http.post("User/GetUserList", params, config);
        return result;
    },
    /**
     * 分页获取用户列表
     * @param {*} params 
     * @param {*} config 
     */
    async getUserPageList(params = {}, config = {}) {
        let newParams = Vue.utils.requestParamsFormat(params);
        let result = await Vue.http.post("User/GetUserPageList", newParams, config);
        return result;
    },
    /**
     * 用户登录
     * @param {*} params 
     * @param {*} config 
     */
    async userLogin(params = {}, config = {}) {
        let result = await Vue.http.post("User/UserLogin", params, config);
        return result;
    },
    /**
     * 添加用户
     * @param {*} params 
     * @param {*} config 
     */
    async insertUser(params = {}, config = {}) {
        let result = await Vue.http.post("User/InsertUser", params, config);
        return result;
    },
    /**
     * 通过编号更新用户
     * @param {*} params 
     * @param {*} config 
     */
    async updateUserById(params = {}, config = {}) {
        let result = await Vue.http.post("User/UpdateUserById", params, config);
        return result;
    },
    /**
     * 通过编号删除用户
     * @param {*} params 
     * @param {*} config 
     */
    async deleteUserById(params = {}, config = {}) {
        let result = await Vue.http.post("User/DeleteUserById", params, config);
        return result;
    },
    /**
     * 通过编号更新用户是否删除状态（伪删除）
     * @param {*} params 
     * @param {*} config 
     */
    async updateUserIsDelById(params = {}, config = {}) {
        let result = await Vue.http.post("User/UpdateUserIsDelById", params, config);
        return result;
    }
}