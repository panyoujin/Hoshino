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
using Hoshino.API.Extentions;

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
        private readonly IConfiguration _configuration;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="repository"></param>
        /// <param name="configuration"></param>
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
        public ActionResult<object> Post([FromBody]sys_userVM model)
        {
            sys_user_Entity entity = model.ConvertToT<sys_user_Entity>();
            this.SetCreateUserInfo(entity);
            return this._repository.Insert(entity).ResponseSuccess();
        }

        /// <summary>
        /// 修改
        /// </summary>
        [Authorize]
        [HttpPut]
        [ProducesResponseType(200, Type = typeof(ApiResult<bool>))]
        public ActionResult<object> Update([FromBody]sys_userVM model, int User_ID)
        {
            sys_user_Entity entity = model.ConvertToT<sys_user_Entity>();
            this.SetUpdateUserInfo(entity);
            return this._repository.Update(entity, User_ID).ResponseSuccess();
        }

        /// <summary>
        /// 删除
        /// </summary>
        [Authorize]
        [HttpDelete]
        [ProducesResponseType(200, Type = typeof(ApiResult<bool>))]
        public ActionResult<object> Delete(int User_ID)
        {
            sys_user_Entity entity = new sys_user_Entity();
            this.SetUpdateUserInfo(entity);
            this._repository.Update(entity, User_ID);
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
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(ApiResult<List<sys_user_Entity>>))]
        public ActionResult<object> GetList([FromBody]sys_userVM model, int pageindex, int pagesize)
        {
            sys_user_Entity entity = model.ConvertToT<sys_user_Entity>();
            var (list, total) = this._repository.GetList(entity, pageindex, pagesize);
            return list.ResponseSuccess("", total);
        }
        /// <summary>
        /// 后台登录接口
        /// </summary>
        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(ApiResult<LoginVM>))]
        public ActionResult<object> Login([FromBody]LoginVM model)
        {
            LoginVM login = new LoginVM();
            sys_user_Entity user = this._repository.GetUserByAccount(model.User_Account);
            if (user == null || !model.Password.Equals(user.Password))
            {
                return login.ResponseNotLogin("登录失败");
            }
            user.Password = "";
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this._configuration["JWT:SecurityKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var claims = new[] { new Claim(ClaimTypes.Name, user.ToJson()) };

            var authTime = DateTime.UtcNow;
            var expiresAt = authTime.AddDays(7);
            var token = new JwtSecurityToken(issuer: "*", audience: "*", claims: claims, expires: expiresAt, signingCredentials: creds);
            login.token = Constant.JwtTokenPrefix + new JwtSecurityTokenHandler().WriteToken(token);
            //HttpContext.Session.SetString(login.token, user.ToJson());

            return login.ResponseSuccess();
        }
        /// <summary>
        /// 后台登出接口
        /// </summary>
        [Authorize]
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(ApiResult<bool>))]
        public ActionResult<object> Logout()
        {
            try
            {
                string authorization = HttpContext.Request.Headers[Constant.LoginToken_Key];
                HttpContext.Session.Remove(authorization);
            }
            catch
            {
                return false.ResponseSuccess();
            }


            return true.ResponseSuccess();
        }
    }
}
