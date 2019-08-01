<template>
    <div class="page-body">
        <div class="page-header">
            <h1 class="page-title">添加模块</h1>
            <el-breadcrumb separator="/">
                <el-breadcrumb-item>首页</el-breadcrumb-item>
                <el-breadcrumb-item>添加模块</el-breadcrumb-item>
            </el-breadcrumb>
        </div>
        <div class="page-content">
            <div class="row ad-form">
                <el-form ref="form" :model="form" :label-position="top" size="small">
                    <div class="col-sm-12 col-md-12">
                        <el-form-item label="模块名称" prop="Title" :rules="[{required:true,message:'模块名称不能为空'}]">
                            <el-input v-model="form.Title" placeholder="请输入模块名称" auto-complete="off"></el-input>
                        </el-form-item>
                    </div>

                    <div class="col-sm-12 col-md-4">
                        <el-form-item label="父级">
                            <el-select v-model="form.FatherId" style="width:100%;" placeholder="请选择父级">
                                <el-option label="请选择父级" value="-1"></el-option>
                                <el-option label="区域一" value="0"></el-option>
                                <el-option label="区域二" value="1"></el-option>
                            </el-select>
                        </el-form-item>
                    </div>

                    <div class="col-sm-12 col-md-12">
                        <el-form-item label="图标" prop="MenuIcon" :rules="[{required:true,message:'请选择图标'}]">
                            <el-input placeholder="请选择图标" v-model="form.MenuIcon">
                                <template slot="append">
                                    <span style="cursor:pointer;">选择图标</span>
                                </template>
                            </el-input>
                        </el-form-item>
                    </div>

                    <div class="col-sm-12 col-md-12">
                        <el-form-item label="地址" prop="MenuUrl" :rules="[{required:true,message:'请输入模块地址'}]">
                            <el-input placeholder="请输入地址" v-model="form.MenuUrl"></el-input>
                        </el-form-item>
                    </div>

                    <div class="col-sm-12 col-md-12">
                        <el-form-item label="是否有效">
                            <el-radio-group v-model="form.IstValid">
                                <el-radio :label="0">否</el-radio>
                                <el-radio :label="1">是</el-radio>
                            </el-radio-group>
                        </el-form-item>
                    </div>

                    <div class="col-sm-12 col-md-12">
                        <el-form-item size="large">
                            <el-button type="primary" @click="btnSubmit();">保存</el-button>
                            <el-button>取消</el-button>
                        </el-form-item>
                    </div>
                </el-form>
            </div>
        </div>
    </div>
</template>

<script>
    export default {
        name: "AddMenuComponent",
        data() {
            return {
                form: {
                    Id: 0,
                    Title: '',
                    MenuIcon: '',
                    MenuUrl: '',
                    FatherId: '',
                    LevelId: 0,
                    IstValid: 1
                }
            }
        },
        methods: {
            btnSubmit() {
                this.$refs['form'].validate((valid) => {
                    console.log(valid);
                    if (valid) {
                        console.log(this.form);
                        this.$http.post('Menu/InsertMenu', this.form).then(response => {
                            console.log(response);
                        });
                    }
                });
            }
        }
    }
</script>

<style>
    .ad-form {
        width: 40%;
        margin: 0 auto !important;
    }

    @media (max-width:800px) {
        .ad-form {
            width: 100%;
        }
    }
</style>