﻿using FiltersSample.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace FiltersSample.Filters
{
    #region snippet_TypeFilterAttribute
    public class SampleActionFilterAttribute : TypeFilterAttribute
    {
        public SampleActionFilterAttribute()
                             :base(typeof(SampleActionFilterImpl))
        {
        }

        private class SampleActionFilterImpl : IActionFilter
        {
            private readonly ILogger _logger;
            public SampleActionFilterImpl(ILoggerFactory loggerFactory)
            {
                _logger = loggerFactory.CreateLogger<
                                        SampleActionFilterAttribute>();
            }

            public void OnActionExecuting(ActionExecutingContext context)
            {
               _logger.LogInformation(
                         "SampleActionFilterAttribute.OnActionExecuting");
                // perform some business logic work

            }

            public void OnActionExecuted(ActionExecutedContext context)
            {
                // perform some business logic work
                _logger.LogInformation(
                         "SampleActionFilterAttribute.OnActionExecuted");
            }
        }
    }
    #endregion
}