using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinPrintr
{
    public partial class mainWin : Form
    {
        public mainWin()
        {
            InitializeComponent();
            this.printersTable.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            
        }
    }
}
