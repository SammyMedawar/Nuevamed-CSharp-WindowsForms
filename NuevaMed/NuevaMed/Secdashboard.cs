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
using System.Data.SqlClient;

namespace NuevaMed
{
    public partial class Secdashboard : Form
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
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MYDBD"].ToString());
       

        public Secdashboard()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRect(0, 0, Width, Height, 10, 10));

        }

        private void button9_Click(object sender, EventArgs e)
        {
            SecPatient prod = new SecPatient();
            prod.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Secappointments prod = new Secappointments();
            prod.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Seclogin prod = new Seclogin();
            prod.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void Secdashboard_Load(object sender, EventArgs e)
        {
            string query0 = "Select Name ,Picture,SSND from Doctor where SSND = 2019";
            SqlCommand cmd0 = new SqlCommand(query0, con);
            if (con.State != ConnectionState.Open)
                con.Open();

            SqlDataReader dr0 = cmd0.ExecuteReader();
            if (dr0.Read() == true)
            {
                var filename = @dr0["Picture"].ToString();
                label1.Text = dr0["Name"].ToString();
                label4.Text = dr0["SSND"].ToString();
                string parent = System.AppDomain.CurrentDomain.BaseDirectory;
                parent = @parent + @"images\" + filename;
                Cardiopic.ImageLocation = @parent;
                Cardiopic.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            if (con.State == ConnectionState.Open)
                con.Close();

            string query5 = "Select Name ,Picture,SSND from Doctor where SSND = 2020";
            SqlCommand cmd5 = new SqlCommand(query5, con);
            if (con.State != ConnectionState.Open)
                con.Open();

            SqlDataReader dr5 = cmd5.ExecuteReader();
            if (dr5.Read() == true)
            {
                var filename = @dr5["Picture"].ToString();
                label2.Text = dr5["Name"].ToString();
                label7.Text = dr5["SSND"].ToString();
                string parent = System.AppDomain.CurrentDomain.BaseDirectory;
                parent = @parent + @"images\" + filename;
                Otopic.ImageLocation = @parent;
                Otopic.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            if (con.State == ConnectionState.Open)
                con.Close();

            string query6 = "Select Name ,Picture,SSND from Doctor where SSND = 2018";

            SqlCommand cmd6 = new SqlCommand(query6, con);
            if (con.State != ConnectionState.Open)
                con.Open();

            SqlDataReader dr6 = cmd6.ExecuteReader();
            if (dr6.Read() == true)
            {
                var filename = @dr6["Picture"].ToString();
                label3.Text = dr6["Name"].ToString();
                label8.Text = dr6["SSND"].ToString();
                string parent = System.AppDomain.CurrentDomain.BaseDirectory;
                parent = @parent + @"images\" + filename;
                Opthapic.ImageLocation = @parent;
                Opthapic.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            if (con.State == ConnectionState.Open)
                con.Close();


            string query = "Select Name , Picture from Receptionist where Username = @username";
            
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@username", Global.username);

            if (con.State != ConnectionState.Open)
                con.Open();

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read() == true )
            {
                var filename = @dr["Picture"].ToString();
                label5.Text = dr["Name"].ToString();

                string parent = System.AppDomain.CurrentDomain.BaseDirectory;
                parent = @parent + @"images\" + filename;
                roundPicturebox1.ImageLocation = @parent;
                roundPicturebox1.SizeMode = PictureBoxSizeMode.StretchImage;


            }
            if (con.State == ConnectionState.Open)
                con.Close();

            


            con.Open();
            string query2 = "Select count(*) as temp from Patient as [Count]";

            SqlCommand cmd2 = new SqlCommand(query2, con);
            cmd2.Parameters.AddWithValue("@username", Global.username);

            
             

            SqlDataReader dr2 = cmd2.ExecuteReader();
            if (dr2.Read() == true)
            {
                label14.Text = dr2["temp"].ToString();

            }
            if (con.State == ConnectionState.Open)
                con.Close();

            con.Open();

            var dateAndTime = DateTime.Now;
            string date = dateAndTime.ToShortDateString();
            var start = "00:00:00.000";
            var end = "23:59:59.000";
            DateTime dtstart = Convert.ToDateTime(date + " " + start);
            DateTime dtend = Convert.ToDateTime(date + " " + end);
            string query3 = "Select count(*) as temp from Appointment where Datetimes Between '"+dtstart+"' AND '"+dtend+"' ";

            SqlCommand cmd3 = new SqlCommand(query3, con);
            cmd3.Parameters.AddWithValue("@username", Global.username);

            if (con.State != ConnectionState.Open)
                con.Open();

            SqlDataReader dr3 = cmd3.ExecuteReader();
            if (dr3.Read() == true)
            {
                label15.Text = dr3["temp"].ToString();

            }
            if (con.State == ConnectionState.Open)
                con.Close();
                
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Secdashboard prod = new Secdashboard();
            prod.Show();
            this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Opacity == 1)
                timer1.Stop();
            Opacity += .2;
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }
    }
}
