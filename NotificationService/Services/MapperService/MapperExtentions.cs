using AutoMapper;

namespace NotificationService.Services.MapperService
{
    public static class MapperExtentions
    {
        public static IServiceCollection AddMapper(this IServiceCollection services)
        {
            if (services is null)
            {
                throw new ArgumentNullException(nameof(services));
            }
            var mappingConfig = new MapperConfiguration(
                    mc =>
                    {
                        mc.AddProfile<ModelProfile>();
                    }
            );

            var mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            return services;
        }
    }
}
