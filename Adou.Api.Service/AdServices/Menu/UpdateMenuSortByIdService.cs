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
    /// 
    /// </summary>
    public class UpdateMenuSortByIdService : ApiBase<RequestUpdateMenuSortByIdModel>
    {
        public MenuRep menuRep { get; set; }
        /// <summary>
        /// 执行具体业务逻辑
        /// </summary>
        protected override void ExecuteMethod()
        {
            var result = menuRep.UpdateMenuSortById(this.Parameter.Id,this.Parameter.Sort);
            this.Result.Data = result;
        }
    }
}
