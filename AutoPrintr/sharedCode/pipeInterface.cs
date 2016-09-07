using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.IO.Pipes;
using Newtonsoft.Json;
//using System.Reflection;
//using AutoPrintr;



namespace AutoPrintr
{
    static public class Pipe
    {
        private static NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();

        public static string PrintersPipeName = "AutoPrintr.Printers";
        
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
            Printers.init();
            pipeServer srv = new pipeServer(
                PrintersPipeName, 
                (Action<pipeServer.conn>)( (cn) => {
                    Console.WriteLine("New connection: {0}", cn.id);
                    Console.WriteLine("Msg: {0}", cn.read<string>());
                    cn.send( Printers.get().Select(p => p.name).ToList() );
                    //cn.send(new Msg() { Text = "msg text", Id = 123 });
                    //cn.send("msg text");
                })
            );
        }


        public static void PrintersClient()
        {
            //pipeClient<string, string> client = new pipeClient<string, string>(PrintersPipeName);
            //Console.WriteLine("Server respone 1: {0}", client.send("Test 1"));
            //Console.WriteLine("Server respone 2: {0}", client.send("Test 2"));
            Console.WriteLine("PrintersClient");
            //Console.WriteLine("Server respone: {0}", call<Msg>(PrintersPipeName, "Test"));
            //Console.WriteLine("Server respone: {0}", call<List<string>>(PrintersPipeName, ""));

            Console.WriteLine(
                "Printers: {0}",
                String.Join(", ", call<List<string>>(PrintersPipeName, ""))
            );
            //call<string, string>("Printers.get", "12345");
        }

        public static OUT call<OUT>(string pipeName, object data)
        {
            NamedPipeClientStream stream = new NamedPipeClientStream(pipeName);
            stream.Connect();
            
            JsonSerializer serializer = new JsonSerializer();

            var streamWriter = new StreamWriter(stream, Encoding.UTF8);
            var jsonWriter = new JsonTextWriter(streamWriter);
            serializer.Serialize(jsonWriter, data);
            jsonWriter.Flush();

            var streamReader = new StreamReader(stream, Encoding.UTF8);
            var jsonReader = new JsonTextReader(streamReader);
            OUT result = serializer.Deserialize<OUT>(jsonReader);

            //JsonConvert.SerializeObject( data )
            //JsonConvert.DeserializeObject<Settings>( data)
            //stream.Write(JsonConvert.SerializeObject(data));
            
            stream.Close();
            return result;
        }

        //public class pipeClient<In, Out> 
        //    where In : class 
        //    where Out : class
        //{
        //    NamedPipeClientStream stream;
        //    //StreamReader reader;
        //    //StreamWriter writer;
        //    IFormatter formatter;

        //    public pipeClient(string pipeName)
        //    {
        //        stream = new NamedPipeClientStream(pipeName);
        //        stream.Connect();
        //        //StreamReader reader = new StreamReader(stream);
        //        //StreamWriter writer = new StreamWriter(stream);
        //        formatter = new BinaryFormatter();                
        //    }

        //    public Out send(In msg)
        //    {
        //        //f.Serialize(cs, messageToSend);
        //        formatter.Serialize(stream, msg);
        //        //stream.WaitForPipeDrain();
        //        return (Out)formatter.Deserialize(stream);
        //    }
        //}


        public class pipeServer
        {
            public bool state = true;
            //NamedPipeServerStream stream;
            ulong cliendID = 0;
            Action<conn> onConn;

            public pipeServer(string pipeName, Action<conn> onConn)
            {
                this.onConn = onConn;
                //stream = new NamedPipeServerStream(PrintersPipeName);                
                //stream.WaitForConnection();
                //while (state)
                //{
                //onConn(new conn(cliendID++, this));
                //}
                connect();
            }

            void connect()
            {
                NamedPipeServerStream stream = new NamedPipeServerStream(
                    PrintersPipeName,
                    PipeDirection.InOut,
                    10,
                    PipeTransmissionMode.Byte,
                    PipeOptions.Asynchronous
                 );
                stream.BeginWaitForConnection(
                    new AsyncCallback(WaitForConnectionCallBack)
                    , stream
                );
            }

            private void WaitForConnectionCallBack(IAsyncResult iar)
            { 
                NamedPipeServerStream stream = (NamedPipeServerStream)iar.AsyncState;
                stream.EndWaitForConnection(iar);
                onConn(new conn(cliendID++, stream));
                stream.Close();
                stream = null;                
                connect();
            }
   
            public class conn
            {
                public ulong id;
                NamedPipeServerStream stream;
                StreamReader reader;
                StreamWriter writer;
                BinaryFormatter formatter;

                public conn(ulong id, NamedPipeServerStream stream)
                {
                    this.id = id;
                    this.stream = stream;
                    //formatter = new BinaryFormatter();
                    //formatter.AssemblyFormat = System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Simple;

                    //reader = new StreamReader(serverStream);
                    //writer = new StreamWriter(serverStream);
                }

                public void send(object data)
                {
                    //formatter.Serialize(serverStream, msg);
                    //serverStream.Flush();
                    JsonSerializer serializer = new JsonSerializer();

                    var streamWriter = new StreamWriter(stream, Encoding.UTF8);
                    var jsonWriter = new JsonTextWriter(streamWriter);
                    serializer.Serialize(jsonWriter, data);
                    jsonWriter.Flush();
                }

                //public void send<T>(T data)
                //{
                //    //formatter.Serialize(stream, msg);
                //    //serverStream.Flush();
                //    JsonSerializer serializer = new JsonSerializer();

                //    var streamWriter = new StreamWriter(stream, Encoding.UTF8);
                //    var jsonWriter = new JsonTextWriter(streamWriter);
                //    serializer.Serialize(jsonWriter, data);
                //}

                public T read<T>()
                {
                    //return (T)formatter.Deserialize(stream);
                    JsonSerializer serializer = new JsonSerializer();

                    var streamReader = new StreamReader(stream, Encoding.UTF8);
                    var jsonReader = new JsonTextReader(streamReader);
                    return serializer.Deserialize<T>(jsonReader);
                }
            }
        }

    }
}
