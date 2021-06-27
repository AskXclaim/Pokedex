using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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

        private static readonly string SwaggerApiName =
            $"{System.Reflection.Assembly.GetEntryAssembly()?.GetName().Name} API V1";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
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
            services.AddAutoMapper(typeof(Startup));
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