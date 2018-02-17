using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiPlayground.Api.Loggers;

namespace WebApiPlayground.Api.Controllers
{
    public class ExceptionLogController : ApiController
    {
        private BadLogger _logService;

        public ExceptionLogController()
        {
            _logService = BadLogger.Instance;
        }
        // GET: api/ExceptionLog
        public IEnumerable<string> Get()
        {
            return _logService.GetExceptionLogs();
        }

        // GET: api/ExceptionLog/5
        public IHttpActionResult Get(int id)
        {
            var log = _logService.GetExceptionLog(id);
            if (log != null)
                return Ok(log);
            return BadRequest("no log with id exists.");
        }

    }
}
