using AutoMapper;
using NotificationService.Models;
using Vonage;

namespace NotificationService.Services.NotificationService
{
    public class NotificationService : INotificationService
    {
        private readonly ISender _sender;
        private readonly IMapper _mapper;
        private readonly ILogger<NotificationService> _logger;



        public NotificationService(ISender sender, IMapper mapper, ILogger<NotificationService> logger)
        {
            _sender = sender;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task SendNotificationAsync(RequestMailNotificationModel requestMailNotificationModel)
        {
            try
            {
                await _sender.SendMessageByMailAsync(requestMailNotificationModel.PublisherAdress, requestMailNotificationModel.RecieverAdress,
               requestMailNotificationModel.Topic, requestMailNotificationModel.Content);
            }
            catch(Exception ex)
            {
                throw;
            }

            
        }

        public string GetInfo()
        {
            _logger.LogInformation("done");
            return "done";
        }

        public async Task SendNotificationBySmsAsync(RequestSmsNotificationModel requestSmsNotificationModel)
        {
            try
            {
                await _sender.SendMessageBySmsAsync(requestSmsNotificationModel);
            }
            catch(Exception ex)
            {
                throw;
            }

        }
    }
}
