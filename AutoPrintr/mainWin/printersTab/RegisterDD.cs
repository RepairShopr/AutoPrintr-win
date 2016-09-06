using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace AutoPrintr
{
    /// <summary>
    /// Custom combo box for selecting register associated with printer
    /// </summary>
    class RegisterDD : ComboBox
    {
        /// <summary>
        /// Printer for this combo box
        /// </summary>
        public Printer printer;
        Dictionary<string, int> rlist = new Dictionary<string, int>(){};
        /// <summary>
        /// Create new combo box for selected printer
        /// </summary>
        /// <param name="printer"></param>
        public RegisterDD(Printer printer, List<Register> rlist)
        {
            this.printer = printer;
            DropDownStyle = ComboBoxStyle.DropDownList;
            // Setting handler for change event
            AutoSize = true;
            Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            setItems(rlist);
            this.SelectedIndexChanged += RegisterDD_TextChanged;
        }

        /// <summary>
        /// Combo box change event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void RegisterDD_TextChanged(object sender, EventArgs e)
        {
            printer.register = rlist[this.Text];    
            Program.config.save();
        }

        public void setItems(List<Register> rlist)
        {           
            Items.Clear();
            Items.Add("None");
            this.rlist.Clear();
            this.rlist.Add("None", 0);
            Text = "None";
            foreach (Register r in rlist)
            {
                this.rlist.Add(r.name, r.id);
                Items.Add(r.name);
                //if (printer.register != 0 & printer.register == r.id)
                //{

                //}
            }
        }
    }
}
