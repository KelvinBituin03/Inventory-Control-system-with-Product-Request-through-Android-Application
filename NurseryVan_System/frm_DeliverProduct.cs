using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using NurseryVan_System.Database;

namespace NurseryVan_System
{
    public partial class frm_DeliverProduct : Form
    {
        string supplierid;
        string productid;
        string dateexpected, dateordered;


        
    
        public frm_DeliverProduct()
        {
            InitializeComponent();
        }

        private void btnAddproduct1_Click(object sender, EventArgs e)
        {
           


        }
        private void changeRowColor1()
        {
            try
            {


                foreach (DataGridViewRow Myrow in metroGrid2.Rows)
                {
                    if (Myrow.Cells["Status"].Value.ToString() == "Pending Ordered")
                    {
                        Myrow.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#AAF726");
                        Myrow.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;

                    }
                    else if (Myrow.Cells["Uncheck Status"].Value.ToString() == "Uncheck")
                    {
                        Myrow.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF8000");
                      
                        Myrow.DefaultCellStyle.ForeColor = System.Drawing.Color.White;

                    }
                    //else if (Myrow.Cells["Status"].Value.ToString() == "Out of Stocked")
                    //{
                    //    Myrow.DefaultCellStyle.BackColor = System.Drawing.Color.Red;
                    //    Myrow.DefaultCellStyle.ForeColor = System.Drawing.Color.White;

                    //}
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        private void frm_DeliverProduct_Load(object sender, EventArgs e)
        {
            DGVEditDelivery();
        }

        void DGVEditDelivery()
        {
            MySqlConnection Conn = ConString.Connection;
            MySqlCommand cmd = new MySqlCommand("SELECT tbl_product.product_id as 'Product ID',  tbl_supplierinfo.supplier_id as 'Supplier ID',  tbl_product.product_name as 'Product', tbl_supplierinfo.company  as 'Supplier Name', tbl_order.date_expected as 'Date Expected',tbl_order.status as 'Status', tbl_order.subStatus1 as 'Uncheck Status' ,tbl_order.date_ordered as 'Date Ordered'  FROM tbl_order inner join tbl_product on tbl_order.product_id = tbl_product.product_id inner join tbl_supplierinfo on tbl_order.supplier_id = tbl_supplierinfo.supplier_id  where tbl_order.status = 'Pending Ordered' and date_ordered < date_expected and DATE(NOW()) or date_ordered < date_expected and DATE(NOW()) and tbl_order.status = 'Backorder' or tbl_order.subStatus1 = 'Uncheck' group by tbl_order.product_id, tbl_order.supplier_id, tbl_order.status, tbl_order.date_expected, tbl_order.date_ordered order by tbl_order.order_id desc;", Conn);
            cmd.CommandTimeout = 0;


            try
            {

                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmd;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bSource = new BindingSource();
                bSource.DataSource = dbdataset;
                metroGrid2.DataSource = bSource;
                sda.Update(dbdataset);

                MySqlDataReader myReader;
                myReader = cmd.ExecuteReader();


                metroGrid2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

                Conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
           

            metroGrid2.Columns[0].Visible = false;
            metroGrid2.Columns[1].Visible = false;
            metroGrid2.Columns[7].Visible = false;

            changeRowColor1();
      
        }


        private void cbStore_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbStore_TextChanged(object sender, EventArgs e)
        {

         
       
           
         
        }

        private void metroGrid2_SelectionChanged(object sender, EventArgs e)
        {

            DataGridViewCell cell = null;
            foreach (DataGridViewCell selectedCell in metroGrid2.SelectedCells)
            {
                cell = selectedCell;
                break;
            }

            if (cell != null)
            {



                DataGridViewRow row = cell.OwningRow;

                productid = row.Cells[0].Value.ToString();
                supplierid = row.Cells[1].Value.ToString();
                dateexpected = row.Cells[4].Value.ToString();
                dateordered = row.Cells[7].Value.ToString();


            }
         

        }

        private void metroTile1_Click(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            DateTime datenow = DateTime.Now;
            if (dateexpected == dateExpected1.Text || dateExpected1.Text == datenow.ToString("yyyy-MM-dd"))
            {

                MessageBox.Show("Please set date of delivery", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.None);

                return;
            }
            try
            {
                MySqlConnection Conn = ConString.Connection;


                string Query = "Update tbl_order set date_expected = '" + dateExpected1.Text + "' where " +
                    "product_id = '" + productid + "' and supplier_id = '" + supplierid + "' and status = 'Pending Ordered'" +
                    " and date_ordered = '"+dateordered+"' and date_expected = '"+dateexpected+"' or product_id = '" + productid + "' and supplier_id = '" + supplierid + "' and status = 'Backorder' and date_ordered = '" + dateordered + "' and date_expected = '" + dateexpected + "' and date_ordered < date_expected and DATE(NOW());Update tbl_order set subStatus1 = 'Checked', date_expected = '"+dateExpected1.Text+"' where product_id = '" + productid+"' and supplier_id = '"+supplierid+ "' and subStatus1 = 'Uncheck' and date_ordered = '" + dateordered + "' and date_expected = '" + dateexpected + "'";
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

            MessageBox.Show("Updated successfully.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            DGVEditDelivery();
        }

        private void dateExpected1_ValueChanged(object sender, EventArgs e)
        {
           
            dateTimePicker1.Text = DateTime.Now.ToString("yyyy-MM-dd");
            DateTime startdate = dateTimePicker1.Value;
            DateTime enddate = dateExpected1.Value;


           

            DateTime date1 = dateTimePicker1.Value;
            DateTime date2 = dateExpected1.Value;

            TimeSpan difference = date2.Subtract(date1);



            if ((date2 < date1 && dateTimePicker1.Text != dateExpected1.Text))
            {
                //  MessageBox.Show("The date doesn't look right. Be sure to use the actual date.", "Nursery Van System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateExpected1.Text = dateTimePicker1.Text;
            }
        }
    }
}
