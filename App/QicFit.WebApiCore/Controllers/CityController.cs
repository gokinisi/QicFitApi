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
    [Route("city")]
    [ApiController]
    public class CityController : ControllerBase
    {
        protected readonly ICityService cityService;
        public CityController(ICityService cityService)
        {
            this.cityService = cityService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> City()
        {
            var city = await cityService.GetAll();
            return Ok(city);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> City(int id)
        {
            var city = await cityService.GetById(id);
            return Ok(city);
        }

        [HttpGet]
        [Route("search/{predicate}")]
        public async Task<IActionResult> Search(string predicate)
        {
            var cities = await cityService.Search(predicate);
            return Ok(cities);
        }

    }
}