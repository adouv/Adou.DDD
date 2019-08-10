﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adou.Entity.PetaPocoModels.AdouModel;
using PetaPoco;

namespace Adou.Repositories.PetaPoco.Adou
{
    /// <summary>
    /// 用户信息
    /// </summary>
    public class UserRep : BaseRep<adUser>
    {
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="userPwd">密码</param>
        /// <returns>adUser</returns>
        public adUser GetUser(string userName, string userPwd)
        {
            string sqlWhere = string.Empty;
            string sql = string.Empty;

            #region where
            if (!string.IsNullOrWhiteSpace(userName))
            {
                sqlWhere += @"
                    AND UserName = @0
                ";
            }
            if (!string.IsNullOrWhiteSpace(userPwd))
            {
                sqlWhere += @"
                    AND UserPwd = @1
                ";
            }
            #endregion

            #region sql
            sql += string.Format(@"
                SELECT TOP 1 [Id]
                      ,[UserName]
                      ,[UserPwd]
                      ,[UserHead]
                      ,[UserType]
                      ,[UserStatus]
                      ,[RoleId]
                      ,[CreateTime]
                      ,[CreateUser]
                      ,[ModifyTime]
                      ,[ModifyUser]
                      ,[IsDel]
                      ,[Sort]
                FROM [dbo].[adUser]
                WHERE 1=1 And IsDel = 0 {0}
            ", sqlWhere);
            #endregion

            return PetaPocoAdouDB.GetInstance().SingleOrDefault<adUser>(sql, userName, userPwd);
        }
        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <param name="orderBy">排序字段</param>
        /// <param name="isDesc">是否降序</param>
        /// <param name="model">请求实体</param>
        /// <returns>IEnumerable<adUser></returns>
        public IEnumerable<adUser> GetUserList(string orderBy, bool isDesc, adUser model)
        {
            string sqlWhere = string.Empty;
            string sql = string.Empty;

            #region where
            if (!string.IsNullOrWhiteSpace(model.UserName))
            {
                sqlWhere += " AND [UserName] = @0 ";
            }

            if (model.UserType > 0)
            {
                sqlWhere += " AND [UserType] = @1 ";
            }

            if (model.UserStatus > 0)
            {
                sqlWhere += " AND [UserStatus] = @2 ";
            }
            #endregion

            #region sql
            sql = string.Format(@"
                SELECT [Id]
                      ,[UserName]
                      ,[UserPwd]
                      ,[UserHead]
                      ,[UserType]
                      ,[UserStatus]
                      ,[RoleId]
                      ,[CreateTime]
                      ,[CreateUser]
                      ,[ModifyTime]
                      ,[ModifyUser]
                      ,[IsDel]
                      ,[Sort]
                FROM [dbo].[adUser]
                WHERE 1=1 And IsDel = 0 {0}
            ", sqlWhere);
            #endregion

            return this.GetList(orderBy, isDesc, sql, model.UserName, model.UserType, model.UserStatus);
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
        public Page<adUser> GetUserPageList(string orderBy, bool isDesc, int pageIndex, int pageSize, adUser model)
        {
            string sqlWhere = string.Empty;
            string sql = string.Empty;

            #region where
            if (!string.IsNullOrWhiteSpace(model.UserName))
            {
                sqlWhere += " AND [UserName] = @0 ";
            }

            if (model.UserType > 0)
            {
                sqlWhere += " AND [UserType] = @1 ";
            }

            if (model.UserStatus > 0)
            {
                sqlWhere += " AND [UserStatus] = @2 ";
            }
            #endregion

            #region sql
            sql = string.Format(@"
                SELECT [Id]
                      ,[UserName]
                      ,[UserPwd]
                      ,[UserHead]
                      ,[UserType]
                      ,[UserStatus]
                      ,[RoleId]
                      ,[CreateTime]
                      ,[CreateUser]
                      ,[ModifyTime]
                      ,[ModifyUser]
                      ,[IsDel]
                      ,[Sort]
                FROM [dbo].[adUser]
                WHERE 1=1 And IsDel = 0 {0} 
            ", sqlWhere);
            #endregion

            return this.GetPageList(orderBy, isDesc, pageIndex, pageSize, sql, model.UserName, model.UserType, model.UserStatus);
        }
        /// <summary>
        /// 插入用户信息
        /// </summary>
        /// <param name="model">请求实体</param>
        /// <returns>long</returns>
        public long InsertUser(adUser model)
        {
            this.Insert(model);
            return model.Id;
        }
        /// <summary>
        /// 通过编号更新用户信息
        /// </summary>
        /// <param name="model">请求实体</param>
        /// <returns>int</returns>
        public int UpdateUserById(adUser model)
        {
            #region sql
            string sql = string.Format(@"
                SET [UserName] = @0
                    ,[UserPwd] = @1
                    ,[UserHead] = @2
                    ,[UserType] = @3
                    ,[UserStatus] = @4
                    ,[RoleId] = @5
                    ,[ModifyTime] = @6
                    ,[ModifyUser] = @7
                    ,[IsDel] = @8
                    ,[Sort] = @9
                WHERE 1 = 1 AND [Id] = @10
            ");
            #endregion

            return PetaPocoAdouDB.GetInstance().Update<adMenu>(sql,
                model.UserName,
                model.UserPwd,
                model.UserHead,
                model.UserType,
                model.UserStatus,
                model.RoleId,
                model.ModifyTime,
                model.ModifyUser,
                model.IsDel,
                model.Sort,
                model.Id);
        }
        /// <summary>
        /// 通过编号更新用户是否删除（伪删除）
        /// </summary>
        /// <param name="isDel">是否删除</param>
        /// <param name="id">编号</param>
        /// <returns>int</returns>
        public int UpdateUserIsDelById(bool isDel, long id)
        {
            return this.UpdateIsDel(isDel, id);
        }
        /// <summary>
        /// 通过编号删除用户
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns>int</returns>
        public int DeleteUserById(long id)
        {
            return this.Delete(id);
        }
    }
}
