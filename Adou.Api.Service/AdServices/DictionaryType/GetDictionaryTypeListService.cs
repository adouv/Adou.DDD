﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adou.Api.Model;
using Adou.Entity.PetaPocoModels.AdouModel;
using Adou.Repositories.PetaPoco.Adou;

namespace Adou.Api.Service.AdServices.DictionaryType
{
    /// <summary>
    /// 获取字典项列表服务
    /// </summary>
    public class GetDictionaryTypeListService : ApiBase<RequestGetDictionaryTypeListModel>
    {
        public DictionaryTypeRep dictionaryTypeRep { get; set; }
        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        protected override void ExecuteMethod()
        {
            var model = new adDictionaryType()
            {
                Name = this.Parameter.Name,
                Coding = this.Parameter.Coding
            };

            var result = dictionaryTypeRep.GetDictionaryTypeList(this.Parameter.OrderBy, this.Parameter.IsDesc, model);

            this.Result.Data = result;
        }
    }
}
