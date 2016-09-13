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
using NamedPipeWrapper;

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
            if (Program.isSilent)
            {
                trayIconState(true);
            } else {
                this.ShowInTaskbar = true;
                trayIconState(false);
            }
        }



        // -------------------------------------------------------------------
        /// <summary>
        /// Server connect
        /// </summary>
        public void srvConnect(string channel)
        {
            //Console.WriteLine("srvConnect, Program.isService= {0} ", Program.isService);
            
            if (Program.isService)
            {
                JobsServer.disconnect();
                log.Info("Connecting to jobs server via service...");
                srvConnectService(channel);
            }
            else
            {
                Pipe.clientStop();
                log.Info("Connecting to jobs server directly...");
                srvConnectLocal(channel);
            }
        }

        public void srvConnectLocal(string channel)
        {
            log.Info("Connecting to jobs server...");
            List<Listener> msgWrokers = new List<Listener> {
                Jobs.init(channel,  (ex, job) =>
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

        //public System.Timers.Timer srvDataTimer = null;

        public void srvConnectService(string channel)
        {
            Pipe.clientStart(setJobs, setState);
        }

        Dictionary<ulong, Job> jobs = new Dictionary<ulong, Job>();
        
        bool jobsIsProcessing = false;
        void setJobs(List<Job> newJobs)
        {
            //Console.WriteLine("Jobs() {0}", jobsIsProcessing);

            if (jobsIsProcessing) { return; }
            jobsIsProcessing = true; // WindowsForms UI generating - is veeery slow :(

            //Console.WriteLine("Jobs() 1");
            //List<Job> jobsUpdate = Pipe.call<List<Job>>("Jobs");
            //Console.WriteLine("Jobs() 2 {0} | {1}", jobsUpdate.Count, jobsUpdate);

            //Console.WriteLine("Jobs: {0}", jobsUpdate.Count);

            Job existingJob;
            foreach (Job j in newJobs)
            {
                j.init();
                if (jobs.TryGetValue(j.id, out existingJob))
                {
                    jobsTable.update(j);
                }
                else
                {
                    //Console.WriteLine("New print job event. Job is: '{0}'", job.ToString());
                    Console.WriteLine("    j id {0}", j.id.ToString());
                    log.Info("New print job event. Job is: {0}", j);
                    jobs.Add(j.id, j);
                    jobsTable.add(j);
                }
            }

            jobsIsProcessing = false;
        }

        void setState(string state)
        {
            // Status processing
            //ConnectionState state = Pipe.call<ConnectionState>("JobsServerState");
            Invoke(new setStatusCb(this.setStatus), new object[] { state });
        }

    }
}
