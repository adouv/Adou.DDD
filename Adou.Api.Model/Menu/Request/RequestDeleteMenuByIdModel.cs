using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adou.Api.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class RequestDeleteMenuByIdModel : RequestBaseModel
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int Id { get; set; }
    }
}
