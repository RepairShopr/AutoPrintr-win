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
        Dictionary<string, int> rlist = new Dictionary<string, int>()
        {
             {"None", 0}
        };
        /// <summary>
        /// Create new combo box for selected printer
        /// </summary>
        /// <param name="printer"></param>
        public RegisterDD(Printer printer, List<LoginServer.Register> rlist)
        {
            this.printer = printer;

            DropDownStyle = ComboBoxStyle.DropDownList;
            Items.Add("None");
            this.Text = "None";
            foreach (LoginServer.Register r in rlist)
            {
                this.rlist.Add(r.name, r.id);
                Items.Add(r.name);
            }

            // Setting handler for change event
            this.SelectedIndexChanged += RegisterDD_TextChanged;

            AutoSize = true;
            Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
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
    }
}
