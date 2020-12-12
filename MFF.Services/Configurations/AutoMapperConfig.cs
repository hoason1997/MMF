using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using MFF.Infrastructure.Mapping;
namespace MFF.Infrastructure.Configurations
{
    public static class AutoMapperConfig1
    {
        public static void AddAutoMapperConfig1(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile((typeof(IMappingProfile)));
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
