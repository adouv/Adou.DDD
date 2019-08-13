using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adou.Api.Model;
using Adou.Repositories.PetaPoco.Adou;

namespace Adou.Api.Service.AdServices.User
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteUserByIdService : ApiBase<RequestDeleteUserByIdModel>
    {
        public UserRep userRep { get; set; }
        /// <summary>
        /// 执行具体业务逻辑
        /// </summary>
        protected override void ExecuteMethod()
        {
            var result = userRep.DeleteUserById(this.Parameter.Id);

            this.Result.Data = result;
        }
    }
}
