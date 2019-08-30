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
    /// 更新用户
    /// </summary>
    public class UpdateWebUserByIdService : ApiBase<RequestUpdateWebUserByIdModel>
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
                UserName = this.Parameter.UserName,
                UserPwd = this.Parameter.UserPwd,
                RealName = this.Parameter.RealName,
                IDCard = this.Parameter.IDCard,
                CompanyName = this.Parameter.CompanyName,
                Mobile = this.Parameter.Mobile,
                Tel = this.Parameter.Tel,
                Address = this.Parameter.Address,
                ModifyTime = DateTime.Now,
                ModifyUser = AdouConfigHelper.UserName,
                IsValid = this.Parameter.IsValids,
                IsVip = this.Parameter.IsVip
            };

            var result = webUserRep.UpdateWebUserById(model);

            this.Result.Data = result;
        }
    }
}
