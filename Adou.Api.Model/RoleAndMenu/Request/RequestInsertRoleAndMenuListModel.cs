using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adou.Api.Model
{
    /// <summary>
    /// 批量添加角色菜单
    /// </summary>
    public class RequestInsertRoleAndMenuListModel : RequestBaseModel
    {
        /// <summary>
        /// 角色编号
        /// </summary>
        public long RoleId { get; set; }
        /// <summary>
        /// 菜单编号数组
        /// </summary>
        public int[] MenuArr { get; set; }
    }
}
