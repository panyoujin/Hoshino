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
    /// b_product_attribute
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class b_product_attributeController : ControllerBase
    {
        private readonly ILogger<b_product_attributeController> _logger;
        private readonly Ib_product_attribute_Repository _repository;
        /// <summary>
        /// 构造函数
        /// </summary>
        public b_product_attributeController(ILogger<b_product_attributeController> logger,Ib_product_attribute_Repository repository)
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
        public ActionResult<object> Post([FromBody]b_product_attributeVM model)
        {
            b_product_attribute_Entity entity = model.ConvertToT<b_product_attribute_Entity>();
            return this._repository.Insert(entity).ResponseSuccess();
        }

        /// <summary>
        /// 修改
        /// </summary>
        [Authorize]
        [HttpPut]
        [ProducesResponseType(200, Type = typeof(ApiResult<bool>))]
        public ActionResult<object> Update([FromBody]b_product_attributeVM model)
        {
            b_product_attribute_Entity entity = model.ConvertToT<b_product_attribute_Entity>();
            return this._repository.Update(entity).ResponseSuccess();
        }

        /// <summary>
        /// 删除
        /// </summary>
        [Authorize]
        [HttpDelete]
        [ProducesResponseType(200, Type = typeof(ApiResult<bool>))]
        public ActionResult<object> Delete(int P_Attribute_ID)
        {
            return this._repository.Delete(P_Attribute_ID).ResponseSuccess();
        }

        /// <summary>
        /// 获取单个
        /// </summary>
        [Authorize]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ApiResult<b_product_attribute_Entity>))]
        public ActionResult<object> Get(int P_Attribute_ID)
        {
            return this._repository.Get(P_Attribute_ID).ResponseSuccess();
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(ApiResult<List<b_product_attribute_Entity>>))]
        public ActionResult<object> GetList([FromBody]b_product_attributeVM model,int pageindex,int pagesize)
        {
            b_product_attribute_Entity entity = model.ConvertToT<b_product_attribute_Entity>();
            var (list,total) = this._repository.GetList(entity, pageindex, pagesize) ;
            return list.ResponseSuccess("",total);
        }

    }
}
