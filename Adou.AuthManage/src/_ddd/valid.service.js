import Vue from "vue";
/**
 * 验证服务
 */
export default {
    /**
     * 验证手机号码
     * ^ 1 以数字1 开头
     * [3-578] 手机号第二位允许是 3 、4 、5、7、8 中的任意一位
     * \d{9} 任意9位数字组合
     * $ 只能以数字作为结尾
     * @param {*} mobile 手机号
     * @return 
     */
    isMobileValid(mobile) {
        let reg = /^1[3-578]\d{9}$/;
        return reg.test(mobile);
    },
    /**
     * 验证邮箱
     * 第一部分@第二部分
     * 第一部分：由字母、数字、下划线、短线 - 、点号 . 组成
     * 第二部分：域名，域名由字母、数字、短线 - 域名后缀组成
     * @param {*} email 邮箱
     * @return 
     */
    isEmailValid(email) {
        let reg = /^([a-zA-Z]|[0-9])(\w|\-)+@[a-zA-Z0-9]+\.([a-zA-Z]{2,4})$/;
        return reg.test(email);
    },
    /**
     * 去除字符串首尾空格
     * @param {*} obj 字符串
     * @return 
     */
    trim(obj) {
        return obj.replace(/(^\s*)|(\s*$)/g, "");
    },
    /**
     * 返回字符串实际长度
     * 一个汉字算2个长度
     * @param  {any} obj 字符串
     * @return 
     */
    len(obj) {
        return obj.replace(/[^\x00-\xff]/g, "**").length;
    }
};