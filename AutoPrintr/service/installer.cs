using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AutoPrintr.service
{
    static class Installer
    {
        public static bool install()
        {
            if (StartUpManager.IsUserAdministrator())
            {
                StartUpManager.AddApplicationToAllUserStartup();
                return true;
            }
            else
            {
                //MessageBox.Show();
                return false;
            }
        }

        public static bool uninstall()
        {
            if (StartUpManager.IsUserAdministrator())
            {
                StartUpManager.RemoveApplicationFromAllUserStartup();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
