using Adou.DDD.Utils;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace Adou.DDD.SOA
{
    /// <summary>
    /// 返回的相应对象
    /// Result: 分页返回
    /// Result: 集合返回
    /// Result: 实体返回
    /// </summary>
    public class ResponseMessage
    {
        string _serializableFields;
        /// <summary>
        /// 初始化ResponseMessage
        /// </summary>
        public ResponseMessage()
            : this(null)
        { }
        /// <summary>
        /// 初始化ResponseMessage
        /// </summary>
        /// <param name="serializableFields">希望返回的字段</param>
        public ResponseMessage(string serializableFields)
        {
            this._serializableFields = serializableFields;
            this.Status = 100;
            this.GuidKey = Guid.NewGuid().ToString().Replace("-", "");
        }
        /// <summary>
        /// 标示码，与RequestBase里的GuidKey对应
        /// </summary>
        public string GuidKey { get; set; }
        /// <summary>
        /// 状态码
        /// 100成功，200失败
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 业务错误代码
        /// </summary>
        public string MessageCode { get; set; }
        /// <summary>
        /// 错误消息
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 只写属性，返回的对象，它不被序列化，只在服务端内存临时存储
        /// 它通常是一个ReponseBase对象或者集合
        /// </summary>
        [JsonIgnore]
        public Object Body
        {
            set
            {

                if (string.IsNullOrWhiteSpace(_serializableFields))
                    result = value.ToJson();
                else
                    result = value.ToJson(_serializableFields.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList());
            }
        }
        private string result;
        /// <summary>
        /// 只读属性， 根据Body，返回的JSON对象
        /// </summary>
        public string Result
        {
            get
            {
                return result;
            }
            internal set { result = value; }
        }
    }
}
