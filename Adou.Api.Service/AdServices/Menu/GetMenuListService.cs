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
    /// 获取菜单列表
    /// </summary>
    public class GetMenuListService : ApiBase<RequestGetMenuListModel>
    {
        public MenuRep menuRep { get; set; }

        /// <summary>
        /// 业务逻辑
        /// </summary>
        protected override void ExecuteMethod()
        {
            var model = new adMenu()
            {
                Title = this.Parameter.Title,
                FatherId = this.Parameter.FatherId
            };
            var result = menuRep.GetMenuList(this.Parameter.OrderBy, this.Parameter.IsDesc, model);
            this.Result.Data = result;
        }
    }
}
