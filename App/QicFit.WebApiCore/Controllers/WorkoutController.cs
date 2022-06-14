using Common.WebApiCore.Controllers;
using QicFit.DTO;
using QicFit.Services.Infrastructure;
using QicFit.Services.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace QicFit.WebApiCore.Controllers
{
    [Route("workout")]
    [ApiController]
    public class WorkoutController : BaseApiController
    {
        protected readonly IWorkoutService workoutService;
        public WorkoutController(IWorkoutService workoutService)
        {
            this.workoutService = workoutService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Workouts()
        {
            var workout = await workoutService.GetAllWorkouts();
            return Ok(workout);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> Workout(int id)
        {
            var workout = await workoutService.GetById(id);
            return Ok(workout);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update(int id, WorkoutDTO workout)
        {
            if (id != workout.Id)
            {
                return BadRequest();
            }

            var result = await workoutService.Update(workout);
            return Ok(result);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Create(WorkoutDTO workout)
        {
            var result = await workoutService.Create(workout);
            return Ok(result);
        }

        [HttpGet]
        [Route("search")]
        public async Task<IActionResult> Search([FromQuery] WorkoutDTO workout)
        {
            var results = await workoutService.Search(workout);

            return Ok(results);
        }
    }
}