using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Common;

namespace PISGPRS
{
    public partial class ucSignalStrength : UserControl
    {
        public static Rectangle rec = new Rectangle(0, 23, 5, 7);
        public static Rectangle rec1 = new Rectangle(7, 15, 5, 15);
        public static Rectangle rec2 = new Rectangle(14, 10, 5, 20);
        public static Rectangle rec3 = new Rectangle(21, 5, 5, 25);
        public static Rectangle rec4 = new Rectangle(28, 0, 5, 30);

        //public static Rectangle rec = new Rectangle(0, 22,8, 7);
        //public static Rectangle rec1 = new Rectangle(7, 17, 8, 15);
        //public static Rectangle rec2 = new Rectangle(14, 12, 8, 20);
        //public static Rectangle rec3 = new Rectangle(21, 7, 8, 25);
        //public static Rectangle rec4 = new Rectangle(28, 2, 8, 30);

       public   Pen pen = new Pen(System.Drawing.SystemColors.ControlLightLight, 1);
       public  Brush brush = new SolidBrush(Color.Blue);
       public  Graphics g = null; 

        public ucSignalStrength()
        {
            InitializeComponent();
           
        }

        public void DrawSignals()
        {
            g = this.CreateGraphics();
                g.DrawRectangle(pen, rec);
                g.DrawRectangle(pen, rec1);
                g.DrawRectangle(pen, rec2);
                g.DrawRectangle(pen, rec3);
                g.DrawRectangle(pen, rec4);

                int sgStg = 0;
                if (!string.IsNullOrEmpty(Constants.GPRSSignalStrength))
                {
                    sgStg = Convert.ToInt32(Constants.GPRSSignalStrength);
                }

                if (sgStg != 0)
                { brush = new SolidBrush(Color.Blue); }
                if (sgStg > 1)
                {
                    g.FillRectangle(brush, rec);
                    g.FillRectangle(brush, rec1);
                }

                if (sgStg > 9)
                {
                    g.FillRectangle(brush, rec2);
                }

                if (sgStg > 14)
                {
                    g.FillRectangle(brush, rec3);
                }

                if (sgStg > 19)
                {
                    g.FillRectangle(brush, rec4);
                }

                //pen.Dispose();
                //brush.Dispose();
            
        }

        

        private void ucSignalStrength_Paint(object sender, PaintEventArgs e)
        {
 DrawSignals();
        }

        private void ucSignalStrength_Load(object sender, EventArgs e)
        {
            g = this.CreateGraphics();
        }
    }
}
