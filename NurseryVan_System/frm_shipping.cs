using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NurseryVan_System
{
    public partial class frm_shipping : Form
    {
        public static string mDateDelivery;
        public static string ok, cancel;
        public frm_shipping()
        {
            InitializeComponent();
        }

        private void frm_shipping_Load(object sender, EventArgs e)
        {

            mDateDelivery = dateExpected.Text;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            cancel = btnCancel.Text;
            this.Hide();
        }

        private void dateExpected_ValueChanged(object sender, EventArgs e)
        {

         dateTimePicker1.Text=   DateTime.Now.ToString("yyyy-MM-dd");
            DateTime date1 = dateTimePicker1.Value;
            DateTime date2 = dateExpected.Value;

            TimeSpan difference = date2.Subtract(date1);

           

          

            if ((date2 < date1 && dateTimePicker1.Text != dateExpected.Text))
            {
                //  MessageBox.Show("The date doesn't look right. Be sure to use the actual date.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateExpected.Text = dateTimePicker1.Text;
            }
        }

        private void btnAddtoCart_Click(object sender, EventArgs e)
        {
            if(dateExpected.Text == DateTime.Now.ToString("yyyy-MM-dd"))
            {
                MessageBox.Show("Set for Date Deliver must not be equal for date now.", "Fabula's Merchandise System");
                return;
            }

            ok = btnOK.Text;

            mDateDelivery = dateExpected.Text;
            this.Hide();
        }
    }
}
