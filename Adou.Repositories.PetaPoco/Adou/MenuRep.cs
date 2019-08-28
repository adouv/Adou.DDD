using Adou.Entity.PetaPocoModels.AdouModel;
using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adou.Repositories.PetaPoco.Adou
{
    public class MenuRep : BaseRep<adMenu>
    {
        /// <summary>
        /// 获取菜单列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<adMenu> GetMenuList(string orderBy, bool isDesc, adMenu model)
        {
            string sqlWhere = string.Empty;
            string sql = string.Empty;

            #region where
            if (!string.IsNullOrWhiteSpace(model.Title))
            {
                sqlWhere += " AND [Title] =  @0 ";
            }

            if (model.FatherId >= 0)
            {
                sqlWhere += " AND [FatherId] =  @1 ";
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
                      ,[Sort]
                  FROM [dbo].[adMenu]
                WHERE 1=1 AND [IsDel] = 0 {0} 
            ", sqlWhere);
            #endregion

            return this.GetList(orderBy, isDesc, sql, model.Title, model.FatherId);
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
                WHERE 1=1 AND [IsDel] = 0 {0}
            ", sqlWhere);
            #endregion

            return PetaPocoAdouDB.GetInstance().SingleOrDefault<adMenu>(sql, FatherId);
        }
        /// <summary>
        /// 通过角色编号获取菜单
        /// </summary>
        /// <param name="roleId">角色编号</param>
        /// <returns></returns>
        public IEnumerable<adMenu> GetMenuListByRoleId(long roleId)
        {
            string sql = string.Empty;

            #region sql
            sql = string.Format(@"
                SELECT b.Id,b.Title,b.FatherId,b.LevelId FROM adRoleAndMenu a 
                INNER JOIN adMenu b ON a.MenuId=b.Id
                WHERE RoleId = @0
            ");
            #endregion

            return PetaPocoAdouDB.GetInstance().Query<adMenu>(sql, roleId);
        }
        /// <summary>
        /// 添加菜单
        /// </summary>
        /// <param name="model">菜单请求实体</param>
        /// <returns>int</returns>
        public long InsertMenu(adMenu model)
        {
            this.Insert(model);
            return model.Id;
        }
        /// <summary>
        /// 通过Id删除账户
        /// </summary>
        /// <param name="model">请求实体</param>
        /// <returns></returns>
        public int DeleteMenuById(long id)
        {
            return this.Delete(id);
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
                      ,[Sort] = @7
                 WHERE 1=1 AND [Id] = @8
            ");
            #endregion

            return PetaPocoAdouDB.GetInstance().Update<adMenu>(sql, model.Title, model.MenuIcon, model.MenuUrl, model.FatherId, model.LevelId, model.ModifyTime, model.ModifyUser, model.Sort, model.Id);
        }
        /// <summary>
        /// 通过编号更新排序值
        /// </summary>
        /// <param name="id">编号</param>
        /// <param name="sort">排序</param>
        /// <returns></returns>
        public int UpdateMenuSortById(long id, int sort)
        {
            string sql = string.Format(@"
                   SET [Sort] = @0 WHERE 1=1 AND [Id] = @1
            ");

            return PetaPocoAdouDB.GetInstance().Update<adMenu>(sql, sort, id);
        }
        /// <summary>
        /// 通过编号伪删除
        /// </summary>
        /// <param name="model">请求实体</param>
        /// <returns>int</returns>
        public int UpdateMenuIsDelById(adMenu model)
        {
            #region sql
            string sql = string.Format(@"
                SET [IsDel] = @0 ,
                [ModifyTime] = @1,
                [ModifyUser] = @2
                WHERE 1 = 1 AND [Id] = @3
            ");
            #endregion

            return PetaPocoAdouDB.GetInstance().Update<adMenu>(sql, model.IsDel, model.ModifyTime, model.ModifyUser, model.Id);
        }
    }
}
