using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adou.Api.Model
{
    public class RequestUpdateWebProductByIdModel : RequestBaseModel
    {
        /// <summary>
        /// 编号 自增
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 产品分类
        /// </summary>
        public long? ProductTypeId { get; set; }
        /// <summary>
        /// 品种
        /// </summary>
        public long? VarietyId { get; set; }
        /// <summary>
        /// 规格
        /// </summary>
        public string Specification { get; set; }
        /// <summary>
        /// 几孔
        /// </summary>
        public long? FewHolesId { get; set; }
        /// <summary>
        /// 锌层
        /// </summary>
        public long? ZincLayerId { get; set; }
        /// <summary>
        /// 颜色
        /// </summary>
        public long? ColorId { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public string Quantity { get; set; }
        /// <summary>
        /// 公司名称、用户名称
        /// </summary>
        public string CompanyName { get; set; }
        /// <summary>
        /// 公司编号、用户编号
        /// </summary>
        public long? UserId { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 是否热点
        /// </summary>
        public int? IsHot { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int? Sort { get; set; }
    }
}
