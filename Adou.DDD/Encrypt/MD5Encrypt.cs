using System.Collections.Generic;
using System.Web.Security;

namespace Adou.DDD.Encrypt
{
    public static class MD5Encrypt
    {
        /// <summary>
        /// MD5数据加密
        /// </summary>
        /// <param name="value">需要加密的字符串</param>
        /// <returns>string</returns>
        public static string MD5(string value)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(value, "MD5");
        }
        /// <summary>
        /// 支付接口拼接sign
        /// </summary>
        /// <param name="dic">支付参数</param>
        /// <param name="key">加密密码</param>
        /// <returns></returns>
        public static string GetSign(SortedDictionary<string, string> dic, string key)
        {
            string sign = "";
            foreach (var item in dic)
            {
                if (!item.Key.Equals("sign") && !item.Key.Equals("sign_type"))
                    sign += item.Key.ToLower() + "=" + item.Value + "&";
            }
            return MD5(sign.Trim('&') + key);
        }
    }
}
