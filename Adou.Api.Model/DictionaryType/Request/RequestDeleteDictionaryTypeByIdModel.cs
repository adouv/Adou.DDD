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
    public class RequestDeleteDictionaryTypeByIdModel : RequestBaseModel
    {
        /// <summary>
        /// 编号
        /// </summary>
        public long Id { get; set; }
    }
}
