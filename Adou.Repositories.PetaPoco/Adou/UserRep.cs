using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adou.Entity.PetaPocoModels.AdouModel;

namespace Adou.Repositories.PetaPoco.Adou
{
    /// <summary>
    /// 用户信息
    /// </summary>
    public class UserRep
    {
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="UserName">用户名</param>
        /// <param name="UserPwd">密码</param>
        /// <returns>adUser</returns>
        public adUser GetUser(string UserName, string UserPwd)
        {
            string sqlWhere = string.Empty;
            string sql = string.Empty;

            #region where
            if (!string.IsNullOrWhiteSpace(UserName))
            {
                sqlWhere += @"
                    AND UserName = @0
                ";
            }
            if (!string.IsNullOrWhiteSpace(UserPwd))
            {
                sqlWhere += @"
                    AND UserPwd = @1
                ";
            }
            #endregion

            #region sql
            sql += string.Format(@"
                SELECT [ID]
                      ,[UserName]
                      ,[UserHead]
                      ,[UserType]
                      ,[UserStatus]
                      ,[RoleId]
                      ,[CreateTime]
                      ,[CreateUserId]
                      ,[UpdateTime]
                      ,[UpdateUserId]
                FROM [dbo].[adUser]
                WHERE 1=1 {0}
            ", sqlWhere);
            #endregion

            return PetaPocoAdouDB.GetInstance().SingleOrDefault<adUser>(sql, UserName, UserPwd);
        }
    }
}
