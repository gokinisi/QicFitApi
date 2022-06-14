using Common.WebApiCore.Controllers;
using QicFit.Services.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using QicFit.DTO;

namespace QicFit.WebApiCore.Controllers
{
    [Route("userSupport")]
    [ApiController]
    public class UserSupportController : BaseApiController
    {
        protected readonly IUserSupportService userSupportService;
        public UserSupportController(IUserSupportService userSupportService)
        {
            this.userSupportService = userSupportService;
        }

        [HttpPost]
        [Route("")]
        public IActionResult Create(SupportMessageDTO messsage)
        {
            var result = userSupportService.CreateUserMessage(messsage);
            return Ok(result);
        }
    }
}