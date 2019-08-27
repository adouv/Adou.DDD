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
    /// 通过编号删除字典项服务
    /// </summary>
    public class DeleteDictionaryTypeByIdService : ApiBase<RequestDeleteDictionaryTypeByIdModel>
    {
        public DictionaryTypeRep dictionaryTypeRep { get; set; }
        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        protected override void ExecuteMethod()
        {
            var result = dictionaryTypeRep.DeleteDictionaryTypeById(this.Parameter.Id);

            this.Result.Data = result;
        }
    }
}
