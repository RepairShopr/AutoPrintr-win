using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace WinPrintr
{
    /// <summary>
    /// Static class for printers management
    /// </summary>
    static class Printers
    {
        /// <summary>
        /// List of printers with properties. Each printer automatically save changed property.
        /// </summary>
        public static List<Printer> list;

        /// <summary>
        /// Printers config file path or name.
        /// </summary>
        public static string config = "printers.json";

        /// <summary>
        /// Load printers from file.
        /// </summary>
        /// <returns>Printer[]</returns>
        private static Printer[] load()
        {
            Printer[] arr = null;
            if (File.Exists(config))
            {
                //try 
                //{	        
		        arr = JsonConvert.DeserializeObject<Printer[]>(File.ReadAllText( config ));
                //}
                //catch (Exception e)
                //{
                //    throw e;
                //}    
            }
            if (arr == null)
            {
                arr = new Printer[0];
            }
            return arr;
        }

        /// <summary>
        /// Save printers to config file.
        /// </summary>
        public static void save()
        {
            File.WriteAllText(config, JsonConvert.SerializeObject(list));
        }

        /// <summary>
        /// Find existing system printers; load printers grom file; merge 2 lists.
        /// </summary>
        /// <returns></returns>
        public static List<Printer> get()
        {
            List<Printer> pList = new List<Printer>();

            // Loading printers config
            Printer[] savedPrinters = load();

            // Getting available printers
            bool notLoaded;
            foreach (string printerName in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                // If system printer is have saved config - then use this config
                notLoaded = true;
                foreach (Printer printer in savedPrinters)
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
            list = pList;
            save();
            return pList;
        }
    }

    /// <summary>
    /// Printing types
    /// </summary>
    public enum PType : byte { fullSize, receipt, label }
        
    /// <summary>
    /// Printer class. Automatically save changed property.
    /// </summary>
    public class Printer
    {
        public readonly string name;

        private bool _fullsize;
        public bool fullsize
        {
            get { return _fullsize; }
            set
            {
                _fullsize = value;
                Printers.save();
            }

        }

        private bool _receipt;
        public bool receipt
        {
            get { return _receipt; }
            set
            {
                _receipt = value;
                Printers.save();
            }

        }

        private bool _label;
        public bool label
        {
            get { return _label; }
            set
            {
                _label = value;
                Printers.save();
            }

        }

        /// <summary>
        /// Set printing type value
        /// </summary>
        /// <param name="printingType">Printing type</param>
        /// <param name="val">Value</param>
        public void set(PType printingType, bool val)
        {
            switch (printingType)
            {
                case PType.fullSize:
                    fullsize = val;
                    break;
                case PType.receipt:
                    receipt = val;
                    break;
                case PType.label:
                    label = val;
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
            switch (printingType)
            {
                case PType.fullSize:
                    return _fullsize;
                case PType.receipt:
                    return _receipt;
                case PType.label:
                    return _label;
                default:
                    return false;
            }
        }


        /// <summary>
        /// Create new printer.
        /// </summary>
        /// <param name="n">Name</param>
        /// <param name="f">Fullsize sate</param>
        /// <param name="r">Receipt sate</param>
        /// <param name="l">Label sate</param>
        public Printer(string n, bool f=false, bool r=false, bool l=false)
        {
            name = n;
            _fullsize = f;
            _receipt = r;
            _label = l;
        }

        public override bool Equals(System.Object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            // If parameter cannot be cast to type return false.
            Printer p = (Printer)obj;
            if ((System.Object)p == null)
            {
                return false;
            }

            return name == p.name;
        }

        public bool Equals(Printer p)
        {
            // If parameter is null return false:
            if ((object)p == null)
            {
                return false;
            }

            // Return true if the fields match:
            return  name == p.name;
        }

        public static bool operator == (Printer p1, Printer p2) {
            return p1.Equals(p2);
        }

        public static bool operator != (Printer p1, Printer p2) {
            return !p1.Equals(p2);
        }

        public override int GetHashCode()
        {
            return name.GetHashCode();
        }

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
