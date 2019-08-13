using Adou.Api.Model;
using Adou.Api.Service.AdServices.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Adou.Api.Controllers.Controllers.Menu
{
    /// <summary>
    /// 菜单信息 - 控制器
    /// </summary>
    [RoutePrefix("api/Adou/Menu")]
    public class MenuController : BaseController
    {
        /// <summary>
        /// 通过父级编号获取菜单列表服务
        /// </summary>
        public GetMenuListByFatherIdService getMenuListByFatherIdService { get; set; }
        /// <summary>
        /// 获取菜单列表服务
        /// </summary>
        public GetMenuListService getMenuListService { get; set; }
        /// <summary>
        /// 获取单个菜单信息服务
        /// </summary>
        public GetSingleMenuByFatherIdService getSingleMenuByFatherIdService { get; set; }
        /// <summary>
        /// 添加菜单服务
        /// </summary>
        public InsertMenuService insertMenuService { get; set; }
        /// <summary>
        /// 更新菜单
        /// </summary>
        public UpdateMenuByIdService updateMenuByIdService { get; set; }
        /// <summary>
        /// 通过编号更新菜单排序服务
        /// </summary>
        public UpdateMenuSortByIdService updateMenuSortByIdService { get; set; }
        /// <summary>
        /// 通过编号删除菜单服务
        /// </summary>
        public DeleteMenuByIdService deleteMenuByIdService { get; set; }
        /// <summary>
        /// 获取菜单列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("GetMenuList"), HttpPost]
        public async Task<ResponseMessageModel> GetMenuList([FromBody]RequestGetMenuListModel model)
        {
            return await Task.Run(() => getMenuListService.Execute(model));
        }
        /// <summary>
        /// 通过父级编号获取菜单列表
        /// </summary>
        /// <param name="model">请求实体</param>
        /// <returns>ResponseMessageModel</returns>
        [Route("GetMenuListByFatherId"), HttpPost]
        public async Task<ResponseMessageModel> GetMenuListByFatherId([FromBody]RequestGetMenuListModel model)
        {
            return await Task.Run(() => getMenuListByFatherIdService.Execute(model));
        }
        /// <summary>
        /// 获取单个菜单信息
        /// </summary>
        /// <param name="model">请求实体</param>
        /// <returns></returns>
        [Route("GetSingleMenuByFatherId"), HttpPost]
        public async Task<ResponseMessageModel> GetSingleMenuByFatherId([FromBody]RequestGetMenuListModel model)
        {
            return await Task.Run(() => getSingleMenuByFatherIdService.Execute(model));
        }
        /// <summary>
        /// 添加菜单
        /// </summary>
        /// <param name="model">请求实体</param>
        /// <returns>ResponseMessageModel</returns>
        [Route("InsertMenu"), HttpPost]
        public async Task<ResponseMessageModel> InsertMenu([FromBody]RequestInsertMenuModel model)
        {
            return await Task.Run(() => insertMenuService.Execute(model));
        }
        /// <summary>
        /// 通过编号修改菜单
        /// </summary>
        /// <param name="model">请求实体</param>
        /// <returns>ResponseMessageModel</returns>
        [Route("UpdateMenuById"), HttpPost]
        public async Task<ResponseMessageModel> UpdateMenuById([FromBody]RequestUpdateMenuByIdModel model)
        {
            return await Task.Run(() => updateMenuByIdService.Execute(model));
        }
        /// <summary>
        /// 通过编号更新菜单排序
        /// </summary>
        /// <param name="model">请求实体</param>
        /// <returns>ResponseMessageModel</returns>
        [Route("UpdateMenuSortById"), HttpPost]
        public async Task<ResponseMessageModel> UpdateMenuSortById([FromBody]RequestUpdateMenuSortByIdModel model)
        {
            return await Task.Run(() => updateMenuSortByIdService.Execute(model));
        }
        /// <summary>
        /// 通过编号删除菜单
        /// </summary>
        /// <param name="model">请求实体</param>
        /// <returns>ResponseMessageModel</returns>
        [Route("DeleteMenuById"), HttpPost]
        public async Task<ResponseMessageModel> DeleteMenuById([FromBody]RequestDeleteMenuByIdModel model)
        {
            return await Task.Run(() => deleteMenuByIdService.Execute(model));
        }
    }
}
