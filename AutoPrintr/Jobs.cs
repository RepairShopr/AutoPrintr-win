using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PusherClient;
using Newtonsoft.Json;

namespace AutoPrintr
{
    static class Jobs
    {        
        //static public Listener listener;
        static public string ev = "job";
        public static Listener init(string channel, Action<Exception, Job> onJob)
        {
            return new Listener(channel, ev, (dynamic msg) =>
            {
                
                if (msg.type != null & msg.location != null & msg.file != null)
                {
                    //Job j = new Job(msg.type, msg.location, msg.file);
                    onJob(null, new Job(
                        (string)msg.type, 
                        (int)msg.location,
                        (string)msg.file,
                        (string)msg.document
                    ));
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
    }

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

    public class Job : JobMsg
    {
        public bool isPrinted = false;

        public Job(string type, int location, string file, string document)
        {
            this.type = type;
            this.location = location;
            this.file = file;
            this.document = document;
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
    }
}
