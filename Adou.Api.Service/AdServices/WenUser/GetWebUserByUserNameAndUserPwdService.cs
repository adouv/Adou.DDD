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
    /// 通过用户名和密码进行用户登录
    /// </summary>
    public class GetWebUserByUserNameAndUserPwdService : ApiBase<RequestGetWebUserByUserNameAndUserPwdModel>
    {
        public WebUserRep webUserRep { get; set; }
        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        protected override void ExecuteMethod()
        {
            var result = webUserRep.GetWebUserByUserNameAndUserPwd(this.Parameter.UserName, this.Parameter.UserPwd);

            this.Result.Data = result;
        }
    }
}
