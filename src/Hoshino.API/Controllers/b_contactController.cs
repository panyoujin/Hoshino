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
using Hoshino.API.Extentions;

namespace Hoshino.API.Controllers
{
    /// <summary>
    /// b_contact
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class b_contactController : ControllerBase
    {
        private readonly ILogger<b_contactController> _logger;
        private readonly Ib_contact_Repository _repository;
        /// <summary>
        /// 构造函数
        /// </summary>
        public b_contactController(ILogger<b_contactController> logger,Ib_contact_Repository repository)
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
        public ActionResult<object> Post([FromBody]b_contactVM model)
        {
            b_contact_Entity entity = model.ConvertToT<b_contact_Entity>();
            this.SetCreateUserInfo(entity);
            return this._repository.Insert(entity).ResponseSuccess();
        }

        /// <summary>
        /// 修改
        /// </summary>
        [Authorize]
        [HttpPut]
        [ProducesResponseType(200, Type = typeof(ApiResult<bool>))]
        public ActionResult<object> Update([FromBody]b_contactVM model)
        {
            b_contact_Entity entity = model.ConvertToT<b_contact_Entity>();
            this.SetUpdateUserInfo(entity);
            return this._repository.Update(entity).ResponseSuccess();
        }

        /// <summary>
        /// 删除
        /// </summary>
        [Authorize]
        [HttpDelete]
        [ProducesResponseType(200, Type = typeof(ApiResult<bool>))]
        public ActionResult<object> Delete(int Contact_ID)
        {
            return this._repository.Delete(Contact_ID).ResponseSuccess();
        }

        /// <summary>
        /// 获取单个
        /// </summary>
        [Authorize]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ApiResult<b_contact_Entity>))]
        public ActionResult<object> Get(int Contact_ID)
        {
            return this._repository.Get(Contact_ID).ResponseSuccess();
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(ApiResult<List<b_contact_Entity>>))]
        public ActionResult<object> GetList([FromBody]b_contactVM model,int pageindex,int pagesize)
        {
            b_contact_Entity entity = model.ConvertToT<b_contact_Entity>();
            var (list,total) = this._repository.GetList(entity, pageindex, pagesize) ;
            return list.ResponseSuccess("",total);
        }

    }
}
