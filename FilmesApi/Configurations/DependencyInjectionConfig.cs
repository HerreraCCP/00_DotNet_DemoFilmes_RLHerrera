using FilmesApi.Service;
using Microsoft.Extensions.DependencyInjection;

namespace FilmesApi.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<FilmeService, FilmeService>();
            services.AddScoped<CinemaService, CinemaService>();
            services.AddScoped<SessaoService, SessaoService>();
            
            return services;
        }
    }
}