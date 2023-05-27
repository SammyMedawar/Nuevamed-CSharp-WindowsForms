using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NuevaMed
{
   
    public partial class UserControldays : UserControl
    {
        public static string static_day;

        public UserControldays()
        {
            InitializeComponent();
        }

        private void UserControldays_Load(object sender, EventArgs e)
        {

        }
        public void days(int numday)
        {
            
            lbdays.Text = numday + "";
        }

        private void lbdays_Click(object sender, EventArgs e)
        {
            static_day = lbdays.Text;
            Docappevent prod = new Docappevent();
            prod.ShowDialog();

        }
    }
}
