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
using Microsoft.AspNetCore.Http;

namespace Hoshino.API.Controllers
{
    /// <summary>
    /// b_contact
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class b_contactController : ControllerBase
    {
        private readonly ILogger<b_contactController> _logger;
        private readonly Ib_contact_Repository _repository;
        /// <summary>
        /// 构造函数
        /// </summary>
        public b_contactController(ILogger<b_contactController> logger, Ib_contact_Repository repository)
        {
            this._logger = logger;
            this._repository = repository;
        }
        /// <summary>
        /// 新增 前台API
        /// </summary>
        [Authorize]
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(ApiResult<bool>))]
        public ActionResult<object> Post([FromBody]b_contactVM model, string code)
        {
            if (string.IsNullOrWhiteSpace(code) || string.IsNullOrWhiteSpace(HttpContext.Session.GetString(Constant.Session_CheckCode)) || !code.ToLower().Equals(HttpContext.Session.GetString(Constant.Session_CheckCode).ToLower()))
            {
                return this.ResponseUnknown("验证码错误");
            }
            HttpContext.Session.Remove(Constant.Session_CheckCode);
            b_contact_Entity entity = model.ConvertToT<b_contact_Entity>();
            this.SetCreateUserInfo(entity);
            return this._repository.Insert(entity).ResponseSuccess();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="Contact_ID"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(ApiResult<bool>))]
        public ActionResult<object> UpdateStatus([FromBody]b_contactVM model, int Contact_ID)
        {
            b_contact_Entity entity = new b_contact_Entity
            {
                Contact_Status = 1,
                Processing_Result = model.Processing_Result
            };
            this.SetUpdateUserInfo(entity);
            return this._repository.Update(entity, Contact_ID).ResponseSuccess();
        }

        /// <summary>
        /// 删除
        /// </summary>
        [Authorize]
        [HttpDelete]
        [ProducesResponseType(200, Type = typeof(ApiResult<bool>))]
        public ActionResult<object> Delete(int Contact_ID)
        {
            b_contact_Entity entity = new b_contact_Entity();
            this.SetUpdateUserInfo(entity);
            this._repository.Update(entity, Contact_ID);
            return this._repository.Delete(Contact_ID).ResponseSuccess();
        }

        /// <summary>
        /// 获取单个
        /// </summary>
        [Authorize]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ApiResult<b_contact_Entity>))]
        public ActionResult<object> Get(int Contact_ID)
        {
            return this._repository.Get(Contact_ID).ResponseSuccess();
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        [Authorize]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ApiResult<List<b_contact_Entity>>))]
        public ActionResult<object> GetList(string Company, string Phone, int Contact_Status, int pageindex, int pagesize)
        {
            b_contact_Entity entity = new b_contact_Entity
            {
                Company = Company,
                Phone = Phone,
                Contact_Status = Contact_Status
            };
            var (list, total) = this._repository.GetList(entity, pageindex, pagesize);
            return list.ResponseSuccess("", total);
        }

    }
}
