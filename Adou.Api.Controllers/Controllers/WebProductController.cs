using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http;
using System.Threading.Tasks;
using Adou.Api.Model;
using Adou.Api.Service.AdServices.WebProduct;

namespace Adou.Api.Controllers.Controllers
{
    /// <summary>
    /// 产品信息 - 控制器
    /// </summary>
    [RoutePrefix("api/Adou/WebProduct")]
    public class WebProductController : BaseController
    {
        /// <summary>
        /// 获取产品列表服务
        /// </summary>
        public GetWebProductListService getWebProductListService { get; set; }
        /// <summary>
        /// 分页获取产品列表服务
        /// </summary>
        public GetWebProductPageListService getWebProductPageListService { get; set; }
        /// <summary>
        /// 添加产品服务
        /// </summary>
        public InsertWebProductService insertWebProductService { get; set; }
        /// <summary>
        /// 通过编号更新产品服务
        /// </summary>
        public UpdateWebProductByIdService updateWebProductByIdService { get; set; }
        /// <summary>
        /// 通过编号伪删除产品服务
        /// </summary>
        public UpdateWebProductIsDelByIdService updateWebProductIsDelByIdService { get; set; }
        /// <summary>
        /// 通过编号删除产品服务
        /// </summary>
        public DeleteWebProductByIdService deleteWebProductByIdService { get; set; }

        /// <summary>
        /// 获取产品列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("GetWebProductList"), HttpPost]
        public async Task<ResponseMessageModel> GetWebProductList([FromBody]RequestGetWebProductListModel model)
        {
            return await Task.Run(() => getWebProductListService.Execute(model));
        }
        /// <summary>
        /// 分页获取产品列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("GetWebProductPageList"), HttpPost]
        public async Task<ResponseMessageModel> GetWebProductPageList([FromBody]RequestGetWebProductListModel model)
        {
            return await Task.Run(() => getWebProductPageListService.Execute(model));
        }
        /// <summary>
        /// 添加产品
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("InsertWebProduct"), HttpPost]
        public async Task<ResponseMessageModel> InsertWebProduct([FromBody]RequestInsertWebProductModel model)
        {
            return await Task.Run(() => insertWebProductService.Execute(model));
        }
        /// <summary>
        /// 通过编号更新产品
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("UpdateWebProductById"), HttpPost]
        public async Task<ResponseMessageModel> UpdateWebProductById([FromBody]RequestUpdateWebProductByIdModel model)
        {
            return await Task.Run(() => updateWebProductByIdService.Execute(model));
        }
        /// <summary>
        /// 通过编号伪删除产品
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("UpdateWebProductIsDelById"), HttpPost]
        public async Task<ResponseMessageModel> UpdateWebProductIsDelById([FromBody]RequestUpdateWebProductIsDelByIdModel model)
        {
            return await Task.Run(() => updateWebProductIsDelByIdService.Execute(model));
        }
        /// <summary>
        /// 通过编号删除产品
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("DeleteWebProductById"), HttpPost]
        public async Task<ResponseMessageModel> DeleteWebProductById([FromBody]RequestDeleteWebProductByIdModel model)
        {
            return await Task.Run(() => deleteWebProductByIdService.Execute(model));
        }
    }
}
