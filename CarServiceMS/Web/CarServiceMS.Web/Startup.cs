using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CarServiceMS.Data.Models;
using CarServiceMS.Data;
using CarServiceMS.Services;
using System.Linq;
using CarServiceMS.Services.Interfaces.AdminInterfaces;
using CarServiceMS.Services.Interfaces.CarInterfaces;
using System.Reflection;
using CarServiceMS.Service.AutoMapper;
using AutoMapper;
using CarServiceMS.Services.Interfaces.UserInterfaces;
using System;

namespace CarServiceMS
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
            services.Configure<CookiePolicyOptions>(options =>
            {

                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));


            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
            });

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddDefaultTokenProviders()
                .AddDefaultUI(UIFramework.Bootstrap4)
                .AddEntityFrameworkStores<ApplicationDbContext>();


            // Register the services
            services.AddScoped<ICarServices, CarServices>();
            services.AddScoped<IAdminServices, AdminServices>();
            services.AddScoped<IUserServices, UserServices>();
            services.AddScoped<IRepairServices, RepairServices>();
            services.AddScoped<IMaintenanceServices, MaintenanceServices>();


            services.AddMvcCore().AddDataAnnotations();

            services.AddAutoMapper(new Assembly[]
            {
              typeof(MappingProfile).GetTypeInfo().Assembly
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {


            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>())
                {
                    context.Database.EnsureCreated();

                    if (!context.Roles.Any())
                    {
                        context.Roles.Add(new IdentityRole
                        {
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        });

                        context.Roles.Add(new IdentityRole
                        {
                            Name = "User",
                            NormalizedName = "USER"

                        });

                        context.Roles.Add(new IdentityRole
                        {
                            Name = "Banned",
                            NormalizedName = "BANNED"

                        });

                        context.SaveChanges();
                    }
                }
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                name: "default",
                template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "areas",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
