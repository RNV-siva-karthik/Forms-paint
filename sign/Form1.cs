using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton;
using ComponentFactory.Krypton.Toolkit;

namespace sign
{
    public partial class Form1 :KryptonForm
    {
        PointF[] pt = new PointF[10000];
       int i=0;
        int j = 0;
        Bitmap bmp;
        Color color = Color.Black;
        int pensize=2;
        bool check = false;
        public Form1()
        {
            InitializeComponent();
             bmp = new Bitmap(panel1.Size.Width, panel1.Size.Height);
            trackBar1.Value = 2;
        }

        private void panel1_DoubleClick(object sender, EventArgs e)
        {
            timer1.Stop();
            Array.Clear(pt,0,pt.Length);
            i = 1;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            float cx = Cursor.Position.X;
            float cy = Cursor.Position.Y;
            float fx = this.Location.X;
            float fy= this.Location.Y;
            Pen p = new Pen(color, pensize);
            Pen p2= new Pen(color:Color.White, pensize);
            pt[i]=new PointF(cx-fx-50,cy-fy-47);
            Graphics g=panel1.CreateGraphics();
            int q = i;
            if (q == 0)
            {
                if (check)
                {
                    g.DrawCurve(p2, pt, 1, q + 2, 0F);
                }
                else
                {
                    g.DrawCurve(p, pt, 1, q + 2, 0F);
                }
            }
            else
            {
                if (check)
                {
                    g.DrawCurve(p2, pt, 0, q, 0F);
                }
                else
                g.DrawCurve(p, pt, 0, q, 0F);
            }
            i++;
        }
        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            timer1.Start();
        }
        
        private void Drawpoints(object sender, PaintEventArgs e)
        {
            //e.Graphics.DrawImage(bmp, Point.Empty);
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            timer1.Stop();
            Array.Clear(pt, 0, pt.Length);
            i = 0;
            j = 1;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Graphics g = panel1.CreateGraphics();
            g.Clear(Color.White);
            panel1.Cursor = Cursors.Cross;
            check = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromImage(bmp);
            if (saveFileDialog1.ShowDialog()==DialogResult.OK)
            {
                string file=saveFileDialog1.FileName;
                panel1.DrawToBitmap(bmp, new Rectangle(0,0,bmp.Width,bmp.Height));
                //panel1.DrawImage(bmp, new Rectangle(0,0,bmp.Width,bmp.Height));
                bmp.Save(file);
                //project needs to be completed as to how to save the sign into an image to use it.
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(colorDialog1.ShowDialog() == DialogResult.OK)
            {
               color = colorDialog1.Color;
            }
            button3.BackColor = color;
            
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            pensize = trackBar1.Value;
        }

        private void panel1_MouseClick_1(object sender, MouseEventArgs e)
        {
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!check)
            {
                panel1.Cursor = Cursors.No;
                check = true;
            }
            else
            {
                panel1.Cursor=Cursors.Cross;
                check = false;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel1.Cursor = Cursors.Cross;
            check = false;
        }
    }
}
