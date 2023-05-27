using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace NuevaMed
{
    public partial class Loading : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRect
            (
                int leftRect,
                int topRect,
                int rightRect,
                int bottomRect,
                int widthEllipse,
                int heightEllipse
                );
        public Loading()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRect(0, 0, Width, Height, 20, 20));
        }
        int counter = 0;
        int len = 5;
        string text;
        int startpoint = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            startpoint += 32;
            panel1.Width = startpoint;


            if (panel1.Width >= 630)
            {
                panel1.Width = startpoint;

                timer1.Stop();
                Drlogin fm2 = new Drlogin();
                fm2.Show();
                this.Hide();


            }
            lb1.Text = text.Substring(0, counter);
            counter++;
            if (counter > len)
            {
                counter = 0;
                //timer2.Stop();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            text = lb1.Text;
            len = text.Length;
            lb1.Text = "";
            timer1.Start();
            
               
               // timer2.Start();
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void timer2_Tick(object sender, EventArgs e)
        {
           /* lb1.Text = text.Substring(0, counter);
            counter++;
            if (counter > len)
            {
                counter = 0; 
                //timer2.Stop();
            }
            * */
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        }
    }

