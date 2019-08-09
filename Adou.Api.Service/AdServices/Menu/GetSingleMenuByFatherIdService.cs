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
    /// <summary>
    /// 获取单个菜单信息服务
    /// </summary>
    public class GetSingleMenuByFatherIdService:ApiBase<RequestMenuModel>
    {
        public MenuRep menuRep { get; set; }
        /// <summary>
        /// 执行具体业务逻辑
        /// </summary>
        protected override void ExecuteMethod()
        {
            var result = menuRep.GetSingleMenuByFatherId(this.Parameter.FatherId);
            this.Result.Data = result;
        }
    }
}
