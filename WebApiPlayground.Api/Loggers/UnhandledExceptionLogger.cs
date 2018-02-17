using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.ExceptionHandling;

namespace WebApiPlayground.Api.Loggers
{
    public class UnhandledExceptionLogger : ExceptionLogger
    {
        private BadLogger _badLogger;

        public UnhandledExceptionLogger()
        {
            _badLogger = BadLogger.Instance;
        }
        public override void Log(ExceptionLoggerContext context)
        {
            var log = context.Exception.ToString();
            _badLogger.LogException(log);

        }
    }
}
