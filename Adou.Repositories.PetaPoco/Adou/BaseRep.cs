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
    /// 公用方法
    /// </summary>
    /// <typeparam name="P"></typeparam>
    public class BaseRep<P>
    {
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="orderBy">排序字段</param>
        /// <param name="isDesc">是否降序</param>
        /// <param name="sql">sql语句</param>
        /// <param name="args">参数</param>
        /// <returns>IEnumerable<P</returns>
        public IEnumerable<P> GetList(string orderBy, bool isDesc, string sql, params object[] args)
        {
            string strOrderBy = "";
            if (string.IsNullOrWhiteSpace(orderBy))
            {
                strOrderBy = string.Format(" ORDER BY CreateTime DESC ");
            }
            else
            {
                strOrderBy = string.Format(" ORDER BY {0} {1} ", orderBy, isDesc ? "DESC" : "");
            }

            string strSql = string.Format(@"{0} {1} ", sql, strOrderBy);

            return PetaPocoAdouDB.GetInstance().Query<P>(strSql, args);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        /// <param name="orderBy">排序字段</param>
        /// <param name="isDesc">是否降序</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页条数</param>
        /// <param name="sql">sql语句</param>
        /// <param name="args">参数</param>
        /// <returns>Page<P></returns>

        public Page<P> GetPageList(string orderBy, bool isDesc, int pageIndex, int pageSize, string sql, params object[] args)
        {
            string strOrderBy = "";
            if (string.IsNullOrWhiteSpace(orderBy))
            {
                strOrderBy = string.Format(" ORDER BY CreateTime DESC ");
            }
            else
            {
                strOrderBy = string.Format(" ORDER BY {0} {1} ", orderBy, isDesc ? "DESC" : "");
            }

            string strSql = string.Format(@"{0} {1}", sql, strOrderBy);

            return PetaPocoAdouDB.GetInstance().Page<P>(pageIndex, pageSize, strSql, args);
        }
        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="model">请求实体</param>
        /// <returns>Object</returns>
        public Object Insert(P model)
        {
            return PetaPocoAdouDB.GetInstance().Insert(model);
        }
        /// <summary>
        /// 更新数据状态（伪删除）
        /// </summary>
        /// <param name="isDel">是否删除</param>
        /// <param name="id">编号 自增</param>
        /// <returns>int</returns>
        public int UpdateIsDel(bool isDel, long id)
        {
            #region sql
            string sql = string.Format(@"
                SET [IsDel] = @0 
                WHERE 1 = 1 AND [Id] = @1
            ");
            #endregion

            return PetaPocoAdouDB.GetInstance().Update<P>(sql, isDel, id);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">编号 自增</param>
        /// <returns></returns>
        public int Delete(long id)
        {
            string sql = string.Format(@"
               WHERE 1=1 AND Id = @0
            ");

            return PetaPocoAdouDB.GetInstance().Delete<P>(sql, id);
        }
    }
}
