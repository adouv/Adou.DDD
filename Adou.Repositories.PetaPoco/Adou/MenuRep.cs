using Adou.Entity.PetaPocoModels.AdouModel;
using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adou.Repositories.PetaPoco.Adou
{
    public class MenuRep
    {
        /// <summary>
        /// 获取菜单列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<adMenu> GetMenuList(string orderBy, bool isDes)
        {
            string sqlWhere = string.Empty;
            string sql = string.Empty;

            string strOrderBy = "";
            if (isDes)
            {
                if (string.IsNullOrWhiteSpace(orderBy))
                {
                    strOrderBy = " ORDER BY CreateTime DESC ";
                }
                else
                {
                    strOrderBy = " ORDER BY " + orderBy + " DESC ";
                }
            }

            #region sql
            sql = string.Format(@"
                SELECT [Id]
                      ,[Title]
                      ,[MenuIcon]
                      ,[MenuUrl]
                      ,[FatherId]
                      ,[LevelId]
                      ,[CreateTime]
                      ,[CreateUser]
                      ,[ModifyTime]
                      ,[ModifyUser]
                      ,[IsDel]
                      ,[Sort]
                  FROM [dbo].[adMenu]
                WHERE 1=1 AND [IsDel] = 1 {0} {1}
            ", sqlWhere, strOrderBy);
            #endregion

            return PetaPocoAdouDB.GetInstance().Query<adMenu>(sql);
        }
        /// <summary>
        /// 通过父级编号获取菜单列表
        /// </summary>
        /// <param name="FatherId">父级编号</param>
        /// <returns>IEnumerable<adMenu></returns>
        public IEnumerable<adMenu> GetMenuListByFatherId(int FatherId, string orderBy, bool isDes)
        {
            string sqlWhere = string.Empty;
            string sql = string.Empty;

            #region where
            if (FatherId >= 0)
            {
                sqlWhere += " AND [FatherId] = @0 ";
            }
            #endregion

            string strOrderBy = "";
            if (isDes)
            {
                if (string.IsNullOrWhiteSpace(orderBy))
                {
                    strOrderBy = " ORDER BY CreateTime DESC ";
                }
                else
                {
                    strOrderBy = " ORDER BY " + orderBy + " DESC ";
                }
            }

            #region sql
            sql = string.Format(@"
                SELECT [Id]
                      ,[Title]
                      ,[MenuIcon]
                      ,[MenuUrl]
                      ,[FatherId]
                      ,[LevelId]
                      ,[CreateTime]
                      ,[CreateUser]
                      ,[ModifyTime]
                      ,[ModifyUser]
                      ,[IsDel]
                      ,[Sort]
                  FROM [dbo].[adMenu]
                WHERE 1=1 AND [IsDel] = 1 {0} {1}
            ", sqlWhere, strOrderBy);
            #endregion

            return PetaPocoAdouDB.GetInstance().Query<adMenu>(sql, FatherId);
        }
        /// <summary>
        /// 通过父级编号获取菜单
        /// </summary>
        /// <param name="FatherId">父级编号</param>
        /// <returns>adMenu</returns>
        public adMenu GetSingleMenuByFatherId(int FatherId)
        {
            string sqlWhere = string.Empty;
            string sql = string.Empty;

            #region where
            if (FatherId >= 0)
            {
                sqlWhere += " AND [FatherId] = @0 ";
            }
            #endregion

            #region sql
            sql = string.Format(@"
                SELECT TOP 1 [Id]
                      ,[Title]
                      ,[MenuIcon]
                      ,[MenuUrl]
                      ,[FatherId]
                      ,[LevelId]
                      ,[CreateTime]
                      ,[CreateUser]
                      ,[ModifyTime]
                      ,[ModifyUser]
                      ,[IsDel]
                      ,[Sort]
                  FROM [dbo].[adMenu]
                WHERE 1=1 AND [IsDel] = 1 {0}
            ", sqlWhere);
            #endregion

            return PetaPocoAdouDB.GetInstance().SingleOrDefault<adMenu>(sql, FatherId);
        }
        /// <summary>
        /// 添加菜单
        /// </summary>
        /// <param name="model">菜单请求实体</param>
        /// <returns>int</returns>
        public int InsertMenu(adMenu model)
        {
            PetaPocoAdouDB.GetInstance().Insert(model);
            return model.Id;
        }
        /// <summary>
        /// 通过Id删除账户
        /// </summary>
        /// <param name="model">请求实体</param>
        /// <returns></returns>
        public int DeleteMenuById(int Id)
        {
            string sql = string.Format(@"
                DELETE FROM [dbo].[adMenu] WHERE 1=1 AND Id = {0}
            ", Id);

            return PetaPocoAdouDB.GetInstance().Execute(sql);
        }
        /// <summary>
        /// 修改账户
        /// </summary>
        /// <param name="model">请求参数</param>
        /// <returns></returns>
        public int UpdateMenuById(adMenu model)
        {
            string sql = string.Empty;

            #region sql
            sql = string.Format(@"
                   SET [Title] = @0
                      ,[MenuIcon] = @1
                      ,[MenuUrl] = @2
                      ,[FatherId] = @3
                      ,[LevelId] = @4
                      ,[ModifyTime] = @5
                      ,[ModifyUser] = @6
                      ,[IsDel] = @7
                      ,[Sort] = @8
                 WHERE 1=1 AND [Id] = @9
            ");
            #endregion

            return PetaPocoAdouDB.GetInstance().Update<adMenu>(sql, model.Title, model.MenuIcon, model.MenuUrl, model.FatherId, model.LevelId, model.ModifyTime, model.ModifyUser, model.IsDel, model.Sort, model.Id);
        }
        /// <summary>
        /// 通过编号更新排序值
        /// </summary>
        /// <param name="id">编号</param>
        /// <param name="sort">排序</param>
        /// <returns></returns>
        public int UpdateMenuSortById(int id, int sort)
        {
            string sql = string.Format(@"
                   SET [Sort] = @0 WHERE 1=1 AND [Id] = @1
            ");

            return PetaPocoAdouDB.GetInstance().Update<adMenu>(sql, sort, id);
        }
    }
}
