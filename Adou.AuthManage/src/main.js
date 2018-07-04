// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.
import Vue from 'vue'
import App from '@/App'
import router from '@/router'
import store from '@/store'
import {
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
    Button,
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
    TabPane
} from 'element-ui'
import 'element-ui/lib/theme-chalk/index.css'
import '@/assets/scss/index.scss'
import '@node/font-awesome/scss/font-awesome.scss'
import '@/assets/webIcons/scss/web-icons.scss'
import 'babel-polyfill'
import 'es6-promise/auto'

Vue.config.productionTip = false

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
Vue.use(Button);
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

/* eslint-disable no-new */
new Vue({
    el: '#app',
    store,
    router,
    components: {
        App
    },
    template: '<App />'
})
