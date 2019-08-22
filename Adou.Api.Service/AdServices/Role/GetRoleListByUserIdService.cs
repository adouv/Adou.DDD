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
    /// 通过用户编号获取角色列表服务
    /// </summary>
    public class GetRoleListByUserIdService : ApiBase<RequestGetRoleListByUserIdModel>
    {
        public RoleRep roleRep { get; set; }
        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        protected override void ExecuteMethod()
        {
            var result = roleRep.GetRoleListByUserId(this.Parameter.UserId);

            this.Result.Data = result;
        }
    }
}
