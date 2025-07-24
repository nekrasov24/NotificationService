using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotificationService.Models;
using NotificationService.Services.NotificationService;

namespace NotificationService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;
        private readonly ISender _sender;

        public NotificationController(INotificationService notificationService, ISender sender)
        {
            _notificationService = notificationService;
            _sender = sender;
        }

        [HttpPost("sendmail")]
        public async  Task<IActionResult> SendNotificationAsync([FromBody] RequestMailNotificationModel requestMailNotificationModel)
        {
            await _notificationService.SendNotificationAsync(requestMailNotificationModel);
            return Ok();   
        }

        [HttpPost("getinfo")]
        public IActionResult GetInfo()
        {
            _notificationService.GetInfo();
            return Ok();
        }

        [HttpPost("sendsmstophone")]
        public async Task<IActionResult> SendNotificationBySmsAsync([FromBody] RequestSmsNotificationModel requestSmsNotificationModel)
        {
            await _notificationService.SendNotificationBySmsAsync(requestSmsNotificationModel);
            return Ok();
        }

        [HttpGet("sendsms")]
        public async Task<IActionResult> SendSmsAsync()
        {
            return Ok();
        }


    }
}
