import Vue from 'vue';
import VueRouter from 'vue-router'
import router from './router';
import App from './App.vue';

new Vue({
    el: "#app",
    router,
    components: {
        App
    },
    template: '<App/>'
});