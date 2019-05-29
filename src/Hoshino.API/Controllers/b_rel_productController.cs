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
        public ActionResult<object> Post([FromBody]List<b_rel_productVM> modelList)
        {
            List<b_rel_product_Entity> list = new List<b_rel_product_Entity>();
            foreach (var model in modelList)
            {
                b_rel_product_Entity entity = model.ConvertToT<b_rel_product_Entity>();
                this.SetCreateUserInfo(entity);
                list.Add(entity);
            }
            return this._repository.Insert(list).ResponseSuccess();
        }
        /// <summary>
        /// 修改
        /// </summary>
        [Authorize]
        [HttpPut]
        [ProducesResponseType(200, Type = typeof(ApiResult<bool>))]
        public ActionResult<object> Update([FromBody]List<b_rel_productVM> modelList)
        {
            List<b_rel_product_Entity> list = new List<b_rel_product_Entity>();
            foreach (var model in modelList)
            {
                b_rel_product_Entity entity = model.ConvertToT<b_rel_product_Entity>();
                this.SetUpdateUserInfo(entity);
                list.Add(entity);
            }
            return this._repository.Update(list).ResponseSuccess();
        }
        /// <summary>
        /// 删除
        /// </summary>
        [Authorize]
        [HttpDelete]
        [ProducesResponseType(200, Type = typeof(ApiResult<bool>))]
        public ActionResult<object> Delete(List<int> idList)
        {
            List<b_rel_product_Entity> list = new List<b_rel_product_Entity>();
            foreach (var id in idList)
            {
                b_rel_product_Entity entity = new b_rel_product_Entity()
                {
                    P_Relevant_ID = id
                };
                this.SetUpdateUserInfo(entity);
                list.Add(entity);
            }
            this._repository.Update(list);
            return this._repository.Delete(idList).ResponseSuccess();
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ApiResult<List<b_rel_product_Entity>>))]
        public ActionResult<object> GetList(int Product_ID, int pageindex = 1, int pagesize = 24)
        {
            var (list, total) = this._repository.GetList(Product_ID, pageindex, pagesize);
            return list.ResponseSuccess("", total);
        }

    }
}
