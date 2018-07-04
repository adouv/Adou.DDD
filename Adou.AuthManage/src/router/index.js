import Vue from 'vue'
import Router from 'vue-router'

import LoginComponent from '@/views/Login'

import SharedComponent from "@/views/Shared/Shared"
import HomeComponent from "@/views/Home"
import ButtonComponent from "@/views/Button"
import ThemeSettingComponent from "@/views/ThemeSetting"

import UserListComponent from "@/views/User/UserList"
import RoleListComponent from "@/views/Role/RoleList"
import MenuListComponent from "@/views/Menu/MenuList"

Vue.use(Router);

const routers = new Router({
    routes: [
        {
            path: "/",
            name: "home",
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
                }
            ]
        },
        {
            path: "/login",
            name: "login",
            component: LoginComponent
        }
    ]
});

export default routers;
