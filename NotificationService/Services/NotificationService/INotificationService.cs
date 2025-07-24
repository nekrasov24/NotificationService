using NotificationService.Models;

namespace NotificationService.Services.NotificationService
{
    public interface INotificationService
    {
        Task SendNotificationAsync(RequestMailNotificationModel requestMailNotificationModel);
        string GetInfo();
        Task SendNotificationBySmsAsync(RequestSmsNotificationModel requestSmsNotificationModel);
    }
}
