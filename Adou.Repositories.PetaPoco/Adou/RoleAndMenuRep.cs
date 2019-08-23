using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adou.Entity.PetaPocoModels.AdouModel;
using PetaPoco;

namespace Adou.Repositories.PetaPoco.Adou
{
    public class RoleAndMenuRep:BaseRep<adRoleAndMenu>
    {
        /// <summary>
        /// 添加角色菜单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public long InsertRoleAndMenu(adRoleAndMenu model)
        {
            this.Insert(model);
            return model.Id;
        }
        /// <summary>
        /// 通过角色编号删除角色菜单
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public long DeleteRoleAndMenuByRoleId(long roleId)
        {
            string sql = string.Format(@"
               WHERE 1=1 AND RoleId = @0
            ");

            return PetaPocoAdouDB.GetInstance().Delete<adRoleAndMenu>(sql, roleId);
        }
    }
}
