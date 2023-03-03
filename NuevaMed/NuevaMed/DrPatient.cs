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
    public partial class DrPatient : Form
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
        public DrPatient()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRect(0, 0, Width, Height, 10, 10));
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                
                string query = "Select Patient.Name, Patient.Gender, Patient.Age, Medications.Name, Medications.StartDate ,Medications.EndDate, Diagnosis.Name , Diagnosis.StartDate, Diagnosis.EndDate , Diagnosis.Status , Diagnosis.FamilyHistory, Allergies.Source  from Patient  inner join MedicalRecord on Patient.SSNP = MedicalRecord.SSNP inner join Medications on MedicalRecord.IDM = Medications.IDM inner join ViewMR on ViewMR.IDM = MedicalRecord.IDM inner join Allergies on MedicalRecord.IDM = Allergies.IDM inner join Diagnosis on MedicalRecord.IDM = Diagnosis.IDM where ViewMR.SSND = (Select SSND from Doctor where Doctor.Username = '"+Global.username+"' ); ";

                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;

           

                dataGridView1.Columns[0].HeaderText = "Name";
                dataGridView1.Columns[1].HeaderText = "Gender";
                dataGridView1.Columns[2].HeaderText = "Age";
                dataGridView1.Columns[3].HeaderText = "Medication Name";
                dataGridView1.Columns[4].HeaderText = "Medication Start-Date";
                dataGridView1.Columns[5].HeaderText = "Medication End-Date";
                dataGridView1.Columns[6].HeaderText = "Diagnosis Name";
                dataGridView1.Columns[7].HeaderText = "Diagnosis Start-Date";
                dataGridView1.Columns[8].HeaderText = "Diagnosis End-Dater";
                dataGridView1.Columns[9].HeaderText = "Diagnosis Status";
                dataGridView1.Columns[10].HeaderText = "Diagnosis Family History";
                dataGridView1.Columns[11].HeaderText = "Allergies Source";


                string query2 = "Select * from Doctor where Username = @username";
                SqlCommand cmd = new SqlCommand(query2, con);
                cmd.Parameters.AddWithValue("@username", Global.username);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read() == true)
                {
                    label3.Text = "Dr. " + dr["Name"].ToString();
                    var filename = @dr["Picture"].ToString();
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
                    label7.Text = dr2[0].ToString();
                }
               
                if (con.State == ConnectionState.Open)
                    con.Close();
                

            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong!");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized; 

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Drdashboard prod = new Drdashboard();
            prod.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Drappointments prod = new Drappointments();
            prod.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                string Name =Search.Text;
                string query = "Select Patient.Name, Patient.Gender, Patient.Age, Medications.Name, Medications.StartDate ,Medications.EndDate, Diagnosis.Name , Diagnosis.StartDate, Diagnosis.EndDate , Diagnosis.Status , Diagnosis.FamilyHistory, Allergies.Source  from Patient  inner join MedicalRecord on Patient.SSNP = MedicalRecord.SSNP inner join Medications on MedicalRecord.IDM = Medications.IDM inner join Allergies on MedicalRecord.IDM = Allergies.IDM inner join Diagnosis on MedicalRecord.IDM = Diagnosis.IDM where Patient.Name ='" + Name + "' ";
                   
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;

            }
            catch (Exception)
            {
                MessageBox.Show("Name dosen't Exist");
            }
        }

        private void Search_TextChanged(object sender, EventArgs e)
        {

        }

        private void Load1_Click(object sender, EventArgs e)
        {
            if (Search.Text != "Search for patient name")
            {
                Search.Text = "Search for patient name";
                Search.ForeColor = Color.Silver;
            } 
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();

                string query = "Select Patient.Name, Patient.Gender, Patient.Age, Medications.Name, Medications.StartDate ,Medications.EndDate, Diagnosis.Name , Diagnosis.StartDate, Diagnosis.EndDate , Diagnosis.Status , Diagnosis.FamilyHistory, Allergies.Source  from Patient  inner join MedicalRecord on Patient.SSNP = MedicalRecord.SSNP inner join Medications on MedicalRecord.IDM = Medications.IDM inner join ViewMR on ViewMR.IDM = MedicalRecord.IDM inner join Allergies on MedicalRecord.IDM = Allergies.IDM inner join Diagnosis on MedicalRecord.IDM = Diagnosis.IDM where ViewMR.SSND = (Select SSND from Doctor where Doctor.Username = '" + Global.username + "') "; 
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;

                dataGridView1.Columns[0].HeaderText = "Name";
                dataGridView1.Columns[1].HeaderText = "Gender";
                dataGridView1.Columns[2].HeaderText = "Age";
                dataGridView1.Columns[3].HeaderText = "Medication Name";
                dataGridView1.Columns[4].HeaderText = "Medication Start-Date";
                dataGridView1.Columns[5].HeaderText = "Medication End-Date";
                dataGridView1.Columns[6].HeaderText = "Diagnosis Name";
                dataGridView1.Columns[7].HeaderText = "Diagnosis Start-Date";
                dataGridView1.Columns[8].HeaderText = "Diagnosis End-Dater";
                dataGridView1.Columns[9].HeaderText = "Diagnosis Status";
                dataGridView1.Columns[10].HeaderText = "Diagnosis Family History";
                dataGridView1.Columns[11].HeaderText = "Allergies Source";


                string query2 = "Select * from Doctor where Username = @username";
                SqlCommand cmd = new SqlCommand(query2, con);
                cmd.Parameters.AddWithValue("@username", Global.username);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read() == true)
                {
                    label3.Text = "Dr. " + dr["Name"].ToString();
                    var filename = @dr["Picture"].ToString();
                    string parent = System.AppDomain.CurrentDomain.BaseDirectory;
                    parent = @parent + @"images\" + filename;
                    roundPicturebox1.ImageLocation = @parent;
                }
                if (con.State == ConnectionState.Open)
                    con.Close();


            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong!");
            }
        }

        private void Search_Enter(object sender, EventArgs e)
        {
            if (Search.Text == "Search for patient name")
                Search.Text = "";
            Search.ForeColor = Color.Black;
        }

        private void Search_Leave(object sender, EventArgs e)
        {
            if (Search.Text == "")
            {
                Search.Text = "Search for patient name";
                Search.ForeColor = Color.Silver;
            }
            else
                Search.ForeColor = Color.Black;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Drlogin prod = new Drlogin();
            prod.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Opacity == 1)
                timer1.Stop();
            Opacity += .2;
        }

        private void roundedPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
