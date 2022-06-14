using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.WebApiCore.Controllers;
using QicFit.DTO;
using QicFit.Services.Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace QicFit.WebApiCore.Controllers
{
    [Route("requirement")]
    [ApiController]
    public class WorkoutLocationRequirementController : BaseApiController
    {
        protected readonly IWorkoutLocationRequirementService locationRequirementService;
        public WorkoutLocationRequirementController(IWorkoutLocationRequirementService locationRequirementService)
        {
            this.locationRequirementService = locationRequirementService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Locations()
        {
            var requirement = await locationRequirementService.GetAll();
            return Ok(requirement);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> Location(int id)
        {
            var requirement = await locationRequirementService.GetById(id);
            return Ok(requirement);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update(int id, WorkoutLocationRequirementDTO requirement)
        {
            if (id != requirement.Id)
            {
                return BadRequest();
            }

            var result = await locationRequirementService.Update(requirement);
            return Ok(result);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Create(WorkoutLocationRequirementDTO requirement)
        {
            var result = await locationRequirementService.Create(requirement);
            return Ok(result);
        }
    }
}