using CvApi.Data;
using CvApi.Jwt;
using CvApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CvApi
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



            services.AddDbContext<CvDbContext>(options =>
            {
                options.UseSqlServer(this.Configuration.GetConnectionString("DefaultConnection"));
                   
            });
           var jwtSettingsSection = this.Configuration.GetSection("JwtSettings");
           services.Configure<JwtSettings>(jwtSettingsSection);
         
           var jwtSettings = jwtSettingsSection.Get<JwtSettings>();
           var key = Encoding.ASCII.GetBytes(jwtSettings.Secret);
         
           var signinKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret));
         
           services.Configure<TolkenProviderOptions>(options =>
           {
               options.Issuer = this.Configuration["JwtSettings: Issuer"];
               options.Audience = this.Configuration["JwtSettings: Audience"];
               options.SigningCredentials = new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256);
         
           });
         
         
           services.AddAuthentication(options =>
           {
               options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
               options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
           })
           .AddJwtBearer(options =>
           {
               options.RequireHttpsMetadata = false;
               options.SaveToken = true;
               options.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateIssuerSigningKey = true,
                   IssuerSigningKey = new SymmetricSecurityKey(key),
                   ValidateIssuer = false,
                   ValidateAudience = false
         
               };
           });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddCors(options =>
            {
                options.AddPolicy("CvCORSPolicy",
                builder =>
                {

                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader()
                           .AllowCredentials();
                           
                });

            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetRequiredService<CvDbContext>())
                {
                    context.Database.EnsureCreated();
                }
            }


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseCors("CvCORSPolicy");
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
