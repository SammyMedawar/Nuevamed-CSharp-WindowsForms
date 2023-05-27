using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NuevaMed
{
    public partial class trial : Form
    {
        public trial()
        {
            InitializeComponent();
        }

        private void addNoteToDay_Click(object sender, EventArgs e)
        {
            EventUI dialog = new EventUI();

            string datetime = Utils.GetDateString(selectedGridItem.getDateTime());

            dialog.setInitUIView(datetime);

            DialogResult dr = dialog.ShowDialog();
            if (dr == DialogResult.OK)
            {
                refreshCalenderGrid(currentMonthCounter);
            }
        }
    }
}
