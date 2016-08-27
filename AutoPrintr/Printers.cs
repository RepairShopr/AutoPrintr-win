﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Windows.Forms;
using Microsoft.Win32;

namespace AutoPrintr
{
    /// <summary>
    /// Static class for printers management
    /// </summary>
    static class Printers
    {
        ///// <summary>
        ///// List of printers with properties. Each printer automatically save changed property.
        ///// </summary>
        //public static List<Printer> list = Program.config.printers;

        ///// <summary>
        ///// Printers config file path or name.
        ///// </summary>
        //public static string config = "printers.json";

        ///// <summary>
        ///// Load printers from file.
        ///// </summary>
        ///// <returns>Printer[]</returns>
        //private static Printer[] load()
        //{
        //    Printer[] arr = null;
        //    if (File.Exists(config))
        //    {
        //        //try 
        //        //{	        
        //        arr = JsonConvert.DeserializeObject<Printer[]>(File.ReadAllText( config ));
        //        //}
        //        //catch (Exception e)
        //        //{
        //        //    throw e;
        //        //}    
        //    }
        //    if (arr == null)
        //    {
        //        arr = new Printer[0];
        //    }
        //    return arr;
        //}

        ///// <summary>
        ///// Save printers to config file.
        ///// </summary>
        //public static void save() 
        //{
        //    File.WriteAllText(config, JsonConvert.SerializeObject(Printers.list));
        //}

        /// <summary>
        /// Find existing system printers; load printers grom file; merge 2 lists.
        /// </summary>
        /// <returns></returns>
        public static List<Printer> get()
        {
            List<Printer> pList = new List<Printer>();

            // Loading printers config
            //Printer[] savedPrinters = load();

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
                        break;
                    }
                }
                
                if (notLoaded)
                {
                    pList.Add(new Printer(printerName));
                }
            }
            //list = pList;
            //save();
            pList.Sort((a, b) => a.name.CompareTo(b.name));
            Program.config.printers = pList;            
            Program.config.save();
            return pList;
        }

        public static void init()
        {
            PrintTypes.list = new List<PrintType>() { 
                //new PrintType( PType.tickets, "Tickets" ),
                //new PrintType( PType.tickets_receipt, "Tickets Receipt" ),
                //new PrintType( PType.intake_forms, "Intake Forms" ),
                //new PrintType( PType.invoices, "Invoices" ),
                //new PrintType( PType.receipt, "Receipt" ),
                //new PrintType( PType.customer_labels, "Customer Labels" ),
                //new PrintType( PType.asset_labels, "Asset Labels" ),
                //new PrintType( PType.ticket_labels, "Ticket Labels" )
                new PrintType( PType.Invoice, "Invoice" ),
                new PrintType( PType.Estimate, "Estimate" ),
                new PrintType( PType.Ticket, "Ticket" ),
                new PrintType( PType.IntakeForm, "Intake Form" ),
                new PrintType( PType.Receipt, "Receipt" ),
                new PrintType( PType.ZReport, "Z Report" ),
                new PrintType( PType.TicketReceipt, "Ticket Receipt" ),
                new PrintType( PType.PopDrawer, "Pop Drawer" ),
                new PrintType( PType.Adjustment, "Adjustment" ),
                new PrintType( PType.CustomerID, "Customer ID" ),
                new PrintType( PType.Asset, "Asset" ),
                new PrintType( PType.TicketLabel, "Ticket Label" )
            };
            //PrintTypes.list = (List<PrintType>)PrintTypes.list.OrderBy(item => item.name);
            PrintTypes.list.Sort( (a, b) => a.name.CompareTo(b.name) );
        }

        public static List<Printer> getPrinters(string type, int location)
        {
            List<Printer> l = new List<Printer>();
            PrintType t = PrintTypes.ToPrintType(type);
            //MessageBox.Show(
            //    type + " / " + location + "\n\n" +
            //    Program.config.location.Contains(location).ToString()
            //);
            if( t == null){ return l; }


            if (Program.config.location.Count > 0 & location != 0) // Check for empty locations array
            {
                if ( !Program.config.location.Contains(location) ) { return l; } // If location not in array - return empty list
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
    /// Printing types
    /// </summary>
    public enum PType : byte
    {
        //tickets,
        //tickets_receipt,
        //intake_forms,
        //invoices,
        //receipt,
        //customer_labels,
        //asset_labels,
        //ticket_labels

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
    }


    public static class PrintTypes
    {
        public static List<PrintType> list;

        public static string title(PType type)
        {
            PrintType t = list.Find(x => x.type == type);
            if (t == null)
            {
                throw new Exception("Can't find PType '" + type.ToString() + "' in PrintTypes.list");
            }
            else
            {
                return t.title;
            }
        }

        public static PrintType ToPrintType(string str)
        {
            PrintType t = list.Find(x => x.name == str);
            if (t == null)
            {
                throw new Exception("Can't find PType string '" + str + "' in PrintTypes.list");
            }
            else
            {
                return t;
            }
        }

        public static string toTitle(string str)
        {
            return PrintTypes.ToPrintType(str).title;
        }
    }    

    public class PrintType
    {
        public readonly PType type;
        public readonly string name;
        public readonly string title;

        public override string ToString()
        {
            return name;
        }

        public PrintType(PType type, string title)
        {
            this.type = type;
            this.name = type.ToString();
            this.title = title;
            //PrintTypes.list.Add(this);
        }
    }


    //public class PrinterProps
    //{
    //    public string name;
    //    public bool[] types;
    //}

    public enum PrintEngine { Internal, AcrobatReader, DefaultPdfViwer };
    static class PrintEngines
    {
        static public PrintEngine type(string str)
        {
            switch (str)
            {
                //case("Internal"):
                //    return PrintEngine.Internal;
                case ("AcrobatReader"):
                    return PrintEngine.AcrobatReader;
                case ("DefaultPdfViwer"):
                    return PrintEngine.DefaultPdfViwer;
                default:
                    return PrintEngine.Internal;
            }
        }
    }
    /// <summary>
    /// Printer class. Automatically save changed property.
    /// </summary>
    public class Printer
    {
        public readonly string name;
        public PrintEngine printEngine = PrintEngine.Internal;
        public List<PType>types = new List<PType>();

        /// <summary>
        /// Set printing type value
        /// </summary>
        /// <param name="printingType">Printing type</param>
        /// <param name="val">Value</param>
        public void set(PType printingType, bool val)
        {
            //types[(int)printingType] = val;
            bool exists = types.Exists(v => v == printingType);
            if (val & !exists)
            {
                types.Add(printingType);
            }
            else if (!val & exists)
            {
                types.Remove(printingType);
            }
            Program.config.save();
        }

        public void print(string filePath, string documentName)
        {
            Process p;
            switch (printEngine)
            {
                case(PrintEngine.AcrobatReader):
                    p = Process.Start(
                        Registry.LocalMachine.OpenSubKey(
                            @"SOFTWARE\Microsoft\Windows\CurrentVersion" +
                            @"\App Paths\AcroRd32.exe").GetValue("").ToString(),
                            string.Format("/h /t \"{0}\" \"{1}\"", filePath, name)
                    );
                    break;
                case (PrintEngine.DefaultPdfViwer):
                    p = new Process();
                    p.StartInfo = new ProcessStartInfo()
                    {
                        CreateNoWindow = true,
                        Verb = "PrintTo",
                        WindowStyle = ProcessWindowStyle.Hidden,
                        FileName = filePath,
                        Arguments = "\"" + name + "\""
                    };
                    p.Start();
                    break;
                case (PrintEngine.Internal):
                    RawPrint.SendFileToPrinter(filePath, name, documentName);
                    break;
            }
        }

        /// <summary>
        /// Get printing type value
        /// </summary>
        /// <param name="printingType"></param>
        /// <returns>value</returns>
        public bool get(PType printingType)
        {
            //return types[(int)printingType];
            return types.Exists(v => v == printingType);
        }


        /// <summary>
        /// Create new printer.
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="types">Types states</param>
        /// <param name="r">Receipt sate</param>
        /// <param name="l">Label sate</param>
        public Printer(string name, List<PType> types = null)
        {
            this.name = name;
            if (types != null)
            {
                this.types = types;
            }
        }

        //public override bool Equals(System.Object obj)
        //{
        //    // If parameter is null return false.
        //    if (obj == null)
        //    {
        //        return false;
        //    }
        //    MessageBox.Show(obj.ToString());
        //    // If parameter cannot be cast to type return false.
        //    Printer p = (Printer)obj;
        //    if ((System.Object)p == null)
        //    {
        //        return false;
        //    }

        //    return name == p.name;
        //}

        //public bool Equals(Printer p)
        //{
        //    // If parameter is null return false:
        //    if ((object)p == null)
        //    {
        //        return false;
        //    }

        //    // Return true if the fields match:
        //    return  name == p.name;
        //}

        //public static bool operator == (Printer p1, Printer p2) {
        //    return p1.Equals(p2);
        //}

        //public static bool operator != (Printer p1, Printer p2) {
        //    return !p1.Equals(p2);
        //}

        //public override int GetHashCode()
        //{
        //    return name.GetHashCode();
        //}

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
