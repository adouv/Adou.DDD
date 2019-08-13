using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adou.Api.Model;
using Adou.Repositories.PetaPoco.Adou;
using Adou.Entity.PetaPocoModels.AdouModel;

namespace Adou.Api.Service.AdServices.User
{
    /// <summary>
    /// 
    /// </summary>
    public class InsertUserService : ApiBase<RequestInsertUserModel>
    {
        public UserRep userRep { get; set; }
        /// <summary>
        /// 执行具体业务逻辑
        /// </summary>
        protected override void ExecuteMethod()
        {
            var model = new adUser()
            {
                UserName = this.Parameter.UserName,
                UserPwd = this.Parameter.UserPwd,
                UserHead = this.Parameter.UserHead,
                UserType = this.Parameter.UserType,
                UserStatus = this.Parameter.UserStatus,
                RoleId = this.Parameter.RoleId,
                CreateTime = DateTime.Now,
                CreateUser = "fukaihang",
                ModifyTime = DateTime.Now,
                ModifyUser = "fukaihang",
                IsDel = false,
                Sort = this.Parameter.Sort
            };

            var result = userRep.InsertUser(model);
            this.Result.Data = result;
        }
    }
}
