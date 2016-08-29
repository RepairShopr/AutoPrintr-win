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
using WinFormAnimation;

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
        public EventHandler Click;

        public string onText = "On";
        public string offText = "Off";

        public int onTopColor = 0x51a351;
        public int onBottomColor = 0x62c462;
        public int onTextColor = 0xFFFFFF;
        public int onBorderColor = 0xDDDDDD;

        public int middleTopColor = 0xFFFFFF;
        public int middleBottomColor = 0xe6e6e6;
        public int middleTextColor = 0xFFFFFF;
        public int middleBorderColor = 0xDDDDDD;

        public int offTopColor = 0xe6e6e6;
        public int offBottomColor = 0xFFFFFF;
        public int offTextColor = 0x000000;
        public int offBorderColor = 0xDDDDDD;

        public GradientLabel leftLabel;
        public GradientLabel middleLabel;
        public GradientLabel rightLabel;

        /// <summary>
        /// Time of animation in ms
        /// </summary>
        private ulong animationtime = 500; 

        bool _checked = false;

        int h = 0;
        int w = 0;
        /// <summary>
        /// Left offscreen point (hidden)
        /// </summary>
        Float2D p1;
        /// <summary>
        /// Left point (start)
        /// </summary>
        Float2D p2;
        /// <summary>
        /// Middle point
        /// </summary>
        Float2D p3;
        /// <summary>
        /// Right offscreen point (hidden)
        /// </summary>
        Float2D p4;

        Animator2D animLeftOff;
        Animator2D animMiddleOff;
        Animator2D animRightOff;
        Animator2D animLeftOn;
        Animator2D animMiddleOn;
        Animator2D animRightOn;

        DateTime lastClick;

        public bool Checked
        {
            get { return _checked; }
            set {
                _checked = value;
                if (value) { setOn(); } else { setOff(); } 
            }
        }

        void init(bool state = false)
        {
            h = Height;
            w = Width / 2;
            p1 = new Float2D(-w, 0);
            p2 = new Float2D(0, 0);
            p3 = new Float2D(w - 1, 0);
            p4 = new Float2D(w * 2, 0);

            Margin = new Padding(3);

            leftLabel = new cbsLabel(
                color(onTopColor),
                color(onBottomColor),
                color(onTextColor),
                color(onBorderColor),
                h, w, onText
            );

            middleLabel = new cbsLabel(
                color(middleTopColor),
                color(middleBottomColor),
                color(middleTextColor),
                color(middleBorderColor),
                h, w
            );

            rightLabel = new cbsLabel(
                color(offTopColor),
                color(offBottomColor),
                color(offTextColor),
                color(offBorderColor),
                h, w, offText
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

            Controls.Add(leftLabel);
            Controls.Add(middleLabel);
            Controls.Add(rightLabel);

            leftLabel.Click += onClick;
            middleLabel.Click += onClick;
            rightLabel.Click += onClick;

            animLeftOff = new Animator2D(new Path2D(p2, p1, animationtime));
            animMiddleOff = new Animator2D(new Path2D(p3, p2, animationtime));
            animRightOff = new Animator2D(new Path2D(p4, p3, animationtime));

            animLeftOn = new Animator2D(new Path2D(p1, p2, animationtime));
            animMiddleOn = new Animator2D(new Path2D(p2, p3, animationtime));
            animRightOn = new Animator2D(new Path2D(p3, p4, animationtime));            
        }

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
            tt.SetToolTip(leftLabel, text);
            tt.SetToolTip(middleLabel, text);
            tt.SetToolTip(rightLabel, text);
        }


        void animOff()
        {
            animLeftOff.Play(leftLabel, Animator2D.KnownProperties.Location);
            animMiddleOff.Play(middleLabel, Animator2D.KnownProperties.Location);
            animRightOff.Play(rightLabel, Animator2D.KnownProperties.Location);
        }

        void animOn()
        {
            animLeftOn.Play(leftLabel, Animator2D.KnownProperties.Location);
            animMiddleOn.Play(middleLabel, Animator2D.KnownProperties.Location);
            animRightOn.Play(rightLabel, Animator2D.KnownProperties.Location);
        }

        void setOn()
        {
            leftLabel.Left = (int)p2.X;
            middleLabel.Left = (int)p3.X;
            rightLabel.Left = (int)p4.X;
        }

        void setOff()
        {
            leftLabel.Left = (int)p1.X;
            middleLabel.Left = (int)p2.X;
            rightLabel.Left = (int)p3.X;
        }

        void animate()
        {
            if (_checked)
            {
                animOff();
            }
            else
            {
                animOn();                    
            }
            _checked = !_checked;
        }

        void animate(bool flag)
        {
            if (flag)
            {
                animOff();
            }
            else
            {
                animOn();
            }
            _checked = !flag;
        }

        void onClick(object sender, System.EventArgs e)
        {
            if (lastClick == null)
            {
                animate();
                lastClick = DateTime.Now;
                if (Click != null)
                {
                    Click(this, new EventArgs());
                }
            }
            else if ((DateTime.Now - lastClick).TotalMilliseconds > animationtime)
            {
                animate();
                lastClick = DateTime.Now;
                if (Click != null)
                {
                    Click(this, new EventArgs());
                }
            }                       
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
