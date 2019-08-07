using Adou.Api.Model;
using Adou.Repositories.PetaPoco.Adou;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adou.Api.Service.AdServices.Menu
{
    /// <summary>
    /// 获取菜单列表
    /// </summary>
    public class GetMenuListService : ApiBase<RequestMenuModel>
    {
        public MenuRep menuRep { get; set; }

        /// <summary>
        /// 业务逻辑
        /// </summary>
        protected override void ExecuteMethod()
        {
            var result = menuRep.GetMenuList();
            this.Result.Data = result;
        }
    }
}
