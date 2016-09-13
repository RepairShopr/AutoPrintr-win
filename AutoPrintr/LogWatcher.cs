using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AutoPrintr
{
    /// <summary>
    /// Log watching class
    /// </summary>
    public static class LogWatcher
    {
        /// <summary>
        /// Log file name, shall be same as in NLog.config
        /// </summary>
        public static string file = "autoprintr.log";

        public static EventHandler onChange;
        public static string text = "";

        public static void init()
        {
            // Create a new FileSystemWatcher and set its properties.
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = Program.localPath;
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
        }

        // Define the event handlers.
        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            if (LogWatcher.onChange != null)
            {
                //LogWatcher.text = File.ReadAllText(file, Encoding.ASCII);
                //var logFile = (string)null;
                using (var fileStream = new FileStream(
                    Path.Combine(Program.localPath, file)
                    , FileMode.Open
                    , FileAccess.Read
                    , FileShare.ReadWrite
                )) {
                    using (var reader = new StreamReader(fileStream))
                    {
                        LogWatcher.text = reader.ReadToEnd();
                    }
                }
                LogWatcher.onChange(null, new EventArgs());
            }
        }
    }
}
