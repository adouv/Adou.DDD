using Adou.DDD.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adou.DDD.EntityValidation
{
    /// <summary>
    /// IP地址验证
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    public class IPAttribute : EntityValidationAttribute
    {
        public IPAttribute(MessageType messageType, params object[] args) :
            base(messageType, args) { }
        public override bool IsValid(object value)
        {
            if (value == null)
                return false;
            else
                return ValidationHelper.CheckIP(value.ToString());
        }
    }
}
