using System;
using Microsoft.Win32;
using System.Security.Principal;

namespace AutoPrintr
{
    public static class User
    {
        /// <summary>
        /// Check if user admin
        /// </summary>
        /// <returns></returns>
        public static bool IsAdministrator()
        {
            //bool value to hold our return value
            
            bool isAdmin = false;
            try
            {
                //get the currently logged in user
                WindowsIdentity user = WindowsIdentity.GetCurrent();
                WindowsPrincipal principal = new WindowsPrincipal(user);
                isAdmin = principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
            catch (UnauthorizedAccessException ex)
            {
                isAdmin = false;
            }
            catch (Exception ex)
            {
                isAdmin = false;
            }
            return isAdmin;
        }

        /// <summary>
        /// Is system user
        /// </summary>
        /// <returns></returns>
        public static bool IsSystem()
        {
            try
            {
                WindowsIdentity user = WindowsIdentity.GetCurrent();
                return user.IsSystem;
            }
            catch (UnauthorizedAccessException)
            {
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
