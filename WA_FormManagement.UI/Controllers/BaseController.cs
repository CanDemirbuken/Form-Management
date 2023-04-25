using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

public class BaseController : Controller
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.HttpContext.User.Identity.IsAuthenticated)
        {
            context.Result = new RedirectToActionResult("Index", "Login", null);
        }

        base.OnActionExecuting(context);
    }
}
