using System;
using System.Collections.Generic;
//using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Timers;
//using System.IO;
using PusherClient;
using NLog;
//using System.Diagnostics;

namespace AutoPrintr
{
    /// <summary>
    /// Main window class
    /// </summary>
    public partial class mainWin : Form
    {
        private static NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();
       
        const string mailto = "help@repairshopr.com";
        const string subject = "Support request from AutoPrintr";
        const string userMessageTemplate = "Hi!\n\nI'm user of AutoPrintr and need help.\n<My problem is...>\n\nHere the last 100 lines of AutoPrintr log file:\n\n";
        const int lastLinesOfLog = 100;
        const int pusherReconnectDelay = 20000;
        /// <summary>
        /// List of dropdowns with registers
        /// </summary>
        List<RegisterDD> registersDD = new List<RegisterDD>();

        /// <summary>
        /// Create main window form
        /// </summary>
        public mainWin()
        {
            Printers.init();
            tools.SetAllowUnsafeHeaderParsing20();

            log.Info("GUI Initialization start...");
            InitializeComponent();

            log.Info("Loading config start...");
            Program.config = new Config(err =>
            {
                log.Error(err, "Config loading error.");
            });
            
            log.Info("Cheking update...");
            updateInit();

            log.Info("Tray icon initialization...");
            trayIconInit();

            log.Info("Configuring GUI...");
            aboutTabInit();

            this.Shown += mainWin_Shown;
            WinAutoSize.apply(this, new Control[]{printersTable, jobsTable.table});
        }
        
        void mainWin_Shown(object sender, EventArgs e)
        {
            log.Info("Login tab initialization start...");
            configTabInit();

            log.Info("Printers tab initialization start...");
            createPrintersUI();

            log.Info("Log tab initialization start...");
            logTabInit();

            log.Info("Skin initialization...");
            Skins.load();
            
            if (Program.config.locations != null)
            {
                updateLocations(Program.config.availableLocations);
            }

            log.Info("Application started...");
        }



        // -------------------------------------------------------------------
        /// <summary>
        /// Server connect
        /// </summary>
        public void srvConnect(string channel)
        {
            Console.WriteLine("srvConnect, Program.isService= {0} ", Program.isService);
            log.Info("Connecting to jobs server...");
            if (Program.isService)
            {
                srvConnectService(channel);
            }
            else
            {
                srvConnectLocal(channel);
            }
        }

        public void srvConnectLocal(string channel)
        {
            log.Info("Connecting to jobs server...");
            List<Listener> msgWrokers = new List<Listener> {
                Jobs.init(channel,  (ex, job, msg) =>
                {
                    log.Info("New print job event. Job is: {0}", job);
                    jobsTable.add(job);
                })
            };

            Action<PusherException> onError = (err) =>
            {
                log.Error("Pusher error: {0}", err);
            };

            Action<String> onStateChanged = (state) =>
            {
                Invoke(new setStatusCb(this.setStatus), new object[] { state });
                log.Info("Pusher state changed to: {0}", state);
                switch (state)
                {
                    case "disconnected":
                        log.Warn("Pusher state is disconnected");
                        break;
                    case "unavailable":
                        Thread.Sleep(pusherReconnectDelay);
                        srvConnect(channel);
                        log.Warn("Pusher state is unavailable. Reconnecting in {0} seconds.", pusherReconnectDelay / 1000);
                        break;
                    default:
                        break;
                }
            };
            JobsServer.connect(msgWrokers, onError, onStateChanged);
        }

        public System.Timers.Timer srvDataTimer = null;

        public void srvConnectService(string channel)
        {
            Console.WriteLine( "Server state: " + Pipe.call<string>("JobsServerState") );
            if (srvDataTimer != null)
            {
                srvDataTimer.Stop();
                srvDataTimer.Dispose();
                srvDataTimer = null;
            }

            srvDataTimer = new System.Timers.Timer(1000.0);
            srvDataTimer.Elapsed += new ElapsedEventHandler(timerHandler);
            srvDataTimer.Start();            
            Invoke(new setStatusCb(this.setStatus), new object[] { Pipe.call<ConnectionState>("JobsServerState").ToString() });
        }

        Dictionary<ulong, Job> jobs = new Dictionary<ulong, Job>();
        
        void timerHandler ( object sender, ElapsedEventArgs e){
            // Jobs processing
            getJobs();
            getStatus();
            //
            //
        }

        void getJobs()
        {
            List<Job> jobsUpdate = Pipe.call<List<Job>>("Jobs");
            Console.WriteLine("Jobs: {0}", jobsUpdate.Count);
            Job job;
            foreach (Job j in jobsUpdate)
            {
                if (jobs.TryGetValue(j.id, out job))
                {
                    jobsTable.update(job);
                }
                else
                {
                    Console.WriteLine("New print job event. Job is: '{0}'", job);
                    log.Info("New print job event. Job is: {0}", job);
                    jobsTable.add(job);
                    jobs.Add(j.id, j);
                }
            }
        }

        void getStatus()
        {
            // Status processing
            ConnectionState state = Pipe.call<ConnectionState>("JobsServerState");
            if (state != JobsServer.state )
            {
                JobsServer.state = state;
                Invoke(new setStatusCb(this.setStatus), new object[] { state.ToString() });
            }
        }

    }
}
