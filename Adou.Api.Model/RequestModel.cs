using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adou.Api.Model
{
    public class RequestModel
    {
        private string guidkey;
        /// <summary>
        /// 标示码
        /// </summary>
        public string GuidKey
        {
            get => guidkey ?? Guid.NewGuid().ToString();
            set => guidkey = value;
        }
        /// <summary>
        /// Json数据
        /// </summary>
        [Required(ErrorMessage = "必须填写")]
        public string Data { get; set; }
    }
}
