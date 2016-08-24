using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoPrintr
{
    public static class Program
    {
        public static mainWin window;
        public static Config config;

        /// <summary>
        /// Main entry point
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Program.window = new mainWin();
            Application.Run(Program.window);
        }
    }
}
