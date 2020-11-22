using Cybertron.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Cybertron.Behaviors.Filters
{
    public class ApiExceptionFilter : ExceptionFilterAttribute
    {
        private readonly INotificationService _notification;
        private readonly ILogger<ApiExceptionFilter> _logger;
        public ApiExceptionFilter(INotificationService notification, ILogger<ApiExceptionFilter> logger)
        {
            _notification = notification;
            _logger = logger;
        }
        public override void OnException(ExceptionContext context)
        {
            string[] messages = _notification.Messages.Concat(new string[] { context.Exception.Message }).ToArray();

            if (context.Exception is ArgumentException || context.Exception is ArgumentNullException || context.Exception is ValidationException)
            {
                context.HttpContext.Response.StatusCode = 400;
                context.Result = new JsonResult(messages);
            }
            else
            {
                context.HttpContext.Response.StatusCode = 500;
                context.Result = new JsonResult(messages);
            }

            _logger.LogError(messages.Aggregate((acc, val) => $"{acc}, {val}"));

            base.OnException(context);
        }
    }
}
