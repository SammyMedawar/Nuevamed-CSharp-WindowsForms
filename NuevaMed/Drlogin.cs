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
    public partial class Drlogin : Form
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

        public Drlogin()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRect(0, 0, Width, Height, 20, 20));

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

        private void button5_Click(object sender, EventArgs e)
        {
            new Seclogin().Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Uname.Text = "";
            Pass.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
           

            var username = Uname.Text;

            string query = "Select * from Login where Username = @username AND Password = @password";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@username", Uname.Text);
            cmd.Parameters.AddWithValue("@password", Pass.Text);

            if (con.State != ConnectionState.Open)
                con.Open();

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read() == true)
            {
                if (username == "Recep")
                {
                    MessageBox.Show("Invalid Credentials");
                    Uname.Text = "";
                    Pass.Text = "";
                 
                }
                if (username == "Cardio" || username == "Optha" || username == "Oto")
                {
                    Global.username = username;
                    Drdashboard prod = new Drdashboard();
                    prod.Show();
                    this.Hide();
                }
                
                
            }
            else
            {
                MessageBox.Show("Invalid Username or Password");
                Uname.Text = "";
                Pass.Text = "";
            }

            if (con.State == ConnectionState.Open)
                con.Close();

            
        }

        private void drlogin_Load(object sender, EventArgs e)
        {
            
        }

        private void Select_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            button8.Visible = true;
            button7.Visible = false;
            Pass.PasswordChar = '•';
        }
        private void button8_Click(object sender, EventArgs e)
        {
            button8.Visible = false;
            button7.Visible = true;
            Pass.PasswordChar = '\0';
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
        }

        private void X_MouseMove(object sender, MouseEventArgs e)
        {
            X.Text = "X"; 
            X.Show(); 
        }

        private void X_MouseLeave(object sender, EventArgs e)
        {
        X.Text = ""; 
            X.Hide();
        }

        private void Pass_TextChanged(object sender, EventArgs e)
        {
            if (button8.Visible == true)
                Pass.PasswordChar = '•';
            else if (button7.Visible == true)
                Pass.PasswordChar = '\0';
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            if (Opacity == 1)
                timer1.Stop();
            Opacity += .2;
        }
    }
}
/*private void checkbxShowPas_CheckedChanged(object sender, EventArgs e)
{
    if (checkbxShowPas.Checked)
    {
        Pass.PasswordChar = '\0';
    }
    else
    {
        Pass.PasswordChar = '•';

    }
}*/
