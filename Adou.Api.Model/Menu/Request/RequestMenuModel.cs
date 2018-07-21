using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adou.Api.Model
{
    public class RequestMenuModel : RequestBaseModel
    {
        /// <summary>
        /// 编号 自增
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 图标
        /// </summary>
        public string MenuIcon { get; set; }
        /// <summary>
        /// 菜单地址
        /// </summary>
        public string MenuUrl { get; set; }

        /// <summary>
        /// 父级编号
        /// </summary>
        public int FatherId { get; set; }
        /// <summary>
        /// 级别
        /// </summary>
        public int LevelId { get; set; }
        /// <summary>
        /// 是否有效 0无效  1有效
        /// </summary>
        public int IstValid { get; set; }
        /// <summary>
        /// 当前页
        /// </summary>
        public int PageIndex { get; set; }
        /// <summary>
        /// 每页条数
        /// </summary>
        public int PageSize { get; set; }
    }
}
