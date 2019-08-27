import Vue from 'vue'
/** 
 * 字典管理服务
 */
export default {
    /**
     * 获取字典列表
     * @param {*} params 
     * @param {*} config 
     */
    async getDictionaryList(params = {}, config = {}) {
        let newParams = Vue.utils.requestParamsFormat(params);
        let result = await Vue.http.post('Dictionary/GetDictionaryList', newParams, config);
        return result;
    },
    /**
     * 分页获取字典列表
     * @param {*} params 
     * @param {*} config 
     */
    async getDictionaryPageList(params = {}, config = {}) {
        let newParams = Vue.utils.requestParamsFormat(params);
        let result = await Vue.http.post('Dictionary/GetDictionaryPageList', newParams, config);
        return result;
    },
    /**
     * 添加字典
     * @param {*} [params={}]
     * @param {*} [config={}]
     * @returns
     */
    async insertDictionary(params = {}, config = {}) {
        let result = await Vue.http.post('Dictionary/InsertDictionary', params, config);
        return result;
    },
    /**
     * 通过编号更新字典
     * @param {*} [params={}]
     * @param {*} [config={}]
     * @returns
     */
    async updateDictionaryById(params = {}, config = {}) {
        let result = await Vue.http.post('Dictionary/UpdateDictionaryById', params, config);
        return result;
    },
    /**
     * 伪删除
     * @param {*} [params={}]
     * @param {*} [config={}]
     * @returns
     */
    async updateDictionaryIsDelById(params = {}, config = {}) {
        let result = await Vue.http.post('Dictionary/UpdateDictionaryIsDelById', params, config);
        return result;
    },
    /**
     * 通过编号删除字典
     * @param {*} params 
     * @param {*} config 
     */
    async deleteDictionaryById(params = {}, config = {}) {
        let result = await Vue.http.post('Dictionary/DeleteDictionaryById', params, config);
        return result;
    }
}