using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using Pandora.NetStandard.Business.Validators;
using Pandora.NetStandard.Core.Filters;
using System;

namespace Pandora.NetStandard.Api
{
    public class Configuration
    {
        public static IServiceCollection ConfigureApiServices(IServiceCollection services)
        {
            return services
                .AddApiVersioning(o =>
                {
                    o.ReportApiVersions = true;
                    o.AssumeDefaultVersionWhenUnspecified = true;
                    o.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
                })
                .AddMvcCore(config => config.Filters.Add(typeof(ValidModelStateFilter)))//Global filter goes here
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateStudentValidator>())
                .AddApiExplorer()
                .AddJsonFormatters()
                .AddJsonOptions(jop =>
                {
                    jop.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    jop.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                    jop.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
                })
                .Services;
        }

        public static IApplicationBuilder ConfigureApi(
            IApplicationBuilder app,
            Func<IApplicationBuilder, IApplicationBuilder> configureHost) =>
            configureHost(app)
                .UseMvc(routes => routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}"));

    }
}
