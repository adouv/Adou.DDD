using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adou.Api.Model
{
    /// <summary>
    /// 通过角色编号删除角色菜单
    /// </summary>
    public class RequestDeleteRoleAndMenuByRoleIdModel : RequestBaseModel
    {
        /// <summary>
        /// 编号
        /// </summary>
        public long RoleId { get; set; }
    }
}
