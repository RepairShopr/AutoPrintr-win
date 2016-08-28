using System;
using System.Collections.Generic;
using PusherClient;

namespace AutoPrintr
{
    /// <summary>
    /// Server with API for requesting new print jobs
    /// </summary>
    static class JobsServer
    {
        /// <summary>
        /// List of channels
        /// </summary>
        public static List<Channel> channels = new List<Channel>();
        /// <summary>
        /// Pusher current connection state
        /// </summary>
        public static ConnectionState state = ConnectionState.Disconnected;
        /// <summary>
        /// Pusher instance
        /// </summary>
        private static Pusher pusher = null;

        /// <summary>
        /// Connect to jobs server
        /// </summary>
        /// <param name="listeners"></param>
        /// <param name="onError"></param>
        /// <param name="onStateChanged"></param>
        public static void connect(
            List<Listener> listeners,
            Action<PusherException> onError,
            Action<String> onStateChanged
        ){
            // Disconnect pusher, if it already connected
            if (pusher != null)
            {
                pusher.Disconnect();
                pusher = null;
            }
            // Create new pusher instanc
            pusher = new Pusher(Credentials.SrvXT, new PusherOptions());
            // Set pusher connection changed event handler
            pusher.ConnectionStateChanged += (object sender, ConnectionState state) =>
            {
                JobsServer.state = state;
                onStateChanged(state.ToString());
            };
            // Set error event handler
            pusher.Error += (object sender, PusherException error) => onError(error);

            // Subscribe listeners to they channels
            Channel c;
            foreach(Listener l in listeners)
            {
                c = pusher.Subscribe(l.channel);
                c.Bind(l.evt, l.onMessage);
                channels.Add(c);
            }
            // Connect to pusher
            pusher.Connect();
        }        
    }

    /// <summary>
    /// Pusher channel listener
    /// </summary>
    public class Listener
    {
        /// <summary>
        /// Listener channel string id
        /// </summary>
        public string channel = "";
        /// <summary>
        /// Listener event string
        /// </summary>
        public string evt = "";
        /// <summary>
        /// Listener action for message from pusher
        /// </summary>
        public Action<dynamic> onMessage;
        /// <summary>
        /// Create new listener for channel and event
        /// </summary>
        /// <param name="channel"></param>
        /// <param name="evt"></param>
        /// <param name="onMessage"></param>
        public Listener(string channel, string evt, Action<dynamic> onMessage)
        {
            this.channel = channel;
            this.evt = evt;
            this.onMessage = onMessage;
        }
    }

}
