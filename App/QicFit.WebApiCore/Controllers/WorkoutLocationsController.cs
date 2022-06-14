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
    [Route("locations")]
    [ApiController]
    public class WorkoutLocationsController : BaseApiController
    {
        protected readonly IWorkoutLocationService locationService;
        public WorkoutLocationsController(IWorkoutLocationService locationService)
        {
            this.locationService = locationService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> WorkoutLocations()
        {
            var location = await locationService.GetAll();
            return Ok(location);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> WorkoutLocation(int id)
        {
            var location = await locationService.GetById(id);
            return Ok(location);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update(int id, WorkoutLocationDTO location)
        {
            if (id != location.Id)
            {
                return BadRequest();
            }

            var result = await locationService.Update(location);
            return Ok(result);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Create(WorkoutLocationDTO location)
        {
            var result = await locationService.Create(location);
            return Ok(result);
        }
    }
}