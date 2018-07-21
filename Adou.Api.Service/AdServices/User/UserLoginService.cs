using Adou.Api.Model;
using Adou.Entity.PetaPocoModels.AdouModel;
using Adou.Repositories.PetaPoco.Adou;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Adou.Api.Service.AdServices.User
{
    /// <summary>
    /// 用户登录
    /// </summary>
    public class UserLoginService : ApiBase<RequestUserLoginModel>
    {
        #region 注入服务
        public UserRep userRep { get; set; }
        #endregion

        /// <summary>
        /// 业务逻辑
        /// </summary>
        protected override void ExecuteMethod()
        {
            var result = userRep.GetUser(this.Parameter.UserName, this.Parameter.UserPwd);

            if (result != null)
            {
                this.Result.Data = result;
            }
            else
            {
                throw new AggregateException("用户不存在或密码不正确！");
            }
        }
    }
}
