using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExploreCaliforniaMyProject.Models;
using ExploreCaliforniaMyProject;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ExploreCaliforniaMyProject
{
    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<FormattingService>();

            services.AddTransient<FeatureToggles>(x => new FeatureToggles
            {
                DeveloperExceptions = configuration.GetValue<bool>("FeatureToggles:DeveloperExceptions")
            });

            services.AddDbContext<BlogDataContext>(options =>
            {
                var connectionString = configuration.GetConnectionString("BlogDataContext");
                options.UseSqlServer(connectionString);
            });

            services.AddDbContext<IdentityDataContext>(options =>
            {
                var connectionString = configuration.GetConnectionString("IdentityDataContext");
                options.UseSqlServer(connectionString);

            });

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<IdentityDataContext>();

            services.AddMvc(options => options.EnableEndpointRouting = false);
        }

        
        public void Configure(
            IApplicationBuilder app,
            IWebHostEnvironment env,
            FeatureToggles features)
        {
            app.UseExceptionHandler("/error.html");

            if (features.DeveloperExceptions)
            {
                app.UseDeveloperExceptionPage();
            }

            app.Use(async (context, next) =>
            {
                if (context.Request.Path.Value.Contains("invalid"))
                    throw new Exception("ERROR!");

                await next();
            });

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute("Default",
                    "{controller=Home}/{action=Index}/{id?}"
                );
            });

            app.UseFileServer();
        }
    }
}
