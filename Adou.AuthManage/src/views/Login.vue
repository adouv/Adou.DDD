<template>
  <div class="page-login layout-full page-dark">
    <div class="page height-full">
      <div class="page-content height-full">
        <div class="page-brand-info vertical-align animation-slide-left hidden-xs">
          <div class="page-brand vertical-align-middle">
            <div class="brand">
              <!-- <img class="brand-img" src="http://cdn.admui.com/demo/pjax/1.3.0/images/logo-white.svg" height="50" alt="Admui"> -->
            </div>
            <h2 class="hidden-sm">添丁后台管理系统</h2>
            <!-- <ul class="list-icons hidden-sm">
              <li>
                <i class="wb-check" aria-hidden="true"></i> Adou 是一个基于最新 Web 技术的企业级通用管理系统快速开发框架，可以帮助企业极大的提高工作效率，节省开发成本，提升品牌形象。
              </li>
              <li>
                <i class="wb-check" aria-hidden="true"></i> 您可以 Admui 为基础，快速开发各种MIS系统，如CMS、OA、CRM、ERP、POS等。</li>
              <li>
                <i class="wb-check" aria-hidden="true"></i> Admui 紧贴业务特性，涵盖了大量的常用组件和基础功能，最大程度上帮助企业节省时间成本和费用开支。
              </li>
            </ul>-->
          </div>
        </div>
        <div class="page-login-main animation-fade">
          <div class="vertical-align">
            <div class="vertical-align-middle">
              <div class="brand visible-xs text-center">
                <img
                  class="brand-img"
                  src="../assets/images/logo.svg"
                  height="50"
                  alt="Admui"
                >
              </div>

              <h3 class="hidden-xs">登录 添丁</h3>

              <div class="login-form fv-form fv-form-bootstrap">
                <div class="form-group has-feedback has-success">
                  <label class="sr-only" for="userName">用户名</label>
                  <input
                    type="text"
                    class="form-control"
                    title="用户名"
                    id="userName"
                    name="userName"
                    v-model="userName"
                    placeholder="用户名"
                  >
                </div>

                <div class="form-group has-feedback has-success">
                  <label class="sr-only" for="userPwd">密码</label>
                  <input
                    type="password"
                    class="form-control"
                    id="userPwd"
                    name="userPwd"
                    v-model="userPwd"
                    placeholder="密码"
                  >
                </div>

                <div class="form-group has-feedback">
                  <label class="sr-only" for="userCode">验证码</label>
                  <div class="input-group">
                    <input
                      type="text"
                      class="form-control"
                      name="userCode"
                      placeholder="请输入验证码"
                      v-model="userCode"
                      @keyup.enter="btnLogin();"
                    >
                    <a class="input-group-addon padding-0 reload-vify" href="javascript:;">
                      <img
                        v-bind:src="ImgByteArray"
                        width="100"
                        height="38"
                        @click="btnValidateCode();"
                      >
                    </a>
                  </div>
                </div>

                <div class="form-group clearfix">
                  <div class="checkbox-custom checkbox-inline checkbox-primary pull-left">
                    <input type="checkbox" id="remember" checked="true" name="remember">
                    <label for="remember">自动登录</label>
                  </div>
                </div>

                <button
                  type="button"
                  class="btn btn-primary btn-block margin-top-30"
                  @click="btnLogin();"
                >立即登录</button>
              </div>
            </div>
          </div>

          <footer class="page-copyright">
            <p>
              Adou ©
              <a href="http://www.a-dou.com" target="_blank">a-dou.com</a>
            </p>
          </footer>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
// import AuthService from "../../_service/auth.service";
// import UserService from "../../_service/user.service";
// import EncryptService from "../../_ddd/encrypt.service";

export default {
  name: "LoginComponent",
  data() {
    return {
      userName: "Administrator",
      userPwd: "tianding8",
      userCode: "",
      ValidateCode: "",
      ImgByteArray: ""
    };
  },
  mounted() {
    // this.btnValidateCode();
  },
  methods: {
    /**
     * 用户登录
     */
    btnLogin() {
      let self = this;

      self.$router.push({ path: "/" });

      return;
      
      let params = {};

      params.userName = this.userName;
      params.password = this.userPwd;
      params.userCode = this.userCode;
      params.flag =
        EncryptService.MD5Encryption(params.userCode) === this.ValidateCode;

      if (!params.flag) {
        this.$tip("请输入正确的验证码！");
        return;
      }

      UserService.getToken(params)
        .then(response => {
          if (response != null) {
            let { Data } = response;
            this.local$.removeItem("tdToken");
            this.local$.removeItem("tdUser");
            this.local$.setItem("tdToken", Data.Password);
            this.local$.setItem("tdUser", JSON.stringify(Data));
            this.$tip(
              "登录成功！",
              function(show) {
                self.$router.push({ path: "/" });
              },
              500
            );
          }
        })
        .catch(error => {
          let logData = {};
          logData.status = error.response.status;
          logData.data = error.response.config.data;
          logData.message = error.response.data;
          logData.url = error.response.config.url;
          logData.type = "response.error";
          let logParams = {};
          logParams.Content = JSON.stringify(logData);
          logParams.IPAddress = "";
          this.CommonService.WriteLog(logParams).then();
        });
    },
    btnValidateCode() {
      AuthService.getValidateCode().then(response => {
        if (response !== null) {
          let { Data } = response;
          this.ValidateCode = Data.ValidateCode;
          this.ImgByteArray = `data:image/jpeg;base64,${Data.ImgByteArray}`;
        }
      });
    }
  }
};
</script>

<style lang="scss">
html {
  height: 100%;
}

.page-login {
  height: 100%;
  min-height: 600px;
  padding-top: 0;
  overflow: hidden;
  &:before {
    background: url("../assets/images/login.jpg");
  }
  &.page-dark.layout-full:after {
    background-color: rgba(38, 50, 56, 0.6);
  }
  .page-brand-info {
    height: 100%;
    .page-brand {
      padding: 0 60px 60px;
      .brand-img {
        vertical-align: middle;
      }
      h2 {
        max-width: 650px;
        color: #fff;
      }
      .list-icons {
        padding-left: 0;
        margin: 30px 0;
      }
    }
  }
}

.page-login-main {
  position: absolute;
  top: 0;
  right: 0;
  height: 100%;
  min-height: 600px;
  padding: 150px 60px 180px;
  padding: 0 60px;
  color: #76838f;
  background: #fff;
  > .alert {
    position: absolute;
    top: 0;
    right: 0;
    left: 0;
    text-align: center;
    border-radius: 0;
  }
  .vertical-align {
    height: 100%;
    -webkit-box-sizing: border-box;
    -moz-box-sizing: border-box;
    box-sizing: border-box;
    padding-bottom: 65px;
  }
  > .alert {
    padding-right: 10px;
    + .vertical-align {
      padding-top: 65px;
    }
  }
  .version-toggle {
    float: right;
    margin-top: -5px;
  }
}

.page-login .login-form {
  width: 350px;
  margin: 45px 0 20px;
  .form-control {
    height: 42px;
  }
}

input.page-login .login-form .form-control {
  padding: 0 12px;
}

.page-login {
  .login-form {
    .form-control .btn {
      height: 100%;
    }
    &.fv-form-bootstrap .form-control-feedback {
      margin: 6px;
      background-color: transparent;
    }
    .input-group + .form-control-feedback {
      display: none !important;
    }
    > button {
      padding: 8px 0;
    }
  }
  .page-copyright {
    position: absolute;
    right: 0;
    bottom: 15px;
    left: 0;
    text-align: center;
  }
}

@media (max-height: 600px) {
  .page-login .page-copyright {
    display: none;
  }
}

@media (min-width: 992px) {
  .page-login .page-content {
    padding-right: 500px;
  }
}

@media (max-width: 767px) {
  .page-login {
    overflow: auto;
    background: #fff;
    background-image: none;
    .login-form {
      width: auto;
    }
  }
}

@media (max-width: 480px) {
  .page-login-main {
    width: 100%;
  }
  .page-login .login-form {
    width: auto;
  }
}
</style>

