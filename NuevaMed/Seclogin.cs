using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

namespace NuevaMed
{
    public partial class Seclogin : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRect
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
       );



        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["nuevaDB"].ToString());

        private void Clear()
        {
            Uname.Text = "";
            Pass.Text = "";
        }

        public Seclogin()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRect(0, 0, Width, Height, 20, 20));
        }

        private void Secretary_login_Load(object sender, EventArgs e)
        {

        }

        private void Uname_TextChanged(object sender, EventArgs e)
        {

        }
         private void button1_Click(object sender, EventArgs e)
        {
             Application.Exit();
        }
         private void button6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var username = Uname.Text;
            var password = Pass.Text;

            string query = "Select * from Login where Username = '" + username + "' AND Password = '" + password + "' ";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();     //OCCUPATION BIT 
            if (dr.Read() == true)
            {
                if (username == "Cardio" || username == "Oto" || username == "Optha" || username == "Admin")
                {
                    MessageBox.Show("Invalid Credentials");
                    Clear();
                }

                else
                {
                    Global.username = username;
                    Secdashboard prod = new Secdashboard();
                    prod.Show();
                    this.Hide();

                }
            }
            else{
                MessageBox.Show("Invalid Username or Password ");
                Clear();
            }
            con.Close();
    }
     private void drlogin_Load(object sender, EventArgs e)
        {

        }

        private void Select_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new Drlogin().Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
                if (Pass.PasswordChar == '*')
                {
                    button4.BringToFront();
                    Pass.PasswordChar = '\0';
                }
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            button8.Visible = true;
            button9.Visible = false;
            Pass.PasswordChar = '•';
        }

        private void button8_Click(object sender, EventArgs e)
        {
            button8.Visible = false;
            button9.Visible = true;
            Pass.PasswordChar = '\0';
        }

        private void Pass_TextChanged(object sender, EventArgs e)
        {
            if (button8.Visible == true)
                Pass.PasswordChar = '•';
            else if (button9.Visible == true)
                Pass.PasswordChar = '\0';
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {

            adminLogin prod = new adminLogin();
            prod.Show();
            this.Hide();
        }

        private void button7_MouseHover(object sender, EventArgs e)
        {
            //button7.BackColor = Color.
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Opacity == 1)
                timer1.Stop();
            Opacity += .2;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void button7_MouseMove(object sender, MouseEventArgs e)
        {
            button7.ForeColor = Color.Black; 
        }

        private void button7_MouseLeave(object sender, EventArgs e)
        {
            button7.ForeColor = Color.Gainsboro; 
        }

        }
       }
   
