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
    [Route("userLocations")]
    [ApiController]
    public class UserLocationsController : BaseApiController
    {
        protected readonly IUserLocationService userLocationService;
        public UserLocationsController(IUserLocationService userLocationService)
        {
            this.userLocationService = userLocationService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Locations()
        {
            var location = await userLocationService.GetAll();
            return Ok(location);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> Location(int id)
        {
            var location = await userLocationService.GetById(id);
            return Ok(location);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update(int id, UserLocationDTO location)
        {
            if (id != location.Id)
            {
                return BadRequest();
            }

            var result = await userLocationService.Update(location);
            return Ok(result);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Create(UserLocationDTO location)
        {
            var result = await userLocationService.Create(location);
            return Ok(result);
        }
    }
}