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
    public class UpdateMenuByIdService : ApiBase<RequestUpdateMenuByIdModel>
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
                Title = this.Parameter.Title,
                MenuIcon = this.Parameter.MenuIcon,
                MenuUrl = this.Parameter.MenuUrl,
                FatherId = this.Parameter.FatherId,
                LevelId = this.Parameter.LevelId,
                ModifyUser = AdouConfigHelper.UserName,
                ModifyTime = DateTime.Now,
                IsDel = false,
                Sort = this.Parameter.Sort
            };

            var result = menuRep.UpdateMenuById(model);

            this.Result.Data = result;
        }
    }
}
