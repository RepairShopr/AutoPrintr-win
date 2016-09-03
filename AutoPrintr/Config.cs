using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
//using System.Windows.Forms;

namespace AutoPrintr
{
    /// <summary>
    /// Application settings structure
    /// </summary>
    public class Settings
    {
        /// <summary>
        /// User's channel ID
        /// </summary>
        public string channel = "";
        /// <summary>
        /// User's login
        /// </summary>
        public string login = "";
        /// <summary>
        /// Selected locations
        /// </summary>
        public List<int> locations = new List<int>();
        /// <summary>
        /// Selected locations
        /// </summary>
        public List<Location> availableLocations = new List<Location>();
        /// <summary>
        /// Registers list
        /// </summary>
        public List<LoginServer.Register> registers = new List<LoginServer.Register>();

        /// <summary>
        /// Printers configurations
        /// </summary>
        public List<Printer> printers = new List<Printer>();
        /// <summary>
        /// 
        /// Log levels:
        ///  - None
        ///  - Fatal
        ///  - Error
        ///  - Warn
        ///  - Info
        ///  - Debug
        ///  - Trace
        /// </summary>
        //public logLevels logLevel = logLevels.Info;
    }

    //public enum logLevels : byte
    //{
    //      None,
    //      Fatal,
    //      Error,
    //      Warn,
    //      Info,
    //      Debug,
    //      Trace
    //}

    /// <summary>
    /// Application config manager class - read, write config, load, save setting to file
    /// </summary>
    public class Config : Settings
    {
        private const string configFile = "config.json";
        //private Action<Exception> onError;
        private static NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();
        
        /// <summary>
        /// Save current configuration
        /// </summary>
        public void save()
        {
            try
            {
                string conf = JsonConvert.SerializeObject(this, Formatting.Indented);
                log.Debug("Config saving");
                //log.Trace("Config saving: {0}", conf);
                File.WriteAllText(configFile, conf);
            }
            catch (Exception err)
            {
                //onError(err);
                log.Error(err, "Can't save configuration.");
            }            
        }

        /// <summary>
        /// Load configuration
        /// </summary>
        public void load()
        {
            try
            {
                if (File.Exists(configFile))
                {
                    string file = File.ReadAllText(configFile);
                    Settings config = JsonConvert.DeserializeObject<Settings>(file);
                    channel = config.channel;
                    login = config.login;
                    locations = config.locations;
                    printers = config.printers;
                    availableLocations = config.availableLocations;
                    registers = config.registers;
                }
                else
                {
                    save();
                }
            }
            catch (Exception err)
            {
                //onError(err);
                //System.Windows.Forms.MessageBox.Show(
                //    "config error: " + err.ToString()
                //);
                log.Error(err, "Can't load configuration.");
            }
        }

        /// <summary>
        /// New config instance
        /// </summary>
        /// <param name="onError"></param>
        public Config(Action<Exception> onError)
        {
            //this.onError = onError;
            load();
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    } 
}
