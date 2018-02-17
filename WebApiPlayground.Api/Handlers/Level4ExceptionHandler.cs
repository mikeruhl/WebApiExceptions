using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using WebApiPlayground.Api.Exceptions;

namespace WebApiPlayground.Api.Handlers
{
    public class Level4ExceptionHandler : ExceptionHandler
    {
        public override void Handle(ExceptionHandlerContext context)
        {
            if (context.Exception is Level4Exception)
            {
                var result = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(context.Exception.Message),
                    ReasonPhrase = "Level4Exception"
                };
                context.Result = new Level4ExceptionResult(result);
            }
            else
            {
                //no more levels, but if we did, we'd handle them here.
            }
        }
    }

    public class Level4ExceptionResult : IHttpActionResult
    {
        
        private readonly HttpResponseMessage _httpResponseMessage;
        public Level4ExceptionResult(HttpResponseMessage httpResponseMessage)
        {

            _httpResponseMessage = httpResponseMessage;
        }
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(_httpResponseMessage);
        }
    }
}
