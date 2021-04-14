using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Application.Interfaces;
using ToDoList.Application.Services;
using ToDoList.Core.Configuration;
using ToDoList.Core.Repositories;
using ToDoList.Infrastructure.Data;
using ToDoList.Infrastructure.Repositories;

namespace ToDoList.Web
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
            ConfigureAspnetRunServices(services);
            services.AddControllersWithViews();
           
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
        }
        public void ConfigureDatabases(IServiceCollection services)
        {
            
                services.AddDbContext<BaseProjectContext>(c =>
                  c.UseSqlServer(Configuration.GetConnectionString("BaseProjectConnection"), b => b.MigrationsAssembly("ToDoList.Web").UseNetTopologySuite()));
            
        }
        private void ConfigureAspnetRunServices(IServiceCollection services)
        {
            #region Add Core Layer
            services.Configure<BaseProjectSettings>(Configuration);
            #endregion
            ConfigureDatabases(services);
            #region Add Infrastructure Layer
            services.AddScoped(typeof(INoteItemRepository), typeof(NoteItemRepository));
            services.AddScoped(typeof(INoteRepository), typeof(NoteRepository));
            services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
            #endregion
            #region Add Application Layer
            services.AddScoped(typeof(INoteService), typeof(NoteService));
            services.AddScoped(typeof(INoteItemService), typeof(NoteItemService));
            services.AddScoped(typeof(IUserService), typeof(UserService));
            #endregion
            services.AddAutoMapper(typeof(Startup)); // Add AutoMapper
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
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
           
            Guid param = Guid.NewGuid();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                // ASP.NET Core Kestrel сервер внутренне передает файлы SPA через прокси-сервер на сервер разработки Angular.
                if (env.IsDevelopment())
                {
                    spa.Options.StartupTimeout =   TimeSpan.FromSeconds(120);
                    spa.UseProxyToSpaDevelopmentServer("http://localhost:4200");
                    //spa.UseAngularCliServer(npmScript: "start");
                }
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
