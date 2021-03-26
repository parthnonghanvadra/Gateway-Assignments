using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace HRM.ViewLayer.Filters
{
    public class AddCustomHeaderFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            context.HttpContext.Response.Headers.Add("Name", "Parth Nonghanvadra");
        }
    }
}
