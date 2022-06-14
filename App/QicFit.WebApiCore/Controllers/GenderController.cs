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
    [Route("gender")]
    [ApiController]
    public class GenderController : BaseApiController
    {
        protected readonly IGenderService genderService;
        public GenderController(IGenderService genderService)
        {
            this.genderService = genderService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Gender()
        {
            var gender = await genderService.GetAll();
            return Ok(gender);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> Location(int id)
        {
            var gender = await genderService.GetById(id);
            return Ok(gender);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update(int id, GenderDTO gender)
        {
            if (id != gender.Id)
            {
                return BadRequest();
            }

            var result = await genderService.Update(gender);
            return Ok(result);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Create(GenderDTO gender)
        {
            var result = await genderService.Create(gender);
            return Ok(result);
        }
    }
}