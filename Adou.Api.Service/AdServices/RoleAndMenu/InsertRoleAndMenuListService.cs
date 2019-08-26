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
    /// 批量添加角色菜单
    /// </summary>
    public class InsertRoleAndMenuListService : ApiBase<RequestInsertRoleAndMenuListModel>
    {
        public RoleAndMenuRep roleAndMenuRep { get; set; }
        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        protected override void ExecuteMethod()
        {
            var result = roleAndMenuRep.InsertRoleAndMenuList(this.Parameter.RoleId, this.Parameter.MenuArr);

            this.Result.Data = result;
        }
    }
}
