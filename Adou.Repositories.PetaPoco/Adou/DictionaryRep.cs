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
    /// 字典数据操作类
    /// </summary>
    public class DictionaryRep : BaseRep<adDictionary>
    {
        /// <summary>
        /// 获取字典项列表
        /// </summary>
        /// <param name="model">请求参数</param>
        /// <returns></returns>
        public IEnumerable<adDictionary> GetDictionaryList(string orderBy, bool isDesc, adDictionary model)
        {
            string sqlWhere = string.Empty;
            string sql = string.Empty;

            #region where
            if (!string.IsNullOrWhiteSpace(model.DicKey))
            {
                sqlWhere += " AND [DicKey] = @0 ";
            }

            if (!string.IsNullOrWhiteSpace(model.DicCoding))
            {
                sqlWhere += " AND [DicCoding] = @1 ";
            }

            if (model.DicType > 0)
            {
                sqlWhere += " AND [DicType] = @2 ";
            }
            #endregion

            #region sql
            sql = string.Format(@"
                SELECT [Id]
                    ,[DicKey]
                    ,[DicValue]
                    ,[DicCoding]
                    ,[DicType]
                    ,[Sort]
                    ,[Remark]
                    ,[IsDel]
                    ,[CreateTime]
                    ,[CreateUser]
                    ,[ModifyTime]
                    ,[ModifyUser]
                FROM [dbo].[adDictionary]
                WHERE 1=1 AND [IsDel] = 0 {0} 
            ", sqlWhere);
            #endregion

            return this.GetList(orderBy, isDesc, sql, model.DicKey, model.DicCoding, model.DicType);
        }
        /// <summary>
        /// 分页获取字典列表
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页条数</param>
        /// <param name="orderBy">排序字段</param>
        /// <param name="isDes">是否倒序</param>
        /// <param name="model">请求实体</param>
        /// <returns></returns>
        public Page<adDictionary> GetDictionaryPageList(int pageIndex, int pageSize, string orderBy, bool isDesc, adDictionary model)
        {
            string sqlWhere = string.Empty;
            string sql = string.Empty;

            #region where
            if (!string.IsNullOrWhiteSpace(model.DicKey))
            {
                sqlWhere += " AND [DicKey] = @0 ";
            }

            if (!string.IsNullOrWhiteSpace(model.DicCoding))
            {
                sqlWhere += " AND [DicCoding] = @1 ";
            }

            if (model.DicType > 0)
            {
                sqlWhere += " AND [DicType] = @2 ";
            }
            #endregion

            #region sql
            sql = string.Format(@"
                SELECT [Id]
                    ,[DicKey]
                    ,[DicValue]
                    ,[DicCoding]
                    ,[DicType]
                    ,[Sort]
                    ,[Remark]
                    ,[IsDel]
                    ,[CreateTime]
                    ,[CreateUser]
                    ,[ModifyTime]
                    ,[ModifyUser]
                FROM [dbo].[adDictionary]
                WHERE 1=1 AND [IsDel] = 0 {0} 
            ", sqlWhere);
            #endregion

            return this.GetPageList(orderBy, isDesc, pageIndex, pageSize, sql, model.DicKey, model.DicCoding, model.DicType);
        }
        /// <summary>
        /// 添加字典
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public long InsertDictionary(adDictionary model)
        {
            this.Insert(model);
            return model.Id;
        }
        /// <summary>
        /// 修改字典
        /// </summary>
        /// <param name="model">请求参数</param>
        /// <returns></returns>
        public long UpdateDictionaryById(adDictionary model)
        {
            string sql = string.Empty;

            #region sql
            sql = string.Format(@"
                SET [DicKey] = @0
                    ,[DicValue] = @1
                    ,[DicCoding] = @2
                    ,[DicType] = @3
                    ,[Sort] = @4
                    ,[Remark] = @5
                    ,[ModifyTime] = @6
                    ,[ModifyUser] = @7
                WHERE 1 = 1 AND [Id] = @8
            ");
            #endregion

            return PetaPocoAdouDB.GetInstance().Update<adDictionary>(sql,
                model.DicKey,
                model.DicValue,
                model.DicCoding,
                model.DicType,
                model.Sort,
                model.Remark,
                model.ModifyTime,
                model.ModifyUser,
                model.Id);
        }
        /// <summary>
        /// 删除字典
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns></returns>
        public int DeleteDictionaryById(long id)
        {
            return this.Delete(id);
        }
        /// <summary>
        /// 伪删除
        /// </summary>
        /// <param name="model">请求实体</param>
        /// <returns></returns>
        public int UpdateDictionaryIsDelById(adDictionary model)
        {
            #region sql
            string sql = string.Format(@"
                SET [IsDel] = @0 ,
                [ModifyTime] = @1,
                [ModifyUser] = @2
                WHERE 1 = 1 AND [Id] = @3
            ");
            #endregion

            return PetaPocoAdouDB.GetInstance().Update<adDictionary>(sql, model.IsDel, model.ModifyTime, model.ModifyUser, model.Id);
        }
    }
}
