using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adou.Api.Model;
using Adou.DDD.Config;
using Adou.Repositories.PetaPoco.Adou;
using Adou.Entity.PetaPocoModels.AdouModel;

namespace Adou.Api.Service.AdServices.WenUser
{
    /// <summary>
    /// 通过编号删除用户
    /// </summary>
    public class DeleteWebUserByIdService : ApiBase<RequestDeleteWebUserByIdModel>
    {
        public WebUserRep webUserRep { get; set; }
        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        protected override void ExecuteMethod()
        {
            var result = webUserRep.DeleteWebUserById(this.Parameter.Id);

            this.Result.Data = result;
        }
    }
}
