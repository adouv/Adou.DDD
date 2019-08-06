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
        public IEnumerable<adMenu> GetMenuList() {
            string sqlWhere = string.Empty;
            string sql = string.Empty;

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
                  FROM [dbo].[adMenu]
                WHERE 1=1 AND [IsDel] = 1 {0}
            ", sqlWhere);
            #endregion

            return PetaPocoAdouDB.GetInstance().Query<adMenu>(sql);
        }
        /// <summary>
        /// 通过父级编号获取菜单列表
        /// </summary>
        /// <param name="FatherId">父级编号</param>
        /// <returns>IEnumerable<adMenu></returns>
        public IEnumerable<adMenu> GetMenuByFatherId(int FatherId)
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
                  FROM [dbo].[adMenus]
                WHERE 1=1 AND [IsDel] = 1 {0}
            ", sqlWhere);
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
                  FROM [dbo].[adMenus]
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
    }
}
