using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Test.Business.Managers;
using Test.Core.Repositories;
using Test.Core.Services;
using Test.Core.UnitOfWork;
using Test.Data;
using Test.Data.Repositories;
using Test.Data.UnitOfWork;

namespace Test.MVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddScoped(typeof(IEntityRepository<>), typeof(EntityRepository<>));
            services.AddScoped(typeof(IEntityService<>), typeof(EntityManager<>));

            services.AddScoped<ITestService, TestManager>();
            services.AddScoped<ISubTestService, SubTestManager>();

            services.AddControllers();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddDbContext<TestContext>();
            services.AddScoped<DbContext>(sp => sp.GetService<TestContext>());

            services.AddDataProtection();


            //services.AddMvc();
            services.AddMvc(option => option.EnableEndpointRouting = false);
            //services.AddMvc(option => option.EnableEndpointRouting = true)
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                        name: "index.html",
                        template: "{controller}/{action=Index}/{id?}"
                    );
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
