using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adou.Entity.PetaPocoModels.AdouModel;
using PetaPoco;

namespace Adou.Repositories.PetaPoco.Adou
{
    public class RoleAndMenuRep : BaseRep<adRoleAndMenu>
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
        /// 批量增加角色菜单
        /// </summary>
        /// <param name="roleId">角色编号</param>
        /// <param name="menuArr">菜单编号数组</param>
        /// <returns></returns>
        public int InsertRoleAndMenuList(long roleId, int[] menuArr)
        {
            using (var db = PetaPocoAdouDB.GetInstance())
            {
                int index = 0;

                db.BeginTransaction();

                try
                {
                    foreach (var menu in menuArr)
                    {
                        var model = new adRoleAndMenu()
                        {
                            RoleId = roleId,
                            MenuId = menu
                        };

                        db.Insert(model);

                        if (model.Id > 0)
                        {
                            index++;
                        }
                    }

                    db.CompleteTransaction();
                }
                catch (Exception ex)
                {
                    db.AbortTransaction();
                }
                return index;
            }
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
