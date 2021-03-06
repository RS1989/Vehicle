﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gateway.Web.Api.Provider;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using provider = Gateway.Web.Api.Provider;


namespace Gateway.Web.Api
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
            services.AddLogging(builder =>
            {
                builder.AddFilter((category, level) => true);
                builder.AddConsole(options => options.IncludeScopes = true);
            });

            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info
            {
                Title = "API",
                Version = "1.0.0",
                Description = ""
            }));

            var clientUrl = Configuration[Constants.Constants.HttpService.HttpServiceUrlEnvVar];
            services.AddHttpClient(Constants.Constants.HttpService.HttpServiceUrl, client =>
            {
                client.BaseAddress = new Uri(clientUrl);
            });

            //IOC
            services.AddTransient<IVehicleProvider, VehicleProvider>();
            services.AddTransient<IStatusProvider, StatusProvider>();
            services.AddTransient<ICustomerProvider, CustomerProvider>();
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
            
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "VEHICLE API SERVICE"));

            app.UseHttpsRedirection();
            app.UseCors("MyPolicy");
            app.UseMiddleware(typeof(ErrorHandlingMiddleware));
            app.UseMvc();
        }
    }
}
