using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adou.Api.Model;
using Adou.Repositories.PetaPoco.Adou;

namespace Adou.Api.Service.AdServices.RoleAndMenu
{
    /// <summary>
    /// 通过角色编号删除角色菜单服务
    /// </summary>
    public class DeleteRoleAndMenuByRoleIdService : ApiBase<RequestDeleteRoleAndMenuByRoleIdModel>
    {
        public RoleAndMenuRep roleAndMenuRep { get; set; }
        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        protected override void ExecuteMethod()
        {
            var result = roleAndMenuRep.DeleteRoleAndMenuByRoleId(this.Parameter.RoleId);

            this.Result.Data = result;
        }
    }
}
