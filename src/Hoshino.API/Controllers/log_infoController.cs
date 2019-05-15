using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pan.Code;
using Pan.Code.Extentions;
using Hoshino.API.Filters;
using Hoshino.Entity;
using Hoshino.IRepository;
using Microsoft.AspNetCore.Authorization;
using Hoshino.API.ViewModels;

namespace Hoshino.API.Controllers
{
    /// <summary>
    /// log_info
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class log_infoController : ControllerBase
    {
        private readonly ILogger<log_infoController> _logger;
        private readonly Ilog_info_Repository _repository;
        /// <summary>
        /// 构造函数
        /// </summary>
        public log_infoController(ILogger<log_infoController> logger,Ilog_info_Repository repository)
        {
            this._logger = logger;
            this._repository = repository;
        }
        /// <summary>
        /// 新增
        /// </summary>
        [Authorize]
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(ApiResult<bool>))]
        public ActionResult<object> Post([FromBody]log_infoVM model)
        {
            log_info_Entity entity = model.ConvertToT<log_info_Entity>();
            return this._repository.Insert(entity).ResponseSuccess();
        }

        /// <summary>
        /// 修改
        /// </summary>
        [Authorize]
        [HttpPut]
        [ProducesResponseType(200, Type = typeof(ApiResult<bool>))]
        public ActionResult<object> Update([FromBody]log_infoVM model)
        {
            log_info_Entity entity = model.ConvertToT<log_info_Entity>();
            return this._repository.Update(entity).ResponseSuccess();
        }

        /// <summary>
        /// 删除
        /// </summary>
        [Authorize]
        [HttpDelete]
        [ProducesResponseType(200, Type = typeof(ApiResult<bool>))]
        public ActionResult<object> Delete(int id)
        {
            return this._repository.Delete(id).ResponseSuccess();
        }

        /// <summary>
        /// 获取单个
        /// </summary>
        [Authorize]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ApiResult<log_info_Entity>))]
        public ActionResult<object> Get(int id)
        {
            return this._repository.Get(id).ResponseSuccess();
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(ApiResult<List<log_info_Entity>>))]
        public ActionResult<object> GetList([FromBody]log_infoVM model,int pageindex,int pagesize)
        {
            log_info_Entity entity = model.ConvertToT<log_info_Entity>();
            var (list,total) = this._repository.GetList(entity, pageindex, pagesize) ;
            return list.ResponseSuccess("",total);
        }

    }
}
