import Vue from 'vue'
import Router from 'vue-router'
import SharedComponent from "@/views/Shared/Shared"
import HomeComponent from "@/views/Home"
import ButtonComponent from "@/views/Button"
import ThemeSettingComponent from "@/views/ThemeSetting"

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
                }
            ]
        }
    ]
});

export default routers;
