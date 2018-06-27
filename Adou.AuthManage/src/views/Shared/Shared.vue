<template>
    <div class="ad" ref="shared">
        <el-header class="ad-header" :style="{backgroundColor:$store.state.skin.headerBgColor,Color:$store.state.skin.headerTextColor}">
            <!--#region | LOGO | 大小LOGO区分-->
            <el-aside class="ad-header-left" :style="{width:asideWidth}" v-if="!isCollapse">
                <i class="el-icon-menu" v-on:click="toggleCollapse"></i>
                <span>ADOU</span>
                <el-dropdown trigger="click">
                    <span class="el-dropdown-link">
                        <i class="el-icon-more"></i>
                    </span>
                    <el-dropdown-menu slot="dropdown">
                        <el-dropdown-item>黄金糕</el-dropdown-item>
                        <el-dropdown-item>狮子头</el-dropdown-item>
                        <el-dropdown-item>螺蛳粉</el-dropdown-item>
                        <el-dropdown-item disabled>双皮奶</el-dropdown-item>
                        <el-dropdown-item divided>蚵仔煎</el-dropdown-item>
                    </el-dropdown-menu>
                </el-dropdown>
            </el-aside>
            <!--小LOGO-->
            <el-aside class="ad-header-left" :style="{width:asideWidth}" v-if="isCollapse">AD</el-aside>
            <!--#endregion-->
            <el-container class="ad-header-right">
                <!--#region | 右侧菜单显示隐藏按钮-->
                <i class="el-icon-back aside-toggle" v-on:click="toggleCollapse"></i>
                <!--#endregion-->
            </el-container>
        </el-header>
        <el-aside class="ad-container-left" :style="{width:asideWidth}">
            <el-menu :style="{width:menuWidth}" router :unique-opened="true" default-active="1-4-1" class="ad-menu" @open="handleOpen" @close="handleClose" :collapse="isCollapse">
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
                        <el-menu-item index="1-1" v-on:click="toPathRouter('home')"><i class="el-icon-back"></i>用户管理</el-menu-item>
                        <el-menu-item index="1-2" v-on:click="toPathRouter('home')"><i class="el-icon-back"></i>角色管理</el-menu-item>
                        <el-menu-item index="1-3" v-on:click="toPathRouter('home')"><i class="el-icon-back"></i>菜单管理</el-menu-item>
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
        </el-aside>
        <el-container class="ad-container-right">
            <el-main v-on:click="toggleCollapse">
                <router-view></router-view>
            </el-main>
        </el-container>
        <el-footer class="ad-footer" height="56px">
            这里是底部版权
        </el-footer>
    </div>
</template>

<script>
    import Service from '@/services'
    export default {
        name: "SharedComponent",
        data() {
            return {
                isPhone: false,
                isCollapse: false
            };
        },
        methods: {
            handleOpen(key, keyPath) {
                console.log('open');
            },
            handleClose(key, keyPath) {
                console.log('close');
            },
            /**
             * 左侧菜单显示/隐藏
             */
            toggleCollapse() {
                let _asideName = "phone-aside-show";
                let _disktopName = "disktop-content-toggle";
                let _isOpen = this.$refs.shared.classList.value.includes(_asideName);
                if (!this.isPhone) {
                    this.isCollapse = !this.isCollapse;
                    if (this.isCollapse) {
                        this.$refs.shared.classList.add(_disktopName);
                    } else {
                        this.$refs.shared.classList.remove(_disktopName);
                    }
                } else {
                    if (_isOpen) {
                        this.$refs.shared.classList.remove(_asideName);
                    } else {
                        this.$refs.shared.classList.add(_asideName);
                    }
                }
            },
            /**
             * 菜单路由跳转
             * @param name  路由名称
             */
            toPathRouter(name, params = {}) {
                this.$router.push({ name: name, params: params });
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