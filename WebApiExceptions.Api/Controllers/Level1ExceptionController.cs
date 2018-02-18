using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiPlayground.Api.Exceptions;
using WebApiPlayground.Api.Loggers;

namespace WebApiPlayground.Api.Controllers
{
    [Route("api/exception/1")]
    public class Level1ExceptionController : ApiController
    {

        public IHttpActionResult Get()
        {

            throw new HttpResponseException(
                new HttpResponseMessage(HttpStatusCode.BadRequest)
                { Content = new StringContent("This is a level 1 exception") });

        }
    }
}