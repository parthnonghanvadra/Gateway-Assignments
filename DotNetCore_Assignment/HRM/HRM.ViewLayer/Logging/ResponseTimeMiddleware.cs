﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HRM.ViewLayer.Logging
{
    public class ResponseTimeMiddleware
    {
        // Name of the Response Header, Custom Headers starts with "X-"  
        private const string RESPONSE_HEADER_RESPONSE_TIME = "X-Response-Time-ms";
        // Handle to the next Middleware in the pipeline  
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        public ResponseTimeMiddleware(RequestDelegate next, ILogger logger)
        {
            _next = next;
            _logger = logger;
        }
        public Task InvokeAsync(HttpContext context)
        {
            var controllerName = context.GetRouteValue("controller");
            var actionName = context.GetRouteValue("action");
            // Start the Timer using Stopwatch
            var watch = new Stopwatch();
            watch.Start();
            context.Response.OnStarting(() => {
                // Stop the timer information and calculate the time   
                watch.Stop();
                var responseTimeForCompleteRequest = watch.ElapsedMilliseconds;
                // Add the Response time information in the Response headers.   
                context.Response.Headers[RESPONSE_HEADER_RESPONSE_TIME] = responseTimeForCompleteRequest.ToString();
                _logger.LogInformation($"{controllerName}({actionName}) Response time Captured : {responseTimeForCompleteRequest}");
                return Task.CompletedTask;
            });
            // Call the next delegate/middleware in the pipeline   
            return this._next(context);
        }
    }
}
