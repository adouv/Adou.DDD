using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adou.Api.Model
{
    public class RequestGetRoleListByUserIdModel:RequestBaseModel
    {
        /// <summary>
        /// 用户编号
        /// </summary>
        public long UserId { get; set; }
    }
}
