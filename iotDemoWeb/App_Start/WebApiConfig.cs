using iotDemoWeb.Models;
using Microsoft.Azure.Mobile.Server;
using Microsoft.Azure.Mobile.Server.Config;
using Microsoft.Azure.Mobile.Server.Tables.Config;
using Swashbuckle.Application;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace iotDemoWeb
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // BENKO: Register MobileApp
            new MobileAppConfiguration()
                //.UseDefaultConfiguration()
                //.AddMobileAppHomeController()
                .MapApiControllers()
                .AddTables(
                    new MobileAppTableConfiguration()
                        .MapTableControllers()
                        .AddEntityFramework()
                    )
                .ApplyTo(config);


            // TODO: Add database context for service
            Database.SetInitializer<MobileDataContext>(null);
            ConfigSwagger(config);

        }

        private static void ConfigSwagger(HttpConfiguration config)
        {
            // Use the custom ApiExplorer that applies constraints. This prevents
            // duplicate routes on /api and /tables from showing in the Swagger doc.
            //config.Services.Replace(typeof(IApiExplorer), new MobileAppApiExplorer(config));
            config
               .EnableSwagger(c =>
               {
                   c.SingleApiVersion("v1", "InspectorPlus");

                   // Tells the Swagger doc that any MobileAppController needs a
                   // ZUMO-API-VERSION header with default 2.0.0
                   //c.OperationFilter<MobileAppHeaderFilter>();

                   // Looks at attributes on properties to decide whether they are readOnly.
                   // Right now, this only applies to the DatabaseGeneratedAttribute.
                   //c.SchemaFilter<MobileAppSchemaFilter>();
               })
               .EnableSwaggerUi();

        }
    }
}
