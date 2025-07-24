using System.ComponentModel.DataAnnotations;

namespace NotificationService.Models
{
    public class RequestSmsNotificationModel
    {
        [Required(ErrorMessage = "Publisher's phone number is required", AllowEmptyStrings = false)]
        [RegularExpression("^\\+?[1-9][0-9]{7,14}$", ErrorMessage = "Publisher's phone number is not valid")]
        public required string PublisherAdress { get; set; }

        [Required(ErrorMessage = "Reciever's phone number is required", AllowEmptyStrings = false)]

        [RegularExpression("^\\+?[1-9][0-9]{7,14}$", ErrorMessage = "Reciever's phone number is not valid")]
        public required string RecieverAdress { get; set; }

        [Required(ErrorMessage ="content is required", AllowEmptyStrings = true)]
        [StringLength(100)]
        public string? Text { get; set; }
    }
}
