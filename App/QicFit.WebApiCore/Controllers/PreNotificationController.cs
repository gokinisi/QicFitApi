using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Common.WebApiCore.Controllers;
using QicFit.DTO;
using QicFit.Services.Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QicFit.DTO;

namespace QicFit.WebApiCore.Controllers
{
    [Route("preNotification")]
    [ApiController]
    public class PreNotificationController : ControllerBase
    {
        protected readonly IPreNotificationService preNotificationService;
        public PreNotificationController(IPreNotificationService preNotificationService)
        {
            this.preNotificationService = preNotificationService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> prenotification()
        {
            var prenotification = await preNotificationService.GetAll();
            return Ok(prenotification);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> prenotification(int id)
        {
            var prenotification = await preNotificationService.GetById(id);
            return Ok(prenotification);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update(int id, PreNotificationDTO prenotification)
        {
            if (id != prenotification.Id)
            {
                return BadRequest();
            }

            var result = await preNotificationService.Update(prenotification);
            return Ok(result);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Create(PreNotificationDTO prenotification)
        {
            var result = await preNotificationService.Create(prenotification);
            return Ok(result);
        }

        [HttpPost]
        [Route("unsubscribe")]
        public async Task<IActionResult> Unsubscribe([FromBody] SubscriptionDTO subscription)
        {
            try
            {
                var result = await preNotificationService.UnsubscribeNotification(subscription);
                return Ok(result);
            }
            catch (Exception)
            {
                return NotFound();
            }
           
        }

    }
}