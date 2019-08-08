using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pandora.NetCore.ApiHost;
using Pandora.NetStandard.Business.Services;
using Pandora.NetStandard.Business.Services.Contracts;
using Pandora.NetStandard.Core.Config;
using Pandora.NetStandard.Core.Identity;
using Pandora.NetStandard.Core.Interfaces;
using Pandora.NetStandard.Core.Interfaces.Identity;
using Pandora.NetStandard.Core.Mapper;
using Pandora.NetStandard.Data.Dals;
using Serilog;
using Serilog.Exceptions;
using Serilog.Sinks.Elasticsearch;
using Swashbuckle.AspNetCore.Swagger;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDIServices(this IServiceCollection services)
        {
            services
            .AddScoped<Logging.ILogger, Logger<SchoolMngrLOG>>()
            .AddSingleton<IMapperCore, GenericMapper>()
            .AddSingleton<RepositoryFactories<SchoolDbContext>>()
            .AddScoped<IRepositoryProvider<SchoolDbContext>, RepositoryProvider<SchoolDbContext>>()
            .AddScoped<IIdentityAppUow, ApplicationUow<SchoolDbContext>>()
            .AddScoped<IRoleRepository, RoleManagerFacade>()
            .AddScoped<IUserRepository, UserManagerFacade>()
            .AddScoped<IAccountSvc, AccountSvc>()
            .AddScoped<IGradeSvc, GradeSvc>()
            .AddScoped<IClassSvc, ClassSvc>()
            .AddScoped<IStudentSvc, StudentSvc>()
            .AddScoped<IStudentStateSvc, StudentStateSvc>()
            .AddScoped<ISubjectSvc, SubjectSvc>();

            return services;
        }

        public static IServiceCollection AddOpenApi(this IServiceCollection services)// TODO add Authorization JWT
        {
            services.AddSwaggerGen(setup =>
            {
                setup.DescribeAllParametersInCamelCase();
                setup.DescribeStringEnumsInCamelCase();
                setup.SwaggerDoc("v1", new Info
                {
                    Title = "SchoolMngr API",
                    Version = ApiVersion.Default.ToString()
                });
            });

            return services;
        }

        public static IServiceCollection AddLogger(this IServiceCollection services, AppSettings settings)
        {
            //configure logger provider 
            var elasticUrl = settings.ElasticServerUrl;

            var loggerConfig = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .Enrich.WithExceptionDetails();

            if (settings.IsProdMode)
            {
                loggerConfig.WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(elasticUrl))
                {
                    AutoRegisterTemplate = true,
                });
            }
            else
            {
                loggerConfig.WriteTo.Console();
            }

            Log.Logger = loggerConfig.CreateLogger();

            return services;
        }
    }
}
