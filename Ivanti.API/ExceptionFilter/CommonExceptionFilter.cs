using Ivanti.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Ivanti.API.ExceptionFilter
{
	public class CommonExceptionFilter : ExceptionFilterAttribute
	{
		public override void OnException(ExceptionContext context)
		{
			var exception = context.Exception;
            var httpContext = context.HttpContext;
			int statusCode;

			if(exception.GetType() == typeof(CustomException))
			{
				statusCode = 400;
			}
			else
			{
				statusCode = 500;
			}

			httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = statusCode;

			var errorResponse = new ErrorResponse
			{
				Error = new Error 
				{
					StatusCode = statusCode,
					Message = exception.Message
				}
			};

			context.Result = new JsonResult(errorResponse);
			base.OnException(context);
		}
	}
}
