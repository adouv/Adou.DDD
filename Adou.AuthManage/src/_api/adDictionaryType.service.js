import Vue from 'vue'
/** 
 * 字典项管理服务
 */
export default {
    /**
     * 获取字典项列表
     * @param {*} params 
     * @param {*} config 
     */
    async getDictionaryTypeList(params = {}, config = {}) {
        let newParams = Vue.utils.requestParamsFormat(params);
        let result = await Vue.http.post('DictionaryType/GetDictionaryTypeList', newParams, config);
        return result;
    },
    /**
     * 分页获取字典项列表
     * @param {*} params 
     * @param {*} config 
     */
    async getDictionaryTypePageList(params = {}, config = {}) {
        let newParams = Vue.utils.requestParamsFormat(params);
        let result = await Vue.http.post('DictionaryType/GetDictionaryTypePageList', newParams, config);
        return result;
    },
    /**
     * 添加字典项
     * @param {*} [params={}]
     * @param {*} [config={}]
     * @returns
     */
    async insertDictionaryType(params = {}, config = {}) {
        let result = await Vue.http.post('DictionaryType/InsertDictionaryType', params, config);
        return result;
    },
    /**
     * 通过编号更新字典项
     * @param {*} [params={}]
     * @param {*} [config={}]
     * @returns
     */
    async updateDictionaryTypeById(params = {}, config = {}) {
        let result = await Vue.http.post('DictionaryType/UpdateDictionaryTypeById', params, config);
        return result;
    },
    /**
     * 伪删除
     * @param {*} [params={}]
     * @param {*} [config={}]
     * @returns
     */
    async updateDictionaryTypeIsDelById(params = {}, config = {}) {
        let result = await Vue.http.post('DictionaryType/UpdateDictionaryTypeIsDelById', params, config);
        return result;
    },
    /**
     * 通过编号删除字典项
     * @param {*} params 
     * @param {*} config 
     */
    async deleteDictionaryTypeById(params = {}, config = {}) {
        let result = await Vue.http.post('DictionaryType/DeleteDictionaryTypeById', params, config);
        return result;
    }
}