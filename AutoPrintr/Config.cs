using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using System.Windows.Forms;

namespace AutoPrintr
{
    public class Settings
    {
        public string channel = "";
        public string login = "";
        public List<int> location = new List<int>();
        public List<Printer> printers = new List<Printer>();
    }

    public class Config : Settings
    {
        //public string serverKey = "";
        //public List<int> location = new List<int>();
        //public List<Printer> printers = new List<Printer>();

        private const string configFile = "config.json";
        private Action<Exception> onError;

        public void save()
        {
            try
            {
                File.WriteAllText(configFile, JsonConvert.SerializeObject(this));
            }
            catch (Exception err)
            {
                onError(err);
            }            
        }

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
                    location = config.location;
                    printers = config.printers;
                }
                else
                {
                    save();
                }                
            }
            catch (Exception err)
            {
                //onError(err);
                MessageBox.Show(err.ToString());
            }
            
        }

        public Config(Action<Exception> onError)
        {
            this.onError = onError;
            load();
        }
    } 
}
