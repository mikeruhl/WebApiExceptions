using System.Web.Http;
using WebApiPlayground.Api.Exceptions;

namespace WebApiPlayground.Api.Controllers
{
    [Route("api/exception/{id}/level4/{type}")]
    public class Level4ExceptionController : ApiController
    {
        // GET: api/Level4Exception/5
        public IHttpActionResult Get(int id, int type)
        {
            throw new Level4Exception($"Passed values: {id}, {type}");
        }
    }
}