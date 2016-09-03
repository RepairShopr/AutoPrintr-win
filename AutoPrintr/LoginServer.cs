using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AutoPrintr
{
    
    /// <summary>
    /// Login server class
    /// </summary>
    public static class LoginServer
    {
        private static NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Url for sign in
        /// </summary>
        static string serverUrl = "https://admin.{0}/api/v1/sign_in";
        /// <summary>
        /// User token from server for API acess
        /// </summary>
        public static string UserToken = "";
        /// <summary>
        /// User channel for pusher API
        /// </summary>
        public static string channel = "";
        /// <summary>
        /// User domain - require fro API access
        /// </summary>
        public static string domain = "";
        /// <summary>
        /// Multi/single locations flag
        /// </summary>
        public static bool isMultiLocations = false;
        /// <summary>
        /// Array with available user locations
        /// </summary>
        public static List<Location> locations;
        /// <summary>
        /// User default location
        /// </summary>
        public static Location defaultLocation;
        /// <summary>
        /// Dictionary-converter for convertin location string to ID
        /// </summary>
        public static Dictionary<string, int> locationString2ID = new Dictionary<string, int>();
        /// <summary>
        ///  Dictionary-converter for convertin location ID to string
        /// </summary>
        public static Dictionary<int, string> locationID2String = new Dictionary<int, string>();

        /// <summary>
        /// Registers collection
        /// </summary>
        public static List<Register> registers = new List<Register>();

        /// <summary>
        /// Method for login via username and password
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static LoginResponse login(string username, string password)
        {
            //string globalURl = ConfigurationManager.AppSettings.Get("HostName");
            
            string globalURl = AutoPrintr.Properties.Settings.Default.HostName;
            using (WebClient myWebClient = new WebClient())
            {
                try
                {
                    NameValueCollection data = new NameValueCollection();
                    data.Add("email", username);
                    data.Add("password", password);
                    string url = string.Format(serverUrl, globalURl.Trim());
                    var responseArray = myWebClient.UploadValues(url, "POST", data);
                    string jsonResult = Encoding.ASCII.GetString(responseArray);
                    LoginResponse resp = 
                        JsonConvert.DeserializeObject<LoginResponse>(
                            jsonResult, 
                            new JsonSerializerSettings { // allow null values
                                NullValueHandling = NullValueHandling.Ignore
                            }
                        );
                    
                    if (resp != null)
                    {
                        // Saving locations configuration
                        UserToken = resp.UserToken;
                        if (resp.LocationsAllowed != null)
                        {
                            int id = resp.DefaulLocation;
                            locationString2ID = new Dictionary<string, int>();
                            foreach(Location l in resp.LocationsAllowed){
                                if( l.id == id){
                                    LoginServer.defaultLocation = l;
                                }
                                LoginServer.locationString2ID.Add(l.name, l.id);
                                LoginServer.locationID2String.Add(l.id, l.name);
                            }
                            locations = resp.LocationsAllowed;
                        }

                        // Setting other variables
                        LoginServer.isMultiLocations = resp.EnableMultiLocations;
                        LoginServer.domain = resp.Subdomain;
                        //LoginServer.channel = getChannel(domain, globalURl, UserToken);
                        getSettings(domain, globalURl, UserToken);
                        //getChannel();
                        return resp;
                    }
                    else
                    {
                        string errText = "Response from login server is null";
                        log.Error(errText);
                        MessageBox.Show(errText);
                        throw new Exception(errText);
                    }
                }
                catch (WebException ex)
                {
                    if (ex.Status == WebExceptionStatus.ProtocolError && ex.Response != null)
                    {
                        if ((ex.Response as HttpWebResponse).StatusCode == HttpStatusCode.Unauthorized)
                        {
                            string errText = "Failed to Authenticate given Username and Password";
                            log.Error(errText);
                            MessageBox.Show(errText);
                            throw new Exception(errText);
                        }
                    }
                    else
                    {
                        string errText = "Unable to Login in RepairShopr. Error: " + ex.Message;
                        log.Error(errText);
                        MessageBox.Show(errText);
                        throw new Exception(errText);
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Request to login server for pucher user channel ID
        /// </summary>
        /// <param name="domain"></param>
        /// <param name="host"></param>
        /// <param name="xt"></param>
        /// <returns></returns>
        public static void getSettings(string domain, string host, string xt)
        {
            string url = "https://" + domain + "." + host + "/api/v1/settings/printing?api_key=" + xt;
            string response = "";
            SettingsResponse settings;
            response = tools.GET(url);
            settings = JsonConvert.DeserializeObject<SettingsResponse>(
                response, 
                new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore}
            );


            if (settings.messaging_channel != null)
            {
                LoginServer.channel = settings.messaging_channel;
            }
            else
            {
                string errText = "Can\'t get channel from response. Error: '" + settings.error.ToString() + "'. Response: " + response;
                log.Error(errText);
                throw new Exception(errText);
            }

            if (settings.registers != null)
            {
                foreach(Register r in settings.registers){
                    LoginServer.registers.Add(r);
                }
            }
        }

        private class SettingsResponse
        {
            public string messaging_channel = null;
            public List<Register> registers = new List<Register>();
            public string error = null;
        }

        /// <summary>
        /// Register class api/v1/settings/printing
        /// </summary>
        public class Register
        {
            public int id = 0;
            public string name = "";
            public int location_id = 0;
            public string location_name = "";
        }

        public static class Registers
        {
            public static Register get(int id)
            {
                return Program.config.registers.Find(v => v.id == id);
            }

            public static Register get(string name)
            {
                return Program.config.registers.Find(v => v.name == name);
            }

            public static void Add(Register r)
            {
                Program.config.registers.Add(r);
                Program.config.save();
            }
        }

        //{
        //  "messaging_channel": "",
        //  "registers": [
        //    {
        //      "id": 2748,
        //      "name": "Register 1",
        //      "location_id": 1019,
        //      "location_name": "Office 1"
        //    },
        //    {
        //      "id": 2750,
        //      "name": "Register 2",
        //      "location_id": 1020,
        //      "location_name": "Small Office"
        //    }
        //  ]
        //}

    }

}
