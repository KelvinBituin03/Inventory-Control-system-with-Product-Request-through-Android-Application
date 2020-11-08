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
    public partial class Inspection : Form
    {


       
        public Inspection()
        {
            InitializeComponent();
        }

    

          

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
        private void Inspection_Load(object sender, EventArgs e)
        {

            //if (frm_Inventory.mStatus.ToString() == "Pending Ordered")
            //{

            //    return;
            //}
                if (frm_Inventory.mStatus.ToString() == "Ordered")
            {



                label3.Text = frm_Inventory.orderid.ToString();
                txtRP.Focus();


                try
                {
                    MySqlConnection conn = ConString.Connection;
                    query = "select sum(quantity) as 'QTY', sum(total_due) as 'Total Due', product_id, supplier_id from tbl_order where " +
                        "product_id = '" + frm_Inventory.mProduct_ID + "' and supplier_id =  '" + frm_Inventory.mSupplier_ID + "' and status = 'Ordered' and date_expected = '" + frm_Inventory.mDateExpected + "' and date_ordered = '" + frm_Inventory.mDateOrdered + "'";
                    cmd = new MySqlCommand(query, conn);
                    dr = cmd.ExecuteReader();


                    while (dr.Read())
                    {
                        // qtyorder = dr.GetInt32("QTY");
                        qtyorder = Convert.ToInt32(frm_Inventory.mOrderedQTY.ToString());
                        totalamountt = dr.GetDecimal("Total Due");
                        idItem = dr.GetInt32("product_id");
                        idSupp = dr.GetInt32("supplier_id");
                    }

                    label5.Text = qtyorder.ToString();

                    conn.Close();
                }



                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "1");
                }

                try
                {
                    MySqlConnection conn = ConString.Connection;
                    query = "select * from tbl_product where product_id = '" + idItem + "'";
                    cmd = new MySqlCommand(query, conn);
                    dr = cmd.ExecuteReader();


                    while (dr.Read())
                    {
                        suppprice = dr.GetInt32("product_price");

                    }

                    conn.Close();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "2");
                }

                txtRP.Text = "0";
                txtDP.Text = "0";
                generator1();
            }
          else  if (frm_Inventory.mStatus.ToString() == "Overdue Ordered")
            {



                label3.Text = frm_Inventory.orderid.ToString();
                txtRP.Focus();


                try
                {
                    MySqlConnection conn = ConString.Connection;
                    query = "select sum(quantity) as 'QTY', sum(total_due) as 'Total Due', product_id, supplier_id from tbl_order where " +
                        "product_id = '" + frm_Inventory.mProduct_ID + "' and supplier_id =  '" + frm_Inventory.mSupplier_ID + "' and status = 'Overdue Ordered' and date_expected = '" + frm_Inventory.mDateExpected + "' and date_ordered = '" + frm_Inventory.mDateOrdered + "'";
                    cmd = new MySqlCommand(query, conn);
                    dr = cmd.ExecuteReader();


                    while (dr.Read())
                    {
                        // qtyorder = dr.GetInt32("QTY");
                        qtyorder = Convert.ToInt32(frm_Inventory.mOrderedQTY.ToString());
                        totalamountt = dr.GetDecimal("Total Due");
                        idItem = dr.GetInt32("product_id");
                        idSupp = dr.GetInt32("supplier_id");
                    }

                    label5.Text = qtyorder.ToString();

                    conn.Close();
                }



                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "1");
                }

                try
                {
                    MySqlConnection conn = ConString.Connection;
                    query = "select * from tbl_product where product_id = '" + idItem + "'";
                    cmd = new MySqlCommand(query, conn);
                    dr = cmd.ExecuteReader();


                    while (dr.Read())
                    {
                        suppprice = dr.GetInt32("product_price");

                    }

                    conn.Close();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "2");
                }

                txtRP.Text = "0";
                txtDP.Text = "0";
                generator1();
            }
            else 
            {



                label3.Text = frm_Inventory.orderid.ToString();
                txtRP.Focus();


                try
                {
                    MySqlConnection conn = ConString.Connection;
                    query = "select sum(quantity) as 'QTY', sum(total_due) as 'Total Due', product_id, supplier_id from tbl_order where product_id = '" + frm_Inventory.mProduct_ID + "' and supplier_id =  '" + frm_Inventory.mSupplier_ID + "' and status = 'Backorder' and date_expected = '" + frm_Inventory.mDateExpected + "' and date_ordered = '" + frm_Inventory.mDateOrdered + "'";
                    cmd = new MySqlCommand(query, conn);
                    dr = cmd.ExecuteReader();


                    while (dr.Read())
                    {
                        qtyorder = Convert.ToInt32(frm_Inventory.mOrderedQTY.ToString());
                        totalamountt = dr.GetDecimal("Total Due");
                        idItem = dr.GetInt32("product_id");
                        idSupp = dr.GetInt32("supplier_id");
                    }

                    label5.Text = qtyorder.ToString();

                    conn.Close();
                }



                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "1");
                }

                try
                {
                    MySqlConnection conn = ConString.Connection;
                    query = "select * from tbl_product where product_id = '" + idItem + "'";
                    cmd = new MySqlCommand(query, conn);
                    dr = cmd.ExecuteReader();


                    while (dr.Read())
                    {
                        suppprice = dr.GetInt32("product_price");

                    }

                    conn.Close();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "2");
                }

                txtRP.Text = "0";
                txtDP.Text = "0";
                generator1();
            }

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
           // if (txtDP.Text != "0")
           // {

           ////     lblInput.Visible = true;
           //     //dateExpected.Visible = true;

           //     //dateExpected.CustomFormat = "yyyy-MM-dd";
           //     //btnOK.Location = new Point(215, 172);
           //     //btnBack.Location = new Point(372, 172);

           // }
           // else
           // {
           //     //lblInput.Visible = false;
           //     //dateExpected.Visible = false;
           //     //btnOK.Location = new Point(215, 132);
           //     //btnBack.Location = new Point(372, 132);
           //     return;


           // }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtRP.Text == "")
            {
                MessageBox.Show("Please enter receive of quantity.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (frm_Inventory.mStatus.ToString() == "Ordered")
            {
                okforinspection();
            }
          else  if (frm_Inventory.mStatus.ToString() == "Overdue Ordered")
            {
                okforinspection2();
            }
            else
            {
                okforinspection1();
            }


               

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
                    //1
                    statuss = "Received";

                    decimal backamount = totalamountt - (totalamountt / qtyorder * Convert.ToDecimal(txtDP.Text));

                    MySqlConnection conn = ConString.Connection;
                    query = "update tbl_order set total_due = '" + backamount + "' ,quantity_receive = '" + Convert.ToInt32(txtRP.Text) + "' , damage_product = '" + Convert.ToInt32(txtDP.Text) + "' , status = '" + statuss + "' where product_id = '" + frm_Inventory.mProduct_ID + "'  and supplier_id = '" + frm_Inventory.mSupplier_ID + "' and status = 'Ordered' " +
                        "and date_expected = '"+frm_Inventory.mDateExpected+ "' and date_ordered = '" + frm_Inventory.mDateOrdered + "'";
                    cmd = new MySqlCommand(query, conn);
                    dr = cmd.ExecuteReader();

                    MessageBox.Show("Inspection Successful. Unreceived/Damaged product(s) will be automatically backorder.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    conn.Close();


                    // conn = ConString.Connection;
                    //backorder = "Reordered";
                    //query = "update tbl_order set status = '" + backorder + "' where product_id = '" + frm_Inventory.mProduct_ID + "'  and supplier_id = '" + frm_Inventory.mSupplier_ID + "' and status = 'Ordered' and quantity_receive = 0";
                    //cmd = new MySqlCommand(query, conn);
                    //dr = cmd.ExecuteReader();


                    //conn.Close();


                    backprice = suppprice * Convert.ToInt32(txtDP.Text);

                    if (frm_Inventory.receivedzero == 0)
                    {

                    }
                    conn = ConString.Connection;
                    query = "insert into tbl_order (order_id,product_id,supplier_id,total_due,quantity,quantity_receive,damage_product,status,date_ordered, date_expected, subStatus1) values ('" + txtOrderID.Text + "','" + idItem + "','" + idSupp + "', '" + Convert.ToDecimal(backprice) + "','" + Convert.ToInt32(txtDP.Text) + "',0,0,'Backorder','" + dateTimePicker1.Text + "', '" + DateTime.Now.ToString("yyyy-MM-dd") + "', 'Uncheck')";
                    cmd = new MySqlCommand(query, conn);
                    dr = cmd.ExecuteReader();


                    // MessageBox.Show("Order Successful. ");
                    conn.Close();

                }
                else
                {
                    statuss = "Received";
                    //2
                    MySqlConnection conn = ConString.Connection;
                    query = "update tbl_order set quantity_receive = '" + Convert.ToInt32(txtRP.Text) + "' , damage_product = '" + Convert.ToInt32(txtDP.Text) + "' , status = '" + statuss + "' where product_id = '" + frm_Inventory.mProduct_ID + "'  and supplier_id = '" + frm_Inventory.mSupplier_ID + "' and status = 'Ordered' and date_expected = '" + frm_Inventory.mDateExpected + "' and date_ordered = '" + frm_Inventory.mDateOrdered + "'";
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



        public void okforinspection1()
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
                    query = "update tbl_order set total_due = '" + backamount + "' ,quantity_receive = '" + Convert.ToInt32(txtRP.Text) + "' , damage_product = '" + Convert.ToInt32(txtDP.Text) + "' , status = '" + statuss + "' where product_id = '" + frm_Inventory.mProduct_ID + "' and supplier_id =  '" + frm_Inventory.mSupplier_ID + "' and status = 'Backorder' and date_expected = '" + frm_Inventory.mDateExpected + "' and date_ordered = '" + frm_Inventory.mDateOrdered + "'";
                    cmd = new MySqlCommand(query, conn);
                    dr = cmd.ExecuteReader();

                    MessageBox.Show("Inspection Successful. Unreceived product(s) will be automatically backorder.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    conn.Close();


                    // conn = ConString.Connection;
                    //backorder = "Reordered";
                    //query = "update tbl_order set status = '" + backorder + "' where product_id = '" + frm_Inventory.mProduct_ID + "'  and supplier_id = '" + frm_Inventory.mSupplier_ID + "' and status = 'Ordered' and quantity_receive = 0";
                    //cmd = new MySqlCommand(query, conn);
                    //dr = cmd.ExecuteReader();


                    //conn.Close();


                    backprice = suppprice * Convert.ToInt32(txtDP.Text);

                    if (frm_Inventory.receivedzero == 0)
                    {

                    }
                    conn = ConString.Connection;
                    query = "insert into tbl_order (order_id,product_id,supplier_id,total_due,quantity,quantity_receive,damage_product,status,date_ordered, date_expected, subStatus1) values ('" + txtOrderID.Text + "','" + idItem + "','" + idSupp + "', '" + Convert.ToDecimal(backprice) + "','" + Convert.ToInt32(txtDP.Text) + "',0,0,'Backorder','" + dateTimePicker1.Text + "', '" + DateTime.Now.ToString("yyyy-MM-dd") + "', 'Uncheck')";
                    cmd = new MySqlCommand(query, conn);
                    dr = cmd.ExecuteReader();


                    // MessageBox.Show("Order Successful. ");
                    conn.Close();

                }
                else
                {
                    statuss = "Received";

                    MySqlConnection conn = ConString.Connection;
                    query = "update tbl_order set quantity_receive = '" + Convert.ToInt32(txtRP.Text) + "' , damage_product = '" + Convert.ToInt32(txtDP.Text) + "' , status = '" + statuss + "' where product_id = '" + frm_Inventory.mProduct_ID + "' and supplier_id =  '" + frm_Inventory.mSupplier_ID + "' and status = 'Backorder' and date_expected = '" + frm_Inventory.mDateExpected + "' and date_ordered = '" + frm_Inventory.mDateOrdered + "'";
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

        public void okforinspection2()
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
                    //1
                    statuss = "Received";

                    decimal backamount = totalamountt - (totalamountt / qtyorder * Convert.ToDecimal(txtDP.Text));

                    MySqlConnection conn = ConString.Connection;
                    query = "update tbl_order set total_due = '" + backamount + "' ,quantity_receive = '" + Convert.ToInt32(txtRP.Text) + "' , damage_product = '" + Convert.ToInt32(txtDP.Text) + "' , status = '" + statuss + "' where product_id = '" + frm_Inventory.mProduct_ID + "'  and supplier_id = '" + frm_Inventory.mSupplier_ID + "' and status = 'Overdue Ordered' and date_expected = '" + frm_Inventory.mDateExpected + "' and date_ordered = '" + frm_Inventory.mDateOrdered + "'";
                    cmd = new MySqlCommand(query, conn);
                    dr = cmd.ExecuteReader();

                    MessageBox.Show("Inspection Successful. Unreceived/Damaged product(s) will be automatically backorder.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    conn.Close();


                    // conn = ConString.Connection;
                    //backorder = "Reordered";
                    //query = "update tbl_order set status = '" + backorder + "' where product_id = '" + frm_Inventory.mProduct_ID + "'  and supplier_id = '" + frm_Inventory.mSupplier_ID + "' and status = 'Ordered' and quantity_receive = 0";
                    //cmd = new MySqlCommand(query, conn);
                    //dr = cmd.ExecuteReader();


                    //conn.Close();


                    backprice = suppprice * Convert.ToInt32(txtDP.Text);

                    if (frm_Inventory.receivedzero == 0)
                    {

                    }
                    conn = ConString.Connection;
                    query = "insert into tbl_order (order_id,product_id,supplier_id,total_due,quantity,quantity_receive,damage_product,status,date_ordered, date_expected, subStatus1) values ('" + txtOrderID.Text + "','" + idItem + "','" + idSupp + "', '" + Convert.ToDecimal(backprice) + "','" + Convert.ToInt32(txtDP.Text) + "',0,0,'Backorder','" + dateTimePicker1.Text + "', '" + DateTime.Now.ToString("yyyy-MM-dd") + "', 'Uncheck')";
                    cmd = new MySqlCommand(query, conn);
                    dr = cmd.ExecuteReader();


                    // MessageBox.Show("Order Successful. ");
                    conn.Close();

                }
                else
                {
                    statuss = "Received";
                    //2
                    MySqlConnection conn = ConString.Connection;
                    query = "update tbl_order set quantity_receive = '" + Convert.ToInt32(txtRP.Text) + "' , damage_product = '" + Convert.ToInt32(txtDP.Text) + "' , status = '" + statuss + "' where product_id = '" + frm_Inventory.mProduct_ID + "'  and supplier_id = '" + frm_Inventory.mSupplier_ID + "' and status = 'Overdue Ordered' " +
                        "and date_expected = '" + frm_Inventory.mDateExpected + "' and date_ordered = '" + frm_Inventory.mDateOrdered + "'";
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



            if ((date2 < date1 && dateTimePicker1.Text != DateTime.Now.ToString("yyyy-MM-dd")))
            {
                MessageBox.Show("The date doesn't look right. Be sure to use the actual date.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateExpected.Text = dateTimePicker1.Text;
            }
        }
    }
}
