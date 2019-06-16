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

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class b_logo_resourcesController : ControllerBase
    {
        private readonly ILogger<b_logo_resourcesController> _logger;
        private readonly Ib_logo_resources_Repository _repository;
        /// <summary>
        /// 构造函数
        /// </summary>
        public b_logo_resourcesController(ILogger<b_logo_resourcesController> logger, Ib_logo_resources_Repository repository)
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
        public ActionResult<object> Post([FromBody]b_logo_resourcesVM model)
        {
            b_logo_resources_Entity entity = model.ConvertToT<b_logo_resources_Entity>();
            this.SetCreateUserInfo(entity);
            return this._repository.Insert(entity).ResponseSuccess();
        }


        /// <summary>
        /// 删除
        /// </summary>
        [Authorize]
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(ApiResult<bool>))]
        public ActionResult<object> Delete([FromBody]b_logo_resourcesVM model)
        {
            b_logo_resources_Entity entity = new b_logo_resources_Entity();
            this.SetUpdateUserInfo(entity);
            return this._repository.Delete(model.Logo_ID).ResponseSuccess();
        }


        /// <summary>
        /// 获取列表
        /// </summary>
        [Authorize]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ApiResult<List<b_logo_resources_Entity>>))]
        public ActionResult<object> GetList(int pageindex = 1, int pagesize = 24)
        {
            b_logo_resources_Entity entity = new b_logo_resources_Entity();
            var (list, total) = this._repository.GetList(entity, pageindex, pagesize);
            return list.ResponseSuccess("", total);
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ApiResult<List<b_logo_resources_Entity>>))]
        public ActionResult<object> GetIndexList()
        {
            b_logo_resources_Entity model = new b_logo_resources_Entity();
            var (list, total) = this._repository.GetList(model, -1, -1);
            return list.ResponseSuccess("", total);
        }
    }
}
