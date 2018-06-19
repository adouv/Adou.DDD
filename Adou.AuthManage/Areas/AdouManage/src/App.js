import Vue from 'vue';
import {
    Container, Header, Aside, Main, Footer, Menu, Submenu, MenuItem, MenuItemGroup, Col, Row, Icon
} from 'element-ui';
import app from '@view/App/Index.cshtml';
import router from '@/router';
import components from "@/components";
import '@node/element-ui/lib/theme-chalk/index.css';
import '@/assets/scss/index.scss';

Vue.config.productionTip = false;
//加载UI
Vue.use(Container);
Vue.use(Header);
Vue.use(Aside);
Vue.use(Main);
Vue.use(Footer);
Vue.use(Menu);
Vue.use(Submenu);
Vue.use(MenuItem);
Vue.use(MenuItemGroup);
Vue.use(Col);
Vue.use(Row);
Vue.use(Icon);
//自定义组件
components.LoadComponents();

new Vue({
    el: "#app",
    router,
    template: app
});