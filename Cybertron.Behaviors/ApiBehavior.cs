using Cybertron.Behaviors.Filters;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Cybertron.Behaviors
{
    public static class ApiBehavior
    {
        public static void Configure(MvcOptions options)
        {
            options.Filters.Add<ApiExceptionFilter>();
            options.Filters.Add<ApiNotificationFilter>();
        }
    }
}
