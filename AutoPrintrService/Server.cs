using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using PusherClient;
using Newtonsoft.Json;
using NamedPipeWrapper;
using System.Timers;
using System.IO;

namespace AutoPrintr
{
    public static class Server
    {
        private static NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();
        
        const int pusherReconnectDelay = 20000;
        const int jobsMax = 100;
        public static JobsList jobs = new JobsList(jobsMax);

        public static ServerData data = new ServerData();
        static NamedPipeServer<string> server;

        static bool updateRequired = false;
        static System.Timers.Timer msgTimer = new System.Timers.Timer();

        public static void init()
        {
            Printers.init();
            log.Info("Loading config start...");
            Program.config = new Config(err =>
            {
                log.Error(err, "Config loading error.");
            });

            //pingPongPipe();
            //printers();
            //jobsList();
            //jobPrint();
            //ConfigReload();
            //JobsServerState();

            server = new NamedPipeServer<string>(Pipe.name);
            server.ClientConnected += server_ClientConnected;
            server.ClientMessage += server_ClientMessage;
            server.ClientDisconnected += server_ClientDisconnected;
            server.Error += server_Error;
            server.Start();

            if (Program.config.channel.Length != 0)
            {
                srvConnect(Program.config.channel);
            }

            msgTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            msgTimer.Interval = 100;
            msgTimer.Enabled = true;

            configWatch();
        }


        public static void stop()
        {
            msgTimer.Elapsed -= OnTimedEvent;
            msgTimer.Stop();
            server.Stop();
            server = null;
            watcherStop();
        }

        /// <summary>
        /// Limit frequency of requests to 10/sec
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            //Console.WriteLine("Hello World!");
            if (updateRequired)
            {
                pushData();
                updateRequired = false;
            }
        }

        static void pushData()
        {
            if (server != null && server._connections != null)
            {
                foreach (var conn in server._connections)
                {
                    Console.WriteLine("data is pushing to conn {0}", conn.Id);
                    conn.PushMessage( JsonConvert.SerializeObject(data) );
                    Console.WriteLine("data is pushed to conn {0}", conn.Id);
                }
            }
        }

        static void server_Error(Exception exception)
        {
            log.Error(exception, "Service pipe server error");
        }

        static void server_ClientMessage(NamedPipeConnection<string, string> connection, string message)
        {
            Console.WriteLine("Client {0} says: {1}", connection.Id, message);
            //if (message.job2print != 0)
            //{
            //    jobs.print(message.job2print);
            //}
        }

        static void server_ClientConnected(NamedPipeConnection<string, string> connection)
        {
            Console.WriteLine("Client {0} is now connected!", connection.Id);
            connection.PushMessage(JsonConvert.SerializeObject(data));
            Console.WriteLine("    data is pushed for conn {0}", connection.Id);
        }

        static void server_ClientDisconnected(NamedPipeConnection<string, string> connection)
        {
            //throw new NotImplementedException();
            Console.WriteLine("Client {0} Disconnected", connection.Id);
        }

        public class JobsList
        {
            public Queue<Job> items = new Queue<Job>();
            public int CountMax = 0;
            ulong jobsCnt = 0;
            public JobsList(int count)
            {
                CountMax = count;
            }

            public void Add(Job job)
            {
                if (items.Count == CountMax)
                {
                    Job oldJob = items.Dequeue();
                    oldJob.onChange -= job_onChange;
                    oldJob.Dispose();
                }
                job.id = jobsCnt++;
                job.printerName = job.printer.name;
                items.Enqueue(job);
                data.jobs = items.ToList();
            }

            public List<Job> ToList()
            {
                return items.ToList();
            }

            public void print(ulong id)
            {
                foreach (Job j in items)
                {
                    if (j.id == id)
                    {
                        j.print((ex) =>
                        {
                            if (ex != null)
                            {
                                log.Error(ex, "Job printing error");
                            }
                        });
                    }
                }
            }
        }        

        // -------------------------------------------------------------------
        /// <summary>
        /// Connect to jobs server
        /// </summary>
        public static void srvConnect(string channel)
        {
            log.Info("Connecting to jobs server...");
            List<Listener> msgWrokers = new List<Listener> {
                Jobs.init(channel,  (ex, job) =>
                {
                    log.Info("New print job event. Job is: {0}", job);
                    //jobsTable.add(job);
                    jobs.Add(job);
                    job.onChange += job_onChange;
                    //pushData();
                    updateRequired = true;
                })
            };

            Action<PusherException> onError = (err) =>
            {
                log.Error("Pusher error: {0}", err);
            };

            Action<String> onStateChanged = (state) =>
            {
                //Invoke(new setStatusCb(this.setStatus), new object[] { state });
                log.Info("Pusher state changed to: {0}", state);

                data.state = state;
                updateRequired = true;

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

            try
            {
                JobsServer.connect(msgWrokers, onError, onStateChanged);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Error while connecting to pusher");
            }
            
        }

        static void job_onChange(object sender, Job e)
        {
            //pushData();
            updateRequired = true;
        }


        /// <summary>
        /// Log file name, shall be same as in NLog.config
        /// </summary>
        static string file = Config.file;
        static FileSystemWatcher watcher = null;
        static FileSystemEventHandler h1;
        static FileSystemEventHandler h2;
        static FileSystemEventHandler h3;
        public static void configWatch()
        {
            // Create a new FileSystemWatcher and set its properties.
            watcher = new FileSystemWatcher();
            watcher.Path = Program.localPath;
            /* Watch for changes in LastAccess and LastWrite times, and 
                the renaming of files or directories. */
            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite;
            // Only watch text files.
            watcher.Filter = file;

            // Add event handlers.
            h1 = new FileSystemEventHandler(OnChanged);
            h2 = new FileSystemEventHandler(OnChanged);
            h3 = new FileSystemEventHandler(OnChanged);

            watcher.Changed += h1;
            watcher.Created += h2;
            watcher.Deleted += h3;
            //watcher.Renamed += new RenamedEventHandler(OnRenamed);

            // Begin watching.
            watcher.EnableRaisingEvents = true;
            //watcher.
        }

        static void watcherStop()
        {
            if (watcher != null)
            {
                watcher.EnableRaisingEvents = false;
                watcher.Changed -= h1;
                watcher.Created -= h2;
                watcher.Deleted -= h3;
                watcher.Dispose();
                watcher = null;
            }
        }

        // Define the event handlers.
        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            log.Info("Config is changed");
            Program.config.load();
        }
        
    }
}
