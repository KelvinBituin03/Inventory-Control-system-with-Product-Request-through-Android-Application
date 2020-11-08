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
    public partial class frm_TransactionRecord : Form
    {
        string status;
        string Customer;
        string sold;
        string transid;
        public static string manager;
        int store_id;
        public frm_TransactionRecord()
        {
            InitializeComponent();
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
        }
        public static string user;
        private void btnHome_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;


            if (frm_Login.manager == "Manager")
            {
                Cursor.Current = Cursors.AppStarting;
                var myForm = new frm_MainHomeManager(manager);
                myForm.Show();
                this.Hide();
            }
            else if (frm_Login.user == "Staff")
            {
                Cursor.Current = Cursors.AppStarting;

                var myForm = new frm_POS();
                myForm.Show();
                this.Hide();

            }
            else if (frm_Login.stockman == "Stockman")
            {
                Cursor.Current = Cursors.AppStarting;

                var myForm = new frm_Inventory();
                myForm.Show();
                this.Hide();

            }
            else
            {
                //Cursor.Current = Cursors.AppStarting;
                //var myForm = new frm_MainHomeStaff(user);
                //myForm.Show();
                //this.Hide();
            }
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            var pleaseWait = new frm_PleaseWait();
            pleaseWait.Show();
            Application.DoEvents();
            Cursor.Current = Cursors.WaitCursor;
            var myForm = new frm_Inventory();
            myForm.Show();
            pleaseWait.Hide();

            this.Hide();
        }

        private void btnLoginHistory_Click(object sender, EventArgs e)
        {
            var pleaseWait = new frm_PleaseWait();
            pleaseWait.Show();
            Application.DoEvents();
            Cursor.Current = Cursors.WaitCursor;
            var myForm = new frm_LoginHistory();
            myForm.Show();
            pleaseWait.Hide();

            this.Hide();
        }
        public void DGVCustomerDetails()
        {

            MySqlConnection Conn = ConString.Connection;
            //SELECT tbl_transactionrecord.trans_id as 'Transaction ID', tbl_transactionrecord.product_id as 'Product ID', tbl_transactionrecord.product_name as 'Product Name', tbl_transactionrecord.description as 'Category', tbl_transactionrecord.price as 'Unit Price', tbl_transactionrecord.quantity as 'QTY',  tbl_transactionrecord.amount as 'Amount', tbl_transactionrecord.status as 'Status',  tbl_transactionrecord.dateortime as 'Date/Time', tbl_transactionrecord.date as 'Date',tbl_customers.order_ref as 'Sales Invoice' FROM tbl_transactionrecord inner join tbl_customers on tbl_transactionrecord.customer_id = tbl_customers.customer_id order by tbl_transactionrecord.dateortime desc
            MySqlCommand cmd = new MySqlCommand("SELECT tbl_customers.customer_id as 'Customer ID', tbl_customers.customer_name as 'Customer Name', tbl_customers.address as 'Address', tbl_customers.contact_no as 'Contact Phone #', tbl_customers.order_ref as 'Sales Invoice' FROM tbl_transactionrecord inner join tbl_customers on tbl_transactionrecord.customer_id = tbl_customers.customer_id where tbl_transactionrecord.store_id = '" + txtstore_id.Text + "' and tbl_transactionrecord.remove = 'No'  group by tbl_customers.customer_id order by tbl_customers.customer_id desc;", Conn);
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
                Conn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void DGVProductRecord()
        {

            MySqlConnection Conn = ConString.Connection;


            MySqlCommand cmd = new MySqlCommand("SELECT tbl_transactionrecord.trans_id as 'Transaction ID', tbl_transactionrecord.product_id as 'Product ID', tbl_transactionrecord.product_name as 'Product Name', tbl_transactionrecord.price as 'SRP', tbl_transactionrecord.quantity as 'QTY',  tbl_transactionrecord.amount as 'Amount', tbl_transactionrecord.status as 'Status',  tbl_transactionrecord.dateortime as 'Date/Time',tbl_customers.order_ref as 'Sales Invoice' FROM tbl_transactionrecord inner join tbl_customers on tbl_transactionrecord.customer_id = tbl_customers.customer_id where tbl_transactionrecord.store_id = '" + txtstore_id.Text + "' and tbl_transactionrecord.remove = 'No' order by tbl_transactionrecord.dateortime desc;", Conn);
            cmd.CommandTimeout = 0;
            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmd;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bSource = new BindingSource();

                bSource.DataSource = dbdataset;
                dataGridView2.DataSource = bSource;
                sda.Update(dbdataset);

                Conn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void refreshCB()
        {

            MySqlConnection Conn = ConString.Connection;



            string Query = "select * from tbl_store where store_id = '" + frm_Login.global_storeid + "'";

            MySqlCommand cmd = new MySqlCommand(Query, Conn);


            DataTable dt = new DataTable();
            MySqlDataAdapter sda = new MySqlDataAdapter("select * from tbl_store where store_id = '" + frm_Login.global_storeid + "'", Conn);
            sda.Fill(dt);
            sda.SelectCommand = cmd;

            cbStore.DataSource = dt;


            txtstore_id.DataSource = dt;

            cbStore.DisplayMember = "store_name";
            cbStore.ValueMember = "store_name";

            txtstore_id.DisplayMember = "store_id";
            txtstore_id.ValueMember = "store_id";

            DataTable dbdataset = new DataTable();
            sda.Fill(dbdataset);
            BindingSource bSource = new BindingSource();

            bSource.DataSource = dbdataset;
            cbStore.DataSource = bSource;

            txtstore_id.DataSource = bSource;

            sda.Update(dbdataset);
            Conn.Close();
        }
        public void refreshCB1()
        {

            MySqlConnection Conn = ConString.Connection;



            string Query = "select * from tbl_store where status = 'Available'";

            MySqlCommand cmd = new MySqlCommand(Query, Conn);


            DataTable dt = new DataTable();
            MySqlDataAdapter sda = new MySqlDataAdapter("select * from tbl_store", Conn);
            sda.Fill(dt);
            sda.SelectCommand = cmd;

            cbStore.DataSource = dt;


            txtstore_id.DataSource = dt;

            cbStore.DisplayMember = "store_name";
            cbStore.ValueMember = "store_name";

            txtstore_id.DisplayMember = "store_id";
            txtstore_id.ValueMember = "store_id";

            DataTable dbdataset = new DataTable();
            sda.Fill(dbdataset);
            BindingSource bSource = new BindingSource();

            bSource.DataSource = dbdataset;
            cbStore.DataSource = bSource;

            txtstore_id.DataSource = bSource;

            sda.Update(dbdataset);
            Conn.Close();
        }
        private void frm_TransactionRecord_Load(object sender, EventArgs e)
        {
            DGVCustomerDetails();
            DGVProductRecord();

            RemoveListCritical();
            AreaCriticalLevel();
            NotificationofCriticalLevel();
            NotificationofCriticalLevel_Warehouse();

            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;
            toolTip1.SetToolTip(this.lblqtycritical, "Critical Level ( " + lblqtycritical.Text + " )");

            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;
            toolTip1.SetToolTip(this.lblQTYcritical1, "Critical Level and Expiration ( " + lblQTYcritical1.Text + " )");

            PictureBox pic = new PictureBox();
            pic.Width = 16;
            pic.Height = 16;
            pic.Left = 200;
            pic.BackgroundImage = NurseryVan_System.Properties.Resources.search2;
            txtSearch.Controls.Add(pic);

            pic = new PictureBox();
            pic.Width = 16;
            pic.Height = 16;
            pic.Left = 200;
            pic.BackgroundImage = NurseryVan_System.Properties.Resources.search2;
            txtSearch1.Controls.Add(pic);

          

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridView2.Columns[0].Visible = false;
            //dataGridView1.Columns[9].Visible = false;
            if (frm_Login.manager == "Manager")
            {
                btnRemove.Visible = true;
                //   label23.Text = "Branch:";

                cbStore.Size = new Size(275, 26);
                refreshCB1();
                //  ComboboxofStore();


            }
            else if (frm_Login.user == "Staff")
            {
                //btnTransactionRecord.Location = new Point(3, 56);
                //btnLoginHistory.Location = new Point(3, 109);
                //btnLogout.Location = new Point(3, 162);
                //btnHome1.Text = "POS";
                //btnsalereports.Text = "Login History";
                //btnmanageaccounts.Visible = false;
                //btnSupp.Text = "Logout";
                //btnloginhistory1.Visible = false;
                //btnLogout1.Visible = false;
                //btnInventory.Visible = false;
                //btninventory1.Visible = false;
                //btnsalereports.Location = new Point(0, 292);
                //btnSupp.Location = new Point(0, 362);
                panelSupervisor.Visible = false;
                panelManager.Visible = false;

                refreshCB();


            }
            else if (frm_Login.stockman == "Stockman")
            {
                //btnTransactionRecord.Location = new Point(3, 56);
                //btnLoginHistory.Location = new Point(3, 109);
                //btnLogout.Location = new Point(3, 162);
                //btnHome1.Text = "Inventory";
            }
            else if (frm_Login.supervisor == "Supervisor")
            {

                // tabControl1.TabPages.Remove(tabPage3);

                //btnHome1.Text = "POS";
                //btnsalereports.Text = "Login History";
                //btnmanageaccounts.Visible = false;
                //btnSupp.Text = "Logout";
                //btnloginhistory1.Visible = false;
                //btnLogout1.Visible = false;
                panelManager.Visible = false;
                refreshCB();
            }
            else
            {
                btnRemove.Visible = false;
                refreshCB();
            }
        }

        public void NotificationofCriticalLevel_Warehouse()
        {

            MySqlConnection Conn = ConString.Connection;

            string Query = "Select sum(Critical_All)  as 'CriticalAll' from ((SELECT *  FROM (   Select '1' as ID, count(*)   as Critical_All from (SELECT count(tbl_product.product_id)  from tbl_product where tbl_product.status_new = 'Critical Level' group by tbl_product.product_id order by count(tbl_product.product_id)) as DerivedTableAlias) AS A) UNION (SELECT *  FROM ( Select '2' as ID, count(*) as Expiry from (SELECT count(tbl_expiry.product_id), count(tbl_expiry.date_expiry) FROM tbl_expiry inner join tbl_product on tbl_expiry.product_id = tbl_product.product_id where datediff( tbl_expiry.date_expiry, date(now())) <= tbl_product.notify_days and tbl_expiry.status != 'Removed' and tbl_expiry.date_expiry <= date(now()) and tbl_expiry.status = 'Expired' or  datediff( tbl_expiry.date_expiry, date(now())) < tbl_product.notify_days and tbl_expiry.status != 'Removed' and tbl_expiry.date_expiry > date(now()) and tbl_expiry.status = 'Soon to Expire' group by tbl_expiry.product_id, tbl_expiry.date_expiry order by count(tbl_expiry.product_id), count(tbl_expiry.date_expiry)) as DerivedTableAlias) AS B)) as subAlias";
            MySqlCommand cmd = new MySqlCommand(Query, Conn);
            MySqlDataReader myReader;


            try
            {

                myReader = cmd.ExecuteReader();

                while (myReader.Read())
                {



                    lblQTYcritical1.Text = myReader.GetString("CriticalAll");
                    

                    if (int.Parse(lblQTYcritical1.Text) >= 99)
                    {
                        lblQTYcritical1.Text = "99";
                    }

                 

                    if (int.Parse(lblQTYcritical1.Text) == 0)
                    {
                        lblQTYcritical1.Visible = false;
                        pCritical1.Visible = false;


                    }
                    else
                    {
                        lblQTYcritical1.Visible = true;
                        pCritical1.Visible = true;


                    }


                  

                }
                Conn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error2");
            }
        }
        public void ComboboxofStore()
        {
            MySqlConnection Conn = ConString.Connection;
            


            string Query = "Select store_name from tbl_store where status = 'Available'";
            MySqlCommand cmd = new MySqlCommand(Query, Conn);
            MySqlDataReader myReader;

            AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
            try
            {

                myReader = cmd.ExecuteReader();

                while (myReader.Read())
                {
                    MyCollection.Add(myReader.GetString(0));

                    cbStore.Items.Add(myReader[0]);


                }

                cbStore.AutoCompleteCustomSource = MyCollection;
                Conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error1");
            }
        }
        private void txtSearch3_TextChanged(object sender, EventArgs e)
        {
            try
            {

                MySqlConnection Conn = ConString.Connection;
                DataTable dt = new DataTable();

                MySqlDataAdapter sda = new MySqlDataAdapter("SELECT tbl_customers.customer_id as 'Customer ID', tbl_customers.customer_name as 'Customer Name', tbl_customers.address as 'Address', tbl_customers.contact_no as 'Contact Phone #', tbl_customers.order_ref as 'Sales Invoice' FROM tbl_transactionrecord inner join tbl_customers on tbl_transactionrecord.customer_id = tbl_customers.customer_id where " +
                    "tbl_transactionrecord.store_id = '" + txtstore_id.Text + "' and tbl_transactionrecord.remove = 'No' and  tbl_customers.customer_name like '%" + txtSearch.Text + "%' or tbl_transactionrecord.store_id = '" + txtstore_id.Text + "' and tbl_transactionrecord.remove = 'No' and tbl_customers.order_ref like '%" + txtSearch.Text + "%' group by tbl_customers.customer_id", Conn);
                sda.Fill(dt);
                Conn.Close();
                dataGridView1.DataSource = dt;

                dataGridView1.DefaultCellStyle.SelectionBackColor = Color.RoyalBlue;

                if (txtSearch.Text == "Search" || txtSearch.Text == "")
                {

                    DGVCustomerDetails();
                    lblMatch.Hide();
                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (txtSearch.Text.Length <= 0) return;
            string s = txtSearch.Text.Substring(0, 1);
            if (s != s.ToUpper())
            {
                int curSelStart = txtSearch.SelectionStart;
                int curSelLength = txtSearch.SelectionLength;
                txtSearch.SelectionStart = 0;
                txtSearch.SelectionLength = 1;
                txtSearch.SelectedText = s.ToUpper();
                txtSearch.SelectionStart = curSelStart;
                txtSearch.SelectionLength = curSelLength;

            }
            try
            {
                if (!dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].IsNewRow)
                {
                    foreach (DataGridViewCell cell in dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells)
                    {
                        lblMatch.Hide();
                        if (cell.Value == System.DBNull.Value)
                        {

                        }
                    }


                }
            }
            catch (NullReferenceException)
            {
                lblMatch.Show();
            }
        }

        private void btnSearch3_Click(object sender, EventArgs e)
        {
            try
            {

                MySqlConnection Conn = ConString.Connection;
                DataTable dt = new DataTable();

                MySqlDataAdapter sda = new MySqlDataAdapter("SELECT customer_id as 'Customer ID', customer_name as 'Customer Name', contact_no as 'Contact Phone #', order_ref as 'Sales Invoice' FROM tbl_customers where customer_name like '" + txtSearch.Text + "%'", Conn);
                sda.Fill(dt);
                Conn.Close();
                dataGridView1.DataSource = dt;



                if (txtSearch.Text == "Search")
                {

                    Conn = ConString.Connection;

                    dt = new DataTable();
                    sda = new MySqlDataAdapter("SELECT customer_id as 'Customer ID', customer_name as 'Customer Name', contact_no as 'Contact Phone #', order_ref as 'Sales Invoice' FROM tbl_customers", Conn);
                    sda.Fill(dt);
                    Conn.Close();
                    dataGridView1.DataSource = dt;
                    lblMatch.Hide();
                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (txtSearch.Text.Length <= 0) return;
            string s = txtSearch.Text.Substring(0, 1);
            if (s != s.ToUpper())
            {
                int curSelStart = txtSearch.SelectionStart;
                int curSelLength = txtSearch.SelectionLength;
                txtSearch.SelectionStart = 0;
                txtSearch.SelectionLength = 1;
                txtSearch.SelectedText = s.ToUpper();
                txtSearch.SelectionStart = curSelStart;
                txtSearch.SelectionLength = curSelLength;

            }
            try
            {
                if (!dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].IsNewRow)
                {
                    foreach (DataGridViewCell cell in dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells)
                    {
                        lblMatch.Hide();
                        if (cell.Value == System.DBNull.Value)
                        {

                        }
                    }


                }
            }
            catch (NullReferenceException)
            {
                lblMatch.Show();
            }
        }

        private void txtSearch1_TextChanged(object sender, EventArgs e)
        {
            try
            {

                MySqlConnection Conn = ConString.Connection;
                DataTable dt = new DataTable();

                MySqlDataAdapter sda = new MySqlDataAdapter("SELECT tbl_transactionrecord.trans_id as 'Transaction ID', tbl_transactionrecord.product_id as 'Product ID', tbl_transactionrecord.product_name as 'Product Name',  tbl_transactionrecord.price as 'SRP', tbl_transactionrecord.quantity as 'QTY',  tbl_transactionrecord.amount as 'Amount', tbl_transactionrecord.status as 'Status',  tbl_transactionrecord.dateortime as 'Date/Time', tbl_customers.order_ref as 'Sales Invoice' FROM tbl_transactionrecord inner join tbl_customers on tbl_transactionrecord.customer_id = tbl_customers.customer_id where " +
                    "tbl_transactionrecord.store_id = '" + txtstore_id.Text + "' and tbl_transactionrecord.remove = 'No' and tbl_transactionrecord.product_name like '%" + txtSearch1.Text + "%' or  tbl_transactionrecord.store_id = '" + txtstore_id.Text + "' and tbl_transactionrecord.remove = 'No' and tbl_customers.order_ref like '%" + txtSearch1.Text + "%' or tbl_transactionrecord.store_id = '" + txtstore_id.Text + "' and tbl_transactionrecord.dateortime like '%" + txtSearch1.Text + "%' ", Conn);
                sda.Fill(dt);
                Conn.Close();
                dataGridView2.DataSource = dt;

                if (txtSearch1.Text == "Search" || txtSearch1.Text == "")
                {

                    DGVProductRecord();
                    lblMatch2.Hide();
                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (txtSearch1.Text.Length <= 0) return;
            string s = txtSearch1.Text.Substring(0, 1);
            if (s != s.ToUpper())
            {
                int curSelStart = txtSearch1.SelectionStart;
                int curSelLength = txtSearch1.SelectionLength;
                txtSearch1.SelectionStart = 0;
                txtSearch1.SelectionLength = 1;
                txtSearch1.SelectedText = s.ToUpper();
                txtSearch1.SelectionStart = curSelStart;
                txtSearch1.SelectionLength = curSelLength;

            }
            try
            {
                if (!dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex].IsNewRow)
                {
                    foreach (DataGridViewCell cell in dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex].Cells)
                    {
                        lblMatch2.Hide();
                        if (cell.Value == System.DBNull.Value)
                        {

                        }
                    }


                }
            }
            catch (NullReferenceException)
            {
                lblMatch2.Show();
            }
        }

        private void txtSearch1_Leave(object sender, EventArgs e)
        {
            if (txtSearch1.Text.Length == 0)
            {
                txtSearch1.Text = "Search";
                txtSearch1.ForeColor = SystemColors.GrayText;
            }
        }

        private void txtSearch1_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtSearch1.Text.Equals(null) == true)
            {
                txtSearch1.Text = "Search";
                txtSearch1.ForeColor = Color.Gray;
            }
            else
            {
                txtSearch1.ForeColor = Color.Black;
            }
            if (e.KeyCode == Keys.Back)
            {
                if (txtSearch1.Text.Length == 0)
                {


                    txtSearch1.Text = "Search";

                    txtSearch1.ForeColor = Color.Gray;
                    Cursor.Current = Cursors.IBeam;


                }
            }
        }

        private void txtSearch1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            //{
            //    e.Handled = true;
            //}
            if (txtSearch1.Text == "Search")
            {
                txtSearch1.Text = "";
            }
        }

        private void txtSearch1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {


                btnSearch.PerformClick();
            }
        }

        private void txtSearch1_Click(object sender, EventArgs e)
        {
            if (txtSearch1.Text == "Search")
            {
                txtSearch1.Focus();
                txtSearch1.Select(0, 0);

            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (txtSearch.Text.Length == 0)
            {
                txtSearch.Text = "Search";
                txtSearch.ForeColor = SystemColors.GrayText;
            }
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtSearch.Text.Equals(null) == true)
            {
                txtSearch.Text = "Search";
                txtSearch.ForeColor = Color.Gray;
            }
            else
            {
                txtSearch.ForeColor = Color.Black;
            }
            if (e.KeyCode == Keys.Back)
            {
                if (txtSearch.Text.Length == 0)
                {


                    txtSearch.Text = "Search";

                    txtSearch.ForeColor = Color.Gray;
                    Cursor.Current = Cursors.IBeam;


                }
            }
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtSearch.Text == "Search")
            {
                txtSearch.Text = "";
            }
        }

        private void txtSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Search")
            {
                txtSearch.Focus();
                txtSearch.Select(0, 0);

            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {


                btnSearch.PerformClick();
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Are you sure, you want to logout?", "Fabula's Merchandise System", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                Cursor.Current = Cursors.WaitCursor;
                frm_Login.time = DateTime.Now.ToShortTimeString();
                try
                {
                    MySqlConnection Conn = ConString.Connection;
                    MySqlCommand cmd = new MySqlCommand("update tbl_loginhistory set time_out = '" + frm_Login.time + "' where login_id = '" + frm_Login.loginID + "'", Conn);

                    MySqlDataReader myReader;

                    myReader = cmd.ExecuteReader();

                    while (myReader.Read())
                    {



                    }

                    Conn.Close();
                    Cursor.Current = Cursors.AppStarting;
                    var myForm = new frm_Login();
                    myForm.Show();
                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


            }
            else if (confirm == DialogResult.No)
            {


            }
        }

        private void frm_TransactionRecord_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Are you sure, you want to exit?", "Fabula's Merchandise System", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {

                Cursor.Current = Cursors.WaitCursor;
                frm_Login.time = DateTime.Now.ToShortTimeString();
                try
                {
                    MySqlConnection Conn = ConString.Connection;
                    MySqlCommand cmd = new MySqlCommand("update tbl_loginhistory set time_out = '" + frm_Login.time + "', status = 'Offline' where login_id = '" + frm_Login.loginID + "'", Conn);

                    MySqlDataReader myReader;

                    myReader = cmd.ExecuteReader();

                    while (myReader.Read())
                    {



                    }
                    Conn.Close();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Fabula's Merchandise System", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                }
                Application.ExitThread();
            }
            else if (confirm == DialogResult.No)
            {
                e.Cancel = true;

            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            try
            {
                MySqlConnection Conn = ConString.Connection;
                DataTable dt = new DataTable();

                MySqlDataAdapter sda = new MySqlDataAdapter("SELECT trans_id as 'Transaction ID', product_id as 'Product ID', product_name as 'Product Name', category as 'Category', price as 'SRP',  amount as 'Amount', status as 'Status', discount as 'Discount', discountgiven as 'Discount Given', dateortime as 'Date/Time' FROM tbl_transactionrecord where product_name like '" + txtSearch1.Text + "%' or status like '" + txtSearch1.Text + "%'", Conn);
                sda.Fill(dt);
                Conn.Close();
                dataGridView2.DataSource = dt;


                if (txtSearch1.Text == "Search")
                {

                    DGVProductRecord();
                    lblMatch2.Hide();
                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (txtSearch1.Text.Length <= 0) return;
            string s = txtSearch1.Text.Substring(0, 1);
            if (s != s.ToUpper())
            {
                int curSelStart = txtSearch1.SelectionStart;
                int curSelLength = txtSearch1.SelectionLength;
                txtSearch1.SelectionStart = 0;
                txtSearch1.SelectionLength = 1;
                txtSearch1.SelectedText = s.ToUpper();
                txtSearch1.SelectionStart = curSelStart;
                txtSearch1.SelectionLength = curSelLength;

            }
            try
            {
                if (!dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex].IsNewRow)
                {
                    foreach (DataGridViewCell cell in dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex].Cells)
                    {
                        lblMatch2.Hide();
                        if (cell.Value == System.DBNull.Value)
                        {

                        }
                    }


                }
            }
            catch (NullReferenceException)
            {
                lblMatch2.Show();
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {

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
            try
            {
                if (txtCustomerID.Text == "")
                {
                    String s = string.Empty;

                    return;
                }
                string removed = "Yes";
                MySqlConnection Conn = ConString.Connection;
                string Query = "update tbl_transactionrecord set remove = '" + removed + "' where customer_id = '" + this.txtCustomerID.Text + "'";

            
                MySqlCommand cmd = new MySqlCommand(Query, Conn);
                MySqlDataReader myReader;




                if (MessageBox.Show("Are you sure, you want to remove customer " + Customer + "?", "Fabula's Merchandise System", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {

                    try
                    {



                        myReader = cmd.ExecuteReader();
                        MessageBox.Show("Customer's details deleted.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        while (myReader.Read())
                        {


                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }


                    Conn.Close();

                }
                DGVProductRecord();
                DGVCustomerDetails();


            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                txtCustomerID.Text = row.Cells[0].Value.ToString();

                Customer = row.Cells[1].Value.ToString();



            }
        }

        private void btnRemove1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex].IsNewRow)
                {
                    foreach (DataGridViewCell cell in dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex].Cells)
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

            try
            {
                MySqlConnection Conn = ConString.Connection;
                string Query = "delete from tbl_transactionrecord where status = 'Voided';";

         
                MySqlCommand cmd = new MySqlCommand(Query, Conn);
                MySqlDataReader myReader;
                if (sold == "Sold")
                {
                    String s = string.Empty;
                    MessageBox.Show("Sold product cannot remove. ", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (status == "Voided")
                {

                    try
                    {

                        myReader = cmd.ExecuteReader();
                        MessageBox.Show("Product voided deleted.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        while (myReader.Read())
                        {


                        
                        }
                        Conn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    DGVProductRecord();
                    return;
                }


                DGVProductRecord();
            }




            catch (FormatException)
            {

            }
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewCell cell = null;
            foreach (DataGridViewCell selectedCell in dataGridView2.SelectedCells)
            {
                cell = selectedCell;
                break;
            }

            if (cell != null)
            {



                DataGridViewRow row = cell.OwningRow;
                sold = row.Cells[7].Value.ToString();
                status = row.Cells[7].Value.ToString();
                transid = row.Cells[0].Value.ToString();





            }
        }

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {

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
            try
            {

                MySqlConnection Conn = ConString.Connection;

                string Query = "delete from tbl_customers;delete from tbl_transactionrecord";

                MySqlCommand cmd = new MySqlCommand(Query, Conn);
                MySqlDataReader myReader;


                if (txtCustomerID.Text == "")
                {
                    String s = string.Empty;

                    return;
                }

                if (MessageBox.Show("Are you sure, you want to remove all customers' details?", "Fabula's Merchandise System", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {

                    try
                    {


                       
                        myReader = cmd.ExecuteReader();
                        MessageBox.Show("Record all customers deleted.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        while (myReader.Read())
                        {


                       
                        }
                        Conn.Close();
                    }
                    catch (Exception)
                    {

                    }

                    DGVCustomerDetails();
                }
            }

            catch (FormatException)
            {

            }
        }

        private void btnRemoveAll1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex].IsNewRow)
                {
                    foreach (DataGridViewCell cell in dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex].Cells)
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

            try
            {
                MySqlConnection Conn = ConString.Connection;

                string Query = "delete from tbl_transactionrecord;";

             
                MySqlCommand cmd = new MySqlCommand(Query, Conn);
                MySqlDataReader myReader;
                if (transid == "")
                {
                    String s = string.Empty;

                    return;
                }

                if (MessageBox.Show("Are you sure, you want to remove all products?", "Fabula's Merchandise System", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {


                    try
                    {

                        myReader = cmd.ExecuteReader();
                        MessageBox.Show("Record all products deleted.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        while (myReader.Read())
                        {


                        }

                        Conn.Close();
                    }
                    catch (Exception)
                    {

                    }

                    DGVProductRecord();
                }


            }

            catch (FormatException)
            {

            }
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.RowCount - 1;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DGVCustomerDetails();
        }

        private void btnScrollBottom_Click(object sender, EventArgs e)
        {
            dataGridView2.FirstDisplayedScrollingRowIndex = dataGridView2.RowCount - 1;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cbStore_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlConnection Conn = ConString.Connection;
            string Query = "select * from tbl_store where store_name = '" + cbStore.SelectedItem.ToString() + "'; ";

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
            MySqlDataAdapter sda = new MySqlDataAdapter("select * from tbl_store where store_name like '%" + cbStore.Text + "';", Conn);
            sda.Fill(dt);
            sda.SelectCommand = cmd;
            Conn.Close();
            txtstore_id.DataSource = dt;
            txtstore_id.DisplayMember = "store_id";
            txtstore_id.ValueMember = "store_id";
            DGVProductRecord();
            DGVCustomerDetails();
        }

        private void btnHome1_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;


            if (frm_Login.manager == "Manager")
            {
                Cursor.Current = Cursors.AppStarting;
                var myForm = new frm_MainHomeManager(manager);
                myForm.Show();
                this.Hide();
            }
            else if (frm_Login.supervisor == "Supervisor")
            {
                Cursor.Current = Cursors.AppStarting;
                var myForm = new frm_POS();
                myForm.Show();
                this.Hide();
            }
            else if (frm_Login.user == "Staff")
            {
                Cursor.Current = Cursors.AppStarting;
                var myForm = new frm_POS();
                myForm.Show();
                this.Hide();
            }
            else
            {
                Cursor.Current = Cursors.AppStarting;
                var myForm = new frm_Inventory();
                myForm.Show();
                this.Hide();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var pleaseWait = new frm_PleaseWait();
            pleaseWait.Show();
            Application.DoEvents();
            Cursor.Current = Cursors.WaitCursor;
            var myForm = new frm_Inventory();
            myForm.Show();
            pleaseWait.Hide();

            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (frm_Login.supervisor == "Supervisor" || frm_Login.user == "Staff")
            {
                Cursor.Current = Cursors.AppStarting;
                var myForm1 = new frm_LoginHistory();
                myForm1.Show();
                this.Hide();
            }
            else
            {
                var pleaseWait = new frm_PleaseWait();
                pleaseWait.Show();
                Application.DoEvents();
                Cursor.Current = Cursors.WaitCursor;
                var myForm = new frm_Report();
                myForm.Show();
                pleaseWait.Hide();

                this.Hide();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (frm_Login.supervisor == "Supervisor" || frm_Login.user == "Staff")
            {
                DialogResult confirm = MessageBox.Show("Are you sure, you want to logout?", "Fabula's Merchandise System", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    frm_Login.time = DateTime.Now.ToShortTimeString();
                    try
                    {
                        MySqlConnection Conn = ConString.Connection;
                        MySqlCommand cmd = new MySqlCommand("update tbl_loginhistory set time_out = '" + frm_Login.time + "' where login_id = '" + frm_Login.loginID + "'", Conn);

                        MySqlDataReader myReader;

                        myReader = cmd.ExecuteReader();

                        while (myReader.Read())
                        {



                        }

                        Conn.Close();
                        Cursor.Current = Cursors.AppStarting;
                        var myForm1 = new frm_Login();
                        myForm1.Show();
                        this.Hide();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }


                }
                else if (confirm == DialogResult.No)
                {


                }
            }
            else
            {
                var pleaseWait = new frm_PleaseWait();
                pleaseWait.Show();
                Application.DoEvents();
                Cursor.Current = Cursors.WaitCursor;
                var myForm = new frm_Supplier();
                myForm.Show();
                pleaseWait.Hide();

                this.Hide();
            }
        }

        private void btnmanageaccounts_Click(object sender, EventArgs e)
        {
            var pleaseWait = new frm_PleaseWait();
            pleaseWait.Show();
            Application.DoEvents();
            Cursor.Current = Cursors.WaitCursor;
            var myForm = new frm_AccountManager();
            myForm.Show();
            pleaseWait.Hide();

            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var pleaseWait = new frm_PleaseWait();
            pleaseWait.Show();
            Application.DoEvents();
            Cursor.Current = Cursors.WaitCursor;
            var myForm = new frm_LoginHistory();
            myForm.Show();
            pleaseWait.Hide();

            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {

            DialogResult confirm = MessageBox.Show("Are you sure, you want to logout?", "Fabula's Merchandise System", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                Cursor.Current = Cursors.WaitCursor;
                frm_Login.time = DateTime.Now.ToShortTimeString();
                try
                {
                    MySqlConnection Conn = ConString.Connection;

                    MySqlCommand cmd = new MySqlCommand("update tbl_loginhistory set time_out = '" + frm_Login.time + "' where login_id = '" + frm_Login.loginID + "'", Conn);

                    MySqlDataReader myReader;

                    myReader = cmd.ExecuteReader();

                    while (myReader.Read())
                    {



                    }

                    Conn.Close();
                    Cursor.Current = Cursors.AppStarting;
                    var myForm = new frm_Login();
                    myForm.Show();
                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


            }
            else if (confirm == DialogResult.No)
            {


            }
        }

        private void btntransactions_Click(object sender, EventArgs e)
        {

        }

        private void btnhomenew1_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.AppStarting;

            var myForm = new frm_POS();
            myForm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var pleaseWait = new frm_PleaseWait();
            pleaseWait.Show();
            Application.DoEvents();
            Cursor.Current = Cursors.WaitCursor;
            var myForm = new frm_LoginHistory();
            myForm.Show();
            pleaseWait.Hide();

            this.Hide();
        }

        private void btnmanageaccounts_Click_1(object sender, EventArgs e)
        {
            var pleaseWait = new frm_PleaseWait();
            pleaseWait.Show();
            Application.DoEvents();
            Cursor.Current = Cursors.WaitCursor;
            var myForm = new frm_AccountStaff();
            myForm.Show();
            pleaseWait.Hide();

            this.Hide();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Are you sure, you want to logout?", "Fabula's Merchandise System", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                Cursor.Current = Cursors.WaitCursor;
                frm_Login.time = DateTime.Now.ToShortTimeString();
                try
                {
                    MySqlConnection Conn = ConString.Connection;
                    MySqlCommand cmd = new MySqlCommand("update tbl_loginhistory set time_out = '" + frm_Login.time + "', status = 'Offline' where login_id = '" + frm_Login.loginID + "'", Conn);

                    MySqlDataReader myReader;

                    myReader = cmd.ExecuteReader();

                    while (myReader.Read())
                    {



                    }
                    Conn.Close();

                    Cursor.Current = Cursors.AppStarting;
                    var myForm = new frm_Login();
                    myForm.Show();
                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


            }
            else if (confirm == DialogResult.No)
            {


            }
        }

        private void button12_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.AppStarting;

            var myForm = new frm_POS();
            myForm.Show();
            this.Hide();
        }

        public void RemoveListCritical()
        {
            try
            {
                MySqlConnection Conn = ConString.Connection;
                MySqlCommand cmd = new MySqlCommand("Select   * from tbl_inventory inner join tbl_product on tbl_inventory.product_id = tbl_product.product_id where tbl_inventory.QTY > tbl_inventory.critical group by tbl_inventory.product_id;", Conn);
                cmd.CommandTimeout = 50000;

                try
                {

                    MySqlDataReader myReader = cmd.ExecuteReader();


                    while (myReader.Read())
                    {



                        // dataGridView2 .DefaultCellStyle.SelectionBackColor = Color.Pink;

                        pCritical.Hide();
                        lblqtycritical.Visible = false;

                    }
                    Conn.Close();

                }
                catch (TimeoutException)
                {

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "5", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);

            }

        }
        public void AreaCriticalLevel()
        {

            try
            {
                MySqlConnection Conn = ConString.Connection;
                MySqlCommand cmd = new MySqlCommand("Select   * from tbl_inventory inner join tbl_product on tbl_inventory.product_id = tbl_product.product_id where tbl_inventory.QTY <= tbl_inventory.critical and tbl_inventory.QTY != 0 and tbl_inventory.store_id = '" + frm_Login.global_storeid + "' group by tbl_inventory.product_id;", Conn);


                cmd.CommandTimeout = 50000;



                MySqlDataReader myReader = cmd.ExecuteReader();


                while (myReader.Read())
                {



                    pCritical.Show();
                    lblqtycritical.Visible = true;


                }



                Conn.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "7");

            }
        }
        public void NotificationofCriticalLevel()
        {

            MySqlConnection Conn = ConString.Connection;

            string Query = "Select count(*) as 'C_Branch'  from (SELECT count(tbl_store.store_id)  from tbl_inventory inner join tbl_store on tbl_store.store_id = tbl_inventory.store_id where tbl_inventory.status_pending  = 'Not Available' and tbl_inventory.store_id = '" + frm_Login.global_storeid + "' group by tbl_inventory.product_id order by count(tbl_inventory.product_id)) as DerivedTableAlias";
            MySqlCommand cmd = new MySqlCommand(Query, Conn);
            MySqlDataReader myReader;


            try
            {

                myReader = cmd.ExecuteReader();

                while (myReader.Read())
                {



                    lblqtycritical.Text = myReader.GetString("C_Branch");

                    if (int.Parse(lblqtycritical.Text) >= 99)
                    {
                        lblqtycritical.Text = "99";
                    }

                    if (int.Parse(lblqtycritical.Text) == 0)
                    {
                        lblqtycritical.Visible = false;
                    }
                   

                }
                Conn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error1");
            }
        }
        private void button11_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.AppStarting;
            var myForm = new frm_Inventory();
            myForm.Show();
            this.Hide();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            var pleaseWait = new frm_PleaseWait();
            pleaseWait.Show();
            Application.DoEvents();
            Cursor.Current = Cursors.WaitCursor;
            var myForm = new frm_LoginHistory();
            myForm.Show();
            pleaseWait.Hide();

            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            {
                var pleaseWait = new frm_PleaseWait();
                pleaseWait.Show();
                Application.DoEvents();
                Cursor.Current = Cursors.WaitCursor;
                var myForm = new frm_AccountStaff();
                myForm.Show();
                pleaseWait.Hide();

                this.Hide();
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Are you sure, you want to logout?", "Fabula's Merchandise System", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                Cursor.Current = Cursors.WaitCursor;
                frm_Login.time = DateTime.Now.ToShortTimeString();
                try
                {
                    MySqlConnection Conn = ConString.Connection;
                    MySqlCommand cmd = new MySqlCommand("update tbl_loginhistory set time_out = '" + frm_Login.time + "', status = 'Offline' where login_id = '" + frm_Login.loginID + "'", Conn);

                    MySqlDataReader myReader;

                    myReader = cmd.ExecuteReader();

                    while (myReader.Read())
                    {



                    }
                    Conn.Close();

                    Cursor.Current = Cursors.AppStarting;
                    var myForm = new frm_Login();
                    myForm.Show();
                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


            }
            else if (confirm == DialogResult.No)
            {


            }
        }

        private void btnHome1_Click_1(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.AppStarting;
            var myForm = new frm_MainHomeManager(manager);
            myForm.Show();
            this.Hide();
        }

        private void btnTransactionRecord_Click(object sender, EventArgs e)
        {

        }

        private void button20_Click(object sender, EventArgs e)
        {
            var pleaseWait = new frm_PleaseWait();
            pleaseWait.Show();
            Application.DoEvents();
            Cursor.Current = Cursors.WaitCursor;
            var myForm = new frm_TransactionRecord();
            myForm.Show();
            pleaseWait.Hide();

            this.Hide();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.AppStarting;
            var myForm = new frm_Inventory();
            myForm.Show();
            this.Hide();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            var pleaseWait = new frm_PleaseWait();
            pleaseWait.Show();
            Application.DoEvents();
            Cursor.Current = Cursors.WaitCursor;
            var myForm = new frm_Report();
            myForm.Show();
            pleaseWait.Hide();

            this.Hide();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            var pleaseWait = new frm_PleaseWait();
            pleaseWait.Show();
            Application.DoEvents();
            Cursor.Current = Cursors.WaitCursor;
            var myForm = new frm_Supplier();
            myForm.Show();
            pleaseWait.Hide();

            this.Hide();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            var pleaseWait = new frm_PleaseWait();
            pleaseWait.Show();
            Application.DoEvents();
            Cursor.Current = Cursors.WaitCursor;
            var myForm = new frm_AccountManager();
            myForm.Show();
            pleaseWait.Hide();

            this.Hide();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            var pleaseWait = new frm_PleaseWait();
            pleaseWait.Show();
            Application.DoEvents();
            Cursor.Current = Cursors.WaitCursor;
            var myForm = new frm_LoginHistory();
            myForm.Show();
            pleaseWait.Hide();

            this.Hide();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Are you sure, you want to logout?", "Fabula's Merchandise System", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                Cursor.Current = Cursors.WaitCursor;
                frm_Login.time = DateTime.Now.ToShortTimeString();
                try
                {
                    MySqlConnection Conn = ConString.Connection;
                    MySqlCommand cmd = new MySqlCommand("update tbl_loginhistory set time_out = '" + frm_Login.time + "', status = 'Offline' where login_id = '" + frm_Login.loginID + "'", Conn);

                    MySqlDataReader myReader;

                    myReader = cmd.ExecuteReader();

                    while (myReader.Read())
                    {



                    }
                    Conn.Close();

                    Cursor.Current = Cursors.AppStarting;
                    var myForm = new frm_Login();
                    myForm.Show();
                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


            }
            else if (confirm == DialogResult.No)
            {


            }
        }

        private void label23_Click(object sender, EventArgs e)
        {

        }
    }
}
