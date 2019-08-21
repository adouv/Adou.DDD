﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adou.Api.Model;
using Adou.Repositories.PetaPoco.Adou;

namespace Adou.Api.Service.AdServices.User
{
    /// <summary>
    /// 更新用户删除状态
    /// </summary>
    public class UpdateUserIsDelByIdService : ApiBase<RequestUpdateUserIsDelByIdModel>
    {
        public UserRep userRep { get; set; }
        /// <summary>
        /// 执行具体业务逻辑
        /// </summary>
        protected override void ExecuteMethod()
        {
            var result = userRep.UpdateUserIsDelById(this.Parameter.IsDel, this.Parameter.Id);

            this.Result.Data = result;
        }
    }
}