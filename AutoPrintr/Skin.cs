using System;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Windows.Forms;


namespace AutoPrintr
{
    public static class Skins
    {
        private static NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Skin configuration file
        /// </summary>
        public static string file = "skin.json";
        /// <summary>
        /// Skin configuration file
        /// </summary>
        public static string fileExample = "skin_example.json";
        /// <summary>
        /// Current skin configuration
        /// </summary>
        public static SkinConfig config;

        public static void save()
        {
            try
            {
                File.WriteAllText(file, JsonConvert.SerializeObject(config, Formatting.Indented));
            }
            catch (Exception err)
            {
                log.Error(err, "Can't save skin configuration. Details:\n{0}");
            }
        }

        public static void save(string filePath)
        {
            try
            {
                File.WriteAllText(filePath, JsonConvert.SerializeObject(config, Formatting.Indented));
            }
            catch (Exception err)
            {
                log.Error(err, "Can't save skin configuration.");
            }
        }

        public static void load()
        {
            try
            {
                if (File.Exists(file))
                {
                    string fileData = File.ReadAllText(file);
                    config = JsonConvert.DeserializeObject<SkinConfig>(
                        fileData,
                        new JsonSerializerSettings { // allow null values
                            NullValueHandling = NullValueHandling.Ignore
                        }
                    );
                    use();
                }

                if (!File.Exists(fileExample)) // If skin examplefile not exsist - create it
                {
                    init();
                    save(fileExample);
                }
            }
            catch (Exception err)
            {
                log.Error(err, "Can't load skin configuration.");
            }
        }

        //static List<Control> getControls()
        //{
        //    var controls = tools.GetAllControls(Program.window);
        //    List<Control> list = new List<Control>(){};
        //    string type;
        //    foreach(var c in controls){
        //        type = c.GetType().ToString();
        //        if (type == "AutoPrintr.pCheckBox") { continue; }
        //        list.Add(c);
        //    }
        //    return list;
        //}

        public static void init()
        {
            // Get all controls
            //var controls = getControls();
            var controls = tools.GetAllControls(Program.window);
            // Creating new skin
            config = new SkinConfig()
            {
                window = new Skin() { },
                CheckBox = new SkinCheckBox() { },
                all = new Skin() { },
                table = new SkinTable()
                {
                    RowHeader = new Skin(){},
                    ColumnHeader = new Skin(){}
                },
                controlsByType = new Dictionary<string, Skin>() { },
                controls = new List<SkinForControl>() { }
            };

            string type;
            // Now processing the controls
            foreach(var c in controls){
                type = c.GetType().ToString();
                if (
                    c.Name.Length == 0 |
                    type == "AutoPrintr.pCheckBox" |
                    type == "System.Windows.Forms.TableLayoutPanel"
                ) { 
                    continue; 
                }

                config.controls.Add(
                    new SkinForControl()
                    {
                        ControlName = c.Name,
                        ControlType = c.GetType().ToString(),
                        BackColor = tools.Color2RGB(c.BackColor),
                        TextColor = tools.Color2RGB(c.ForeColor),
                        Font = new skinFont()
                        {
                            Name = c.Font.Name,
                            Size = c.Font.Size,
                            Unit = c.Font.Unit,
                            Bold = c.Font.Bold,
                            Italic = c.Font.Italic,
                            Strikeout = c.Font.Strikeout,
                            Underline = c.Font.Underline
                        }
                    }
                );
            }
        }

        public static void use()
        {            
            //var controls = getControls();
            var controls = tools.GetAllControls(Program.window);
            if (config.window != null)
            {
                config.window.apply(Program.window);
            }

            string name;
            string type;
            //bool isEnabled;

            // Processsing all controls
            foreach (var control in controls)
            {
                name = control.Name;
                type = control.GetType().ToString();
                if (type == "AutoPrintr.pCheckBox")
                {
                    if (config.CheckBox != null)
                    {
                        config.CheckBox.apply(control);
                    }
                }
                else if (type == "System.Windows.Forms.TableLayoutPanel")
                {
                    if (config.table != null)
                    {
                        config.table.apply((TableLayoutPanel)control);
                    }                    
                } 
                else 
                {
                    //isEnabled = control.Enabled;
                    //control.Enabled = true;
                    if (config.all != null)
                    {
                        config.all.apply(control);
                    }
                    foreach (var kv in config.controlsByType)
                    {
                        if (kv.Key == type)
                        {
                            kv.Value.apply(control);
                        }
                    }

                    if (control.Name.Length != 0)
                    {
                        foreach (SkinForControl skin in config.controls)
                        {

                            if (skin.ControlName == name & skin.ControlType == type)
                            {
                                skin.apply(control);
                            }
                        }
                    }
                    //control.Enabled = isEnabled;
                }
                control.Invalidate();
            }
        }

        /// <summary>
        /// Skin configuration
        /// </summary>
        public class SkinConfig
        {
            public Skin window;
            public SkinCheckBox CheckBox;
            public SkinTable table;
            public Skin all = null;
            public Dictionary<string, Skin> controlsByType;
            public List<SkinForControl> controls;
        }

        /// <summary>
        /// Skin font
        /// </summary>
        public class skinFont
        {
            public string Name = "Microsoft Sans Serif";
            public float Size = 8.25F;
            public GraphicsUnit Unit = GraphicsUnit.Point;
            public bool Bold = false;
            public bool Italic = false;
            public bool Strikeout = false;
            public bool Underline = false;

            public void use(Control control)
            {
                if (Name != null | Size != 0)
                {
                    if (Name == null) { Name = control.Font.Name; }
                    if (Size == 0) { Size = control.Font.Size; }
                    if (Unit == 0) { Unit = control.Font.Unit; }
                    FontStyle fStyle = FontStyle.Regular;
                    if (Bold) { fStyle = fStyle | FontStyle.Bold; }
                    if (Italic) { fStyle = fStyle | FontStyle.Italic; }
                    if (Strikeout) { fStyle = fStyle | FontStyle.Strikeout; }
                    if (Underline) { fStyle = fStyle | FontStyle.Underline; }
                    control.Font = new Font(Name, Size, fStyle, Unit) { };
                }
            }
        }

        /// <summary>
        /// Base skin class
        /// </summary>
        [JsonObject(MemberSerialization.OptIn)]
        public class Skin
        {
            [JsonProperty]
            public string BackColor = "FFFFFF";
            [JsonProperty]
            public string TextColor = "000000";
            [JsonProperty]
            public skinFont Font = new skinFont() { };
            //public Image BackgroundImage;
            //public ImageLayout BackgroundImageLayout;
            //public TableLayoutPanelCellBorderStyle CellBorderStyle;

            /// <summary>
            /// Apply this skin to control
            /// </summary>
            /// <param name="control"></param>
            public void apply(Control control)
            {
                //control.Tag = this;
                if (BackColor != null) { control.BackColor = tools.RGB2Color(BackColor); }
                if (TextColor != null) { control.ForeColor = tools.RGB2Color(TextColor); }
                if (Font != null) { Font.use(control); }
            }
        }

        /// <summary>
        /// Skin class for processing items by name and type
        /// </summary>
        [JsonObject(MemberSerialization.OptIn)]
        public class SkinForControl : Skin
        {
            [JsonProperty]
            public string ControlName;
            [JsonProperty]
            public string ControlType;
            //public Image BackgroundImage;
            //public ImageLayout BackgroundImageLayout;
            //public TableLayoutPanelCellBorderStyle CellBorderStyle;

            /// <summary>
            /// Apply this skin to control
            /// </summary>
            /// <param name="control"></param>
            public new void apply(Control control)
            {
                base.apply(control);
            }
        }

        /// <summary>
        /// Skin for custom checkboxes
        /// </summary>
        [JsonObject(MemberSerialization.OptIn)]
        public class SkinCheckBox
        {
            [JsonProperty]
            public skinFont Font = new skinFont() { };
            [JsonProperty]
            public label on = new label()
            {
                TopColor = "51a351",
                BottomColor = "62c462",
                TextColor = "FFFFFF",
                BorderColor = "0xDDDDDD"
            };
            [JsonProperty]
            public label middle = new label()
            {
                TopColor = "FFFFFF",
                BottomColor = "e6e6e6",
                TextColor = "FFFFFF",
                BorderColor = "DDDDDD"
            };
            [JsonProperty]
            public label off = new label()
            {
                TopColor = "e6e6e6",
                BottomColor = "FFFFFF",
                TextColor = "000000",
                BorderColor = "DDDDDD"
            };

            public class label
            {
                public string TopColor;
                public string BottomColor;
                public string TextColor;
                public string BorderColor;

                public void apply(GradientLabel label)
                {
                    label.topColor = tools.RGB2Color(TopColor);
                    label.bottomColor = tools.RGB2Color(BottomColor);
                    label.ForeColor = tools.RGB2Color(TextColor);
                    label.borderColor = tools.RGB2Color(BorderColor);
                }
            }

            public void apply(Control control)
            {
                CheckBoxSlider c = (CheckBoxSlider)control;
                on.apply(c.labelOn);
                middle.apply(c.labelMiddle);
                off.apply(c.labelOff);
            }
        }

        [JsonObject(MemberSerialization.OptIn)]
        public class SkinTable
        {
            [JsonProperty]
            public Skin RowHeader;
            [JsonProperty]
            public Skin ColumnHeader;
            //public Skin odd;
            //public Skin even;
            [JsonProperty]
            public TableLayoutPanelCellBorderStyle Border = TableLayoutPanelCellBorderStyle.Single;
            //public class Border
            //{
            //    public TableLayoutPanelCellBorderStyle style = TableLayoutPanelCellBorderStyle.Single;
            //}

            public void apply(TableLayoutPanel table)
            {
                //int rowsCount = table.RowCount;
                //int ColumnCount = table.ColumnCount;
                foreach (Control control in table.Controls)
                {                 
                    if (table.GetRow(control) == 0)
                    {
                        RowHeader.apply(control);
                    }
                    else if (table.GetColumn(control) == 0)
                    {
                        ColumnHeader.apply(control);
                    }
                }
            }
        }







        ///// <summary>
        ///// Skin base for controls
        ///// </summary>
        //public class Skin
        //{
        //    public string BackColor = "FFFFFF";
        //    public string FontColor = "000000";
        //    public skinFont Font = new skinFont() { };
        //    /// <summary>
        //    /// Initialize skin
        //    /// </summary>
        //    /// <param name="control"></param>
        //    public void init(Control control)
        //    {
        //        control.Tag = this;
        //        if (BackColor != null) { control.BackColor = tools.RGB2Color(BackColor); }
        //        if (FontColor != null) { control.ForeColor = tools.RGB2Color(FontColor); }
        //        if (Font != null) { Font.use(control); }
        //    }
        //    //public Skin(){}
        //}

        //[JsonObject(MemberSerialization.OptIn)]
        //public class SkinForControl : Skin
        //{
        //    [JsonProperty]
        //    public string ControlName = null;
        //    [JsonProperty]
        //    public string ControlType = null;
        //    //[JsonProperty]
        //    //public string BackColor = "FFFFFF";
        //    //[JsonProperty]
        //    //public string FontColor = "000000";
        //    //[JsonProperty]
        //    //public skinFont Font = new skinFont() { };

        //    /// <summary>
        //    /// Initialize this skin
        //    /// </summary>
        //    /// <param name="control"></param>
        //    public new void init(Control control)
        //    {
        //        base.init(control);                
        //    }
        //    //[JsonConstructor]
        //    //public SkinSimple(){} 
        //}






        //[JsonObject(MemberSerialization.OptIn)]
        //public class SkinGradient : Skin
        //{
        //    [JsonProperty]
        //    public string ControlName = null;
        //    [JsonProperty]
        //    public string ControlType = null;
        //    [JsonProperty]
        //    public string TopColor = "FFFFFF";
        //    [JsonProperty]
        //    public string BottomColor = "D4D4D4";
        //    [JsonProperty]
        //    public string BorderColor = "A8A8A8";
        //    [JsonProperty]
        //    public string FontColor = "000000";
        //    [JsonProperty]
        //    public skinFont Font = new skinFont() { };

        //    public new void init(Control control)
        //    {
        //        if (FontColor != null) { control.ForeColor = tools.RGB2Color(FontColor); }
        //        if (Font != null) { Font.use(control);  }
        //    }

        //    void OnPaintBackground(PaintEventArgs e)
        //    {
        //        using (
        //            LinearGradientBrush brush =
        //                new LinearGradientBrush(
        //                    this.ClientRectangle,
        //                    topColor,
        //                    bottomColor,
        //                    90F
        //                )
        //        )
        //        {
        //            e.Graphics.FillRectangle(brush, this.ClientRectangle);
        //        }
        //        ControlPaint.DrawBorder(
        //            e.Graphics,
        //            this.ClientRectangle,
        //            borderColor,
        //            ButtonBorderStyle.Solid
        //        );
        //    }
        //}
    }
}
