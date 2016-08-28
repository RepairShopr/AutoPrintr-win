using System;
using System.Windows.Forms;

namespace AutoPrintr
{
    /// <summary>
    /// Custom combo box for selecting print engine for printer
    /// </summary>
    class PrintEngineDD : ComboBox
    {
        /// <summary>
        /// Printer for this combo box
        /// </summary>
        public Printer printer;
        /// <summary>
        /// Create new combo box for selected printer
        /// </summary>
        /// <param name="printer"></param>
        public PrintEngineDD(Printer printer)
        {
            this.printer = printer;
            DropDownStyle = ComboBoxStyle.DropDownList;
            // Get list of engines
            foreach (var kv in PrintEngines.list)
            { 
                Items.Add(kv.Key);
            }
            // Setting handler for change event
            this.SelectedIndexChanged += PrintEngineDD_TextChanged;
            // Set current value as printer engine name
            this.Text = printer.printEngine.name;
        }

        /// <summary>
        /// Print engine combo box change event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void PrintEngineDD_TextChanged(object sender, EventArgs e)
        {
            // Change print engine to selected
            printer.printEngine = PrintEngines.find(Text);
            // Config save (no one like alerts and message boxes)
            Program.config.save();
        }
    }
}
