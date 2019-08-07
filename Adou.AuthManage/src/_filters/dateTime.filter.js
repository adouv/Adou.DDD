import moment from 'moment';
/** 
 * 时间格式化过滤器
 */
export const dateTimeFormats = (Vue) => {
    Vue.filter('dateTimeFormats', (dataStr, pattern = 'YYYY/MM/DD HH:mm:ss') => {
        return moment(dataStr).format(pattern);
    })
}