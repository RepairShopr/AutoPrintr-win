using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace AutoPrintr
{
    public class AppService
    {
        private static NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();
        public static serviceData data = new serviceData();
        public static event EventHandler onJob;
        public static event EventHandler onStateChanged;

        public static void print(ulong jobId)
        {

        }

        /// <summary>
        /// Log file name, shall be same as in NLog.config
        /// </summary>
        public static string file = "service.json";
        public static string filePath = Program.tempDir;
        public static string fullPath = Path.Combine(filePath, file);
        public static EventHandler onChange;
        static FileSystemWatcher watcher;
        public static bool Enabled = false;

        public static void watch()
        {
            // Create a new FileSystemWatcher and set its properties.
            watcher = new FileSystemWatcher();
            //watcher.Path = AppDomain.CurrentDomain.BaseDirectory;tempDir
            watcher.Path = filePath;
            /* Watch for changes in LastAccess and LastWrite times, and 
                the renaming of files or directories. */
            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite;
            // Only watch text files.
            watcher.Filter = file;

            // Add event handlers.
            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Created += new FileSystemEventHandler(OnChanged);
            watcher.Deleted += new FileSystemEventHandler(OnChanged);
            //watcher.Renamed += new RenamedEventHandler(OnRenamed);

            // Begin watching.
            watcher.EnableRaisingEvents = true;
            load();
        }

        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            if (onChange != null & Enabled)
            {
                //LogWatcher.text = File.ReadAllText(file, Encoding.ASCII);
                //var logFile = (string)null;
                load();
                onChange(null, new EventArgs());
            }
        }

        public static void load()
        {          
            try
            {
                if (File.Exists(fullPath))
                {
                    string stringData = File.ReadAllText(fullPath);
                    data = JsonConvert.DeserializeObject<serviceData>(stringData);                    
                }
                else
                {
                    save();
                }
            }
            catch (Exception err)
            {
                log.Error(err, "Can't load AppService data.");
            }
        }

        public static void save()
        {
            Console.WriteLine("Path: " + fullPath);
            try
            {
                string conf = JsonConvert.SerializeObject(data, Formatting.Indented);
                log.Debug("AppService data saving");
                File.WriteAllText(fullPath, conf);
            }
            catch (Exception err)
            {
                log.Error(err, "Can't save AppService data.");
            }
        }


        public static void delete()
        {
            File.Delete(fullPath);
        }

        [JsonObject(MemberSerialization.OptIn)]
        public class serviceData
        {
            [JsonProperty]
            public List<Job> jobs = new List<Job>();
            [JsonProperty]
            public string state = "";
            public serviceData()
            {

            }
        }


    }
}

