
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
    /// 通过编号删除字典服务
    /// </summary>
    public class DeleteDictionaryByIdService : ApiBase<RequestDeleteDictionaryByIdModel>
    {
        public DictionaryRep dictionaryRep { get; set; }
        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        protected override void ExecuteMethod()
        {
            var result = dictionaryRep.DeleteDictionaryById(this.Parameter.Id);

            this.Result.Data = result;
        }
    }
}
