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
        private static NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Main applciation window
        /// </summary>
        public static mainWin window;
        /// <summary>
        /// Application configuration
        /// </summary>
        public static Config config;
        /// <summary>
        /// Temporary directory
        /// </summary>
        public static string tempDir = Path.Combine(Path.GetTempPath(), "AutoPrintr");
        /// <summary>
        /// Temporary directory for fiels download
        /// </summary>
        public static string tempDnDir = Path.Combine(tempDir, "dn");

        /// <summary>
        /// Application start log marker
        /// </summary>
        public const string appInitString = "/       === Application initialization... ===       /";

        /// <summary>
        /// Application version
        /// </summary>
        public static string version;
        /// <summary>
        /// Main entry point
        /// </summary>
        [STAThread]
        static void Main()
        {
            Version v = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            Program.version = String.Format("{0}.{1}.{2}", v.Major, v.Minor, v.Build);

            log.Info("/***************************************************/");
            log.Info("/                                                   /");
            log.Info(appInitString);
            log.Info("/                                                   /");
            log.Info("/***************************************************/");
            Directory.CreateDirectory(tempDir);
            Directory.CreateDirectory(tempDnDir);
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit); 
            
            Program.window = new mainWin();
            Application.Run(Program.window);
        }
        static void OnProcessExit(object sender, EventArgs e)
        {
            log.Info("Removing temp files...");
            Jobs.clearFiles();
            log.Info("Application quit...");
        }
    }
}
