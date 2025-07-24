using AutoMapper;
using NotificationService.Models;

namespace NotificationService.Services.MapperService
{
    public class ModelProfile : Profile
    {
        public ModelProfile()
        {
            CreateMap<RequestMailNotificationModel, MailNotificationModel>();
        }
    }
}
