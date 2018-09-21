using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fenergo.HealthChecker.Business
{
    public class Result
    {
        public bool Success { get; set; }

        public List<string> Messages { get; set; }

        public Result()
        {
        }
        public Result(bool success)
        {
            Success = success;
            Messages = new List<string>();
        }

        public Result(bool success, string message) {
            Success = success;
            Messages.Add(message);
        }
    }
}
