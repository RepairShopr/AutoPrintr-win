using System;
using System.Drawing;
using Newtonsoft.Json;
using System.Windows.Forms;

namespace AutoPrintr
{
    public class Skin
    {
        public skinWindow window;
        public skinTable table;
        public skinLog log;        
    }
    
    public class skinTable
    {
        public Color BackColor;
        public Font Font;
        public Color ForeColor;
        public Image BackgroundImage;
        public ImageLayout BackgroundImageLayout;
        public TableLayoutPanelCellBorderStyle CellBorderStyle;
    }

    public class skinWindow
    {
        public Color BackColor;
        public Font Font;
        public Color ForeColor;
        public Image BackgroundImage;
        public ImageLayout BackgroundImageLayout;
        public FormBorderStyle FormBorderStyle;
    }

    public class skinLog
    {
        public Color BackColor;
        public Font Font;
        public Color ForeColor;
    }

    public class skinCheckBox
    {
        public Color BackColor;
        public Color ForeColor;
        public Font Font;
        public Color BorderColor;
    }

}
