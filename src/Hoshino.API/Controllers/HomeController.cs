using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hoshino.Entity;
using Hoshino.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pan.Code;
using Pan.Code.Extentions;

namespace Hoshino.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {

        private readonly ILogger<b_categoryController> _logger;
        private readonly Ib_product_Repository _repository;
        public HomeController(ILogger<b_categoryController> logger, Ib_product_Repository repository)
        {
            this._logger = logger;
            this._repository = repository;
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

