using System;
//using System.Collections.Generic;
//using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
//using System.Data;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
//using WinFormAnimation;

namespace AutoPrintr
{
    /// <summary>
    /// Custom checkbox of slider type with gradients and border
    /// </summary>
    public partial class CheckBoxSlider : UserControl
    {
        /// <summary>
        /// Click event
        /// </summary>
        public new EventHandler Click;

        /// <summary>
        /// State change event
        /// </summary>
        public EventHandler Changed;

        public static string onText = "On";
        public static string offText = "Off";

        public static int onTopColor = 0x51a351;
        public static int onBottomColor = 0x62c462;
        public static int onTextColor = 0xFFFFFF;
        public static int onBorderColor = 0xDDDDDD;

        public static int middleTopColor = 0xFFFFFF;
        public static int middleBottomColor = 0xe6e6e6;
        public static int middleTextColor = 0xFFFFFF;
        public static int middleBorderColor = 0xDDDDDD;

        public static int offTopColor = 0xe6e6e6;
        public static int offBottomColor = 0xFFFFFF;
        public static int offTextColor = 0x000000;
        public static int offBorderColor = 0xDDDDDD;

        public GradientLabel labelOn;
        public GradientLabel labelMiddle;
        public GradientLabel labelOff;

        /// <summary>
        /// Time of animation in ms
        /// </summary>
        //private ulong animationtime = 200; 

        bool _checked = false;

        int h = 0;
        int w = 0;
        ///// <summary>
        ///// Left offscreen point (hidden)
        ///// </summary>
        //Float2D p1;
        ///// <summary>
        ///// Left point (start)
        ///// </summary>
        //Float2D p2;
        ///// <summary>
        ///// Middle point
        ///// </summary>
        //Float2D p3;
        ///// <summary>
        ///// Right offscreen point (hidden)
        ///// </summary>
        //Float2D p4;

        //Animator2D animLeftOff;
        //Animator2D animMiddleOff;
        //Animator2D animRightOff;
        //Animator2D animLeftOn;
        //Animator2D animMiddleOn;
        //Animator2D animRightOn;

        //DateTime lastClick;
        //SafeInvoker animDone;

        Point p1;
        Point p2;
        Point p3;
        Point p4;
        public bool Checked
        {
            get { return _checked; }
            set {
                _checked = value;
                if (value) { setOn(); } else { setOff(); }
                if (Changed != null) { Changed(this, new EventArgs()); }
            }
        }

        void init(bool state = false)
        {
            h = Height;
            w = Width / 2;
            p1 = new Point(-w, 0);
            p2 = new Point(0, 0);
            p3 = new Point(w - 1, 0);
            p4 = new Point(w * 2, 0);
            //p1 = new Float2D(-w, 0);
            //p2 = new Float2D(0, 0);
            //p3 = new Float2D(w-1, 0);
            //p4 = new Float2D(w * 2, 0);

            Margin = new Padding(3);

            labelOn = new cbsLabel(
                color(onTopColor),
                color(onBottomColor),
                color(onTextColor),
                color(onBorderColor),
                h, w, onText
            );

            labelMiddle = new cbsLabel(
                color(middleTopColor),
                color(middleBottomColor),
                color(middleTextColor),
                color(middleBorderColor),
                Height, Width
            );

            labelOff = new cbsLabel(
                color(offTopColor),
                color(offBottomColor),
                color(offTextColor),
                color(offBorderColor),
                h, w+1, offText
            );

            if (state)
            {
                setOn();
            }
            else
            {
                setOff();
            }
            _checked = state;

            Controls.Add(labelOn);
            Controls.Add(labelOff);
            // Middle will be as background if we add it last
            Controls.Add(labelMiddle);

            labelOn.Click += onClick;
            labelMiddle.Click += onClick;
            labelOff.Click += onClick;

            //animLeftOff = new Animator2D(new Path2D(p2, p1, animationtime));
            //animMiddleOff = new Animator2D(new Path2D(p3, p2, animationtime));
            //animRightOff = new Animator2D(new Path2D(p4, p3, animationtime));

            //animLeftOn = new Animator2D(new Path2D(p1, p2, animationtime));
            //animMiddleOn = new Animator2D(new Path2D(p2, p3, animationtime));
            //animRightOn = new Animator2D(new Path2D(p3, p4, animationtime));

            //animDone = new SafeInvoker(onAnimDone);
        }

        //void onAnimDone()
        //{
        //    if (_checked)
        //    {
        //        setOn();
        //    }
        //    else
        //    {
        //        setOff();
        //    }
        //}

        public CheckBoxSlider()
        {
            InitializeComponent();
            init();
        }

        public CheckBoxSlider(bool state)
        {
            InitializeComponent();
            init(state);
        }

        /// <summary>
        /// Set tooltip for this checkbox
        /// </summary>
        /// <param name="tt"></param>
        /// <param name="text"></param>
        public void SetToolTip(ToolTip tt, string text)
        {
            tt.SetToolTip(labelOn, text);
            tt.SetToolTip(labelMiddle, text);
            tt.SetToolTip(labelOff, text);
        }


        //void animOff()
        //{
        //    animLeftOff.Play(leftLabel, Animator2D.KnownProperties.Location);
        //    animMiddleOff.Play(middleLabel, Animator2D.KnownProperties.Location);
        //    animRightOff.Play(rightLabel, Animator2D.KnownProperties.Location);
        //}

        //void animOn()
        //{
        //    animLeftOn.Play(leftLabel, Animator2D.KnownProperties.Location);
        //    animMiddleOn.Play(middleLabel, Animator2D.KnownProperties.Location);
        //    animRightOn.Play(rightLabel, Animator2D.KnownProperties.Location);
        //}

        void setOn()
        {
            labelOn.Left = p2.X;
            //middleLabel.Left = p3.X;
            labelOff.Left = p4.X;
        }

        void setOff()
        {
            labelOn.Left = p1.X;
            //middleLabel.Left = p2.X;
            labelOff.Left = p3.X;
        }

        //void animate()
        //{
        //    if (_checked)
        //    {
        //        setOff();
        //    }
        //    else
        //    {
        //        setOn();                    
        //    }
        //    _checked = !_checked;
        //}

        //void animate(bool flag)
        //{
        //    if (flag)
        //    {
        //        animOff();
        //    }
        //    else
        //    {
        //        animOn();
        //    }
        //    _checked = !flag;
        //}

        void onClick(object sender, System.EventArgs e)
        {
            if (_checked)
            {
                setOff();
            }
            else
            {
                setOn();
            }
            _checked = !_checked;
            if (Changed != null) { Changed(this, new EventArgs()); }
            if (Click != null) { Click(this, new EventArgs()); }
            //if (lastClick == null)
            //{
            //    animate();
            //    lastClick = DateTime.Now;
            //    if (Click != null)
            //    {
            //        Click(this, new EventArgs());
            //    }
            //}
            //else if ((DateTime.Now - lastClick).TotalMilliseconds > animationtime)
            //{
            //    animate();
            //    lastClick = DateTime.Now;
            //    if (Click != null)
            //    {
            //        Click(this, new EventArgs());
            //    }
            //}                       
        }

        static Color color(int color)
        {
            byte R = (byte)((color >> 16) & 0xFF);
            byte G = (byte)((color >> 8) & 0xFF);
            byte B = (byte)((color) & 0xFF);
            return Color.FromArgb(R, G, B);
        }

        class cbsLabel : GradientLabel 
        {
            public cbsLabel(
                Color topColor, 
                Color bottomColor, 
                Color textColor,
                Color borderColor,
                int h,
                int w,
                string text = "" )
            {
                this.topColor = topColor;
                this.bottomColor = bottomColor;
                this.ForeColor = textColor;
                this.borderColor = borderColor;
                Text = text;
                AutoSize = false;
                Width = w;
                Height = h;
                Padding = new Padding(2);
                TextAlign = ContentAlignment.MiddleCenter;
            }
            
        }

    }


    public class GradientLabel : Label
    {
        public Color topColor;
        public Color bottomColor;
        public Color borderColor;

        public GradientLabel(
            Color topColor, 
            Color bottomColor, 
            Color textColor, 
            Color borderColor,
            string text = "" )
        {                
            this.topColor = topColor;
            this.bottomColor = bottomColor;
            this.ForeColor = textColor;
            this.borderColor = borderColor;
            Text = text;
        }
        public GradientLabel() { }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            using (
                LinearGradientBrush brush = 
                    new LinearGradientBrush(
                        this.ClientRectangle,
                        topColor,
                        bottomColor,
                        90F
                    )
            ) {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
            ControlPaint.DrawBorder(
                e.Graphics,
                this.ClientRectangle,
                borderColor,
                ButtonBorderStyle.Solid
            );
        }
    }
}
