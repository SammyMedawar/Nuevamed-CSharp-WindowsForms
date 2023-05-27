using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace NuevaMed
{
    public partial class Secappointments : Form
    {
        public static int static_month, static_year;
        int month, year;
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["nuevaDB"].ToString());


        public Secappointments()
        {
            InitializeComponent();
        }

        private void daycontainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LBDATE_Click(object sender, EventArgs e)
        {

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

        private void Secappointments_Load(object sender, EventArgs e)
        {
            displayDays();

            string query = "Select Name , Picture from Receptionist where Username = @username";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@username", Global.username);

            if (con.State != ConnectionState.Open)
                con.Open();

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read() == true)
            {
                var filename = @dr["Picture"].ToString();
                label3.Text = dr["Name"].ToString();

                string parent = System.AppDomain.CurrentDomain.BaseDirectory;
                parent = @parent + @"images\" + filename;
                roundPicturebox1.ImageLocation = @parent;
                roundPicturebox1.SizeMode = PictureBoxSizeMode.StretchImage;
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

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Seclogin prod = new Seclogin();
            this.Hide();
            prod.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SecPatient prod = new SecPatient();
            this.Hide();
            prod.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Opacity == 1)
                timer1.Stop();
            Opacity += .2;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Secdashboard prod = new Secdashboard();
            this.Hide();
            prod.Show();
        }
    }
}
