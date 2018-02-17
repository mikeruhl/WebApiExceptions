using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiPlayground.Api.Exceptions;
using WebApiPlayground.Api.Loggers;

namespace WebApiPlayground.Api.Controllers
{
    public class ExceptionController : ApiController
    {
        private BadLogger _logger;

        public ExceptionController()
        {
            _logger = BadLogger.Instance;
        }
        // GET: api/Exception/5
        public IHttpActionResult Get(int id)
        {
            switch (id)
            {
                case 1:
                    throw new HttpResponseException(
                        new HttpResponseMessage(HttpStatusCode.BadRequest)
                            {Content = new StringContent("This is a level 1 exception")});
                case 3:
                    throw new Level3Exception("This is a level 3 exception.  Check the exception logs, all exceptions should be there.");
                case 2:
                    var redirectTo2 = $"{Url.Content("~/")}api/exception/{id}/level3/0";
                    return Redirect(redirectTo2);
                case 4:
                    var redirectTo4 = $"{Url.Content("~/")}api/exception/{id}/level4/0";
                    return Redirect(redirectTo4);
                default:
                    return Ok(id);
            }
        }
    }
}