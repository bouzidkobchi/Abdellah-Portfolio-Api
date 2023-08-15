using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Abdellah_Portfolio.Api
{
    public static class ConfigSwaggerUI
    {
        public static WebApplicationBuilder ConfiguringSwagger(this WebApplicationBuilder builder)
        {
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Abdellah-Portfolio",
                    Description = ".Net Api For Managing Abdellah-Portfolio Database Operations",
                });

                // allow using xml comments :
                string xmlFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                string xmlAbsolutePath = Path.Combine(AppContext.BaseDirectory, xmlFileName);

                options.IncludeXmlComments(xmlAbsolutePath);


            });
            return builder;
        }

        public static WebApplication ConfiguringSwagger(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                options.RoutePrefix = string.Empty;
            });

            return app;
        }
    }
}
