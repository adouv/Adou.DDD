using Adou.Entity.PetaPocoModels.AdouModel;
using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adou.Repositories.PetaPoco.Adou
{
    public class AccountRep
    {
        /// <summary>
        /// 添加账户
        /// </summary>
        /// <param name="model">请求实体</param>
        /// <returns>int</returns>
        public long InsertAccount(adAccount model)
        {
            PetaPocoAdouDB.GetInstance().Insert(model);
            return model.Id;
        }
        /// <summary>
        /// 修改账户
        /// </summary>
        /// <param name="model">请求参数</param>
        /// <returns></returns>
        public long UpdateAccountById(adAccount model)
        {
            string sql = string.Empty;

            #region sql
            sql = string.Format(@"
                   SET [Title] = @0
                      ,[Url] = @1
                      ,[Account] = @2
                      ,[Password] = @3
                      ,[Email] = @4
                      ,[Mobile] = @5
                      ,[Keyword] = @6
                      ,[Descript] = @7
                      ,[ModifyTime] = @8
                      ,[ModifyUser] = @9
                      ,[IsDel] = @10
                      ,[Sort] = @11
                 WHERE 1=1 AND [Id] = @12
            ");
            #endregion

            return PetaPocoAdouDB.GetInstance().Update<adAccount>(sql,
                model.Title,
                model.Url,
                model.Account,
                model.Password,
                model.Email,
                model.Mobile,
                model.Keyword,
                model.Descript,
                model.ModifyTime,
                model.ModifyUser,
                model.IsDel,
                model.Sort,
                model.Id);
        }
        /// <summary>
        /// 获取账户列表
        /// </summary>
        /// <param name="model">请求参数</param>
        /// <returns></returns>
        public IEnumerable<adAccount> GetAccountList(string orderBy, bool isDes, adAccount model)
        {
            string sqlWhere = string.Empty;
            string sql = string.Empty;

            #region where
            if (!string.IsNullOrWhiteSpace(model.Title))
            {
                sqlWhere += " AND [Title] = @0 ";
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
                      ,[Url]
                      ,[Account]
                      ,[Password]
                      ,[Email]
                      ,[Mobile]
                      ,[Keyword]
                      ,[Descript]
                      ,[CreateTime]
                      ,[CreateUser]
                      ,[ModifyTime]
                      ,[ModifyUser]
                      ,[IsDel]
                      ,[Sort]
                  FROM [dbo].[adAccount]
                  WHERE 1=1 AND [IsDel] = 1 {0} {1}
            ", sqlWhere, strOrderBy);
            #endregion

            return PetaPocoAdouDB.GetInstance().Query<adAccount>(sql, model.Title);
        }
        /// <summary>
        /// 分页获取账户列表
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页条数</param>
        /// <param name="orderBy">排序字段</param>
        /// <param name="isDes">是否倒序</param>
        /// <param name="model">请求实体</param>
        /// <returns></returns>
        public Page<adAccount> GetAccountPageList(int pageIndex, int pageSize, string orderBy, bool isDes, adAccount model)
        {
            string sqlWhere = string.Empty;
            string sql = string.Empty;

            #region where
            if (!string.IsNullOrWhiteSpace(model.Title))
            {
                sqlWhere += " AND [Title] = @0 ";
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
                      ,[Url]
                      ,[Account]
                      ,[Password]
                      ,[Email]
                      ,[Mobile]
                      ,[Keyword]
                      ,[Descript]
                      ,[CreateTime]
                      ,[CreateUser]
                      ,[ModifyTime]
                      ,[ModifyUser]
                      ,[IsDel]
                      ,[Sort]
                  FROM [dbo].[adAccount] WHERE 1=1 {0} {1} 
            ", sqlWhere, strOrderBy);
            #endregion

            return PetaPocoAdouDB.GetInstance().Page<adAccount>(pageIndex, pageSize, sql, model.Title);
        }
        /// <summary>
        /// 通过Id删除账户
        /// </summary>
        /// <param name="model">请求实体</param>
        /// <returns></returns>
        public int DeleteAccountById(long Id)
        {
            string sql = string.Format(@"
                DELETE FROM [dbo].[adAccount] WHERE 1=1 AND Id = {0}
            ", Id);

            return PetaPocoAdouDB.GetInstance().Execute(sql);
        }
    }
}
