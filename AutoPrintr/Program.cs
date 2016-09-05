using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace AutoPrintr
{
    /// <summary>
    /// Main class
    /// </summary>
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
        /// Main entry point
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
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

            if (args != null && args.Length == 1 && args[0].Length > 1
                    && (args[0][0] == '-' || args[0][0] == '/'))
            {
                switch (args[0].Substring(1).ToLower())
                {
                    case "install":
                    case "i":
                        //if (Installer.install())
                        //{
                        //    Console.WriteLine("Programm installed");
                        //}
                        //else
                        //{
                        //    Console.WriteLine("Failed to install programm");
                        //}

                        break;
                    case "uninstall":
                    case "u":
                        //if (Installer.uninstall())
                        //{
                        //    Console.WriteLine("Programm uninstalled");
                        //}
                        //else
                        //{
                        //    Console.WriteLine("Failed to uninstall programm");
                        //}

                        break;
                    default:
                        Console.WriteLine("Unrecognized parameters.\n\n    -i /i -install /install — install programm\n\n    -u /u -uninstall /uninstall — uninstall programm");
                        break;
                }
            }
            else
            {
                try
                {
                    //AppDomain.CurrentDomain.ProcessExit += (sender, e) => cpamon.stop();
                    //cpamon.run();
                }
                catch (IOException ex)
                {
                    //log.Error("", ex);
                    Console.WriteLine("IOException", ex);
                    //cpamon.stop();
                }
                catch (Exception ex)
                {
                    //log.Fatal("Could not start polling service due to unknown error", ex);
                    Console.WriteLine("Could not start programm due application error", ex);
                    //cpamon.stop();
                }
            }
        }

        static void OnProcessExit(object sender, EventArgs e)
        {
            log.Info("Removing temp files...");
            Jobs.clearFiles();
            log.Info("Application quit...");
        }
    }
}
