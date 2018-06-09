import Vue from 'vue';
import router from './router';
import components from "./components";

Vue.config.productionTip = false

components.LoadComponents();

new Vue({
    el: "#app",
    router
});