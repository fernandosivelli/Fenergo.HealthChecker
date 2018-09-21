using Fenergo.HealthChecker.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fenergo.HealthChecker.Behaviours
{
    public interface IBehaviour
    {
        Result Execute();
    }
}
