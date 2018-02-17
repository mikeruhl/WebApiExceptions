using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using WebApiPlayground.Api.Handlers;
using WebApiPlayground.Api.Loggers;

namespace WebApiPlayground.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                "DefaultApi",
                "api/{controller}/{id}",
                new {id = RouteParameter.Optional}
            );
            config.Services.Replace(typeof(IExceptionLogger), new UnhandledExceptionLogger());
            config.Services.Replace(typeof(IExceptionHandler), new Level4ExceptionHandler());
            config.MessageHandlers.Add(new ApiLogHandler());
        }
    }
}