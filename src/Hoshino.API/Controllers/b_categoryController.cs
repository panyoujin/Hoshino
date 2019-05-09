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
    public class b_categoryController : ControllerBase
    {
        private readonly ILogger<b_categoryController> _logger;
        private readonly Ib_category_Repository _repository;
        public b_categoryController(ILogger<b_categoryController> logger,Ib_category_Repository repository)
        {
            this._logger = logger;
            this._repository = repository;
        }
        /// <summary>
        /// 新增
        /// <summary>
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(ApiResult<bool>))]
        public ActionResult<object> Post([FromBody]b_category_Entity model)
        {
            return this._repository.Insert(model).ResponseSuccess();
        }

        /// <summary>
        /// 修改
        /// <summary>
        [HttpPut]
        [ProducesResponseType(200, Type = typeof(ApiResult<bool>))]
        public ActionResult<object> Update([FromBody]b_category_Entity model)
        {
            return this._repository.Update(model).ResponseSuccess();
        }

        /// <summary>
        /// 删除
        /// <summary>
        [HttpDelete]
        [ProducesResponseType(200, Type = typeof(ApiResult<bool>))]
        public ActionResult<object> Delete([FromBody]b_category_Entity model)
        {
            return this._repository.Delete(model).ResponseSuccess();
        }

        /// <summary>
        /// 获取单个
        /// <summary>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ApiResult<b_category_Entity>))]
        public ActionResult<object> Get(int Category_ID)
        {
            b_category_Entity model = new b_category_Entity();
            model.Category_ID = Category_ID;
            return this._repository.Get(model).ResponseSuccess();
        }

        /// <summary>
        /// 获取列表
        /// <summary>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ApiResult<List<b_category_Entity>>))]
        public ActionResult<object> GetList([FromBody]b_category_Entity model,int pageindex,int pagesize)
        {
            var (list,total) = this._repository.GetList(model, pageindex, pagesize) ;
            return list.ResponseSuccess("",total);
        }

    }
}
