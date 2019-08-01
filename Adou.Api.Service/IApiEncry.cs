using Adou.Api.Model;

namespace Adou.Api.Service
{
    interface IApiEncry
    {
        /// <summary>
        /// 执行
        /// </summary>
        /// <returns></returns>
        ResponseMessageModel Execute();

        /// <summary>
        /// 加入提交参数
        /// </summary>
        /// <param name="json"></param>
        //void SetEncryData(RequestModel json);
    }
}
