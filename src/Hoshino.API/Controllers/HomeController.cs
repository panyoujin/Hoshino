using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hoshino.Entity;
using Hoshino.IRepository;
using Hoshino.Util;
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

        /// <summary>
        /// 获取验证码
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public FileResult GetValidateCode()
        {
            string code = string.Empty;
            byte[] imageFile = VerificationCodeImage.CreateImage(out code);
            HttpContext.Session.Set(Constant.Session_CheckCode, Encoding.UTF8.GetBytes(code));
            return File(imageFile, @"image/gif");
        }


    }
}

