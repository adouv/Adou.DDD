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
    /// 分页获取用户列表
    /// </summary>
    public class GetWebUserPageListService : ApiBase<RequestGetWebUserListModel>
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

            var result = webUserRep.GetWebUserPageList(this.Parameter.OrderBy, this.Parameter.IsDesc, this.Parameter.PageIndex, this.Parameter.PageSize, model);

            this.Result.Data = result;
        }
    }
}
