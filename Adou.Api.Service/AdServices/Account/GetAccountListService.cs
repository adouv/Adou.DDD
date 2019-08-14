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
    /// 获取账户列表服务
    /// </summary>
    public class GetAccountListService : ApiBase<RequestGetAccountListModel>
    {
        public AccountRep accountRep { get; set; }
        /// <summary>
        /// 业务逻辑
        /// </summary>
        protected override void ExecuteMethod()
        {
            var model = new adAccount()
            {
                Title = this.Parameter.Title,
                Type = this.Parameter.Type
            };

            var result = accountRep.GetAccountList(this.Parameter.OrderBy, this.Parameter.IsDesc, model);

            this.Result.Data = result;
        }
    }
}
