using System;
using System.IO;

namespace AutoPrintr
{
    /// <summary>
    /// Various usefull tools
    /// </summary>
    public static class tools
    {
        private static NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();
        /// <summary>
        /// Log levels of NLog
        /// </summary>
        public enum logLevels : byte
        {
            Fatal, Error, Warn, Info, Debug, Trace
        };
        
        /// <summary>
        /// Convert number of bytes to formatted string
        /// </summary>
        /// <param name="byteCount"></param>
        /// <returns></returns>
        public static string BytesToString(long byteCount)
        {
            string[] suf = { "B", "KB", "MB", "GB", "TB", "PB", "EB" }; //Longs run out around EB
            if (byteCount == 0)
                return "0" + suf[0];
            long bytes = Math.Abs(byteCount);
            int place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));
            double num = Math.Round(bytes / Math.Pow(1024, place), 1);
            return (Math.Sign(byteCount) * num).ToString() + suf[place];            
        }

        /// <summary>
        /// Generate random file name
        /// </summary>
        /// <returns></returns>
        public static string randomFileName()
        {
            string path = Path.GetRandomFileName();
            path = path.Replace(".", ""); // Remove period.
            return path.Substring(0, 8);  // Return 8 character string
        }
    }

}
