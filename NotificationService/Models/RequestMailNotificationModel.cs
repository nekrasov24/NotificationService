using System.ComponentModel.DataAnnotations;

namespace NotificationService.Models
{
    public class RequestMailNotificationModel
    {
        [Required(ErrorMessage = "Publisher's adress is required", AllowEmptyStrings = false)]
        public required string PublisherAdress { get; set; }

        [Required(ErrorMessage = "Publisher's adress is required", AllowEmptyStrings = false)]
        public required string RecieverAdress { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(30)]
        public string? Topic { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(500)]
        public string? Content { get; set; }
    }
}
