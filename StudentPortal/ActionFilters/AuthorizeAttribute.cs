using Entities.AuthenticationModels;
using Microsoft.AspNetCore.Mvc.Filters;

namespace StudentPortal.ActionFilters
{
    public class AuthorizationFilter : Attribute, IAuthorizationFilter
    {
        public AuthorizationFilter()
        {
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any())
            {
                return;
            }


            UserAuthenticatedDto auth = (UserAuthenticatedDto)context.HttpContext.Items[HeadersConstants.User];
            if (auth == null)
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Authentication", action = "Login" }));
                return;
            }
        }
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : TypeFilterAttribute
    {
        public AuthorizeAttribute()
            : base(typeof(AuthorizationFilter))
        {
            Arguments = new object[] { };
        }
    }
}
