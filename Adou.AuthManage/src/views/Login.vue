<template>
    <div class="login">
        <el-form :model="form" class="login-box">
            <el-form-item class="login-logo">
                <img src="../assets/images/adou.jpg" />
                <p>您好，欢迎登录！<br />Adou 通用权限管理系统</p>
            </el-form-item>
            <el-form-item>
                <el-input type="text" prefix-icon="el-icon-message" v-model="form.userName" auto-complete="off" placeholder="UserName"></el-input>
            </el-form-item>
            <el-form-item>
                <el-input type="password" prefix-icon="el-icon-view" v-model="form.userPwd" auto-complete="off" placeholder="UserPassword"></el-input>
            </el-form-item>
            <el-form-item>
                <el-button type="primary" size="medium" @click="submitForm();">登录</el-button>
            </el-form-item>
        </el-form>
    </div>
</template>

<script>
    export default {
        name: "LoginComponent",
        data() {
            return {
                form: {
                    userName: "",
                    userPwd: ""
                }
            }
        },
        methods: {
            submitForm() {
                console.log(this.form.userName);
                console.log(this.form.userPwd);
                this.$router.push({ path: '/' });
            }
        }
    }
</script>

<style lang="scss" scoped>
    @import "../assets/scss/views/login";
</style>