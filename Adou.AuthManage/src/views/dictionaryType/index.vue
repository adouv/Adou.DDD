<template>
  <ad-main title="数据字典管理 / 数据字典项管理" :back="true" class="ad-dictionary-type">
    <div class="row row-lg">
      <div class="col-sm-6 col-md-4">
        <div class="example-wrap">
          <h4 class="example-title">编码</h4>
          <el-input size="small" v-model="request.Coding" style="width:100%;" placeholder="请输入编码"></el-input>
        </div>
      </div>

      <div class="col-sm-6 col-md-4">
        <div class="example-wrap">
          <h4 class="example-title">名称</h4>
          <el-input size="small" v-model="request.Name" style="width:100%;" placeholder="请输入名称"></el-input>
        </div>
      </div>

      <div class="col-sm-12 col-md-12">
        <ad-button type="inverse" @click.native="getList();">搜索</ad-button>
        <ad-button type="primary" @click.native="btnEditHandller({});">添加</ad-button>
      </div>
    </div>

    <ad-table :headers="headers" :list="list">
      <tbody>
        <tr v-for="item in list" :key="item.Id">
          <td>{{item.Id}}</td>
          <td>{{item.Coding}}</td>
          <td>{{item.Name}}</td>
          <td>{{item.Sort}}</td>
          <td>{{item.ModifyTime|dateFormats}}</td>
          <td>
            <ad-button type="danger" size="sm" @click.native="btnDeleteHandller(item);">删除</ad-button>
            <ad-button type="primary" size="sm" @click.native="btnEditHandller(item);">编辑</ad-button>
          </td>
        </tr>
      </tbody>
    </ad-table>

    <ad-pagination :total="TotalItems" :pageIndex="request.PageIndex" @currentChange="getList"></ad-pagination>
  </ad-main>
</template>

<script>
import adDictionaryTypeService from "../../_api/adDictionaryType.service";
import AdDictionaryTypeEditComponent from "./edit";
export default {
  name: "AdDictionaryTypeComponent",
  data() {
    return {
      headers: ["编号", "编码", "名称", "排序", "最后更新时间", "操作"],
      list: [],
      type: 0,
      request: {
        Name: "",
        Coding: "",
        PageIndex: 1,
        PageSize: 10,
        OrderBy: "",
        IsDesc: true
      },
      TotalItems: 0,
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

    if (this.$route.params.DicType !== undefined) {
      this.type = this.$route.params.DicType;
    }

    this.getList();
  },
  methods: {
    async getList(PageIndex = 1) {
      this.list = [];

      this.request.PageIndex = PageIndex;

      try {
        let response = await adDictionaryTypeService.getDictionaryTypePageList(
          this.request
        );

        if (response.Data !== null && response.Data.Items.length !== 0) {
          this.list = response.Data.Items;
          this.TotalItems = response.Data.TotalItems;
          this.request.PageIndex = response.Data.CurrentPage;
        }

        this.loading.close();
      } catch (error) {
        this.loading.close();
      }
    },
    btnEditHandller(item) {
      let IsUndefined = item.Id !== undefined;
      let options = {};
      options.title = IsUndefined ? "修改数据字典项" : "添加数据字典项";
      options.componentName = AdDictionaryTypeEditComponent;
      options.height = 350;
      options.params = {};
      options.params.Id = IsUndefined ? item.Id : 0;
      options.params.Coding = IsUndefined ? item.Coding : "";
      options.params.Name = IsUndefined ? item.Name : "";
      options.params.Sort = IsUndefined ? item.Sort : 100;
      options.params.Remark = IsUndefined ? item.Remark : "";
      options.save = (params, close) => {
        console.log(params);
        if (!params.Name) {
          this.$tip("请填写名称");
          return;
        }

        if (params.Sort === 0 && !params.Sort) {
          params.Sort = 100;
        }

        let result = null;

        if (params.Id === 0) {
          result = adDictionaryTypeService.insertDictionaryType(params);
        } else {
          result = adDictionaryTypeService.updateDictionaryTypeById(params);
        }

        result.then(response => {
          if (response.Data > 0 && response.Data !== null) {
            this.$tip("保存成功");
          }
          this.getList();
          close();
        });
      };
      this.modal$(options);
    },
    btnDeleteHandller(item) {
      let options = {};
      options.title = "确认提示";
      options.message = "确认要删除吗？";

      options.params = {};
      options.params.Id = item.Id;

      options.save = (params, close) => {
        console.log(params);
        adDictionaryTypeService
          .updateDictionaryTypeIsDelById(params)
          .then(response => {
            if (response.Data > 0 && response.Data !== null) {
              this.$tip("删除成功");
            }
            this.getList();
            close();
          });
      };

      this.confirm$(options);
    }
  }
};
</script>
