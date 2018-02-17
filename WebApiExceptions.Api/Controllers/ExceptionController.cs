using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
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
                case 2:
                    var exceptionToThrow = new HttpResponseException(
                        new HttpResponseMessage(HttpStatusCode.BadRequest)
                            { Content = new StringContent("This is a level 2 exception") });
                    _logger.LogException(exceptionToThrow.Message);
                    throw exceptionToThrow;
                case 3:
                    var redirectTo2 = $"{Url.Content("~/")}api/exception/{id}/level2/0";
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