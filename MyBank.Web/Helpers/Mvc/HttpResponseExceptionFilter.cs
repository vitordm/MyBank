using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBank.Web.Helpers.Mvc
{
    public class HttpResponseExceptionFilter : IActionFilter, IOrderedFilter
    {
        public int Order { get; set; } = int.MaxValue - 10;

        public void OnActionExecuting(ActionExecutingContext context)
        {
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {

            var uri = context.HttpContext.Request.Path.ToUriComponent();

            if (context.Exception != null && uri.StartsWith("/api"))
            {
                HandleApiException(context);
            }

        }

        private void HandleApiException(ActionExecutedContext context)
        {
            if (context.Exception is InvalidOperationException exception)
            {
                context.Result = new ObjectResult(exception.Message)
                {
                    StatusCode = 400
                };
                context.ExceptionHandled = true;
                return;
            }

            if (context.Exception is ApplicationException exception1)
            {
                context.Result = new ObjectResult(exception1.Message)
                {
                    StatusCode = 400
                };
                context.ExceptionHandled = true;
                return;
            }

        }
    }
}
