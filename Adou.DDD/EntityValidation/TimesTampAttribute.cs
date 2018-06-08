using Adou.DDD.Utils;
using System;

namespace Adou.DDD.EntityValidation
{
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    public class TimesTampAttribute  : EntityValidationAttribute
    {
        public TimesTampAttribute(MessageType messageType, params object[] args) :
                base(messageType, args)
        { }
        public override bool IsValid(object value)
        {
            if (value == null)
                return false;
            else
                return ValidationHelper.CheckDateTimeFormat(value.ToString());
        }
    }
}
