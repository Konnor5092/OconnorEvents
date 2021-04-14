using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using OconnorEvents.Mediatr.Core.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OconnorEvents.Mediatr.Core.Middleware
{
    public class EntityExistsMiddleware
    {
        private readonly RequestDelegate _next;

        public EntityExistsMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (EntityNotFoundException ex)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;

                var response = new
                {
                    Message = "One or more entities don't exist",
                    Errors = ex.Errors.Select(e => new { Property = e.PropertyName, Error = e.ErrorMessage })
                };

                await context.Response.WriteAsync(JsonConvert.SerializeObject(response));
            }
        }
    }
}
