using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adou.Entity.PetaPocoModels.AdouModel;
using PetaPoco;

namespace Adou.Repositories.PetaPoco.Adou
{
    public class UserAndRoleRep : BaseRep<adUserAndRole>
    {
        /// <summary>
        /// 添加用户角色权限
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public long InsertUserAndRole(adUserAndRole model)
        {
            this.Insert(model);
            return model.Id;
        }
        /// <summary>
        /// 通过用户编号删除角色
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <returns></returns>

        public long DeleteUserAndRoleByUserId(long userId)
        {
            string sql = string.Format(@"
               WHERE 1=1 AND UserId = @0
            ");

            return PetaPocoAdouDB.GetInstance().Delete<adUserAndRole>(sql, userId);
        }
    }
}
