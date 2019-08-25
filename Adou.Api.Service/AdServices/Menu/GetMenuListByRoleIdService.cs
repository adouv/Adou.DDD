using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adou.Api.Model;
using Adou.Repositories.PetaPoco.Adou;
using Adou.Entity.PetaPocoModels.AdouModel;

namespace Adou.Api.Service.AdServices.Menu
{
    public class GetMenuListByRoleIdService : ApiBase<RequestGetMenuListByRoleIdModel>
    {
        public MenuRep menuRep { get; set; }
        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        protected override void ExecuteMethod()
        {
            var result = menuRep.GetMenuListByRoleId(this.Parameter.RoleId);

            this.Result.Data = result;
        }
    }
}
