using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace FilmesApi.Configurations
{
    public static class SwaggerConfig
    {
        public static IServiceCollection ResolveSwaggerConfig(this IServiceCollection services)
        {
            return services.AddSwaggerGen(c =>
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
    }
}