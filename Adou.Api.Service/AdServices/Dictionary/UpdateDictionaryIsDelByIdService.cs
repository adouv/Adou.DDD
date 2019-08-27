using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adou.Api.Model;
using Adou.Entity.PetaPocoModels.AdouModel;
using Adou.Repositories.PetaPoco.Adou;
using Adou.DDD.Config;

namespace Adou.Api.Service.AdServices.Dictionary
{
    /// <summary>
    /// 伪删除
    /// </summary>
    public class UpdateDictionaryIsDelByIdService : ApiBase<RequestUpdateDictionaryIsDelByIdModel>
    {
        public DictionaryRep dictionaryRep { get; set; }
        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        protected override void ExecuteMethod()
        {
            var model = new adDictionary()
            {
                Id = this.Parameter.Id,
                IsDel = true,
                ModifyTime = DateTime.Now,
                ModifyUser = AdouConfigHelper.UserName
            };

            var result = dictionaryRep.UpdateDictionaryIsDelById(model);

            this.Result.Data = result;
        }
    }
}
