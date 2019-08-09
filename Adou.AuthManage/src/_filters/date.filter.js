import moment from 'moment';
/** 
 * 时间格式化过滤器
 */
export const dateFormats = (Vue) => {
    Vue.filter('dateFormats', (dataStr, pattern = 'YYYY/MM/DD') => {
        return moment(dataStr).format(pattern);
    })
}