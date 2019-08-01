using Adou.Api.Model;

namespace Adou.Api.Service
{
    public abstract class ApiBaseBase<T> : IApi<T>
    {
        /// <summary>
        /// 执行
        /// </summary>
        /// <returns></returns>
        public abstract ResponseMessageModel Execute(T t);
    }
}
