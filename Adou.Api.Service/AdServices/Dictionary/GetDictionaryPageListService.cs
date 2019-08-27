using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adou.Api.Model;
using Adou.Entity.PetaPocoModels.AdouModel;
using Adou.Repositories.PetaPoco.Adou;

namespace Adou.Api.Service.AdServices.Dictionary
{
    /// <summary>
    /// 分页获取字典列表服务
    /// </summary>
    public class GetDictionaryPageListService : ApiBase<RequestGetDictionaryListModel>
    {
        public DictionaryRep dictionaryRep { get; set; }
        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        protected override void ExecuteMethod()
        {
            var model = new adDictionary()
            {
                DicKey = this.Parameter.DicKey,
                DicCoding = this.Parameter.DicCoding,
                DicType = this.Parameter.DicType
            };

            var result = dictionaryRep.GetDictionaryPageList(this.Parameter.PageIndex, this.Parameter.PageSize, this.Parameter.OrderBy, this.Parameter.IsDesc, model);

            this.Result.Data = result;
        }
    }
}
