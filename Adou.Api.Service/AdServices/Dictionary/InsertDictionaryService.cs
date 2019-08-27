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
    /// 添加字典
    /// </summary>
    public class InsertDictionaryService : ApiBase<RequestInsertDictionaryModel>
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
                DicValue = this.Parameter.DicValue,
                DicCoding = this.Parameter.DicCoding,
                DicType = this.Parameter.DicType,
                Sort = this.Parameter.Sort,
                Remark = this.Parameter.Remark,
                IsDel = this.Parameter.IsDel,
                CreateTime = DateTime.Now,
                CreateUser = AdouConfigHelper.UserName,
                ModifyTime = DateTime.Now,
                ModifyUser = AdouConfigHelper.UserName
            };

            var result = dictionaryRep.InsertDictionary(model);

            this.Result.Data = result;
        }
    }
}
