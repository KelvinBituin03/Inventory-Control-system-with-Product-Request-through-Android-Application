using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using NurseryVan_System.Database;

namespace NurseryVan_System
{
    public partial class frm_Inspection_of_Product_In_Branch : Form

    {

       
        MySqlCommand cmd;
        MySqlDataReader dr;
        MySqlDataAdapter da;
        string query;
        DataTable dt;
        string statuss;
        int qtyorder;
        decimal totalamountt;

        int idItem;
        int idSupp;

        decimal suppprice;
        decimal backprice;
        string backorder;
        public frm_Inspection_of_Product_In_Branch()
        {
            InitializeComponent();
        }


        private void frm_Inspection_of_Product_In_Branch_Load(object sender, EventArgs e)
        {
          //  label3.Text = frm_Supplier.orderid.ToString();
            txtRP.Focus();


            try
            {
                MySqlConnection conn = ConString.Connection;
                query = "select * from tbl_inventory where product_id = '" +frm_Inventory.getting_product_id+ "' and store_id = '"+frm_Inventory.getting_store_id+"'";
                cmd = new MySqlCommand(query, conn);
                dr = cmd.ExecuteReader();


                while (dr.Read())
                {
                    qtyorder = dr.GetInt32("subQTY");
                    //totalamountt = dr.GetDecimal("total_due");
                    //idItem = dr.GetInt32("product_id");
                    //idSupp = dr.GetInt32("supplier_id");
                }

                label5.Text = qtyorder.ToString();
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "1");
            }

            //try
            //{
            //    //conn.Open();
            //    //query = "select * from tbl_product where product_id = '" + idItem + "'";
            //    //cmd = new MySqlCommand(query, conn);
            //    //dr = cmd.ExecuteReader();


            //    //while (dr.Read())
            //    //{
            //    //    suppprice = dr.GetInt32("product_price");

            //    //}

            //    //conn.Close();
            //}

            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "2");
            //}

            txtRP.Text = "0";
            txtDP.Text = "0";
            generator1();

        }
        public void generator1()
        {
            NurseryVan_System.AutoGenerator.autoincrement("select max(order_id) from tbl_order ", txtOrderID);
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if(txtRP.Text == "")
            {
                MessageBox.Show("Please enter received of quantity.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            okforinspection();

        }
        public void okforinspection()
        {
            DateTime datenow = DateTime.Now;
            try
            {
                if (txtDays.Text.Contains("-"))
                {
                    MessageBox.Show("The date doesn't look right. Be sure to use the actual date.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dateExpected.Text = dateTimePicker1.Text;
                    return;

                }
                if (Convert.ToInt32(txtDP.Text) > 0)
                {
                    statuss = "Received";

                    decimal backamount = totalamountt - (totalamountt / qtyorder * Convert.ToDecimal(txtDP.Text));

                    MySqlConnection conn = ConString.Connection;
                    query = "update tbl_inventory set subQTY = '" + txtRP.Text + "', qty_replacement = '"+txtDP.Text+"', subStatus = '"+statuss+"' where product_id = '"+frm_Inventory.getting_product_id+"' and store_id = '"+frm_Inventory.getting_store_id+"';";
                    cmd = new MySqlCommand(query, conn);
                    dr = cmd.ExecuteReader();
                                                                                                                                                                                                                                                                            
                    MessageBox.Show("Inspection Successful. Unreceived product(s) will be automatically backorder.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    conn.Close();


                    //conn.Open();
                    //backorder = "Reordered";
                    //query = "update tbl_order set status = '" + backorder + "' where order_id = '" + frm_Supplier.orderid + "' and quantity_receive = 0";'
                    //cmd = new MySqlCommand(query, conn);
                    //dr = cmd.ExecuteReader();


                    //conn.Close();


                    backprice = suppprice * Convert.ToInt32(txtDP.Text);

                     conn = ConString.Connection;
                    query = "insert into tbl_inventory (store_id,product_id,qty_replacement, subStatus, status_pending, s_replacement, subQTY) values ('" + frm_Inventory.getting_store_id+ "','" + frm_Inventory.getting_product_id + "', '" + Convert.ToInt32(txtDP.Text) +"', 'Backorder', 'Pending','Replacement', '"+ Convert.ToInt32(txtRP.Text) + "')";
                    cmd = new MySqlCommand(query, conn);
                    dr = cmd.ExecuteReader();


                    // MessageBox.Show("Order Successful. ");
                    conn.Close();

                }
                else
                {
                    statuss = "Received";

                    MySqlConnection conn = ConString.Connection;
                    query = "update tbl_inventory set subStatus = 'Received' where product_id = '" + frm_Inventory.getting_product_id + "' and store_id = '" + frm_Inventory.getting_store_id + "'";
                    cmd = new MySqlCommand(query, conn);
                    dr = cmd.ExecuteReader();

                    MessageBox.Show("Inspection Successful. ", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    conn.Close();


                }

                this.Hide();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "3");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            if (txtRP.Text == "0")
            {
                txtRP.Focus();
                txtRP.Select(0, 0);

            }
        }

        private void txtSearch1_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtRP.Text.Equals(null) == true)
            {
                txtRP.Text = "0";
                txtRP.ForeColor = Color.Gray;
            }
            else
            {
                txtRP.ForeColor = Color.Black;
            }
            if (e.KeyCode == Keys.Back)
            {
                if (txtRP.Text.Length == 0)
                {


                    txtRP.Text = "0";

                    txtRP.ForeColor = Color.Gray;
                    Cursor.Current = Cursors.IBeam;


                }
            }
        }

        private void txtSearch1_Leave(object sender, EventArgs e)
        {
            if (txtRP.Text.Length == 0)
            {
                txtRP.Text = "0";
                txtRP.ForeColor = SystemColors.GrayText;
            }
        }

        private void txtSearch1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dateExpected_ValueChanged(object sender, EventArgs e)
        {
            DateTime date1 = dateTimePicker1.Value;
            DateTime date2 = dateExpected.Value;

            TimeSpan difference = date2.Subtract(date1);

            txtDays.Text = Convert.ToInt32(date2.Subtract(date1).Days).ToString();



            if ((date2 < date1 && dateTimePicker1.Text != dateExpected.Text))
            {
                MessageBox.Show("The date doesn't look right. Be sure to use the actual date.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateExpected.Text = dateTimePicker1.Text;
            }
        }
        private void txtDP_TextChanged(object sender, EventArgs e)
        {

        }
        private void txtRP_TextChanged(object sender, EventArgs e)
        {
            btnOK.Enabled = true;
            btnOK.BackColor = Color.Gold;

            if (txtRP.Text == "")
            {
                txtRP.Text = "0";
                if (txtRP.Text == "0")
                {
                    txtRP.Focus();
                    txtRP.Select(0, 1);

                }

            }


            if (Convert.ToInt32(txtRP.Text) > qtyorder)
            {
                txtRP.Text = "";
                MessageBox.Show("You've entered amount is greater than quantity ordered.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);




            }
            else
            {
                txtDP.Text = (qtyorder - Convert.ToInt32(txtRP.Text)).ToString();
            }
        }
    }
}
