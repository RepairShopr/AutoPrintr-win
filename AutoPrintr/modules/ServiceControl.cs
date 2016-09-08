using System;
using System.Collections.Generic;
//using System.Linq;
//using System.Text;
using System.ServiceProcess;

namespace AutoPrintr
{
    static class ServiceControl
    {
        public static void start(string serviceName, int timeoutMilliseconds)
        {
            ServiceController service = new ServiceController(serviceName);
            //try
            //{
            TimeSpan timeout = TimeSpan.FromMilliseconds(timeoutMilliseconds);
            service.Start();
            service.WaitForStatus(ServiceControllerStatus.Running, timeout);
            //}
            //catch
            //{
            //    // ...
            //}
        }

        public static void stop(string serviceName, int timeoutMilliseconds)
        {
            ServiceController service = new ServiceController(serviceName);
            //try
            //{
            TimeSpan timeout = TimeSpan.FromMilliseconds(timeoutMilliseconds);
            service.Stop();
            service.WaitForStatus(ServiceControllerStatus.Stopped, timeout);
            //}
            //catch
            //{
            //    // ...
            //}
        }

        public static bool isInstalled(string name)
        {
            foreach (var c in ServiceController.GetServices())
            {
                if (c.ServiceName == name)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool isRunning(string name)
        {
            bool installed = isInstalled(name);
            if (installed)
            {
                ServiceController sc = new ServiceController(name);
                return sc.Status == ServiceControllerStatus.Running;
            }
            return false;

            //switch (sc.Status)
            //{
            //    case ServiceControllerStatus.Running:
            //        return "Running";
            //    case ServiceControllerStatus.Stopped:
            //        return "Stopped";
            //    case ServiceControllerStatus.Paused:
            //        return "Paused";
            //    case ServiceControllerStatus.StopPending:
            //        return "Stopping";
            //    case ServiceControllerStatus.StartPending:
            //        return "Starting";
            //    default:
            //        return "Status Changing";
            //}
        }
    }
}
