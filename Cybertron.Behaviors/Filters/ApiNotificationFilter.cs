using Cybertron.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Net;
namespace Cybertron.Behaviors.Filters
{
    public class ApiNotificationFilter : ResultFilterAttribute
    {
        private readonly ILogger<ApiNotificationFilter> _logger;
        private readonly INotificationService _notifications;
        public ApiNotificationFilter(ILogger<ApiNotificationFilter> logger, INotificationService notifications)
        {
            _logger = logger;
            _notifications = notifications;
        }

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            if (_notifications.HasAny())
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Result = new JsonResult(_notifications.Messages);
                //context.Result = new JsonResult(new
                //{
                //    Notifications = _notifications.Messages,
                //    Result = (context.Result as ObjectResult).Value
                //});

                _logger.LogWarning(_notifications.Messages.Aggregate((acc, val) => $"{acc}, {val}"));
            }

            base.OnResultExecuting(context);
        }
    }
}
