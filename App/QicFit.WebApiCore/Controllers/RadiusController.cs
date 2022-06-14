using System.Threading.Tasks;
using Common.WebApiCore.Controllers;
using QicFit.DTO;
using QicFit.Services.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace QicFit.WebApiCore.Controllers
{
    [Route("radius")]
    [ApiController]
    public class RadiusController : BaseApiController
    {
        protected readonly IRadiusService radiusService;
        public RadiusController(IRadiusService radiusService)
        {
            this.radiusService = radiusService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Radius()
        {
            var radius = await radiusService.GetAll();
            return Ok(radius);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> Location(int id)
        {
            var radius = await radiusService.GetById(id);
            return Ok(radius);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update(int id, RadiusDTO radius)
        {
            if (id != radius.Id)
            {
                return BadRequest();
            }

            var result = await radiusService.Update(radius);
            return Ok(result);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Create(RadiusDTO radius)
        {
            var result = await radiusService.Create(radius);
            return Ok(result);
        }
    }
}