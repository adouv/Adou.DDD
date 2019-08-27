using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adou.Api.Model;
using Adou.Repositories.PetaPoco.Adou;
using Adou.Entity.PetaPocoModels.AdouModel;
using Adou.DDD.Config;

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
                Title = this.Parameter.Title,
                Account = this.Parameter.Account,
                Password = this.Parameter.Password,
                Url = this.Parameter.Url,
                Email = this.Parameter.Email,
                Mobile = this.Parameter.Mobile,
                Keyword = this.Parameter.Keyword,
                Descript = this.Parameter.Descript,
                CreateUser = AdouConfigHelper.UserName,
                CreateTime = DateTime.Now,
                ModifyUser = AdouConfigHelper.UserName,
                ModifyTime = DateTime.Now,
                IsDel = false,
                Sort = 100,
                Type = this.Parameter.Type
            };

            long result = accountRep.InsertAccount(model);

            this.Result.Data = result;
        }
    }
}
