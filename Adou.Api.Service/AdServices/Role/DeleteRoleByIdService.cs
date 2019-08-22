using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adou.Api.Model;
using Adou.Repositories.PetaPoco.Adou;
using Adou.Entity.PetaPocoModels.AdouModel;

namespace Adou.Api.Service.AdServices.Role
{
    /// <summary>
    /// 删除角色服务
    /// </summary>
    public class DeleteRoleByIdService : ApiBase<RequestDeleteRoleByIdModel>
    {
        public RoleRep roleRep { get; set; }
        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        protected override void ExecuteMethod()
        {
            var result = roleRep.DeleteRoleById(this.Parameter.Id);

            this.Result.Data = result;
        }
    }
}
