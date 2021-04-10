using FluentValidation;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace OconnorEvents.EventCatalog.Middleware
{
    public class ValidationFailedMiddleware
    {
        private readonly RequestDelegate _next;

        public ValidationFailedMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ValidationException ex)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

                var response = new
                {
                    Message = "One or more validation failures detected",
                    Errors = ex.Errors.Select(e => new { Property = e.PropertyName, Error = e.ErrorMessage })
                };

                await context.Response.WriteAsync(JsonConvert.SerializeObject(response));
            }
        }
    }
}
