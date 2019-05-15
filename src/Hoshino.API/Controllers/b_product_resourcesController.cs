﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pan.Code;
using Pan.Code.Extentions;
using Hoshino.API.Filters;
using Hoshino.Entity;
using Hoshino.IRepository;
using Microsoft.AspNetCore.Authorization;

namespace Hoshino.API.Controllers
{
    /// <summary>
    /// 产品资源
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class b_product_resourcesController : ControllerBase
    {
        private readonly ILogger<b_product_resourcesController> _logger;
        private readonly Ib_product_resources_Repository _repository;
        public b_product_resourcesController(ILogger<b_product_resourcesController> logger,Ib_product_resources_Repository repository)
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
        public ActionResult<object> Post([FromBody]b_product_resources_Entity model)
        {
            return this._repository.Insert(model).ResponseSuccess();
        }

        /// <summary>
        /// 修改
        /// </summary>
        [Authorize]
        [HttpPut]
        [ProducesResponseType(200, Type = typeof(ApiResult<bool>))]
        public ActionResult<object> Update([FromBody]b_product_resources_Entity model)
        {
            return this._repository.Update(model).ResponseSuccess();
        }

        /// <summary>
        /// 删除
        /// </summary>
        [Authorize]
        [HttpDelete]
        [ProducesResponseType(200, Type = typeof(ApiResult<bool>))]
        public ActionResult<object> Delete(int P_Resources_ID)
        {
            return this._repository.Delete(P_Resources_ID).ResponseSuccess();
        }

        /// <summary>
        /// 获取单个
        /// </summary>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ApiResult<b_product_resources_Entity>))]
        public ActionResult<object> Get(int P_Resources_ID)
        {
            return this._repository.Get(P_Resources_ID).ResponseSuccess();
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(ApiResult<List<b_product_resources_Entity>>))]
        public ActionResult<object> GetList([FromBody]b_product_resources_Entity model,int pageindex,int pagesize)
        {
            var (list,total) = this._repository.GetList(model, pageindex, pagesize) ;
            return list.ResponseSuccess("",total);
        }

    }
}
