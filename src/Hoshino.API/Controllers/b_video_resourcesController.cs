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
    /// b_video_resources
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class b_video_resourcesController : ControllerBase
    {
        private readonly ILogger<b_video_resourcesController> _logger;
        private readonly Ib_video_resources_Repository _repository;
        /// <summary>
        /// 构造函数
        /// </summary>
        public b_video_resourcesController(ILogger<b_video_resourcesController> logger, Ib_video_resources_Repository repository)
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
        public ActionResult<object> Post([FromBody]b_video_resourcesVM model)
        {
            b_video_resources_Entity entity = model.ConvertToT<b_video_resources_Entity>();
            return this._repository.Insert(entity).ResponseSuccess();
        }

        /// <summary>
        /// 修改
        /// </summary>
        [Authorize]
        [HttpPut]
        [ProducesResponseType(200, Type = typeof(ApiResult<bool>))]
        public ActionResult<object> Update([FromBody]b_video_resourcesVM model)
        {
            b_video_resources_Entity entity = model.ConvertToT<b_video_resources_Entity>();
            return this._repository.Update(entity).ResponseSuccess();
        }

        /// <summary>
        /// 删除
        /// </summary>
        [Authorize]
        [HttpDelete]
        [ProducesResponseType(200, Type = typeof(ApiResult<bool>))]
        public ActionResult<object> Delete(int Video_ID)
        {
            return this._repository.Delete(Video_ID).ResponseSuccess();
        }

        /// <summary>
        /// 获取单个
        /// </summary>
        [Authorize]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ApiResult<b_video_resources_Entity>))]
        public ActionResult<object> Get(int Video_ID)
        {
            return this._repository.Get(Video_ID).ResponseSuccess();
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(ApiResult<List<b_video_resources_Entity>>))]
        public ActionResult<object> GetList([FromBody]b_video_resourcesVM model, int pageindex, int pagesize)
        {
            b_video_resources_Entity entity = model.ConvertToT<b_video_resources_Entity>();
            var (list, total) = this._repository.GetList(entity, pageindex, pagesize);
            return list.ResponseSuccess("", total);
        }

        /// <summary>
        /// 获取首页Video列表
        /// </summary>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ApiResult<List<b_video_resources_Entity>>))]
        public ActionResult<object> GetIndexList()
        {
            b_video_resources_Entity model = new b_video_resources_Entity();
            model.Video_Location = Video_Location.Index.ToString();
            model.Video_Status = (int)Table_Status.Effective;
            var (list, total) = this._repository.GetList(model, 1, 1);
            return list.ResponseSuccess("", total);
        }

    }
}
