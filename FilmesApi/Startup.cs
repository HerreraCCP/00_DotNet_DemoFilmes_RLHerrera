using FilmesApi.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;

namespace FilmesAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        private IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(opts => opts.UseLazyLoadingProxies().UseMySQL(Configuration.GetConnectionString("CinemaConnection")));
            services.AddControllers();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "RL Herrera API",
                    Version = "v1",
                    Description = "This Api only for test and consume in front",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Rodrigo Herrera",
                        Email = "herrera.ccp@gmail.com",
                        Url = new Uri("https://www.linkedin.com/in/rodrigo-herrera-0404/"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "API License",
                        Url = new Uri("https://en.wikipedia.org/wiki/Free_license"),
                    }
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.RoutePrefix = "swagger";
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Demo RL Herrera Api");
                });

            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            //app.UseEndpoints(e => e.MapControllers());
            //app.UseEndpoints(endpoints => endpoints.MapControllers());
        }

        //private static void UseExceptionHandling(IApplicationBuilder app, ILoggerFactory loggerFactory)
        //{
        //    app.UseExceptionHandler().WithConventions(config =>
        //    {
        //        config.ContentType = "application/json";
        //        config.MessageFormatter(s => JsonConvert.SerializeObject(new
        //        {
        //            Message = "An error occurred whilst processing your request"
        //        }));

        //        config.OnError((exception, httpContext) =>
        //        {
        //            var logger = loggerFactory.CreateLogger("GlobalExceptionHandler");
        //            logger.LogError(exception, exception.Message);
        //            return Task.CompletedTask;
        //        });
        //    });
        //}
    }
}
