namespace NotificationService.Models
{
    public class MailNotificationModel
    {
        public required Guid Id { get; set; }

        public required string PublisherAdress { get; set; }

        public required string RecieverAdress { get; set; }

        public string? Topic { get; set; } 

        public string? Content { get; set; }
    }
}
