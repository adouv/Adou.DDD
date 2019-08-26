import Vue from "vue";
/**
 * 角色管理服务
 */
export default {
    /**
     * 获取角色列表
     * @param {*} params
     * @param {*} config
     */
    async getRoleList(params = {}, config = {}) {
        let newParams = Vue.utils.requestParamsFormat(params);
        let result = await Vue.http.post("Role/GetRoleList", newParams, config);
        return result;
    },
    /**
     * 分页获取角色列表
     * @param {*} params
     * @param {*} config
     */
    async getRolePageList(params = {}, config = {}) {
        let newParams = Vue.utils.requestParamsFormat(params);
        let result = await Vue.http.post("Role/GetRolePageList", newParams, config);
        return result;
    },
    /**
     * 通过用户编号获取角色列表
     * @param {*} params
     * @param {*} config
     */
    async getRoleListByUserId(params = {}, config = {}) {
        let result = await Vue.http.post(
            "Role/GetRoleListByUserId",
            params,
            config
        );
        return result;
    },
    /**
     * 添加角色，同时添加所拥有的菜单权限
     * @param {*} params
     * @param {*} config
     */
    async insertRoleAndMenu(params = {}, config = {}) {
        let result = await Vue.http.post("Role/InsertRoleAndMenu", params, config);
        return result;
    },
    /**
     * 通过角色编号更新角色，同时更新所拥有的菜单权限
     * @param {*} params
     * @param {*} config
     */
    async updateRoleAndMenuById(params = {}, config = {}) {
        let result = await Vue.http.post(
            "Role/UpdateRoleAndMenuById",
            params,
            config
        );
        return result;
    },
    /**
     * 通过编号删除角色
     * @param {*} params
     * @param {*} config
     */
    async deleteRoleById(params = {}, config = {}) {
        let result = await Vue.http.post("Role/DeleteRoleById", params, config);
        return result;
    },
    /**
     * 通过编号更新角色删除状态（伪删除）
     * @param {*} params
     * @param {*} config
     */
    async updateRoleIsDelById(params = {}, config = {}) {
        let result = await Vue.http.post(
            "Role/UpdateRoleIsDelById",
            params,
            config
        );
        return result;
    }
};