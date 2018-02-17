using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiPlayground.Api.Repositories
{
    public class InMemoryLogRepository
    {
        private static InMemoryLogRepository _singleton;

        public InMemoryLogRepository()
        {

        }
        //singleton pattern right now.

        public static InMemoryLogRepository Instance
        {
            get
            {
                if(_singleton == null)
                    _singleton = new InMemoryLogRepository();
                return _singleton;
            }
        }

        private ConcurrentBag<string> _logs = new ConcurrentBag<string>();

        private ConcurrentBag<string> _exceptionLogs = new ConcurrentBag<string>();

        public void Log(string logLine)
        {
            _singleton._logs.Add($"{DateTime.Now:O} | {logLine}");
        }

        public void LogException(string logLine)
        {
            _singleton._exceptionLogs.Add($"{DateTime.Now:O} | {logLine}");
        }

        public ConcurrentBag<string> GetLogs()
        {
            return _singleton._logs;
        }

        public ConcurrentBag<string> GetExceptionLogs()
        {
            return _singleton._exceptionLogs;
        }
    }
}
