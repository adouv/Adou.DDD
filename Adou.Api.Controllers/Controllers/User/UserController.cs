using Adou.Api.Model;
using Adou.Api.Service.AdServices.User;
using System.Threading.Tasks;
using System.Web.Http;

namespace Adou.Api.Controllers.Controllers.User
{
    /// <summary>
    /// 用户信息 - 控制器
    /// </summary>
    [RoutePrefix("api/Adou/User")]
    public class UserController: BaseController
    {
        /// <summary>
        /// 用户登录 - 服务 
        /// </summary>
        public UserLoginService userLoginService { get; set; }
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="model">请求实体</param>
        /// <returns>ResponseMessageModel</returns>      
        [Route("UserLogin"), HttpPost]
        public async Task<ResponseMessageModel> UserLogin([FromBody]RequestUserLoginModel model)
        {
            return await Task.Run(() => userLoginService.Execute(model));
        }
    }
}
