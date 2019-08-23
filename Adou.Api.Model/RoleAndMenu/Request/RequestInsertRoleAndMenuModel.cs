using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adou.Api.Model
{
    public class RequestInsertRoleAndMenuModel : RequestBaseModel
    {
        /// <summary>
        /// 编号
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// 角色编号
        /// </summary>
        public long RoleId { get; set; }
        /// <summary>
        /// 菜单编号
        /// </summary>
        public long MenuId { get; set; }
    }
}
