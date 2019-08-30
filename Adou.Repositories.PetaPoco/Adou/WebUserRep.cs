using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetaPoco;
using Adou.Entity.PetaPocoModels.AdouModel;

namespace Adou.Repositories.PetaPoco.Adou
{
    /// <summary>
    /// 网站用户信息
    /// </summary>
    public class WebUserRep : BaseRep<adWebUser>
    {
        /// <summary>
        /// 通过用户名和密码进行用户登录
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="userPwd">密码</param>
        /// <returns>adUser</returns>
        public adWebUser GetWebUserByUserNameAndUserPwd(string userName, string userPwd)
        {
            string sqlWhere = string.Empty;
            string sql = string.Empty;

            #region where
            if (!string.IsNullOrWhiteSpace(userName))
            {
                sqlWhere += @" AND UserName = @0 ";
            }
            if (!string.IsNullOrWhiteSpace(userPwd))
            {
                sqlWhere += @" AND UserPwd = @1 ";
            }
            #endregion

            #region sql
            sql += string.Format(@"
                SELECT TOP 1 [Id]
                    ,[UserName]
                    ,[UserPwd]
                    ,[RealName]
                    ,[IDCard]
                    ,[CompanyName]
                    ,[Mobile]
                    ,[Tel]
                    ,[Address]
                    ,[CreateTime]
                    ,[CreateUser]
                    ,[ModifyTime]
                    ,[ModifyUser]
                    ,[IsDel]
                    ,[IsValid]
                    ,[IsVip]
                FROM [dbo].[adWebUser]
                WHERE 1=1 And IsDel = 0 {0}
            ", sqlWhere);
            #endregion

            return PetaPocoAdouDB.GetInstance().SingleOrDefault<adWebUser>(sql, userName, userPwd);
        }
        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <param name="orderBy">排序字段</param>
        /// <param name="isDesc">是否降序</param>
        /// <param name="model">请求实体</param>
        /// <returns>IEnumerable<adUser></returns>
        public IEnumerable<adWebUser> GetWebUserList(string orderBy, bool isDesc, adWebUser model)
        {
            string sqlWhere = string.Empty;
            string sql = string.Empty;

            #region where
            if (!string.IsNullOrWhiteSpace(model.UserName))
            {
                sqlWhere += " AND [UserName] = @0 ";
            }
            if (model.IsValid > 0)
            {
                sqlWhere += " AND [IsValid] = @1 ";
            }
            if (model.IsVip > 0)
            {
                sqlWhere += " AND [IsVip] = @2 ";
            }
            #endregion

            #region sql
            sql = string.Format(@"
                SELECT [Id]
                    ,[UserName]
                    ,[UserPwd]
                    ,[RealName]
                    ,[IDCard]
                    ,[CompanyName]
                    ,[Mobile]
                    ,[Tel]
                    ,[Address]
                    ,[CreateTime]
                    ,[CreateUser]
                    ,[ModifyTime]
                    ,[ModifyUser]
                    ,[IsDel]
                    ,[IsValid]
                    ,[IsVip]
                FROM [dbo].[adWebUser]
                WHERE 1=1 And IsDel = 0 {0}
            ", sqlWhere);
            #endregion

            return this.GetList(orderBy, isDesc, sql, model.UserName, model.IsValid, model.IsVip);
        }
        /// <summary>
        /// 分页获取用户信息
        /// </summary>
        /// <param name="orderBy">排序字段</param>
        /// <param name="isDesc">是否降序</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页条数</param>
        /// <param name="model">请求实体</param>
        /// <returns>Page<adUser></returns>
        public Page<adWebUser> GetWebUserPageList(string orderBy, bool isDesc, int pageIndex, int pageSize, adWebUser model)
        {
            string sqlWhere = string.Empty;
            string sql = string.Empty;

            #region where
            if (!string.IsNullOrWhiteSpace(model.UserName))
            {
                sqlWhere += " AND [UserName] = @0 ";
            }
            if (model.IsValid > 0)
            {
                sqlWhere += " AND [IsValid] = @1 ";
            }
            if (model.IsVip > 0)
            {
                sqlWhere += " AND [IsVip] = @2 ";
            }
            #endregion

            #region sql
            sql = string.Format(@"
                SELECT [Id]
                    ,[UserName]
                    ,[UserPwd]
                    ,[RealName]
                    ,[IDCard]
                    ,[CompanyName]
                    ,[Mobile]
                    ,[Tel]
                    ,[Address]
                    ,[CreateTime]
                    ,[CreateUser]
                    ,[ModifyTime]
                    ,[ModifyUser]
                    ,[IsDel]
                    ,[IsValid]
                    ,[IsVip]
                FROM [dbo].[adWebUser]
                WHERE 1=1 And IsDel = 0 {0}
            ", sqlWhere);
            #endregion

            return this.GetPageList(orderBy, isDesc, pageIndex, pageSize, sql, model.UserName, model.IsValid, model.IsVip);
        }
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="model">请求参数</param>
        /// <returns>long</returns>
        public long InsertWebUser(adWebUser model)
        {
            this.Insert(model);
            return model.Id;
        }
        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="model">请求参数</param>
        /// <returns>long</returns>
        public long UpdateWebUserById(adWebUser model)
        {
            string sql = string.Empty;

            #region sql
            sql = string.Format(@"
                SET [UserName] = @0
                    ,[UserPwd] = @1
                    ,[RealName] = @2
                    ,[IDCard] = @3
                    ,[CompanyName] = @4
                    ,[Mobile] = @5
                    ,[Tel] = @6
                    ,[Address] = @7
                    ,[ModifyTime] = @8
                    ,[ModifyUser] = @9
                    ,[IsValid] = @10
                    ,[IsVip] = @11
                WHERE 1 = 1 AND [Id] = @12
            ");
            #endregion

            return PetaPocoAdouDB.GetInstance().Update<adWebUser>(sql,
                model.UserName,
                model.UserPwd,
                model.RealName,
                model.IDCard,
                model.CompanyName,
                model.Mobile,
                model.Tel,
                model.Address,
                model.ModifyTime,
                model.ModifyUser,
                model.IsValid,
                model.IsVip,
                model.Id);
        }
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns></returns>
        public int DeleteWebUserById(long id)
        {
            return this.Delete(id);
        }
        /// <summary>
        /// 伪删除
        /// </summary>
        /// <param name="model">请求实体</param>
        /// <returns></returns>
        public int UpdateWebUserIsDelById(adWebUser model)
        {
            #region sql
            string sql = string.Format(@"
                SET [IsDel] = @0
                    ,[ModifyTime] = @1
                    ,[ModifyUser] = @2
                WHERE 1 = 1 AND [Id] = @3
            ");
            #endregion

            return PetaPocoAdouDB.GetInstance().Update<adWebUser>(sql, model.IsDel, model.ModifyTime, model.ModifyUser, model.Id);
        }
    }
}
