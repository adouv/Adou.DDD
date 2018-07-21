import Vue from 'vue'
import Router from 'vue-router'
import Sers from '@/services'

import LoginComponent from '@/views/Login'

import SharedComponent from "@/views/Shared/Shared"
import HomeComponent from "@/views/Home"
import ButtonComponent from "@/views/Button"
import NoticeComponent from "@/views/Notice"
import ThemeSettingComponent from "@/views/ThemeSetting"

import UserListComponent from "@/views/User/UserList"
import RoleListComponent from "@/views/Role/RoleList"
import MenuListComponent from "@/views/Menu/MenuList"
import AddMenuComponent from "@/views/Menu/AddMenu"

Vue.use(Router);

const routers = [
    {
        path: "/",
        name: "/",
        component: SharedComponent,
        children: [
            {
                path: "",
                name: "home",
                component: HomeComponent
            },
            {
                path: "button",
                name: "button",
                component: ButtonComponent
            },
            {
                path: "notice",
                name: "notice",
                component: NoticeComponent
            },
            {
                path: "themeSetting",
                name: "themeSetting",
                component: ThemeSettingComponent
            },
            {
                path: "userList",
                name: "userList",
                component: UserListComponent
            },
            {
                path: "roleList",
                name: "roleList",
                component: RoleListComponent
            },
            {
                path: "menuList",
                name: "menuList",
                component: MenuListComponent
            },
            {
                path: "addMenu",
                name: "addMenu",
                component: AddMenuComponent
            }
        ]
    },
    {
        path: "/login",
        name: "login",
        component: LoginComponent
    }
];

const router = new Router({
    routes: routers
});


Sers.Auth.loginAuth(router, routers);

export default router;
