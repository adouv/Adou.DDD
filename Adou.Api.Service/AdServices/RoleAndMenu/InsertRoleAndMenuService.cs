using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adou.Api.Model;
using Adou.Entity.PetaPocoModels.AdouModel;
using Adou.Repositories.PetaPoco.Adou;

namespace Adou.Api.Service.AdServices.RoleAndMenu
{
    /// <summary>
    /// 添加角色菜单服务
    /// </summary>
    public class InsertRoleAndMenuService : ApiBase<RequestInsertRoleAndMenuModel>
    {
        public RoleAndMenuRep roleAndMenuRep { get; set; }
        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        protected override void ExecuteMethod()
        {
            var model = new adRoleAndMenu() {
                RoleId=this.Parameter.RoleId,
                MenuId=this.Parameter.MenuId
            };

            var result = roleAndMenuRep.InsertRoleAndMenu(model);

            this.Result.Data = result;
        }
    }
}
