import Vue from "vue"         
import tip from './tip'
import confirm from './confirm'
import alert from './alert'
import prompt from './prompt'

export default {
    use(options) {
        Vue.message = Vue.prototype.$message = options.message;
        Vue.tip = Vue.prototype.$tip = tip;
        Vue.confirm = Vue.prototype.$confirm = confirm;
        Vue.alert = Vue.prototype.$alert = alert;
        Vue.prompt = Vue.prototype.$prompt = prompt;
    }
}