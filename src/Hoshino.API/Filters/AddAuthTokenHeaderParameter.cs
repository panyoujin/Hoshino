﻿using System.Collections.Generic;
using System.Linq;
using Hoshino.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Controllers;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Hoshino.API.Filters
{
    /// <summary>
    /// 控制swagger中是否需要添加accesstoken验证
    /// </summary>
    public class AddAuthTokenHeaderParameter : IOperationFilter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="context"></param>
        public void Apply(Operation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null) operation.Parameters = new List<IParameter>();
            var attrs = context.ApiDescription.ActionDescriptor.AttributeRouteInfo;

            //先判断是否是匿名访问,
            var descriptor = context.ApiDescription.ActionDescriptor as ControllerActionDescriptor;
            if (descriptor != null)
            {
                var actionAttributes = descriptor.MethodInfo.GetCustomAttributes(inherit: true);
                bool isAuthorize = actionAttributes.Any(a => a is AuthorizeAttribute);
                //非匿名的方法,链接中添加accesstoken值
                operation.Parameters.Add(new NonBodyParameter()
                {
                    Name = Constant.LoginToken,
                    In = "header",//query header body path formData
                    Type = "string",
                    Required = isAuthorize //是否必选
                });

            }
        }
    }
}
