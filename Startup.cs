using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SwaggerOAS3RestAPI.Middlewares;
using System;

namespace swagger_oas3
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "RED RIBBON Rest API",
                    Description = "New REST API for RED RIBBON backend services. This will gather information and feed all our new androids.",
                    TermsOfService = new Uri("https://en.wikipedia.org/wiki/List_of_Dragon_Ball_characters#Red_Ribbon_Army"),
                    Contact = new OpenApiContact
                    {
                        Name = "RED RIBBON",
                        Email = "support@redribbondragonball.com",
                        Url = new Uri("https://en.wikipedia.org/wiki/List_of_Dragon_Ball_characters#Red_Ribbon_Army"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "RED RIBBON Privacy Policy",
                        Url = new Uri("https://en.wikipedia.org/wiki/List_of_Dragon_Ball_characters#Red_Ribbon_Army"),
                    }
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Required to change the swagger style (access external files)
            app.UseStaticFiles();

            app.UseAuthentication();
            app.UseSwaggerAuthorized();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                string swaggerJsonBasePath = string.IsNullOrWhiteSpace(c.RoutePrefix) ? "." : "..";
                c.SwaggerEndpoint($"{swaggerJsonBasePath}/swagger/v1/swagger.json", "Version 1");
                c.InjectStylesheet($"{swaggerJsonBasePath}/swagger/ui/custom.css");
                c.InjectJavascript($"{swaggerJsonBasePath}/swagger/ui/custom.js");
                c.RoutePrefix = "docs";
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