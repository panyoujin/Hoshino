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
    /// 关联产品
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class b_rel_productController : ControllerBase
    {
        private readonly ILogger<b_rel_productController> _logger;
        private readonly Ib_rel_product_Repository _repository;
        public b_rel_productController(ILogger<b_rel_productController> logger,Ib_rel_product_Repository repository)
        {
            this._logger = logger;
            this._repository = repository;
        }
        /// <summary>
        /// 新增
        /// </summary>
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(ApiResult<bool>))]
        public ActionResult<object> Post([FromBody]b_rel_product_Entity model)
        {
            return this._repository.Insert(model).ResponseSuccess();
        }

        /// <summary>
        /// 修改
        /// </summary>
        [HttpPut]
        [ProducesResponseType(200, Type = typeof(ApiResult<bool>))]
        public ActionResult<object> Update([FromBody]b_rel_product_Entity model)
        {
            return this._repository.Update(model).ResponseSuccess();
        }

        /// <summary>
        /// 删除
        /// </summary>
        [HttpDelete]
        [ProducesResponseType(200, Type = typeof(ApiResult<bool>))]
        public ActionResult<object> Delete(int P_Relevant_ID)
        {
            return this._repository.Delete(P_Relevant_ID).ResponseSuccess();
        }

        /// <summary>
        /// 获取单个
        /// </summary>
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
        public ActionResult<object> GetList([FromBody]b_rel_product_Entity model,int pageindex,int pagesize)
        {
            var (list,total) = this._repository.GetList(model, pageindex, pagesize) ;
            return list.ResponseSuccess("",total);
        }

    }
}
