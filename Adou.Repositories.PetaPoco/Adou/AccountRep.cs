using Adou.Entity.PetaPocoModels.AdouModel;
using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Adou.Repositories.PetaPoco.Adou
{
    /// <summary>
    /// 账号信息
    /// </summary>
    public class AccountRep
    {
        /// <summary>
        /// 获取账号列表
        /// </summary>
        /// <returns>IEnumerable<adAccount></returns>
        public Page<adAccount> GetAccountList(int PageIndex, int PageSize)
        {
            string sqlWhere = string.Empty;
            string sql = string.Empty;

            #region where

            #endregion

            #region sql
            sql += string.Format(@"
                SELECT [ID]
                        ,[Name]
                        ,[Email]
                        ,[Phone]
                        ,[Url]
                        ,[Account]
                        ,[Pwd]
                        ,[Remark]
                        ,[Description]
                        ,[CreateTime]
                        ,[CreateUserId]
                        ,[UpdateTime]
                        ,[UpdateUserId]
                        ,[TableId]
                    FROM [dbo].[adAccount]
                    WHERE 1=1 {0}
            ", sqlWhere);
            #endregion

            return PetaPocoAdouDB.GetInstance().Page<adAccount>(PageIndex, PageSize, sql);
        }
    }
}
