using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http;
using System.Threading.Tasks;
using Adou.Api.Model;
using Adou.Api.Service.AdServices.DictionaryType;

namespace Adou.Api.Controllers.Controllers
{
    /// <summary>
    /// 字典项信息 - 控制器
    /// </summary>
    [RoutePrefix("api/Adou/DictionaryType")]
    public class DictionaryTypeController : BaseController
    {
        /// <summary>
        /// 获取字典项列表服务
        /// </summary>
        public GetDictionaryTypeListService getDictionaryTypeListService { get; set; }
        /// <summary>
        /// 分页获取字典项列表服务
        /// </summary>
        public GetDictionaryTypePageListService getDictionaryTypePageListService { get; set; }
        /// <summary>
        /// 添加字典项服务
        /// </summary>
        public InsertDictionaryTypeService insertDictionaryTypeService { get; set; }
        /// <summary>
        /// 通过编号更新字典项服务
        /// </summary>
        public UpdateDictionaryTypeByIdService updateDictionaryTypeByIdService { get; set; }
        /// <summary>
        /// 伪删除服务
        /// </summary>
        public UpdateDictionaryTypeIsDelByIdService updateDictionaryTypeIsDelByIdService { get; set; }
        /// <summary>
        /// 通过编号删除字典项服务
        /// </summary>
        public DeleteDictionaryTypeByIdService deleteDictionaryTypeByIdService { get; set; }

        /// <summary>
        /// 获取字典项列表
        /// </summary>
        /// <param name="model">请求实体</param>
        /// <returns></returns>
        [Route("GetDictionaryTypeList"), HttpPost]
        public async Task<ResponseMessageModel> GetDictionaryTypeList([FromBody]RequestGetDictionaryTypeListModel model)
        {
            return await Task.Run(() => getDictionaryTypeListService.Execute(model));
        }
        /// <summary>
        /// 分页获取字典项列表
        /// </summary>
        /// <param name="model">请求实体</param>
        /// <returns></returns>
        [Route("GetDictionaryTypePageList"), HttpPost]
        public async Task<ResponseMessageModel> GetDictionaryTypePageList([FromBody]RequestGetDictionaryTypeListModel model)
        {
            return await Task.Run(() => getDictionaryTypePageListService.Execute(model));
        }
        /// <summary>
        /// 添加字典项
        /// </summary>
        /// <param name="model">请求实体</param>
        /// <returns></returns>
        [Route("InsertDictionaryType"), HttpPost]
        public async Task<ResponseMessageModel> InsertDictionaryType([FromBody]RequestInsertDictionaryTypeModel model)
        {
            return await Task.Run(() => insertDictionaryTypeService.Execute(model));
        }
        /// <summary>
        /// 通过编号更新字典项
        /// </summary>
        /// <param name="model">请求实体</param>
        /// <returns></returns>
        [Route("UpdateDictionaryTypeById"), HttpPost]
        public async Task<ResponseMessageModel> UpdateDictionaryTypeById([FromBody]RequestUpdateDictionaryTypeByIdModel model)
        {
            return await Task.Run(() => updateDictionaryTypeByIdService.Execute(model));
        }
        /// <summary>
        /// 伪删除
        /// </summary>
        /// <param name="model">请求实体</param>
        /// <returns></returns>
        [Route("UpdateDictionaryTypeIsDelById"), HttpPost]
        public async Task<ResponseMessageModel> UpdateDictionaryTypeIsDelById([FromBody]RequestUpdateDictionaryTypeIsDelByIdModel model)
        {
            return await Task.Run(() => updateDictionaryTypeIsDelByIdService.Execute(model));
        }
        /// <summary>
        /// 通过编号删除字典项
        /// </summary>
        /// <param name="model">请求实体</param>
        /// <returns></returns>
        [Route("DeleteDictionaryTypeById"), HttpPost]
        public async Task<ResponseMessageModel> DeleteDictionaryTypeById([FromBody]RequestDeleteDictionaryTypeByIdModel model)
        {
            return await Task.Run(() => deleteDictionaryTypeByIdService.Execute(model));
        }
    }
}
