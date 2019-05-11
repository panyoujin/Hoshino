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
    public class b_contactController : ControllerBase
    {
        private readonly ILogger<b_contactController> _logger;
        private readonly Ib_contact_Repository _repository;
        public b_contactController(ILogger<b_contactController> logger,Ib_contact_Repository repository)
        {
            this._logger = logger;
            this._repository = repository;
        }
        /// <summary>
        /// 新增
        /// <summary>
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(ApiResult<bool>))]
        public ActionResult<object> Post([FromBody]b_contact_Entity model)
        {
            return this._repository.Insert(model).ResponseSuccess();
        }

        /// <summary>
        /// 修改
        /// <summary>
        [HttpPut]
        [ProducesResponseType(200, Type = typeof(ApiResult<bool>))]
        public ActionResult<object> Update(int Contact_ID)
        {
            return this._repository.Update(Contact_ID).ResponseSuccess();
        }

        /// <summary>
        /// 删除
        /// <summary>
        [HttpDelete]
        [ProducesResponseType(200, Type = typeof(ApiResult<bool>))]
        public ActionResult<object> Delete(int Contact_ID)
        {
            return this._repository.Delete(Contact_ID).ResponseSuccess();
        }

        /// <summary>
        /// 获取单个
        /// <summary>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ApiResult<b_contact_Entity>))]
        public ActionResult<object> Get(int Contact_ID)
        {
            return this._repository.Get(Contact_ID).ResponseSuccess();
        }

        /// <summary>
        /// 获取列表
        /// <summary>
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(ApiResult<List<b_contact_Entity>>))]
        public ActionResult<object> GetList([FromBody]b_contact_Entity model,int pageindex,int pagesize)
        {
            var (list,total) = this._repository.GetList(model, pageindex, pagesize) ;
            return list.ResponseSuccess("",total);
        }

    }
}
