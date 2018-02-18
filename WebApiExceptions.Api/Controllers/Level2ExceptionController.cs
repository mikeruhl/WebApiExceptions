using System.Web.Http;
using WebApiPlayground.Api.Attributes;
using WebApiPlayground.Api.Services;

namespace WebApiPlayground.Api.Controllers
{
    [Route("api/exception/2")]
    public class Level2ExceptionController : ApiController
    {
        private readonly ExceptionService _exceptionService;

        public Level2ExceptionController()
        {
            _exceptionService = new ExceptionService();
        }

        [HttpGet]
        [Level2ExceptionFilter]
        // GET: api/exception/x/level2/5
        public IHttpActionResult Get()
        {
            _exceptionService.ThrowLevel2Exception(2);
            return Ok();
        }
    }
}