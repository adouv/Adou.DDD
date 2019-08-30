import Vue from "vue";
import Router from "vue-router";

import AuthService from "../_ddd/auth.service";

import LoginComponent from "@views/login";
import SharedComponent from "@views/shared";
import HomeComponent from "@views/home.vue";
import SettingComponent from "@views/shared/setting.vue";

import AdAccountComponent from "@views/account/index";
import AdMenuComponent from "@views/menu/index";
import AdMenuEditComponent from "@views/menu/edit";
import AdUserComponent from "@views/user/index";
import AdUserEditComponent from "@views/user/edit";
import AdRoleComponent from "@views/role/index";
import AdRoleEditComponent from "@views/role/edit";

import AdDictionaryComponent from "@views/dictionary/index";
import AdDictionaryTypeComponent from "@views/dictionaryType/index";

import AdWebProductComponent from "@views/webManage/product/index";
import AdWebProductEditComponent from "@views/webManage/product/edit";
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
                component: AdAccountComponent
            },
            {
                path: "adMenu",
                name: "adMenu",
                component: AdMenuComponent
            },
            {
                path: "adMenuEdit",
                name: "adMenuEdit",
                component: AdMenuEditComponent
            },
            {
                path: "adUser",
                name: "adUser",
                component: AdUserComponent
            },
            {
                path: "adUserEdit",
                name: "adUserEdit",
                component: AdUserEditComponent
            },
            {
                path: "adRole",
                name: "adRole",
                component: AdRoleComponent
            },
            {
                path: "adRoleEdit",
                name: "adRoleEdit",
                component: AdRoleEditComponent
            },
            {
                path: "adDictionary",
                name: "adDictionary",
                component: AdDictionaryComponent
            },
            {
                path: "adDictionaryType",
                name: "adDictionaryType",
                component: AdDictionaryTypeComponent
            },
            {
                path: "adProduct",
                name: "adProduct",
                component: AdWebProductComponent
            },
            {
                path: "adProductEdit",
                name: "adProductEdit",
                component: AdWebProductEditComponent
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