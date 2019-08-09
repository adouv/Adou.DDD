using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adou.Api.Model;
using Adou.Repositories.PetaPoco.Adou;
using Adou.Entity.PetaPocoModels.AdouModel;

namespace Adou.Api.Service.AdServices.Account
{
    public class InsertAccountService : ApiBase<RequestInsertAccountModel>
    {
        public AccountRep accountRep { get; set; }
        /// <summary>
        /// 
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
                CreateUser = 0,
                CreateTime = DateTime.Now,
                ModifyUser = 0,
                ModifyTime = DateTime.Now,
                IsDel = true,
                Sort = 100
            };

            long result = accountRep.InsertAccount(model);

            this.Result.Data = result;
        }
    }
}
