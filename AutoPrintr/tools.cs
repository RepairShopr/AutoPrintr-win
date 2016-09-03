using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

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

        /// <summary>
        /// Get all UI controls
        /// </summary>
        /// <param name="container"></param>
        /// <returns></returns>
        public static IEnumerable<Control> GetAllControls(Control container)
        {
            List<Control> controlList = new List<Control>();
            foreach (Control c in container.Controls)
            {
                controlList.AddRange(GetAllControls(c));
                controlList.Add(c); 
            }
            return controlList;
        }

        /// <summary>
        /// Convert RGB string to color
        /// </summary>
        /// <param name="s">Hex string color</param>
        /// <returns>Color</returns>
        public static Color RGB2Color(string s){
            uint color = Convert.ToUInt32(s, 16);
            //byte A = (byte)((color >> 24) & 0xFF);
            byte R = (byte)((color >> 16) & 0xFF);
            byte G = (byte)((color >> 8) & 0xFF);
            byte B = (byte)((color) & 0xFF);
            return Color.FromArgb(R, G, B);
        }
        /// <summary>
        /// Convert color to RGB string
        /// </summary>
        /// <param name="c">Color</param> 
        /// <returns>Hex string color</returns>
        public static string Color2RGB(Color c){
            return (c.ToArgb() & 0xFFFFFF).ToString("X6");
        }

        /// <summary>
        /// Remove all fiels from directory
        /// </summary>
        /// <param name="path"></param>
        public static void DirEmpty(string path)
        {
            try
            {
                System.IO.DirectoryInfo di = new DirectoryInfo(path);
                foreach (FileInfo file in di.GetFiles())
                {
                    file.Delete();
                }
                foreach (DirectoryInfo dir in di.GetDirectories())
                {
                    dir.Delete(true);
                }
            }
            catch (Exception err)
            {
                log.Error(err, "Error while removing files from directory '" + path + "'");
            }
            
        }

        ///// <summary>
        ///// Update items sizes
        ///// </summary>
        ///// <param name="?"></param>
        //public static void TableLayoutPanelUpdateItemsSizes(TableLayoutPanel p)
        //{

        //}


    }
}
