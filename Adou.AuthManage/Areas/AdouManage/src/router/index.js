import Vue from 'vue'
import Router from 'vue-router';

import HomeComponent from '../components/Home.vue';

Vue.use(Router);

const routers = [
    {
        path: "/",
        name: "/",
        component: HomeComponent
    }
];

const router = new Router({
    routes: routers
});

export default router;