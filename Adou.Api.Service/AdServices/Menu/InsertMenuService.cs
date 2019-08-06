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
    public class InsertMenuService : ApiBase<RequestMenuModel>
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
                MenuIcon = this.Parameter.MenuIcon,
                MenuUrl = this.Parameter.MenuUrl,
                FatherId = this.Parameter.FatherId,
                LevelId = this.Parameter.LevelId,
                IsDel = this.Parameter.IsDel,
                CreateTime = DateTime.Now,
                CreateUser = 1
            };
            var result = menuRep.InsertMenu(model);
            this.Result.Data = result;
        }
    }
}
