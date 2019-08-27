using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adou.Api.Model
{
    /// <summary>
    /// 添加角色，同时添加所拥有的菜单权限
    /// </summary>
    public class RequestInsertRoleAndMenuModel : RequestBaseModel
    {
        /// <summary>
        /// 编号
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }
        /// <summary>
        /// 菜单编号数组
        /// </summary>
        public int[] menuArr { get; set; }
    }
}
