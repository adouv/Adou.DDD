﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adou.Api.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class RequestUpdateDictionaryByIdModel : RequestBaseModel
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
    }
}
