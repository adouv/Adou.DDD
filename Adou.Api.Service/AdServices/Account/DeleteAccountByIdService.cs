using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adou.Api.Model;
using Adou.Repositories.PetaPoco.Adou;

namespace Adou.Api.Service.AdServices.Account
{
    /// <summary>
    /// 通过Id删除账户服务
    /// </summary>
    public class DeleteAccountByIdService : ApiBase<RequestDeleteAccountByIdModel>
    {
        public AccountRep accountRep { get; set; }
        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        protected override void ExecuteMethod()
        {
            var result = accountRep.DeleteAccountById(this.Parameter.Id);
            this.Result.Data = result;
        }
    }
}
