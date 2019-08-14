using Adou.Entity.PetaPocoModels.AdouModel;
using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adou.Repositories.PetaPoco.Adou
{
    public class AccountRep : BaseRep<adAccount>
    {
        /// <summary>
        /// 获取账户列表
        /// </summary>
        /// <param name="model">请求参数</param>
        /// <returns></returns>
        public IEnumerable<adAccount> GetAccountList(string orderBy, bool isDesc, adAccount model)
        {
            string sqlWhere = string.Empty;
            string sql = string.Empty;

            #region where
            if (!string.IsNullOrWhiteSpace(model.Title))
            {
                sqlWhere += " AND [Title] = @0 ";
            }

            if (model.Type != -1)
            {
                sqlWhere += " AND [Type] = @1 ";
            }
            #endregion

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
                      ,[Type]
                  FROM [dbo].[adAccount]
                  WHERE 1=1 AND [IsDel] = 0 {0} 
            ", sqlWhere);
            #endregion

            return this.GetList(orderBy, isDesc, sql, model.Title, model.Type);
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
        public Page<adAccount> GetAccountPageList(int pageIndex, int pageSize, string orderBy, bool isDesc, adAccount model)
        {
            string sqlWhere = string.Empty;
            string sql = string.Empty;

            #region where
            if (!string.IsNullOrWhiteSpace(model.Title))
            {
                sqlWhere += " AND [Title] = @0 ";
            }

            if (model.Type != -1)
            {
                sqlWhere += " AND [Type] = @1 ";
            }
            #endregion

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
                      ,[Type]
                  FROM [dbo].[adAccount] WHERE 1=1 AND [IsDel] = 0  {0} 
            ", sqlWhere);
            #endregion

            return this.GetPageList(orderBy, isDesc, pageIndex, pageSize, sql, model.Title, model.Type);
        }
        /// <summary>
        /// 删除账户
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns></returns>
        public int DeleteAccountById(long id)
        {
            return this.Delete(id);
        }
        /// <summary>
        /// 添加账户
        /// </summary>
        /// <param name="model">请求实体</param>
        /// <returns>int</returns>
        public long InsertAccount(adAccount model)
        {
            this.Insert(model);
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
                      ,[Type] = @12
                 WHERE 1=1 AND [Id] = @13
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
                model.Type,
                model.Id);
        }
        /// <summary>
        /// 伪删除
        /// </summary>
        /// <param name="isDel"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public int UpdateAccountIsDelById(bool isDel, int id)
        {
            return this.UpdateIsDel(isDel, id);
        }
    }
}
