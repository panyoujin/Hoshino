using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pan.Code;
using Pan.Code.Extentions;
using Hoshino.API.Filters;
using Hoshino.Entity;
using Hoshino.IRepository;

namespace Hoshino.API.Controllers
{
    /// <summary>
    /// 日志
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class log_infoController : ControllerBase
    {
        private readonly ILogger<log_infoController> _logger;
        private readonly Ilog_info_Repository _repository;
        public log_infoController(ILogger<log_infoController> logger,Ilog_info_Repository repository)
        {
            this._logger = logger;
            this._repository = repository;
        }
        /// <summary>
        /// 新增
        /// </summary>
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(ApiResult<bool>))]
        public ActionResult<object> Post([FromBody]log_info_Entity model)
        {
            return this._repository.Insert(model).ResponseSuccess();
        }

        /// <summary>
        /// 修改
        /// </summary>
        [HttpPut]
        [ProducesResponseType(200, Type = typeof(ApiResult<bool>))]
        public ActionResult<object> Update([FromBody]log_info_Entity model)
        {
            return this._repository.Update(model).ResponseSuccess();
        }

        /// <summary>
        /// 删除
        /// </summary>
        [HttpDelete]
        [ProducesResponseType(200, Type = typeof(ApiResult<bool>))]
        public ActionResult<object> Delete(int id)
        {
            return this._repository.Delete(id).ResponseSuccess();
        }

        /// <summary>
        /// 获取单个
        /// </summary>
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
        public ActionResult<object> GetList([FromBody]log_info_Entity model,int pageindex,int pagesize)
        {
            var (list,total) = this._repository.GetList(model, pageindex, pagesize) ;
            return list.ResponseSuccess("",total);
        }

    }
}
