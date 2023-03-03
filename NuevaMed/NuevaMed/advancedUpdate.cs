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

namespace NuevaMed
{
    public partial class advancedUpdate : Form
    {

        SqlDataAdapter adapter1;
        SqlDataAdapter adapter2;
        SqlCommandBuilder builder1;
        SqlCommandBuilder builder2;
        DataTable dt1;
        DataTable dt2;
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MYDBD"].ToString());

        public void display()
        {
            if (con.State != ConnectionState.Open)
                con.Open();

            string query = "Select * from Receptionist";
            dt1 = new DataTable();
            adapter1 = new SqlDataAdapter(query, con);
            adapter1.Fill(dt1);
            dataReceptionist.DataSource = dt1;

            string query2 = "Select * from Login";
            dt2 = new DataTable();
            adapter2 = new SqlDataAdapter(query2, con);
            adapter2.Fill(dt2);
            dataLogin.DataSource = dt2;

            if (con.State == ConnectionState.Open)
                con.Close();
        }

        public advancedUpdate()
        {
            InitializeComponent();
        }

        private void advancedUpdate_Load(object sender, EventArgs e)
        {

            display();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            Createacc prod = new Createacc();
            prod.Show();
            this.Hide();
        }

        private void Load_Click(object sender, EventArgs e)
        {
            
        }

        private void Update_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                //int rowIndex = dataReceptionist.CurrentCell.RowIndex;
                //dataReceptionist.Rows.RemoveAt(rowIndex);

                //int rowIndex2 = dataLogin.CurrentCell.RowIndex;
                //dataLogin.Rows.RemoveAt(rowIndex2);
                

                builder1 = new SqlCommandBuilder(adapter1);
                adapter1.Update(dt1);
                builder2 = new SqlCommandBuilder(adapter2);
                adapter2.Update(dt2);

                con.Close();

            }
            catch (Exception)
            {
                MessageBox.Show("Username or SSN cannot be Updated!");
            }
        }

        private void dataReceptionist_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataLogin_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Update_Click_1(object sender, EventArgs e)
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

        private void roundButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void roundButton2_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                builder1 = new SqlCommandBuilder(adapter1);
                adapter1.Update(dt1);
                builder2 = new SqlCommandBuilder(adapter2);
                adapter2.Update(dt2);
                MessageBox.Show("Edited Successfully");

                con.Close();
            }
            catch
            {
                MessageBox.Show("You cant edit this information "); 
            }
        }

        private void Load1_Click(object sender, EventArgs e)
        {
            display();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }
    }
}
