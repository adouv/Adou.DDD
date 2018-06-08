using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Adou.DDD.Domain
{
    /// <summary>
    /// 主键为int类型的实体基类
    /// </summary
    [Serializable]
    public abstract class Entity:EntityBase
    {                                  
        /// <summary>
        /// 标识列
        /// </summary>
        [DisplayName("编号"), Column("ID"), Required, Key]
        public int Id { get; set; }
    }
}
