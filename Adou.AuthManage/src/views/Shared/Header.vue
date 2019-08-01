<template>
<header class="main-header">
  <a href="Javascript:void(0);" class="logo">
    <span class="logo-mini">添丁</span>
    <span class="logo-lg">添丁权限管理系统</span>
  </a>

  <nav class="navbar navbar-static-top">
    <!-- Sidebar toggle button 边栏切换按钮-->
    <a href="JavaScript:void(0);" class="sidebar-toggle" @click="sidebarToggle($event);" data-toggle="push-menu" role="button">
      <span class="sr-only">Toggle navigation</span>
    </a>

    <div class="navbar-custom-menu">
      <ul class="nav navbar-nav">
        <li class="nav-item dropdown layout-menu">
          <router-link to="setting" title="页面布局" class="nav-item-a">
            <i class="icon wb-layout"></i>
          </router-link>
        </li>
        <li class="nav-item dropdown phone-menu">
          <a href="JavaScript:void(0);" title="手机预览" class="nav-item-a dropdown-toggle" data-toggle="dropdown">
            <i class="icon wb-mobile"></i>
          </a>
        </li>
        <li class="nav-item dropdown notifications-menu">
          <a href="JavaScript:void(0);" title="系统通知" class="nav-item-a dropdown-toggle" data-toggle="dropdown">
            <i class="icon wb-bell"></i>
            <span class="label label-warning">10</span>
          </a>
        </li>
        <li class="nav-item dropdown fullscreen-menu">
          <a href="JavaScript:void(0);" title="全屏预览" class="nav-item-a dropdown-toggle" data-toggle="dropdown">
            <i class="icon wb-fullscreen"></i>
          </a>
        </li>
        <li class="nav-item dropdown user user-menu">
          <a href="JavaScript:void(0);" class="nav-item-a dropdown-toggle" data-toggle="dropdown">
            <img src="../../assets/images/user9-200x200.png" class="user-image" alt="User Image">
            <span class="hidden-xs">付凯航</span>
          </a>
        </li>
        <li class="nav-item">
          <a href="JavaScript:void(0);" title="退出登录" class="nav-item-a" data-toggle="control-sidebar" @click="outLogin();">
            <i class="fa fa-sign-out"></i>
          </a>
        </li>
      </ul>
    </div>
  </nav>
</header>

</template>

<script>
export default {
  name: "HeaderComponent",
  data() {
    return {
      user: {}
    };
  },
  mounted() {
    this.user = JSON.parse(this.local$.getItem("adUser"));
  },
  methods: {
    outLogin() {
      this.local$.removeItem("adToken");
      this.local$.removeItem("adUser");
      this.$router.push("/login");
    },
    sidebarToggle($event) {
      this.elem$.sidebarToggle($event);
    }
  }
};
</script>
