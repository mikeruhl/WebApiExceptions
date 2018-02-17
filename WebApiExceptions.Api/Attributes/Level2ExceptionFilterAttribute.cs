using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Filters;
using WebApiPlayground.Api.Exceptions;

namespace WebApiPlayground.Api.Attributes
{
    public class Level2ExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            if (context.Exception is Level2Exception)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(context.Exception.Message),
                    ReasonPhrase = "Level 2 Exception"
                };
                throw new HttpResponseException(resp);
            }
        }
    }
}