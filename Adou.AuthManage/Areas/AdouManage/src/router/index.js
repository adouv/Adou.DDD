import Vue from 'vue'
import Router from 'vue-router';

import HomeComponent from '../../Views/Home/Index.js';
import LoginComponent from '../../Views/Login/Index.js';
const Bar = { template: '<div>bar</div>' }

Vue.use(Router);

const routers = [
    { path: '/home', component: HomeComponent },
    { path: '/login', component: LoginComponent },
    { path: '/bar', component: Bar }
];

const router = new Router({
    routes: routers
});

export default router;