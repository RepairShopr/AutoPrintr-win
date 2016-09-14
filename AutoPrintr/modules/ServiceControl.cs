using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.ServiceProcess;

namespace AutoPrintr
{
    static class ServiceControl
    {
        private static NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();

        public static void start(string serviceName, int timeoutMilliseconds)
        {
            startType(serviceName, StartupTypes.Automatic);
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
            startType(serviceName, StartupTypes.Disabled);
            //}
            //catch
            //{
            //    // ...
            //}
        }

        public static void enable(string serviceName)
        {
            startType(serviceName, StartupTypes.Automatic);
        }

        public static void disable(string serviceName)
        {
            startType(serviceName, StartupTypes.Disabled);
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
                try
                {
                    ServiceController sc = new ServiceController(name);
                    return sc.Status == ServiceControllerStatus.Running;
                }
                catch (Exception ex)
                {
                    log.Error(ex, "Error while requesting service status");
                    return false;
                }
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


        /// <summary>
        /// Set service start type
        /// </summary>
        /// <param name="serviceName"></param>
        /// <param name="startType"></param>
        public static void startType(string serviceName, StartupTypes startType)
        {
            //Obtain a handle to the service control manager database
            IntPtr scmHandle = OpenSCManager(null, null, SC_MANAGER_CONNECT);
            if (scmHandle == IntPtr.Zero)
            {
                throw new Exception("Failed to obtain a handle to the service control manager database.");
            }

            //Obtain a handle to the specified windows service
            IntPtr serviceHandle = OpenService(scmHandle, serviceName, SERVICE_QUERY_CONFIG | SERVICE_CHANGE_CONFIG);
            if (serviceHandle == IntPtr.Zero)
            {
                throw new Exception(string.Format("Failed to obtain a handle to service \"{0}\".", serviceName));
            }

            bool changeServiceSuccess = ChangeServiceConfig(serviceHandle, SERVICE_NO_CHANGE, (uint)startType, SERVICE_NO_CHANGE, null, null, IntPtr.Zero, null, null, null, null);

            if (!changeServiceSuccess)
            {
                string msg = string.Format("Failed to update service configuration for service \"{0}\". ChangeServiceConfig returned error {1}.", serviceName, Marshal.GetLastWin32Error().ToString());
                throw new Exception(msg);
            }

            //Clean up
            if (scmHandle != IntPtr.Zero) CloseServiceHandle(scmHandle);
            if (serviceHandle != IntPtr.Zero) CloseServiceHandle(serviceHandle);
        }

        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr OpenSCManager(string machineName, string databaseName, uint dwAccess);

        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr OpenService(IntPtr hSCManager, string lpServiceName, uint dwDesiredAccess);

        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern Boolean ChangeServiceConfig(
            IntPtr hService,
            UInt32 nServiceType,
            UInt32 nStartType,
            UInt32 nErrorControl,
            String lpBinaryPathName,
            String lpLoadOrderGroup,
            IntPtr lpdwTagId,
            [In] char[] lpDependencies,
            String lpServiceStartName,
            String lpPassword,
            String lpDisplayName);

        [DllImport("advapi32.dll", EntryPoint = "CloseServiceHandle")]
        private static extern int CloseServiceHandle(IntPtr hSCObject);

        private const uint SC_MANAGER_CONNECT = 0x0001;
        private const uint SERVICE_QUERY_CONFIG = 0x00000001;
        private const uint SERVICE_CHANGE_CONFIG = 0x00000002;
        private const uint SERVICE_NO_CHANGE = 0xFFFFFFFF;

        public enum StartupTypes : uint
        {
            BootStart = 0,      //A device driver started by the system loader. This value is valid only for driver services.
            SystemStart = 1,    //A device driver started by the IoInitSystem function. This value is valid only for driver services.
            Automatic = 2,      //A service started automatically by the service control manager during system startup.
            Manual = 3,         //A service started by the service control manager when a process calls the StartService function.
            Disabled = 4        //A service that cannot be started. Attempts to start the service result in the error code ERROR_SERVICE_DISABLED.
        }
    }
}
