using Adou.Api.Model;
using Adou.Api.Service.AdServices.User;
using System.Threading.Tasks;
using System.Web.Http;

namespace Adou.Api.Controllers.Controllers
{
    /// <summary>
    /// 用户信息 - 控制器
    /// </summary>
    [RoutePrefix("api/Adou/User")]
    public class UserController : BaseController
    {
        /// <summary>
        /// 获取用户列表服务
        /// </summary>
        public GetUserListService getUserListService { get; set; }
        /// <summary>
        /// 分页获取用户列表服务
        /// </summary>
        public GetUserPageListService getUserPageListService { get; set; }
        /// <summary>
        /// 用户登录服务
        /// </summary>
        public UserLoginService userLoginService { get; set; }
        /// <summary>
        /// 添加用户服务
        /// </summary>
        public InsertUserService insertUserService { get; set; }
        /// <summary>
        /// 通过编号更新用户服务
        /// </summary>
        public UpdateUserByIdService updateUserByIdService { get; set; }
        /// <summary>
        /// 通过编号删除用户服务
        /// </summary>
        public DeleteUserByIdService deleteUserByIdService { get; set; }
        /// <summary>
        /// 通过编号更新用户是否删除状态服务（伪删除）
        /// </summary>
        public UpdateUserIsDelByIdService updateUserIsDelByIdService { get; set; }

        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("GetUserList"), HttpPost]
        public async Task<ResponseMessageModel> GetUserList([FromBody]RequestGetUserListModel model)
        {
            return await Task.Run(() => getUserListService.Execute(model));
        }
        /// <summary>
        /// 分页获取用户列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("GetUserPageList"), HttpPost]
        public async Task<ResponseMessageModel> GetUserPageList([FromBody]RequestGetUserListModel model)
        {
            return await Task.Run(() => getUserPageListService.Execute(model));
        }
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("UserLogin"), HttpPost]
        public async Task<ResponseMessageModel> UserLogin([FromBody]RequestUserLoginModel model)
        {
            return await Task.Run(() => userLoginService.Execute(model));
        }
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("InsertUser"), HttpPost]
        public async Task<ResponseMessageModel> InsertUser([FromBody]RequestInsertUserModel model)
        {
            return await Task.Run(() => insertUserService.Execute(model));
        }
        /// <summary>
        /// 通过编号更新用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("UpdateUserById"), HttpPost]
        public async Task<ResponseMessageModel> UpdateUserById([FromBody]RequestUpdateUserByIdModel model)
        {
            return await Task.Run(() => updateUserByIdService.Execute(model));
        }
        /// <summary>
        /// 通过编号删除用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("DeleteUserById"), HttpPost]
        public async Task<ResponseMessageModel> DeleteUserById([FromBody]RequestDeleteUserByIdModel model)
        {
            return await Task.Run(() => deleteUserByIdService.Execute(model));
        }
        /// <summary>
        /// 通过编号更新用户是否删除状态（伪删除）
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("UpdateUserIsDelById"), HttpPost]
        public async Task<ResponseMessageModel> UpdateUserIsDelById([FromBody]RequestUpdateUserIsDelByIdModel model)
        {
            return await Task.Run(() => updateUserIsDelByIdService.Execute(model));
        }
    }
}
