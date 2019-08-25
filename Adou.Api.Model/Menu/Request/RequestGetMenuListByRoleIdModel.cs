using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adou.Api.Model
{
    public class RequestGetMenuListByRoleIdModel : RequestBaseModel
    {
        /// <summary>
        /// 角色编号
        /// </summary>
        public long RoleId { get; set; }
    }
}
