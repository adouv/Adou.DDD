<template>
  <aside class="main-sidebar">
    <section class="sidebar">
      <ul class="sidebar-menu" data-widget="tree">
        <li class="header">导航</li>
        <li class="active treeview">
          <router-link to="/">
            <i class="fa fa-dashboard"></i>
            <span>控制面板</span>
            <span class="pull-right-container">
              <i class="fa fa-angle-left pull-right"></i>
            </span>
          </router-link>
        </li>

        <li
          class="treeview"
          v-for="item in sidebarList"
          :key="item.id"
          v-bind:class="{'menu-open':item.isSubShow}"
        >
          <a href="Javascript:void(0);" @click="showToggle(item);">
            <i :class="item.icon"></i>
            <span>{{item.text}}</span>
            <span class="pull-right-container">
              <i class="fa fa-angle-left pull-right"></i>
            </span>
          </a>
          <transition name="sidebar">
            <ul class="treeview-menu" v-show="item.isSubShow" transiton="sidebar">
              <li v-for="items in item.children" :key="items.id" class="active">
                <a href="javascript:void(0);" @click="toPath(items)">{{items.text}}</a>
              </li>
            </ul>
          </transition>
        </li>
      </ul>
    </section>
  </aside>
</template>

<script>
// import RightService from "../../_service/right.service";
// import OperatingService from "../../_service/operating.service";
export default {
  name: "SidebarComponent",
  data() {
    return {
      sidebarList:[],
      data: [
        {
          RightId: 5,
          RightName: "系统管理",
          Description: "系统管理",
          RightUrl: "#",
          ParentID: 0,
          IconFontName: "fa fa-laptop"
        },
        {
          RightId: 6,
          RightName: "用户管理",
          Description: "用户管理",
          RightUrl: "user",
          ParentID: 5,
          IconFontName: "fa fa-laptop"
        },
        {
          RightId: 7,
          RightName: "角色管理",
          Description: "角色管理",
          RightUrl: "role",
          ParentID: 5,
          IconFontName: "fa fa-laptop"
        },
        {
          RightId: 8,
          RightName: "菜单管理",
          Description: "菜单管理",
          RightUrl: "menu",
          ParentID: 5,
          IconFontName: "fa fa-laptop"
        },
        {
          RightId: 9,
          RightName: "权限管理",
          Description: "权限管理",
          RightUrl: "operation",
          ParentID: 5,
          IconFontName: "fa fa-laptop"
        },
        {
          RightId: 10,
          RightName: "订单管理",
          Description: "订单管理",
          RightUrl: "#",
          ParentID: 0,
          IconFontName: "fa fa-laptop"
        },
        {
          RightId: 12,
          RightName: "病患配置",
          Description: "病患配置",
          RightUrl: "#",
          ParentID: 0,
          IconFontName: "fa fa-laptop"
        },
        {
          RightId: 13,
          RightName: "医师管理",
          Description: "医师管理",
          RightUrl: "#",
          ParentID: 0,
          IconFontName: "fa fa-laptop"
        },
        {
          RightId: 14,
          RightName: "系统配置",
          Description: "系统配置",
          RightUrl: "#",
          ParentID: 0,
          IconFontName: "fa fa-laptop"
        },
        {
          RightId: 15,
          RightName: "医院管理",
          Description: "医院管理",
          RightUrl: "hospital",
          ParentID: 14,
          IconFontName: "fa fa-laptop"
        },
        {
          RightId: 16,
          RightName: "实验室管理",
          Description: "实验室管理",
          RightUrl: "laboratory",
          ParentID: 14,
          IconFontName: "fa fa-laptop"
        },
        {
          RightId: 17,
          RightName: "医师管理",
          Description: "医师管理",
          RightUrl: "doctor",
          ParentID: 13,
          IconFontName: "fa fa-laptop"
        },
        {
          RightId: 18,
          RightName: "医师标签管理",
          Description: "医师标签管理",
          RightUrl: "doctorLabel",
          ParentID: 13,
          IconFontName: "fa fa-laptop"
        },
        {
          RightId: 20,
          RightName: "项目列表",
          Description: "项目列表",
          RightUrl: "testItem",
          ParentID: 25,
          IconFontName: "fa fa-laptop"
        },
        {
          RightId: 21,
          RightName: "患者管理",
          Description: "患者管理",
          RightUrl: "patient",
          ParentID: 12,
          IconFontName: "fa fa-laptop"
        },
        {
          RightId: 23,
          RightName: "项目套餐管理",
          Description: "项目套餐管理",
          RightUrl: "testPackage",
          ParentID: 25,
          IconFontName: "fa fa-laptop"
        },
        {
          RightId: 24,
          RightName: "病例管理",
          Description: "病例管理",
          RightUrl: "medicalRecord",
          ParentID: 12,
          IconFontName: "fa fa-laptop"
        },
        {
          RightId: 25,
          RightName: "检测项目管理",
          Description: "检测项目管理",
          RightUrl: "#",
          ParentID: 0,
          IconFontName: "fa fa-laptop"
        },
        {
          RightId: 26,
          RightName: "物料管理",
          Description: "物料管理",
          RightUrl: "sendMaterial",
          ParentID: 10,
          IconFontName: "fa fa-laptop"
        },
        {
          RightId: 27,
          RightName: "预约项目管理",
          Description: "预约项目管理",
          RightUrl: "doctorAppointmentItem",
          ParentID: 13,
          IconFontName: "fa fa-laptop"
        },
        {
          RightId: 29,
          RightName: "预约设置管理",
          Description: "医师资讯预约设置",
          RightUrl: "doctorAppointment",
          ParentID: 13,
          IconFontName: "fa fa-laptop"
        },
        {
          RightId: 31,
          RightName: "订单管理",
          Description: "订单管理",
          RightUrl: "order",
          ParentID: 10,
          IconFontName: "fa fa-laptop"
        },
        {
          RightId: 32,
          RightName: "下单检测",
          Description: "下单检测",
          RightUrl: "patientDelection",
          ParentID: 10,
          IconFontName: "fa fa-laptop"
        },
        {
          RightId: 33,
          RightName: "批量上传报告",
          Description: "批量上传报告",
          RightUrl: "orderReport",
          ParentID: 10,
          IconFontName: "fa fa-laptop"
        }
      ]
    };
  },
  mounted() {
    this.getMenuByUserId();
  },
  methods: {
    async toPath(items) {
      let mkey = "ModifyOrderDelection";
      this.local$.removeItem(mkey);
      this.local$.setItem(mkey, JSON.stringify({ flag: false }));

      let params = {};
      params.userID = this.local$.getUser().SysUserId;
      params.rightID = items.id;
      let result = await OperatingService.getOperationByUserAndRight(params);
      params.list = result.Data;
      this.local$.removeItem("tdSelfMenuOperation");
      this.local$.setItem("tdSelfMenuOperation", JSON.stringify(params));

      this.$router.push({ path: `/${items.path}` });
    },
    showToggle(item) {
      this.sidebarList.forEach(element => {
        if (item.id == element.id) {
          item.isSubShow = !item.isSubShow;
        } else {
          element.isSubShow = false;
        }
      });
    },
    getMenuByUserId() {
      this.data.forEach(element => {
        let children = [];

        if (element.ParentID === 0) {
          this.sidebarList.push({
            id: element.RightId,
            text: element.RightName,
            icon: element.IconFontName,
            url: "#",
            path: "#",
            isSubShow: false,
            children: children
          });
        }

        this.data.forEach(subElement => {
          if (subElement.ParentID === element.RightId) {
            children.push({
              id: subElement.RightId,
              text: subElement.RightName,
              icon: "",
              url: subElement.RightUrl,
              path: subElement.RightUrl
            });
          }
        });
      });
      // let params = {};
      // params.userID = this.local$.getUser().SysUserId;
      // RightService.getMenuByUserId(params).then(response => {
      //   if (response !== null && response.Data.length > 0) {
      //     response.Data.forEach(element => {
      //       let children = [];

      //       if (element.ParentID === 0) {
      //         this.sidebarList.push({
      //           id: element.RightId,
      //           text: element.RightName,
      //           icon: element.IconFontName,
      //           url: "#",
      //           path: "#",
      //           isSubShow: false,
      //           children: children
      //         });
      //       }

      //       response.Data.forEach(subElement => {
      //         if (subElement.ParentID === element.RightId) {
      //           children.push({
      //             id: subElement.RightId,
      //             text: subElement.RightName,
      //             icon: "",
      //             url: subElement.RightUrl,
      //             path: subElement.RightUrl
      //           });
      //         }
      //       });
      //     });
      //   } else {
      //     this.$tip(response.Message);
      //   }
      // });
    }
  }
};
</script>

<style lang="scss">
.sidebar-enter-active,
.sidebar-leave-active {
  transition: opacity 0.2s;
}
.sidebar-enter,
.sidebar-leave-active {
  opacity: 0;
}
</style>

