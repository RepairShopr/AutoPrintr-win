using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using System.IO;
using PusherClient;
using Newtonsoft.Json;
using System.Net;
using Microsoft.Win32;
using System.Windows.Forms;

namespace AutoPrintr
{
    static class Jobs
    {
        static public List<Job> dnlist = new List<Job>();
        static public List<Job> printlist = new List<Job>();
        static public List<Job> donelist = new List<Job>();

        //static public Listener listener;
        static public string ev = "print-job";
        static public event EventHandler<Job> jobAdded;
        static public event EventHandler<Job> jobDownloaded;
        static public event EventHandler<Job> jobPrinted;

        public static Listener init(string channel, Action<Exception, Job> onJob)
        {
            return new Listener(channel, ev, (dynamic msg) =>
            {
                
                if (msg.type != null & msg.location != null & msg.file != null)
                {
                    //Job j = new Job(msg.type, msg.location, msg.file);
                    Job j = new Job(
                        (string)msg.type, 
                        (int)msg.location,
                        (string)msg.file,
                        (string)msg.document
                    );

                    List<string> printers = Printers.getPrinters(j.document, j.location);
                    //MessageBox.Show(
                    //    "Printers for job: " + 
                    //    "[" + printers.Count + "] " + 
                    //    printers.ToArray().ToString()
                    //);
                    if (printers.Count == 0) { 
                        return;  
                    }
                    //MessageBox.Show("Job: " + printers.ToArray().ToString());
                    j.printers = printers;

                    onJob(null, j);
                    if (jobAdded != null) { jobAdded(null, j); }
                    dnlist.Add(j);
                    j.download((err1) =>
                    {
                        //MessageBox.Show("Downloaded");
                        if (err1 == null)
                        {
                            dnlist.Remove(j);
                            printlist.Add(j);
                            if (jobDownloaded != null) { jobDownloaded(null, j); }
                            j.print((err2) =>
                            {
                                //MessageBox.Show("Printed");
                                if (err1 == null)
                                {
                                    printlist.Remove(j);
                                    donelist.Add(j);
                                    if (jobPrinted != null) { jobPrinted(null, j); }
                                }
                                else
                                {
                                    
                                }
                            });
                        }
                        else
                        {

                        }
                    });
                }
                else
                {
                    onJob(new Exception("Wrong job format. Get: " + msg.ToString()), null);
                }
                //msg
                
                //j.type = msg.type;
                //j.location = msg.location;
                //j.file = msg.file;
                //JobMsg msg = (JobMsg)obj;
                //if( )
                //Job j = new Job();
               
            });
        }


        //public class JobEvent : JobMsg
        //{
        //    public JobEvent(Job j)
        //    {
        //        this.type = j.type;
        //    }
        //}

    }



    /// <summary>
    /// Job msg class
    /// </summary>
    public class JobMsg
    {
        public string type = "";
        public int location = 0;
        public string file = "";
        public string document = "";
        public override string ToString()
        {
            return "type: '" + type +
                "', location:'" + location +
                "', file: '" + file +
                "', document: '" + document + "'"
            ;
        }
    }

    public class Job : JobMsg
    {
        public bool isPrinted = false;
        public int progress = 0;
        public long recived = 0;
        public string localFile = "";
        public string documentName = "";
        public List<string> printers;
        //public Exception err;

        public event EventHandler<Job> downloaded;
        public event EventHandler<Job> printed;

        public static string randName()
        {
            string path = Path.GetRandomFileName();
            path = path.Replace(".", ""); // Remove period.
            return path.Substring(0, 8);  // Return 8 character string
        }

        private void onDnProgress(object sender, DownloadProgressChangedEventArgs e)
        {
            progress = e.ProgressPercentage;
            recived = e.TotalBytesToReceive;
        }

        //private void onDnCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        //{
        //    if (e.Cancelled)
        //    {

        //    }
        //}

        public void download(Action<Exception> cb)
        {
            progress = 0;
            recived = 0;
            Uri url = new Uri(file);
            documentName = Path.GetFileName(url.LocalPath);
            localFile = Path.Combine(Program.tempDnDir, randName() + "_" + documentName);
            try
            {
                using (WebClient wc = new WebClient())
                {
                    wc.DownloadProgressChanged += onDnProgress;
                    wc.DownloadFileCompleted += (object sender, System.ComponentModel.AsyncCompletedEventArgs e) =>
                    {
                        if (e.Cancelled)
                        {
                            throw new Exception("Donwload was canceled");
                        }

                        if (e.Error != null)
                        {
                            throw e.Error;
                        }

                        cb(null);
                    };
                    wc.DownloadFileAsync(url, localFile);
                }
            }
            catch (Exception err)
            {
                cb(err);
            }
            
        }

        public void print(Action<Exception> cb)
        {            
            try
            {
                foreach (string printer in printers)
                {
                    //var p = Process.Start(
                    //    Registry.LocalMachine.OpenSubKey(
                    //        @"SOFTWARE\Microsoft\Windows\CurrentVersion" +
                    //        @"\App Paths\AcroRd32.exe").GetValue("").ToString(),
                    //        string.Format("/h /t \"{0}\" \"{1}\"", localFile, printer)
                    //);

                    //Process p = new Process();
                    //p.StartInfo = new ProcessStartInfo()
                    //{
                    //    CreateNoWindow = true,
                    //    Verb = "print",
                    //    FileName = localFile //put the correct path here
                    //};
                    //p.Start();

                    RawPrint.SendFileToPrinter(localFile, printer, documentName);                    
                }
                cb(null);
            }
            catch (Exception err)
            {
                cb(err);
            }
            
        }

        public Job(string type, int location, string file, string document)
        {
            this.type = type;
            this.location = location;
            this.file = file;
            this.document = document;
        }

        public Job()
        {
            this.type = null;
            this.location = 0;
            this.file = null;
            this.document = null;
        }

        public override string ToString()
        {
            return base.ToString() + ", isPrinted: " + isPrinted.ToString();
        }


    }
}
