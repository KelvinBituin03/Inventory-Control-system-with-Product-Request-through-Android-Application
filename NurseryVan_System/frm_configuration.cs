using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DGVPrinterHelper;
using MySql.Data.MySqlClient;
using NurseryVan_System.Database;

namespace NurseryVan_System
{
    public partial class frm_edit_replacement : Form
    {
        string getproductid;
        int store_id;
        string dateexpected;
        public frm_edit_replacement()
        {
            InitializeComponent();
        }

        public void showCategory()
        {
            MySqlConnection Conn = ConString.Connection;


            string Query = "Select category from tbl_product group by category";
            MySqlCommand cmd = new MySqlCommand(Query, Conn);
            MySqlDataReader myReader;

            AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
            try
            {

                myReader = cmd.ExecuteReader();

                while (myReader.Read())
                {
                    MyCollection.Add(myReader.GetString(0));
                    txtCategory.Items.Add(myReader[0]);
                 

                }

                txtCategory.AutoCompleteCustomSource = MyCollection;
                comboBox1.AutoCompleteCustomSource = MyCollection;
                Conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error3");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            DateTime datenow = DateTime.Now;

            if (string.IsNullOrWhiteSpace(txtNotifyDays.Text.Trim('0')) || txtNotifyDays.Text =="")
            {
                MessageBox.Show("Please enter require field.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {



                //  txtSubDays.Text = (Expiry.Value - DateTime.Today).TotalDays.ToString("#");

            
                if (txtNotifyDays.Text == "")
                {

                    Expiry.Text = datenow.ToString("yyyy-MM-dd");

                }
                else
                {


                    Expiry.Value = Expiry.Value.AddDays(Convert.ToDouble(txtNotifyDays.Text));
                }

                //txtNotifyDays.Text = txtSubDays.Text;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                MySqlConnection Conn = ConString.Connection;


                string Query = "Update tbl_product set notify_days = '"+txtNotifyDays.Text+"', notify_expired = '"+Expiry.Text+"' where category = '"+txtCategory.Text+"'";
                MySqlCommand cmd = new MySqlCommand(Query, Conn);


                MySqlDataReader myReader;
                myReader = cmd.ExecuteReader();



                while (myReader.Read())
                {

                }
                Conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            DGVCategoryNotifyExpired();
            MessageBox.Show("Applied successfully.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            txtNotifyDays.Text = "";


      

                Expiry.Text = datenow.ToString("yyyy-MM-dd");

            

        }
        public void DGVCategoryNotifyExpired()
        {



            MySqlConnection Conn = ConString.Connection;

            MySqlCommand cmd = new MySqlCommand("SELECT Category, notify_days as 'Days Interval' FROM tbl_product  group by Category;", Conn);
            cmd.CommandTimeout = 0;

            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmd;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bSource = new BindingSource();

                bSource.DataSource = dbdataset;
                dataGridView1.DataSource = bSource;
                sda.Update(dbdataset);
                //dataGridView2.DefaultCellStyle.SelectionBackColor = Color.Pink;
                Conn.Close();


              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error6");
            }

       


        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewCell cell = null;
            foreach (DataGridViewCell selectedCell in dataGridView1.SelectedCells)
            {
                cell = selectedCell;
                break;
            }

            if (cell != null)
            {



                DataGridViewRow row = cell.OwningRow;



                txtCategory.Text = row.Cells[0].Value.ToString();
              
       
            }
        }

        private void frm_edit_replacement_Load(object sender, EventArgs e)
        {
            showCategory();
            DGVCategoryNotifyExpired();
        }
      



       

      

        private void cbServer_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void cbServer_SelectedIndexChanged(object sender, EventArgs e)
        {




           
        }

        private void dateExpected_ValueChanged(object sender, EventArgs e)
        {
        }

        private void txtNotifyDays_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtNotifyDays_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
