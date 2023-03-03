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
using System.Globalization;

namespace NuevaMed
{
    public partial class Docappevent : Form
    {

        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MYDBD"].ToString());
        public static int SSNR;
        public static string Date;

        public Docappevent()
        {
            InitializeComponent();
        }

        void clear()
        {
            textTime.Text = "";
            textSSN.Text = "";
            textDRSSN.Text = "";
            textOffice.Text = "";
            textApp.Text = "";
        }


        void displaygrid()
        {
            textApp.ReadOnly = false;
            string Date;

            string StartTime = "00:00:00.000";
            string EndTime = "23:59:59.000";

            //DateTime dtstart = DateTime.ParseExact(Date + " " + StartTime, "yyyy/M/d HH:mm:ss.fff", CultureInfo.InvariantCulture);
            //DateTime dtend = DateTime.ParseExact(Date + " " + EndTime, "yyyy/M/d HH:mm:ss.fff", CultureInfo.InvariantCulture);



            if (con.State != ConnectionState.Open)
                con.Open();

            if (Global.username == "Cardio" || Global.username == "Optha" || Global.username == "Oto")
            {
                Date = Drappointments.static_year + "-" + Drappointments.static_month + "-" + UserControldays.static_day;
                //string query4 = "select Appointment.Datetimes,Patient.Name , Appointment.SSNP,  Appointment.IDA   from Appointment inner join Patient on Patient.SSNP=Appointment.SSNP inner join Checks on Appointment.IDA = Checks.IDA where Checks.SSND = (select SSND from Doctor where Doctor.Username =  '" + Global.username + "' ) AND Appointment.Datetimes > '" + date + "' ;";
                DateTime dtstart = Convert.ToDateTime(Date + " " + StartTime);
                DateTime dtend = Convert.ToDateTime(Date + " " + EndTime);

                string query3 = "select Appointment.*, Checks.SSND from Appointment inner join Checks on Checks.IDA = Appointment.IDA where Appointment.Datetimes Between '" + dtstart + "' AND '" + dtend + "' AND Checks.SSND= (select SSND from Doctor where Doctor.Username='" + Global.username + "') ";

                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(query3, con);
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else
            {
                Date = Secappointments.static_year + "-" + Secappointments.static_month + "-" + UserControldays.static_day;
                DateTime dtstart = Convert.ToDateTime(Date + " " + StartTime);
                DateTime dtend = Convert.ToDateTime(Date + " " + EndTime);
                string query3 = "select Appointment.*, Checks.SSND from Appointment inner join Checks on Checks.IDA = Appointment.IDA where Appointment.Datetimes Between '" + dtstart + "' AND '" + dtend + "'   ";

                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(query3, con);
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }



            if (con.State == ConnectionState.Open)
                con.Close();
        }



        private void EventForm_Load(object sender, EventArgs e)
        {

            if (Global.username == "Cardio" || Global.username == "Optha" || Global.username == "Oto")
            {
                textDate.Text = UserControldays.static_day + "/" + Drappointments.static_month + "/" + Drappointments.static_year;

                int i = 0;
                while (i < 16) // had to use a while loop to ensure that all 
                {             // necessary controls are removed
                    foreach (Control c in Controls)
                    {
                        if (c.Name != "dataGridView1" && c.Name != "button2")
                        {
                            Controls.Remove(c);
                            i++;
                        }
                    }
                }
                dataGridView1.Size = new Size(642, 150);
                dataGridView1.Location = new Point(83, 60); //Relocate datagridview in case user is doctor

            }
            else
            {

                textDate.Text = UserControldays.static_day + "/" + Secappointments.static_month + "/" + Secappointments.static_year;

            }

            displaygrid();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (Global.username == "Cardio" || Global.username == "Optha" || Global.username == "Oto")
            {
                return;
                //ignore
            }

            string queryu = "Select SSNR from Receptionist where Username = @username ";
            SqlCommand cmd2 = new SqlCommand(queryu, con);
            cmd2.Parameters.AddWithValue("@username", Global.username);

            if (con.State != ConnectionState.Open)
                con.Open();

            SqlDataReader dr = cmd2.ExecuteReader();
            if (dr.Read() == true)
            {

                string temp;
                temp = dr["SSNR"].ToString();
                SSNR = Int32.Parse(temp);
            }
            if (con.State == ConnectionState.Open)
                con.Close();




            try
            {
                queryu = "select Appointment.SSNP from Appointment where Appointment.SSNP = '" + Int32.Parse(textSSN.Text) + "' UNION select Doctor.SSND from Doctor where Doctor.SSND = '" + Int32.Parse(textDRSSN.Text) + "' ";
                cmd2 = new SqlCommand(queryu, con);
                cmd2.Parameters.AddWithValue("@username", Global.username);

                if (con.State != ConnectionState.Open)
                    con.Open();

                dr = cmd2.ExecuteReader();
                if (dr.Read() == false)//CHECK IF PATIENT SSN OR DOCTOR SSN EXITST, IF NOT END THE FUNCTION BY RETURNING
                {
                    MessageBox.Show("Invalid Patient or Doctor SSN");
                    return;
                }


                if (con.State == ConnectionState.Open)
                    con.Close();

                if (con.State != ConnectionState.Open)
                    con.Open();

                string query = "Insert into Appointment values (@IDA, @SSNP, @SSNR, @Officenumber, @Datetimes)";
                string query2 = "Insert into Checks values ( @SSND, @IDA)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@IDA", Int32.Parse(textApp.Text));
                cmd.Parameters.AddWithValue("@SSNP", Int32.Parse(textSSN.Text));
                cmd.Parameters.AddWithValue("@SSNR", SSNR);


                if (textDRSSN.Text == "2018")
                {
                    cmd.Parameters.AddWithValue("@Officenumber", ("101"));
                    textOffice.Text = "101";
                }
                else if (textDRSSN.Text == "2019")
                {
                    cmd.Parameters.AddWithValue("@Officenumber", ("103"));
                    textOffice.Text = "103";
                }

                else if (textDRSSN.Text == "2020")
                {
                    cmd.Parameters.AddWithValue("@Officenumber", ("105"));
                    textOffice.Text = "105";
                }



                // cmd.Parameters.AddWithValue("@Officenumber", Int32.Parse(textOffice.Text));
                string Date = Secappointments.static_year + "-" + Secappointments.static_month + "-" + UserControldays.static_day;
                string Time = (textTime.Text).ToString();
                DateTime dt = DateTime.ParseExact(Date + " " + Time, "yyyy-M-d HH:mm:ss", CultureInfo.InvariantCulture);
                cmd.Parameters.AddWithValue("@Datetimes", dt);
                cmd.ExecuteNonQuery();

                SqlCommand cmdc = new SqlCommand(query2, con);
                cmdc.Parameters.AddWithValue("@IDA", Int32.Parse(textApp.Text));
                cmdc.Parameters.AddWithValue("@SSND", Int32.Parse(textDRSSN.Text));
                cmdc.ExecuteNonQuery();




                displaygrid();
                MessageBox.Show("Appointment Added Successfully");
                clear();
            }
            catch (Exception MSG)
            {
                MessageBox.Show("Invalid Information!");
            }

            if (con.State == ConnectionState.Open)
                con.Close();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (Global.username == "Cardio" || Global.username == "Optha" || Global.username == "Oto")
            {
                return;
                //ignore
            }

            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                string query1 = "delete from Checks where Checks.IDA = @IDA";
                string query2 = "delete from Appointment where Appointment.IDA = @IDA ";
                SqlCommand cmd = new SqlCommand(query1, con);
                SqlCommand cmd2 = new SqlCommand(query2, con);
                cmd2.Parameters.AddWithValue("@IDA", Int32.Parse(textApp.Text));
                cmd.Parameters.AddWithValue("@IDA", Int32.Parse(textApp.Text));
                cmd.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();

                MessageBox.Show("Appointment Successfully Deleted");
                clear();

                if (con.State == ConnectionState.Open)
                    con.Close();
                displaygrid();
            }

            catch
            {
                MessageBox.Show("Invalid Appointment ID!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textApp.Text))
            {
                MessageBox.Show("Appointment ID Cannot Be Modified!");
                return;
            }

            try
            {
                string query = "Update Appointment set SSNP = @SSNP, Officenumber = @Officenumber, Datetimes = @Datetimes where IDA = @IDA";
                string query3 = "Update Checks set SSND = @SSND where IDA = @IDA ";




                SqlCommand cmd = new SqlCommand(query, con);
                SqlCommand cmd3 = new SqlCommand(query3, con);

                if (con.State != ConnectionState.Open)
                    con.Open();
                DateTime X = Convert.ToDateTime(textTime.Text);
                TimeSpan Time = X.TimeOfDay;
                string Date = Secappointments.static_year + "-" + Secappointments.static_month + "-" + UserControldays.static_day;
                DateTime dt = DateTime.ParseExact(Date + " " + Time, "yyyy-M-d HH:mm:ss", CultureInfo.InvariantCulture);

                cmd.Parameters.AddWithValue("@SSNP", Int32.Parse(textSSN.Text));
                cmd.Parameters.AddWithValue("@Officenumber", Int32.Parse(textOffice.Text));
                cmd.Parameters.AddWithValue("@Datetimes", dt);
                cmd.Parameters.AddWithValue("@IDA", Int32.Parse(textApp.Text));
                cmd3.Parameters.AddWithValue("@IDA", Int32.Parse(textApp.Text));
                cmd3.Parameters.AddWithValue("@SSND", Int32.Parse(textDRSSN.Text));
                cmd.ExecuteNonQuery();
                cmd3.ExecuteNonQuery();

                if (con.State != ConnectionState.Closed)
                    con.Close();

                MessageBox.Show("Edited Successfully");
                displaygrid();
            }
            catch
            {
                MessageBox.Show("Please Enter Valid Information");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                textApp.ReadOnly = true;

                if (Global.username == "Cardio" || Global.username == "Optha" || Global.username == "Oto")
                    Date = Drappointments.static_year + "-" + Drappointments.static_month + "-" + UserControldays.static_day;
                else
                    Date = Secappointments.static_year + "-" + Secappointments.static_month + "-" + UserControldays.static_day;

                string StartTime = "00:00:00.000";
                string EndTime = "23:59:59.000";



                DateTime dtstart = Convert.ToDateTime(Date + " " + StartTime);
                DateTime dtend = Convert.ToDateTime(Date + " " + EndTime);

                if (con.State != ConnectionState.Open)
                    con.Open();


                string query3 = "select Appointment.*, Checks.SSND from Appointment inner join Checks on Checks.IDA = Appointment.IDA where Appointment.Datetimes Between '" + dtstart + "' AND '" + dtend + "' AND Appointment.IDA = '" + Int32.Parse(search2.Text) + "' ";
                SqlCommand cmd = new SqlCommand(query3, con);
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(query3, con);
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    DateTime X = Convert.ToDateTime(dr["Datetimes"]);
                    TimeSpan Y = X.TimeOfDay;
                    textTime.Text = Y.ToString();
                    textApp.Text = dr["IDA"].ToString();
                    textSSN.Text = dr["SSNP"].ToString();
                    textOffice.Text = dr["Officenumber"].ToString();
                    textDRSSN.Text = dr["SSND"].ToString();
                }
                else
                {
                    MessageBox.Show("Patient Does Not Exist");
                    clear();
                }

                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            catch
            {
                MessageBox.Show("Something Went Wrong!");
            }

        }



        private void Search_Enter(object sender, EventArgs e)
        {
            if (Search.Text == "Search by Appointment ID")
            {
                Search.Text = "";
                Search.ForeColor = Color.Black;
            }
        }

        private void Search_Leave(object sender, EventArgs e)
        {
            if (Search.Text == "")
            {
                Search.Text = "Search by Appointment ID";
                Search.ForeColor = Color.Silver;
            }
        }

        private void Load1_Click(object sender, EventArgs e)
        {
            displaygrid();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Opacity == 1)
                timer1.Stop();
            Opacity += .2;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                textApp.ReadOnly = true;

                if (Global.username == "Cardio" || Global.username == "Optha" || Global.username == "Oto")
                    Date = Drappointments.static_year + "-" + Drappointments.static_month + "-" + UserControldays.static_day;
                else
                    Date = Secappointments.static_year + "-" + Secappointments.static_month + "-" + UserControldays.static_day;

                string StartTime = "00:00:00.000";
                string EndTime = "23:59:59.000";



                DateTime dtstart = Convert.ToDateTime(Date + " " + StartTime);
                DateTime dtend = Convert.ToDateTime(Date + " " + EndTime);

                if (con.State != ConnectionState.Open)
                    con.Open();


                string query3 = "select Appointment.*, Checks.SSND from Appointment inner join Checks on Checks.IDA = Appointment.IDA where Appointment.Datetimes Between '" + dtstart + "' AND '" + dtend + "' AND Appointment.IDA = '" + Int32.Parse(search2.Text) + "' ";
                SqlCommand cmd = new SqlCommand(query3, con);
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(query3, con);
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    DateTime X = Convert.ToDateTime(dr["Datetimes"]);
                    TimeSpan Y = X.TimeOfDay;
                    textTime.Text = Y.ToString();
                    textApp.Text = dr["IDA"].ToString();
                    textSSN.Text = dr["SSNP"].ToString();
                    textOffice.Text = dr["Officenumber"].ToString();
                    textDRSSN.Text = dr["SSND"].ToString();
                }
                else
                {
                    MessageBox.Show("Patient Does Not Exist");
                    clear();
                }

                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            catch
            {
                MessageBox.Show("Something Went Wrong!");
            }
        }

        private void search2_Enter(object sender, EventArgs e)
        {
            if (search2.Text == "Search by Appointment ID")
            {
                search2.Text = "";
                search2.ForeColor = Color.Black;
            }
        }

        private void search2_Leave(object sender, EventArgs e)
        {
            if (search2.Text == "")
            {
                search2.Text = "Search by Appointment ID";
                search2.ForeColor = Color.Silver;
            }
        }
    }
}
