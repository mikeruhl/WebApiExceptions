using System.Web.Http;
using WebApiPlayground.Api.Attributes;
using WebApiPlayground.Api.Services;

namespace WebApiPlayground.Api.Controllers
{
    [Route("api/exception/{id}/level2/{type}")]
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
        public IHttpActionResult Get(int id, int type)
        {
            _exceptionService.ThrowLevel2Exception(id * type);
            return Ok();
        }
    }
}