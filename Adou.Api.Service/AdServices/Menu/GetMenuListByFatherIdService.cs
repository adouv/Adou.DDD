using Adou.Api.Model;
using Adou.Entity.PetaPocoModels.AdouModel;
using Adou.Repositories.PetaPoco.Adou;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adou.Api.Service.AdServices.Menu
{
    /// <summary>
    /// 通过父级编号获取菜单列表
    /// </summary>
    public class GetMenuListByFatherIdService : ApiBase<RequestGetMenuListModel>
    {
        public MenuRep menuRep { get; set; }

        /// <summary>
        /// 业务逻辑
        /// </summary>
        protected override void ExecuteMethod()
        {
            var result = menuRep.GetMenuListByFatherId(this.Parameter.FatherId, this.Parameter.OrderBy, this.Parameter.IsDesc);
            this.Result.Data = result;
        }
    }
}
