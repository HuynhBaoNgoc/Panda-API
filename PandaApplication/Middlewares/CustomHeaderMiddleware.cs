using Microsoft.AspNetCore.Http;
using PandaApplication.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PandaApplication.Middlewares
{
    public class CustomHeaderMiddleware
    {
        private readonly RequestDelegate _next;
        public CustomHeaderMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context, CustomHeaderService customHeaderService)
        {
            string? customHeader = context.Request.Headers["Custom-Header"].FirstOrDefault();
            if (!string.IsNullOrWhiteSpace(customHeader))
            {
                customHeaderService.CustomHeaderValue = customHeader;
                Console.WriteLine($"My custom header value is '{customHeaderService.CustomHeaderValue}'");
            }
            await _next(context);
        }
    }
}
