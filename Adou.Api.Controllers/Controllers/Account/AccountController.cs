using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks;
using System.Web.Http;
using Adou.Api.Model;
using Adou.Api.Service.AdServices.Account;

namespace Adou.Api.Controllers.Controllers.Account
{
    /// <summary>
    /// 账户信息 - 控制器
    /// </summary>
    [RoutePrefix("api/Adou/Account")]
    public class AccountController : BaseController
    {
        /// <summary>
        /// 添加账户
        /// </summary>
        public InsertAccountService insertAccountService { get; set; }
        /// <summary>
        /// 获取账户列表
        /// </summary>
        public GetAccountListService getAccountService { get; set; }
        /// <summary>
        /// 添加账户
        /// </summary>
        /// <param name="model">请求实体</param>
        /// <returns>ResponseMessageModel</returns>
        [Route("InsertAccount"), HttpPost]
        public async Task<ResponseMessageModel> InsertMenu([FromBody]RequestAccountModel model)
        {
            return await Task.Run(() => insertAccountService.Execute(model));
        }
        /// <summary>
        /// 获取账户列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("GetAccountList"), HttpPost]
        public async Task<ResponseMessageModel> GetAccountList([FromBody]RequestAccountModel model)
        {
            return await Task.Run(() => getAccountService.Execute(model));
        }
    }
}
