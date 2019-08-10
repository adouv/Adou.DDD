using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adou.Api.Model;
using Adou.Repositories.PetaPoco.Adou;

namespace Adou.Api.Service.AdServices.Account
{
    public class UpdateAccountIsDelByIdService : ApiBase<RequestUpdateAccountIsDelByIdModel>
    {
        public AccountRep accountRep { get; set; }
        /// <summary>
        /// 执行具体业务逻辑
        /// </summary>
        protected override void ExecuteMethod()
        {
            var result = accountRep.UpdateAccountIsDelById(this.Parameter.IsDel, Convert.ToInt32(this.Parameter.Id));
            this.Result.Data = result;

        }
    }
}
