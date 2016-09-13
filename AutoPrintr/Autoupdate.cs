using System;
using System.IO;
using System.IO.Compression;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace AutoPrintr
{
    static class Autoupdate
    {
        private static NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();

        const string url = "https://api.github.com/repos/RepairShopr/AutoPrintr-win/releases/latest";
        public static string localPath;
        public static GHRelease release;
        public static GHRelease.Asset releaseFile = null;

        public delegate void onAvailableHandler(object sender, UpdateEventArgs e);
        public delegate void onDownloadedHandler(object sender, EventArgs e);
        public delegate void onProgressHandler(object sender, DownloadProgressChangedEventArgs e);

        public static event onAvailableHandler onAvailable;
        public static event onDownloadedHandler onDownloaded;
        public static event onProgressHandler onProgress;

        static string versionFile;
        static string installer;

        public static void check()
        {
            string apiStringRes = tools.GET(url);
            Autoupdate.release = JsonConvert.DeserializeObject<GHRelease>(
                apiStringRes,
                new JsonSerializerSettings
                { // allow null values
                    NullValueHandling = NullValueHandling.Ignore
                }
            );

            releaseFile = release.assets.Find(
                (file) => file.name == "AutoPrintr_install.zip"
            );

            if (releaseFile != null & tools.isNewerVersion(release.name) )
            {
                if (onAvailable != null)
                {
                    onAvailable(null, new UpdateEventArgs(Autoupdate.release));
                }            
            }
        }

        static public void install()
        {
            ZipFile.ExtractToDirectory(Autoupdate.localPath, Program.tempDir);
            string errMsg = "Can't find file {0} from release archive. Update aborted.";

            if( !File.Exists(versionFile) )
            {
                log.Error(errMsg, versionFile);
                return;
            }

            if( !File.Exists(installer) ){
                log.Error(errMsg, installer);
                return;
            }
            log.Info("Starting installer: {0}{1}{2}", installer, " /S /D ", Program.localPath);
            Process.Start(installer, " /S /D " + Program.localPath);
            System.Windows.Forms.Application.Exit();
        }

        static public void download()
        {
            versionFile = Path.Combine(Program.tempDir, "version.txt");
            installer = Path.Combine(Program.tempDir, "AutoPrintr_install.exe");

            if (File.Exists(versionFile))
            {
                File.Delete(versionFile); 
            }

            if (File.Exists(installer))
            {
                File.Delete(installer);
            }

            if (File.Exists(Autoupdate.localPath))
            {
                File.Delete(Autoupdate.localPath);
            }
            
            Autoupdate.localPath = Path.Combine(Program.tempDir, "AutoPrintr_install.zip");
            using (WebClient wc = new WebClient())
            {
                // Adding progress event handler
                wc.DownloadProgressChanged += wc_DownloadProgressChanged;                
                // Adding oncomplete cb - done via lambda, because it is more simple to pass there cb
                wc.DownloadFileCompleted += (object sender, System.ComponentModel.AsyncCompletedEventArgs e) =>
                {
                    if (e.Error != null)
                    {
                        log.Error(e.Error, "Error while downloading update");
                        //throw e.Error;
                        //System.Windows.Forms.MessageBox.Show(releaseFile.browser_download_url + "\n" + e.Error.ToString());
                    }
                    else
                    {
                        if (onDownloaded != null)
                        {
                            onDownloaded(null, new EventArgs());
                        }
                    }
                };
                // Start file donwload
                wc.DownloadFileAsync(
                    new Uri(releaseFile.browser_download_url), 
                    Autoupdate.localPath
                );
            }
        }

        static void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            if (onProgress != null)
            {
                onProgress(null, e);
            }
        }

        public class ProgressEventArgs : EventArgs
        {
            public string Status { get; private set; }

            public ProgressEventArgs(string status)
            {
                Status = status;
            }
        }

        public class UpdateEventArgs : EventArgs
        {
            public GHRelease release { get; private set; }

            public UpdateEventArgs(GHRelease release)
            {
                this.release = release;
            }
        }

        /// <summary>
        /// Github API releases response
        /// </summary>
        [JsonObject(MemberSerialization.OptIn)]
        public class GHRelease
        {
            [JsonProperty]
            public string url;
            [JsonProperty]
            public string assets_url;
            [JsonProperty]
            public string upload_url;
            [JsonProperty]
            public string html_url;
            [JsonProperty]
            public int id;
            [JsonProperty]
            public string tag_name;
            [JsonProperty]
            public string target_commitish;
            [JsonProperty]
            public string name;
            [JsonProperty]
            public bool draft;
            [JsonProperty]
            public Author author;
            [JsonProperty]
            public bool prerelease;
            [JsonProperty]
            public string created_at;
            [JsonProperty]
            public string published_at;
            [JsonProperty]
            public List<Asset> assets;
            [JsonProperty]
            public string tarball_url;
            [JsonProperty]
            public string zipball_url;
            [JsonProperty]
            public string body;

            [JsonObject(MemberSerialization.OptIn)]
            public class Author
            {
                [JsonProperty]
                public string login;
                [JsonProperty]
                public int id;
                [JsonProperty]
                public string avatar_url;
                [JsonProperty]
                public string gravatar_id;
                [JsonProperty]
                public string url;
                [JsonProperty]
                public string html_url;
                [JsonProperty]
                public string followers_url;
                [JsonProperty]
                public string following_url;
                [JsonProperty]
                public string gists_url;
                [JsonProperty]
                public string starred_url;
                [JsonProperty]
                public string subscriptions_url;
                [JsonProperty]
                public string organizations_url;
                [JsonProperty]
                public string repos_url;
                [JsonProperty]
                public string events_url;
                [JsonProperty]
                public string received_events_url;
                [JsonProperty]
                public string type;
                [JsonProperty]
                public bool site_admin;
            }

            [JsonObject(MemberSerialization.OptIn)]
            public class Uploader
            {
                [JsonProperty]
                public string login;
                [JsonProperty]
                public int id;
                [JsonProperty]
                public string avatar_url;
                [JsonProperty]
                public string gravatar_id;
                [JsonProperty]
                public string url;
                [JsonProperty]
                public string html_url;
                [JsonProperty]
                public string followers_url;
                [JsonProperty]
                public string following_url;
                [JsonProperty]
                public string gists_url;
                [JsonProperty]
                public string starred_url;
                [JsonProperty]
                public string subscriptions_url;
                [JsonProperty]
                public string organizations_url;
                [JsonProperty]
                public string repos_url;
                [JsonProperty]
                public string events_url;
                [JsonProperty]
                public string received_events_url;
                [JsonProperty]
                public string type;
                [JsonProperty]
                public bool site_admin;
            }

            [JsonObject(MemberSerialization.OptIn)]
            public class Asset
            {
                [JsonProperty]
                public string url;
                [JsonProperty]
                public int id;
                [JsonProperty]
                public string name;
                [JsonProperty]
                public object label;
                [JsonProperty]
                public Uploader uploader;
                [JsonProperty]
                public string content_type;
                [JsonProperty]
                public string state;
                [JsonProperty]
                public int size;
                [JsonProperty]
                public int download_count;
                [JsonProperty]
                public string created_at;
                [JsonProperty]
                public string updated_at;
                [JsonProperty]
                public string browser_download_url;
            }
        }

    }
}
