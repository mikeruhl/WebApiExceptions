using System.Collections.Generic;
using System.Web.Http;
using WebApiPlayground.Api.Loggers;

namespace WebApiPlayground.Api.Controllers
{
    public class LogController : ApiController
    {
        private readonly BadLogger _logService;

        public LogController()
        {
            _logService = new BadLogger();
        }

        // GET: api/Log
        public IEnumerable<string> Get()
        {
            return _logService.GetLogs();
        }

        // GET: api/Log/5
        public IHttpActionResult Get(int id)
        {
            var log = _logService.GetLog(id);
            if (log != null)
                return Ok(log);
            return BadRequest("no log exists");
        }
    }
}