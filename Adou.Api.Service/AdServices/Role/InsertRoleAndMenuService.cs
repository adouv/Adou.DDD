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
    /// 添加角色，同时添加所拥有的菜单权限
    /// </summary>
    public class InsertRoleAndMenuService : ApiBase<RequestInsertRoleAndMenuModel>
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
                CreateUser = AdouConfigHelper.UserName,
                ModifyTime = DateTime.Now,
                ModifyUser = AdouConfigHelper.UserName,
                IsDel = false,
                Sort = this.Parameter.Sort
            };

            var result = roleRep.InsertRoleAndMenu(model, this.Parameter.menuArr);

            this.Result.Data = result;
        }
    }
}
