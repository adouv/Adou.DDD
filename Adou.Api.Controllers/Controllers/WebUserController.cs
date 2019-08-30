using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http;
using System.Threading.Tasks;
using Adou.Api.Model;
using Adou.Api.Service.AdServices.WebUser;

namespace Adou.Api.Controllers.Controllers
{
    /// <summary>
    /// 用户信息 - 控制器
    /// </summary>
    [RoutePrefix("api/Adou/WebUser")]
    public class WebUserController : BaseController
    {
        /// <summary>
        /// 通过用户名和密码进行用户登录服务
        /// </summary>
        public GetWebUserByUserNameAndUserPwdService getWebUserByUserNameAndUserPwdService { get; set; }
        /// <summary>
        /// 通过用户名和密码进行用户登录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("GetWebUserByUserNameAndUserPwd"), HttpPost]
        public async Task<ResponseMessageModel> GetWebUserByUserNameAndUserPwd([FromBody]RequestGetWebUserByUserNameAndUserPwdModel model)
        {
            return await Task.Run(() => getWebUserByUserNameAndUserPwdService.Execute(model));
        }
        /// <summary>
        /// 获取用户列表服务
        /// </summary>
        public GetWebUserListService getWebUserListService { get; set; }
        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("GetWebUserList"), HttpPost]
        public async Task<ResponseMessageModel> GetWebUserList([FromBody]RequestGetWebUserListModel model)
        {
            return await Task.Run(() => getWebUserListService.Execute(model));
        }
        /// <summary>
        /// 分页获取用户列表服务
        /// </summary>
        public GetWebUserPageListService getWebUserPageListService { get; set; }
        /// <summary>
        /// 分页获取用户列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("GetWebUserPageList"), HttpPost]
        public async Task<ResponseMessageModel> GetWebUserPageList([FromBody]RequestGetWebUserListModel model)
        {
            return await Task.Run(() => getWebUserPageListService.Execute(model));
        }
        /// <summary>
        /// 添加用户服务
        /// </summary>
        public InsertWebUserService insertWebUserService { get; set; }
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("InsertWebUser"), HttpPost]
        public async Task<ResponseMessageModel> InsertWebUser([FromBody]RequestInsertWebUserModel model)
        {
            return await Task.Run(() => insertWebUserService.Execute(model));
        }
        /// <summary>
        /// 通过编号修改用户服务
        /// </summary>
        public UpdateWebUserByIdService updateWebUserByIdService { get; set; }
        /// <summary>
        /// 通过编号修改用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("UpdateWebUserById"), HttpPost]
        public async Task<ResponseMessageModel> UpdateWebUserById([FromBody]RequestUpdateWebUserByIdModel model)
        {
            return await Task.Run(() => updateWebUserByIdService.Execute(model));
        }
        /// <summary>
        /// 通过编号伪删除用户服务
        /// </summary>
        public UpdateWebUserIsDelByIdService updateWebUserIsDelByIdService { get; set; }
        /// <summary>
        /// 通过编号伪删除用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("UpdateWebUserIsDelById"), HttpPost]
        public async Task<ResponseMessageModel> UpdateWebUserIsDelById([FromBody]RequestUpdateWebUserIsDelByIdModel model)
        {
            return await Task.Run(() => updateWebUserIsDelByIdService.Execute(model));
        }
        /// <summary>
        /// 通过编号删除用户服务
        /// </summary>
        public DeleteWebUserByIdService deleteWebUserByIdService { get; set; }
        /// <summary>
        /// 通过编号删除用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("DeleteWebUserById"), HttpPost]
        public async Task<ResponseMessageModel> DeleteWebUserById([FromBody]RequestDeleteWebUserByIdModel model)
        {
            return await Task.Run(() => deleteWebUserByIdService.Execute(model));
        }
    }
}
