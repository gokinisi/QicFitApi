
using Common.Entities;
using Common.Services.Infrastructure;
using Microsoft.AspNetCore.Http;

namespace Common.WebApiCore
{
    public class CurrentContextProvider : ICurrentContextProvider
    {
        private readonly IHttpContextAccessor _accessor;
        public CurrentContextProvider(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public ContextSession GetCurrentContext()
        {
            if (_accessor.HttpContext.User != null && _accessor.HttpContext.User.Identity.IsAuthenticated)
            {
                var currentUserId = _accessor.HttpContext.User.GetUserId();

                if (currentUserId > 0)
                {
                    return new ContextSession { UserId = currentUserId };
                }
            }

            return null;
        }
    }
}
