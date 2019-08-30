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
    /// 获取用户列表
    /// </summary>
    public class GetWebUserListService : ApiBase<RequestGetWebUserListModel>
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
                RealName = this.Parameter.RealName,
                IDCard = this.Parameter.IDCard,
                CompanyName = this.Parameter.CompanyName,
                Mobile = this.Parameter.Mobile,
                Tel = this.Parameter.Tel,
                Address = this.Parameter.Address,
                IsValid = this.Parameter.IsValids,
                IsVip = this.Parameter.IsVip
            };

            var result = webUserRep.GetWebUserList(this.Parameter.OrderBy, this.Parameter.IsDesc, model);

            this.Result.Data = result;
        }
    }
}
