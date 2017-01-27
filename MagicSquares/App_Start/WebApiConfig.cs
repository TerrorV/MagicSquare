using MagicSquares.BL.Abstract;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Dispatcher;

namespace MagicSquares
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.Formatters.Add(new JsonMediaTypeFormatter());
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("text/html"));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );


            Container container = new Container();
            container.Configure(x =>
            {
                x.Scan(scan =>
                {
                    scan.LookForRegistries();
                    scan.Assembly("MagicSquares.BL.Abstract");
                    scan.Assembly("MagicSquares.BL");
                    scan.Assembly("MagicSquares");
                    scan.WithDefaultConventions();
                    scan.AddAllTypesOf<ISquareProvider>();
                });
                //x.For<IEnumerable<IServiceProvider>>().Use(c => c.GetAllInstances<IServiceProvider>());
            });

            var provider = container.GetAllInstances<ISquareProvider>();

            config.Services.Replace(typeof(IHttpControllerActivator), new ServiceActivator(container));

        }
    }
}
