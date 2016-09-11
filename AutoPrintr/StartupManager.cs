using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.Security.Principal;

namespace AutoPrintr
{
    public static class StartupManager
    {
        public static void addToCurrentUserStartup(string opt = "")
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
            {
                key.SetValue(System.Diagnostics.Process.GetCurrentProcess().ProcessName, "\"" + System.Reflection.Assembly.GetExecutingAssembly().Location + "\"" + opt);
            }
        }

        public static void addToAllUserStartup(string opt = "")
        {
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
            {
                key.SetValue(System.Diagnostics.Process.GetCurrentProcess().ProcessName, "\"" + System.Reflection.Assembly.GetExecutingAssembly().Location + "\"" + opt);
            }
        }

        public static void removeFromCurrentUserStartup()
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
            {
                key.DeleteValue(System.Diagnostics.Process.GetCurrentProcess().ProcessName, false);
            }
        }

        public static void removeFromAllUserStartup()
        {
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
            {
                key.DeleteValue(System.Diagnostics.Process.GetCurrentProcess().ProcessName, false);
            }
        }

    }
}
