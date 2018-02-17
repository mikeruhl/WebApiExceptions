using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Routing;
using Newtonsoft.Json;
using WebApiPlayground.Api.Loggers;

namespace WebApiPlayground.Api.Handlers
{
    public class ApiLogHandler : DelegatingHandler
    {
        private BadLogger _logger;

        public ApiLogHandler()
        {
            _logger = BadLogger.Instance;
        }
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            var apiLogEntry = CreateApiLogEntryWithRequestData(request);
            if (request.Content != null)
            {
                await request.Content.ReadAsStringAsync()
                    .ContinueWith(task => { apiLogEntry +=  $" | {task.Result}"; }, cancellationToken);
            }

            return await base.SendAsync(request, cancellationToken)
                .ContinueWith(task =>
                {
                    var response = task.Result;

                    // Update the API log entry with response info
                    apiLogEntry += $" | {(int)response.StatusCode}";

                    // TODO: Save the API log entry to the database
                    _logger.Log(apiLogEntry);

                    return response;
                }, cancellationToken);
        }

        private string CreateApiLogEntryWithRequestData(HttpRequestMessage request)
        {
            var context = ((HttpContextBase)request.Properties["MS_HttpContext"]);
            var routeData = request.GetRouteData();

            return $"{request.RequestUri} | {context.Request.ContentType} | {request.Method.Method} | {JsonConvert.SerializeObject(routeData, Formatting.Indented)}";

        }
    }
}
