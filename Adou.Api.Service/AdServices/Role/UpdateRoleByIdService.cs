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
    /// 更新角色信息服务
    /// </summary>
    public class UpdateRoleByIdService : ApiBase<RequestUpdateRoleByIdModel>
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
                ModifyUser = "fukaihang",
                IsDel = this.Parameter.IsDel,
                Sort = this.Parameter.Sort
            };

            var result = roleRep.UpdateRoleById(model, this.Parameter.MenuArr);

            this.Result.Data = result;
        }
    }
}
