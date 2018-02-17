using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiPlayground.Api.Repositories;

namespace WebApiPlayground.Api.Loggers
{
    public class BadLogger
    {
        private static BadLogger _badLogger;
        private InMemoryLogRepository _repository;

        public static BadLogger Instance
        {
            get
            {
                if (_badLogger == null)
                    _badLogger = new BadLogger(InMemoryLogRepository.Instance);
                return _badLogger;
            }
        }

        public BadLogger()
        {

        }

        private BadLogger(InMemoryLogRepository repository)
        {
            _repository = repository;
        }

        public void Log(string message)
        {
            _badLogger._repository.Log(message);
        }

        public void LogException(string message)
        {
            _badLogger._repository.LogException(message);
        }

        public IEnumerable<string> GetLogs()
        {
            return _badLogger._repository.GetLogs();
        }

        public string GetLog(int id)
        {
            var logs = _badLogger._repository.GetLogs().ToArray();
            if (logs.Length > id)
                return logs[id];
            return null;

        }

        public string GetExceptionLog(int id)
        {
            var logs = _badLogger._repository.GetExceptionLogs().ToArray();
            if (logs.Length > id)
                return logs[id];
            return null;
        }

        public IEnumerable<string> GetExceptionLogs()
        {
            return _badLogger._repository.GetExceptionLogs();
        }
    }
}
