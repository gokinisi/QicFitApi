using Common.WebApiCore.Controllers;
using QicFit.DTO;
using QicFit.Services.Infrastructure;
using QicFit.Services.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace QicFit.WebApiCore.Controllers
{
    [Route("workoutTypes")]
    [ApiController]
    public class WorkoutTypeController : BaseApiController
    {
        protected readonly IWorkoutTypeService workoutTypeTypeService;
        public WorkoutTypeController(IWorkoutTypeService workoutTypeTypeService)
        {
            this.workoutTypeTypeService = workoutTypeTypeService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> WorkoutTypes()
        {
            var workoutType = await workoutTypeTypeService.GetAll();
            return Ok(workoutType);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> WorkoutType(int id)
        {
            var workoutType = await workoutTypeTypeService.GetById(id);
            return Ok(workoutType);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update(int id, WorkoutTypeDTO workoutType)
        {
            if (id != workoutType.Id)
            {
                return BadRequest();
            }

            var result = await workoutTypeTypeService.Update(workoutType);
            return Ok(result);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Create(WorkoutTypeDTO workoutType)
        {
            var result = await workoutTypeTypeService.Create(workoutType);
            return Ok(result);
        }
    }
}