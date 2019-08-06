import Vue from "vue";
import axios from "axios";

/**
 * 超时
 */
axios.defaults.timeout = 1000000;

axios.defaults.baseURL = ``;

axios.defaults.retry = 4;

axios.defaults.retryDelay = 1000;

/**
 * 请求拦截
 */
axios.interceptors.request.use(
    config => {
        console.log('http.service.config', config);
        if (Vue.local.getItem("tdToken") !== undefined) {
            config.headers.Token = `${Vue.local.getItem("tdToken")}`;
        }
        return config;
    },
    error => {
        console.log('http.service.error0', error);
        return Promise.reject(error);
    }
);
/**
 * 响应拦截
 */
axios.interceptors.response.use(
    response => {
        console.log('http.service.response', response);
        let { Data, IsSuccess, Status, Message } = response.data;
        if (Status === 200 && IsSuccess && Data.length !== 0) {
            return { Data: Data, Message: Message };
        } else {
            return { Data: null, Message: Message };
        }
    },
    error => {
        console.log('http.service.error1', error);
        if (error.response) {
            let {
                config,
                data,
                headers,
                request,
                status,
                statusText
            } = error.response;
            ResponseStatus(status, data.Message);
        }
        return Promise.reject(error);
    }
);
/**
 * 响应状态拦截
 */
let ResponseStatus = (status, message) => {
    if (status === 401) {
        Vue.local.removeItem("tdToken");
        Vue.local.removeItem("tdUser");
        Vue.tip(
            "登陆超时,即将跳转登录页面...",
            () => {
                window.location.href = "/login";
            },
            2500
        );
    } else {
        Vue.tip(message);
    }
};

let HttpService = axios;

export default HttpService;