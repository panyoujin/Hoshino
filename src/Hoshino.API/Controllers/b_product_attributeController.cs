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
        public b_product_attributeController(ILogger<b_product_attributeController> logger, Ib_product_attribute_Repository repository)
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
        public ActionResult<object> Post([FromBody]List<b_product_attributeVM> modelList)
        {
            List<b_product_attribute_Entity> list = new List<b_product_attribute_Entity>();
            var ids = new List<int>();
            foreach (var model in modelList)
            {
                if (ids.Where(id => id != model.Product_ID).Count() <= 0)
                {
                    ids.Add(model.Product_ID);
                }

                b_product_attribute_Entity entity = model.ConvertToT<b_product_attribute_Entity>();
                this.SetCreateUserInfo(entity);
                list.Add(entity);
            }
            this.Delete(ids);
            return this._repository.Insert(list).ResponseSuccess();
        }

        /// <summary>
        /// 修改
        /// </summary>
        [Authorize]
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(ApiResult<bool>))]
        public ActionResult<object> Update([FromBody]List<b_product_attributeVM> modelList)
        {
            List<b_product_attribute_Entity> list = new List<b_product_attribute_Entity>();
            foreach (var model in modelList)
            {
                b_product_attribute_Entity entity = model.ConvertToT<b_product_attribute_Entity>();
                this.SetUpdateUserInfo(entity);
                list.Add(entity);
            }
            return this._repository.Update(list).ResponseSuccess();
        }

        /// <summary>
        /// 删除
        /// </summary>
        [Authorize]
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(ApiResult<bool>))]
        public ActionResult<object> Delete(List<int> idList)
        {
            List<b_product_attribute_Entity> list = new List<b_product_attribute_Entity>();
            foreach (var id in idList)
            {
                b_product_attribute_Entity entity = new b_product_attribute_Entity()
                {
                    P_Attribute_ID = id
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
        [ProducesResponseType(200, Type = typeof(ApiResult<List<b_product_attribute_Entity>>))]
        public ActionResult<object> GetList(int Product_ID, int pageindex = 1, int pagesize = 24)
        {
            var (list, total) = this._repository.GetList(Product_ID, pageindex, pagesize);
            return list.ResponseSuccess("", total);
        }

    }
}
