using Microsoft.Extensions.Logging;
using Pandora.NetCore.Identity;
using Pandora.NetCore.Identity.DataAccess;
using Pandora.NetCore.Identity.Services;
using Pandora.NetCore.Identity.Services.Contracts;
using Pandora.NetStandard.Core.Interfaces;
using Pandora.NetStandard.Core.Mapper;
using Pandora.NetStandard.Core.Security;
using Swashbuckle.AspNetCore.Swagger;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDIServices(this IServiceCollection services)
        {
            services
            .AddScoped<ILogger, Logger<IdentityLOG>>()
            .AddSingleton<IMapperCore, GenericMapperCore>()
            .AddScoped<IApplicationUow, IdentityUow>()
            .AddScoped<IAuthSvc, AuthSvc>()
            .AddScoped<ISocialSvc, SocialSvc>()
            .AddTransient<IJwtTokenProvider, JwtTokenProvider>();

            return services;
        }

        public static IServiceCollection AddOpenApi(this IServiceCollection services)
        {
            services.AddSwaggerGen(setup =>
            {
                setup.DescribeAllParametersInCamelCase();
                setup.DescribeStringEnumsInCamelCase();
                setup.SwaggerDoc("v1", new Info
                {
                    Title = "SchoolMngr Identity",
                    Version = "v1"
                });
            });

            return services;
        }
    }
}
