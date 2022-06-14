using Common.WebApiCore.Controllers;
using QicFit.DTO;
using QicFit.Services.Infrastructure;
using QicFit.Services.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using QicFit.Services.Infrastructure.Services;
using System;
using System.Threading.Tasks;

namespace QicFit.WebApiCore.Controllers
{
    [Route("userworkout")]
    [ApiController]
    public class UserWorkoutController : BaseApiController
    {
        protected readonly IUserWorkoutService userWorkoutService;
        public UserWorkoutController(IUserWorkoutService userWorkoutService)
        {
            this.userWorkoutService = userWorkoutService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Workouts()
        {
            var result = await userWorkoutService.GetWorkoutGroups();
            return Ok(result);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Create(UserWorkoutDTO userWorkout)
        {
            var workout = await userWorkoutService.Create(userWorkout);
            return Ok(workout);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await userWorkoutService.Remove(id);
            return Ok(id);
        }

    }
}