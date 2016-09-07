using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration.Install;
using System.Reflection;

namespace AutoPrintr
{
    class serviceInstaller
    {
        //private static readonly ILog log = LogManager.GetLogger(typeof(Program));
        private static readonly string exePath = Assembly.GetExecutingAssembly().Location;
        
        public static bool Install()
        {
            try { 
                ManagedInstallerClass.InstallHelper(new[] { exePath });
                //ServiceControl.start("AutoPrintrService", 10000);
            }
            catch { return false; }
            return true;
        }

        public static bool Uninstall()
        {
            try { ManagedInstallerClass.InstallHelper(new[] { "/u", exePath }); }
            catch { return false; }
            return true;
        }
    }
}
