using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adou.Api.Model;
using Adou.Repositories.PetaPoco.Adou;
using Adou.Entity.PetaPocoModels.AdouModel;
using Adou.DDD.Config;

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
            var model = new adMenu()
            {
                Id = this.Parameter.Id,
                IsDel = this.Parameter.IsDel,
                ModifyTime = DateTime.Now,
                ModifyUser = AdouConfigHelper.UserName
            };

            var result = menuRep.UpdateMenuIsDelById(model);

            this.Result.Data = result;
        }
    }
}
