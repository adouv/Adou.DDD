<template>
  <ad-main :title="`产品管理 / ${params.Id===0?'添加':'编辑'}产品`" :back="true" class="ad-product-edit">
    <div class="row row-lg">
      <div class="col-sm-12 col-md-12">
        <div class="example-wrap">
          <h4 class="example-title">
            <span style="color:#f00;padding-right:5px;">*</span>所属栏目
          </h4>
          <select class="form-control" v-model="params.ProductCategoryId">
            <option :value="0">请选择</option>
            <option
              v-for="(item,index) in DictionaryAllList[0]"
              :key="index"
              :value="item.Id"
            >{{item.DicKey}}</option>
          </select>
        </div>
      </div>

      <div class="col-sm-12 col-md-12">
        <div class="example-wrap">
          <h4 class="example-title">
            <span style="color:#f00;padding-right:5px;">*</span>用户
          </h4>
          <el-input
            size="small"
            v-model="params.UserName"
            style="width:100%;"
            placeholder="请填写用户名/真实姓名/公司名称进行检索"
          ></el-input>
        </div>
      </div>

      <div class="col-sm-12 col-md-12">
        <div class="example-wrap">
          <h4 class="example-title">
            <span style="color:#f00;padding-right:5px;">*</span>产品分类
          </h4>
          <select class="form-control" v-model="params.ProductTypeId">
            <option :value="0">请选择</option>
            <option
              v-for="(item,index) in DictionaryAllList[1]"
              :key="index"
              :value="item.Id"
            >{{item.DicKey}}</option>
          </select>
        </div>
      </div>

      <div class="col-sm-12 col-md-12">
        <div class="example-wrap">
          <h4 class="example-title">
            <span style="color:#f00;padding-right:5px;">*</span>品种
          </h4>
          <select class="form-control" v-model="params.VarietyId">
            <option :value="0">请选择</option>
            <option
              v-for="(item,index) in DictionaryAllList[2]"
              :key="index"
              :value="item.Id"
            >{{item.DicKey}}</option>
          </select>
        </div>
      </div>

      <div class="col-sm-12 col-md-12">
        <div class="example-wrap">
          <h4 class="example-title">
            <span style="color:#f00;padding-right:5px;">*</span>规格
          </h4>
          <el-input
            size="small"
            v-model="params.Specification"
            style="width:100%;"
            placeholder="请填写规格"
          ></el-input>
        </div>
      </div>

      <div class="col-sm-12 col-md-12">
        <div class="example-wrap">
          <h4 class="example-title">
            <span style="color:#f00;padding-right:5px;">*</span>几孔
          </h4>
          <select class="form-control" v-model="params.FewHolesId">
            <option :value="0">请选择</option>
            <option
              v-for="(item,index) in DictionaryAllList[3]"
              :key="index"
              :value="item.Id"
            >{{item.DicKey}}</option>
          </select>
        </div>
      </div>

      <div class="col-sm-12 col-md-12">
        <div class="example-wrap">
          <h4 class="example-title">
            <span style="color:#f00;padding-right:5px;">*</span>锌层
          </h4>
          <select class="form-control" v-model="params.ZincLayerId">
            <option :value="0">请选择</option>
            <option
              v-for="(item,index) in DictionaryAllList[4]"
              :key="index"
              :value="item.Id"
            >{{item.DicKey}}</option>
          </select>
        </div>
      </div>

      <div class="col-sm-12 col-md-12">
        <div class="example-wrap">
          <h4 class="example-title">
            <span style="color:#f00;padding-right:5px;">*</span>颜色
          </h4>
          <select class="form-control" v-model="params.ColorId">
            <option :value="0">请选择</option>
            <option
              v-for="(item,index) in DictionaryAllList[5]"
              :key="index"
              :value="item.Id"
            >{{item.DicKey}}</option>
          </select>
        </div>
      </div>

      <div class="col-sm-12 col-md-12">
        <div class="example-wrap">
          <h4 class="example-title">
            <span style="color:#f00;padding-right:5px;">*</span>数量
          </h4>
          <el-input
            type="number"
            size="small"
            v-model="params.Quantity"
            style="width:100%;"
            placeholder="请填写数量"
          ></el-input>
        </div>
      </div>

      <div class="col-sm-12 col-md-12">
        <ad-button type="secondary" @click.native="$router.push({ name: 'adProduct' })">返回</ad-button>
        <ad-button type="primary" @click.native="btnSave()">保存</ad-button>
      </div>
    </div>
  </ad-main>
</template>

<script>
import adWebProductService from "../../../_api/adWebProduct.service";
import adDictionaryService from "../../../_api/adDictionary.service";
export default {
  name: "AdWebProductEditComponent",
  data() {
    return {
      params: {
        Id: 0,
        Name: "",
        ProductCategoryId: 0,
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
        Sort: 100
      },
      DictionaryAllList: [],
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

    let params = this.$route.params;

    if (params.Id !== undefined) {
      this.params = params;
    }

    this.getDictionaryListByDicType();
  },
  methods: {
    /**
     * 产品栏目、产品分类、产品品种、产品几孔、产品锌层、产品颜色
     */
    async getDictionaryListByDicType() {
      let _dicTypeList = [22, 6, 7, 8, 9, 10];

      let _promiseList = [];

      _dicTypeList.forEach(k => {
        let args = {};
        args.DicType = k;
        _promiseList.push(adDictionaryService.getDictionaryList(args));
      });

      if (_promiseList.length > 0) {
        let result = await this.http$.all(_promiseList);

        result.forEach(response => {
          this.DictionaryAllList.push(response.Data);
        });
      }

      this.loading.close();
    },
    getRoleList() {
      let params = {};

      adRoleService
        .getRoleList(params)
        .then(response => {
          if (response.Data) {
            this.roleList = response.Data;
          }

          if (this.roleList.length > 0 && this.params.Id > 0) {
            this.params.RoleList.forEach(element => {
              this.roleIds.push(element.Id);
            });
          }

          this.loading.close();
        })
        .catch(err => {
          this.loading.close();
        });
    },
    async btnSave() {
      if (!this.params.UserName) {
        this.$tip("请填写用户名");
        return;
      }

      if (this.params.Id === 0) {
        if (!this.params.UserPwd) {
          this.$tip("请填写密码");
          return;
        }

        if (!this.params.ReUserPwd) {
          this.$tip("请填写确认密码");
          return;
        }

        if (this.params.UserPwd !== this.params.ReUserPwd) {
          this.$tip("两次输入密码不一致");
          return;
        }
      } else {
        if (this.params.UserPwd || this.params.ReUserPwd) {
          if (this.params.UserPwd !== this.params.ReUserPwd) {
            this.$tip("两次输入密码不一致");
            return;
          }
        }
      }

      if (!this.params.Sort) {
        this.$tip("请填写排序值");
        return;
      }

      if (this.params.UserType === 0) {
        if (this.roleIds.length === 0) {
          this.$tip("请选择角色");
          return;
        }
      }

      this.params.RoleArr = this.roleIds;

      console.log(this.params);

      let result = null;

      try {
        if (this.params.Id === 0) {
          result = adUserService.insertUserAndRole(this.params);
        } else {
          result = adUserService.updateUserAndRoleById(this.params);
        }

        let response = await result;

        if (response.Data > 0 && response.Data !== null) {
          this.$tip("保存成功");
        }

        this.$router.push({ name: "adProduct" });
      } catch (error) {
        this.$tip("保存失败");
      }
    }
  }
};
</script>
