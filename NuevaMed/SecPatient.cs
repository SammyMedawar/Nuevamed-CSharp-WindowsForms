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
    public partial class SecPatient : Form

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

        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["nuevaDB"].ToString());


        public SecPatient()
        {
            InitializeComponent();
             Region = System.Drawing.Region.FromHrgn(CreateRoundRect(0, 0, Width, Height, 10, 10));
        }

        private void ViewPatients()
        {
            if (con.State != ConnectionState.Open)
                con.Open();

            //string query = "Select * from Patient";
            string query = "Select MedicalRecord.IDM, Patient.*, ViewMR.SSND from MedicalRecord inner join Patient on MedicalRecord.SSNP = Patient.SSNP inner join ViewMR on MedicalRecord.IDM = ViewMR.IDM";
            
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;

            if (con.State == ConnectionState.Open)
                con.Close();
        }
        private void ViewRecordsSpec(string query)
        {
            
            if (con.State != ConnectionState.Open)
                con.Open();

            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            adapter.Fill(dt);
            dataGridView2.DataSource = dt;

            if (con.State == ConnectionState.Open)
                con.Close();
        }
        private void ViewRecords()
        {
            //string query = "select MedicalRecord.* , Diagnosis.IDD as [Diagnosis ID], Medications.ID as [Medications ID], Allergies.ID [ID] from MedicalRecord inner join Diagnosis inner join Medications join Allergies Group By MedicalRecord.IDM";
            string query = "select MedicalRecord.* , Diagnosis.IDD as [Diagnosis ID], Medications.ID as [Medications ID], Allergies.ID as [AID] from MedicalRecord inner join Diagnosis on MedicalRecord.IDM = Diagnosis.IDM inner join Medications on MedicalRecord.IDM = Medications.IDM inner join Allergies on MedicalRecord.IDM = Allergies.IDM Order By MedicalRecord.IDM";
            //string query = "Select * from Diagnosis";
            if (con.State != ConnectionState.Open)
                con.Open();

            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            adapter.Fill(dt);
            dataGridView2.DataSource = dt;

            if (con.State == ConnectionState.Open)
                con.Close();
        }
        private void Clear()
        {
            textMIDMID.Text = "";
            //textMIDMID.ForeColor = Color.Silver;
            textDID.Text = "";
            //textDID.ForeColor = Color.Silver;
            textDName.Text = "";
            //textDName.ForeColor = Color.Silver;
            textDStatus.Text = "";
           // textDStatus.ForeColor = Color.Silver;
            textDStart.Text = "";
           // textDStart.ForeColor = Color.Silver;
            textDEnd.Text = "";
            //textDEnd.ForeColor = Color.Silver;
            textHistory.Text = "";
            //textHistory.ForeColor = Color.Silver;
            textMedicationID.Text = "";
           // textMedicationID.ForeColor = Color.Silver;
            textMName.Text = "";
           // textMName.ForeColor = Color.Silver;
            textMStart.Text = "";
            //textMStart.ForeColor = Color.Silver;
            textMEnd.Text = "";
            //textMEnd.ForeColor = Color.Silver;
            textAID.Text = "";
           // textAID.ForeColor = Color.Silver;
            textSource.Text = "";
           // textSource.ForeColor = Color.Silver;
            textSSN.Text = "";
           // textSSN.ForeColor = Color.Silver;
            textPName.Text = "";
           // textPName.ForeColor = Color.Silver;
            textGender.Text = "";
           // textGender.ForeColor = Color.Silver;
            textAge.Text = "";
           // textAge.ForeColor = Color.Silver;
            textnbr.Text = "";
           // textnbr.ForeColor = Color.Silver;
            textPStatus.Text = "";
           // textPStatus.ForeColor = Color.Silver;
            textAcc.Text = "";
           // textAcc.ForeColor = Color.Silver;
            textMIDP.Text = "";
            //textMIDP.ForeColor = Color.Silver;
            roundTextbox18.Text = "";
        }

        private void Loadstart()
        {
            
        }

        private void Drpatient_Load(object sender, EventArgs e)
        {
           
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {

            if (radioDD.Checked)
            {
                try
                {
                    if (String.IsNullOrEmpty(textMIDMID.Text) || String.IsNullOrEmpty(textDID.Text))
                    {

                        MessageBox.Show("Please Enter Both the Medications ID and the Medical Record ID");
                        return;
                    }

                    else
                    {
                        if (con.State != ConnectionState.Open)
                            con.Open();
                        
                        string query = "Insert into Diagnosis values (@IDD, @IDM, @Name,  @StartDate , @EndDate , @Status , @FamilyHistory)";
                        
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@IDD", Int32.Parse(textDID.Text));
                        cmd.Parameters.AddWithValue("@IDM", Int32.Parse(textMIDMID.Text));
                        cmd.Parameters.AddWithValue("@Name", textDName.Text);
                        cmd.Parameters.AddWithValue("@StartDate", textDStart.Text);
                        cmd.Parameters.AddWithValue("@EndDate", textDEnd.Text);
                        cmd.Parameters.AddWithValue("@Status", textDStatus.Text);
                        cmd.Parameters.AddWithValue("@FamilyHistory", textHistory.Text);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Diagnosis Added Successfully");
                        Clear();
                        int DIDDY = Int32.Parse(searchRecord.Text);
                        query = "Select MedicalRecord.SSNP, Diagnosis.* from MedicalRecord inner join Diagnosis on MedicalRecord.IDM = Diagnosis.IDM where Diagnosis.IDD = '" + DIDDY + "' ";
                        ViewRecordsSpec(query);

                        if (con.State != ConnectionState.Closed)
                            con.Close();
                       
                    }
                }
                catch
                {
                    MessageBox.Show("Please Enter All the Information Correctly");
                }
            }
            else if (radioMM.Checked)
            {
                try
                {
                    if (String.IsNullOrEmpty(textMIDMID.Text) || String.IsNullOrEmpty(textMedicationID.Text))
                    {

                        MessageBox.Show("Please Enter Both the Diagnosis ID and the Medical Record ID");
                        return;
                    }

                    else
                    {
                        if (con.State != ConnectionState.Open)
                            con.Open();

                        string query = "Insert into Medications values (@ID, @IDM, @Name,  @StartDate , @EndDate)";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@ID", Int32.Parse(textMedicationID.Text));
                        cmd.Parameters.AddWithValue("@IDM", Int32.Parse(textMIDMID.Text));
                        cmd.Parameters.AddWithValue("@Name", textMName.Text);
                        cmd.Parameters.AddWithValue("@StartDate", textMStart.Text);
                        cmd.Parameters.AddWithValue("@EndDate", textMEnd.Text);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Medication Added Successfully");
                        Clear();

                        
                        int IDMM = Int32.Parse(searchRecord.Text);
                        query = "Select MedicalRecord.SSNP, Medications.* from MedicalRecord inner join Medications on MedicalRecord.IDM = Medications.IDM where Medications.ID = '" + IDMM + "' ";
                        ViewRecordsSpec(query);

                        if (con.State != ConnectionState.Closed)
                            con.Close();
                        
                    }
                }
                catch 
                {
                    MessageBox.Show("Please Enter All the Information Correctly");
                }
            }
            else if (radioAA.Checked)
            {
                try
                {
                    if (String.IsNullOrEmpty(textMIDMID.Text) || String.IsNullOrEmpty(textAID.Text))
                    {

                        MessageBox.Show("Please Enter Both the Allergie ID and the Medical Record ID");
                        return;
                    }

                    else
                    {
                        if (con.State != ConnectionState.Open)
                            con.Open();

                        string query = "Insert into Allergies values (@ID, @IDM, @Source)";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@ID", Int32.Parse(textAID.Text));
                        cmd.Parameters.AddWithValue("@IDM", Int32.Parse(textMIDMID.Text));
                        cmd.Parameters.AddWithValue("@Source", textSource.Text);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Allergie Added Successfully");
                        Clear();
                        int IDMM = Int32.Parse(searchRecord.Text);
                        query = "Select MedicalRecord.SSNP, Allergies.* from MedicalRecord inner join Allergies on MedicalRecord.IDM = Allergies.IDM where Allergies.ID = '" + IDMM + "' ";
                        ViewRecordsSpec(query);
                        if (con.State != ConnectionState.Closed)
                            con.Close();
                        
                    }
                }
                catch 
                {
                    MessageBox.Show("Please Enter All the Information Correctly");
                }
            }
            else if (radioPP.Checked)
            {
                if (String.IsNullOrEmpty(textSSN.Text) || String.IsNullOrEmpty(textMIDP.Text) || String.IsNullOrEmpty(textAcc.Text))
                {
                    MessageBox.Show("Please Make Sure That Patient SSN, Medical Record ID, and Doctor Access Are Filled Before Adding");
                    return;
                }

                int SSND = Int32.Parse(textAcc.Text);
                if (textAcc.Text != "2019" && textAcc.Text != "2018" && textAcc.Text != "2020")
                {
                    MessageBox.Show("That Doctor SSN Does Not Exist");
                    return;
                }
                if (con.State != ConnectionState.Open)
                    con.Open();
                try
                {
                    string query = "Insert into Patient values (@SSNP, @Name, @Gender, @Age, @Status, @Phonenumber)";
                    string query2 = "Insert into MedicalRecord values (@IDM, @SSNP)";
                    string query3 = "Insert into ViewMR values (@IDM, @SSND)";
                    string query4 = "Insert into Medications (ID, IDM) values (@ID, @IDM) ";
                    string query5 = "Insert into Diagnosis (IDD, IDM) values (@IDD, @IDM) ";
                    string query6 = "Insert into Allergies (ID, IDM) values (@ID, @IDM)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlCommand cmd2 = new SqlCommand(query2, con);
                    SqlCommand cmd3 = new SqlCommand(query3, con);
                    SqlCommand cmd4 = new SqlCommand(query4, con);
                    SqlCommand cmd5 = new SqlCommand(query5, con);
                    SqlCommand cmd6 = new SqlCommand(query6, con);
                    cmd.Parameters.AddWithValue("@SSNP", Int32.Parse(textSSN.Text));
                    cmd.Parameters.AddWithValue("@Name", textPName.Text);
                    cmd.Parameters.AddWithValue("@Gender", textGender.Text);
                    cmd.Parameters.AddWithValue("@Age", Int32.Parse(textAge.Text));
                    cmd.Parameters.AddWithValue("@Status", textPStatus.Text);
                    cmd.Parameters.AddWithValue("@Phonenumber", Int32.Parse(textnbr.Text));
                    cmd2.Parameters.AddWithValue("@IDM", Int32.Parse(textMIDP.Text));
                    cmd2.Parameters.AddWithValue("@SSNP", Int32.Parse(textSSN.Text));
                    cmd3.Parameters.AddWithValue("@IDM", Int32.Parse(textMIDP.Text));
                    cmd3.Parameters.AddWithValue("@SSND", SSND);
                    cmd4.Parameters.AddWithValue("@ID", Int32.Parse(textMIDP.Text));
                    cmd4.Parameters.AddWithValue("@IDM", Int32.Parse(textMIDP.Text));
                    cmd5.Parameters.AddWithValue("@IDD", Int32.Parse(textMIDP.Text));
                    cmd5.Parameters.AddWithValue("@IDM", Int32.Parse(textMIDP.Text));
                    cmd6.Parameters.AddWithValue("@ID", Int32.Parse(textMIDP.Text));
                    cmd6.Parameters.AddWithValue("@IDM", Int32.Parse(textMIDP.Text));
                    cmd.ExecuteNonQuery();
                    cmd2.ExecuteNonQuery();
                    cmd3.ExecuteNonQuery();
                    cmd4.ExecuteNonQuery();
                    cmd5.ExecuteNonQuery();
                    cmd6.ExecuteNonQuery();
                    MessageBox.Show("Patient Added Successfully");
                    Clear();
                    ViewRecords();
                    ViewPatients();
                }
                catch
                {
                    MessageBox.Show("Please Check That You Filled In The Information Correctly");
                }
                if (con.State != ConnectionState.Closed)
                    con.Close();
                
            }
            else if(radioCC.Checked){
                if (String.IsNullOrEmpty(textSSN.Text) || String.IsNullOrEmpty(textAcc.Text))
                {
                    MessageBox.Show("Please Make Sure That Patient SSN and Doctor Access Are Filled Before Adding");
                    return;
                }

                int SSND = Int32.Parse(textAcc.Text);
                if (textAcc.Text != "2019" && textAcc.Text != "2018" && textAcc.Text != "2020")
                {
                    MessageBox.Show("That Doctor SSN Does Not Exist");
                    return;
                }

                if (con.State != ConnectionState.Open)
                    con.Open();
                try
                {
                    string query3 = "Insert into ViewMR values (@IDM, @SSND)";
                    SqlCommand cmd3 = new SqlCommand(query3, con);
                    cmd3.Parameters.AddWithValue("@IDM", Int32.Parse(textMIDP.Text));
                    cmd3.Parameters.AddWithValue("@SSND", SSND);
                    cmd3.ExecuteNonQuery();
                    MessageBox.Show("Access Added Successfully");
                    Clear();
                    ViewRecords();
                    ViewPatients();
                }
                catch
                {
                    MessageBox.Show("Please Check That You Filled In The Information Correctly");
                }
                if (con.State != ConnectionState.Closed)
                    con.Close();
                
            }
            else
            {
                MessageBox.Show("Please Select What You Want To Add");
            }
       
        }
            
        

        private void Load_Click(object sender, EventArgs e)
        {
            /*textSSN.ReadOnly = false;
            textMIDP.ReadOnly = false;*/
            ViewPatients();
            Clear();
        }

        private void Search_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
            string query;
            /*textDID.ReadOnly = false;
            textAID.ReadOnly = false;
            textMedicationID.ReadOnly = false;
            textSSN.ReadOnly = false;
            textMIDP.ReadOnly = false;*/

            try
            {
                if (comboBox1.Text == "Medical Record ID")
                {
                    try
                    {
                        if (String.IsNullOrEmpty(textAcc.Text) || String.IsNullOrEmpty(searchRecord.Text))
                        {
                            MessageBox.Show("Please Fill In The Doctor SSN and the Search Bar");
                            return;
                        }

                        int MID = Int32.Parse(searchRecord.Text);
                        int SSND = Int32.Parse(textAcc.Text);
                        if (SSND != 2019 && SSND != 2018 && SSND != 2020)
                        {
                            MessageBox.Show("That Doctor Does Not Exist");
                            return;
                        }
                        //string query2 = "Select MedicalRecord.IDM, Patient.*, ViewMR.SSND from MedicalRecord inner join Patient on MedicalRecord.SSNP = Patient.SSNP inner join ViewMR on MedicalRecord.IDM = ViewMR.IDM where MedicalRecord.IDM = '" + MID + "' ";

                        string query2 = "Select MedicalRecord.IDM, Patient.*, ViewMR.SSND from MedicalRecord inner join Patient on MedicalRecord.SSNP = Patient.SSNP inner join ViewMR on MedicalRecord.IDM = ViewMR.IDM where MedicalRecord.IDM = '" + MID + "' AND ViewMR.SSND = '"+SSND+"' ";
                        query = "Select MedicalRecord.*, Diagnosis.IDD, Diagnosis.Name as DName, Diagnosis.Status as DStatus, Diagnosis.FamilyHistory, Diagnosis.StartDate as DStartDate, Diagnosis.EndDate as DEndDate, Medications.Name as Medication, Medications.ID as MID, Medications.StartDate as MStartDate, Medications.EndDate as MEndDate, Allergies.Source as [Allergies], Allergies.ID as [AID] from MedicalRecord inner join Diagnosis on MedicalRecord.IDM = Diagnosis.IDM inner join Medications on MedicalRecord.IDM = Medications.IDM inner join Allergies on MedicalRecord.IDM = Allergies.IDM where MedicalRecord.IDM = '" + MID + "' ";
                        if (con.State != ConnectionState.Open)
                            con.Open();

                        DataTable dt = new DataTable();
                        SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                        adapter.Fill(dt);
                        dataGridView2.DataSource = dt;

                        DataTable dt2 = new DataTable();
                        SqlDataAdapter adapter2 = new SqlDataAdapter(query2, con);
                        adapter2.Fill(dt2);
                        dataGridView1.DataSource = dt2;

     

                        SqlCommand cmd = new SqlCommand(query2, con);
                        SqlDataReader dr = cmd.ExecuteReader();

                        if (dr.Read() == true)
                        {
                            //textSSN.ReadOnly = true;
                            //textMIDP.ReadOnly = true;
                            textSSN.Text = dr["SSNP"].ToString();
                            textMIDP.Text = dr["IDM"].ToString();
                            textPName.Text = dr["Name"].ToString();
                            textGender.Text = dr["Gender"].ToString();
                            textAge.Text = dr["Age"].ToString();
                            textPStatus.Text = dr["Status"].ToString();
                            textnbr.Text = dr["Phonenumber"].ToString();
                            textAcc.Text = dr["SSND"].ToString();
                            
                        }


                        if (con.State == ConnectionState.Open)
                            con.Close();

                    }
                    catch
                    {
                        MessageBox.Show("Please Enter a Valid Medical Record ID");
                    }
                }

                else if (comboBox1.Text == "Diagnosis ID")
                {
                    try
                    {
                        //textMIDMID.ReadOnly = true;
                        //textDID.ReadOnly = true;
                        textMIDMID.ForeColor = Color.Black;
                        textDID.ForeColor = Color.Black;
                        textDName.ForeColor = Color.Black;
                        textDStatus.ForeColor = Color.Black;
                        textDStart.ForeColor = Color.Black;
                        textDEnd.ForeColor = Color.Black;
                        textHistory.ForeColor = Color.Black;

                        int DID = Int32.Parse(searchRecord.Text);
                        query = "Select MedicalRecord.SSNP, Diagnosis.* from MedicalRecord inner join Diagnosis on MedicalRecord.IDM = Diagnosis.IDM where Diagnosis.IDD = '" + DID + "' ";
                        if (con.State != ConnectionState.Open)
                            con.Open();

                        DataTable dt = new DataTable();
                        SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                        adapter.Fill(dt);
                        dataGridView2.DataSource = dt;

                        SqlCommand cmd = new SqlCommand(query, con);
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.Read() == true)
                        {
                            //textDID.ReadOnly = true;
                            textMIDMID.Text = dr["IDM"].ToString();
                            textDID.Text = dr["IDD"].ToString();
                            textDName.Text = dr["Name"].ToString();
                            textDStart.Text = dr["StartDate"].ToString();
                            textDEnd.Text = dr["EndDate"].ToString();
                            textDStatus.Text = dr["Status"].ToString();
                            textHistory.Text = dr["FamilyHistory"].ToString();
                        }

                        if (con.State == ConnectionState.Open)
                            con.Close();

                        
                    }
                    catch
                    {
                        MessageBox.Show("Please Enter a Valid Diagnosis ID");
                    }


                }
                else if (comboBox1.Text == "Medications ID")
                {
                    try
                    {
                        //textMedicationID.ReadOnly = true;
                        //textMIDMID.ReadOnly = true;
                        textMIDMID.ForeColor = Color.Black;
                        textMedicationID.ForeColor = Color.Black;
                        textMName.ForeColor = Color.Black;
                        textMStart.ForeColor = Color.Black;
                        textMEnd.ForeColor = Color.Black;

                        int IDM = Int32.Parse(searchRecord.Text);
                        query = "Select MedicalRecord.SSNP, Medications.* from MedicalRecord inner join Medications on MedicalRecord.IDM = Medications.IDM where Medications.ID = '" + IDM + "' ";
                        if (con.State != ConnectionState.Open)
                            con.Open();

                        DataTable dt = new DataTable();
                        SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                        adapter.Fill(dt);
                        dataGridView2.DataSource = dt;

                        SqlCommand cmd = new SqlCommand(query, con);
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.Read() == true)
                        {
                            textMIDMID.Text = dr["IDM"].ToString();
                            textMedicationID.Text = dr["ID"].ToString();
                            textMName.Text = dr["Name"].ToString();
                            roundTextbox18.Text = dr["StartDate"].ToString(); //Medications Start
                            textMEnd.Text = dr["EndDate"].ToString();
                        }

                        if (con.State == ConnectionState.Open)
                            con.Close();

                        
                    }
                    catch
                    {
                        MessageBox.Show("Please Enter a Valid Medciations ID");
                    }
                }
                else if (comboBox1.Text == "Allergies ID")
                {
                    try
                    {
                       // textAID.ReadOnly = true;
                        //textMIDMID.ReadOnly = true;
                        textMIDMID.ForeColor = Color.Black;
                        textAID.ForeColor = Color.Black;
                        textSource.ForeColor = Color.Black;
                        int IDM = Int32.Parse(searchRecord.Text);
                        query = "Select MedicalRecord.SSNP, Allergies.* from MedicalRecord inner join Allergies on MedicalRecord.IDM = Allergies.IDM where Allergies.ID = '" + IDM + "' ";
                        if (con.State != ConnectionState.Open)
                            con.Open();

                        DataTable dt = new DataTable();
                        SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                        adapter.Fill(dt);
                        dataGridView2.DataSource = dt;

                        SqlCommand cmd = new SqlCommand(query, con);
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.Read() == true)
                        {
                            textMIDMID.Text = dr["IDM"].ToString();
                            textAID.Text = dr["ID"].ToString();
                            textSource.Text = dr["Source"].ToString();
                        }

                        if (con.State == ConnectionState.Open)
                            con.Close();

                        
                        
                    }
                    catch
                    {
                        MessageBox.Show("Please Enter a Allergies ID");
                    }
                }
                else
                {
                    MessageBox.Show("Please Select What You Want to Search");
                }
            }
            catch
            {
                MessageBox.Show("Something Went Wrong!");
            }
        }

        private void Drpatient_Load_1(object sender, EventArgs e)
        {
            Loadstart();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Drpatient_Load_2(object sender, EventArgs e)
        {
            ViewPatients();
            ViewRecords();
            string query = "Select Name , Picture from Receptionist where Username = @username";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@username", Global.username);

            if (con.State != ConnectionState.Open)
                con.Open();

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read() == true)
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

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            if (radioDD.Checked)
            {
                try
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();

                    string query = "Delete From Diagnosis where IDD = @IDD AND IDM = @IDM";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@IDD", Int32.Parse(textDID.Text));
                    cmd.Parameters.AddWithValue("@IDM", Int32.Parse(textMIDMID.Text));
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Diagnosis Removed Successfully");
                    Clear();
                    int DIDDY = Int32.Parse(searchRecord.Text);
                    query = "Select MedicalRecord.SSNP, Diagnosis.* from MedicalRecord inner join Diagnosis on MedicalRecord.IDM = Diagnosis.IDM where Diagnosis.IDD = '" + DIDDY + "' ";
                    ViewRecordsSpec(query);

                    if (con.State != ConnectionState.Closed)
                        con.Close();
                    
                }
                catch
                {
                    MessageBox.Show("Please Enter both the Diagnosis and Medical Record ID's Correctly");
                }
            }

            else if (radioMM.Checked)
            {
                try
                {
                    if (String.IsNullOrEmpty(textMIDMID.Text) || String.IsNullOrEmpty(textMedicationID.Text))
                    {

                        MessageBox.Show("Please Enter Both the Medications ID and the Medical Record ID");
                        return;
                    }

                    else
                    {
                        if (con.State != ConnectionState.Open)
                            con.Open();

                        string query = "Delete from Medications where IDM = @IDM AND ID = @MID";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@MID", Int32.Parse(textMedicationID.Text));
                        cmd.Parameters.AddWithValue("@IDM", Int32.Parse(textMIDMID.Text));
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Medication Removed Successfully");
                        Clear();
                        int IDMM = Int32.Parse(searchRecord.Text);
                        query = "Select MedicalRecord.SSNP, Medications.* from MedicalRecord inner join Medications on MedicalRecord.IDM = Medications.IDM where Medications.ID = '" + IDMM + "' ";
                        ViewRecordsSpec(query);

                        if (con.State != ConnectionState.Closed)
                            con.Close();
                        
                    }
                }
                catch 
                {
                    MessageBox.Show("Please Enter All the Information Correctly");
                }
            }

            else if (radioAA.Checked)
            {
                try
                {
                    if (String.IsNullOrEmpty(textMIDMID.Text) || String.IsNullOrEmpty(textAID.Text))
                    {

                        MessageBox.Show("Please Enter Both the Allergie ID and the Medical Record ID");
                        return;
                    }

                    else
                    {
                        if (con.State != ConnectionState.Open)
                            con.Open();

                        string query = "Delete From Allergies where ID = @IDA AND IDM = @IDM";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@IDA", Int32.Parse(textAID.Text));
                        cmd.Parameters.AddWithValue("@IDM", Int32.Parse(textMIDMID.Text));
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Allergie Removed Successfully");
                        Clear();
                        int IDMM = Int32.Parse(searchRecord.Text);
                        query = "Select MedicalRecord.SSNP, Allergies.* from MedicalRecord inner join Allergies on MedicalRecord.IDM = Allergies.IDM where Allergies.ID = '" + IDMM + "' ";
                        ViewRecordsSpec(query);

                        if (con.State != ConnectionState.Closed)
                            con.Close();
                        
                    }
                }
                catch (Exception MSG)
                {
                    MessageBox.Show("Please Enter All the Information Correctly");
                }
            }
            else if (radioPP.Checked)
            {
                if (String.IsNullOrEmpty(textSSN.Text))
                {
                    MessageBox.Show("Please Make Sure That Patient SSN is Filled Before Removing");
                    return;
                }

                if (con.State != ConnectionState.Open)
                    con.Open();
                try
               {
                    string query1 = "Delete from Patient where SSNP = @SSNP";
                    string query2 = "Delete from Allergies where Allergies.IDM in (Select MedicalRecord.IDM from MedicalRecord where MedicalRecord.SSNP = @SSNP)";
                    string query3 = "Delete from Diagnosis where Diagnosis.IDM in (Select MedicalRecord.IDM from MedicalRecord where MedicalRecord.SSNP = @SSNP)";
                    string query4 = "Delete from Medications where Medications.IDM in (Select MedicalRecord.IDM from MedicalRecord where MedicalRecord.SSNP = @SSNP)";
                    string query5 = "Delete from MedicalRecord where SSNP = @SSNP";
                    string query6 = "Delete from Appointment where Appointment.SSNP = @SSNP";
                    string query7 = "Delete from Checks where Checks.IDA in (Select Appointment.IDA from Appointment where SSNP = @SSNP)";
                    string query8 = "Delete from ManagesP where ManagesP.SSNP = @SSNP";
                    string query9 = "Delete from Setup where IDM in (select MedicalRecord.IDM from MedicalRecord where MedicalRecord.SSNP = @SSNP)";
                    string query10 = "Delete from ViewMR where IDM in (select MedicalRecord.IDM from MedicalRecord where MedicalRecord.SSNP = @SSNP)";

                    SqlCommand cmd1 = new SqlCommand(query1, con);
                    SqlCommand cmd2 = new SqlCommand(query2, con);
                    SqlCommand cmd3 = new SqlCommand(query3, con);
                    SqlCommand cmd4 = new SqlCommand(query4, con);
                    SqlCommand cmd5 = new SqlCommand(query5, con);
                    SqlCommand cmd6 = new SqlCommand(query6, con);
                    SqlCommand cmd7 = new SqlCommand(query7, con);
                    SqlCommand cmd8 = new SqlCommand(query8, con);
                    SqlCommand cmd9 = new SqlCommand(query9, con);
                    SqlCommand cmd10 = new SqlCommand(query10, con);

                    cmd1.Parameters.AddWithValue("@SSNP", Int32.Parse(textSSN.Text));
                    cmd2.Parameters.AddWithValue("@SSNP", Int32.Parse(textSSN.Text));
                    cmd3.Parameters.AddWithValue("@SSNP", Int32.Parse(textSSN.Text));
                    cmd4.Parameters.AddWithValue("@SSNP", Int32.Parse(textSSN.Text));
                    cmd5.Parameters.AddWithValue("@SSNP", Int32.Parse(textSSN.Text));
                    cmd6.Parameters.AddWithValue("@SSNP", Int32.Parse(textSSN.Text));
                    cmd7.Parameters.AddWithValue("@SSNP", Int32.Parse(textSSN.Text));
                    cmd8.Parameters.AddWithValue("@SSNP", Int32.Parse(textSSN.Text));
                    cmd9.Parameters.AddWithValue("@SSNP", Int32.Parse(textSSN.Text));
                    cmd10.Parameters.AddWithValue("@SSNP", Int32.Parse(textSSN.Text));

                    
                    cmd2.ExecuteNonQuery();
                    cmd3.ExecuteNonQuery();
                    cmd4.ExecuteNonQuery();
                    cmd7.ExecuteNonQuery();
                    cmd9.ExecuteNonQuery();
                    cmd10.ExecuteNonQuery();
                    cmd6.ExecuteNonQuery();
                    cmd8.ExecuteNonQuery();
                    cmd5.ExecuteNonQuery();
                    cmd1.ExecuteNonQuery();
                    
                    MessageBox.Show("Patient Removed Successfully");
                    Clear();
                    ViewRecords();
                    ViewPatients();
                }
                catch
                {
                    MessageBox.Show("Please Check That You Filled In The Information Correctly");
                }
                if (con.State != ConnectionState.Closed)
                    con.Close();

            }
            else if (radioCC.Checked)
            {
                if (String.IsNullOrEmpty(textSSN.Text) || String.IsNullOrEmpty(textAcc.Text))
                {
                    MessageBox.Show("Please Make Sure That Patient SSN and Doctor Access Are Filled Before Removing");
                    return;
                }

                int SSND = Int32.Parse(textAcc.Text);
                if (textAcc.Text != "2019" && textAcc.Text != "2018" && textAcc.Text != "2020")
                {
                    MessageBox.Show("That Doctor SSN Does Not Exist");
                    return;
                }

                if (con.State != ConnectionState.Open)
                    con.Open();
                try
                {
                    string query3 = "Delete from ViewMR where IDM = @IDM AND SSND = @SSND)";
                    SqlCommand cmd3 = new SqlCommand(query3, con);
                    cmd3.Parameters.AddWithValue("@IDM", Int32.Parse(textMIDP.Text));
                    cmd3.Parameters.AddWithValue("@SSND", SSND);
                    cmd3.ExecuteNonQuery();
                    MessageBox.Show("Access Removed Successfully");
                    Clear();
                    ViewRecords();
                    ViewPatients();
                }
                catch
                {
                    MessageBox.Show("Please Check That You Filled In The Information Correctly");
                }
                if (con.State != ConnectionState.Closed)
                    con.Close();

            }
            else
            {
                MessageBox.Show("Please Select What You Want To Change");
            }
            ViewRecords();
            ViewPatients();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Opacity == 1)
                timer1.Stop();
            Opacity += .2;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Seclogin prod = new Seclogin();
            prod.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Secappointments prod = new Secappointments();
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

        private void Edit_Click(object sender, EventArgs e)
        {
            if (radioDD.Checked)
            {
                try
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();

                    string query = "Update Diagnosis set Name = @Name, StartDate = @StartDate, EndDate = @EndDate, Status = @Status, FamilyHistory = @FamilyHistory where IDD = @IDD AND IDM = @IDM";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@IDD", Int32.Parse(textDID.Text));
                    cmd.Parameters.AddWithValue("@IDM", Int32.Parse(textMIDMID.Text));
                    cmd.Parameters.AddWithValue("@Name", textDName.Text);
                    cmd.Parameters.AddWithValue("@StartDate", textDStart.Text);
                    cmd.Parameters.AddWithValue("@EndDate", textDEnd.Text);
                    cmd.Parameters.AddWithValue("@Status", textDStatus.Text);
                    cmd.Parameters.AddWithValue("@FamilyHistory", textHistory.Text);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Diagnosis Edited Successfully");
                    Clear();

                    int DIDDY = Int32.Parse(searchRecord.Text);
                    query = "Select MedicalRecord.SSNP, Diagnosis.* from MedicalRecord inner join Diagnosis on MedicalRecord.IDM = Diagnosis.IDM where Diagnosis.IDD = '" + DIDDY + "' ";
                    ViewRecordsSpec(query);

                    if (con.State != ConnectionState.Closed)
                        con.Close();
                    
                }
                catch
                {
                    MessageBox.Show("Please Enter both the Diagnosis and Medical Record ID's Correctly");
                }
            }

            else if (radioMM.Checked)
            {
                try
                {
                    if (String.IsNullOrEmpty(textMIDMID.Text) || String.IsNullOrEmpty(textMedicationID.Text))
                    {

                        MessageBox.Show("Please Enter Both the Medications ID and the Medical Record ID");
                        return;
                    }

                    else
                    {
                        if (con.State != ConnectionState.Open)
                            con.Open();

                        string query = "Update Medications set Name = @Name, StartDate = @StartDate, EndDate = @EndDate where IDM = @IDM AND ID = @MID";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@MID", Int32.Parse(textMedicationID.Text));
                        cmd.Parameters.AddWithValue("@IDM", Int32.Parse(textMIDMID.Text));
                        cmd.Parameters.AddWithValue("@Name", textMName.Text);
                        cmd.Parameters.AddWithValue("@StartDate", textMStart.Text);
                        cmd.Parameters.AddWithValue("@EndDate", textMEnd.Text);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Medication Edited Successfully");
                        Clear();
                        int IDMM = Int32.Parse(searchRecord.Text);
                        query = "Select MedicalRecord.SSNP, Medications.* from MedicalRecord inner join Medications on MedicalRecord.IDM = Medications.IDM where Medications.ID = '" + IDMM + "' ";
                        ViewRecordsSpec(query);

                        if (con.State != ConnectionState.Closed)
                            con.Close();
                        
                    }
                }
                catch
                {
                    MessageBox.Show("Please Enter All the Information Correctly");
                }
            }

            else if (radioAA.Checked)
            {
                try
                {
                    if (String.IsNullOrEmpty(textMIDMID.Text) || String.IsNullOrEmpty(textAID.Text))
                    {

                        MessageBox.Show("Please Enter Both the Allergie ID and the Medical Record ID");
                        return;
                    }

                    else
                    {
                        if (con.State != ConnectionState.Open)
                            con.Open();

                        string query = "Update Allergies set Source = @Source where ID = @IDA AND IDM = @IDM";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@IDA", Int32.Parse(textAID.Text));
                        cmd.Parameters.AddWithValue("@IDM", Int32.Parse(textMIDMID.Text));
                        cmd.Parameters.AddWithValue("@Source", textSource.Text);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Medication Edited Successfully");
                        Clear();
                        int IDMM = Int32.Parse(searchRecord.Text);
                        query = "Select MedicalRecord.SSNP, Allergies.* from MedicalRecord inner join Allergies on MedicalRecord.IDM = Allergies.IDM where Allergies.ID = '" + IDMM + "' ";
                        ViewRecordsSpec(query);

                        if (con.State != ConnectionState.Closed)
                            con.Close();
                        
                    }
                }
                catch
                {
                    MessageBox.Show("Please Enter All the Information Correctly");
                }
            }
            else if (radioPP.Checked)

            {
                if (String.IsNullOrEmpty(textSSN.Text) || String.IsNullOrEmpty(textMIDP.Text) || String.IsNullOrEmpty(textAcc.Text))
                {
                    MessageBox.Show("Please Make Sure That Patient SSN, Medical Record ID, and Doctor Access Are Filled Before Editing");
                    return;
                }

                int SSND = Int32.Parse(textAcc.Text);
                if (textAcc.Text != "2019" && textAcc.Text != "2018" && textAcc.Text != "2020")
                {
                    MessageBox.Show("That Doctor SSN Does Not Exist");
                    return;
                }
                if (con.State != ConnectionState.Open)
                    con.Open();
                try
                {
                    string query = "Update Patient set Name = @Name, Gender = @Gender, Age = @Age, Status = @Status, Phonenumber = @Phonenumber where SSNP = @SSNP";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Name", textPName.Text);
                    cmd.Parameters.AddWithValue("@Gender", textGender.Text);
                    cmd.Parameters.AddWithValue("@Age", Int32.Parse(textAge.Text));
                    cmd.Parameters.AddWithValue("@Status", textPStatus.Text);
                    cmd.Parameters.AddWithValue("@Phonenumber", Int32.Parse(textnbr.Text));
                    cmd.Parameters.AddWithValue("@SSND", SSND);
                    cmd.Parameters.AddWithValue("@SSNP", Int32.Parse(textSSN.Text));
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Patient Edited Successfully");
                    Clear();
                    ViewRecords();
                    ViewPatients();
                }
                catch
                {
                    MessageBox.Show("Please Check That You Filled In The Information Correctly");
                }
                if (con.State != ConnectionState.Closed)
                    con.Close();

            }
            else if (radioCC.Checked)
            {
                if (String.IsNullOrEmpty(textSSN.Text) || String.IsNullOrEmpty(textAcc.Text))
                {
                    MessageBox.Show("Please Make Sure That Patient SSN and Doctor Access Are Filled Before Editing");
                    return;
                }

                int SSND = Int32.Parse(textAcc.Text);
                if (textAcc.Text != "2019" && textAcc.Text != "2018" && textAcc.Text != "2020")
                {
                    MessageBox.Show("That Doctor SSN Does Not Exist");
                    return;
                }

                if (con.State != ConnectionState.Open)
                    con.Open();
                try{
                
                    string query3 = "Update ViewMR set SSND = @SSND where IDM = @IDM";
                    SqlCommand cmd3 = new SqlCommand(query3, con);
                    cmd3.Parameters.AddWithValue("@SSND", SSND);
                    cmd3.Parameters.AddWithValue("@IDM", Int32.Parse(textMIDP.Text));
                    cmd3.ExecuteNonQuery();
                    MessageBox.Show("Access Edited Successfully");
                    Clear();
                }
                catch
                {
                    MessageBox.Show("Please Check That You Filled In The Information Correctly");
                }
                if (con.State != ConnectionState.Closed)
                    con.Close();

            }
            else
            {
                MessageBox.Show("Please Select What You Want To Edit");
            }
            
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Secdashboard prod = new Secdashboard();
            prod.Show();
            this.Hide();
        }
 

        private void Medication_Name_TextChanged(object sender, EventArgs e)
        {

        }

        private void roundedPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dr_ID_TextChanged(object sender, EventArgs e)
        {

        }

        private void roundedPanel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            ViewRecords();
            //textDID.ReadOnly = false;
            //textAID.ReadOnly = false;
            //textMedicationID.ReadOnly = false;
            //textMIDMID.ReadOnly = false;
            textMIDMID.Text = "Search";
            Clear();
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void searchRecord_Enter(object sender, EventArgs e)
        {
            if (searchRecord.Text == "Search")
            {
                searchRecord.Text = "";
                searchRecord.ForeColor = Color.Black;
            }
        }

        private void searchRecord_Leave(object sender, EventArgs e)
        {
            if (searchRecord.Text == "")
            {
                searchRecord.Text = "Search";
                searchRecord.ForeColor = Color.Silver;
            }
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void textDStart_TextChanged(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void textAge_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void roundedPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        
    }

 }
        

        
    

