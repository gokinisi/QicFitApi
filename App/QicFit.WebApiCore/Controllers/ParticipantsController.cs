using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.WebApiCore.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QicFit.Services.Infrastructure.Services;

namespace QicFit.WebApiCore.Controllers
{
    [Route("qikpik")]
    [ApiController]
    public class ParticipantsController : BaseApiController
    {
        protected readonly IParticipantService participantsService;

        public ParticipantsController(IParticipantService participantsService)
        {
            this.participantsService = participantsService;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetByWorkoutId(int id)
        {
            var particpants = await participantsService.GetByWorkoutId(id);
            return Ok(particpants);
        }
    }
}
