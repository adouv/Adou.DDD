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
    /// 添加角色服务
    /// </summary>
    public class InsertRoleService : ApiBase<RequestInsertRoleModel>
    {
        public RoleRep roleRep { get; set; }
        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        protected override void ExecuteMethod()
        {
            var model = new adRole()
            {
                RoleName = this.Parameter.RoleName,
                CreateTime = DateTime.Now,
                CreateUser = "fukaihang",
                ModifyTime = DateTime.Now,
                ModifyUser = "fukaihang",
                IsDel = this.Parameter.IsDel,
                Sort = this.Parameter.Sort
            };

            var result = roleRep.InsertRole(model);

            this.Result.Data = result;
        }
    }
}
