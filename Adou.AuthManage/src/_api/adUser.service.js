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
     * 插入用户信息，同时添加所拥有的角色权限
     * @param {*} params 
     * @param {*} config 
     */
    async insertUserAndRole(params = {}, config = {}) {
        let result = await Vue.http.post("User/InsertUserAndRole", params, config);
        return result;
    },
    /**
     * 通过编号更新用户，同时更新所拥有的角色权限
     * @param {*} params 
     * @param {*} config 
     */
    async updateUserAndRoleById(params = {}, config = {}) {
        let result = await Vue.http.post("User/UpdateUserAndRoleById", params, config);
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