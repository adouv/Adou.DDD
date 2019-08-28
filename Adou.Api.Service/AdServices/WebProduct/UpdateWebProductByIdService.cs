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
    /// 修改产品
    /// </summary>
    public class UpdateWebProductByIdService : ApiBase<RequestUpdateWebProductByIdModel>
    {
        public WebProductRep webProductRep { get; set; }
        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        protected override void ExecuteMethod()
        {
            var model = new adWebProduct()
            {
                Id = this.Parameter.Id,
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
                IsHot = this.Parameter.IsHot,
                Sort = this.Parameter.Sort,
                ModifyTime = DateTime.Now,
                ModifyUser = AdouConfigHelper.UserName
            };

            var result = webProductRep.UpdateWebProductById(model);

            this.Result.Data = result;
        }
    }
}
