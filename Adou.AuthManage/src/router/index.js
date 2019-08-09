import Vue from "vue";
import Router from "vue-router";

import AuthService from "../_ddd/auth.service";

import LoginComponent from "@views/login";
import SharedComponent from "@views/shared";
import HomeComponent from "@views/home.vue";
import SettingComponent from "@views/shared/setting.vue";

import adAccountComponent from "@views/account/index";
import AdMenuComponent from "@views/menu/index";

Vue.use(Router);

const routers = [{
        path: "/login",
        name: "login",
        component: LoginComponent
    },
    {
        path: "/",
        name: "/",
        component: SharedComponent,
        children: [{
                path: "",
                name: "home",
                component: HomeComponent
            },
            {
                path: "setting",
                name: "setting",
                component: SettingComponent
            },
            {
                path: "adAccount",
                name: "adAccount",
                component: adAccountComponent
            },
            {
                path: "adMenu",
                name: "adMenu",
                component: AdMenuComponent
            }
        ]
    }
];

const router = new Router({
    // mode: 'history',
    routes: routers
});

AuthService.tokenAuth(Vue, router, routers);

export default router;