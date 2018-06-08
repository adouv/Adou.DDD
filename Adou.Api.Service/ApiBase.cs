using Adou.Api.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Adou.DDD.Logger;

namespace Adou.Api.Service
{
    public abstract class ApiBase<P>
        where P : RequestBaseModel, new()
    {
        //初始化异步锁
        private static SemaphoreSlim _mutex = new SemaphoreSlim(2);
        public ApiBase() {
                           
        }
        /// <summary>
        /// 返回实体
        /// </summary>
        public ResponseMessageModel Result { get; set; }
        public P Parameter { get; set; }
        /// <summary>
        /// 业务实现方法
        /// </summary>
        protected abstract void ExecuteMethod();
        /// <summary>
        /// 验证
        /// </summary>
        protected virtual void Validate()
        {
            //此处执行实体验证MD5
        }
        /// <summary>
        /// 执行
        /// </summary>
        /// <returns></returns>
        public ResponseMessageModel Execute(P model)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            try
            {
                //异步锁等待
                _mutex.Wait();
                this.Parameter = model;
                //执行验证
                if (!string.IsNullOrWhiteSpace(this.Parameter.Sign))
                {
                    this.Validate();
                }
                
                //执行业务方法
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

                StringBuilder DebugeInfo = new StringBuilder();
                //DebugeInfo.Append("Model:" + JsonConvert.SerializeObject(this.model) + "\r\n");
                DebugeInfo.Append("Parameter:" + JsonConvert.SerializeObject(this.Parameter) + "\r\n");
                DebugeInfo.Append("Exception:" + ex.Message + "|" + ex.StackTrace);
                LoggerFactory.Instance.Logger_Debug(DebugeInfo.ToString(), "ExecuteMethodError");
                #endregion
            }
            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            LoggerFactory.Instance.Logger_Info(string.Format("请求花费{0}ms", ts.TotalMilliseconds), "ApiReQuestTime");
            return Result;
        }
    }
}
