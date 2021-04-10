using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OconnorEvents.EventCatalog.Middleware
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseValidationFailedMiddleware(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ValidationFailedMiddleware>();
        }
    }
}
