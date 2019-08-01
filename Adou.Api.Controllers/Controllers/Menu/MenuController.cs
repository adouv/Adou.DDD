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
        /// 获取菜单服务
        /// </summary>
        public GetMenuByFatherIdService getMenuByFatherIdService { get; set; }
        /// <summary>
        /// 添加菜单服务
        /// </summary>
        public InsertMenuService insertMenuService { get; set; }
        /// <summary>
        /// 通过父级编号获取菜单
        /// </summary>
        /// <param name="model">请求实体</param>
        /// <returns>ResponseMessageModel</returns>
        [Route("GetMenuByFatherId"), HttpPost]
        public async Task<ResponseMessageModel> GetMenuByFatherId([FromBody]RequestMenuModel model)
        {
            return await Task.Run(() => getMenuByFatherIdService.Execute(model));
        }
        /// <summary>
        /// 添加菜单
        /// </summary>
        /// <param name="model">请求实体</param>
        /// <returns>ResponseMessageModel</returns>
        [Route("InsertMenu"), HttpPost]
        public async Task<ResponseMessageModel> InsertMenu([FromBody]RequestMenuModel model)
        {
            return await Task.Run(() => insertMenuService.Execute(model));
        }
    }
}
