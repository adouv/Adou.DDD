using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adou.Api.Model;
using Adou.Repositories.PetaPoco.Adou;

namespace Adou.Api.Service.AdServices.Menu
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateMenuIsDelByIdService : ApiBase<RequestUpdateMenuIsDelByIdModel>
    {
        public MenuRep menuRep { get; set; }
        /// <summary>
        /// 执行具体业务逻辑
        /// </summary>
        protected override void ExecuteMethod()
        {
            var result = menuRep.UpdateMenuIsDelById(this.Parameter.IsDel, this.Parameter.Id);
            this.Result.Data = result;
        }
    }
}
