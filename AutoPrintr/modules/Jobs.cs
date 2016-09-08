using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
//using System.Windows.Forms;

namespace AutoPrintr
{
    /// <summary>
    /// General jobs actions
    /// </summary>
    static class Jobs
    {
        private static NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Jobs list
        /// </summary>
        //static public List<Job> list = new List<Job>();

        /// <summary>
        /// Constant with new print job event name from Pusher
        /// </summary>
        public const string newJobEvent = "print-job";

        /// <summary>
        /// Jobs events
        /// </summary>
        static public event EventHandler<Job> jobAdded;
        static public event EventHandler<Job> jobDownloaded;
        static public event EventHandler<Job> jobPrinted;

        /// <summary>
        /// Pusher msg validation
        /// </summary>
        /// <param name="msg">parsed msg object from pusher</param>
        /// <returns></returns>
        static bool msgValidate(dynamic msg)
        {            
            JToken message = (JToken)msg;
            JToken document = message["document"];
            JToken file = message["file"];
            JToken type = message["type"];
            JToken location = message["location"];
            JToken autoprinted = message["autoprinted"];
            JToken register = message["register"];
            
            // Check for null
            if(
                document == null |
                file == null |
                type == null
            ) {
                log.Error("Pusher msg validation not passed: one of the properties is null. \"document\": {0}, \"file\": {1}, \"type\": {2}", document, file, type);
                return false; 
            }
            
            // Location can be null
            if (msg.location == null) 
            {
                msg.location = 0;
            }

            if (document.Type != JTokenType.String)
            {
                log.Error("Pusher msg validation not passed: \"document\" type isnt string. Type: {0}", document.Type);
                return false;
            }

            if (file.Type != JTokenType.String)
            {
                log.Error("Pusher msg validation not passed: \"file\" type isnt string. Type: {0}", file.Type);
                return false;
            }

            if (type.Type != JTokenType.String)
            {
                log.Error("Pusher msg validation not passed: \"type\" type isnt string. Type: {0}", type.Type);
                return false;
            }

            if (autoprinted.Type == JTokenType.Null)
            {
                msg.autoprinted = false;
            }

            if (register.Type == JTokenType.Null)
            {
                msg.register = 0;
            }
            return true;
        }

        /// <summary>
        /// Job listener
        /// </summary>
        /// <param name="channel"></param>
        /// <param name="onJob"></param>
        /// <returns></returns>
        public static Listener init(string channel, Action<Exception, Job> onJob)
        {
            return new Listener(channel, newJobEvent, (dynamic msg) =>
            {
                // Msg validation
                if (msgValidate(msg))
                {
                    // Searching printers for this job
                    List<Printer> printers = Printers.findPrinters((string)msg.document, (int)msg.location, (int)msg.register);
                    if (printers.Count == 0) {
                        log.Info("Skipped job: document: {0}, file: {1}, location: {2}, type: {3}, autoprinted: {4}, register: {5}", 
                            (string)msg.document,
                            (string)msg.file,
                            (int)msg.location,
                            (string)msg.type,
                            (bool)msg.autoprinted,
                            (int)msg.register
                        );
                        return;
                    }

                    foreach (Printer printer in printers)
                    {
                        // Job cration
                        Job job = new Job(
                            (string)msg.document,
                            (string)msg.file,
                            (int)msg.location,
                            (string)msg.type,
                            (bool)msg.autoprinted,
                            (int)msg.register
                        );

                        job.Processing();

                        // Setting job printers
                        job.printer = printer;

                        // New job callback (not sure if it corret and better via event)
                        onJob(null, job);

                        // New job event 
                        if (jobAdded != null) { jobAdded(null, job); }

                        job.download((err1) =>
                        {
                            if (err1 == null)
                            {
                                if (jobDownloaded != null) { jobDownloaded(null, job); }
                                job.print((err2) =>
                                {
                                    if (err2 == null)
                                    {
                                        if (jobPrinted != null) { jobPrinted(null, job); }
                                    }
                                    else
                                    {
                                        job.err = err2;
                                        log.Error("File printing error. File: \"{0}\"; Error details:\n{1}", job.localFilePath, err2);
                                    }
                                });
                            }
                            else
                            {
                                job.err = err1;
                                log.Error("File download error. File: \"{0}\"; Error details:\n{1}", job.file, err1);
                            }
                        });
                    }
                }
                else
                {
                    onJob(new Exception("Wrong job format. Get: " + msg.ToString()), null);
                }
            });
        }

        ///// <summary>
        ///// Class for jobs list operating: it shall be mapped to file also
        ///// </summary>
        //public class JobsList
        //{
        //    string file = "jobs.json";
        //    public Job Add(Job job)
        //    {
        //        return job;
        //    }

        //    public void Remove(Job job)
        //    {
                
        //    }

        //    public JobsList(string file)
        //    {
        //        this.file = file;
        //    }
        //}

        public static void clearFiles()
        {
            tools.DirEmpty(Program.tempDnDir);
        }
    }



    /// <summary>
    /// Job msg class. This class is used for parsing JSON.
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class JobMsg
    {
        [JsonProperty]
        public string type = "";
        [JsonProperty]
        public int location = 0;
        [JsonProperty]
        public string file = "";
        [JsonProperty]
        public string document = "";
        [JsonProperty]
        public bool autoprinted;
        [JsonProperty]
        public int register = 0;
  //      "autoprinted": false,
  //"register": null,
        public override string ToString()
        {
            return "type: '" + type +
                "', location:'" + location +
                "', file: '" + file +
                "', document: '" + document +
                "', autoprinted: '" + autoprinted +
                "', register: '" + register + "'"
            ;
        }
    }

    /// <summary>
    /// Job state constants
    /// </summary>
    public enum JobState : byte
    {
        New,
        Processing,
        Downloading,
        Downloaded, 
        Printing,
        Printed,
        Skipped,
        Error
    }

    /// <summary>
    /// Job presentation class
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class Job : JobMsg
    {
        /// <summary>
        /// Job id
        /// </summary>
        [JsonProperty]
        public ulong id = 0;
        /// <summary>
        /// Job download progress in percents
        /// </summary>
        [JsonProperty]
        public int progress = 0;
        /// <summary>
        /// Job download progress in bytes
        /// </summary>
        [JsonProperty]
        public long recived = 0;
        /// <summary>
        /// Full path to local file, where job file will be downloaded. Have random additional string.
        /// </summary>
        [JsonProperty]
        public string localFilePath = "";
        /// <summary>
        /// Local file name
        /// </summary>
        [JsonProperty]
        public string localFileName = "";
        /// <summary>
        /// Only file name
        /// </summary>
        [JsonProperty]
        public string fileName = "";
        /// <summary>
        /// Document title - human redable job document type.
        /// </summary>
        [JsonProperty]
        public string documentTitle = "";
        /// <summary>
        /// Job file url parsed to URI object
        /// </summary>
        public Uri url;
        /// <summary>
        /// List of associated with this job printers
        /// </summary>
        public Printer printer;

        [JsonProperty]
        public string printerName = "";

        /// <summary>
        /// Job error
        /// </summary>
        public Exception err = null;
        /// <summary>
        /// Job state
        /// </summary>
        [JsonProperty]
        public JobState state = JobState.New;
        public string stateDetails = "";
        /// <summary>
        /// Job change event
        /// </summary>
        public event EventHandler<Job> onChange;

        /// <summary>
        /// Qauntity
        /// </summary>
        [JsonProperty]
        public int qty = 1;

        public DocType docType;

        /// <summary>
        /// Job download progress event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void onDnProgress(object sender, DownloadProgressChangedEventArgs e)
        {
            progress = e.ProgressPercentage;
            recived = e.TotalBytesToReceive;
        }

        /// <summary>
        /// Job file download method
        /// </summary>
        /// <param name="cb"></param>
        public void download(Action<Exception> cb)
        {
            Downloading();
            // Set progress variables to 0
            progress = 0;
            recived = 0;
            try
            {
                using (WebClient wc = new WebClient())
                {
                    // Adding progress event handler
                    wc.DownloadProgressChanged += onDnProgress;
                    // Adding oncomplete cb - done via lambda, because it is more simple to pass there cb
                    wc.DownloadFileCompleted += (object sender, System.ComponentModel.AsyncCompletedEventArgs e) =>
                    {
                        Downloaded();

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
                    // Start file donwload
                    wc.DownloadFileAsync(url, localFilePath);                    
                }
            }
            catch (Exception err)
            {
                this.err = err;
                Error();
                cb(err);
            }            
        }

        /// <summary>
        /// Print job on selected printers
        /// </summary>
        /// <param name="cb"></param>
        public void print(Action<Exception> cb)
        {
            stateDetails = "";
            Printing();
            // Job printing
            // Looks like more optimal solution will be sending job to "Printers" class and it will decise print job or not... Just idea...
            try
            {      
                if ( 
                    (printer.triggerGet(docType) == false) & 
                    (autoprinted == true)
                )
                {                    
                    Skipped(quantity());
                    cb(null);
                }
                else
                {
                    //Console.WriteLine("File path for print: {0} | {1} | {2}", localFilePath, fileName, document);
                    printer.print(localFilePath, fileName, document);
                    Printed();
                    cb(null);
                }                
            }
            catch (Exception err)
            {
                this.err = err;
                Error();
                cb(err);
            }
        }
        /// <summary>
        /// Get quantity for this job
        /// </summary>
        /// <returns></returns>
        public int quantity()
        {
            return printer.quantity[document];
        }

        public void init()
        {
            this.url = new Uri(file);
            this.docType = DocumentTypes.ToDocumentType(this.document).type;
            if (printerName.Length > 0)
            {
                this.printer = Printers.fromName(this.printerName);
            }
        }

        /// <summary>
        /// New job consturctor
        /// </summary>
        /// <param name="document"></param>
        /// <param name="file"></param>
        /// <param name="location"></param>
        /// <param name="type"></param>
        public Job(
            string document, 
            string file, 
            int location, 
            string type,
            bool autoprinted,
            int register
       )
        {
            this.document = document;
            this.file = file;
            this.type = type;
            this.location = location;
            this.autoprinted = autoprinted;
            this.register = register;

            init();

            // Generate local file path with partial random name
            this.fileName = Path.GetFileName(this.url.LocalPath);
            this.localFileName = tools.randomFileName() + "_" + fileName; 
            this.documentTitle = DocumentTypes.toTitle(document);
            this.localFilePath = Path.Combine(Program.tempDnDir, this.localFileName);
        }

        public Job() { }

        /// <summary>
        /// Converting job to string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return base.ToString();
        }

        /// <summary>
        /// Set job state "Processing"
        /// </summary>
        public void Processing()
	    { 
		    state = JobState.Processing; 
		    if( onChange != null ){
                onChange(null, this);
		    }
	    }
        /// <summary>
        /// Set job state "Downloading"
        /// </summary>
        public void Downloading()
	    { 
		    state = JobState.Downloading; 
		    if( onChange != null ){
                onChange(null, this);
		    }
	    }
        /// <summary>
        /// Set job state "Downloaded"
        /// </summary>
        public void Downloaded()
        {
            state = JobState.Downloaded;
            if (onChange != null)
            {
                onChange(null, this);
            }
        }
        /// <summary>
        /// Set job state "Printing"
        /// </summary>
        public void Printing()
	    { 
		    state = JobState.Printing; 
		    if( onChange != null ){
                onChange(null, this);
		    }
	    }
        /// <summary>
        /// Set job state "Printed"
        /// </summary>
        public void Printed()
	    { 
		    state = JobState.Printed; 
		    if( onChange != null ){
                onChange(null, this);
		    }

	    }
        /// <summary>
        /// Set job state "Ignored"
        /// </summary>
        public void Skipped(int count)
	    {
            state = JobState.Skipped;
            //stateDetails = count.ToString();
		    if( onChange != null ){
                onChange(null, this);
		    }
	    }
        
        /// <summary>
        /// Set job state "Error"
        /// </summary>
        public void Error()
	    { 
		    state = JobState.Error; 
		    if( onChange != null ){
                onChange(null, this);
		    }
	    }

        public void Dispose()
        {
            foreach (EventHandler<Job> d in onChange.GetInvocationList())
            {
                onChange -= d;
            }
            File.Delete(this.localFilePath);
        }
    }
}
