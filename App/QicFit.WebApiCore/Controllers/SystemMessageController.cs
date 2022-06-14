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
    [Route("systemMessage")]
    [ApiController]
    public class SystemMessageController : BaseApiController
    {
        protected readonly ISystemMessageService systemMessageService;
        public SystemMessageController(ISystemMessageService systemMessageService)
        {
            this.systemMessageService = systemMessageService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> systemMessage()
        {
            var systemMessage = await systemMessageService.GetAll();
            return Ok(systemMessage);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> systemMessage(int id)
        {
            var systemMessage = await systemMessageService.GetById(id);
            return Ok(systemMessage);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update(int id, SystemMessageDTO systemMessage)
        {
            if (id != systemMessage.Id)
            {
                return BadRequest();
            }

            var result = await systemMessageService.Update(systemMessage);
            return Ok(result);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Create(SystemMessageDTO systemMessage)
        {
            var result = await systemMessageService.Create(systemMessage);
            return Ok(result);
        }

    }
}