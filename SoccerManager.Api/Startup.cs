using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SoccerManager.Api.Security;
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

        private const string ISSUER = "c1f51f42";
        private const string AUDIENCE = "c6bbbb645024";
        private const string SECRET_KEY = "c1f51f42-5727-4d15-b787-c6bbbb645024";
        private readonly SymmetricSecurityKey _signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SECRET_KEY));

        public void ConfigureServices(IServiceCollection services)
        {

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var configuration = builder.Build();

            services.AddMvc(config =>
                   {
                       var policy = new AuthorizationPolicyBuilder()
                                           .RequireAuthenticatedUser()
                                           .Build();
                       config.Filters.Add(new AuthorizeFilter(policy));
                   });
            services.AddCors();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Teacher", policy => policy.RequireClaim("SoccerManager", "Teacher"));
                options.AddPolicy("Administrator", policy => policy.RequireClaim("SoccerManager", "Administrator"));                
            });

            services.Configure<TokenOptions>(options =>
            {
                options.Issuer = ISSUER;
                options.Audience = AUDIENCE;
                options.SigningCredentials = new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha256);
            });


            //var tokenValidationParameters = new TokenValidationParameters
            //{
            //    ValidateIssuer = true,
            //    ValidIssuer = ISSUER,

            //    ValidateAudience = true,
            //    ValidAudience = AUDIENCE,

            //    ValidateIssuerSigningKey = true,
            //    IssuerSigningKey = _signingKey,

            //    RequireExpirationTime = true,
            //    ValidateLifetime = true,

            //    ClockSkew = TimeSpan.Zero
            //};


            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(cfg =>
                {
                    
                    cfg.RequireHttpsMetadata = false;
                    cfg.SaveToken = true;                    
                    cfg.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidIssuer = ISSUER,
                        ValidAudience = AUDIENCE,
                        IssuerSigningKey = _signingKey
                        
                    };

                });

            services.AddScoped<SoccerManagerDataContext, SoccerManagerDataContext>();
            services.AddScoped<StudentHandler, StudentHandler>();
            services.AddScoped<TeacherHandler, TeacherHandler>();
            services.AddScoped<ClassroomHandler, ClassroomHandler>();
            services.AddScoped<BankAccountHandler, BankAccountHandler>();
            services.AddTransient<IStudentRepository, StudentRepository>();
            services.AddTransient<IAddressRepository, AddressRepository>();
            services.AddTransient<IClassroomRepository, ClassroomRepository>();
            services.AddTransient<IBankAccountRepository, BankAccountRepository>();
            services.AddTransient<ITeacherRepository, TeacherRepository>();
            services.AddSwaggerGen(x =>
            {
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
            var supportedCultures = new[]
            {
                new CultureInfo("pt-BR")
            };

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("pt-BR"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });


            app.UseAuthentication();
            app.UseCors(x =>
            {
                x.AllowAnyHeader();
                x.AllowAnyMethod();
                x.AllowAnyOrigin();
            });
            app.UseMvc();
        }
    }
}
