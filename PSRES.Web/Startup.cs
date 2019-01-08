using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PSRES.Web.Services;
using PSRESData;
using PSRESData.Entities;

namespace PSRES.Web
{
    public class Startup
    {
        private readonly IConfiguration configuration;
        private readonly IHostingEnvironment env;

        public Startup(IConfiguration configuration,
                       IHostingEnvironment env)
        {
            this.configuration = configuration;
            this.env = env;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentity<UserEntity, IdentityRole>(cfg =>
            {
                cfg.Password.RequireNonAlphanumeric = false;
                cfg.Password.RequireUppercase = false;
            }).AddEntityFrameworkStores<PSRESContext>();

            services.AddSingleton<IController, SystemControl>();
            services.AddMvc(opt=>
            {
                if (env.IsProduction())
                {
                    //opt.Filters.Add(new RequireHttpsAttribute());
                }
            });
            services.AddDbContext<PSRESContext>(cfg=>
            {
                cfg.UseSqlServer(configuration.GetConnectionString("PSRESConnectionString"));
            });

            services.AddTransient<DataBaseSeeder>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //app.UseDeveloperExceptionPage();
            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(cfg =>
            {
                cfg.MapRoute("Default",
                    "/{controller}/{action}/{id?}",
                    new { controller = "main", action = "Index" });
            });

            using (var scope = app.ApplicationServices.CreateScope())
            {
                var seeder = scope.ServiceProvider.GetService<DataBaseSeeder>();
                seeder.Seed().Wait();

            }

        }
    }
}
