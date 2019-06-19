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
using System.Linq;
using Hoshino.API.Extentions;

namespace Hoshino.API.Controllers
{
    /// <summary>
    /// b_product_attribute_template
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class b_product_attribute_templateController : ControllerBase
    {
        private readonly ILogger<b_product_attribute_templateController> _logger;
        private readonly Ib_product_attribute_template_Repository _repository;
        /// <summary>
        /// 构造函数
        /// </summary>
        public b_product_attribute_templateController(ILogger<b_product_attribute_templateController> logger, Ib_product_attribute_template_Repository repository)
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
        public ActionResult<object> Post([FromBody] List<b_product_attribute_templateVM> modelList)
        {
            List<b_product_attribute_template_Entity> list = new List<b_product_attribute_template_Entity>();
            var ids = new List<int>();
            foreach (var model in modelList)
            {
                b_product_attribute_template_Entity entity = model.ConvertToT<b_product_attribute_template_Entity>();
                this.SetCreateUserInfo(entity);
                list.Add(entity);
            }
            this._repository.Delete();
            return this._repository.Insert(list).ResponseSuccess();

        }

        /// <summary>
        /// 获取列表
        /// </summary>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ApiResult<List<b_product_attribute_template_Entity>>))]
        public ActionResult<object> GetList()
        {
            var list = this._repository.GetList<b_product_attribute_template_Entity>();
            return list.ResponseSuccess("");
        }

    }
}
