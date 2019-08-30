using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adou.DDD.Config;
using Adou.Api.Model;
using Adou.Entity.PetaPocoModels.AdouModel;
using Adou.Repositories.PetaPoco.Adou;

namespace Adou.Api.Service.AdServices.WebProduct
{
    /// <summary>
    /// 获取产品列表
    /// </summary>
    public class GetWebProductListService : ApiBase<RequestGetWebProductListModel>
    {
        public WebProductRep webProductRep { get; set; }
        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        protected override void ExecuteMethod()
        {
            var model = new adWebProduct()
            {
                Name = this.Parameter.Name,
                ProductTypeId = this.Parameter.ProductTypeId,
                VarietyId = this.Parameter.VarietyId,
                Specification = this.Parameter.Specification,
                FewHolesId = this.Parameter.FewHolesId,
                ZincLayerId = this.Parameter.ZincLayerId,
                ColorId = this.Parameter.ColorId,
                Quantity = this.Parameter.Quantity,
                CompanyName = this.Parameter.CompanyName,
                UserId = this.Parameter.UserId,
                UserName = this.Parameter.UserName,
                IsHot = this.Parameter.IsHot
            };

            var result = webProductRep.GetWebProductList(this.Parameter.OrderBy, this.Parameter.IsDesc, model);

            this.Result.Data = result;
        }
    }
}
