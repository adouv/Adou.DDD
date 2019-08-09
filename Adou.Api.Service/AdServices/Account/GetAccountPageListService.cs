using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adou.Api.Model;
using Adou.Entity.PetaPocoModels.AdouModel;
using Adou.Repositories.PetaPoco.Adou;

namespace Adou.Api.Service.AdServices.Account
{
    /// <summary>
    /// 分页获取账户列表
    /// </summary>
    public class GetAccountPageListService : ApiBase<RequestGetAccountListModel>
    {
        public AccountRep accountRep { get; set; }
        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        protected override void ExecuteMethod()
        {
            var model = new adAccount()
            {
                Title = this.Parameter.Title
            };

            var result = accountRep.GetAccountPageList(this.Parameter.PageIndex, this.Parameter.PageSize, this.Parameter.OrderBy, this.Parameter.IsDesc, model);

            this.Result.Data = result;
        }
    }
}
