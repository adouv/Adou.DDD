import Vue from "vue";
/**
 * 工具类服务
 */
export default {
    /**
     * 参数格式化
     * @param {*} params
     */
    requestParamsFormat(params) {
        let newParams = {};
        Object.keys(params).forEach(param => {
            let val = params[param];
            if (val) {
                newParams[param] = val;
            }
        });
        return newParams;
    }
};