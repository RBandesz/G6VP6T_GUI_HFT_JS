using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using TireShop.Endpoint.Services;
using TireShop.Logic;
using TireShop.Data;
using TireShop.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TireShop.Repository.TireRepo;
using TireShop.Data.Tables;
using TireShop.Repository.BrandRepo;
using TireShop.Repository.TireSpecificationRepo;
using TireShop.Logic.Logicinterfaces;
using TireShop.Logic.Logics;
using Microsoft.EntityFrameworkCore;

namespace TireShop.Endpoint
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
            services.AddTransient<DbContext, TireDbContext>();

            services.AddTransient<ITireRepository, TireRepository>();
            services.AddTransient<IBrandRepository, BrandRepository>();
            services.AddTransient<ITireSpecificationRepository, TireSpecificationRepository>();


            services.AddTransient<ITireShopLogic, TireShopLogic>();
            services.AddTransient<ILogicAdministration, LogicAdministration>();

            services.AddSignalR();
 
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TireShop.Endpoint", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TireShop.Endpoint v1"));
            }

            app.UseExceptionHandler(c => c.Run(async context =>
            {
                var exception = context.Features
                    .Get<IExceptionHandlerPathFeature>()
                    .Error;
                var response = new { Msg = exception.Message };
                await context.Response.WriteAsJsonAsync(response);
            }));

            app.UseCors(x => x
                .AllowCredentials()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .WithOrigins("http://localhost:63502"));

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<SignalRHub>("/hub");
            });
        }
    }
}
