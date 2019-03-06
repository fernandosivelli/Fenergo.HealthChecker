using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fenergo.HealthChecker.Business
{
    public enum ProcessorTypeEnum
    {
        Bre = 1,
        Fdim = 2,
        ElasticSearch = 3,
        Queues = 4,
        Application = 5,
        Logs = 6
    }
}
