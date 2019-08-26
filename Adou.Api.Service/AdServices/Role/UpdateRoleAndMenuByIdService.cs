using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adou.Api.Model;
using Adou.Repositories.PetaPoco.Adou;
using Adou.Entity.PetaPocoModels.AdouModel;
using Adou.DDD.Config;

namespace Adou.Api.Service.AdServices.Role
{
    /// <summary>
    /// 通过角色编号更新角色，同时更新所拥有的菜单权限
    /// </summary>
    public class UpdateRoleAndMenuByIdService : ApiBase<RequestUpdateRoleAndMenuByIdModel>
    {
        public RoleRep roleRep { get; set; }
        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        protected override void ExecuteMethod()
        {
            var model = new adRole()
            {
                Id = this.Parameter.Id,
                RoleName = this.Parameter.RoleName,
                ModifyTime = DateTime.Now,
                ModifyUser = AdouConfigHelper.UserName,
                IsDel = this.Parameter.IsDel,
                Sort = this.Parameter.Sort
            };

            var result = roleRep.UpdateRoleAndMenuById(model, this.Parameter.MenuArr);

            this.Result.Data = result;
        }
    }
}
