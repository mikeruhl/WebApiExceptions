using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiPlayground.Api.Attributes;
using WebApiPlayground.Api.Services;

namespace WebApiPlayground.Api.Controllers
{
    public class ExceptionController : ApiController
    {
        private ExceptionService _exceptionService;

        public ExceptionController()
        {
            _exceptionService = new ExceptionService();
        }
        // GET: api/Exception/5
        public IHttpActionResult Get(int id)
        {
            switch (id)
            {
                case 1:
                    throw new ArgumentException("This is a level 1 exception.");
                case 2:
                   throw new HttpResponseException(
                       new HttpResponseMessage(HttpStatusCode.BadRequest)
                           { Content = new StringContent("This is a level 1 modified exception")});
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
