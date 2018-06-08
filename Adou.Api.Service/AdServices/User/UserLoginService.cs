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
    public class UserLoginService: ApiBase<RequestUserLoginModel>
    {
        #region 注入服务
        public UserRep userRep { get; set; }
        #endregion

        /// <summary>
        /// 数据验证
        /// </summary>
        protected override void Validate()
        {
            base.Validate();
        }
        /// <summary>
        /// 业务逻辑
        /// </summary>
        protected override void ExecuteMethod()
        {
            var result = userRep.UserLoginByUserNameAndUserPwd(
                this.Parameter.UserName,
                this.Parameter.UserPwd);
            this.Result.Data = result;
        }
    }
}
