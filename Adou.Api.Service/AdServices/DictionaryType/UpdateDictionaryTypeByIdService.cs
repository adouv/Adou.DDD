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
    /// 通过编号更新字典项
    /// </summary>
    public class UpdateDictionaryTypeByIdService : ApiBase<RequestUpdateDictionaryTypeByIdModel>
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
                Coding = this.Parameter.Coding,
                Name = this.Parameter.Name,
                Sort = this.Parameter.Sort,
                Remark = this.Parameter.Remark,
                ModifyTime = DateTime.Now,
                ModifyUser = AdouConfigHelper.UserName
            };

            var result = dictionaryTypeRep.UpdateDictionaryTypeById(model);

            this.Result.Data = result;
        }
    }
}
