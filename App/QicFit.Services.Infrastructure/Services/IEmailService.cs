using QicFit.DTO;
using System.Threading.Tasks;

namespace QicFit.Services.Infrastructure.Services
{
    public interface IEmailService
    {
        EmailMessageDTO Create(EmailMessageDTO message);
    }
}
