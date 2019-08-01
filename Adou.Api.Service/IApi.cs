using Adou.Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adou.Api.Service
{
    interface IApi<T>
    {
        /// <summary>
        /// 执行
        /// </summary>
        /// <returns></returns>
        ResponseMessageModel Execute(T t);
        /// <summary>
        /// 加入提交参数
        /// </summary>
        /// <param name="json"></param>
        // void SetData<P>(P json);
    }
}
