﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Vehicle.DB.Api.Provider;
using Vehicle.DB.repository;
using Vehicle.DB.repository.status;

namespace Vehicle.DB.Api
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
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            var connection = Configuration["ConnectionString"]; 
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connection));
            var config = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .Build();

            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info
            {
                Title = "API",
                Version = "1.0.0",
                Description = ""                
            }));

            //IOC
            services.AddTransient<IStatusQueryFactory, StatusQueryFactory>();
            services.AddTransient<ICustomerQueryFactory, CustomerQueryFactory>();
            services.AddTransient<IVehicleQueryFactory, VehicleQueryFactory>();
            services.AddTransient<ICustomerProvider, CustomerProvider>();
            services.AddTransient<IStatusProvider, StatusProvider>();
            services.AddTransient<IVehicleProider, VehicleProider>();

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
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "VEHICLE DB SERVICE"));

            app.UseHttpsRedirection();
            app.UseCors("MyPolicy");
            app.UseMiddleware(typeof(ErrorHandlingMiddleware));
            app.UseMvc();
        }


        private static void InitializeMigrations(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                using (var dbContext = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>())
                {
                    dbContext.Database.Migrate();
                }
            }
        }
    }
}
