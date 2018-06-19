import Vue from 'vue'
import Router from 'vue-router';

const debug = process.env.NODE_ENV !== 'production';


import Shared from '@/components/Shared/Shared';
import Home from '@/components/Home';


// const Login = r => require.ensure([], () => r(require('./components/Login/Login')), 'Login');
// const Shared = r => require.ensure([], () => r(require('./components/Shared/Shared')), 'Shared');
// const Home = r => require.ensure([], () => r(require('./components/Home')), 'Home');
// const settings = r => require.ensure([], () => r(require('./components/Settings')), 'settings');
// const orderList = r => require.ensure([], () => r(require('./components/Order/OrderList')), 'orderList');
// const importOrder = r => require.ensure([], () => r(require('./components/Order/ImportOrder')), 'importOrder');
// const Vuexs = r => require.ensure([], () => r(require('./components/Vuexs')), 'Vuexs');
// const modal = r => require.ensure([], () => r(require('./ui/uiModal')), 'modal');
// const icons = r => require.ensure([], () => r(require('./ui/uiIcons')), 'icons');
// const buttons = r => require.ensure([], () => r(require('./ui/uiButtons')), 'buttons');
// const alertify = r => require.ensure([], () => r(require('./ui/uiAlertify')), 'alertify');
// const table = r => require.ensure([], () => r(require('./ui/uiTable')), 'table');
// const list = r => require.ensure([], () => r(require('./ui/uiList')), 'list');
// const form = r => require.ensure([], () => r(require('./ui/uiForm')), 'form');


Vue.use(Router);

const routers = [{
        path: "/",
        name: "/",
        component: Shared,
        //嵌套路由
        children: [{
                path: "", //默认路由
                name: "home",
                component: Home
            }
        ]
    }
];

const router = new Router({
    mode: 'history',
    routes: routers
});

//路由守卫，登录验证
//Service.Auth.loginAuth(router, routers);

export default router;