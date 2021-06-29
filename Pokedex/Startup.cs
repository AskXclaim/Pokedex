using System;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Pokedex.Application.Infrastructure.Instances;
using Pokedex.Application.Infrastructure.Interfaces;
using Pokedex.Service.Common;
using Pokedex.Service.Infrastructure.Instance;
using Pokedex.Service.Infrastructure.Interfaces;

namespace Pokedex
{
    public class Startup
    {
        private const string SwaggerJsonPath = "/swagger/v1/swagger.json";

        private const string Version = "v1";
        private const string Title = "Pokex API";

        private static readonly string Description =
       $"Fun 'Pokedex' API that has two endpoints that:{Environment.NewLine}" +
       $"1. Return basic Pokemon information{Environment.NewLine}" +
        "2. Return basic Pokemon information but with a fun translation of the pokemon description";

        private static readonly string SwaggerApiName =
            $"{Assembly.GetEntryAssembly()?.GetName().Name} API {Version}";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            ConfigurationHolder.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddHttpClient();
            services.AddScoped<IPokemonDetailRepository, PokemonDetailRepository>();
            services.AddScoped<IPokemonIdentifierService, PokemonIdentifierService>();
            services.AddScoped<IPokemonDetailService, PokemonDetailService>();
            services.Configure<TranslationSettings>(Configuration.GetSection(nameof(TranslationSettings)));

            services.AddSwaggerGen();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(Version, new OpenApiInfo
                {
                    Version = Version,
                    Title = Title,
                    Description = Description,
                });
            });
            services.AddAutoMapper(typeof(Startup));
            services.AddApiVersioning(o =>
            {
                o.ReportApiVersions = true;
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.DefaultApiVersion = new ApiVersion(1, 0);
                o.ApiVersionReader = new HeaderApiVersionReader("x-api-version");
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(SwaggerJsonPath, SwaggerApiName);
                c.RoutePrefix = string.Empty;
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}