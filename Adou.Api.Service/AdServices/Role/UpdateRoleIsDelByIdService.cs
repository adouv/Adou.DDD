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
    /// 更新角色删除状态服务
    /// </summary>
    public class UpdateRoleIsDelByIdService : ApiBase<RequestUpdateRoleIsDelByIdModel>
    {
        public RoleRep roleRep { get; set; }
        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        protected override void ExecuteMethod()
        {
            var result = roleRep.UpdateRoleIsDelById(this.Parameter.IsDel, this.Parameter.Id);

            this.Result.Data = result;
        }
    }
}
