using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AutoPrintr
{
    static class Autoupdate
    {
        private static NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();

        const string url = "https://api.github.com/repos/RepairShopr/AutoPrintr-win/releases";
        public static string remotePath;
        public static string localPath;

        public static EventHandler onAvailable;
        public static EventHandler onDonwloaded;

        static bool check()
        {
            string apiStringRes = tools.GET(url);
            GHRelease[] apiResponse = JsonConvert.DeserializeObject<GHRelease[]>(
                apiStringRes,
                new JsonSerializerSettings
                { // allow null values
                    NullValueHandling = NullValueHandling.Ignore
                }
            );
            //if (onAvailable != null)
            //{
            //    onAvailable(null, new EventArgs());
            //}
            return false;
        }

        static void download(){
            Autoupdate.localPath = Path.Combine(Program.tempDir, "AutoPrintr_update.exe");
            using (WebClient wc = new WebClient())
            {
                // Adding progress event handler
                wc.DownloadProgressChanged += wc_DownloadProgressChanged;                
                // Adding oncomplete cb - done via lambda, because it is more simple to pass there cb
                wc.DownloadFileCompleted += (object sender, System.ComponentModel.AsyncCompletedEventArgs e) =>
                {
                    if (e.Error != null)
                    {
                        //cb(e.Error); ;
                        log.Error(e.Error, "Error while downloading update");
                    }
                    else
                    {
                        //cb(null);
                        if (onDonwloaded != null)
                        {
                            onDonwloaded(null, new EventArgs());
                        }
                    }
                };
                // Start file donwload
                wc.DownloadFileAsync(new Uri(url), remotePath);
            }
        }

        static void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            //progress = e.ProgressPercentage;
            //recived = e.TotalBytesToReceive;
        }
        
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
