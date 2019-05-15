using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pan.Code;
using Pan.Code.Extentions;
using Hoshino.API.Filters;
using Hoshino.Entity;
using Hoshino.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using Hoshino.API.ViewModels;

namespace Hoshino.API.Controllers
{
    /// <summary>
    /// 系统用户
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class sys_userController : ControllerBase
    {
        private readonly ILogger<sys_userController> _logger;
        private readonly Isys_user_Repository _repository;
        public IConfiguration _configuration { get; }
        public sys_userController(ILogger<sys_userController> logger, Isys_user_Repository repository, IConfiguration configuration)
        {
            this._logger = logger;
            this._repository = repository;
            this._configuration = configuration;
        }
        /// <summary>
        /// 新增
        /// </summary>
        [Authorize]
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(ApiResult<bool>))]
        public ActionResult<object> Post([FromBody]sys_user_Entity model)
        {
            return this._repository.Insert(model).ResponseSuccess();
        }

        /// <summary>
        /// 修改
        /// </summary>
        [Authorize]
        [HttpPut]
        [ProducesResponseType(200, Type = typeof(ApiResult<bool>))]
        public ActionResult<object> Update([FromBody]sys_user_Entity model)
        {
            return this._repository.Update(model).ResponseSuccess();
        }

        /// <summary>
        /// 删除
        /// </summary>
        [Authorize]
        [HttpDelete]
        [ProducesResponseType(200, Type = typeof(ApiResult<bool>))]
        public ActionResult<object> Delete(int User_ID)
        {
            return this._repository.Delete(User_ID).ResponseSuccess();
        }

        /// <summary>
        /// 获取单个
        /// </summary>
        [Authorize]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ApiResult<sys_user_Entity>))]
        public ActionResult<object> Get(int User_ID)
        {
            return this._repository.Get(User_ID).ResponseSuccess();
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        [Authorize]
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(ApiResult<List<sys_user_Entity>>))]
        public ActionResult<object> GetList([FromBody]sys_user_Entity model, int pageindex, int pagesize)
        {
            var (list, total) = this._repository.GetList(model, pageindex, pagesize);
            return list.ResponseSuccess("", total);
        }
        /// <summary>
        /// 后台登录接口
        /// </summary>
        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(ApiResult<LoginVM>))]
        public ActionResult<object> Login([FromBody]sys_user_Entity model)
        {
            LoginVM login = new LoginVM();
            sys_user_Entity user = this._repository.GetUserByAccount(model.User_Account);
            if (user != null)
            {
                if (!model.Password.Equals(user.Password))
                {
                    return login.ResponseNotLogin("登录失败");
                }
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this._configuration["JWT:SecurityKey"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var claims = new[] {new Claim(ClaimTypes.Name,user.ToJson())};

                var authTime = DateTime.UtcNow;
                var expiresAt = authTime.AddDays(7);
                var token = new JwtSecurityToken(issuer: "*", audience: "*", claims: claims, expires: expiresAt, signingCredentials: creds);
                login.token = "Bearer " + new JwtSecurityTokenHandler().WriteToken(token);
                HttpContext.Session.SetString(login.token, user.ToJson());
            }
            return login.ResponseSuccess();
        }
    }
}
