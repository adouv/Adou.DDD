<template>
    <div class="page-body ad-theme-setting">
        <div class="page-header">
            <h1 class="page-title">用户管理</h1>
            <el-breadcrumb separator="/">
                <el-breadcrumb-item>首页</el-breadcrumb-item>
                <el-breadcrumb-item>用户管理</el-breadcrumb-item>
            </el-breadcrumb>
        </div>
        <div class="page-content">
            <el-form :label-position="top" size="small">
                <div class="row">
                    <div class="col-sm-6 col-md-4">
                        <el-form-item label="用户名">
                            <el-input placeholder="用户名"></el-input>
                        </el-form-item>
                    </div>
                    <div class="col-sm-6 col-md-4">
                        <el-form-item label="组织架构">
                            <el-select placeholder="请选择组织机构" style="width:100%;">
                                <el-option label="组织机构一" value="zuzhijiegou1"></el-option>
                                <el-option label="组织机构二" value="zuzhijiegou2"></el-option>
                            </el-select>
                        </el-form-item>
                    </div>
                    <div class="col-sm-6 col-md-4">
                        <el-form-item label="岗位">
                            <el-input placeholder="岗位"></el-input>
                        </el-form-item>
                    </div>
                </div>
            </el-form>

            <div class="row">
                <el-table :data="tableData" style="width: 100%">
                    <el-table-column prop="date" label="日期" width="180"></el-table-column>
                    <el-table-column prop="name" label="姓名" width="180"></el-table-column>
                    <el-table-column prop="address" label="地址"></el-table-column>
                </el-table>
            </div>

        </div>
    </div>
</template>

<script>
    export default {
        name: 'UserListComponent',
        data() {
            return {
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
                }]
            }
        }
    }
</script>

<style lang="scss">
    .el-col {
        border-radius: 4px;
    }

    .bg-purple-dark {
        background: #99a9bf;
    }

    .bg-purple {
        background: #d3dce6;
    }

    .bg-purple-light {
        background: #e5e9f2;
    }

    .grid-content {
        border-radius: 4px;
        min-height: 36px;
    }
</style>