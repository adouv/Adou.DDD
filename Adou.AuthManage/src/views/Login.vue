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
                <el-button :disabled="btn.disabled" :loading="btn.loading" type="primary" size="medium" @click="submitForm();">{{btn.text}}</el-button>
            </el-form-item>
        </el-form>
    </div>
</template>

<script>
    import sers from "@/services";
    import { setTimeout } from "timers";
    export default {
        name: "LoginComponent",
        data() {
            return {
                form: {
                    userName: "admin",
                    userPwd: "admin"
                },
                btn: {
                    disabled: false,
                    loading: false,
                    text: '登录'
                }
            }
        },
        methods: {
            submitForm() {

                this.btn = {
                    disabled: true,
                    loading: true,
                    text: '正在登录,请稍后...'
                };

                let that = this;
                let params = {};
                params.UserName = this.form.userName;
                params.UserPwd = this.form.userPwd;

                setTimeout(() => {
                    that.$http.post("User/UserLogin", params).then(response => {
                        if (response.data) {
                            if (response.data.Status == 100) {
                                that.$tip('登录成功！', {
                                    onClose: (t) => {
                                        localStorage.setItem(sers.Enum.AD_USER, JSON.stringify(response.data.Data));
                                        that.$router.push({ path: '/' });
                                        that.btnDisabled();
                                    }
                                });
                            } else {
                                that.$message(response.data.Message, { type: 'error' });
                                that.btnDisabled();
                            }
                        } else {
                            that.$tip('登录失败！', { type: 'error' });
                            that.btnDisabled();
                        }
                    });
                }, 3500);
            },
            btnDisabled() {
                this.btn = {
                    disabled: false,
                    loading: false,
                    text: '登录'
                };
            }
        }
    }
</script>

<style lang="scss" scoped>
    @import "../assets/scss/views/login";
</style>