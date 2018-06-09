import Vue from "vue";
import tip from "./tip/index.js"

export default {
    LoadComponents() {
        Vue.use(tip);
    }
}