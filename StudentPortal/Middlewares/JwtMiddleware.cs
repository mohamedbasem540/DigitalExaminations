using Entities.AuthenticationModels;

namespace StudentPortal.Middlewares
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IAuthenticationManager accountService, IJwtUtils jwtUtils)
        {
            UserAuthenticatedDto auth = (UserAuthenticatedDto)context.Items[HeadersConstants.User];

            if (auth == null)
            {
                string token = context.Request.Cookies[HeadersConstants.AuthorizationToken];
                if (!string.IsNullOrWhiteSpace(token))
                {
                    int? userId = jwtUtils.ValidateJwtToken(token);
                    if (userId != null)
                    {
                        // attach user to context on successful jwt validation
                        context.Items[HeadersConstants.User] = await accountService.GetById(userId.Value);
                    }
                }
            }

            await _next(context);
        }
    }
}
