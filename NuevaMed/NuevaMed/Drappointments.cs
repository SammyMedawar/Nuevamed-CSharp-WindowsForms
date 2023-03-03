using System.Threading;
using System.Globalization;
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
    public partial class Drappointments : Form
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
        public static int static_month, static_year;
        int month, year; 

        public Drappointments()
        {
            InitializeComponent();
        }

        
        private void button5_Click(object sender, EventArgs e)
        {
            Drdashboard prod = new Drdashboard();
            prod.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DrPatient prod = new DrPatient();
            prod.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Drlogin prod = new Drlogin();
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


        private void Drappointments_Load(object sender, EventArgs e)
        {
            displayDays();

            string query = "Select * from Doctor where Username = @username";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@username", Global.username);

            if (con.State != ConnectionState.Open)
                con.Open();

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read() == true)
            {
                var filename = @dr["Picture"].ToString();
                label3.Text = "Dr. " + dr["Name"].ToString();

                string parent = System.AppDomain.CurrentDomain.BaseDirectory;
                parent = @parent + @"images\" + filename;
                roundPicturebox1.ImageLocation = @parent;
                roundPicturebox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            if (con.State == ConnectionState.Open)
                con.Close();


            if (con.State != ConnectionState.Open)
                con.Open();

            string query3 = "Select count(*) from Patient  inner join MedicalRecord on Patient.SSNP = MedicalRecord.SSNP inner join ViewMR on ViewMR.IDM = MedicalRecord.IDM where ViewMR.SSND = (Select SSND from Doctor where Doctor.Username = '" + Global.username + "' ); ";
            SqlCommand cmd3 = new SqlCommand(query3, con);
            SqlDataReader dr2 = cmd3.ExecuteReader();
            if (dr2.Read())
            {
                label17.Text = dr2[0].ToString();
            }

            if (con.State == ConnectionState.Open)
                con.Close();    
        }

        private void displayDays()
        {
            DateTime now = DateTime.Now;
            month = now.Month;
            year = now.Year;

            String monthname = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            LBDATE.Text = monthname + " " + year;
            static_month = month;
            static_year = year;

            DateTime startofthemonth = new DateTime(year, month, 1);
            int days = DateTime.DaysInMonth(year, month);

            int dayoftheweek = Convert.ToInt32(startofthemonth.DayOfWeek.ToString("d")) + 1;

            for (int i = 1; i < dayoftheweek; i++)
            {
                UserControlblank ucblank = new UserControlblank();
                daycontainer.Controls.Add(ucblank);
            }
            for (int i = 1; i <= days; i++)
            {
                UserControldays ucdays = new UserControldays();
                ucdays.days(i);
                daycontainer.Controls.Add(ucdays);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Opacity == 1)
                timer1.Stop();
            Opacity += .2;
        }



        private void bnext_Click(object sender, EventArgs e)
        {
            daycontainer.Controls.Clear();

            month++;
            static_month = month;
            static_year = year;
            String monthname = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            LBDATE.Text = monthname + " " + year;
            DateTime startofthemonth = new DateTime(year, month, 1);
            int days = DateTime.DaysInMonth(year, month);

            int dayoftheweek = Convert.ToInt32(startofthemonth.DayOfWeek.ToString("d")) + 1;

            for (int i = 1; i < dayoftheweek; i++)
            {
                UserControlblank ucblank = new UserControlblank();
                daycontainer.Controls.Add(ucblank);
            }
            for (int i = 1; i <= days; i++)
            {
                UserControldays ucdays = new UserControldays();
                ucdays.days(i);
                daycontainer.Controls.Add(ucdays);
            }
        }

        private void bprevious_Click(object sender, EventArgs e)
        {
            daycontainer.Controls.Clear();

            month--;
            static_month = month;
            static_year = year;
            String monthname = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            LBDATE.Text = monthname + " " + year;
            DateTime startofthemonth = new DateTime(year, month, 1);
            int days = DateTime.DaysInMonth(year, month);

            int dayoftheweek = Convert.ToInt32(startofthemonth.DayOfWeek.ToString("d")) + 1;

            for (int i = 1; i < dayoftheweek; i++)
            {
                UserControlblank ucblank = new UserControlblank();
                daycontainer.Controls.Add(ucblank);
            }
            for (int i = 1; i <= days; i++)
            {
                UserControldays ucdays = new UserControldays();
                ucdays.days(i);
                daycontainer.Controls.Add(ucdays);
            }
        }

        private void daycontainer_Paint(object sender, PaintEventArgs e)
        {

        }

        

        

        
    }
}
