using System;
using System.IO;
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
    

    public partial class Createacc : Form
    {
        string destfile = "default.jpg";
        string source;
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
            public Createacc()
            {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRect(0, 0, Width, Height, 20, 20));
        }

            private void clear()
            {
                string parent = System.AppDomain.CurrentDomain.BaseDirectory;

                parent = @parent + @"images\default.jpg";
                pictureBox1.ImageLocation = @parent;
                txtName.Text = "";
                textSSN.Text = "";
                textEmail.Text = "";
                textPhone.Text = "";
                textOfficeHours.Text = "";
                textUsername.Text = "";
                textPassword.Text = "";
            }

        private void button1_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            Seclogin prod = new Seclogin();
            prod.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog open = new OpenFileDialog(); //open file explorer 
                open.Filter = "All Images Files (*.png;*.jpeg;*jpg) | *.png;*.jpeg;*jpg"; //type of images
                if (open.ShowDialog() == DialogResult.OK)   //for ok to work properly
                {
                    string path = @open.FileName;   //saves the file path of the file 
                    pictureBox1.ImageLocation = @open.FileName;
                }


                string parent = System.AppDomain.CurrentDomain.BaseDirectory; 
                source = @pictureBox1.ImageLocation;
                string filename = Path.GetFileName(source); 
                parent = @parent + @"images\"; 

                destfile = System.IO.Path.Combine(parent, filename); //combining the file and the pic
                source = @destfile;   //uploading the pic to the pic box 

            }
            catch (Exception )
            {
                
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            

            try
            {
                if (String.IsNullOrEmpty(textSSN.Text) || String.IsNullOrEmpty(textUsername.Text))
                {
                    MessageBox.Show("Please Enter both the Username and the SSN!");
                    clear();
                    throw (MSG);
                }

                else
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();

                    string parent;
                    parent = System.AppDomain.CurrentDomain.BaseDirectory;
                    parent = @parent + @"images\";

                    string picture = Path.GetFileName(destfile);
                    if (picture != "default.jpg")
                    {

                        source = @pictureBox1.ImageLocation;
                        string filename = Path.GetFileName(source);
                        destfile = System.IO.Path.Combine(parent, filename); //combining the file and the pic
                        File.Copy(@source, @destfile, true); //to copy the pic inside the app folder 
                    }

                    string query = "Insert into Receptionist values (@SSNR, @Username, @SSNA,  @Name , @Email , @OfficeHours , @Phonenumber , @Picture)";
                    string query2 = "Insert into Login (Username, Password) values (@Username, @Password)";


                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlCommand cmd2 = new SqlCommand(query2, con);

                    cmd.Parameters.AddWithValue("@SSNR", Int32.Parse(textSSN.Text));
                    cmd.Parameters.AddWithValue("@SSNA", 20210000);
                    cmd.Parameters.AddWithValue("@Name", txtName.Text);
                    cmd.Parameters.AddWithValue("@Email", textEmail.Text);
                    cmd.Parameters.AddWithValue("@OfficeHours", textOfficeHours.Text);
                    cmd.Parameters.AddWithValue("@Phonenumber", Int32.Parse(textPhone.Text));
                    cmd.Parameters.AddWithValue("@Picture", @picture);
                    cmd.Parameters.AddWithValue("@Username", textUsername.Text);
                    cmd2.Parameters.AddWithValue("@Username", textUsername.Text);
                    cmd2.Parameters.AddWithValue("@Password", textPassword.Text);


                    cmd2.ExecuteNonQuery();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Receptionist added successfully");


                    if (con.State != ConnectionState.Closed)
                        con.Close();



                    clear();

                }
            }
            catch (Exception )
            {
                MessageBox.Show("Please fill in all the fields correctly");     //used try catch to inform the user when there is an error 
            }
                

            
            
        }

        private void button3_Click(object sender, EventArgs e)
        {

            try
            {
                if (String.IsNullOrEmpty(textSSN.Text) || String.IsNullOrEmpty(textUsername.Text))  
                {
                    MessageBox.Show("Please Enter both the Username and the SSN!");
                    clear();
                    throw(MSG);
                }
                else
                {
                    string query = "Delete from Receptionist where SSNR = @SSN ";
                    string query2 = "Delete from Login where Username = @Username";
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlCommand cmd2 = new SqlCommand(query2, con);
                    cmd.Parameters.AddWithValue("@SSN", Int32.Parse(textSSN.Text));
                    cmd2.Parameters.AddWithValue("@Username", textUsername.Text);

                    if (con.State != ConnectionState.Open)
                        con.Open();

                    cmd.ExecuteNonQuery();
                    cmd2.ExecuteNonQuery();

                    if (con.State == ConnectionState.Open)
                        con.Close();
                    MessageBox.Show("The Receptionist Was Successfully Removed");
                }
                
            }
            catch (Exception MSG)
            {
                MessageBox.Show("Please Enter the SSN and Username of the Receptionist You Want to Remove");
            }

            string parent = System.AppDomain.CurrentDomain.BaseDirectory;

            clear();
            
        }

        private void Createacc_Load(object sender, EventArgs e)
        {
            
            string parent = System.AppDomain.CurrentDomain.BaseDirectory; 
            parent = @parent + @"images\default.jpg";
            pictureBox1.ImageLocation = @parent;
        }

        private void textEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void textUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {

            try
            {
                
                    string parent = System.AppDomain.CurrentDomain.BaseDirectory;
                    parent = @parent + @"images\default.jpg";
                    string picture = Path.GetFileName(destfile);

                    if (con.State != ConnectionState.Open)
                        con.Open();

                    if (!String.IsNullOrEmpty(txtName.Text))
                    {
                        string query = "Update Receptionist set Name = @Name where SSNR = @SSN";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@SSN", Int32.Parse(textSSN.Text));
                        cmd.Parameters.AddWithValue("@Name", txtName.Text);
                        cmd.ExecuteNonQuery();

                    }
                    if (!String.IsNullOrEmpty(textEmail.Text))
                    {
                        string query = "Update Receptionist set Email = @Email where SSNR = @SSN";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@SSN", Int32.Parse(textSSN.Text));
                        cmd.Parameters.AddWithValue("@Email", textEmail.Text);
                        cmd.ExecuteNonQuery();

                    }
                    if (String.IsNullOrEmpty(textOfficeHours.Text))
                    {
                        string query = "Update Receptionist set OfficeHours = @OfficeHours where SSNR = @SSN";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@SSN", Int32.Parse(textSSN.Text));
                        cmd.Parameters.AddWithValue("@OfficeHours", textOfficeHours.Text);
                        cmd.ExecuteNonQuery();

                    }
                    if (!String.IsNullOrEmpty(textPhone.Text))
                    {
                        string query = "Update Receptionist set Phonenumber = @Phone where SSNR = @SSN";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@SSN", Int32.Parse(textSSN.Text));
                        cmd.Parameters.AddWithValue("@Phone", Int32.Parse(textPhone.Text));
                        cmd.ExecuteNonQuery();
                    }
                    if (@pictureBox1.ImageLocation != @parent)
                    {
                        string query = "Update Receptionist set Picture = @Picture where SSNR = @SSN";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@Picture", @picture);
                        cmd.Parameters.AddWithValue("@SSN", Int32.Parse(textSSN.Text));
                        cmd.ExecuteNonQuery();
                    }
                    if (!String.IsNullOrEmpty(textPassword.Text))
                    {
                        string query = "Update Login set Password = @Password where Username = @Username";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@Password", textPassword.Text);
                        cmd.Parameters.AddWithValue("@Username", textUsername.Text);
                        cmd.Parameters.AddWithValue("@SSN", Int32.Parse(textSSN.Text));
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Edited Successfully");
                
                
            }

            catch (Exception)
            {
                MessageBox.Show("Invalid SSN or Username!");
            }

            clear();
        }

        private void textSSN_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            advancedUpdate prod = new advancedUpdate();
            prod.Show();
            this.Hide();
        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Opacity == 1)
                timer1.Stop();
            Opacity += .2;
        }

        public Exception MSG { get; set; }
    }
}
