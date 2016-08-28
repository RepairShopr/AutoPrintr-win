using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoPrintr
{
    /// <summary>
    /// Checkboxes list UI control
    /// </summary>
    [Serializable]
    public partial class CheckBoxList : UserControl
    {
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<CheckBoxListItem> Items = new List<CheckBoxListItem>();
        public event EventHandler SelectedChanged;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<CheckBoxListItem> Selected
        {
            get { return Items.FindAll(item => item.Checked); }
            set { }
        }

        private void item_CheckedChanged(object sender, EventArgs e)
        {
            SelectedChanged(this, e);
        }

        public CheckBoxListItem add()
        {
            CheckBoxListItem item = new CheckBoxListItem(Items.Count);
            item.CheckedChanged += item_CheckedChanged;
            return addItem(item);
        }

        public CheckBoxListItem add(string name)
        {
            CheckBoxListItem item = new CheckBoxListItem(Items.Count, name);
            item.CheckedChanged += item_CheckedChanged;
            return addItem(item);
        }

        public CheckBoxListItem add(string name, object userData)
        {
            CheckBoxListItem item = new CheckBoxListItem(Items.Count, name, userData);
            item.CheckedChanged += item_CheckedChanged;
            return addItem(item);
        }

        private CheckBoxListItem addItem(CheckBoxListItem item)
        {
            tableLayout.RowStyles.Clear();
            tableLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tableLayout.Controls.Add(item, 0, tableLayout.RowCount++);
            Items.Add(item);
            return item;
        }

        public void del(string name)
        {

        }

        public CheckBoxList()
        {
            InitializeComponent();
        }

        
    }
    /// <summary>
    /// CheckBox list item
    /// </summary>
    [Serializable]
    public class CheckBoxListItem : CheckBox
    {
        public object userData;
        public int id;

        public string name
        {
            get { return this.Text; }
            set { this.Text = value; }
        }
        public bool Selected
        {
            get { return Checked; }
            set { Checked = value; }
        }

        private void baseInit(int id)
        {
            Padding = new Padding(0, 0, 0, 0);
            Margin = new Padding(0, 0, 0, 0);
            this.id = id;
        }

        public CheckBoxListItem(int id)
        {
            baseInit(id);
        }

        public CheckBoxListItem(int id, string name)
        {
            baseInit(id);
            this.name = name;
        }

        public CheckBoxListItem(int id, object userData)
        {
            baseInit(id);
            this.userData = userData;
        }

        public CheckBoxListItem(int id, string name, object userData)
        {
            baseInit(id);
            this.name = name;
            this.userData = userData;
        }

    }

}
