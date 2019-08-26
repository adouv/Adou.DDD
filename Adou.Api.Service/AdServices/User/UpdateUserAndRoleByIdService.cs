using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adou.Api.Model;
using Adou.Entity.PetaPocoModels.AdouModel;

using Adou.Repositories.PetaPoco.Adou;

namespace Adou.Api.Service.AdServices.User
{
    /// <summary>
    /// 通过编号更新用户，同时更新所拥有的角色权限
    /// </summary>
    public class UpdateUserAndRoleByIdService : ApiBase<RequestUpdateUserAndRoleByIdModel>
    {
        public UserRep userRep { get; set; }
        /// <summary>
        /// 执行具体业务逻辑
        /// </summary>
        protected override void ExecuteMethod()
        {
            var model = new adUser()
            {
                Id = this.Parameter.Id,
                UserName = this.Parameter.UserName,
                UserPwd = this.Parameter.UserPwd,
                UserType = this.Parameter.UserType,
                UserStatus = this.Parameter.UserStatus,
                RoleId = this.Parameter.RoleId,
                ModifyTime = DateTime.Now,
                ModifyUser = "fukaihang",
                IsDel = false,
                Sort = this.Parameter.Sort
            };

            var result = userRep.UpdateUserAndRoleById(model, this.Parameter.RoleArr);
            this.Result.Data = result;
        }
    }
}
