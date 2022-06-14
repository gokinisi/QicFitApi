
using System.Threading.Tasks;
using Common.WebApiCore.Controllers;
using QicFit.DTO;
using QicFit.Services.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace QicFit.WebApiCore.Controllers
{
    [Route("ageGroup")]
    [ApiController]
    public class AgeGroupController : BaseApiController
    {
        protected readonly IAgeGroupService ageGroupService;
        public AgeGroupController(IAgeGroupService ageGroupService)
        {
            this.ageGroupService = ageGroupService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> AgeGroups()
        {
            var ageGroup = await ageGroupService.GetAll();
            return Ok(ageGroup);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> AgeGroup(int id)
        {
            var ageGroup = await ageGroupService.GetById(id);
            return Ok(ageGroup);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update(int id, AgeGroupDTO ageGroup)
        {
            if (id != ageGroup.Id)
            {
                return BadRequest();
            }

            var result = await ageGroupService.Update(ageGroup);
            return Ok(result);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Create(AgeGroupDTO ageGroup)
        {
            var result = await ageGroupService.Create(ageGroup);
            return Ok(result);
        }
    }
}