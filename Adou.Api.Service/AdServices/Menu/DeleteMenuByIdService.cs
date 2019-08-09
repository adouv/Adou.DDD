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
    /// 删除菜单服务
    /// </summary>
    public class DeleteMenuByIdService : ApiBase<RequestDeleteMenuByIdModel>
    {
        public MenuRep menuRep { get; set; }
        /// <summary>
        /// 执行具体业务逻辑
        /// </summary>
        protected override void ExecuteMethod()
        {
            var result = menuRep.DeleteMenuById(this.Parameter.Id);
            this.Result.Data = result;
        }
    }
}
