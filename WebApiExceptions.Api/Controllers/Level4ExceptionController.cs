using System.Web.Http;
using WebApiPlayground.Api.Exceptions;

namespace WebApiPlayground.Api.Controllers
{
    [Route("api/exception/4")]
    public class Level4ExceptionController : ApiController
    {

        public IHttpActionResult Get()
        {
            throw new Level4Exception($"Exception level 4");
        }
    }
}