using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adou.Api.Model;
using Adou.DDD.Config;
using Adou.Repositories.PetaPoco.Adou;
using Adou.Entity.PetaPocoModels.AdouModel;

namespace Adou.Api.Service.AdServices.WebUser
{
    /// <summary>
    /// 伪删除
    /// </summary>
    public class UpdateWebUserIsDelByIdService : ApiBase<RequestUpdateWebUserIsDelByIdModel>
    {
        public WebUserRep webUserRep { get; set; }
        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        protected override void ExecuteMethod()
        {
            var model = new adWebUser()
            {
                Id = this.Parameter.Id,
                IsDel = true,
                ModifyTime = DateTime.Now,
                ModifyUser = AdouConfigHelper.UserName
            };

            var result = webUserRep.UpdateWebUserIsDelById(model);

            this.Result.Data = result;
        }
    }
}
