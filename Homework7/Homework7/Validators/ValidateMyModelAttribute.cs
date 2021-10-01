using Microsoft.AspNetCore.Mvc.Filters;
using Serilog;

namespace Homework7.Validators
{
    public class ValidateMyModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                Log.Warning($"Invalid {context.ModelState}");
            }
        }
    }
}
