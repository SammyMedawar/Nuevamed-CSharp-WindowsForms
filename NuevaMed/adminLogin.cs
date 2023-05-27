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
    public partial class adminLogin : Form
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

        private void clear()
        {
            Uname.Text = "";
            Pass.Text = "";
        }
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["nuevaDB"].ToString());
        public adminLogin()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRect(0, 0, Width, Height, 20, 20));
        }

        private void button8_Click(object sender, EventArgs e)
        {
            button8.Visible = false;
            button9.Visible = true;
            Pass.PasswordChar = '\0';
        }

        private void button9_Click(object sender, EventArgs e)
        {
            button8.Visible = true;
            button9.Visible = false;
            Pass.PasswordChar = '•';
        }

        private void Pass_TextChanged(object sender, EventArgs e)
        {
            if (button8.Visible == true)
                Pass.PasswordChar = '•';
            else if (button9.Visible == true)
                Pass.PasswordChar = '\0';
        }

        private void button3_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            

            string query = "Select * from Login where Username = @username AND Password = @password";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@username", Uname.Text);
            cmd.Parameters.AddWithValue("@password", Pass.Text);

            if (con.State != ConnectionState.Open)
                con.Open();

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read() == true)
            {
                if (Uname.Text == "Admin")
                {
                    Createacc prod = new Createacc();
                    prod.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid Credentials! Only Admins May Use This Tab");
                    clear();
                }

            }
            else
            {
                MessageBox.Show("Invalid Username or Password");
                clear();

            }

            if (con.State == ConnectionState.Open)
                con.Close();
        }

        private void adminLogin_Load(object sender, EventArgs e)
        {
            
        }

        private void Back_Click(object sender, EventArgs e)
        {
            Seclogin prod = new Seclogin();
            prod.Show();
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Opacity == 1)
                timer1.Stop();
            Opacity += .2;
        }
        
    }
}
