using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http;
using System.Threading.Tasks;
using Adou.Api.Model;
using Adou.Api.Service.AdServices.Dictionary;


namespace Adou.Api.Controllers.Controllers
{
    /// <summary>
    /// 字典信息 - 控制器
    /// </summary>
    [RoutePrefix("api/Adou/Dictionary")]
    public class DictionaryController : BaseController
    {
        /// <summary>
        /// 获取字典列表服务
        /// </summary>
        public GetDictionaryListService getDictionaryListService { get; set; }
        /// <summary>
        /// 分页获取字典列表服务
        /// </summary>
        public GetDictionaryPageListService getDictionaryPageListService { get; set; }
        /// <summary>
        /// 添加字典服务
        /// </summary>
        public InsertDictionaryService insertDictionaryService { get; set; }
        /// <summary>
        /// 通过编号更新字典服务
        /// </summary>
        public UpdateDictionaryByIdService updateDictionaryByIdService { get; set; }
        /// <summary>
        /// 伪删除服务
        /// </summary>
        public UpdateDictionaryIsDelByIdService updateDictionaryIsDelByIdService { get; set; }
        /// <summary>
        /// 通过编号删除字典服务
        /// </summary>
        public DeleteDictionaryByIdService deleteDictionaryByIdService { get; set; }

        /// <summary>
        /// 获取字典列表
        /// </summary>
        /// <param name="model">请求实体</param>
        /// <returns></returns>
        [Route("GetDictionaryList"), HttpPost]
        public async Task<ResponseMessageModel> GetDictionaryList([FromBody]RequestGetDictionaryListModel model)
        {
            return await Task.Run(() => getDictionaryListService.Execute(model));
        }
        /// <summary>
        /// 分页获取字典列表
        /// </summary>
        /// <param name="model">请求实体</param>
        /// <returns></returns>
        [Route("GetDictionaryPageList"), HttpPost]
        public async Task<ResponseMessageModel> GetDictionaryPageList([FromBody]RequestGetDictionaryListModel model)
        {
            return await Task.Run(() => getDictionaryPageListService.Execute(model));
        }
        /// <summary>
        /// 添加字典
        /// </summary>
        /// <param name="model">请求实体</param>
        /// <returns></returns>
        [Route("InsertDictionary"), HttpPost]
        public async Task<ResponseMessageModel> InsertDictionary([FromBody]RequestInsertDictionaryModel model)
        {
            return await Task.Run(() => insertDictionaryService.Execute(model));
        }
        /// <summary>
        /// 通过编号更新字典
        /// </summary>
        /// <param name="model">请求实体</param>
        /// <returns></returns>
        [Route("UpdateDictionaryById"), HttpPost]
        public async Task<ResponseMessageModel> UpdateDictionaryById([FromBody]RequestUpdateDictionaryByIdModel model)
        {
            return await Task.Run(() => updateDictionaryByIdService.Execute(model));
        }
        /// <summary>
        /// 伪删除
        /// </summary>
        /// <param name="model">请求实体</param>
        /// <returns></returns>
        [Route("UpdateDictionaryIsDelById"), HttpPost]
        public async Task<ResponseMessageModel> UpdateDictionaryIsDelById([FromBody]RequestUpdateDictionaryIsDelByIdModel model)
        {
            return await Task.Run(() => updateDictionaryIsDelByIdService.Execute(model));
        }
        /// <summary>
        /// 通过编号删除字典
        /// </summary>
        /// <param name="model">请求实体</param>
        /// <returns></returns>
        [Route("DeleteDictionaryById"), HttpPost]
        public async Task<ResponseMessageModel> DeleteDictionaryById([FromBody]RequestDeleteDictionaryByIdModel model)
        {
            return await Task.Run(() => deleteDictionaryByIdService.Execute(model));
        }
    }
}
