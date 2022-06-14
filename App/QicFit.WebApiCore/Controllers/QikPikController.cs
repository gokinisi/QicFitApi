using Common.WebApiCore.Controllers;
using QicFit.DTO;
using QicFit.Services.Infrastructure;
using QicFit.Services.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace QicFit.WebApiCore.Controllers
{
    [Route("qikpik")]
    [ApiController]
    public class QikPikController : BaseApiController
    {
        protected readonly IWorkoutService workoutService;
        protected readonly IConfiguration configuration;
        public QikPikController(IWorkoutService workoutService, IConfiguration configuration)
        {
            this.workoutService = workoutService;
            this.configuration = configuration;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Workouts()
        {
            var nubmerOfDays = Convert.ToInt32(configuration.GetValue<string>
                               ("WorkoutConfiguration:QikPickNumberofDays"));

            var workout = await workoutService.GetWorkoutGroups(nubmerOfDays);
            return Ok(workout);
        }

    }
}