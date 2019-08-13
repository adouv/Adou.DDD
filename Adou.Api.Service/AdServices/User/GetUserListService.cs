using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adou.Api.Model;
using Adou.Repositories.PetaPoco.Adou;
using Adou.Entity.PetaPocoModels.AdouModel;

namespace Adou.Api.Service.AdServices.User
{
    /// <summary>
    /// 
    /// </summary>
    public class GetUserListService : ApiBase<RequestGetUserListModel>
    {
        public UserRep userRep { get; set; }
        /// <summary>
        /// 执行具体业务逻辑
        /// </summary>
        protected override void ExecuteMethod()
        {
            var model = new adUser()
            {
                UserName = this.Parameter.UserName,
                UserType = this.Parameter.UserType,
                UserStatus = this.Parameter.UserStatus
            };

            var result = userRep.GetUserList(this.Parameter.OrderBy, this.Parameter.IsDesc, model);

            this.Result.Data = result;
        }
    }
}
