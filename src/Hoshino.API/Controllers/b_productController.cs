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
using System.Linq;

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
        //private readonly Ib_product_attribute_Repository _product_attribute;
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
            this.SetCreateUserInfo(entity);
            return this._repository.Insert(entity).ResponseSuccess();
        }

        /// <summary>
        /// 修改
        /// </summary>
        [Authorize]
        [HttpPut]
        [ProducesResponseType(200, Type = typeof(ApiResult<bool>))]
        public ActionResult<object> Update([FromBody]b_productVM model, int Product_ID)
        {
            b_product_Entity entity = model.ConvertToT<b_product_Entity>();
            this.SetUpdateUserInfo(entity);
            return this._repository.Update(entity, Product_ID).ResponseSuccess();
        }

        /// <summary>
        /// 删除
        /// </summary>
        [Authorize]
        [HttpDelete]
        [ProducesResponseType(200, Type = typeof(ApiResult<bool>))]
        public ActionResult<object> Delete(int Product_ID)
        {
            b_product_Entity entity = new b_product_Entity();
            this.SetUpdateUserInfo(entity);
            this._repository.Update(entity, Product_ID);
            return this._repository.Delete(Product_ID).ResponseSuccess();
        }

        /// <summary>
        /// 获取单个  前台和后台API
        /// </summary>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ApiResult<b_productVM>))]
        public ActionResult<object> Get(int Product_ID)
        {
            var (pList, prList, paList, rpList) = this._repository.Get(Product_ID);
            b_productVM productVM = null;
            foreach (var p in pList)
            {
                productVM = p.ConvertToT<b_productVM>();
                productVM.product_resourcesList = prList.Select(pr => pr.ConvertToT<b_product_resourcesVM>()).ToList();
                productVM.product_attributeList = paList.Select(pa => pa.ConvertToT<b_product_attributeVM>()).ToList();
                productVM.rel_productList = rpList.Select(rp => rp.ConvertToT<b_productVM>()).ToList();
                break;
            }
            return productVM.ResponseSuccess();
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        [Authorize]
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(ApiResult<List<b_productVM>>))]
        public ActionResult<object> GetList([FromBody]b_productVM model, int pageindex, int pagesize)
        {
            b_product_Entity entity = model.ConvertToT<b_product_Entity>();
            var (list, total) = this._repository.GetList(entity, pageindex, pagesize);

            return list.ResponseSuccess("", total);
        }

        /// <summary>
        /// 获取最新产品列表  前台API
        /// 首页调用参数：pageindex=1；pagesize=24
        /// </summary>
        /// <param name="categoryID">菜单ID，全部时传递-1</param>
        /// <param name="pageindex">页码</param>
        /// <param name="pagesize">每页数量</param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ApiResult<List<b_productVM>>))]
        public ActionResult<object> GetNewProductList(int categoryID = -1, int pageindex = 1, int pagesize = 24)
        {
            var (ids, total) = this._repository.GetProductIDList<int>(categoryID, "", 1, -1, -1, pageindex, pagesize);
            var (pList, prList) = this._repository.GetProductListByIDs<b_product_Entity, b_product_resources_Entity>(ids);
            List<b_productVM> vmList = new List<b_productVM>();
            foreach (var p in pList)
            {
                b_productVM productVM = p.ConvertToT<b_productVM>();
                productVM.product_resourcesList = prList.Where(pr => pr.Product_ID == p.Product_ID).Select(pr => pr.ConvertToT<b_product_resourcesVM>()).ToList();
                vmList.Add(productVM);
            }
            return vmList.ResponseSuccess("", total);
        }
        /// <summary>
        /// 获取热门产品列表  前台API
        /// 首页调用参数：pageindex=1；pagesize=24
        /// </summary>
        /// <param name="categoryID">菜单ID，全部时传递-1</param>
        /// <param name="pageindex">页码</param>
        /// <param name="pagesize">每页数量</param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ApiResult<List<b_productVM>>))]
        public ActionResult<object> GetHotProductList(int categoryID = -1, int pageindex = 1, int pagesize = 24)
        {
            var (ids, total) = this._repository.GetProductIDList<int>(categoryID, "", -1, 1, -1, pageindex, pagesize);
            var (pList, prList) = this._repository.GetProductListByIDs<b_product_Entity, b_product_resources_Entity>(ids);
            List<b_productVM> vmList = new List<b_productVM>();
            foreach (var p in pList)
            {
                b_productVM productVM = p.ConvertToT<b_productVM>();
                productVM.product_resourcesList = prList.Where(pr => pr.Product_ID == p.Product_ID).Select(pr => pr.ConvertToT<b_product_resourcesVM>()).ToList();
                vmList.Add(productVM);
            }
            return vmList.ResponseSuccess("", total);
        }
        /// <summary>
        /// 获取推荐产品列表  前台API
        /// </summary>
        /// <param name="categoryID">菜单ID，全部时传递-1</param>
        /// <param name="pageindex">页码</param>
        /// <param name="pagesize">每页数量</param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ApiResult<List<b_productVM>>))]
        public ActionResult<object> GetRecommendProductList(int categoryID = -1, int pageindex = 1, int pagesize = 24)
        {
            var (ids, total) = this._repository.GetProductIDList<int>(categoryID, "", -1, -1, 1, pageindex, pagesize);
            var (pList, prList) = this._repository.GetProductListByIDs<b_product_Entity, b_product_resources_Entity>(ids);
            List<b_productVM> vmList = new List<b_productVM>();
            foreach (var p in pList)
            {
                b_productVM productVM = p.ConvertToT<b_productVM>();
                productVM.product_resourcesList = prList.Where(pr => pr.Product_ID == p.Product_ID).Select(pr => pr.ConvertToT<b_product_resourcesVM>()).ToList();
                vmList.Add(productVM);
            }
            return vmList.ResponseSuccess("", total);
        }

        /// <summary>
        /// 获取产品列表  前台API
        /// </summary>
        /// <param name="categoryID">菜单ID，全部时传递-1</param>
        /// <param name="product_name"></param>
        /// <param name="pageindex">页码</param>
        /// <param name="pagesize">每页数量</param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ApiResult<List<b_productVM>>))]
        public ActionResult<object> GetProductList(int categoryID = -1, string product_name = "", int pageindex = 1, int pagesize = 24)
        {
            var (ids, total) = this._repository.GetProductIDList<int>(categoryID, product_name, -1, -1, -1, pageindex, pagesize);
            var (pList, prList) = this._repository.GetProductListByIDs<b_product_Entity, b_product_resources_Entity>(ids);
            List<b_productVM> vmList = new List<b_productVM>();
            foreach (var p in pList)
            {
                b_productVM productVM = p.ConvertToT<b_productVM>();
                productVM.product_resourcesList = prList.Where(pr => pr.Product_ID == p.Product_ID).Select(pr => pr.ConvertToT<b_product_resourcesVM>()).ToList();
                vmList.Add(productVM);
            }
            return vmList.ResponseSuccess("", total);
        }

    }
}
