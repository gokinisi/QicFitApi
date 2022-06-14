
using Common.DTO;
using Common.Entities;
using Common.Services.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Common.WebApiCore.Controllers
{
    [Route("users")]
    public class UsersController : BaseApiController
    {
        protected readonly IUserService userService;
        protected readonly JwtManager jwtManager;
        public UsersController(IUserService userService, JwtManager jwtManager)
        {
            this.userService = userService;
            this.jwtManager = jwtManager;
        }

        [HttpGet]
        [Route("")]
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> GetDataForGrid([FromQuery]UsersGridFilter filter)
        {
            filter = filter ?? new UsersGridFilter();
            var users = await userService.GetDataForGrid(filter);
            return Ok(users);
        }

        [HttpGet]
        [Route("{id:int}")]
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> Get(int id)
        {
            var user = await userService.GetById(id);
            return Ok(user);
        }

        [HttpGet]
        [Route("current")]
        public async Task<IActionResult> GetCurrent()
        {
            var currentUserId = User.GetUserId();
            if (currentUserId > 0)
            {
                var user = await userService.GetById(currentUserId);
                return Ok(user);
            }

            return Unauthorized();
        }

        [HttpPost]
        [Route("")]
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> Create(UserDTO userDto)
        {
            if (userDto.Id != 0)
            {
                return BadRequest();
            }

            var result = await userService.Edit(userDto);
            return Ok(result);
        }

        [HttpPut]
        [Route("{id:int}")]
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> Edit(int id, UserDTO userDto)
        {
            if (id != userDto.Id)
                return BadRequest();

            var result = await userService.Edit(userDto);
            return Ok(result);
        }

        [HttpPut]
        [Route("current")]
        public async Task<IActionResult> EditCurrent(UserDTO userDto)
        {
            var currentUserId = User.GetUserId();
            if (currentUserId != userDto.Id)
            {
                return BadRequest();
            }
            var result = await userService.Edit(userDto);
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await userService.Delete(id);
            return Ok(result);
        }

        [HttpGet]
        [Route("{userId:int}/photo")]
        [AllowAnonymous]
        public async Task<IActionResult> UserPhoto(int userId, string token)
        {
           var user = jwtManager.GetPrincipal(token);
           if (user == null || !user.Identity.IsAuthenticated)
           {
               return Unauthorized();
           }

            var photoContent = await userService.GetUserPhoto(userId);
            
            if (photoContent == null)
            {
                return NoContent();
            }

            return File(photoContent, contentType: "image/png");
        }


    }
}