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
    /// 添加字典项
    /// </summary>
    public class InsertDictionaryTypeService : ApiBase<RequestInsertDictionaryTypeModel>
    {
        public DictionaryTypeRep dictionaryTypeRep { get; set; }
        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        protected override void ExecuteMethod()
        {
            var model = new adDictionaryType()
            {
                Coding = this.Parameter.Coding,
                Name = this.Parameter.Name,
                Sort = this.Parameter.Sort,
                Remark = this.Parameter.Remark,
                IsDel = false,
                CreateTime = DateTime.Now,
                CreateUser = AdouConfigHelper.UserName,
                ModifyTime = DateTime.Now,
                ModifyUser = AdouConfigHelper.UserName
            };

            var result = dictionaryTypeRep.InsertDictionaryType(model);

            this.Result.Data = result;
        }
    }
}
