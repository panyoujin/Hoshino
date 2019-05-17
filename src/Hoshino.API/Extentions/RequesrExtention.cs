using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using Hoshino.Entity;
using Microsoft.AspNetCore.Mvc;
using Pan.Code.Extentions;
using Pan.Code.UserException;

namespace Hoshino.API.Extentions
{
    /// <summary>
    /// 
    /// </summary>
    public static class RequesrExtention
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="controller"></param>
        /// <returns></returns>
        public static sys_user_Entity GetLoginUser(this ControllerBase controller)
        {
            try
            {
                var token = controller.Request.Headers[Constant.LoginToken_Key].ToString();
                if (!string.IsNullOrWhiteSpace(token))
                {
                    var temp = new JwtSecurityTokenHandler().ReadJwtToken(token.Replace(Constant.JwtTokenPrefix, ""));
                    if (temp != null && temp.Claims != null && temp.Claims.Count() > 0)
                    {
                        return temp.Claims.FirstOrDefault().Value.ToModel<sys_user_Entity>();
                    }
                }
            }
            catch
            {
            }
            throw new NotLoginException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="entity"></param>
        public static void SetCreateUserInfo(this ControllerBase controller, BaseEntity entity)
        {
            var loginUser = controller.GetLoginUser();
            entity.Create_User = loginUser.User_Name;
            entity.Create_UserId = loginUser.User_ID.ToString();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="entity"></param>
        public static void SetUpdateUserInfo(this ControllerBase controller, BaseEntity entity)
        {
            var loginUser = controller.GetLoginUser();
            entity.Update_User = loginUser.User_Name;
            entity.Update_UserId = loginUser.User_ID.ToString();
        }
    }
}
