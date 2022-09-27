using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinTracker.Core.Filters
{
    public class HttpResponseExceptionFilter : IActionFilter, IOrderedFilter
    {
        public int Order => int.MaxValue;

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // not sure if i will use this yet
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {

        }
    }
}
