<template>
  <ad-left-main title="数据字典管理" class="ad-dictionary">
    <div slot="left">
      <section class="page-aside-section" style="height:auto !important;">
        <h5 class="page-aside-title">数据字典分类</h5>
        <div class="list-group">
          <a
            class="list-group-item active"
            href="javascript:;"
            v-for="(item,index) in typeList"
            :key="index"
            @click="getDictionaryList(1,item.Id);"
          >
            <i class="icon wb-dashboard" aria-hidden="true"></i>
            {{item.Name}}
          </a>
        </div>
      </section>
    </div>
    <div slot="main">
      <div class="row row-lg" style="padding:0px !important;margin:0px !important;">
        <div class="col-sm-6 col-md-4">
          <div class="example-wrap">
            <h4 class="example-title">编码</h4>
            <el-input
              size="small"
              v-model="request.DicCoding"
              style="width:100%;"
              placeholder="请输入编码"
            ></el-input>
          </div>
        </div>

        <div class="col-sm-6 col-md-4">
          <div class="example-wrap">
            <h4 class="example-title">键</h4>
            <el-input size="small" v-model="request.DicKey" style="width:100%;" placeholder="请输入键"></el-input>
          </div>
        </div>

        <div class="col-sm-12 col-md-12">
          <ad-button type="inverse" @click.native="getList();">搜索</ad-button>
          <ad-button type="primary" @click.native="btnEditHandller(item);">添加</ad-button>
          <ad-button
            type="success"
            @click.native="$router.push({ name: 'adDictionaryType',params:{DicType:request.DicType} })"
          >字典项管理</ad-button>
        </div>
      </div>

      <ad-table :headers="headers" :list="list" style="padding:0 24px !important;">
        <tbody>
          <tr v-for="item in list" :key="item.Id">
            <td>{{item.Id}}</td>
            <td>{{item.DicCoding?item.DicCoding:'--'}}</td>
            <td>{{item.DicKey}}</td>
            <td>{{item.DicValue}}</td>
            <td>{{item.Sort}}</td>
            <td>{{item.ModifyTime|dateFormats}}</td>
            <td>
              <ad-button type="danger" size="sm" @click.native="btnDeleteHandller(item);">删除</ad-button>
              <ad-button type="primary" size="sm" @click.native="btnEditHandller(item);">编辑</ad-button>
            </td>
          </tr>
        </tbody>
      </ad-table>

      <ad-pagination
        style="padding:0 24px !important;"
        :total="TotalItems"
        :pageIndex="request.PageIndex"
        @currentChange="getList"
      ></ad-pagination>
    </div>
  </ad-left-main>
</template>

<script>
import adDictionaryService from "../../_api/adDictionary.service";
import adDictionaryTypeService from "../../_api/adDictionaryType.service";
export default {
  name: "AdDictionaryComponent",
  data() {
    return {
      headers: ["编号", "编码", "键", "值", "排序", "最后更新时间", "操作"],
      list: [],
      typeList: [],
      request: {
        DicKey: "",
        DicCoding: "",
        DicType: 0,
        PageIndex: 1,
        PageSize: 10,
        OrderBy: "Sort",
        IsDesc: false
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

    let type = 0;
    if (this.$route.params.DicType !== undefined) {
      type = this.$route.params.DicType;
    }

    this.getDictionaryList(1, type);
  },
  methods: {
    async getDictionaryList(PageIndex = 1, type = 0) {
      this.typeList = [];
      this.list = [];

      try {
        // 获取数据词典分类
        let tres = await adDictionaryTypeService.getDictionaryTypeList();

        if (tres.Data !== null && tres.Data.length !== 0) {
          this.typeList = tres.Data;
        }

        // 获取数据词典
        this.request.PageIndex = PageIndex;

        this.request.DicType = type === 0 ? this.typeList[0].Id : type;

        let res = await adDictionaryService.getDictionaryPageList(this.request);

        if (res.Data !== null && res.Data.Items.length !== 0) {
          this.list = res.Data.Items;
          this.TotalItems = res.Data.TotalItems;
          this.request.PageIndex = res.Data.CurrentPage;
        }

        this.loading.close();
      } catch (error) {
        this.loading.close();
      }
    },
    btnEditHandller(item = {}) {
      if (item.Id === undefined) {
        item.DicType = this.request.DicType;
      }

      this.$router.push({ name: "adDictionaryEdit", params: item });
    },
    btnDeleteHandller(item) {
      let options = {};
      options.title = "确认提示";
      options.message = "确认要删除吗？";

      options.params = {};
      options.params.Id = item.Id;

      options.save = (params, close) => {
        console.log(params);
        adDictionaryService.updateDictionaryIsDelById(params).then(response => {
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
