using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Cloud_System_dev_ops.Models;
using Cloud_System_dev_ops.Repo;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore.Design;

namespace Cloud_System_dev_ops
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            CurrentEnvironment = env;
        }

        public IConfiguration Configuration { get; }
        public IHostingEnvironment CurrentEnvironment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();  //Get rid of existing bearer tokens.

            services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {
                    options.Authority = Configuration.GetSection("UrlConnections")["Auth"];
                    options.Audience = "Api_Link";
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Manager", builder =>
                {
                    builder.RequireClaim("role", "Manager");
                });
                options.AddPolicy("Staffpol", builder =>
                {
                    builder.RequireClaim("role", "Staff", "Manager");
                });
            });
         


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<ReSaleDataBaseContext>(options =>
            {
                String connection = Configuration.GetConnectionString("UserConnectionString");
                options.UseSqlServer(connection);
            });
            
            if (CurrentEnvironment.IsDevelopment())
            {
               
                services.AddSingleton<IRepository<ReSaleModel>, EntityFrameWorkReSaleRepositry>();
            }
            else
            {
                services.AddSingleton<IRepository<ReSaleModel>, EntityFrameWorkReSaleRepositry>();
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            //auth middleware during HTTP request
            app.UseAuthentication(); 

            app.UseMvc();
        }
    }
}
