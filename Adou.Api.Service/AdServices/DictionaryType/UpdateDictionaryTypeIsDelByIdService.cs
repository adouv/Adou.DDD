using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adou.Api.Model;
using Adou.Entity.PetaPocoModels.AdouModel;
using Adou.Repositories.PetaPoco.Adou;
using Adou.DDD.Config;

namespace Adou.Api.Service.AdServices.DictionaryType
{
    /// <summary>
    /// 伪删除
    /// </summary>
    public class UpdateDictionaryTypeIsDelByIdService : ApiBase<RequestUpdateDictionaryTypeIsDelByIdModel>
    {
        public DictionaryTypeRep dictionaryTypeRep { get; set; }
        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        protected override void ExecuteMethod()
        {
            var model = new adDictionaryType()
            {
                Id = this.Parameter.Id,
                IsDel = this.Parameter.IsDel,
                ModifyTime = DateTime.Now,
                ModifyUser = AdouConfigHelper.UserName
            };

            var result = dictionaryTypeRep.UpdateDictionaryTypeIsDelById(model);

            this.Result.Data = result;
        }
    }
}
