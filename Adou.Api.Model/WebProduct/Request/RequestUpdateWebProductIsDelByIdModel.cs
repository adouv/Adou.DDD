using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adou.Api.Model
{
    public class RequestUpdateWebProductIsDelByIdModel : RequestBaseModel
    {
        /// <summary>
        /// 编号 自增
        /// </summary>
        public long Id { get; set; }
    }
}
