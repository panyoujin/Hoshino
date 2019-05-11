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
    /// 预约询价
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class b_appointment_consultationController : ControllerBase
    {
        private readonly ILogger<b_appointment_consultationController> _logger;
        private readonly Ib_appointment_consultation_Repository _repository;
        public b_appointment_consultationController(ILogger<b_appointment_consultationController> logger,Ib_appointment_consultation_Repository repository)
        {
            this._logger = logger;
            this._repository = repository;
        }
        /// <summary>
        /// 新增
        /// </summary>
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(ApiResult<bool>))]
        public ActionResult<object> Post([FromBody]b_appointment_consultation_Entity model)
        {
            return this._repository.Insert(model).ResponseSuccess();
        }

        /// <summary>
        /// 修改
        /// </summary>
        [HttpPut]
        [ProducesResponseType(200, Type = typeof(ApiResult<bool>))]
        public ActionResult<object> Update([FromBody]b_appointment_consultation_Entity model)
        {
            return this._repository.Update(model).ResponseSuccess();
        }

        /// <summary>
        /// 删除
        /// </summary>
        [HttpDelete]
        [ProducesResponseType(200, Type = typeof(ApiResult<bool>))]
        public ActionResult<object> Delete(int AC_ID)
        {
            return this._repository.Delete(AC_ID).ResponseSuccess();
        }

        /// <summary>
        /// 获取单个
        /// </summary>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ApiResult<b_appointment_consultation_Entity>))]
        public ActionResult<object> Get(int AC_ID)
        {
            return this._repository.Get(AC_ID).ResponseSuccess();
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(ApiResult<List<b_appointment_consultation_Entity>>))]
        public ActionResult<object> GetList([FromBody]b_appointment_consultation_Entity model,int pageindex,int pagesize)
        {
            var (list,total) = this._repository.GetList(model, pageindex, pagesize) ;
            return list.ResponseSuccess("",total);
        }

    }
}
