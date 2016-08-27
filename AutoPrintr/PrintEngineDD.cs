using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoPrintr
{
    class PrintEngineDD : ComboBox
    {
        public Printer printer;
        public PrintEngineDD(Printer printer)
        {
            this.printer = printer;
            DropDownStyle = ComboBoxStyle.DropDownList;
            foreach (var engine in Enum.GetValues(typeof(PrintEngine)))
            { 
                Items.Add(engine.ToString());
            }
            this.SelectedIndexChanged += PrintEngineDD_TextChanged;
            this.Text = printer.printEngine.ToString();
        }

        void PrintEngineDD_TextChanged(object sender, EventArgs e)
        {
            printer.printEngine = PrintEngines.type(Text);
            Program.config.save();
        }
    }
}
