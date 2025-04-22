using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace NZWalkAPI.CustomActionFilter
{
    public class ValidateModeAtribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // if we have atribute [skipValidation] then skip validation
            var skipValidation = context.ActionDescriptor.EndpointMetadata
                .OfType<SkipValidationAttribute>()
                .Any();
            if (skipValidation) return;

            var modelState = context.ModelState;
            if (!modelState.IsValid)
            {
                var errors = modelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                context.Result = new BadRequestObjectResult(new { Errors = errors });
            }
        }
    }
   
}
