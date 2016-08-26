using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace AutoPrintr
{
    public static class Program
    {
        public static mainWin window;
        public static Config config;
        public static string tempDir = Path.Combine(Path.GetTempPath(), "AutoPrintr");
        public static string tempDnDir = Path.Combine(tempDir, "dn");
        /// <summary>
        /// Main entry point
        /// </summary>
        [STAThread]
        static void Main()
        {
            Directory.CreateDirectory(tempDir);
            Directory.CreateDirectory(tempDnDir);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Program.window = new mainWin();
            Application.Run(Program.window);
        }
    }
}
