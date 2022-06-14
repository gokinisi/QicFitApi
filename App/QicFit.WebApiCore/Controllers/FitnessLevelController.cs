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
    [Route("fitnessLevel")]
    [ApiController]
    public class FitnessLevelController : BaseApiController
    {
        protected readonly IFitnessLevelService fitnessLevelService;
        public FitnessLevelController(IFitnessLevelService fitnessLevelService)
        {
            this.fitnessLevelService = fitnessLevelService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> FitnessLevel()
        {
            var fitnessLevel = await fitnessLevelService.GetAll();
            return Ok(fitnessLevel);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> Location(int id)
        {
            var fitnessLevel = await fitnessLevelService.GetById(id);
            return Ok(fitnessLevel);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update(int id, FitnessLevelDTO fitnessLevel)
        {
            if (id != fitnessLevel.Id)
            {
                return BadRequest();
            }

            var result = await fitnessLevelService.Update(fitnessLevel);
            return Ok(result);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Create(FitnessLevelDTO fitnessLevel)
        {
            var result = await fitnessLevelService.Create(fitnessLevel);
            return Ok(result);
        }
    }
}