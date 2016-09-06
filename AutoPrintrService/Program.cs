using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace AutoPrintr
{
    public static class Program
    {
        private static NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();

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

        ///// <summary>
        ///// Главная точка входа для приложения.
        ///// </summary>
        //static void Main()
        //{
        //    ServiceBase[] ServicesToRun;
        //    ServicesToRun = new ServiceBase[] 
        //    { 
        //        new AutoPrintrService() 
        //    };
        //    ServiceBase.Run(ServicesToRun);
        //}
        static void Main(string[] args)
        {
            //Console.WriteLine("Programm started");
            log.Info("Loading config start...");
            Program.config = new Config(err =>
            {
                log.Error(err, "Config loading error.");
            });
            log.Info("Service started");

            if (args != null && args.Length == 1 && args[0].Length > 1
                && (args[0][0] == '-' || args[0][0] == '/'))
            {
                switch (args[0].Substring(1).ToLower())
                {
                    case "install":
                    case "i":
                        if (serviceInstaller.Install())
                        {
                            Console.WriteLine("Service installed");
                            log.Info("Service installed");
                            //Log("test");
                        }
                        else
                        {
                            Console.WriteLine("Failed to install service");
                            log.Error("Failed to install service");
                        }

                        break;
                    case "uninstall":
                    case "u":
                        if (serviceInstaller.Uninstall())
                        {
                            Console.WriteLine("Service uninstalled");
                            log.Info("Service uninstalled");
                        }
                        else
                        {
                            Console.WriteLine("Failed to uninstall service");
                            log.Error("Failed to uninstall service");
                        }

                        break;
                    default:
                        Console.WriteLine("Unrecognized parameters.\n\n    -i /i -install /install — install service\n\n    -u /u -uninstall /uninstall — uninstall service");
                        log.Warn("Unrecognized parameters.\n\n    -i /i -install /install — install service\n\n    -u /u -uninstall /uninstall — uninstall service");
                        break;
                }
            }
            else
            {
                try
                {
                    //string cHost = Properties.Settings.Default.host;
                    //int cPort = Properties.Settings.Default.port;
                    //string cPath = Properties.Settings.Default.path;
                    //int loglevel = Properties.Settings.Default.loglevel;

                    //if (cHost.Length == 0) { cHost = defHost; };
                    //if (cPort == 0) { cPort = defPort; };
                    //if (cPath.Length == 0) { cPath = defPath; };
                    bool isConsole = Environment.UserInteractive;
                    var service = new AutoPrintrService();
                    var servicesToRun = new ServiceBase[] { service };

                    if (isConsole)
                    {
                        Console.OutputEncoding = Encoding.UTF8;
                        Console.CancelKeyPress += (x, y) => service.Stop();
                        try
                        {
                            service.start();
                        }
                        catch
                        {
                            Console.WriteLine("Initialization unknown error");
                            throw;
                        }

                        Console.WriteLine("Service started. Press any key to stop.");
                        Console.ReadKey();
                        //service.stop();
                        Console.WriteLine("Service stopped. Good-bye.");
                    }
                    else
                    {
                        ServiceBase.Run(servicesToRun);
                    }
                }
                catch (IOException ex)
                {
                    //log.Error("", ex);
                    Console.WriteLine("IOException", ex);
                    log.Error(ex, "IOException");
                }
                catch (Exception ex)
                {
                    //log.Fatal("Could not start polling service due to unknown error", ex);
                    Console.WriteLine("Could not start service due application error", ex);
                    log.Error(ex, "Could not start service due application error");
                }
                //catch
                //{
                //    //log.Fatal("Could not start polling service due to unknown error", ex);
                //    Console.WriteLine("Could not start service due to unknown error");
                //    log.Error("Could not start service due to unknown error");
                //}
            }
        }
    }
}
