using System.Web.Http.ExceptionHandling;

namespace WebApiPlayground.Api.Loggers
{
    public class UnhandledExceptionLogger : ExceptionLogger
    {
        private readonly BadLogger _badLogger;

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