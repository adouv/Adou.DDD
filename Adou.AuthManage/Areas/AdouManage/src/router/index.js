import Vue from 'vue'
import Router from 'vue-router';

import HomeComponent from '../../Views/Home/Index.js';
const Bar = { template: '<div>bar</div>' }

Vue.use(Router);

const routers = [
    { path: '/home', component: HomeComponent },
    { path: '/bar', component: Bar }
];

const router = new Router({
    routes: routers
});

export default router;