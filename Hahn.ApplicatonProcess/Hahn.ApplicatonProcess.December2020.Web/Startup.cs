using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using FluentValidation.AspNetCore;
using Hahn.ApplicatonProcess.December2020.Web.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Hahn.ApplicatonProcess.December2020.Web.Infrastructure.Middlewares;
using Hahn.ApplicatonProcess.December2020.Web.Infrastructure.Resources;
using Hahn.ApplicatonProcess.December2020.Web.Infrastructure.Services;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Localization;
using Serilog;
using Swashbuckle.AspNetCore.Filters;

namespace Hahn.ApplicatonProcess.December2020.Web
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
            // cors
            services.AddCors(options =>
            {
                options.AddPolicy(Constants.CorsPolicyName, builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            services.AddControllers()
                .AddFluentValidation();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(SwaggerConstants.Version, new OpenApiInfo { Title = SwaggerConstants.OpenApiInfoTitle, Version = SwaggerConstants.Version });
                c.ExampleFilters();
            });

            // bl
            services.AddBusinessLogic();

            // automapper
            services.AddAutoMapper();

            // fluent validators
            services.AddFluentValidators();

            // filters
            services.AddSwaggerExamplesFromAssemblies(Assembly.GetEntryAssembly());

            // localization
            services.AddSingleton<IStringLocalizerFactory, JsonStringLocalizerFactory>();
            services.AddSingleton<IStringLocalizer, JsonStringLocalizer>();
            services.AddLocalization(options => options.ResourcesPath = Constants.ResourcesPath);
            services.Configure<RequestLocalizationOptions>(options => {
                var supportedCultures = new List<CultureInfo>
                {
                    new CultureInfo(Cultures.en_US),
                    new CultureInfo(Cultures.fr_FR),
                    new CultureInfo(Cultures.es_ES)
                };
                options.DefaultRequestCulture = new RequestCulture(Cultures.es_ES);
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });

            // uncomment this lines to work with es-ES spanish culture
            // CultureInfo.DefaultThreadCurrentCulture = CultureInfo.GetCultureInfo(Cultures.es_ES);
            // CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.GetCultureInfo(Cultures.es_ES);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint(SwaggerConstants.JsonUrl, SwaggerConstants.Name));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(Constants.CorsPolicyName);

            app.UseSerilogRequestLogging();

            app.UseMiddleware<ErrorHandlingMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
