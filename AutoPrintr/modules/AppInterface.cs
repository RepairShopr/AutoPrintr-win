using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Net;
using System.Net.Sockets;

//using System.IO.Pipes;
//using NamedPipeWrapper;


namespace AutoPrintr
{
    static public class AppInterface
    {
        private static NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();

        public static int appServerPort = 10200;
        
        //public static void init()
        //{
        //    if (User.IsSystem()) {
        //        PrintersServer();
        //    }
        //    else
        //    {
        //        PrintersClient();
        //    }
        //}

        [Serializable]
        class Msg
        {
            public int Id;
            public string Text;

            public override string ToString()
            {
                return string.Format("\"{0}\" (message ID = {1})", Text, Id);
            }
        }

        public static void PrintersServer()
        {
            appServer<string, string> srv = new appServer<string, string>(
                appServerPort, 
                (Action<appServer<string, string>.conn>)( (cn) => {
                    Console.WriteLine("New connection: {0}", cn.id);
                    while (true)
                    {
                        Console.WriteLine("Msg: {0}", cn.read<string>());
                        cn.send<string>("response");
                        //while (cn.client.Available == 0)
                        //{
                        //    Thread.Sleep(5);
                        //}
                    }
                })
            );
            
            // ---------------------------
            //var server = new NamedPipeServer<string>(PrintersPipeName);
            //server.ClientConnected += delegate(NamedPipeConnection<string, string> conn)
            //    {
            //        Console.WriteLine("Client {0} is now connected!", conn.Id);
            //        conn.PushMessage("Welcome!");
            //    };
            //server.ClientMessage += delegate(NamedPipeConnection<string, string> conn, string message)
            //    {
            //        Console.WriteLine("Client {0} says: {1}", conn.Id, message);
            //    };
            //server.Start();

            // ---------------------------
            //var server = new NamedPipeServerStream(PrintersPipeName);
            //StreamReader reader;
            //StreamWriter writer;

            //Console.WriteLine("WaitForConnection()");
            //server.WaitForConnection();
            //Console.WriteLine("Connected");
            //reader = new StreamReader(server);
            //writer = new StreamWriter(server);
            //while (true)
            //{
            //    Console.WriteLine("Read start...");
            //    var line = reader.ReadLine();
            //    if (String.IsNullOrEmpty(line)) break;
            //    Console.WriteLine("Read end: " + line);
            //    writer.WriteLine(String.Join("", line.Reverse()));
            //    writer.Flush();
            //    //Console.WriteLine("Work...");
            //    //log.Debug("Work...");
            //    Thread.Sleep(1000);
            //}
        }


        public static void PrintersClient(Action<List<string>, List<string>> cb = null)
        {
            appClient<string, string> client = new appClient<string, string>(appServerPort);
            Console.WriteLine("Server respone 1: {0}", client.send("Test 1"));
            Console.WriteLine("sended");
            Console.WriteLine("Server respone 2: {0}", client.send("Test 2"));

            // ---------------------------
            //var client = new NamedPipeClient<string>(PrintersServerName);
            //client.ServerMessage += delegate(NamedPipeConnection<string, string> conn, string message)
            //{
            //    Console.WriteLine("Server says: {0}", message);
            //    conn.PushMessage("Client msg!");
            //};
            //client.Start();
            // ---------------------------
            //var client = new NamedPipeClientStream(PrintersPipeName);
            //client.Connect();
            //StreamReader reader = new StreamReader(client);
            //StreamWriter writer = new StreamWriter(client);

            //while (true)
            //{
            //    writer.WriteLine("Client message");
            //    writer.Flush();
            //    Console.WriteLine("Server answer: " + reader.ReadLine());
            //}
        }


        public class appClient<In, Out> 
            where In : class 
            where Out : class
        {
            public TcpClient client;
            public NetworkStream stream;
            //StreamReader reader;
            //StreamWriter writer;
            IFormatter formatter;

            public appClient(int port)
            {
                formatter = new BinaryFormatter();
                client = new TcpClient("127.0.0.1", port);
                stream = client.GetStream();
                //reader = new StreamReader(stream);
                //writer = new StreamWriter(stream);
            }

            public Out send(In msg)
            {
                formatter.Serialize(stream, msg);
                //stream.Flush();
                //stream.WaitForPipeDrain();
                return (Out)formatter.Deserialize(stream);
            }
        }


        public class appServer<In, Out>
            where In : class
            where Out : class
        {
            public TcpListener Listener; 
            public bool state = true;
            //NamedPipeServerStream stream;
            ulong cliendID = 0;
            Action<conn> onConn;

            public appServer(int port, Action<conn> onConn)
            {
                this.onConn = onConn;
                //stream = new NamedPipeServerStream(PrintersPipeName);                
                //stream.WaitForConnection();
                //while (state)
                //{
                //onConn(new conn(cliendID++, this));
                //}
                //connect();

                int MaxThreadsCount = Environment.ProcessorCount * 4;
                ThreadPool.SetMaxThreads(MaxThreadsCount, MaxThreadsCount);
                ThreadPool.SetMinThreads(2, 2);
                Listener = new TcpListener(IPAddress.Any, port);
                Listener.Start();
                while (state)
                {
                    ThreadPool.QueueUserWorkItem(new WaitCallback(ClientThread), Listener.AcceptTcpClient());
                }
            }

            void ClientThread(Object StateInfo)
            {
                // Просто создаем новый экземпляр класса Client и передаем ему приведенный к классу TcpClient объект StateInfo
                onConn( new conn(cliendID++, (TcpClient)StateInfo) );
            }

            //void connect()
            //{
            //    NamedPipeServerStream stream = new NamedPipeServerStream(
            //        PrintersPipeName,
            //        PipeDirection.InOut,
            //        10,
            //        PipeTransmissionMode.Byte,
            //        PipeOptions.Asynchronous
            //     );
            //    stream.BeginWaitForConnection(
            //        new AsyncCallback(WaitForConnectionCallBack)
            //        , stream
            //    );
            //}

            //private void WaitForConnectionCallBack(IAsyncResult iar)
            //{
            //    NamedPipeServerStream stream = (NamedPipeServerStream)iar.AsyncState;
            //    stream.EndWaitForConnection(iar);
            //    onConn(new conn(cliendID++, stream));
            //    stream.Close();
            //    stream = null;                
            //    connect();
            //}
   
            public class conn
            {
                public ulong id;
                public TcpClient client;
                public NetworkStream stream;
                StreamReader reader;
                StreamWriter writer;                
                IFormatter formatter;

                public conn(ulong id, TcpClient client)
                {
                    this.id = id;
                    stream = client.GetStream();
                    formatter = new BinaryFormatter();
                    reader = new StreamReader(stream);
                    writer = new StreamWriter(stream);
                }

                public void send<T>(T msg)
                {
                    formatter.Serialize(stream, msg);
                    stream.Flush();
                }

                public T read<T>()
                {
                    return (T)formatter.Deserialize(stream);
                }
            }
        }
    }
}
