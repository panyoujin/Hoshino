﻿using System;
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
    /// b_appointment_consultation
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class b_appointment_consultationController : ControllerBase
    {
        private readonly ILogger<b_appointment_consultationController> _logger;
        private readonly Ib_appointment_consultation_Repository _repository;
        /// <summary>
        /// 构造函数
        /// </summary>
        public b_appointment_consultationController(ILogger<b_appointment_consultationController> logger, Ib_appointment_consultation_Repository repository)
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
        public ActionResult<object> Post([FromBody]b_appointment_consultationVM model, string code)
        {
            if (string.IsNullOrWhiteSpace(code) || string.IsNullOrWhiteSpace(HttpContext.Session.GetString(Constant.Session_CheckCode)) || !code.ToLower().Equals(HttpContext.Session.GetString(Constant.Session_CheckCode).ToLower()))
            {
                return this.ResponseUnknown("验证码错误");
            }
            HttpContext.Session.Remove(Constant.Session_CheckCode);
            b_appointment_consultation_Entity entity = model.ConvertToT<b_appointment_consultation_Entity>();
            this.SetCreateUserInfo(entity);
            return this._repository.Insert(entity).ResponseSuccess();
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model">修改实体</param>
        /// <param name="AC_ID">主键ID</param>
        /// <returns></returns>
        [Authorize]
        [HttpPut]
        [ProducesResponseType(200, Type = typeof(ApiResult<bool>))]
        public ActionResult<object> Update([FromBody]b_appointment_consultationVM model, int AC_ID)
        {
            b_appointment_consultation_Entity entity = model.ConvertToT<b_appointment_consultation_Entity>();
            this.SetUpdateUserInfo(entity);
            return this._repository.Update(entity, AC_ID).ResponseSuccess();
        }

        /// <summary>
        /// 删除
        /// </summary>
        [Authorize]
        [HttpDelete]
        [ProducesResponseType(200, Type = typeof(ApiResult<bool>))]
        public ActionResult<object> Delete(int AC_ID)
        {
            b_appointment_consultation_Entity entity = new b_appointment_consultation_Entity();
            this.SetUpdateUserInfo(entity);
            this._repository.Update(entity, AC_ID);
            return this._repository.Delete(AC_ID).ResponseSuccess();
        }

        /// <summary>
        /// 获取单个
        /// </summary>
        [Authorize]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ApiResult<b_appointment_consultation_Entity>))]
        public ActionResult<object> Get(int AC_ID)
        {
            return this._repository.Get(AC_ID).ResponseSuccess();
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(ApiResult<List<b_appointment_consultation_Entity>>))]
        public ActionResult<object> GetList([FromBody]b_appointment_consultationVM model, int pageindex, int pagesize)
        {
            b_appointment_consultation_Entity entity = model.ConvertToT<b_appointment_consultation_Entity>();
            var (list, total) = this._repository.GetList(entity, pageindex, pagesize);
            return list.ResponseSuccess("", total);
        }

    }
}
