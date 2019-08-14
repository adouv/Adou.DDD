import moment from 'moment';
/** 
 * 字符串空过滤器
 */
export const emptyFormats = (Vue) => {
    Vue.filter('emptyFormats', (dataStr, pattern='--') => {
        return dataStr ? dataStr : pattern
    })
}