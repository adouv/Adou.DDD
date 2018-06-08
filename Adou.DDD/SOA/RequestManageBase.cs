﻿using Adou.DDD.EntityValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace Adou.DDD.SOA
{
    /// <summary>
    /// 请求体基类
    /// </summary>
    public abstract class RequestManageBase
    {
        /// <summary>
        /// 请求初始化
        /// </summary>
        public RequestManageBase()
        {
            GuidKey = Guid.NewGuid().ToString();
            queuePredicate = i => i.Name != "IsValid"
            && i.Name != "GuidKey"
            && i.GetValue(this) != null;
        }

        /// <summary>
        /// 以属性作为查询条件,去掉为空的属性和公用属性
        /// </summary>
        private Func<PropertyInfo, bool> queuePredicate;

        /// <summary>
        /// 本次请求唯一标示
        /// </summary>
        private string GuidKey { get; set; }

        /// <summary>
        /// 时间戳
        /// </summary>
        [TimesTampAttribute(MessageType.TimesTampField, null, ErrorMessage = "不是有效的时间戳!")]
        public string TimesTamp { get; set; }

        /// <summary>
        /// mac
        /// </summary>
        public string Mac { get; set; }

        /// <summary>
        /// ip
        /// </summary>
        public string Ip { get; set; }

        /// <summary>
        /// 签名
        /// </summary>
        public string Sign { get; set; }

        /// <summary>
        /// 版本
        /// </summary>
        public string Version { get; set; }


        /// <summary>
        /// 当前请求的客户端Token
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// userKey
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "不是有效的UserKey!")]
        public string UserKey { get; set; }
        /// <summary>
        /// 数据验证(是否成功)
        /// 虚属性，子类可以根据自己的逻辑去复写
        /// </summary>
        public virtual bool IsValid
        {
            get
            {
                return this.GetRuleViolations() == null ||
                       this.GetRuleViolations().Count() == 0;
            }
        }


        #region Methods
        /// <summary>
        /// 得到对象的属性，以键值对的方式返回
        /// </summary>
        /// <returns></returns>
        public IEnumerable<KeyValuePair<string, object>> GetProperyiesDictionary()
        {
            var properties = this.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance)
                     .Where(queuePredicate)
                     .ToArray();

            foreach (var i in properties)
                yield return new KeyValuePair<string, object>(i.Name, i.GetValue(this));

        }

        /// <summary>
        /// 获取验证失败的信息枚举,默认提供了非空验证，派生类可以根据自己的需要去复写这个方法
        /// 个性化验证同样使用yield return返回到IEnumberable列表中
        /// 它使用了简单的迭代器,如果GetRuleViolations有错误则返回迭代列表
        /// </summary> 
        /// <returns></returns>
        public IEnumerable<RuleViolation> GetRuleViolations()
        {
            var properties = this.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .Where(queuePredicate)
            .ToArray();

            foreach (var i in properties)
            {
                var attr = i.GetCustomAttributes();
                foreach (var a in attr)
                {
                    var val = (a as ValidationAttribute);
                    if (val != null)
                        if (!val.IsValid(i.GetValue(this)))
                        {
                            yield return new RuleViolation(val.ErrorMessage, i.Name);
                        }
                }
            }

        }

        /// <summary>
        /// 得到由GetRuleViolations()方法产生的验证消息集合
        /// 实际项目中，可以自己去规定，本方法为虚方法，派生类可以重写
        /// </summary>
        /// <returns></returns>
        public virtual string GetRuleViolationMessages()
        {

            if (GetRuleViolations() != null && GetRuleViolations().Count() > 0)
            {
                return string.Join(",", GetRuleViolations().Select(i => i.ToString()));//json序列化时出现问题
            }
            return string.Empty;

        }
        #endregion
    }
}
