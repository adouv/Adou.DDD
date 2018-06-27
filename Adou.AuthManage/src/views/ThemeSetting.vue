<template>
    <div class="page-body ad-theme-setting">
        <div class="page-header">
            <h1 class="page-title">个性化设置</h1>
            <el-breadcrumb separator="/">
                <el-breadcrumb-item>首页</el-breadcrumb-item>
                <el-breadcrumb-item>个性化设置</el-breadcrumb-item>
            </el-breadcrumb>
        </div>
        <div class="page-content">
            <el-form ref="form" :model="form" label-width="80px">
                <el-form-item label="导航颜色">
                    <div class="skintoolsNavbar">
                        <ul class="color-radio">
                            <li v-for="item in colorList" :key="item.key">
                                <div :class="'radio-custom radio-'+item.key">
                                    <input type="radio" name="headerColor" v-model="form.headerColor" :value="item.val" @click="headerColorEvent(item);" /> <label></label>
                                </div>
                            </li>
                        </ul>
                    </div>
                </el-form-item>
                <el-form-item label="菜单主题">
                    <el-select v-model="form.region" placeholder="请选择菜单主题">
                        <el-option label="浅色主题" value="qianse"></el-option>
                        <el-option label="深色主题" value="shense"></el-option>
                    </el-select>
                </el-form-item>
                <el-form-item label="主题颜色">
                    <!--<el-radio-group v-model="form.resource">
                        <el-radio label="线上品牌商赞助"></el-radio>
                        <el-radio label="线下场地免费"></el-radio>
                    </el-radio-group>-->
                </el-form-item>
                <el-form-item label="Tab页签">
                    <el-switch v-model="form.delivery"></el-switch>
                </el-form-item>
                <el-form-item>
                    <el-button type="primary" @click="onSubmit">立即创建</el-button>
                    <el-button>取消</el-button>
                </el-form-item>
            </el-form>
        </div>
    </div>
</template>

<script>
    import { mapActions } from "vuex";
    export default {
        name: "ThemeSettingComponent",
        data() {
            return {
                colorList: [
                    {
                        key: "primary",
                        val: "#409EFF"
                    },
                    {
                        key: "brown",
                        val: "#8d6658"
                    },
                    {
                        key: "cyan",
                        val: "#57c7d4"
                    },
                    {
                        key: "green",
                        val: "#46be8a"
                    },
                    {
                        key: "grey",
                        val: "#757575"
                    },
                    {
                        key: "indigo",
                        val: "#677ae4"
                    },
                    {
                        key: "orange",
                        val: "#f2a654"
                    },
                    {
                        key: "pink",
                        val: "#f96197"
                    },
                    {
                        key: "purple",
                        val: "#926dde"
                    },
                    {
                        key: "red",
                        val: "#f96868"
                    },
                    {
                        key: "teal",
                        val: "#3aa99e"
                    },
                    {
                        key: "yellow",
                        val: "#f7da64"
                    }
                ],
                headerColor: '#409EFF',
                form: {
                    name: '',
                    headerColor: '#409EFF',
                    date1: '',
                    date2: '',
                    delivery: false,
                    type: [],
                    resource: '1',
                    desc: ''
                }
            }
        },
        methods: {
            onSubmit() {
                console.log('submit!');
            },
            headerColorEvent(params) {
                this.SetHeaderBg(params);
            },
            ...mapActions(["SetHeaderBg"])
        }
    }
</script>

<style lang="scss" scoped>
    @import "../assets/scss/views/themeSetting";
</style>