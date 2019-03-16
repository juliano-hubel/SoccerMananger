﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SoccerManager.Domain.Handlers;
using SoccerManager.Domain.Repositories;
using SoccerManager.Infra.Context.DataContext;
using SoccerManager.Infra.Context.Repositories;
using SoccerManager.Shared;
using Swashbuckle.AspNetCore.Swagger;

namespace SoccerManager.Api
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var configuration = builder.Build();

            services.AddMvc();

            services.AddScoped<SoccerManagerDataContext, SoccerManagerDataContext>();
            services.AddScoped<StudentHandler, StudentHandler>();
            services.AddScoped<ClassroomHandler, ClassroomHandler>();
            services.AddTransient<IStudentRepository, StudentRepository>();
            services.AddTransient<IAddressRepository, AddressRepository>();
            services.AddTransient<IClassroomRepository, ClassroomRepository>();
            services.AddSwaggerGen(x => {
                x.SwaggerDoc("v1", new Info { Title = "SoccerMananger", Version = "v1" });
            });
            Settings.ConnectionString = $"{configuration["ConnectionString"]}";
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())            
                app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SoccerMananger - V1"));

            app.UseMvc();            
        }
    }
}