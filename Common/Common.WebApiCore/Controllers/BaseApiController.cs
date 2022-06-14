
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Common.WebApiCore.Controllers
{
    [ApiController]
    [Authorize]
    public abstract class BaseApiController : ControllerBase
    {
    }
}
