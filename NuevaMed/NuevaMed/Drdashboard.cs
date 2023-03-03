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
    public partial class Drdashboard : Form
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
        public Drdashboard()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRect(0, 0, Width, Height, 10, 10));
        }
      

        private void Drdashboard_Load(object sender, EventArgs e)
        {
            string query = "Select * from Doctor where Username = @username";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@username", Global.username);

            if (con.State != ConnectionState.Open)
                con.Open();

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read() == true)
            {
                label3.Text = "Dr. " + dr["Name"].ToString();
                var filename = @dr["Picture"].ToString();
                label2.Text = dr["Fax"].ToString();
                label4.Text = dr["Nationality"].ToString();
                label5.Text = dr["Gender"].ToString();
                label12.Text = dr["Office Number"].ToString();
                textBox1.Text = dr["OfficeHours"].ToString();
                label14.Text = dr["Extension"].ToString();
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

            if (con.State != ConnectionState.Open)
                con.Open();

            var dateAndTime = DateTime.Now;
            var date = dateAndTime.Date;
            string query4 = "select Appointment.Datetimes,Patient.Name , Appointment.SSNP,  Appointment.IDA   from Appointment inner join Patient on Patient.SSNP=Appointment.SSNP inner join Checks on Appointment.IDA = Checks.IDA where Checks.SSND = (select SSND from Doctor where Doctor.Username =  '" + Global.username + "' ) AND Appointment.Datetimes >= '" + date+ "' ;";
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(query4, con);
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].HeaderText = "Patient SSN";
            dataGridView1.Columns[1].HeaderText = "Appointment Date";
            dataGridView1.Columns[2].HeaderText = "Appointment ID";
            dataGridView1.Columns[1].Width = 130;

            if (con.State == ConnectionState.Open)
                con.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DrPatient prod = new DrPatient();
            prod.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Drlogin prod = new Drlogin();
            prod.Show();
            this.Hide();
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized; 
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Drappointments prod = new Drappointments();
            prod.Show();
            this.Hide();
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            if (Opacity == 1)
                timer1.Stop();
            Opacity += .2;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Drappointments prod = new Drappointments();
            prod.Show();
            this.Hide();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void roundedPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void roundedPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void roundedPanel4_Paint(object sender, PaintEventArgs e)
        {

        }
        
    }
}
