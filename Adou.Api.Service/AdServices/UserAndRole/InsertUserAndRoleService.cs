using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adou.Api.Model;
using Adou.Repositories.PetaPoco.Adou;
using Adou.Entity.PetaPocoModels.AdouModel;

namespace Adou.Api.Service.AdServices.UserAndRole
{
    /// <summary>
    /// 添加用户、角色权限服务
    /// </summary>
    public class InsertUserAndRoleService : ApiBase<RequestInsertUserAndRoleModel>
    {
        public UserAndRoleRep userAndRoleRep { get; set; }
        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        protected override void ExecuteMethod()
        {
            var model = new adUserAndRole()
            {
                UserId = this.Parameter.UserId,
                RoleId = this.Parameter.RoleId
            };

            var result = userAndRoleRep.InsertUserAndRole(model);

            this.Result.Data = result;
        }
    }
}
