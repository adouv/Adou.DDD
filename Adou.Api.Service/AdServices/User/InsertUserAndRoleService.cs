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
    /// 插入用户信息，同时添加所拥有的角色权限
    /// </summary>
    public class InsertUserAndRoleService : ApiBase<RequestInsertUserAndRoleModel>
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

            var result = userRep.InsertUserAndRole(model, this.Parameter.RoleArr);
            this.Result.Data = result;
        }
    }
}
