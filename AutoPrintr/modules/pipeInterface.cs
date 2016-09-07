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
//using System.Reflection;
//using AutoPrintr;

namespace AutoPrintr
{
    static public class Pipe
    {
        private static NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();
        private static string topName = "AutoPrintr";
        private static int connectTimeout = 1000;
        static public bool isAvailable()
        {
            string r = call<string>("");
            Console.WriteLine("Ping! '{0}', {1}", r, r == null);
            return r == "pong";
        }

        static public void isAvailable(Action<bool> cb)
        {
            Task.Factory.StartNew(() => cb( call<string>("") == "pong" ) );
        }

        public static OUT call<OUT>(string pipeName, object data = null)
        {
            NamedPipeClientStream stream = new NamedPipeClientStream(topName + pipeName);
            try
            {
                stream.Connect(connectTimeout);
            }
            catch (Exception)
            {
                return default(OUT);
            }
            
            JsonSerializer serializer = new JsonSerializer();

            if (data != null) 
            {
                var streamWriter = new StreamWriter(stream, Encoding.UTF8);
                var jsonWriter = new JsonTextWriter(streamWriter);
                serializer.Serialize(jsonWriter, data);
                jsonWriter.Flush();
            }
            
            var streamReader = new StreamReader(stream, Encoding.UTF8);
            var jsonReader = new JsonTextReader(streamReader);
            OUT result = serializer.Deserialize<OUT>(jsonReader);

            stream.Close();
            return result;
        }

        public class server
        {
            public bool state = true;
            public string name;
            ulong cliendID = 0;
            Action<conn> onConn;

            public server(string pipeName, Action<conn> onConn)
            {
                this.onConn = onConn;
                this.name = pipeName;
                connect();
            }

            void connect()
            {
                NamedPipeServerStream stream = new NamedPipeServerStream(
                    topName + name,
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
            
        }

        public class conn
        {
            public ulong id;
            NamedPipeServerStream stream;

            public conn(ulong id, NamedPipeServerStream stream)
            {
                this.id = id;
                this.stream = stream;
            }

            public void send(object data)
            {
                Console.WriteLine("send <{0}>", data);
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
                JsonSerializer serializer = new JsonSerializer();
                var streamReader = new StreamReader(stream, Encoding.UTF8);
                var jsonReader = new JsonTextReader(streamReader);
                return serializer.Deserialize<T>(jsonReader);
            }
        }
    }
}
