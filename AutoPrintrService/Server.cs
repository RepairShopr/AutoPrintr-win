using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using PusherClient;

namespace AutoPrintr
{
    public static class Server
    {
        private static NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();

        public static void init()
        {
            Printers.init();
            log.Info("Loading config start...");
            Program.config = new Config(err =>
            {
                log.Error(err, "Config loading error.");
            });

            pingPongPipe();
            printers();
            jobsList();
            jobPrint();
            ConfigReload();
            JobsServerState();

            if (Program.config.channel.Length != 0)
            {
                srvConnect(Program.config.channel);
            }
        }

        const int pusherReconnectDelay = 20000;
        const int jobsMax = 100;

        public static JobsList jobs = new JobsList(jobsMax);
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
                    items.Dequeue();
                }
                job.id = jobsCnt++;
                items.Enqueue(job);                
            }

            public List<Job> ToList()
            {
                return items.ToList();
            }

            public void print(ulong id)
            {

            }
        }
        

        static void pingPongPipe()
        {
            new Pipe.server(
                "",
                (Action<Pipe.conn>)((cn) =>
                {
                    Console.WriteLine("ping");
                    cn.send("pong");
                })
            );
        }

        static void printers(){
            new Pipe.server(
                "PrintersGet",
                (Action<Pipe.conn>)((cn) =>
                {
                    //cn.read<string>();
                    Console.WriteLine("PrintersGet");
                    cn.send(Printers.get().Select(p => p.name).ToList());
                })
            );
        }
        
        static void jobsList(){
            new Pipe.server(
                "Jobs",
                (Action<Pipe.conn>)((cn) =>
                {
                    //cn.read<string>();
                    Console.WriteLine(jobs.ToList());
                    cn.send(jobs.ToList());
                })
            );
        }

        static void jobPrint()
        {
            new Pipe.server(
                "JobPrint",
                (Action<Pipe.conn>)((cn) =>
                {
                    Console.WriteLine("JobPrint");
                    jobs.print(cn.read<ulong>());
                    cn.send(true);
                })
            );
        }

        static void ConfigReload()
        {
            new Pipe.server(
                "ConfigReload",
                (Action<Pipe.conn>)((cn) =>
                {
                    Console.WriteLine("PrintersGet");
                    Program.config.load();
                    cn.send(true);
                })
            );
        }

        static void JobsServerState()
        {
            new Pipe.server(
                "JobsServerState",
                (Action<Pipe.conn>)((cn) =>
                {
                    //Console.WriteLine("JobsServerState");
                    cn.send(JobsServer.state.ToString());
                })
            );
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
        
    }
}
