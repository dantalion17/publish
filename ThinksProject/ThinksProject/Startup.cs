using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using ThinksProject.Data;
using ThinksProject.DataClasses;
using ThinksProject.Models;
using ThinksProject.Services;

namespace ThinksProject
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
	        services.AddLocalization(options => options.ResourcesPath = "Resources");
	        services.AddMvc()
		        .AddDataAnnotationsLocalization()
		        .AddViewLocalization();
			services.Configure<RequestLocalizationOptions>(
		        options =>
		        {
					var supportedCultures = new[]
					{
						new CultureInfo("en"),
						new CultureInfo("de"),
						new CultureInfo("ru")
					};

			        options.DefaultRequestCulture = new RequestCulture("ru");
			        options.SupportedCultures = supportedCultures;
			        options.SupportedUICultures = supportedCultures;
				});

	        services.AddLocalization();
			services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("PostgresConnection")));

	        services.AddDbContext<DataDbContext>(options =>
		        options.UseNpgsql(Configuration.GetConnectionString("PostgresConnection"),
			        x=>x.MigrationsAssembly("ThinksProject")));

			services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();
	        services.AddScoped<DbWorking>();
            services.AddScoped<DbWorkingForPostOperations>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
	        var locOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
	        app.UseRequestLocalization(locOptions.Value);
			if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
			}

	       

			app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Presentation}/{action=AllStatistics}/{id?}");
            });
        }
    }
}
