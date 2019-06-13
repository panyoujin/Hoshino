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
using Pan.Code.Cache;

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
        [ProducesResponseType(200, Type = typeof(ApiResult<int>))]
        public ActionResult<object> Post([FromBody]b_productVM model)
        {
            b_product_Entity entity = model.ConvertToT<b_product_Entity>();
            this.SetCreateUserInfo(entity);
            CacheFactory.CacheInstance.RemovePrefix(Constant.Cache_Product_Prefix);
            return this._repository.Insert(entity).ResponseSuccess();
        }

        /// <summary>
        /// 修改
        /// </summary>
        [Authorize]
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(ApiResult<bool>))]
        public ActionResult<object> Update([FromBody]b_productVM model)
        {
            b_product_Entity entity = model.ConvertToT<b_product_Entity>();
            this.SetUpdateUserInfo(entity);
            CacheFactory.CacheInstance.RemovePrefix(Constant.Cache_Product_Prefix);
            return this._repository.Update(entity, model.Product_ID).ResponseSuccess();
        }

        /// <summary>
        /// 删除
        /// </summary>
        [Authorize]
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(ApiResult<bool>))]
        public ActionResult<object> Delete([FromBody]b_productVM model)
        {
            b_product_Entity entity = new b_product_Entity();
            this.SetUpdateUserInfo(entity);
            this._repository.Update(entity, model.Product_ID);
            CacheFactory.CacheInstance.RemovePrefix(Constant.Cache_Product_Prefix);
            return this._repository.Delete(model.Product_ID).ResponseSuccess();
        }

        /// <summary>
        /// 获取单个  前台API
        /// </summary>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ApiResult<b_productVM>))]
        public ActionResult<object> Get(Lang lang, int Product_ID)
        {
            string key = string.Format(Constant.Cache_Product, Product_ID, lang);
            b_productVM productVM = CacheFactory.CacheInstance.Get<b_productVM>(key);
            if (productVM == null)
            {
                var (pList, prList, paList, rpList) = this._repository.Get(Product_ID);
                foreach (var p in pList)
                {
                    productVM = p.ConvertToT<b_productVM>();
                    productVM.product_resourcesList = prList.Select(pr => pr.ConvertToT<b_product_resourcesVM>()).ToList();
                    productVM.product_attributeList = paList.Select(pa => pa.ConvertToT<b_product_attributeVM>()).ToList();
                    productVM.rel_productList = new List<b_productVM>();
                    if (rpList != null && rpList.Count() > 0)
                    {
                        var (r_pList, r_prList) = this._repository.GetProductListByIDs<b_product_Entity, b_product_resources_Entity>(rpList.Select(rp => rp.Product_ID));
                        foreach (var rp in r_pList)
                        {
                            b_productVM r_productVM = rp.ConvertToT<b_productVM>();
                            switch (lang)
                            {
                                case Lang.CHS:
                                    r_productVM.Product_Name_HK = r_productVM.Product_Name_CH;
                                    break;
                                case Lang.CHT:
                                    r_productVM.Product_Name_CH = r_productVM.Product_Name_HK;
                                    break;
                            }
                            r_productVM.product_resourcesList = r_prList.Where(pr => pr.Product_ID == rp.Product_ID).Select(pr => pr.ConvertToT<b_product_resourcesVM>()).ToList();
                            productVM.rel_productList.Add(r_productVM);
                        }
                    }
                    switch (lang)
                    {
                        case Lang.CHS:
                            productVM.Product_Name_HK = productVM.Product_Name_CH;
                            if (productVM.product_attributeList != null)
                            {
                                foreach (var a in productVM.product_attributeList)
                                {
                                    a.P_Attribute_Name_HK = a.P_Attribute_Name_CH;
                                    a.P_Attribute_Value_HK = a.P_Attribute_Value_CH;
                                }
                            }
                            if (productVM.rel_productList != null)
                            {
                                foreach (var pr in productVM.rel_productList)
                                {
                                    p.Product_Name_HK = p.Product_Name_CH;
                                }
                            }
                            break;
                        case Lang.CHT:
                            productVM.Product_Name_CH = productVM.Product_Name_HK;
                            if (productVM.product_attributeList != null)
                            {
                                foreach (var a in productVM.product_attributeList)
                                {
                                    a.P_Attribute_Name_CH = a.P_Attribute_Name_HK;
                                    a.P_Attribute_Value_CH = a.P_Attribute_Value_HK;
                                }
                            }
                            if (productVM.rel_productList != null)
                            {
                                foreach (var pr in productVM.rel_productList)
                                {
                                    p.Product_Name_CH = p.Product_Name_HK;
                                }
                            }
                            break;
                    }
                    break;
                }
                CacheFactory.CacheInstance.Add(key, productVM);
            }
            return productVM.ResponseSuccess();
        }

        /// <summary>
        /// 获取单个  后台API
        /// </summary>
        [Authorize]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ApiResult<b_productVM>))]
        public ActionResult<object> GetBack(int Product_ID)
        {
            var (pList, prList, paList, rpList) = this._repository.GetBack(Product_ID);
            b_productVM productVM = null;
            foreach (var p in pList)
            {
                productVM = p.ConvertToT<b_productVM>();
                productVM.product_resourcesList = prList.Select(pr => pr.ConvertToT<b_product_resourcesVM>()).ToList();
                productVM.product_attributeList = paList.Select(pa => pa.ConvertToT<b_product_attributeVM>()).ToList();
                //productVM.rel_productList = rpList.Select(rp => rp.ConvertToT<b_productVM>()).ToList();
                productVM.rel_productList = new List<b_productVM>();

                if (rpList != null && rpList.Count() > 0)
                {
                    var (r_pList, r_prList) = this._repository.GetProductListByIDs<b_product_Entity, b_product_resources_Entity>(rpList.Select(rp => rp.Product_ID));
                    foreach (var rp in r_pList)
                    {
                        b_productVM r_productVM = rp.ConvertToT<b_productVM>();
                        r_productVM.product_resourcesList = r_prList.Where(pr => pr.Product_ID == rp.Product_ID).Select(pr => pr.ConvertToT<b_product_resourcesVM>()).ToList();
                        productVM.rel_productList.Add(r_productVM);
                    }
                }

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
        public ActionResult<object> GetList([FromBody]b_productVM model, int pageindex = 1, int pagesize = 24)
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
        public ActionResult<object> GetNewProductList(Lang lang, int categoryID = -1, int pageindex = 1, int pagesize = 24)
        {


            string key = string.Format(Constant.Cache_ProductNewList, pageindex, pagesize, lang);
            string totalKey = string.Format(Constant.Cache_ProductNewListTotal, pageindex, pagesize, lang);
            var total = CacheFactory.CacheInstance.Get<int>(totalKey);
            List<b_productVM> vmList = CacheFactory.CacheInstance.Get<List<b_productVM>>(key) ?? new List<b_productVM>();
            if (vmList == null || vmList.Count <= 0)
            {
                var (ids, rows) = this._repository.GetProductIDList<int>(categoryID, "", 1, -1, -1, pageindex, pagesize);
                total = rows;
                var (pList, prList) = this._repository.GetProductListByIDs<b_product_Entity, b_product_resources_Entity>(ids);
                foreach (var p in pList)
                {
                    b_productVM productVM = p.ConvertToT<b_productVM>();
                    switch (lang)
                    {
                        case Lang.CHS:
                            productVM.Product_Name_HK = productVM.Product_Name_CH;
                            break;
                        case Lang.CHT:
                            productVM.Product_Name_CH = productVM.Product_Name_HK;
                            break;
                    }
                    productVM.product_resourcesList = prList.Where(pr => pr.Product_ID == p.Product_ID).Select(pr => pr.ConvertToT<b_product_resourcesVM>()).ToList();
                    vmList.Add(productVM);
                }
                CacheFactory.CacheInstance.Add(key, vmList);
                CacheFactory.CacheInstance.Add(totalKey, total);
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
        public ActionResult<object> GetHotProductList(Lang lang, int categoryID = -1, int pageindex = 1, int pagesize = 24)
        {
            string key = string.Format(Constant.Cache_ProductHotList, pageindex, pagesize, lang);
            string totalKey = string.Format(Constant.Cache_ProductHotListTotal, pageindex, pagesize, lang);
            var total = CacheFactory.CacheInstance.Get<int>(totalKey);
            List<b_productVM> vmList = CacheFactory.CacheInstance.Get<List<b_productVM>>(key) ?? new List<b_productVM>();
            if (vmList == null || vmList.Count <= 0)
            {
                var (ids, rows) = this._repository.GetProductIDList<int>(categoryID, "", -1, 1, -1, pageindex, pagesize);
                total = rows;
                var (pList, prList) = this._repository.GetProductListByIDs<b_product_Entity, b_product_resources_Entity>(ids);
                foreach (var p in pList)
                {
                    b_productVM productVM = p.ConvertToT<b_productVM>();
                    switch (lang)
                    {
                        case Lang.CHS:
                            productVM.Product_Name_HK = productVM.Product_Name_CH;
                            break;
                        case Lang.CHT:
                            productVM.Product_Name_CH = productVM.Product_Name_HK;
                            break;
                    }
                    productVM.product_resourcesList = prList.Where(pr => pr.Product_ID == p.Product_ID).Select(pr => pr.ConvertToT<b_product_resourcesVM>()).ToList();
                    vmList.Add(productVM);
                }
                CacheFactory.CacheInstance.Add(key, vmList);
                CacheFactory.CacheInstance.Add(totalKey, total);
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
        public ActionResult<object> GetRecommendProductList(Lang lang, int categoryID = -1, int pageindex = 1, int pagesize = 24)
        {
            string key = string.Format(Constant.Cache_ProductRecommendList, pageindex, pagesize, lang);
            string totalKey = string.Format(Constant.Cache_ProductRecommendListTotal, pageindex, pagesize, lang);
            var total = CacheFactory.CacheInstance.Get<int>(totalKey);
            List<b_productVM> vmList = CacheFactory.CacheInstance.Get<List<b_productVM>>(key) ?? new List<b_productVM>();
            if (vmList == null || vmList.Count <= 0)
            {
                var (ids, rows) = this._repository.GetProductIDList<int>(categoryID, "", -1, -1, 1, pageindex, pagesize);
                total = rows;
                var (pList, prList) = this._repository.GetProductListByIDs<b_product_Entity, b_product_resources_Entity>(ids);
                foreach (var p in pList)
                {
                    b_productVM productVM = p.ConvertToT<b_productVM>();
                    switch (lang)
                    {
                        case Lang.CHS:
                            productVM.Product_Name_HK = productVM.Product_Name_CH;
                            break;
                        case Lang.CHT:
                            productVM.Product_Name_CH = productVM.Product_Name_HK;
                            break;
                    }
                    productVM.product_resourcesList = prList.Where(pr => pr.Product_ID == p.Product_ID).Select(pr => pr.ConvertToT<b_product_resourcesVM>()).ToList();
                    vmList.Add(productVM);
                }
                CacheFactory.CacheInstance.Add(key, vmList);
                CacheFactory.CacheInstance.Add(totalKey, total);
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
        public ActionResult<object> GetProductList(Lang lang, int categoryID = -1, string product_name = "", int pageindex = 1, int pagesize = 24)
        {
            string key = string.Format(Constant.Cache_ProductList, categoryID, pageindex, pagesize, lang, product_name);
            string totalKey = string.Format(Constant.Cache_ProductListTotal, categoryID, pageindex, pagesize, lang, product_name);
            var total = CacheFactory.CacheInstance.Get<int>(totalKey);
            List<b_productVM> vmList = CacheFactory.CacheInstance.Get<List<b_productVM>>(key) ?? new List<b_productVM>();
            if (vmList == null || vmList.Count <= 0)
            {
                var (ids, rows) = this._repository.GetProductIDList<int>(categoryID, product_name, -1, -1, -1, pageindex, pagesize);
                total = rows;
                var (pList, prList) = this._repository.GetProductListByIDs<b_product_Entity, b_product_resources_Entity>(ids);
                foreach (var p in pList)
                {
                    b_productVM productVM = p.ConvertToT<b_productVM>();
                    switch (lang)
                    {
                        case Lang.CHS:
                            productVM.Product_Name_HK = productVM.Product_Name_CH;
                            break;
                        case Lang.CHT:
                            productVM.Product_Name_CH = productVM.Product_Name_HK;
                            break;
                    }
                    productVM.product_resourcesList = prList.Where(pr => pr.Product_ID == p.Product_ID).Select(pr => pr.ConvertToT<b_product_resourcesVM>()).ToList();
                    vmList.Add(productVM);
                }
                CacheFactory.CacheInstance.Add(key, vmList);
                CacheFactory.CacheInstance.Add(totalKey, total);
            }
            return vmList.ResponseSuccess("", total);
        }

    }
}
