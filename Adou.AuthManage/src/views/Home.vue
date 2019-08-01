<template>
<div class="page page-home animation-fade page-index-v2">
  <div class="page-header h-300 mb-30">
    <div class="text-center blue-grey-800 mt-50 m-xs-0">
      <div class="font-size-50 mb-30 blue-grey-800">
        <img src="../assets/images/user9-200x200.png" class="user-image" alt="User Image">
        <span class="hidden-xs">付凯航</span>
      </div>
    </div>
  </div>
  <div class="page-content">
    <div class="media account-info">
      <div class="media-body">
        <h4 class="media-heading">
          欢迎您，付凯航 系统管理员
        </h4>
        <p>
          <i aria-hidden="true" class="icon icon-color wb-bell"></i> 
          这是您第 100 次登录，上次登录日期：2019-01-12，如果不是您本人登录，请及时
          <a data-pjax href="javascript:;" target="_blank">修改密码</a>。
        </p>
      </div>
    </div>
  </div>
</div>
</template>

<script>
export default {
  name: "HomeComponent",
  data() {
    return {
      userInfo: {}
    };
  },
  mounted() {
    // this.userInfo = JSON.parse(this.local$.getItem("tdUser"));
    // this.userInfo.LastLoginTime = this.userInfo.LastLoginTime.replace("T", " ");
  }
};
</script>

<style lang="scss">
.page-home {
  .page-header {
    height: 300px;
    background-image: url(../assets/images/dashboard2-header.jpg);
    background-size: cover;
    .text-center {
      margin-top: 50px;
      .font-size-50 {
        text-align: center;
        img {
          width: 100px;
          height: 100px;
        }
        span {
          display: block;
        }
      }
    }
  }
  .page-content {
    margin-top: 20px;
  }
}
</style>
