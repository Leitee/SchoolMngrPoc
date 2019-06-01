﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Pandora.NetCore.Identity.DataAccess;
using Pandora.NetCore.Identity.Services;
using Pandora.NetCore.Identity.Services.Contracts;
using Pandora.NetStandard.Core.Config;
using Pandora.NetStandard.Core.Identity;
using Pandora.NetStandard.Core.Interfaces;
using Pandora.NetStandard.Core.Mapper;
using Pandora.NetStandard.Core.Base;
using System;
using System.Threading.Tasks;

namespace Pandora.NetCore.Identity
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            AppSettings = AppSettings.GetSettings(configuration);
        }

        public IConfiguration Configuration { get; }
        public AppSettings AppSettings { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowMyOrigin",
                builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().AllowCredentials());//TODO: set origin from config
            });

            //services.AddCors();
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .ConfigureApiBehaviorOptions(options =>
                {
                    options.SuppressModelStateInvalidFilter = true;//allow reach controller when model state invalid request
                });

            services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 0;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;
                options.Tokens.AuthenticatorTokenProvider = TokenOptions.DefaultAuthenticatorProvider;
                options.SignIn.RequireConfirmedEmail = true;
            })
                .AddSignInManager<AccountManagerFacade>()
                .AddUserManager<UserManagerFacade>()
                .AddRoleManager<RoleManagerFacade>()
                .AddEntityFrameworkStores<IdentityDbContext>()
                .AddDefaultTokenProviders();
                //.AddDefaultUI(UIFramework.Bootstrap4)

            services.AddDbContext<IdentityDbContext>(ctx => ctx.UseSqlServer(AppSettings.ConnectionString));

            services.AddAuthentication(options =>
            {
                options.DefaultSignOutScheme = IdentityConstants.ApplicationScheme;
            })
                .AddFacebook(options =>
                {
                    options.AppId = AppSettings.SocialFacebookAppId;
                    options.AppSecret = AppSettings.SocialFacebookAppSecret;
                    //options.CallbackPath = new PathString("/google-callback");
                })
                .AddGoogle("Google", options =>
                {
                    options.ClientId = AppSettings.SocialGoogleClientId;
                    options.ClientSecret = AppSettings.SocialGoogleAppSecret;
                    options.CallbackPath = new PathString("/google-callback");
                    options.Events = new OAuthEvents
                    {
                        OnRemoteFailure = (RemoteFailureContext context) =>
                        {
                            context.Response.Redirect("/home/denied");
                            context.HandleResponse();
                            return Task.CompletedTask;
                        }
                    };
                });

            //Dependency Injection Settings
            services.AddScoped<ILogger, Logger<ApiBaseController>>();
            services.AddSingleton<IMapperCore, GenericMapperCore>();
            services.AddScoped<IApplicationUow, IdentityUow>();
            services.AddScoped<IAuthSvc, AuthSvc>();
            services.AddScoped<ISocialSvc, SocialSvc>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors("AllowMyOrigin");

            app.UseAuthentication();

            app.UseHttpsRedirection();

            app.UseMvc();
        }
    }
}
