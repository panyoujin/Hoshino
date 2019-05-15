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
    /// b_product
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class b_productController : ControllerBase
    {
        private readonly ILogger<b_productController> _logger;
        private readonly Ib_product_Repository _repository;
        /// <summary>
        /// 构造函数
        /// </summary>
        public b_productController(ILogger<b_productController> logger, Ib_product_Repository repository)
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
        public ActionResult<object> Post([FromBody]b_productVM model)
        {
            b_product_Entity entity = model.ConvertToT<b_product_Entity>();
            return this._repository.Insert(entity).ResponseSuccess();
        }

        /// <summary>
        /// 修改
        /// </summary>
        [Authorize]
        [HttpPut]
        [ProducesResponseType(200, Type = typeof(ApiResult<bool>))]
        public ActionResult<object> Update([FromBody]b_productVM model)
        {
            b_product_Entity entity = model.ConvertToT<b_product_Entity>();
            return this._repository.Update(entity).ResponseSuccess();
        }

        /// <summary>
        /// 删除
        /// </summary>
        [Authorize]
        [HttpDelete]
        [ProducesResponseType(200, Type = typeof(ApiResult<bool>))]
        public ActionResult<object> Delete(int Product_ID)
        {
            return this._repository.Delete(Product_ID).ResponseSuccess();
        }

        /// <summary>
        /// 获取单个
        /// </summary>
        [Authorize]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ApiResult<b_product_Entity>))]
        public ActionResult<object> Get(int Product_ID)
        {
            return this._repository.Get(Product_ID).ResponseSuccess();
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(ApiResult<List<b_product_Entity>>))]
        public ActionResult<object> GetList([FromBody]b_productVM model, int pageindex, int pagesize)
        {
            b_product_Entity entity = model.ConvertToT<b_product_Entity>();
            var (list, total) = this._repository.GetList(entity, pageindex, pagesize);
            return list.ResponseSuccess("", total);
        }

        /// <summary>
        /// 获取最新产品列表
        /// 首页调用参数：pageindex=1；pagesize=24
        /// </summary>
        /// <param name="categoryID">菜单ID，全部时传递-1</param>
        /// <param name="pageindex">页码</param>
        /// <param name="pagesize">每页数量</param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ApiResult<List<b_product_Entity>>))]
        public ActionResult<object> GetNewProductList(int categoryID = -1, int pageindex = 1, int pagesize = 24)
        {
            var (list, total) = this._repository.GetNewProductList<b_product_Entity>(categoryID, pageindex, pagesize);
            return list.ResponseSuccess("", total);
        }
        /// <summary>
        /// 获取热门产品列表
        /// 首页调用参数：pageindex=1；pagesize=24
        /// </summary>
        /// <param name="categoryID">菜单ID，全部时传递-1</param>
        /// <param name="pageindex">页码</param>
        /// <param name="pagesize">每页数量</param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ApiResult<List<b_product_Entity>>))]
        public ActionResult<object> GetHotProductList(int categoryID = -1, int pageindex = 1, int pagesize = 24)
        {
            var (list, total) = this._repository.GetHotProductList<b_product_Entity>(categoryID, pageindex, pagesize);
            return list.ResponseSuccess("", total);
        }
        /// <summary>
        /// 获取推荐产品列表
        /// </summary>
        /// <param name="categoryID">菜单ID，全部时传递-1</param>
        /// <param name="pageindex">页码</param>
        /// <param name="pagesize">每页数量</param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ApiResult<List<b_product_Entity>>))]
        public ActionResult<object> GetRecommendProductList(int categoryID = -1, int pageindex = 1, int pagesize = 24)
        {
            var (list, total) = this._repository.GetHotProductList<b_product_Entity>(categoryID, pageindex, pagesize);
            return list.ResponseSuccess("", total);
        }

    }
}
