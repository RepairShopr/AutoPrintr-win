using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace AutoPrintr
{
    static class LoginServer
    {
        static string serverUrl = "https://admin.{0}/api/v1/sign_in";
        public static string UserToken = "";
        public static string channel = "";
        public static string domain = "";
        public static bool isMultiLocations = false;
        public static Location[] locationsArr;
        public static Location defaultLocation;
        public static Dictionary<string, int> locations = new Dictionary<string, int>();
        public static Dictionary<int, string> locationsID = new Dictionary<int, string>();
        //static bool isLogged = false;

        public static LoginResponse login(string login, string password)
        {
            //string globalURl = ConfigurationManager.AppSettings.Get("HostName");
            
            string globalURl = AutoPrintr.Properties.Settings.Default.HostName;
            using (WebClient myWebClient = new WebClient())
            {
                try
                {
                    NameValueCollection myNameValueCollection = new NameValueCollection();
                    myNameValueCollection.Add("email", login);
                    myNameValueCollection.Add("password", password);
                    string url = string.Format(serverUrl, globalURl.Trim());
                    var responseArray = myWebClient.UploadValues(url, "POST", myNameValueCollection);
                    string jsonResult = Encoding.ASCII.GetString(responseArray);
                    //LoginResponse resp = JsonConvert.DeserializeObject<LoginResponse>(jsonResult);
                    LoginResponse resp = 
                        JsonConvert.DeserializeObject<LoginResponse>(
                            jsonResult, 
                            new JsonSerializerSettings { 
                                NullValueHandling = NullValueHandling.Ignore
                            }
                        );
                    
                    if (resp != null)
                    {
                        //RepairShoprUtils.LogWriteLineinHTML("Successfully Login in RepairShopr", MessageSource.Login, "", messageType.Information);
                        UserToken = resp.UserToken;
                        if (resp.LocationsAllowed != null)
                        {
                            int id = resp.DefaulLocation;
                            locations = new Dictionary<string, int>();
                            foreach(Location l in resp.LocationsAllowed){
                                if( l.id == id){
                                    LoginServer.defaultLocation = l;
                                }
                                LoginServer.locations.Add(l.name, l.id);
                                LoginServer.locationsID.Add(l.id, l.name);
                            }
                            locationsArr = resp.LocationsAllowed;
                        }
                        //LoginServer.isLogged = true;
                        LoginServer.isMultiLocations = resp.EnableMultiLocations;
                        LoginServer.domain = resp.Subdomain;
                        LoginServer.channel = getChannel(domain, globalURl, UserToken);
                        //getChannel();
                        return resp;
                    }
                }
                catch (WebException ex)
                {
                    if (ex.Status == WebExceptionStatus.ProtocolError && ex.Response != null)
                    {
                        if ((ex.Response as HttpWebResponse).StatusCode == HttpStatusCode.Unauthorized)
                        {
                            //RepairShoprUtils.LogWriteLineinHTML("Failed to Authenticate given Username and Password", MessageSource.Login, ex.Message, messageType.Error);
                            throw new Exception("Failed to Authenticate given Username and Password");
                        }
                    }
                    else
                    {
                        //RepairShoprUtils.LogWriteLineinHTML("Unable to Login in RepairShopr", MessageSource.Login, ex.Message, messageType.Error);
                        throw new Exception("Unable to Login in RepairShopr. Error: " + ex.Message);
                    }
                }
            }
            return null;
        }

        public static string getChannel(string domain, string host, string xt)
        {
            string url = "https://" + domain + "." + host + "/api/v1/settings/printing?api_key=" + xt;
            string response = "";
            getChannelResp ch;
            response = GET(url);
            ch = JsonConvert.DeserializeObject<getChannelResp>(
                response, 
                new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore}
            );
            
            if (ch.messaging_channel != null)
            {
                return ch.messaging_channel;
            }
            else
            {
                throw new Exception("Can\'t get channel from response. Error: '" + ch.error.ToString() + "'. Response: " + response);
            }
        }

        private class getChannelResp
        {
            public string messaging_channel;
            public string error;
        }

        public static string GET(string Url)
        {
            WebRequest req = WebRequest.Create(Url);
            WebResponse resp = req.GetResponse();
            Stream stream = resp.GetResponseStream();
            StreamReader sr = new StreamReader(stream);
            string Out = sr.ReadToEnd();
            sr.Close();
            return Out;
        }
    }

}
