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
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class b_productController : ControllerBase
    {
        private readonly ILogger<b_productController> _logger;
        private readonly Ib_product_Repository _repository;
        public b_productController(ILogger<b_productController> logger,Ib_product_Repository repository)
        {
            this._logger = logger;
            this._repository = repository;
        }
        /// <summary>
        /// 新增
        /// <summary>
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(ApiResult<bool>))]
        public ActionResult<object> Post([FromBody]b_product_Entity model)
        {
            return this._repository.Insert(model).ResponseSuccess();
        }

        /// <summary>
        /// 修改
        /// <summary>
        [HttpPut]
        [ProducesResponseType(200, Type = typeof(ApiResult<bool>))]
        public ActionResult<object> Update(int Product_ID)
        {
            return this._repository.Update(Product_ID).ResponseSuccess();
        }

        /// <summary>
        /// 删除
        /// <summary>
        [HttpDelete]
        [ProducesResponseType(200, Type = typeof(ApiResult<bool>))]
        public ActionResult<object> Delete(int Product_ID)
        {
            return this._repository.Delete(Product_ID).ResponseSuccess();
        }

        /// <summary>
        /// 获取单个
        /// <summary>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ApiResult<b_product_Entity>))]
        public ActionResult<object> Get(int Product_ID)
        {
            return this._repository.Get(Product_ID).ResponseSuccess();
        }

        /// <summary>
        /// 获取列表
        /// <summary>
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(ApiResult<List<b_product_Entity>>))]
        public ActionResult<object> GetList([FromBody]b_product_Entity model,int pageindex,int pagesize)
        {
            var (list,total) = this._repository.GetList(model, pageindex, pagesize) ;
            return list.ResponseSuccess("",total);
        }

        /// <summary>
        /// 获取最新产品列表
        /// <summary>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ApiResult<List<b_product_Entity>>))]
        public ActionResult<object> GetNewProductList()
        {
            var (list, total) = this._repository.GetNewProductList<b_product_Entity>();
            return list.ResponseSuccess("", total);
        }

        /// <summary>
        /// 获取热门产品列表
        /// <summary>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ApiResult<List<b_product_Entity>>))]
        public ActionResult<object> GetHotProductList()
        {
            var (list, total) = this._repository.GetNewProductList<b_product_Entity>();
            return list.ResponseSuccess("", total);
        }
    }
}
