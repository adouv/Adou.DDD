using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adou.Api.Model;
using Adou.Repositories.PetaPoco.Adou;

namespace Adou.Api.Service.AdServices.UserAndRole
{
    /// <summary>
    /// 通过用户编号，删除用户角色权限服务
    /// </summary>
    public class DeleteUserAndRoleByUserIdService : ApiBase<RequestDeleteUserAndRoleByUserIdModel>
    {
        public UserAndRoleRep userAndRoleRep { get; set; }
        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        protected override void ExecuteMethod()
        {
            var result = userAndRoleRep.DeleteUserAndRoleByUserId(this.Parameter.UserId);

            this.Result.Data = result;
        }
    }
}
