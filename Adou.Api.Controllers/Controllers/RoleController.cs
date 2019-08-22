using Adou.Api.Model;
using Adou.Api.Service.AdServices.Role;
using System.Threading.Tasks;
using System.Web.Http;

namespace Adou.Api.Controllers.Controllers
{
    /// <summary>
    /// 角色信息 - 控制器
    /// </summary>
    [RoutePrefix("api/Adou/Role")]
    public class RoleController : BaseController
    {
        /// <summary>
        /// 获取角色列表服务
        /// </summary>
        public GetRoleListService getRoleListService { get; set; }
        /// <summary>
        /// 分页获取角色列表服务
        /// </summary>
        public GetRolePageListService getRolePageListService { get; set; }
        /// <summary>
        /// 通过用户编号获取角色列表服务
        /// </summary>
        public GetRoleListByUserIdService getRoleListByUserIdService { get; set; }
        /// <summary>
        /// 添加角色服务
        /// </summary>
        public InsertRoleService insertRoleService { get; set; }
        /// <summary>
        /// 通过编号更新角色服务
        /// </summary>
        public UpdateRoleByIdService updateRoleByIdService { get; set; }
        /// <summary>
        /// 通过编号更新角色删除状态服务
        /// </summary>
        public UpdateRoleIsDelByIdService updateRoleIsDelByIdService { get; set; }
        /// <summary>
        /// 通过编号删除角色服务
        /// </summary>
        public DeleteRoleByIdService deleteRoleByIdService { get; set; }


        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("GetRoleList"), HttpPost]
        public async Task<ResponseMessageModel> GetRoleList([FromBody]RequestGetRoleListModel model)
        {
            return await Task.Run(() => getRoleListService.Execute(model));
        }
        /// <summary>
        /// 分页获取用户列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("GetRolePageList"), HttpPost]
        public async Task<ResponseMessageModel> GetRolePageList([FromBody]RequestGetRoleListModel model)
        {
            return await Task.Run(() => getRolePageListService.Execute(model));
        }
        /// <summary>
        /// 通过用户编号获取角色列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("GetRoleListByUserId"), HttpPost]
        public async Task<ResponseMessageModel> GetRoleListByUserId([FromBody]RequestGetRoleListByUserIdModel model)
        {
            return await Task.Run(() => getRoleListByUserIdService.Execute(model));
        }
        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("InsertRole"), HttpPost]
        public async Task<ResponseMessageModel> InsertRole([FromBody] RequestInsertRoleModel model)
        {
            return await Task.Run(() => insertRoleService.Execute(model));
        }
        /// <summary>
        /// 通过编号更新角色
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("UpdateRoleById"), HttpPost]
        public async Task<ResponseMessageModel> UpdateRoleById([FromBody]RequestUpdateRoleByIdModel model)
        {
            return await Task.Run(() => updateRoleByIdService.Execute(model));
        }
        /// <summary>
        /// 通过编号删除角色
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("DeleteRoleById"), HttpPost]
        public async Task<ResponseMessageModel> DeleteRoleById([FromBody]RequestDeleteRoleByIdModel model)
        {
            return await Task.Run(() => deleteRoleByIdService.Execute(model));
        }
        /// <summary>
        /// 通过编号更新角色删除状态（伪删除）
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("UpdateRoleIsDelById"), HttpPost]
        public async Task<ResponseMessageModel> UpdateRoleIsDelById([FromBody]RequestUpdateRoleIsDelByIdModel model)
        {
            return await Task.Run(() => updateRoleIsDelByIdService.Execute(model));
        }
    }
}
