<template>
    <div class="main" ref="shared">
        <header class="main-header" :style="{backgroundColor:$store.state.skin.headerBgColor,Color:$store.state.skin.headerTextColor}">
            <a href="JavaScript:void(0);" class="logo" :style="{width:asideWidth}">
                <!--小LOGO-->
                <span class="logo-mini" v-if="isCollapse">Ad</span>
                <!--大LOGO-->
                <span class="logo-lg" v-if="!isCollapse">Adou</span>
            </a>
            <nav class="navbar">
                <i class="icon wb-menu aside-toggle" v-on:click="toggleCollapse"></i>
                <div class="navbar-menu">
                    <ul class="navbar-nav">
                        <li href="JavaScript:void(0);" v-on:click="handleCommand('sign-out')"><i class="fa fa-sign-out"></i></li>
                        <li href="JavaScript:void(0);"><i class="icon wb-fullscreen"></i></li>
                        <li href="JavaScript:void(0);"><i class="icon wb-bell"></i></li>
                        <li href="JavaScript:void(0);"><i class="icon wb-mobile"></i></li>
                        <li href="JavaScript:void(0);" v-on:click="toPathRouter('themeSetting')"><i class="icon wb-layout"></i></li>
                    </ul>
                </div>
            </nav>
            <div class="mobile-logo">
                <i class="icon wb-menu aside-toggle" v-on:click="toggleCollapse"></i>
                <span class="logo-mo">ADOU</span>
                <el-dropdown class="navbar-mo" trigger="click" @command="handleCommand">
                    <span class="el-dropdown-link">
                        <i class="icon wb-more-horizontal"></i>
                    </span>
                    <el-dropdown-menu slot="dropdown">
                        <el-dropdown-item command="themeSetting"><i class="icon wb-layout"></i>&nbsp;&nbsp;设置主题与布局</el-dropdown-item>
                        <el-dropdown-item><i class="icon wb-bell"></i>&nbsp;&nbsp;系统通知</el-dropdown-item>
                        <el-dropdown-item><i class="icon wb-bell"></i>&nbsp;&nbsp;用户信息</el-dropdown-item>
                        <el-dropdown-item><i class="icon wb-bell"></i>&nbsp;&nbsp;修改密码</el-dropdown-item>
                        <el-dropdown-item divided command="sign-out"><i class="fa fa-sign-out"></i>&nbsp;&nbsp;退出</el-dropdown-item>
                    </el-dropdown-menu>
                </el-dropdown>
            </div>
        </header>

        <aside class="main-aside" :style="{width:asideWidth}">
            <el-menu :style="{width:menuWidth}" :unique-opened="true" default-active="1-4-1" :collapse="isCollapse">
                <el-menu-item index="0" v-on:click="toPathRouter('home')">
                    <i class="el-icon-menu"></i>
                    <span slot="title">控制面板</span>
                </el-menu-item>
                <el-submenu index="1">
                    <template slot="title" class="ad-menu-title">
                        <i class="el-icon-location"></i>
                        <span slot="title">系统管理</span>
                    </template>
                    <el-menu-item-group>
                        <el-menu-item index="1-1" v-on:click="toPathRouter('userList')"><i class="el-icon-back"></i>用户管理</el-menu-item>
                        <el-menu-item index="1-2" v-on:click="toPathRouter('roleList')"><i class="el-icon-back"></i>角色管理</el-menu-item>
                        <el-menu-item index="1-3" v-on:click="toPathRouter('menuList')"><i class="el-icon-back"></i>菜单管理</el-menu-item>
                    </el-menu-item-group>
                </el-submenu>
                <el-menu-item index="2" v-on:click="toPathRouter('home')">
                    <i class="el-icon-menu"></i>
                    <span slot="title">系统监控管理</span>
                </el-menu-item>
                <el-menu-item index="3" v-on:click="toPathRouter('home')">
                    <i class="el-icon-document"></i>
                    <span slot="title">登录信息管理</span>
                </el-menu-item>
                <el-menu-item index="4" v-on:click="toPathRouter('home')">
                    <i class="el-icon-setting"></i>
                    <span slot="title">操作日志管理</span>
                </el-menu-item>
                <el-submenu index="5">
                    <template slot="title">
                        <i class="el-icon-setting"></i>
                        <span slot="title">系统配置</span>
                    </template>
                    <el-menu-item-group>
                        <el-menu-item index="5-1" v-on:click="toPathRouter('themeSetting')"><i class="el-icon-back"></i>个性化设置</el-menu-item>
                    </el-menu-item-group>
                </el-submenu>
                <el-submenu index="6">
                    <template slot="title">
                        <i class="el-icon-setting"></i>
                        <span slot="title">组件</span>
                    </template>
                    <el-menu-item-group>
                        <el-menu-item index="6-1" v-on:click="toPathRouter('button')"><i class="el-icon-back"></i>按钮</el-menu-item>
                        <el-menu-item index="6-1" v-on:click="toPathRouter('notice')"><i class="el-icon-back"></i>通知</el-menu-item>
                    </el-menu-item-group>
                </el-submenu>
                <el-menu-item index="7" v-on:click="toPathRouter('home')">
                    <i class="el-icon-setting"></i>
                    <span slot="title">导航六</span>
                </el-menu-item>
                <el-menu-item index="8" v-on:click="toPathRouter('home')">
                    <i class="el-icon-setting"></i>
                    <span slot="title">导航七</span>
                </el-menu-item>
                <el-menu-item index="9" v-on:click="toPathRouter('home')">
                    <i class="el-icon-setting"></i>
                    <span slot="title">导航八</span>
                </el-menu-item>
                <el-menu-item index="10" v-on:click="toPathRouter('home')">
                    <i class="el-icon-setting"></i>
                    <span slot="title">导航九</span>
                </el-menu-item>
                <el-menu-item index="11" v-on:click="toPathRouter('home')">
                    <i class="el-icon-setting"></i>
                    <span slot="title">导航十</span>
                </el-menu-item>
                <el-menu-item index="12" v-on:click="toPathRouter('home')">
                    <i class="el-icon-setting"></i>
                    <span slot="title">导航十一</span>
                </el-menu-item>
                <el-menu-item index="13" v-on:click="toPathRouter('home')">
                    <i class="el-icon-setting"></i>
                    <span slot="title">导航十二</span>
                </el-menu-item>
                <el-menu-item index="14" v-on:click="toPathRouter('home')">
                    <i class="el-icon-setting"></i>
                    <span slot="title">导航十三</span>
                </el-menu-item>
                <el-menu-item index="15" v-on:click="toPathRouter('home')">
                    <i class="el-icon-setting"></i>
                    <span slot="title">导航十四</span>
                </el-menu-item>
                <el-menu-item index="16" v-on:click="toPathRouter('home')">
                    <i class="el-icon-setting"></i>
                    <span slot="title">导航十五</span>
                </el-menu-item>
                <el-menu-item index="17" v-on:click="toPathRouter('home')">
                    <i class="el-icon-setting"></i>
                    <span slot="title">导航十六</span>
                </el-menu-item>
                <el-menu-item index="18" v-on:click="toPathRouter('home')">
                    <i class="el-icon-setting"></i>
                    <span slot="title">导航十七</span>
                </el-menu-item>
                <el-menu-item index="19" v-on:click="toPathRouter('home')">
                    <i class="el-icon-setting"></i>
                    <span slot="title">导航十八</span>
                </el-menu-item>
            </el-menu>
        </aside>

        <div class="main-container">
            <div class="container">
                <router-view />
            </div>
        </div>

        <!-- <footer class="main-footer">
            <p>Copyright  2018 蚂蚁金服体验技术部出品</p>
        </footer> -->

    </div>
</template>

<script>
    import sers from '@/services'
    export default {
        name: "SharedComponent",
        data() {
            return {
                isPhone: false,
                isCollapse: false
            };
        },
        methods: {
            handleCommand(command) {
                switch (command) {
                    case "sign-out":
                        this.$confirm('确认要退出吗？', '提示', {
                            confirm: () => {
                                localStorage.removeItem(sers.Enum.AD_USER);
                                window.location.href = '/AdouManage/';
                            }
                        });
                        break;
                    case "themeSetting":
                        this.toPathRouter(command);
                        break;
                }
            },
            //菜单切换
            toggleCollapse() {
                let ref = this.$refs.shared;
                let _asideName = "phone-aside-show";
                let _disktopName = "disktop-content-toggle";
                let _isOpen = sers.Element.refHasClass(ref, _asideName);

                if (!this.isPhone) {
                    this.isCollapse = !this.isCollapse;
                    if (this.isCollapse) {
                        sers.Element.refAddClass(ref, _disktopName);
                    } else {
                        sers.Element.refRemoveClass(ref, _disktopName);
                    }
                } else {
                    if (_isOpen) {
                        sers.Element.refRemoveClass(ref, _asideName);
                    } else {
                        sers.Element.refAddClass(ref, _asideName);
                    }
                }
            },
            /**
             * 菜单路由跳转
             * @param name  路由名称
             */
            toPathRouter(name, params = {}) {
                this.$router.push({ name: name });
                //移除移动端左侧菜单显示样式
                if (this.isPhone) {
                    this.$refs.shared.classList.remove('phone-aside-show');
                }
            }
        },
        mounted() {
            //判断是否移动端
            let _phoneSize = 768;
            let _windowWidth = document.documentElement.clientWidth;
            if (_windowWidth <= _phoneSize) {//手机
                this.isPhone = true;
            } else {//桌面、平板
                this.isPhone = false;
            }
            /*
                当窗体尺寸改变,重新加载页面
                上线部署后,可注释此方法
            */
            //window.onresize = function () {
            //    window.location.reload();
            //}
        },
        computed: {
            asideWidth() {
                return this.isCollapse ? "70px" : "230px";
            },
            menuWidth() {
                return this.isCollapse ? "89px" : "249px";
            }
        }
    };
</script>

<style lang="scss" scoped>
    @import "../../assets/scss/views/shared";
</style>