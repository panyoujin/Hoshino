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
    /// Banner
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class b_banner_resourcesController : ControllerBase
    {
        private readonly ILogger<b_banner_resourcesController> _logger;
        private readonly Ib_banner_resources_Repository _repository;
        /// <summary>
        /// 构造函数
        /// </summary>
        public b_banner_resourcesController(ILogger<b_banner_resourcesController> logger, Ib_banner_resources_Repository repository)
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
        public ActionResult<object> Post([FromBody]b_banner_resourcesVM model)
        {
            b_banner_resources_Entity entity = model.ConvertToT<b_banner_resources_Entity>();
            this.SetCreateUserInfo(entity);
            return this._repository.Insert(entity).ResponseSuccess();
        }

        /// <summary>
        /// 修改
        /// </summary>
        [Authorize]
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(ApiResult<bool>))]
        public ActionResult<object> Update([FromBody]b_banner_resourcesVM model)
        {
            b_banner_resources_Entity entity = model.ConvertToT<b_banner_resources_Entity>();
            this.SetUpdateUserInfo(entity);
            return this._repository.Update(entity, model.Banner_ID).ResponseSuccess();
        }

        /// <summary>
        /// 删除
        /// </summary>
        [Authorize]
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(ApiResult<bool>))]
        public ActionResult<object> Delete([FromBody]b_banner_resourcesVM model)
        {
            b_banner_resources_Entity entity = new b_banner_resources_Entity();
            this.SetUpdateUserInfo(entity);
            this._repository.Update(entity, model.Banner_ID);
            return this._repository.Delete(model.Banner_ID).ResponseSuccess();
        }


        /// <summary>
        /// 获取单个
        /// </summary>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ApiResult<b_banner_resources_Entity>))]
        public ActionResult<object> Get(int Banner_ID)
        {
            b_banner_resources_Entity entity = new b_banner_resources_Entity();
            this.SetUpdateUserInfo(entity);
            this._repository.Update(entity, Banner_ID);
            return this._repository.Get(Banner_ID).ResponseSuccess();
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ApiResult<List<b_banner_resources_Entity>>))]
        public ActionResult<object> GetList(int pageindex = 1, int pagesize = 24)
        {
            b_banner_resources_Entity entity = new b_banner_resources_Entity();
            var (list, total) = this._repository.GetList(entity, pageindex, pagesize);
            return list.ResponseSuccess("", total);
        }

        /// <summary>
        /// 获取首页Banner列表  前台API
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ApiResult<List<b_banner_resources_Entity>>))]
        public ActionResult<object> GetIndexList()
        {
            b_banner_resources_Entity model = new b_banner_resources_Entity();
            model.Banner_Location = Banner_Location.Index.ToString();
            model.Banner_Status = (int)Table_Status.Effective; ;
            var (list, total) = this._repository.GetList(model, -1, -1);
            return list.ResponseSuccess("", total);
        }
    }
}
