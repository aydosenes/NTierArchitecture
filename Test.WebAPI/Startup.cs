using Autofac.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
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

namespace Test.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
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

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

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
