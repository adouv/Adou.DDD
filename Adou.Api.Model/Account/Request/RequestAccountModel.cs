using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adou.Api.Model
{
    public class RequestAccountModel : RequestBaseModel
    {
        /// <summary>
		/// 编号
		/// </summary>
		 public long Id { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 链接
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 账号
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
       public string Password { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string Mobile { get; set; }
        /// <summary>
        /// 关键词
        /// </summary>
        public string Keyword { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Descript { get; set; }
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
