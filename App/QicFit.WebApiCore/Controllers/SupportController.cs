using Common.WebApiCore.Controllers;
using QicFit.Services.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using QicFit.DTO;

namespace QicFit.WebApiCore.Controllers
{
    [Route("support")]
    [ApiController]
    public class SupportController : ControllerBase
    {
        protected readonly ISupportService supportService;
        public SupportController(ISupportService supportService)
        {
            this.supportService = supportService;
        }

        [HttpPost]
        [Route("")]
        public IActionResult Create(SupportMessageDTO messsage)
        {
            var result = supportService.Create(messsage);
            return Ok(result);
        }
    }
}