using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Autofac;
using Autofac.Integration.WebApi;
using EcommerceTrackerAPI.Services;
using Hangfire;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;
using System.Web.Http;
using AutoMapper;
using EcommerceTrackerAPI.Models;
using Google.Apis.Auth.OAuth2.Responses;

[assembly: OwinStartup(typeof(EcommerceTrackerAPI.Startup))]

namespace EcommerceTrackerAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);

            Mapper.Initialize(cfg => {
                cfg.CreateMap<TokenResponse, GmailAccessTokens>();
            });

            var builder = new ContainerBuilder();
            // Register application services
            builder.RegisterType<GmailOAuthService>().As<IGmailOAuthService>();
            // builder.RegisterType<ImapService>().As<IImapService>();
            builder.RegisterType<AccountsScanner>().As<IAccountsScanner>();
            builder.Register(c => new GmailAccountScanner(c.Resolve<IGmailOAuthService>()));
            // Get your HttpConfiguration.
            var config = System.Web.Http.GlobalConfiguration.Configuration;
            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            // OPTIONAL: Register the Autofac filter provider.
            builder.RegisterWebApiFilterProvider(config);
            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            Hangfire.GlobalConfiguration.Configuration.UseSqlServerStorage("DefaultConnection");
            app.UseHangfireDashboard();
            app.UseHangfireServer();

            RecurringJob.AddOrUpdate<AccountsScanner>(x => x.Run(), Cron.Hourly);

            ConfigureAuth(app);
        }
    }
}
