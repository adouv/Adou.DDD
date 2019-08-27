using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adou.Api.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class RequestGetDictionaryListModel : RequestBaseModel
    {
        /// <summary>
        /// 编号
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// 键
        /// </summary>
        public string DicKey { get; set; }
        /// <summary>
        /// 值
        /// </summary>
        public string DicValue { get; set; }
        /// <summary>
        /// 编码
        /// </summary>
        public string DicCoding { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public long DicType { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDel { get; set; }
        /// <summary>
        /// 当前页
        /// </summary>
        public int PageIndex { get; set; }
        /// <summary>
        /// 每页条数
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// 排序字段
        /// </summary>
        public string OrderBy { get; set; }
        /// <summary>
        /// 是否降序
        /// </summary>
        public bool IsDesc { get; set; }
    }
}
