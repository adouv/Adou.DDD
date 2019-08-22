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
    /// 获取角色列表服务
    /// </summary>
    public class GetRoleListService : ApiBase<RequestGetRoleListModel>
    {
        public RoleRep roleRep { get; set; }
        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        protected override void ExecuteMethod()
        {
            var model = new adRole()
            {
                RoleName = this.Parameter.RoleName
            };

            var result = roleRep.GetRoleList(this.Parameter.OrderBy, this.Parameter.IsDesc, model);

            this.Result.Data = result;
        }
    }
}
