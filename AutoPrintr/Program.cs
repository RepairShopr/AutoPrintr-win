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
        public static string tempDir = Path.Combine(
            Environment.GetEnvironmentVariable("TEMP", EnvironmentVariableTarget.Machine)
            , "AutoPrintr"
        );

        /// <summary>
        /// Temporary directory for fiels download
        /// </summary>
        public static string tempDnDir = Path.Combine(tempDir, "dn");

        /// <summary>
        /// Application start log marker
        /// </summary>
        public const string appInitString = "/       === Application initialization... ===       /";

        /// <summary>
        /// Is service mode
        /// </summary>
        public static bool isService = false;

        /// <summary>
        /// Path to home directory
        /// </summary>
        public static string localPath = AppDomain.CurrentDomain.BaseDirectory;

        /// <summary>
        /// Silent mode for start with tray icon only
        /// </summary>
        public static bool isSilent = false;

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

            //Console.WriteLine("Pipe.isAvailable: = {0}", Pipe.isAvailable());
            //Pipe.PrintersClient();

            //Console.WriteLine("Pipe.isAvailable 1");
            //Pipe.isAvailable((f) => Console.WriteLine("Pipe.isAvailable result: {0}", f));
            //Console.WriteLine("Pipe.isAvailable 2");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit);

            if (args != null && args.Length == 1 && args[0].Length > 1
                    && (args[0][0] == '-' || args[0][0] == '/'))
            {
                //MessageBox.Show(args.Length.ToString() + " " + args[0].Substring(1).ToLower());
                switch (args[0].Substring(1).ToLower())
                {
                    case "silent":
                    case "s":
                        //MessageBox.Show("silent");
                        Program.isSilent = true;
                        break;
                    default:
                        Console.WriteLine("Unrecognized parameters.\n\n    -s /s -silent /silent — start minimized with tray icon");
                        return;
                }
            }            

            Program.window = new mainWin();
            Application.Run(Program.window);

            //else
            //{
            //    try
            //    {
            //        //AppDomain.CurrentDomain.ProcessExit += (sender, e) => cpamon.stop();
            //        //cpamon.run();
            //    }
            //    catch (IOException ex)
            //    {
            //        //log.Error("", ex);
            //        Console.WriteLine("IOException", ex);
            //        //cpamon.stop();
            //    }
            //    catch (Exception ex)
            //    {
            //        //log.Fatal("Could not start polling service due to unknown error", ex);
            //        Console.WriteLine("Could not start programm due application error", ex);
            //        //cpamon.stop();
            //    } 
            //}
        }

        static void OnProcessExit(object sender, EventArgs e)
        {
            log.Info("Removing temp files...");
            Jobs.clearFiles();
            log.Info("Application quit...");
        }
    }
}
