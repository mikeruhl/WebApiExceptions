using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using WebApiPlayground.Api.Loggers;

namespace WebApiPlayground.Api.Handlers
{
    public class ApiLogHandler : DelegatingHandler
    {
        private readonly BadLogger _logger;

        public ApiLogHandler()
        {
            _logger = BadLogger.Instance;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            var apiLogEntry = CreateApiLogEntryWithRequestData(request);
            if (request.Content != null)
                await request.Content.ReadAsStringAsync()
                    .ContinueWith(task => { apiLogEntry += $" | {task.Result}"; }, cancellationToken);

            return await base.SendAsync(request, cancellationToken);
        }

        private string CreateApiLogEntryWithRequestData(HttpRequestMessage request)
        {
            var context = (HttpContextBase) request.Properties["MS_HttpContext"];

            return
                $"{request.RequestUri} | {context.Request.ContentType} | {request.Method.Method}";
        }
    }
}