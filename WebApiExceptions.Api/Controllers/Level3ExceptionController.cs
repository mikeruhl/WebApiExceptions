using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiPlayground.Api.Exceptions;

namespace WebApiPlayground.Api.Controllers
{
    [Route("api/exception/3")]
    public class Level3ExceptionController : ApiController
    {
        public IHttpActionResult Get()
        {
            throw new Level3Exception("This is a level 3 exception.  Check the exception logs, all exceptions should be there.");
        }

      
    }
}
