
using Common.Entities;

namespace Common.Services.Infrastructure
{
    public interface ICurrentContextProvider
    {
        ContextSession GetCurrentContext();
    }
}
