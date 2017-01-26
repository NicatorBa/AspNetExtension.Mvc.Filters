using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspNetExtension.Mvc.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class ClientErrorFilter : Attribute, IAsyncActionFilter
    {
        private readonly IEnumerator<IErrorModule> _errorEnumerator;

        private ErrorFilterContext _errorContext;

        public ClientErrorFilter(SortedSet<IErrorModule> errorModules)
        {
            _errorEnumerator = errorModules.GetEnumerator();
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            ActionExecutedContext executedContext = await next();
            ObjectResult objectResult = executedContext.Result as ObjectResult;

            if (objectResult == null ||
                !objectResult.StatusCode.HasValue ||
                objectResult.StatusCode.Value < 400 ||
                objectResult.StatusCode.Value >= 500)
            {
                return;
            }

            _errorContext = new ErrorFilterContext(objectResult);

            await NextErrorModuleExecutionAsync();
        }

        public async Task NextErrorModuleExecutionAsync()
        {
            if (_errorEnumerator.MoveNext())
            {
                await _errorEnumerator.Current.InvokeAsync(_errorContext, NextErrorModuleExecutionAsync);
            }
        }
    }
}
