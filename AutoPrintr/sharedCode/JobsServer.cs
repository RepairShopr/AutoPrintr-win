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
        private static NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();
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

        private static List<Listener> listeners;
        private static Action<PusherException> onError;
        private static Action<String> onStateChanged;

        private static bool isConnecting = false;

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
            if (isConnecting)
            {
                return;
            }
            isConnecting = true;
            // Disconnect pusher, if it already connected
            //log.Info("Pusher connect 0");
            if (pusher != null)
            {
                Console.WriteLine("Pusher connect disconnect()");
                disconnect();
            }

            //log.Info("Pusher connect 1");
            JobsServer.listeners = listeners;
            JobsServer.onError = onError;
            JobsServer.onStateChanged = onStateChanged;

            // Create new pusher instance
            pusher = new Pusher(Credentials.SrvXT, new PusherOptions());
            // Set pusher connection changed event handler
            pusher.ConnectionStateChanged += onStateChanged_handler;
            // Set error event handler
            pusher.Error += onError_handler;

            //log.Info("Pusher connect 3");
            // Subscribe listeners to they channels
            Channel c;
            foreach(Listener l in listeners)
            {
                //log.Info("    Pusher connect 3.1");
                c = pusher.Subscribe(l.channel);
                c.Bind(l.evt, l.onMessage);
                channels.Add(c);
            }

            //log.Info("Pusher connect 4");
            // Connect to pusher
            pusher.Connect();

        }

        static void onStateChanged_handler(object sender, ConnectionState state)
        {
            JobsServer.state = state;
            JobsServer.onStateChanged(state.ToString());
            if (state == ConnectionState.Connected | state == ConnectionState.Failed | state == ConnectionState.Unavailable)
            {
                isConnecting = false;
            }
        }

        static void onError_handler(object sender, PusherException error)
        {
            JobsServer.onError(error);
        }

        public static void disconnect()
        {
            foreach (Channel c in JobsServer.channels)
            {
                c.Unsubscribe();
            }
            pusher.Disconnect();
            pusher.ConnectionStateChanged -= onStateChanged_handler;
            pusher.Error -= onError_handler;
            pusher = null;
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
