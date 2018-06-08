using Adou.Api.Model;
using Adou.Api.Service.AdServices.Account;
using System.Threading.Tasks;
using System.Web.Http;

namespace Adou.Api.Controllers
{
    /// <summary>
    /// 账户信息
    /// </summary>
    [RoutePrefix("api/Adou/Account")]
    public class AccountController: BaseController
    {
        /// <summary>
        /// 账户信息列表 - 服务
        /// </summary>
        public GetAccountListService getAccountListService { get; set; }
        /// <summary>
        /// 账户信息列表
        /// </summary>
        /// <param name="model">请求实体</param>
        /// <returns>ResponseMessageModel</returns>   
        [Route("GetAccountList"), HttpPost]
        public async Task<ResponseMessageModel> GetAccountList([FromBody]RequestAccountListModel model)
        {
            //getAccountListService.SetData(model);
            return await Task.Run(() => getAccountListService.Execute(model));
        }
    }
}
