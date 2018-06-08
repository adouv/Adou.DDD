namespace Adou.DDD.SOA
{
    /// <summary>
    /// 响应体基类
    /// </summary>
    public abstract class ResponseBase
    {
        /// <summary>
        /// 标示码，与RequestBase里的GuidKey对应
        /// </summary>
        public string GuidKey { get; set; }
        /// <summary>
        /// 相应的字段
        /// </summary>
        public string SerializableFields { get; set; }
        /// <summary>
        /// 初始化ResponseMessage
        /// </summary>
        public ResponseBase()
            : this(null)
        { }
        /// <summary>
        /// 初始化ResponseMessage
        /// </summary>
        /// <param name="serializableFields">希望返回的字段</param>
        public ResponseBase(string serializableFields)
        {
            this.SerializableFields = serializableFields;
        }
    }
}
