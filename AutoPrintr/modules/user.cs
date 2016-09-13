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
            catch (UnauthorizedAccessException)
            {
                isAdmin = false;
            }
            catch (Exception)
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

        public static bool isNetworkService()
        {
            try
            { 
                WindowsIdentity user = WindowsIdentity.GetCurrent();
                var u = user.Name.Split('\\');
                return u[1] == "NETWORK SERVICE";
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
        public static string name()
        {
            try
            {   
                WindowsIdentity user = WindowsIdentity.GetCurrent();
                return user.Name;
            }
            catch (UnauthorizedAccessException)
            {
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
