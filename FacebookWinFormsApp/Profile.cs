using CefSharp.DevTools.Profiler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicFacebookFeatures
{
    public partial class Profile : UserControl
    {
        public Profile()
        {
            InitializeComponent();
            //label1.Text = LabelTitle1;
            //label2.Text = LabelTitle2;
            //label3.Text = LabelTitle3;
        }

        //public Label Label1 { get; }
        //public Label Label2 { get; }
        //public Label Label3 { get; }

        //public string LabelTitle1 { get; set; }
        //public string LabelTitle2 { get; set; }
        //public string LabelTitle3 { get; set; }

        public string LabelText1
        {
            get
            {
                return label1.Text;
            }
            set
            {
                //label1.Text = LabelTitle1 + ": " + value;
                label1.Text = value;
            }
        }

        public string LabelText2
        {
            get
            {
                return label2.Text;
            }
            set
            {
                //label2.Text = LabelTitle2 + ": " + value;
                label2.Text = value;
            }
        }

        public string LabelText3
        {
            get
            {
                return label3.Text;
            }
            set
            {
                //label3.Text = LabelTitle3 + ": " + value;
                label3.Text = value;
            }
        }

        //public Font LabelFont1
        //{
        //    get
        //    {
        //        return label1.Font;
        //    }
        //    set
        //    {
        //        label1.Font = value;
        //    }
        //}

        //public Font LabelFont2
        //{
        //    get
        //    {
        //        return label2.Font;
        //    }
        //    set
        //    {
        //        label2.Font = value;
        //    }
        //}

        //public Font LabelFont3
        //{
        //    get
        //    {
        //        return label3.Font;
        //    }
        //    set
        //    {
        //        label3.Font = value;
        //    }
        //}

        //public Color LabelColor1
        //{
        //    get
        //    {
        //        return label1.ForeColor;
        //    }
        //    set
        //    {
        //        label1.ForeColor = value;
        //    }
        //}

        //public Color LabelColor2
        //{
        //    get
        //    {
        //        return label2.ForeColor;
        //    }
        //    set
        //    {
        //        label2.ForeColor = value;
        //    }
        //}

        //public Color LabelColor3
        //{
        //    get
        //    {
        //        return label3.ForeColor;
        //    }
        //    set
        //    {
        //        label3.ForeColor = value;
        //    }
        //}

        //public Point LabelLocation1
        //{
        //    get
        //    {
        //        return label1.Location;
        //    }
        //    set
        //    {
        //        label1.Location = value;
        //    }
        //}

        //public Point LabelLocation2
        //{
        //    get
        //    {
        //        return label2.Location;
        //    }
        //    set
        //    {
        //        label2.Location = value;
        //    }
        //}

        //public Point LabelLocation3
        //{
        //    get
        //    {
        //        return label3.Location;
        //    }
        //    set
        //    {
        //        label3.Location = value;
        //    }
        //}

        public PictureBox PictureBox
        {
            get
            {
                return pictureBox1;
            }
        }

        //public void PaintLabels(PaintEventArgs e)
        //{
        //    e.Graphics.DrawString(label1.Text, label1.Font, new SolidBrush(label1.ForeColor), label1.Location);
        //    e.Graphics.DrawString(label2.Text, label2.Font, new SolidBrush(label2.ForeColor), label2.Location);
        //    e.Graphics.DrawString(label3.Text, label3.Font, new SolidBrush(label3.ForeColor), label3.Location);
        //}

        //protected override void OnPaint(PaintEventArgs e)
        //{
        //    base.OnPaint(e);
        //    e.Graphics.DrawString(label1.Text, label1.Font, new SolidBrush(label1.ForeColor), label1.Location);
        //    e.Graphics.DrawString(label2.Text, label2.Font, new SolidBrush(label2.ForeColor), label2.Location);
        //    e.Graphics.DrawString(label3.Text, label3.Font, new SolidBrush(label3.ForeColor), label3.Location);
        //}
    }
}
