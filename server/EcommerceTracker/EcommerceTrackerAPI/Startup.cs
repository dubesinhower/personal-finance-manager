using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
                cfg.CreateMap<GmailAccessTokens, TokenResponse>();
            });

            ConfigureAuth(app);

            Hangfire.GlobalConfiguration.Configuration.UseSqlServerStorage("DefaultConnection");
            Hangfire.GlobalConfiguration.Configuration.UseNinjectActivator(new Ninject.Web.Common.Bootstrapper().Kernel);
            app.UseHangfireDashboard();
            app.UseHangfireServer();

            RecurringJob.AddOrUpdate<AccountsScanner>(x => x.Run(), Cron.Hourly);
        }
    }
}
