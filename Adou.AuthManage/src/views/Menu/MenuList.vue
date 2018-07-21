<template>
    <div class="page-body">
        <div class="page-header">
            <h1 class="page-title">模块管理</h1>
            <el-breadcrumb separator="/">
                <el-breadcrumb-item>首页</el-breadcrumb-item>
                <el-breadcrumb-item>模块管理</el-breadcrumb-item>
            </el-breadcrumb>
        </div>
        <div class="page-content">
            <el-form :label-position="top" size="small">
                <div class="row">
                    <div class="col-sm-3 col-lg-3">
                        <el-form-item label="模块名称">
                            <el-input placeholder="模块名称" v-model="form.Title"></el-input>
                        </el-form-item>
                    </div>
                    <div class="col-sm-12 col-lg-12">
                        <el-button type="primary" size="mini" @click="menuList">查找</el-button>
                        <el-button type="success" size="mini" @click="$router.push({ name: 'addMenu' });">添加</el-button>
                    </div>
                </div>
            </el-form>

            <div class="row">
                <div class="table-responsive">
                    <el-table :data="tableData" v-loading="loading" stripe style="width: 100%">
                        <el-table-column prop="date" label="日期" width="180"></el-table-column>
                        <el-table-column prop="name" label="姓名" width="180"></el-table-column>
                        <el-table-column prop="address" label="地址"></el-table-column>
                    </el-table>
                </div>
            </div>
        </div>
    </div>
</template>

<script lang="text/javascript" scoped>
    export default {
        name: 'MenuListComponent',
        data() {
            return {
                form: {
                    Id: 0,
                    Title: "",
                    MenuIcon: "",
                    MenuUrl: "",
                    FatherId: 0,
                    LevelId: 0,
                    IsValid: 0
                },
                tableData: [{
                    date: '2016-05-02',
                    name: '王小虎',
                    address: '上海市普陀区金沙江路 1518 弄'
                }, {
                    date: '2016-05-04',
                    name: '王小虎',
                    address: '上海市普陀区金沙江路 1517 弄'
                }, {
                    date: '2016-05-01',
                    name: '王小虎',
                    address: '上海市普陀区金沙江路 1519 弄'
                }, {
                    date: '2016-05-03',
                    name: '王小虎',
                    address: '上海市普陀区金沙江路 1516 弄'
                }],
                loading: true
            }
        },
        methods: {
            menuList() {
                let that = this;
                that.loading = true;
                setTimeout(() => {
                    let params = { FatherId: 0 };
                    that.$http.post('Menu/GetMenuByFatherId', params).then(response => {
                        console.log(response);
                        that.loading = false;
                    });
                }, 2000);
            },
            toPathRouter(name, params = {}) {
                this.$router.push({ name: name });
            }
        },
        mounted() {
            this.menuList();
        }
    }
</script>
