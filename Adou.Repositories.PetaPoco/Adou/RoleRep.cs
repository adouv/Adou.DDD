using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adou.Entity.PetaPocoModels.AdouModel;
using PetaPoco;

namespace Adou.Repositories.PetaPoco.Adou
{
    public class RoleRep : BaseRep<adRole>
    {
        /// <summary>
        /// 获取角色列表
        /// </summary>
        /// <param name="orderBy">排序字段</param>
        /// <param name="isDesc">是否降序</param>
        /// <param name="model">请求实体</param>
        /// <returns>IEnumerable<adRole></returns>
        public IEnumerable<adRole> GetRoleList(string orderBy, bool isDesc, adRole model)
        {
            string sqlWhere = string.Empty;
            string sql = string.Empty;

            #region where
            if (!string.IsNullOrWhiteSpace(model.RoleName))
            {
                sqlWhere += " AND [RoleName] = @0 ";
            }
            #endregion

            #region sql
            sql = string.Format(@"
                SELECT [Id]
                      ,[RoleName]
                      ,[CreateTime]
                      ,[CreateUser]
                      ,[ModifyTime]
                      ,[ModifyUser]
                      ,[IsDel]
                      ,[Sort]
                  FROM [dbo].[adRole]
                  WHERE 1=1 And IsDel = 0 {0}
            ", sqlWhere);
            #endregion

            return this.GetList(orderBy, isDesc, sql, model.RoleName);
        }
        /// <summary>
        /// 分页获取角色列表
        /// </summary>
        /// <param name="orderBy">排序字段</param>
        /// <param name="isDesc">是否降序</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页条数</param>
        /// <param name="model">请求实体</param>
        /// <returns>Page<adRole></returns>
        public Page<adRole> GetRolePageList(string orderBy, bool isDesc, int pageIndex, int pageSize, adRole model)
        {
            string sqlWhere = string.Empty;
            string sql = string.Empty;

            #region where
            if (!string.IsNullOrWhiteSpace(model.RoleName))
            {
                sqlWhere += " AND [RoleName] = @0 ";
            }
            #endregion

            #region sql
            sql = string.Format(@"
                SELECT [Id]
                      ,[RoleName]
                      ,[CreateTime]
                      ,[CreateUser]
                      ,[ModifyTime]
                      ,[ModifyUser]
                      ,[IsDel]
                      ,[Sort]
                  FROM [dbo].[adRole]
                WHERE 1=1 And IsDel = 0 {0} 
            ", sqlWhere);
            #endregion

            return this.GetPageList(orderBy, isDesc, pageIndex, pageSize, sql, model.RoleName);
        }
        /// <summary>
        /// 通过用户编号获取角色
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <returns></returns>
        public IEnumerable<adRole> GetRoleListByUserId(long userId)
        {
            string sql = string.Empty;

            #region sql
            sql = string.Format(@"
                SELECT b.Id,b.RoleName FROM adUserAndRole a 
                INNER JOIN adRole b ON a.RoleId=b.Id
                WHERE UserId = @0
            "); 
            #endregion

            return PetaPocoAdouDB.GetInstance().Query<adRole>(sql, userId);
        }
        /// <summary>
        /// 添加角色，同时添加所拥有的菜单权限
        /// </summary>
        /// <param name="model">请求实体</param>
        /// <param name="menuArr">菜单编号数组</param>
        /// <returns>long</returns>
        public int InsertRoleAndMenu(adRole model, int[] menuArr)
        {
            using (var db = PetaPocoAdouDB.GetInstance())
            {
                int index = 0;

                db.BeginTransaction();

                try
                {
                    db.Insert(model);

                    if (model.Id > 0)
                    {
                        foreach (var menu in menuArr)
                        {
                            var item = new adRoleAndMenu()
                            {
                                RoleId = model.Id,
                                MenuId = menu
                            };

                            db.Insert(item);

                            if (item.Id > 0)
                            {
                                index++;
                            }
                        }

                        db.CompleteTransaction();
                    }
                }
                catch (Exception ex)
                {
                    db.AbortTransaction();
                }

                return index;
            }
        }
        /// <summary>
        /// 通过编号更新角色,同时更新所拥有的菜单权限
        /// </summary>
        /// <param name="model">请求实体</param>
        /// <param name="menuArr">菜单编号数组</param>
        /// <returns>int</returns>
        public int UpdateRoleAndMenuById(adRole model, int[] menuArr)
        {
            using (var db = PetaPocoAdouDB.GetInstance())
            {
                int index = 0;

                db.BeginTransaction();

                try
                {
                    #region sql
                    string sql = string.Format(@"
                        UPDATE [dbo].[adRole] SET [RoleName] = @0
                            ,[ModifyTime] = @1
                            ,[ModifyUser] = @2
                            ,[IsDel] = @3
                            ,[Sort] = @4
                        WHERE 1 = 1 AND [Id] = @5;
                        
                        DELETE FROM [dbo].[adRoleAndMenu] WHERE 1=1 AND RoleId = {0};
                    ", model.Id);
                    #endregion

                    var result = db.Execute(sql, model.RoleName,
                        model.ModifyTime,
                        model.ModifyUser,
                        model.IsDel,
                        model.Sort,
                        model.Id);


                    if (result > 0)
                    {
                        foreach (var menu in menuArr)
                        {
                            var item = new adRoleAndMenu()
                            {
                                RoleId = model.Id,
                                MenuId = menu
                            };

                            db.Insert(item);

                            if (item.Id > 0)
                            {
                                index++;
                            }
                        }

                        db.CompleteTransaction();
                    }
                }
                catch (Exception ex)
                {
                    db.AbortTransaction();
                }

                return index;
            }
        }
        /// <summary>
        /// 通过编号更新角色是否删除（伪删除）
        /// </summary>
        /// <param name="model">请求实体</param>
        /// <returns>int</returns>
        public int UpdateRoleIsDelById(adRole model)
        {
            #region sql
            string sql = string.Format(@"
                SET [IsDel] = @0 ,
                [ModifyTime] = @1,
                [ModifyUser] = @2
                WHERE 1 = 1 AND [Id] = @3
            ");
            #endregion

            return PetaPocoAdouDB.GetInstance().Update<adRole>(sql, model.IsDel, model.ModifyTime, model.ModifyUser, model.Id);
        }
        /// <summary>
        /// 通过编号删除用户
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns>int</returns>
        public int DeleteRoleById(long id)
        {
            return this.Delete(id);
        }
    }
}
