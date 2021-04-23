using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using NSwag;
using NSwag.Generation.Processors.Security;

namespace Ponea.Homework.Bookshop.Api
{
    /// <summary>
    /// 
    /// </summary>
    public static class DependencyExtensions
    {
        /// <summary>
        /// Adds the document swagger.
        /// </summary>
        /// <param name="service">The service.</param>
        public static void AddDocSwagger(this IServiceCollection service)
        {
            service.AddSwaggerDocument(x =>
            {
                x.GenerateXmlObjects = true;
                x.GenerateEnumMappingDescription = true;
                x.DocumentName = "Home Work Apis";
                x.Title = "Home Work Assignment";
                x.Description = "The is an Assignment Apis";
                x.AddSecurity("oauth2", Enumerable.Empty<string>(), new OpenApiSecurityScheme
                {
                    Type = OpenApiSecuritySchemeType.ApiKey,
                    Name = "Authorization",
                    In = OpenApiSecurityApiKeyLocation.Header,
                    Description = "Type into the text-box: Bearer {your JWT token}.",
                    Scheme = "Bearer"
                });
                x.OperationProcessors.Add(
                    new AspNetCoreOperationSecurityScopeProcessor("oauth2"));
            });
        }

        /// <summary>
        /// Uses the document swagger.
        /// </summary>
        /// <param name="app">The application.</param>
        public static void UseDocSwagger(this IApplicationBuilder app)
        {
            app.UseOpenApi();
            app.UseSwaggerUi3(s =>
            {
                s.Path = "";
                s.DocumentTitle = "Room Services Api";
            });
            app.UseReDoc(d =>
            {
                d.Path = "/redoc";
            });
        }
    }
}