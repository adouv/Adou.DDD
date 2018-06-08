using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adou.Api.Model
{
    public class RequestUserLoginModel : RequestBaseModel
    {
        /// <summary>
        /// 登录名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 登录密码
        /// </summary>
        public string UserPwd { get; set; }
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
