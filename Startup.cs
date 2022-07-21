using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dot_bioskop.DBContexts;
using dot_bioskop.Interfaces;
using dot_bioskop.Models;
using dot_bioskop.Datas;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using FluentValidation.AspNetCore;
using System.Reflection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace dot_bioskop
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
            string mySqlConnectionStr = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContextPool<MyDBContext>(options => options.UseMySql(mySqlConnectionStr, ServerVersion.AutoDetect(mySqlConnectionStr)));
            services.AddControllers().AddFluentValidation(fv =>
            {
                fv.ImplicitlyValidateChildProperties = true;
                fv.ImplicitlyValidateRootCollectionElements = true;
                fv.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            });

            var key = "Memang begitulah cinta, deritanya tiada akhir";

            services.AddAuthentication("Basic").AddScheme<BasicAuthenticationOptions, CustomAuthenticationHandler>("Basic", null);

            //services.AddAuthentication(x =>
            //{
            //    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //}).AddJwtBearer(x =>
            //{
            //    x.RequireHttpsMetadata = false;
            //    x.SaveToken = true;
            //    x.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateIssuerSigningKey = true,
            //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
            //        ValidateIssuer = false,
            //        ValidateAudience = false
            //    };
            //});

            services.AddSingleton<ICustomAuthenticationManager, CustomAuthenticationManager>();
            //services.AddSingleton<IJwtAuthenticationManager>(new JWTAuthenticationManager(key));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


            loggerFactory.AddFile("Logs/mylog-{Date}.txt");
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Server is running");
            });
        }
    }
}
