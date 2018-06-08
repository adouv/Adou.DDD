namespace Adou.DDD.SOA
{
    /// <summary>
    /// 接口返回信息
    /// </summary>
    public class ResponseManageMessage
    {
        /// <summary>
        /// 构造方法
        /// </summary>
        public ResponseManageMessage()
        {
            ErrorCode = "0000";
            IsSuccess = true;
            Message = "成功";
        }


        /// <summary>
        /// 商户id
        /// </summary>
        public string MerchantId { get; set; }

        /// <summary>
        /// 数据
        /// </summary>
        public string Data { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        public string ErrorCode { get; set; }

        /// <summary>
        /// 是否成功
        /// </summary>
        public bool IsSuccess { get; set; }
    }
}
