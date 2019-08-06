import Vue from 'vue'
import axios from 'axios'

let isTimeout = false

let logData = {
    status: 100,
    data: "",
    message: "",
    url: "",
    type: 'info'
};

let logParams = {};

let logConfig = {};

/** 
 * 超时
 */
axios.defaults.timeout = 1000000

axios.defaults.baseURL = ``

axios.defaults.retry = 4

axios.defaults.retryDelay = 1000

/** 
 * 请求拦截
 */
axios.interceptors.request.use(
        config => {
            // console.log(config);
            // logData.status = config.status;
            // logData.data = JSON.stringify(config.data);
            // logData.message = "";
            // logData.url = config.url;
            // logData.type = "request.info";
            // logParams.content = JSON.stringify(logData);
            if (Vue.local.getItem('tdToken') !== undefined) {
                config.headers.Token = `${Vue.local.getItem('tdToken')}`
            }
            return config
        },
        error => {
            // console.log(error);
            return Promise.reject(error)
        }
    )
    /** 
     * 响应拦截
     */
axios.interceptors.response.use(
        response => {
            // console.log(response);
            return response.data
        },
        error => {
            // logData.status = error.response.status;
            // logData.data = error.response.config.data;
            // logData.message = error.response.data;
            // logData.url = error.response.config.url;
            // logData.type = "response.error";
            // logParams.content = JSON.stringify(logData);
            // console.log(JSON.stringify(error));
            if (error.response) {
                let {
                    config,
                    data,
                    headers,
                    request,
                    status,
                    statusText
                } = error.response
                ResponseStatus(status, data.Message)
            }
            return Promise.reject(error)
        }
    )
    /** 
     * 响应状态拦截
     */
let ResponseStatus = (status, message) => {
    if (status === 401) {
        Vue.local.removeItem('tdToken')
        Vue.local.removeItem('tdUser')
        Vue.tip('登陆超时,即将跳转登录页面...', () => {
            window.location.href = '/login'
        }, 2500)
    } else {
        Vue.tip(message)
    }


}

let HttpService = axios

export default HttpService