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
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {

        private readonly ILogger<b_categoryController> _logger;
        private readonly Ib_product_Repository _repository;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="repository"></param>
        public HomeController(ILogger<b_categoryController> logger, Ib_product_Repository repository)
        {
            this._logger = logger;
            this._repository = repository;
        }



    }
}

