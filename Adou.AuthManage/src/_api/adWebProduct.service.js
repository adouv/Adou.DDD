import Vue from "vue";
/**
 * 产品管理服务
 */
export default {
    /**
     * 获取产品列表
     * @param {*} params
     * @param {*} config
     */
    async getWebProductList(params = {}, config = {}) {
        let result = await Vue.http.post(
            "WebProduct/GetWebProductList",
            params,
            config
        );
        return result;
    },
    /**
     * 分页获取产品列表
     * @param {*} params
     * @param {*} config
     */
    async getWebProductPageList(params = {}, config = {}) {
        let result = await Vue.http.post(
            "WebProduct/GetWebProductPageList",
            params,
            config
        );
        return result;
    },
    /**
     * 添加产品
     * @param {*} [params={}]
     * @param {*} [config={}]
     * @returns
     */
    async insertWebProduct(params = {}, config = {}) {
        let result = await Vue.http.post(
            "WebProduct/InsertWebProduct",
            params,
            config
        );
        return result;
    },
    /**
     * 通过编号更新产品
     * @param {*} [params={}]
     * @param {*} [config={}]
     * @returns
     */
    async updateWebProductById(params = {}, config = {}) {
        let result = await Vue.http.post(
            "WebProduct/UpdateWebProductById",
            params,
            config
        );
        return result;
    },
    /**
     * 伪删除
     * @param {*} [params={}]
     * @param {*} [config={}]
     * @returns
     */
    async updateWebProductIsDelById(params = {}, config = {}) {
        let result = await Vue.http.post(
            "WebProduct/UpdateWebProductIsDelById",
            params,
            config
        );
        return result;
    },
    /**
     * 通过编号删除产品
     * @param {*} params
     * @param {*} config
     */
    async deleteWebProductById(params = {}, config = {}) {
        let result = await Vue.http.post(
            "WebProduct/DeleteWebProductById",
            params,
            config
        );
        return result;
    }
};