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
import adMenuService from "../../_api/adMenu.service";
export default {
  name: "SidebarComponent",
  data() {
    return {
      sidebarList: [],
      loading: null
    };
  },
  mounted() {
    this.loading = this.loading$({
      lock: true,
      text: "正在加载...",
      spinner: "el-icon-loading",
      background: "rgba(0, 0, 0, 0.7)"
    });

    this.getMenuList();
  },
  methods: {
    async toPath(items) {
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
    getMenuList() {
      let params = {
        FatherId: -1,
        OrderBy: "Sort",
        IsDesc: false
      };

      adMenuService
        .getMenuList(params)
        .then(response => {
          let { Data } = response;
          if (null !== Data) {
            //===
            Data.forEach(element => {
              let children = [];

              if (element.FatherId === 0) {
                this.sidebarList.push({
                  id: element.Id,
                  text: element.Title,
                  icon: element.MenuIcon,
                  url: "#",
                  path: "#",
                  isSubShow: false,
                  children: children
                });
              }

              Data.forEach(subElement => {
                if (subElement.FatherId === element.Id) {
                  children.push({
                    id: subElement.Id,
                    text: subElement.Title,
                    icon: "",
                    url: subElement.MenuUrl,
                    path: subElement.MenuUrl
                  });
                }
              });
            });
            //===
          }
          this.loading.close();
        })
        .catch(err => {
          this.loading.close();
        });
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

