using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using System.Windows.Forms;

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
                new PrintType( PType.tickets, "Tickets" ),
                new PrintType( PType.tickets_receipt, "Tickets Receipt" ),
                new PrintType( PType.intake_forms, "Intake Forms" ),
                new PrintType( PType.invoices, "Invoices" ),
                new PrintType( PType.receipt, "Receipt" ),
                new PrintType( PType.customer_labels, "Customer Labels" ),
                new PrintType( PType.asset_labels, "Asset Labels" ),
                new PrintType( PType.ticket_labels, "Ticket Labels" )
            };
            //PrintTypes.list = (List<PrintType>)PrintTypes.list.OrderBy(item => item.name);
            PrintTypes.list.Sort( (a, b) => a.name.CompareTo(b.name) );
        }
    }

    /// <summary>
    /// Printing types
    /// </summary>
    public enum PType : byte
    {
        tickets,
        tickets_receipt,
        intake_forms,
        invoices,
        receipt,
        customer_labels,
        asset_labels,
        ticket_labels
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

    /// <summary>
    /// Printer class. Automatically save changed property.
    /// </summary>
    public class Printer
    {
        public readonly string name;
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
            //Printers.save();
            Program.config.save();
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

        ///// <summary>
        ///// Debug function
        ///// </summary>
        ///// <returns></returns>
        //public override string ToString()
        //{
        //    return
        //        name + ": Fullsize = " + _fullsize +
        //        " / Receipt = " + _receipt +
        //        " / Label = " + _label;
        //}
    }


}
