using Adou.Api.Model;
using Adou.Entity.PetaPocoModels.AdouModel;
using Adou.Repositories.PetaPoco.Adou;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adou.Api.Service.AdServices.Account
{
    /// <summary>
    /// 用户账号信息列表
    /// </summary>
    public class GetAccountListService : ApiBase<RequestAccountListModel>
    {
        public AccountRep accountRep { get; set; }
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
            var result = accountRep.GetAccountList(
                this.Parameter.PageIndex, 
                this.Parameter.PageSize);
            this.Result.Data = result;
        }
    }
}
