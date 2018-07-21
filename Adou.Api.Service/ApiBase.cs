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
        private static SemaphoreSlim _mutex = new SemaphoreSlim(10);
        public ApiBase()
        { }
        /// <summary>
        /// 返回实体
        /// </summary>
        public ResponseMessageModel Result { get; set; }
        /// <summary>
        /// 参数
        /// </summary>
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
            var timeSpan = new TimeSpan(0, 5, 0);
            _mutex.Wait(timeSpan);
            try
            {
                //接收参数
                this.Parameter = model;
                //执行验证
                this.Validate();
                //执行业务方法
                this.ExecuteMethod();
            }
            catch (Exception ex)
            {
                #region 异常处理
                this.Result.Data = null;
                this.Result.ErrorCode = "9999";
                this.Result.Message = ex.Message;
                this.Result.IsSuccess = false;

                StringBuilder DebugeInfo = new StringBuilder();
                DebugeInfo.Append("Parameter:" + JsonConvert.SerializeObject(this.Parameter) + "\r\n");
                DebugeInfo.Append("Exception:" + ex.Message + "|" + ex.StackTrace + "\r\n");
                LoggerFactory.Instance.Logger_Debug(DebugeInfo.ToString(), "ExecuteMethodError");
                #endregion
            }
            //异步锁释放
            _mutex.Release();
            return Result;
        }
    }
}
