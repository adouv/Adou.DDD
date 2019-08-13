using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adou.Api.Model
{
    public class RequestDeleteUserByIdModel : RequestBaseModel
    {
        /// <summary>
        /// 
        /// </summary>
        public long Id { get; set; }
    }
}
