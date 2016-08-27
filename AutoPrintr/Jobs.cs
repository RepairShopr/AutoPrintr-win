using System;
using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Diagnostics;
//using System.Threading.Tasks;
using System.IO;
using PusherClient;
using Newtonsoft.Json;
using System.Net;
//using Microsoft.Win32;
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
                if (msg.document != null & msg.file != null & msg.type != null)
                {
                    //Job j = new Job(msg.type, msg.location, msg.file);
                    if (msg.location == null)
                    {
                        msg.location = 0;
                    }

                    Job j = new Job(                        
                        (string)msg.document,
                        (string)msg.file,
                        (int)msg.location,
                        (string)msg.type
                    );

                    j.Processing();

                    List<Printer> printers = Printers.getPrinters(j.document, j.location);
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
                                if (err2 == null)
                                {
                                    printlist.Remove(j);
                                    donelist.Add(j);
                                    if (jobPrinted != null) { jobPrinted(null, j); }
                                }
                                else
                                {
                                    //MessageBox.Show("Printing error:" + err2.ToString());
                                    j.err = err2;
                                }
                            });
                        }
                        else
                        {
                            //MessageBox.Show("Download error:" + err1.ToString());
                            j.err = err1;
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

    public enum JobState : byte
    {
        New,
        Processing,
        Downloading,
        Downloaded, 
        Printing,
        Printed,
        Error
    }

    public class Job : JobMsg
    {
        public bool isPrinted = false;
        public int progress = 0;
        public long recived = 0;
        public string localFile = "";
        public string documentName = "";
        public string documentTitle = "";
        public List<Printer> printers;
        public Exception err = null;
        public JobState state = JobState.New;
        public event EventHandler<Job> onChange;

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
            Downloading();
        }

        //private void onDnCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        //{
        //    if (e.Cancelled)
        //    {

        //    }
        //}

        public void download(Action<Exception> cb)
        {
            Downloading();

            progress = 0;
            recived = 0;
            Uri url = new Uri(file);
            //documentName = Path.GetFileName(url.LocalPath);
            localFile = Path.Combine(Program.tempDnDir, randName() + "_" + documentName);
            try
            {
                using (WebClient wc = new WebClient())
                {
                    wc.DownloadProgressChanged += onDnProgress;
                    wc.DownloadFileCompleted += (object sender, System.ComponentModel.AsyncCompletedEventArgs e) =>
                    {
                        //if (e.Cancelled)
                        //{
                        //    cb( new Exception("Donwload was canceled") );
                        //}

                        if (e.Error != null)
                        {
                            cb(e.Error); ;
                        }
                        else
                        {
                            cb(null);
                        }
                    };
                    wc.DownloadFileAsync(url, localFile);
                    Downloaded();
                }
            }
            catch (Exception err)
            {
                Error();
                cb(err);
            }
            
        }

        public void print(Action<Exception> cb)
        {
            Printing();
            try
            {
                foreach (Printer printer in printers)
                {
                    printer.print(localFile, documentName);
                }
                cb(null);
                Printed();
            }
            catch (Exception err)
            {
                cb(err);
            }
        }

        public Job(string document, string file, int location, string type)
        {
            this.document = document;
            this.file = file;
            this.type = type;
            this.location = location;
            this.documentName = Path.GetFileName(new Uri(file).LocalPath);
            this.documentTitle = PrintTypes.toTitle(document);
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


        public void Processing()
	    { 
		    state = JobState.Processing; 
		    if( onChange != null ){
                onChange(null, this);
		    }
	    }
        public void Downloading()
	    { 
		    state = JobState.Downloading; 
		    if( onChange != null ){
                onChange(null, this);
		    }
	    }
        public void Downloaded()
        {
            state = JobState.Downloaded;
            if (onChange != null)
            {
                onChange(null, this);
            }
        }
        public void Printing()
	    { 
		    state = JobState.Printing; 
		    if( onChange != null ){
                onChange(null, this);
		    }
	    }
        public void Printed()
	    { 
		    state = JobState.Printed; 
		    if( onChange != null ){
                onChange(null, this);
		    }
	    }
        public void Error()
	    { 
		    state = JobState.Error; 
		    if( onChange != null ){
                onChange(null, this);
		    }
	    }
    }
}
