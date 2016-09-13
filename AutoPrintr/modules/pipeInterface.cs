using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.IO.Pipes;
using Newtonsoft.Json;
using NamedPipeWrapper;
//using System.Reflection;
//using AutoPrintr;

namespace AutoPrintr
{
    static public class Pipe
    {
        private static NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();
        public static string name = "AutoPrintr";
        private static int connectTimeout = 1000;

        //static public bool isAvailable()
        //{
        //    string r = call<string>("");
        //    Console.WriteLine("Ping! '{0}', {1}", r, r == null);
        //    return r == "pong";
        //}

        //static public void isAvailable(Action<bool> cb)
        //{
        //    Task.Factory.StartNew(() => cb( call<string>("") == "pong" ) );
        //}
        static Action<List<Job>> jobsCallback;
        static Action<string> stateCallback;
        static NamedPipeClient<string> client;

        public static void clientStart(Action<List<Job>> jobsCb, Action<string> stateCb)
        {
            clientStop();
            jobsCallback = jobsCb;
            stateCallback = stateCb;
            client = new NamedPipeClient<string>(name);
            client.AutoReconnect = true;
            client.ServerMessage += client_ServerMessage;
            client.Error += client_Error;
            //delegate(NamedPipeConnection<ServerData, ServerData> conn, ServerData message)
            //{
            //    Console.WriteLine("Server says: {0}", message);
            //};

            // Start up the client asynchronously and connect to the specified server pipe.
            // This method will return immediately while the client runs in a separate background thread.
            
            client.Start();
        }

        static void client_Error(Exception exception)
        {
            log.Error(exception, "Service connection error");
        }

        static void client_ServerMessage(NamedPipeConnection<string, string> connection, string message)
        {
            Console.WriteLine("Server msg. State {0}", message);
            ServerData data = JsonConvert.DeserializeObject<ServerData>(message);
            if (jobsCallback != null)
            {
                jobsCallback(data.jobs);
            }
            if (stateCallback != null)
            {
                stateCallback(data.state);
            }
        }

        public static void clientStop()
        {
            if (client != null)
            {
                client.ServerMessage -= client_ServerMessage;
                client.Error -= client_Error;
                client.Stop();
                client = null;
            }
            jobsCallback = null;
            stateCallback = null;
        }
    }

    [Serializable]
    public class ServerData
    {
        public List<Job> jobs = new List<Job>();
        public string state = "N/A";
        public ulong job2print = 0;
    }
}
