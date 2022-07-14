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
using dot_bioskop.Datas;
using Microsoft.EntityFrameworkCore;

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

            services.AddControllers();
            services.AddScoped<IUsersData, SqlUsersData>();
            services.AddScoped<IMoviesData, SqlMoviesData>();
            services.AddScoped<ITagsData, SqlTagsData>();
            services.AddScoped<IStudiosData, SqlStudiosData>();
            services.AddScoped<IMovieTagsData, SqlMovieTagsData>();
            services.AddScoped<IOrdersData, SqlOrdersData>();
            services.AddScoped<IMovieSchedulesData, SqlMovieSchedulesData>();
            services.AddScoped<IOrderItemsData, SqlOrderItemsData>();
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            loggerFactory.AddFile("Logs/mylog-{Date}.txt");
            //app.UseWhen(context => context.Request.Path.StartsWithSegments("/api"), appBuilder =>
            //{
            //    appBuilder.UsersController();
            //});
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World From 1st Middleware");
            //});
        }
    }
}
