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
    /// 删除产品
    /// </summary>
    public class DeleteWebProductByIdService : ApiBase<RequestDeleteWebProductByIdModel>
    {
        public WebProductRep webProductRep { get; set; }
        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        protected override void ExecuteMethod()
        {
            var result = webProductRep.DeleteWebProductById(this.Parameter.Id);

            this.Result.Data = result;
        }
    }
}
