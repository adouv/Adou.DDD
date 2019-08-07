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
        /// 获取账户列表
        /// </summary>
        /// <param name="model">请求参数</param>
        /// <returns></returns>
        public IEnumerable<adAccount> GetAccountList(adAccount model)
        {
            string sqlWhere = string.Empty;
            string sql = string.Empty;

            if (!string.IsNullOrWhiteSpace(model.Title))
            {
                sqlWhere += " AND [Title] = @0 ";
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
                  FROM [dbo].[adAccount]
                  WHERE 1=1 AND [IsDel] = 1 {0}
            ", sqlWhere);
            #endregion

            return PetaPocoAdouDB.GetInstance().Query<adAccount>(sql,model.Title);
        }
    }
}
