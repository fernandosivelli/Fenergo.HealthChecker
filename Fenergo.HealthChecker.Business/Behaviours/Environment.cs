using Fenergo.HealthChecker.Behaviours;
using Microsoft.Win32;
using System;
using System.Linq;
using System.ServiceProcess;

namespace Fenergo.HealthChecker.Business.Behaviours
{
    public class Environment : IBehaviour
    {
        public Result Execute()
        {
            var result = new Result(true);
            CheckEnvironmentVariables(result);
            CheckSqlService(result);
            CheckDotNetVersion(result);
            CheckNodeJsVersion(result);
            return result;
        }

        private Result CheckEnvironmentVariables(Result result)
        {
            var fmb = System.Environment.GetEnvironmentVariable("FMB_HOME");
            var jre = System.Environment.GetEnvironmentVariable("JRE_HOME");

            if (fmb == null)
                result.Messages.Add("Environment Variable: FMB_HOME is missing.");

            if (jre == null)
                result.Messages.Add("Environment Variable: FMB_HOME is missing.");

            return result;
        }

        private Result CheckSqlService(Result result)
        {
            var sqlService = ServiceController.GetServices().SingleOrDefault(x => x.ServiceName == "SQL Server (MSSQLSERVER)");
            if (sqlService != null)
                if (sqlService.Status != ServiceControllerStatus.Running)
                    result.Messages.Add("Sql Server service is not running.");
                else
                    result.Messages.Add("Sql Server service not found.");

            return result;
        }

        private Result CheckDotNetVersion(Result result)
        {
            using (RegistryKey ndpKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey("SOFTWARE\\Microsoft\\NET Framework Setup\\NDP\\v4\\Full\\"))
            {
                int releaseKey = Convert.ToInt32(ndpKey.GetValue("Release"));
                if (releaseKey < 460798)
                    result.Messages.Add(".Net version is wrong.");
            }
            return result;
        }
        private Result CheckNodeJsVersion(Result result)
        {
            using (RegistryKey ndpKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey("SOFTWARE\\Node.js"))
            {
                int nodeVersion = Convert.ToInt32(ndpKey.GetValue("Version"));

                if (nodeVersion == 0)
                    result.Messages.Add("Node.js not found.");
                if (nodeVersion != 750)
                    result.Messages.Add("Node.js with wrong version.");
            }
            return result;
        }
    }
}
