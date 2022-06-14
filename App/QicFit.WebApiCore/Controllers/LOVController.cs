using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.WebApiCore;
using Common.WebApiCore.Controllers;
using QicFit.Services.Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace QicFit.WebApiCore.Controllers
{
    [Route("lov")]
    [ApiController]
    
    public class LOVController : ControllerBase
    {
        protected readonly ILovService lovService;
  
        public LOVController(ILovService lovService)
        {
            this.lovService = lovService;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Lov()
        {
            var lov = lovService.GetAll();
            return Ok(lov);
        }

        [HttpGet]
        [Route("getByUser")]
        public IActionResult GetByUser()
        {
            var currentUserId = User.GetUserId();
            var lov = lovService.GetWorkoutLocationsLov(currentUserId);
            return Ok(lov);
        }
    }
}