using FluentValidation.AspNetCore;
using Kanban.Core.Entities;
using Kanban.DataAccess.Persistance.Contexts;
using Kanban.DataAccess.UnitOfWork.Abstracts;
using Kanban.DataAccess.UnitOfWork.Implementations;
using Kanban.Service.Business.Data.Abstracts;
using Kanban.Service.Business.Data.Implementations;
using Kanban.Service.Infrastructure.BackgroundTask.BackgroundTaskQueue.Abstracts;
using Kanban.Service.Infrastructure.BackgroundTask.BackgroundTaskQueue.Implementations;
using Kanban.Service.Notification.Email.Abstracts;
using Kanban.Service.Notification.Email.Implementations.SMTP;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
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
        public bool IsProduction { get; set; }
        public bool IsDevelopment { get; set; }
        public bool IsStaging { get; set; }
        public bool IsDevelopmentWithDocker { get; set; }
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration) :this()
        {
            Configuration = configuration;
        }

        public Startup()
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            IsProduction = Environments.Production == environment;
            IsDevelopment = Environments.Development == environment;
            IsStaging = Environments.Staging == environment;
            IsDevelopmentWithDocker = "DevelopmentWithDocker" == environment;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            #region Database context

            services.AddDbContext<KanbanContext>(opt =>
            {
                var dbConnectionString = string.Empty;

                if (IsDevelopment)
                {
                    //Environment.GetEnvironmentVariable("CONNECTION_STRING_NAME")
                    //Production

                    dbConnectionString = Configuration.GetConnectionString("Development");
                }
                else
                {
                    string serverName = Environment.GetEnvironmentVariable("POSTGRE_SERVER_NAME");
                    string serverPort = Environment.GetEnvironmentVariable("POSTGRE_SERVER_PORT");
                    string databaseName = Environment.GetEnvironmentVariable("POSTGRE_DB_NAME");
                    string userId = Environment.GetEnvironmentVariable("POSTGRE_USER_ID");
                    string userPassword = Environment.GetEnvironmentVariable("POSTGRE_USER_PASSWORD");
                    string maxOurPrepare = Environment.GetEnvironmentVariable("POSTGRE_MAX_AUTO_PREPARE");

                    dbConnectionString = @$"Server={serverName};Port={serverPort};Database={databaseName};User Id={userId};Password={userPassword};MaxAutoPrepare={maxOurPrepare}";
                }


                opt.UseNpgsql(dbConnectionString, options => {
                    options.UseNetTopologySuite();
                    options.MigrationsAssembly(typeof(KanbanContext).Assembly.FullName);
                }
                );
            }
            );

            #endregion

            #region Routing configurations

            //Lowercase Routing
            services.AddRouting(options => options.LowercaseUrls = true);

            #endregion

            #region Identity

            //Policy and Role changes will be effected immediately
            services.Configure<SecurityStampValidatorOptions>(options =>
            {
                options.ValidationInterval = TimeSpan.Zero;
            });

            //Identity
            services.AddIdentity<User, IdentityRole>(options =>
            {
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 0;
                options.User.RequireUniqueEmail = true;
                //options.SignIn.RequireConfirmedEmail = true;
            })
              .AddRoles<IdentityRole>()
              .AddEntityFrameworkStores<KanbanContext>()
              .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = "kanban.session";
                options.LoginPath = "/account/login";
                options.AccessDeniedPath = "/account/login";
                options.ExpireTimeSpan = TimeSpan.FromHours(72);
            });

            #endregion

            #region Services

            //unitOfWork
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            //Background tasks
            services.AddSingleton<IBackgroundTaskQueue, BackgroundTaskQueue>();
            services.AddHostedService<BackgroundQueueHostedService>();

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IOrganisationService, OrganisationService>();
            services.AddTransient<IUserOrganisationService, UserOrganisationService>();
            services.AddTransient<ITicketService, TicketService>();
            services.AddTransient<IUserTicketService, UserTicketService>();
            services.AddTransient<INotifyEventService, NotifyEventService>();

            //Email service
            services.AddTransient<IEmailService, Smtp>();

            #endregion


            #region FluentValidation

            services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Startup>());

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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
