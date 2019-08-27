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
    /// 通过编号更新字典
    /// </summary>
    public class UpdateDictionaryByIdService : ApiBase<RequestUpdateDictionaryByIdModel>
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
                DicKey = this.Parameter.DicKey,
                DicValue = this.Parameter.DicValue,
                DicCoding = this.Parameter.DicCoding,
                DicType = this.Parameter.DicType,
                Sort = this.Parameter.Sort,
                Remark = this.Parameter.Remark,
                ModifyTime = DateTime.Now,
                ModifyUser = AdouConfigHelper.UserName
            };

            var result = dictionaryRep.UpdateDictionaryById(model);

            this.Result.Data = result;
        }
    }
}
