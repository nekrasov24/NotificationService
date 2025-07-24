using NotificationService.Models;

namespace NotificationService.Services.NotificationService
{
    public interface ISender
    {
        Task SendMessageByMailAsync(string publisherAdress, string recieverAdress,
               string topic, string content);
        Task SendMessageBySmsAsync(RequestSmsNotificationModel requestSmsNotificationModel);
    }
}
