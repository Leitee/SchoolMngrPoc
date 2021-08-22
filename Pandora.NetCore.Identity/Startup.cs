using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pandora.NetCore.Identity.Validators;
using Pandora.NetStdLibrary.Base.Config;
using Pandora.NetStdLibrary.Base.Filters;
using Pandora.NetStdLibrary.Base.Identity;
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
            services.AddCors();

            //services.AddCors();
            services
                .AddMvcCore(config => config.Filters.Add(typeof(ValidModelStateFilter)))
                .AddJsonFormatters()
                .AddApiExplorer()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<LoginValidator>())
                .ConfigureApiBehaviorOptions(options =>
                {
                    options.SuppressModelStateInvalidFilter = true;//to prevent request reaches controllers when model state invalid
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
                //.AddSignInManager<AccountManagerFacade>()
                //.AddUserManager<UserManagerFacade>()
                //.AddRoleManager<RoleManagerFacade>()
                .AddEntityFrameworkStores<IdentityDbContext>()
                .AddDefaultTokenProviders();

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
            services.AddDIServices();
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

            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();

            app.UseHttpsRedirection();

            app.UseMvc();
        }
    }
}
