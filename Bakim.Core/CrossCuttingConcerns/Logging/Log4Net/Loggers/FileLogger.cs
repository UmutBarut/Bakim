using Bakim.Core.CrossCuttingConcerns.Logging.Log4Net;

namespace Bakim.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers
{
    public class FileLogger : LoggerServiceBase
    {
        public FileLogger() : base("JsonFileLogger")
        {

        }
    }
}
