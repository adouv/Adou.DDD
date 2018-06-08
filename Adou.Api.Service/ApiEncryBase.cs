using Adou.DDD.Logger;
using Adou.Api.Model;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Threading;
using System.Text;

namespace Adou.Api.Service
{
    /// <summary>
    /// api统一抽象基类
    /// </summary>
    /// <typeparam name="P"></typeparam>
    public abstract class ApiEncryBase<P> : IApiEncry
        where P : RequestBaseModel, new()
    {
        //初始化异步锁
        private static SemaphoreSlim _mutex = new SemaphoreSlim(2);
        public ApiEncryBase()
        {
        }
        /// <summary>
        /// 返回实体
        /// </summary>
        public ResponseMessageModel Result { get; set; }
        /// <summary>
        /// 请求实体
        /// </summary>
        public RequestModel model { get; private set; }
        /// <summary>
        /// 提交业务参数
        /// </summary>
        public P Parameter { get; private set; }
        /// <summary>
        /// 业务实现方法
        /// </summary>
        protected abstract void ExecuteMethod();
        /// <summary>
        /// 赋值提交的实体数据
        /// </summary>
        /// <param name="json">Json字符串</param>
        public virtual void SetEncryData(RequestModel json)
        {
            model = json;
        }
        /// <summary>
        /// 验证
        /// </summary>
        protected virtual void Validate()
        {
           this.Parameter = JsonConvert.DeserializeObject<P>(model.Data);
        }
        /// <summary>
        /// 获取MySign
        /// </summary>
        /// <returns>String</returns>
        private string GetMySign() {
            string mySign = "";
            return mySign;
        }
        /// <summary>
        /// 执行
        /// </summary>
        /// <returns></returns>
        public ResponseMessageModel Execute() {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            try
            {
                //执行验证
                if (model != null)
                {
                    this.Validate();
                }
                //异步锁等待
                _mutex.WaitAsync();
                //执行业务逻辑
                this.ExecuteMethod();
            }
            catch (Exception ex)
            {
                LoggerFactory.Instance.Logger_Error(ex, "ExecuteMethodError");

                #region 异常处理
                string code = string.Empty;
                if (ex.Message.Contains("|"))
                {
                    code = ex.Message.Split('|')[0].ToString();
                }
                else
                {
                    code = "9999";
                }
                this.Result.Data = null;
                this.Result.ErrorCode = code;
                this.Result.Message = ex.Message;
                this.Result.IsSuccess = false;
                #endregion

                #region 日志
                StringBuilder DebugeInfo = new StringBuilder();
                DebugeInfo.Append("Model:" + JsonConvert.SerializeObject(this.model) + "\r\n");
                DebugeInfo.Append("Parameter:" + JsonConvert.SerializeObject(this.Parameter) + "\r\n");
                DebugeInfo.Append("Exception:" + ex.Message + "|" + ex.StackTrace);
                LoggerFactory.Instance.Logger_Debug(DebugeInfo.ToString(), "ExecuteMethodError");

                //var addLogger = new AddMongoLoggerEvent() {
                //    GuidKey = model.GuidKey,
                //    ActionNmae = "未知",
                //    Mesasge = ex.Message,
                //    Code = code,
                //    StackTrace = code == "9999" ? ex.StackTrace : "",
                //    CreateTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")
                //};
                //EventBus.Instance.PublishAsync(addLogger);
                #endregion
            }
            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            LoggerFactory.Instance.Logger_Info(string.Format("请求花费{0}ms", ts.TotalMilliseconds), "ApiReQuestTime");
            return Result;
        }
    }
}
