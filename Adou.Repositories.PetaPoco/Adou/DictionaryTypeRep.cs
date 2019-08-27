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
    /// 数据字典项操作类
    /// </summary>
    public class DictionaryTypeRep : BaseRep<adDictionaryType>
    {
        /// <summary>
        /// 获取字典项列表
        /// </summary>
        /// <param name="model">请求参数</param>
        /// <returns></returns>
        public IEnumerable<adDictionaryType> GetDictionaryTypeList(string orderBy, bool isDesc, adDictionaryType model)
        {
            string sqlWhere = string.Empty;
            string sql = string.Empty;

            #region where
            if (!string.IsNullOrWhiteSpace(model.Name))
            {
                sqlWhere += " AND [Name] = @0 ";
            }

            if (!string.IsNullOrWhiteSpace(model.Coding))
            {
                sqlWhere += " AND [Coding] = @1 ";
            }
            #endregion

            #region sql
            sql = string.Format(@"
                SELECT [Id]
                    ,[Coding]
                    ,[Name]
                    ,[Sort]
                    ,[Remark]
                    ,[IsDel]
                    ,[CreateTime]
                    ,[CreateUser]
                    ,[ModifyTime]
                    ,[ModifyUser]
                FROM [dbo].[adDictionaryType]
                WHERE 1=1 AND [IsDel] = 0 {0} 
            ", sqlWhere);
            #endregion

            return this.GetList(orderBy, isDesc, sql, model.Name, model.Coding);
        }
        /// <summary>
        /// 分页获取字典项列表
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页条数</param>
        /// <param name="orderBy">排序字段</param>
        /// <param name="isDes">是否倒序</param>
        /// <param name="model">请求实体</param>
        /// <returns></returns>
        public Page<adDictionaryType> GetDictionaryTypePageList(int pageIndex, int pageSize, string orderBy, bool isDesc, adDictionaryType model)
        {
            string sqlWhere = string.Empty;
            string sql = string.Empty;

            #region where
            if (!string.IsNullOrWhiteSpace(model.Name))
            {
                sqlWhere += " AND [Name] = @0 ";
            }

            if (!string.IsNullOrWhiteSpace(model.Coding))
            {
                sqlWhere += " AND [Coding] = @1 ";
            }
            #endregion

            #region sql
            sql = string.Format(@"
                SELECT [Id]
                    ,[Coding]
                    ,[Name]
                    ,[Sort]
                    ,[Remark]
                    ,[IsDel]
                    ,[CreateTime]
                    ,[CreateUser]
                    ,[ModifyTime]
                    ,[ModifyUser]
                FROM [dbo].[adDictionaryType]
                WHERE 1=1 AND [IsDel] = 0 {0} 
            ", sqlWhere);
            #endregion

            return this.GetPageList(orderBy, isDesc, pageIndex, pageSize, sql, model.Name, model.Coding);
        }
        /// <summary>
        /// 添加字典项
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public long InsertDictionaryType(adDictionaryType model)
        {
            this.Insert(model);
            return model.Id;
        }
        /// <summary>
        /// 修改字典项
        /// </summary>
        /// <param name="model">请求参数</param>
        /// <returns></returns>
        public long UpdateDictionaryTypeById(adDictionaryType model)
        {
            string sql = string.Empty;

            #region sql
            sql = string.Format(@"
                SET [Coding] = @0
                    ,[Name] = @1
                    ,[Sort] = @2
                    ,[Remark] = @3
                    ,[ModifyTime] = @4
                    ,[ModifyUser] = @5
                WHERE 1 = 1 AND [Id] = @6
            ");
            #endregion

            return PetaPocoAdouDB.GetInstance().Update<adDictionaryType>(sql,
                model.Coding,
                model.Name,
                model.Sort,
                model.Remark,
                model.ModifyTime,
                model.ModifyUser,
                model.Id);
        }
        /// <summary>
        /// 删除字典项
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns></returns>
        public int DeleteDictionaryTypeById(long id)
        {
            return this.Delete(id);
        }
        /// <summary>
        /// 伪删除
        /// </summary>
        /// <param name="model">请求实体</param>
        /// <returns></returns>
        public int UpdateDictionaryTypeIsDelById(adDictionaryType model)
        {
            #region sql
            string sql = string.Format(@"
                SET [IsDel] = @0 ,
                [ModifyTime] = @1,
                [ModifyUser] = @2
                WHERE 1 = 1 AND [Id] = @3
            ");
            #endregion

            return PetaPocoAdouDB.GetInstance().Update<adDictionaryType>(sql, model.IsDel, model.ModifyTime, model.ModifyUser, model.Id);
        }
    }
}
