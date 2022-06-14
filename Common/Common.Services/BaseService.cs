
using Common.Entities;
using Common.Services.Infrastructure;

namespace Common.Services
{
    public abstract class BaseService
    {
        protected ICurrentContextProvider contextProvider;
        protected readonly ContextSession Session;

        protected BaseService(ICurrentContextProvider contextProvider)
        {
            this.contextProvider = contextProvider;
            Session = contextProvider.GetCurrentContext();
        }
    }
}
