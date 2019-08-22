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
    /// 分页获取角色列表服务
    /// </summary>
    public class GetRolePageListService : ApiBase<RequestGetRoleListModel>
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

            var result = roleRep.GetRolePageList(this.Parameter.OrderBy, this.Parameter.IsDesc, this.Parameter.PageIndex, this.Parameter.PageSize, model);

            this.Result.Data = result;
        }
    }
}
