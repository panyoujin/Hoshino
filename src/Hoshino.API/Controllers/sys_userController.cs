﻿using System;
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
    public class sys_userController : ControllerBase
    {
        private readonly ILogger<sys_userController> _logger;
        private readonly Isys_user_Repository _repository;
        public sys_userController(ILogger<sys_userController> logger,Isys_user_Repository repository)
        {
            this._logger = logger;
            this._repository = repository;
        }
        /// <summary>
        /// 新增
        /// <summary>
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(ApiResult<bool>))]
        public ActionResult<object> Post([FromBody]sys_user_Entity model)
        {
            return this._repository.Insert(model).ResponseSuccess();
        }

        /// <summary>
        /// 修改
        /// <summary>
        [HttpPut]
        [ProducesResponseType(200, Type = typeof(ApiResult<bool>))]
        public ActionResult<object> Update([FromBody]sys_user_Entity model)
        {
            return this._repository.Update(model).ResponseSuccess();
        }

        /// <summary>
        /// 删除
        /// <summary>
        [HttpDelete]
        [ProducesResponseType(200, Type = typeof(ApiResult<bool>))]
        public ActionResult<object> Delete([FromBody]sys_user_Entity model)
        {
            return this._repository.Delete(model).ResponseSuccess();
        }

        /// <summary>
        /// 获取单个
        /// <summary>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ApiResult<sys_user_Entity>))]
        public ActionResult<object> Get(int User_ID)
        {
            sys_user_Entity model = new sys_user_Entity();
            model.User_ID = User_ID;
            return this._repository.Get(model).ResponseSuccess();
        }

        /// <summary>
        /// 获取列表
        /// <summary>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ApiResult<List<sys_user_Entity>>))]
        public ActionResult<object> GetList([FromBody]sys_user_Entity model,int pageindex,int pagesize)
        {
            var (list,total) = this._repository.GetList(model, pageindex, pagesize) ;
            return list.ResponseSuccess("",total);
        }

    }
}
