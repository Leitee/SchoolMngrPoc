using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Pandora.NetStandard.Api;
using Pandora.NetStandard.Core.Config;
using Pandora.NetStandard.Core.Identity;
using Pandora.NetStandard.Data.Dals;
using Serilog;
using System;
using System.Text;

namespace Pandora.NetCore.ApiHost
{
    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            AppSettings = AppSettings.GetSettings(configuration);
        }

        /// <summary>
        /// App Configuration form appsetting.json
        /// </summary>
        public AppSettings AppSettings { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddCors(options =>
            {
                options.AddPolicy("AllowMyOrigin",
                builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().AllowCredentials());//TODO: set origin from config
            });

            // Register authentication schema
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddCookie()
                .AddJwtBearer(options =>
                {
                    options.SaveToken = true;
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateIssuerSigningKey = true,
                        ValidateLifetime = true,
                        ValidIssuer = AppSettings.JwtValidIssuer,
                        ValidAudience = AppSettings.JwtValidAudience,
                        ClockSkew = TimeSpan.Zero,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(AppSettings.JwtSecretKey))
                    };
                });

            // Add configuration for DbContext
            services.AddDbContext<SchoolDbContext>();
            //setting identity options 
            services.AddIdentity<ApplicationUser, ApplicationRole>()
            .AddUserManager<UserManagerFacade>()
            .AddRoleManager<RoleManagerFacade>()
            .AddSignInManager<AccountManagerFacade>()
            .AddEntityFrameworkStores<SchoolDbContext>();

            Configuration.ConfigureApiServices(services)
                .AddDIServices()// configure DI for application services
                .AddOpenApi()// Register the Swagger generator, defining 1 or more Swagger documents
                .AddLogger(AppSettings)
                .AddApiVersioning(o =>
                {
                    o.ReportApiVersions = true;
                    o.AssumeDefaultVersionWhenUnspecified = true;
                    o.DefaultApiVersion = new ApiVersion(1, 0);
                });
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        /// <param name="loggerFactory"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseIf(env.IsDevelopment(), appBuilder =>
                appBuilder
                    .UseDeveloperExceptionPage()
                    .UseDatabaseErrorPage()
                );

            app.UseIf(env.IsProduction(), appBuilder =>
                appBuilder
                   // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                   .UseHsts()
                   .UseExceptionHandler("/Home/Error")
                );

            //Enable serilog loggin
            loggerFactory.AddSerilog();

            Configuration.ConfigureApi(
                app,
                host => host
                    .UseHttpsRedirection()
                    .UseStaticFiles()
                    .UseCookiePolicy()
                    .UseAuthentication()

                    // global cors policy
                    .UseCors("AllowMyOrigin")
                    // Enable middleware to serve generated Swagger as a JSON endpoint.
                    .UseSwagger()
                    // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
                    .UseSwaggerUI(setup =>
                    {
                        setup.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
                        setup.DefaultModelExpandDepth(0);
                        setup.DefaultModelsExpandDepth(-1);
                    })
            );
        }
    }
}
