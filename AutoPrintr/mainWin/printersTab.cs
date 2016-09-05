using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AutoPrintr
{
    public partial class mainWin
    {
        // -------------------------------------------------------------------
        /// <summary>
        /// Generate printers UI
        /// </summary>
        public void createPrintersUI()
        {
            printersTable.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;

            try
            {
                Printers.get();
            }
            catch (Exception e1)
            {
                MessageBox.Show("Error while loading printers local config. Config will be wiped. Error is: " + e1.Message.ToString());
                try
                {
                    Program.config.save();
                    Printers.get();
                }
                catch (Exception e2)
                {
                    MessageBox.Show("Great Scott! Unexpected error was expected and catched. Application will exit. Error is:" + e2.Message.ToString());
                    Application.Exit();
                }
            }

            // Clear column styles (in other case columns will have wrong width)
            printersTable.ColumnStyles.Clear();
            // Printers table header
            // Adding first column header
            printersTable.Controls.Add(new tabelLabel("Printers:"), 0, 0);

            int column = 1;
            foreach (Printer p in Program.config.printers)
            {
                printersTable.ColumnCount++;
                printersTable.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
                // Printer label
                printersTable.Controls.Add(new pLabel(p), column++, 0);

                // Printer qty
                //printersTable.ColumnCount++;
                //printersTable.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
                //column++;
            }

            printersTable.RowStyles.Clear();
            printersTable.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            int row = 1;
            column = 0;
            printersTable.RowCount++;
            printersTable.Controls.Add(new tabelLabel("Documents"), column++, row);
            foreach (Printer p in Program.config.printers)
            {
                printersTable.Controls.Add(new tabelLabel("Enabled | Quantity | Print from triggers"), column++, row);
            }

            foreach (DocumentType type in DocumentTypes.list)
            {
                column = 0;
                printersTable.RowCount++;
                printersTable.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                // Add header label
                printersTable.Controls.Add(new tabelLabel(type.title), column++, ++row);
                foreach (Printer p in Program.config.printers)
                {
                    printersTable.Controls.Add(new PrinterDocumentControl(type, p), column, row);
                    column++;
                }
            }

            column = 0;
            printersTable.RowCount++;
            printersTable.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            printersTable.Controls.Add(new tabelLabel("Print method"), column++, ++row);
            foreach (Printer p in Program.config.printers)
            {
                printersTable.Controls.Add(new PrintEngineDD(p), column++, row);
            }

            column = 0;
            printersTable.RowCount++;
            printersTable.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            printersTable.Controls.Add(new tabelLabel("Register"), column++, ++row);
            RegisterDD rdd;
            foreach (Printer p in Program.config.printers)
            {
                rdd = new RegisterDD(p, Program.config.registers);
                registersDD.Add(rdd);
                printersTable.Controls.Add(rdd, column++, row);
            }

            //
            // Adding rest columns and headers
            //int column = 1;
            //foreach (PrintType type in PrintTypes.list)
            //{
            //    // Add colmn
            //    printersTable.ColumnCount++;
            //    // Set column style
            //    printersTable.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            //    // Add header label
            //    printersTable.Controls.Add(new tabelLabel(type.title), column++, 0);
            //}

            //// Adding rows
            //int row = 1;

            //foreach (Printer p in Program.config.printers)
            //{
            //    // Row creating
            //    printersTable.RowCount++;
            //    printersTable.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            //    // Printer label
            //    printersTable.Controls.Add(new pLabel(p), 0, row);
            //    // Prnter checkboxes
            //    column = 1;
            //    foreach (PrintType t in PrintTypes.list)
            //    {
            //        printersTable.Controls.Add(new pCheckBox(t.type, p) { }, column, row);
            //    }
            //    row++; 
            //}

            //MessageBox.Show(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            //MessageBox.Show(Path.GetTempPath());
        }
    }
}
