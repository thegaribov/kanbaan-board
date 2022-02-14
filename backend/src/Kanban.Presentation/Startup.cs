using Kanban.DataAccess.Persistance.Contexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kanban.Presentation
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

            #region Database context

            services.AddDbContext<KanbanContext>(opt =>
            {
                string serverName = Environment.GetEnvironmentVariable("POSTGRE_SERVER_NAME");
                string serverPort = Environment.GetEnvironmentVariable("POSTGRE_SERVER_PORT");
                string databaseName = Environment.GetEnvironmentVariable("POSTGRE_DB_NAME");
                string userId = Environment.GetEnvironmentVariable("POSTGRE_USER_ID");
                string userPassword = Environment.GetEnvironmentVariable("POSTGRE_USER_PASSWORD");
                string maxOurPrepare = Environment.GetEnvironmentVariable("POSTGRE_MAX_AUTO_PREPARE");

                var dbConnectionString = @$"Server={serverName};Port={serverPort};Database={databaseName};User Id={userId};Password={userPassword};MaxAutoPrepare={maxOurPrepare}";
 


                opt.UseNpgsql(dbConnectionString, options => {
                    options.UseNetTopologySuite();
                    options.MigrationsAssembly("Ramzioglu.DataAccess.Persistance");
                }
                );
            }
            );

            #endregion
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
