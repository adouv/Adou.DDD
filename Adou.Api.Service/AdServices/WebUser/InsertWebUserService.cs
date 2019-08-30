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
    /// 添加用户
    /// </summary>
    public class InsertWebUserService : ApiBase<RequestInsertWebUserModel>
    {
        public WebUserRep webUserRep { get; set; }
        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        protected override void ExecuteMethod()
        {
            var model = new adWebUser()
            {
                UserName = this.Parameter.UserName,
                UserPwd = this.Parameter.UserPwd,
                RealName = this.Parameter.RealName,
                IDCard = this.Parameter.IDCard,
                CompanyName = this.Parameter.CompanyName,
                Mobile = this.Parameter.Mobile,
                Tel = this.Parameter.Tel,
                Address = this.Parameter.Address,
                CreateTime = DateTime.Now,
                CreateUser = AdouConfigHelper.UserName,
                ModifyTime = DateTime.Now,
                ModifyUser = AdouConfigHelper.UserName,
                IsDel = false,
                IsValid = this.Parameter.IsValids,
                IsVip = this.Parameter.IsVip
            };

            var result = webUserRep.InsertWebUser(model);

            this.Result.Data = result;
        }
    }
}
