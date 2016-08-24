using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Net;
using PusherClient;
using System.Windows.Forms;

namespace AutoPrintr
{
    static class Srv
    {
        public static List<Channel> channels = new List<Channel>();
        public static ConnectionState state = ConnectionState.Disconnected;
        private static Pusher pusher = null;

        public static void connect(
            List<Listener> listeners,
            Action<PusherException> onError,
            Action<String> onStateChanged
        ){
            //if (Srv.state == ConnectionState.Connected)
            if (pusher != null)
            {
                pusher.Disconnect();
                pusher = null;
            }

            //string xt = WinPrintr.Properties.Settings.Default.PucherKey;
            string xt = Program.config.serverKey;
            if(xt == null){
                onError(new PusherException("Pusher key is empty.", ErrorCodes.Unkown));
                return;
            }

            pusher = new Pusher(xt, new PusherOptions());
            pusher.ConnectionStateChanged += (object sender, ConnectionState state) =>
            {
                Srv.state = state;
                onStateChanged(state.ToString());
            };

            pusher.Error += (object sender, PusherException error) => onError(error);

            Channel c;
            foreach(Listener l in listeners)
            {
                c = pusher.Subscribe(l.channel);
                c.Bind(l.ev, l.action);
                channels.Add(c);
            }

            //// Setup private channel
            //Channel c1 = pusher.Subscribe(ch);
            //c1.Subscribed += (object sender) => cb();
            
            //// Inline binding!
            //c1.Bind(ev, (dynamic data) =>
            //{
            //    //MessageBox.Show("[" + data.name + "] " + data.message);
            //});

            pusher.Connect();
        }

        //static void c1_Subscribed(object sender)
        //{
        //    //throw new NotImplementedException();
        //    MessageBox.Show("c1_Subscribed");
        //}

        //static void srv_Error(object sender, PusherException error)
        //{
        //    //throw new NotImplementedException();
        //    //MessageBox.Show("srv_Error" + error.ToString());
        //}

        //static void srv_ConnectionStateChanged(object sender, ConnectionState state)
        //{
        //    //Message
        //    MessageBox.Show("srv_ConnectionStateChanged" + state.ToString());
        //}
        
    }

    public class Listener
    {
        public string channel = "";
        public string ev = "";
        public Action<dynamic> action;
        public Listener(string c, string e, Action<dynamic> a)
        {
            channel = c;
            ev = e;
            action = a;
        }
    }

}
