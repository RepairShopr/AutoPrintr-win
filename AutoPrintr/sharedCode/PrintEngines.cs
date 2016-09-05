using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AutoPrintr
{
    //public enum PrintEngine
    //{
    //    Internal,
    //    AcrobatReader,
    //    DefaultPdfViwer,
    //    SumatraPDF
    //};

    /// <summary>
    /// Print engines manager classs
    /// </summary>
    static class PrintEngines
    {
        /// <summary>
        /// Dictionary for converting engine name to engine instance
        /// </summary>
        public static Dictionary<String, PrintEngine> list = new Dictionary<String, PrintEngine>();
        /// <summary>
        /// Default print engine
        /// </summary>
        public static PrintEngine Default;

        /// <summary>
        /// Print via external programm Sumatra PDF
        /// </summary>
        public static PrintEngine SumatraPDF = new PrintEngine("Sumatra PDF Reader",
            ((printerName, filePath, documentName) => 
            {
                Process.Start(
                    "SumatraPDF.exe",
                    string.Format("-silent -exit-on-print -print-to \"{0}\" \"{1}\"", printerName, filePath)
                );
            })){};

        /// <summary>
        /// Print via external programm Acrobat Reader
        /// </summary>
        public static PrintEngine AcrobatReader = new PrintEngine("Acrobat Reader",
            ((printerName, filePath, documentName) =>
            {
                Process.Start(
                    Registry.LocalMachine.OpenSubKey(
                        @"SOFTWARE\Microsoft\Windows\CurrentVersion" +
                        @"\App Paths\AcroRd32.exe"
                    ).GetValue("").ToString(),
                    string.Format("/h /t \"{0}\" \"{1}\"", filePath, printerName)
                );
            })){};

        /// <summary>
        /// Print via default system PDF reader
        /// </summary>
        public static PrintEngine DefaultPdfReader = new PrintEngine("Default PDF Reader",
            ((printerName, filePath, documentName) =>
            {
                Process p = new Process();
                p.StartInfo = new ProcessStartInfo()
                {
                    CreateNoWindow = true,
                    Verb = "PrintTo",
                    WindowStyle = ProcessWindowStyle.Hidden,
                    FileName = filePath,
                    Arguments = "\"" + printerName + "\""
                };
                p.Start();
            })){};

        ///// <summary>
        ///// Direct PDF printing via Windows API (no any external reader used, works not with all printers - reason is unknown).
        ///// </summary>
        //public static PrintEngine Internal = new PrintEngine("Internal",
        //    ((printerName, filePath, documentName) =>
        //    {
        //        RawPrint.SendFileToPrinter(filePath, printerName, documentName);
        //    })){};



        /// <summary>
        /// Find print engine by name
        /// </summary>
        /// <param name="engineName"></param>
        /// <returns></returns>
        public static PrintEngine find(string engineName)
        {
            PrintEngine engine;
            PrintEngines.list.TryGetValue(engineName, out engine);
            if (engine == null)
            {
                return PrintEngines.Default;
            }
            else
            {
                return engine;
            }
        }



        /// <summary>
        /// PrintEngine JSON converter
        /// </summary>
        public class Converter : JsonConverter
        {
            /// <summary>
            /// Convert print engine instance to string
            /// </summary>
            /// <param name="writer"></param>
            /// <param name="value"></param>
            /// <param name="serializer"></param>
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                PrintEngine engine = value as PrintEngine;
                writer.WriteValue(engine.name);
            }
            /// <summary>
            /// Convert string print engine name to engine instance
            /// </summary>
            /// <param name="reader"></param>
            /// <param name="objectType"></param>
            /// <param name="existingValue"></param>
            /// <param name="serializer"></param>
            /// <returns></returns>
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                // Getting engine name string and searching
                return PrintEngines.find( (string)JToken.Load(reader) );
            }

            /// <summary>
            /// Check if object type can be mapped to print engine
            /// </summary>
            /// <param name="objectType"></param>
            /// <returns></returns>
            public override bool CanConvert(Type objectType)
            {
                return typeof(PrintEngine).IsAssignableFrom(objectType);
            }
        }
    }

    /// <summary>
    /// Print engine class
    /// </summary>
    public class PrintEngine
    {
        /// <summary>
        /// Engine name
        /// </summary>
        public string name = "";
        /// <summary>
        /// Print delegete type (not action, because delegate support named parameters and VS can show this parameters as documentation)
        /// </summary>
        /// <param name="printerName"></param>
        /// <param name="filePath"></param>
        /// <param name="documentName"></param>
        public delegate void printDelegate(string printerName, string filePath, string documentName);
        /// <summary>
        /// Print method for engine
        /// </summary>
        public printDelegate print;

        /// <summary>
        /// Create new PrintEngine with selected name and printAction
        /// </summary>
        /// <param name="name"></param>
        /// <param name="printAction"></param>
        public PrintEngine(string name, printDelegate printAction)
        {
            this.name = name;
            this.print = printAction;
            PrintEngines.list.Add(name, this);
            // Set default print engine
            if (PrintEngines.Default == null)
            {
                PrintEngines.Default = this;
            }
        }

        /// <summary>
        /// Converts engine instance to string - name.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return name;
        }
    }
}
