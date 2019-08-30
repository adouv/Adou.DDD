<template>
  <ad-main title="产品管理" class="ad-product">
    <div class="row row-lg">
      <!-- <div class="col-sm-6 col-md-4">
        <div class="example-wrap">
          <h4 class="example-title">用户名</h4>
          <el-input
            size="small"
            v-model="request.UserName"
            style="width:100%;"
            placeholder="请输入用户名"
          ></el-input>
        </div>
      </div>-->

      <div class="col-sm-12 col-md-12">
        <ad-button type="inverse" @click.native="getList();">搜索</ad-button>
        <ad-button
          type="primary"
          @click.native="$router.push({ name: 'adProductEdit', params: {} })"
        >添加</ad-button>
      </div>
    </div>

    <ad-table :headers="headers" :list="list">
      <tbody>
        <tr v-for="item in list" :key="item.Id">
          <td>{{item.Id}}</td>
          <td>{{item.Name}}</td>
          <td>{{item.ProductTypeId}}</td>
          <td>{{item.VarietyId}}</td>
          <td>{{item.Specification}}</td>
          <td>{{item.FewHolesId}}</td>
          <td>{{item.ZincLayerId}}</td>
          <td>{{item.ColorId}}</td>
          <td>{{item.Quantity}}</td>
          <td>{{item.CompanyName}}</td>
          <td>{{item.Sort}}</td>
          <td>
            <ad-button type="danger" size="sm" @click.native="btnDeleteHandller(item);">删除</ad-button>
            <ad-button
              type="primary"
              size="sm"
              @click.native="$router.push({ name: 'adProductEdit', params: item })"
            >编辑</ad-button>
          </td>
        </tr>
      </tbody>
    </ad-table>

    <ad-pagination :total="TotalItems" :pageIndex="request.PageIndex" @currentChange="getList"></ad-pagination>
  </ad-main>
</template>

<script>
import adWebProductService from "../../../_api/adWebProduct.service";
export default {
  name: "AdWebProductComponent",
  data() {
    return {
      headers: [
        "编号",
        "产品名称",
        "产品分类",
        "品种",
        "规格",
        "几孔",
        "锌层",
        "颜色",
        "数量",
        "公司名称",
        "排序",
        "操作"
      ],
      list: [],
      request: {
        Name: "",
        ProductTypeId: 0,
        VarietyId: 0,
        Specification: "",
        FewHolesId: 0,
        ZincLayerId: 0,
        ColorId: 0,
        Quantity: "",
        CompanyName: "",
        UserId: 0,
        UserName: "",
        IsHot: 0,
        CreateTime: "",
        PageIndex: 1,
        PageSize: 10,
        OrderBy: "CreateTime",
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

    this.getList();
  },
  methods: {
    async getList(PageIndex = 1) {
      this.list = [];

      this.request.PageIndex = PageIndex;

      try {
        let res = await adWebProductService.getWebProductPageList(this.request);

        if (res.Data !== null && res.Data.Items.length !== 0) {
          this.TotalItems = res.Data.TotalItems;
          this.request.PageIndex = res.Data.CurrentPage;
          this.list = res.Data.Items;
        }
        this.loading.close();
      } catch (error) {
        this.loading.close();
      }
    },
    btnDeleteHandller(item) {
      let options = {};
      options.title = "确认提示";
      options.message = "确认要删除吗？";

      options.params = {};
      options.params.Id = item.Id;

      options.save = (params, close) => {
        console.log(params);

        adUserService.updateUserIsDelById(params).then(response => {
          if (response.Data > 0) {
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
