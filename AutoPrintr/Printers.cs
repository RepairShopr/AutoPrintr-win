using System;
using System.Collections.Generic;
using System.Diagnostics;
using Newtonsoft.Json;
using Microsoft.Win32;
//using System.Linq;
//using System.Text;

namespace AutoPrintr
{
    /// <summary>
    /// Static class for printers management
    /// </summary>
    static class Printers
    {        
        /// <summary>
        /// Find existing system printers and merge it with saved in config printers list
        /// </summary>
        /// <returns></returns>
        public static List<Printer> get()
        {
            List<Printer> pList = new List<Printer>();
            // Getting available printers
            bool notLoaded;
            foreach (string printerName in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                // If system printer is have saved config - then use this config
                notLoaded = true;
                foreach (Printer printer in Program.config.printers)
                {
                    if (printerName == printer.name)
                    {
                        pList.Add(printer);
                        notLoaded = false;
                        break; // Hmm... Looks like here something wrong... What you think?
                    }
                }
                
                if (notLoaded)
                {
                    pList.Add(new Printer(printerName));
                }
            }
            // Sorted text list are alsways betterm then unsorted
            pList.Sort((a, b) => a.name.CompareTo(b.name));
            // Saving printers to config
            Program.config.printers = pList;            
            Program.config.save();
            return pList;
        }

        /// <summary>
        /// Intialization of printers static class
        /// </summary>
        public static void init()
        {
            DocumentTypes.init();
        }

        /// <summary>
        /// Find printers for this types and location
        /// </summary>
        /// <param name="type"></param>
        /// <param name="location"></param>
        /// <returns></returns>
        public static List<Printer> findPrinters(string type, int location)
        {
            List<Printer> l = new List<Printer>();
            DocumentType t = DocumentTypes.ToPrintType(type);
            if( t == null){ return l; }

            // Check for empty locations array and empty location (0)
            if (Program.config.locations.Count > 0 & location != 0) 
            {
                // If location not in array - return empty list
                if ( !Program.config.locations.Contains(location) ) { return l; } 
            }
            
            // Search printer by type
            foreach (Printer printer in Program.config.printers)
            {
                if (printer.get(t.type))
                {
                    l.Add(printer);
                }
            }
            return l;
        }
    }

    /// <summary>
    /// Document types id list
    /// </summary>
    public enum DocType : byte
    { 
        Invoice,
        Estimate,
        Ticket,
        IntakeForm,
        Receipt,
        ZReport,
        TicketReceipt,
        PopDrawer,
        Adjustment,
        CustomerID,
        Asset,
        TicketLabel
    };

    /// <summary>
    /// Document types manager
    /// </summary>
    public static class DocumentTypes
    {
        private static NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();
        /// <summary>
        /// Available document types
        /// </summary>
        public static List<DocumentType> list;
        
        /// <summary>
        /// Get DocumentType object from string
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static DocumentType ToPrintType(string str)
        {
            DocumentType t = list.Find(x => x.name == str);
            if (t == null)
            {
                //throw new Exception("Can't find PType string '" + str + "' in PrintTypes.list");
                log.Error("Can't find DocumentType string '" + str + "' in DocumentTypes.list");
                return null;
            }
            else
            {
                return t;
            }
        }

        /// <summary>
        /// Convert document type string to human readable string
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string toTitle(string str)
        {
            DocumentType t = DocumentTypes.ToPrintType(str);
            if( t != null ){
                return t.title;
            } else {
                return "null";
            }            
        }

        /// <summary>
        /// Initialization method
        /// </summary>
        public static void init()
        {
            DocumentTypes.list = new List<DocumentType>() {
                new DocumentType( DocType.Invoice, "Invoice" ),
                new DocumentType( DocType.Estimate, "Estimate" ),
                new DocumentType( DocType.Ticket, "Ticket" ),
                new DocumentType( DocType.IntakeForm, "Intake Form" ),
                new DocumentType( DocType.Receipt, "Receipt" ),
                new DocumentType( DocType.ZReport, "Z Report" ),
                new DocumentType( DocType.TicketReceipt, "Ticket Receipt" ),
                new DocumentType( DocType.PopDrawer, "Pop Drawer" ),
                new DocumentType( DocType.Adjustment, "Adjustment" ),
                new DocumentType( DocType.CustomerID, "Customer ID" ),
                new DocumentType( DocType.Asset, "Asset" ),
                new DocumentType( DocType.TicketLabel, "Ticket Label" )
            };
            DocumentTypes.list.Sort((a, b) => a.name.CompareTo(b.name));
        }
    }

    /// <summary>
    /// Document type class
    /// </summary>
    public class DocumentType
    {
        /// <summary>
        /// Document type ID
        /// </summary>
        public readonly DocType type;
        /// <summary>
        /// Document type name (string)
        /// </summary>
        public readonly string name;
        /// <summary>
        /// Document type human redeable string
        /// </summary>
        public readonly string title;
        /// <summary>
        /// Convert to string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return name;
        }
        /// <summary>
        /// DocumentType constructor
        /// </summary>
        /// <param name="type"></param>
        /// <param name="title"></param>
        public DocumentType(DocType type, string title)
        {
            this.type = type;
            this.name = type.ToString();
            this.title = title;
        }
    }

    [JsonObject(MemberSerialization.OptIn)]
    /// <summary>
    /// Printer class. Automatically save changed properties.
    /// </summary>
    public class Printer
    {
        [JsonProperty]
        public readonly string name;
        [JsonProperty,JsonConverter(typeof(PrintEngines.Converter))]
        public PrintEngine printEngine = PrintEngines.SumatraPDF;
        [JsonProperty]
        public List<DocType>types = new List<DocType>();

        /// <summary>
        /// Set printing type value
        /// </summary>
        /// <param name="type">Document type</param>
        /// <param name="val">Value</param>
        public void set(DocType type, bool val)
        {
            //types[(int)printingType] = val;
            bool exists = types.Exists(v => v == type);
            if (val & !exists)
            {
                types.Add(type);
            }
            else if (!val & exists)
            {
                types.Remove(type);
            }
            Program.config.save();
        }

        public void print(string filePath, string documentName)
        {
            printEngine.print(name, filePath, documentName);            
        }

        /// <summary>
        /// Get printing type value
        /// </summary>
        /// <param name="type"></param>
        /// <returns>value</returns>
        public bool get(DocType type)
        {
            //return types[(int)printingType];
            return types.Exists(v => v == type);
        }


        /// <summary>
        /// Create new printer
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="types">Types states</param>
        /// <param name="r">Receipt sate</param>
        /// <param name="l">Label sate</param>
        public Printer(string name, List<DocType> types = null)
        {
            this.name = name;
            if (types != null)
            {
                this.types = types;
            }
        }

        /// <summary>
        /// Printer to string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return name;
        }
    }


}
