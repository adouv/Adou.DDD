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
    /// 伪删除
    /// </summary>
    public class UpdateWebProductIsDelByIdService : ApiBase<RequestUpdateWebProductIsDelByIdModel>
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
                IsDel = true,
                ModifyTime = DateTime.Now,
                ModifyUser = AdouConfigHelper.UserName
            };

            var result = webProductRep.UpdateWebProductIsDelById(model);

            this.Result.Data = result;
        }
    }
}
