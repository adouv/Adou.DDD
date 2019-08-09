// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.
import Vue from "vue";
import App from "@/App";
import router from "@/router";

import store from "@/store";
import ddd from "@/_ddd";
import { ComponentInstall } from "@/_components/index";
import { ExpansionInstall } from "@/_expansion/index";
import { FilterInstall } from "@/_filters/index";

import {
    Tag,
    Container,
    Header,
    Aside,
    Main,
    Footer,
    Menu,
    Submenu,
    MenuItem,
    MenuItemGroup,
    Col,
    Row,
    Icon,
    Select,
    Breadcrumb,
    BreadcrumbItem,
    Form,
    FormItem,
    Input,
    InputNumber,
    TimeSelect,
    TimePicker,
    Option,
    OptionGroup,
    DatePicker,
    Switch,
    Checkbox,
    CheckboxButton,
    CheckboxGroup,
    Radio,
    RadioButton,
    RadioGroup,
    Dropdown,
    DropdownMenu,
    DropdownItem,
    Tabs,
    TabPane,
    Table,
    TableColumn,
    Pagination,
    Link,
    Message,
    Loading
} from "element-ui";
import "babel-polyfill";
import "es6-promise/auto";

import "element-ui/lib/theme-chalk/index.css";
import "@lib/bootstrap/dist/css/bootstrap.min.css";
import "@scss/index.scss";
import "@node/font-awesome/scss/font-awesome.scss";
import "@lib/Ionicons/scss/ionicons.scss";
import "@lib/webicons/scss/web-icons.scss";
import "@lib/themify-icons/themify-icons.css";

Vue.config.productionTip = false;

Vue.use(Tag);
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
Vue.use(Select);
Vue.use(Breadcrumb);
Vue.use(BreadcrumbItem);
Vue.use(Form);
Vue.use(FormItem);
Vue.use(Input);
Vue.use(InputNumber);
Vue.use(TimeSelect);
Vue.use(TimePicker);
Vue.use(Option);
Vue.use(OptionGroup);
Vue.use(DatePicker);
Vue.use(Switch);
Vue.use(Checkbox);
Vue.use(CheckboxButton);
Vue.use(CheckboxGroup);
Vue.use(Radio);
Vue.use(RadioButton);
Vue.use(RadioGroup);
Vue.use(Dropdown);
Vue.use(DropdownMenu);
Vue.use(DropdownItem);
Vue.use(Tabs);
Vue.use(TabPane);
Vue.use(Table);
Vue.use(TableColumn);
Vue.use(Pagination);
Vue.use(Link);
Vue.use(Loading.directive);

ComponentInstall(Vue);
ExpansionInstall(Vue);
FilterInstall(Vue);
Vue.prototype.$loading = Loading.service;

Vue.elem = Vue.prototype.elem$ = ddd.ElementService;
Vue.local = Vue.prototype.local$ = ddd.LocalStorageService;
Vue.http = Vue.prototype.http$ = ddd.HttpService;
Vue.valid = Vue.prototype.valid$ = ddd.ValidService;
Vue.encry = Vue.prototype.encry$ = ddd.EncryptService;
Vue.utils = Vue.prototype.utils$ = ddd.UtilService;

/* eslint-disable no-new */
new Vue({
    el: "#app",
    store,
    router,
    components: {
        App
    },
    template: "<App />"
});