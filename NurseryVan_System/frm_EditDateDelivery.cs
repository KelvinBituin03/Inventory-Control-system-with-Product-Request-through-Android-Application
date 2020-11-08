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
    public partial class frm_EditDateDelivery : Form
    {
        string getproductid;
        int store_id;
        string dateexpected;
        public frm_EditDateDelivery()
        {
            InitializeComponent();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dateexpected == dateExpected.Text || dateTimePicker1.Text == dateExpected.Text)
            {

                MessageBox.Show("Please set date of delivery delay", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.None);

                return;
            }
            try
            {
                MySqlConnection Conn = ConString.Connection;


                string Query = "Update tbl_inventory set date_expected = '" + dateExpected.Text + "', subStatus = 'Delayed order', status = 'Pending' where product_id = '" + getproductid + "' and store_id = '" + txtstore_id.Text + "';";
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

            SearchingOK();
            //   CriticalLevel1();
            MessageBox.Show("Updated successfully.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

        }

        private void metroGrid3_SelectionChanged(object sender, EventArgs e)
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

                getproductid = row.Cells[0].Value.ToString();
                dateExpected.Text = row.Cells[4].Value.ToString();
                dateexpected = row.Cells[4].Value.ToString();
                dateOrdered.Text = row.Cells[5].Value.ToString();
                txtLeadTime.Text = (dateExpected.Value - dateOrdered.Value).TotalDays.ToString("#");
            }
        }

        private void frm_EditDateDelivery_Load(object sender, EventArgs e)
        {
            SearchingOK();
            refreshCB();
            StartTimer();
            refresh_autocomplete();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            try
            {
                if (!dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].IsNewRow)
                {
                    foreach (DataGridViewCell cell in dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells)
                    {
                        lblMatch2.Visible = false;
                        btnEdit.Enabled = true;
                        btnEdit.BackColor = System.Drawing.ColorTranslator.FromHtml("#24262F");
                        dateExpected.Enabled = true;
                        if (cell.Value == System.DBNull.Value)
                        {

                        }
                    }


                }
            }
            catch (NullReferenceException)
            {
                lblMatch2.Visible = true;
                btnEdit.Enabled = false;
                btnEdit.BackColor = Color.DarkGray;
                dateExpected.Enabled = false;

                return;
            }
        }
        public void CriticalLevel1()
        {
            try
            {
                MySqlConnection conn = ConString.Connection;

                MySqlDataReader dr;



                try
                {
                    //formula
                    //SAFETY STOCK/SS

                    string query = "update tbl_inventory A inner join (select product_id,max(quantity)-min(quantity) as 'SS' from tbl_transactionrecord where date between date_sub(NOW(),interval 360 day) and NOW() and status = 'Sold' group by product_id) B on A.product_id=B.product_id set A.ss = B.SS where a.product_id = '" + getproductid + "' and a.store_id = '" + frm_Login.global_storeid + "';";
                    //"             update tblinventory A inner join (select itemid,max(soldqty)-min(soldqty) as 'SS' from tblcart where datesold between date_sub(NOW(),interval 60 day) and NOW() and remove='No' and payment='Yes' group by itemid) B on A.itemid=B.itemid set A.ss=B.SS where a.itemid = '"+itemid+"';";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    dr = cmd.ExecuteReader();

                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "1");
                }

                try
                {
                    //AVERAGE DAILY SALES
                    conn = ConString.Connection;
                    string query = "update tbl_inventory A inner join (SELECT product_id,avg(quantity)/1 as 'OQ' FROM tbl_transactionrecord where date between date_sub(NOW(),interval 360 day) and NOW() and status = 'Sold' group by product_id) B on A.product_id=B.product_id set A.oq=B.OQ where a.product_id = '" + getproductid + "' and a.store_id = '" + frm_Login.global_storeid + "';";
                    //             update tblinventory A inner join (SELECT itemid,avg(soldqty)/2 as 'OQ' FROM tblcart where datesold between date_sub(NOW(),interval 60 day) and NOW() and remove='No' and payment='Yes' group by itemid) B on A.itemid=B.itemid set A.OQ=B.OQ where a.itemid = '"+itemid+"' ;";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    dr = cmd.ExecuteReader();

                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "2");
                }
                //CRITICAL LEVEL

                if (txtLeadTime.Text == "")
                {


                    try
                    {
                        conn = ConString.Connection;
                        // critical = (ss + oq)/2
                        string query = "update tbl_inventory set critical=(ss + oq)/2 * 0   where product_id = '" + Convert.ToUInt32(getproductid) + "' and store_id = '" + Convert.ToInt32(frm_Login.global_storeid) + "' ;";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        dr = cmd.ExecuteReader();

                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show(ex.Message, "3");
                    }
                }
                else
                {
                    try
                    {
                        conn = ConString.Connection;
                        // critical = (ss + oq)/2
                        string query = "update tbl_inventory set critical=(ss + oq)/2  * '" + Convert.ToInt32(txtLeadTime.Text) + "' where product_id = '" + getproductid + "' and store_id = '" + frm_Login.global_storeid + "' ;";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        dr = cmd.ExecuteReader();

                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "3");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "4", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);

            }
        }
        public void refreshCB()
        {

            MySqlConnection Conn = ConString.Connection;




            string Query = "SELECT * FROM tbl_inventory inner join tbl_product on tbl_inventory.product_id = tbl_product.product_id  inner join tbl_store on tbl_inventory.store_id = tbl_store.store_id where DATE(NOW()) < tbl_inventory.date_expected and  tbl_store.store_name like '%" + cbServer.Text + "' and tbl_inventory.subStatus = 'Pending' and tbl_store.store_name like '%" + cbServer.Text + "' " +
                "or tbl_inventory.subStatus = 'Delayed order' and DATE(NOW()) < tbl_inventory.date_expected and tbl_store.store_name like '%" + cbServer.Text + "' or tbl_inventory.subStatus = 'Backorder Pending' and DATE(NOW()) < tbl_inventory.date_expected and tbl_store.store_name like '%" + cbServer.Text + "' group by tbl_store.store_name";

            MySqlCommand cmd = new MySqlCommand(Query, Conn);


            DataTable dt = new DataTable();
            MySqlDataAdapter sda = new MySqlDataAdapter("SELECT * FROM tbl_inventory inner join tbl_product on tbl_inventory.product_id = tbl_product.product_id  inner join tbl_store on tbl_inventory.store_id = tbl_store.store_id where DATE(NOW()) < tbl_inventory.date_expected and  tbl_store.store_name like '%" + cbServer.Text + "' and tbl_inventory.subStatus = 'Pending' and tbl_store.store_name like '%" + cbServer.Text + "'  group by tbl_store.store_name", Conn);
            sda.Fill(dt);
            sda.SelectCommand = cmd;


            cbServer.DataSource = dt;

            txtstore_id.DataSource = dt;


            cbServer.DisplayMember = "store_name";
            cbServer.ValueMember = "store_name";
            txtstore_id.DisplayMember = "store_id";
            txtstore_id.ValueMember = "store_id";

            DataTable dbdataset = new DataTable();
            sda.Fill(dbdataset);
            BindingSource bSource = new BindingSource();

            bSource.DataSource = dbdataset;

            cbServer.DataSource = bSource;
            txtstore_id.DataSource = bSource;

            sda.Update(dbdataset);
            Conn.Close();
        }



        void refresh_autocomplete()
        {

            MySqlConnection Conn = ConString.Connection;




            string Query = "Select store_name from tbl_store";
            MySqlCommand cmd = new MySqlCommand(Query, Conn);
            MySqlDataReader myReader;

            AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
            try
            {

                myReader = cmd.ExecuteReader();

                while (myReader.Read())
                {
                    MyCollection.Add(myReader.GetString(0));



                }


                cbServer.AutoCompleteCustomSource = MyCollection;

                Conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error1");
            }
        }

        void SearchingOK()
        {
            MySqlConnection Conn = ConString.Connection;


            try
            {






                DataTable dt = new DataTable();

                // sda = new MySqlDataAdapter("SELECT tbl_inventory.product_id as 'Product ID', tbl_inventory.product_name as 'Product Name', tbl_inventory.QTY as 'QTY', tbl_inventory.Price as 'Price'  FROM tbl_inventory left join tbl_store on tbl_inventory.store_id = tbl_store.store_id where tbl_store.store_name like '%"+cbStore.Text+"'", Conn);
                MySqlDataAdapter sda = new MySqlDataAdapter("SELECT tbl_inventory.product_id as 'Product ID', tbl_product.product_name as 'Product Name', QTY as 'QTY in Branch',  tbl_inventory.subQTY as 'QTY Delivered',tbl_inventory.date_expected as 'Date Expected', tbl_inventory.date_delivered as 'Date Ordered',  tbl_inventory.subStatus as 'Status' FROM tbl_inventory inner join tbl_product on tbl_inventory.product_id = tbl_product.product_id  inner join tbl_store on tbl_inventory.store_id = tbl_store.store_id where tbl_store.store_id = '" + txtstore_id.Text + "' and DATE(NOW()) < tbl_inventory.date_expected and tbl_store.store_id = '" + txtstore_id.Text + "' and tbl_inventory.subStatus = 'Pending' " +
                    "or tbl_inventory.subStatus = 'Delayed order' and DATE(NOW()) < tbl_inventory.date_expected and tbl_store.store_id = '" + txtstore_id.Text + "' or tbl_inventory.subStatus = 'Backorder Pending' and DATE(NOW()) < tbl_inventory.date_expected and tbl_store.store_id = '" + txtstore_id.Text + "'  group by tbl_inventory.product_id", Conn);
                sda.Fill(dt);
                Conn.Close();
                dataGridView1.DataSource = dt;

                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[0].Visible = false;


            }




            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void cbServer_TextChanged(object sender, EventArgs e)
        {
            SearchingOK();
            try
            {
                if (!dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].IsNewRow)
                {
                    foreach (DataGridViewCell cell in dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells)
                    {
                        lblMatch2.Visible = false;
                        btnEdit.Enabled = true;
                        btnEdit.BackColor = System.Drawing.ColorTranslator.FromHtml("#24262F");
                        dateExpected.Enabled = true;
                        if (cell.Value == System.DBNull.Value)
                        {

                        }
                    }


                }
            }
            catch (NullReferenceException)
            {
                lblMatch2.Visible = true;
                btnEdit.Enabled = false;
                btnEdit.BackColor = Color.DarkGray;
                dateExpected.Enabled = false;

                return;
            }
        }

        private void cbServer_SelectedIndexChanged(object sender, EventArgs e)
        {



            MySqlConnection Conn = ConString.Connection;

            Cursor.Current = Cursors.WaitCursor;

            string Query = "select * from tbl_store where store_name = '" + cbServer.SelectedItem.ToString() + "'; ";

            MySqlCommand cmd = new MySqlCommand(Query, Conn);
            MySqlDataReader myReader;

            myReader = cmd.ExecuteReader();
            while (myReader.Read())
            {
                store_id = myReader.GetInt32("store_id");


            }

            Conn.Close();


            Conn = ConString.Connection;
            DataTable dt = new DataTable();
            MySqlDataAdapter sda = new MySqlDataAdapter("select * from tbl_store where store_name like '%" + cbServer.Text + "';", Conn);
            sda.Fill(dt);
            sda.SelectCommand = cmd;
            Conn.Close();
            txtstore_id.DataSource = dt;
            txtstore_id.DisplayMember = "store_id";
            txtstore_id.ValueMember = "store_id";
            SearchingOK();
        }

        private void dateExpected_ValueChanged(object sender, EventArgs e)
        {
            DateTime startdate = dateTimePicker1.Value;
            DateTime enddate = dateExpected.Value;




            DateTime date1 = dateTimePicker1.Value;
            DateTime date2 = dateExpected.Value;

            TimeSpan difference = date2.Subtract(date1);



            if ((date2 < date1 && dateTimePicker1.Text != dateExpected.Text))
            {
                //  MessageBox.Show("The date doesn't look right. Be sure to use the actual date.", "Nursery Van System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateExpected.Text = dateTimePicker1.Text;
            }
            txtLeadTime.Text = (dateExpected.Value - dateOrdered.Value).TotalDays.ToString("#");
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.AppStarting;
            try
            {
                if (!dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].IsNewRow)
                {
                    foreach (DataGridViewCell cell in dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells)
                    {

                        if (cell.Value == System.DBNull.Value)
                        {

                        }
                    }


                }
            }
            catch (NullReferenceException)
            {

                return;
            }

            string titlereport = "Delivery Report";
            DGVPrinter printer = new DGVPrinter();
            printer.Title = titlereport;
            printer.SubTitle = string.Format("Date: {0}", lblTime.Text);
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "Fabula's Merchandise System.";
            printer.FooterSpacing = 15;
            printer.PrintDataGridView(dataGridView1);
        }
        System.Windows.Forms.Timer time1 = null;
        private void StartTimer()
        {
            time1 = new System.Windows.Forms.Timer();
            time1.Interval = 1000;
            time1.Tick += new EventHandler(t_Tick);
            time1.Enabled = true;
        }

        void t_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString();
        }
    }
}
