using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.IO.Pipes;
using AutoPrintr;

namespace AutoPrintr
{
    public partial class AutoPrintrService : ServiceBase
    {
        private static NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();
        private readonly Thread workerThread = null;
        public bool state = true;
         
        void main()
        {
            //var server = new NamedPipeServerStream(PipeInterface.serverName);
            //server.WaitForConnection();
            //StreamReader reader = new StreamReader(server);
            //StreamWriter writer = new StreamWriter(server);
            //while (state)
            //{
            //    var line = reader.ReadLine();
            //    writer.WriteLine(String.Join("", line.Reverse()));
            //    writer.Flush();
            
            //    //Console.WriteLine("Work...");
            //    //log.Debug("Work...");
            //    //Thread.Sleep(1000);
            //}

            //Pipe.PrintersServer();
            Server.init();
        }

        public AutoPrintrService()
        {
            InitializeComponent();
            workerThread = new Thread(main);
            workerThread.SetApartmentState(ApartmentState.STA);
        }
        
        public void start()
        {
            //state = true;
            workerThread.Start();
            log.Info("Service is started");
            //main();
        }


        public void stop()
        {
            //state = false;
            Server.stop();
            workerThread.Abort();
            log.Info("service is stopped");
        }

        protected override void OnStart(string[] args)
        {
            start();
        }

        protected override void OnStop()
        {
            stop();
        }
    }
}
