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
    /// 更新账户服务
    /// </summary>
    public class UpdateAccountByIdService : ApiBase<RequestUpdateAccountByIdModel>
    {
        public AccountRep accountRep { get; set; }
        /// <summary>
        /// 业务逻辑
        /// </summary>
        protected override void ExecuteMethod()
        {
            var model = new adAccount()
            {
                Id = this.Parameter.Id,
                Title = this.Parameter.Title,
                Account = this.Parameter.Account,
                Password = this.Parameter.Password,
                Url = this.Parameter.Url,
                Email = this.Parameter.Email,
                Mobile = this.Parameter.Mobile,
                Keyword = this.Parameter.Keyword,
                Descript = this.Parameter.Descript,
                ModifyUser = 0,
                ModifyTime = DateTime.Now,
                IsDel = true,
                Sort = 100
            };

            long result = accountRep.UpdateAccountById(model);

            this.Result.Data = result;
        }
    }
}
