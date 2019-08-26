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
        /// 添加角色，同时添加所拥有的菜单权限
        /// </summary>
        public InsertRoleAndMenuService insertRoleAndMenuService { get; set; }
        /// <summary>
        /// 通过角色编号更新角色，同时更新所拥有的菜单权限
        /// </summary>
        public UpdateRoleAndMenuByIdService updateRoleAndMenuByIdService { get; set; }
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
        /// 添加角色，同时添加所拥有的菜单权限
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("InsertRoleAndMenu"), HttpPost]
        public async Task<ResponseMessageModel> InsertRoleAndMenu([FromBody] RequestInsertRoleAndMenuModel model)
        {
            return await Task.Run(() => insertRoleAndMenuService.Execute(model));
        }
        /// <summary>
        /// 通过角色编号更新角色，同时更新所拥有的菜单权限
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("UpdateRoleAndMenuById"), HttpPost]
        public async Task<ResponseMessageModel> UpdateRoleAndMenuById([FromBody]RequestUpdateRoleAndMenuByIdModel model)
        {
            return await Task.Run(() => updateRoleAndMenuByIdService.Execute(model));
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
