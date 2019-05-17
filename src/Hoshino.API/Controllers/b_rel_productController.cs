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
    /// b_rel_product
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class b_rel_productController : ControllerBase
    {
        private readonly ILogger<b_rel_productController> _logger;
        private readonly Ib_rel_product_Repository _repository;
        /// <summary>
        /// 构造函数
        /// </summary>
        public b_rel_productController(ILogger<b_rel_productController> logger, Ib_rel_product_Repository repository)
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
        public ActionResult<object> Post([FromBody]b_rel_productVM model)
        {
            b_rel_product_Entity entity = model.ConvertToT<b_rel_product_Entity>();
            this.SetCreateUserInfo(entity);
            return this._repository.Insert(entity).ResponseSuccess();
        }

        /// <summary>
        /// 修改
        /// </summary>
        [Authorize]
        [HttpPut]
        [ProducesResponseType(200, Type = typeof(ApiResult<bool>))]
        public ActionResult<object> Update([FromBody]b_rel_productVM model, int P_Relevant_ID)
        {
            b_rel_product_Entity entity = model.ConvertToT<b_rel_product_Entity>();
            this.SetUpdateUserInfo(entity);
            return this._repository.Update(entity, P_Relevant_ID).ResponseSuccess();
        }

        /// <summary>
        /// 删除
        /// </summary>
        [Authorize]
        [HttpDelete]
        [ProducesResponseType(200, Type = typeof(ApiResult<bool>))]
        public ActionResult<object> Delete(int P_Relevant_ID)
        {
            b_rel_product_Entity entity = new b_rel_product_Entity();
            this.SetUpdateUserInfo(entity);
            this._repository.Update(entity, P_Relevant_ID);
            return this._repository.Delete(P_Relevant_ID).ResponseSuccess();
        }

        /// <summary>
        /// 获取单个
        /// </summary>
        [Authorize]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ApiResult<b_rel_product_Entity>))]
        public ActionResult<object> Get(int P_Relevant_ID)
        {
            return this._repository.Get(P_Relevant_ID).ResponseSuccess();
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(ApiResult<List<b_rel_product_Entity>>))]
        public ActionResult<object> GetList([FromBody]b_rel_productVM model, int pageindex, int pagesize)
        {
            b_rel_product_Entity entity = model.ConvertToT<b_rel_product_Entity>();
            var (list, total) = this._repository.GetList(entity, pageindex, pagesize);
            return list.ResponseSuccess("", total);
        }

    }
}
