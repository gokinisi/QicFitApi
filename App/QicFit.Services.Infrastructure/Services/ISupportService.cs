using QicFit.DTO;
using QicFit.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QicFit.Services.Infrastructure.Services
{
    public interface ISupportService
    {
        SupportMessageDTO Create(SupportMessageDTO message);
    }
}
