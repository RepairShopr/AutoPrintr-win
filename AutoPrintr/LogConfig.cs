using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using NLog;

namespace AutoPrintr
{
    /// <summary>
    /// Log configuration class
    /// </summary>
    class LogConfig
    {
        private static NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();

        /// <summary>
        /// LOg levels list
        /// </summary>
        public static List<string> LogLevels = new List<string>()
        {
            "Default"
            , "Everything"
            //"Fatal"
            //, "Error"
            //, "Warn"
            //, "Info"        
            //, "Debug"
            //, "Trace"
        }; 

        /// <summary>
        /// Converter for log levels
        /// </summary>
        static Dictionary<string, string> UserLogName2NLog = new Dictionary<string, string>()
        {
            { "Default", "Warn"},
            { "Everything", "Info"}
        };

        /// <summary>
        /// Converter for log levels
        /// </summary>
        static Dictionary<string, string> NLog2UserLogName = new Dictionary<string, string>()
        {
            { "Fatal", "Default" },
            { "Error", "Default" },
            { "Warn", "Default" },
            { "Info", "Everything" },
            { "Debug", "Everything" },
            { "Trace", "Everything" }
        };

        /// <summary>
        /// Log configuration file (NLog)
        /// </summary>
        static string logConfigFile = "NLog.config";

        /// <summary>
        /// Set log level
        /// </summary>
        /// <param name="level"></param>
        public static string logLevel(string level = null)
        {
            try
            {
                // Loading log fiel configuratio
                XmlDocument config = new XmlDocument();
                config.Load(logConfigFile);

                // Setting namesapce manager
                var nsmgr = new XmlNamespaceManager(config.NameTable);
                nsmgr.AddNamespace("a", "http://www.nlog-project.org/schemas/NLog.xsd");

                // Collecting nodes
                XmlNodeList nodes = config.SelectNodes("//a:rules/a:logger", nsmgr);
                
                XmlAttribute name;
                XmlAttribute minlevel;

                // Searching logger with name="*" and read / update it minlevel attribute
                foreach (XmlNode node in nodes)
                {
                    name = node.Attributes["name"];
                    //if (name.Value == "AutoPrintrService.*" | name.Value == "AutoPrintr.*")
                    if (name.Value == "*")
                    {
                        minlevel = node.Attributes["minlevel"];
                        if (level == null)
                        {
                            return NLog2UserLogName[minlevel.Value];
                        }
                        else
                        {
                            minlevel.Value = UserLogName2NLog[level];
                        }
                    }
                }
                config.Save(logConfigFile);
                LogManager.Configuration = LogManager.Configuration.Reload();
                LogManager.ReconfigExistingLoggers();
            }
            catch (Exception err)
            {
                log.Error(err, "Error while saving or reading configuration file 'NLog.config'");
            }
            return null;
        }
    }
}
