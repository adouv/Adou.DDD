<template>
    <div class="page-body ad-button">
        <div class="page-header">
            <h1 class="page-title">Notice 通知</h1>
            <el-breadcrumb separator="/">
                <el-breadcrumb-item>首页</el-breadcrumb-item>
                <el-breadcrumb-item>Notice 通知</el-breadcrumb-item>
            </el-breadcrumb>
        </div>
        <div class="page-content">
            <el-row>
                <el-button type="success" @click="tip('success');">tip-success</el-button>
                <el-button type="info" @click="tip('info');">tip-info</el-button>
                <el-button type="warning" @click="tip('warning');">tip-warning</el-button>
                <el-button type="danger" @click="tip('error');">tip-error</el-button>
            </el-row>

            <el-row>
                <el-button type="success" @click="message('success');">message-success</el-button>
                <el-button type="info" @click="message('info');">message-info</el-button>
                <el-button type="warning" @click="message('warning');">message-warning</el-button>
                <el-button type="danger" @click="message('error');">message-error</el-button>
            </el-row>

            <el-row>
                <el-button type="success" @click="confirm('success');">messageBox-confirm-success</el-button>
                <el-button type="info" @click="confirm('info');">messageBox-confirm-info</el-button>
                <el-button type="warning" @click="confirm('warning');">messageBox-confirm-warning</el-button>
                <el-button type="danger" @click="confirm('error');">messageBox-confirm-error</el-button>
            </el-row>

            <el-row>
                <el-button type="success" @click="alert('success');">messageBox-alert-success</el-button>
                <el-button type="info" @click="alert('info');">messageBox-alert-info</el-button>
                <el-button type="warning" @click="alert('warning');">messageBox-alert-warning</el-button>
                <el-button type="danger" @click="alert('error');">messageBox-alert-error</el-button>
            </el-row>

            <el-row>
                <el-button type="success" @click="prompt();">messageBox-prompt</el-button>
            </el-row>
        </div>
    </div>
</template>

<script>
    export default {
        name: "NoticeComponent",
        data() {
            return {

            }
        },
        methods: {
            tip(type) {
                this.$tip("我是一个tip-" + type, { type: type });
            },
            message(type) {
                this.$message({ message: "我是一个message-" + type, type: type });
            },
            confirm(type) {
                this.$confirm('标题', '这是一个confirm-' + type, {
                    type: type,
                    confirmButtonText: '123',
                    confirm: () => {
                        this.$message('您点击了确认按钮！', { type: type });
                    }, cancel: () => {
                        this.$message('您点击了取消按钮！', { type: type });
                    }
                });
            },
            alert(type) {
                this.$alert('标题', '这是一个alert-' + type, {
                    type: type,
                    callback: action => {
                        this.$message(`action:${action}`, { type: type });
                    }
                });
            },
            prompt() {
                this.$prompt('标题', '请输入邮箱：', {
                    inputPattern: /[\w!#$%&'*+/=?^_`{|}~-]+(?:\.[\w!#$%&'*+/=?^_`{|}~-]+)*@(?:[\w](?:[\w-]*[\w])?\.)+[\w](?:[\w-]*[\w])?/,
                    inputErrorMessage: '邮箱格式不正确',
                    confirm: (val) => {
                        this.$message(`你的邮箱是：${val}`);
                    },
                    cancel: () => {
                        this.$message('取消输入');
                    }
                });
            }
        }
    }
</script>

<style>
    .el-row {
        margin-bottom: 10px;
    }
</style>