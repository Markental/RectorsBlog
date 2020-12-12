using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace RectorsBlogAPI.Infrastructure.Filters
{
    public class ModelOrNotFoundActionFilter : ActionFilterAttribute
    {
        // Automatically send NotFound response sif model was not found in database
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Result is ObjectResult result) 
            {
                var model = result.Value;

                if(model == null)
                {
                    context.Result = new NotFoundResult();
                }
            }
        }
    }
}
