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

    public partial class frm_LoginHistory : Form
    {
        string LoginID;
        string Username;
        public static string manager;
        public frm_LoginHistory()
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
                var myForm = new frm_MainHomeManager(manager);
                myForm.Show();
                this.Hide();
            }
            else if (frm_Login.user == "Staff" || frm_Login.supervisor == "Supervisor")
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

          
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            if (frm_Login.stockman == "Stockman")
            {

            }
            else
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
        }

        private void btnTransactionRecord_Click(object sender, EventArgs e)
        {
            if (frm_Login.stockman == "Stockman")
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
            else
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
        }

        public void DGVLoginHistory()
        {
            MySqlConnection Conn = ConString.Connection;
            MySqlCommand cmd = new MySqlCommand("SELECT login_id as 'Login ID', username as 'Username', time_in as 'Time In', time_out as 'Time Out', date as 'Date', status as 'Status' from tbl_loginhistory  where status != '' order by login_id desc;", Conn);
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
                dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Pink;
                this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                Conn.Close();
                changeRowColor1();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void frm_LoginHistory_Load(object sender, EventArgs e)
        {
            DGVLoginHistory();
         
            RemoveListCritical();
            AreaCriticalLevel();
            NotificationofCriticalLevel();
            NotificationofCriticalLevel_Warehouse();
            NotificationOnline();

            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;
            toolTip1.SetToolTip(this.lblqtycritical, "Critical Level ( " + lblqtycritical.Text + " )");

            lblTime.Text = DateTime.Now.ToShortTimeString();

            PictureBox pic = new PictureBox();
            pic.Width = 16;
            pic.Height = 16;
            pic.Left = 200;

            pic.BackgroundImage = NurseryVan_System.Properties.Resources.search2;
            txtSearch.Controls.Add(pic);





            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;
            toolTip1.SetToolTip(this.lblQTYcritical1, "Critical Level and Expiration ( " + lblQTYcritical1.Text + " )");


            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;
            toolTip1.SetToolTip(this.lblQTYCritical2, "Critical Level and Expiration ( " + lblQTYCritical2.Text + " )");

            if (frm_Login.user == "Staff")
            {
                panelSupervisor.Visible = false;
                panelStockman.Visible = false;
                panelManager.Visible = false;
            }
            else if (frm_Login.supervisor == "Supervisor")
            {

                panelStockman.Visible = false;
                panelManager.Visible = false;

            }
            else if (frm_Login.stockman == "Stockman")
            {
                panelManager.Visible = false;

            }
           
            else if (frm_Login.manager == "Manager")
            {


            }
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
        public void NotificationOnline()
        {

            MySqlConnection Conn = ConString.Connection;

            string Query = "Select count(*) as 'OnlineCount' from (SELECT count(tbl_loginhistory.login_id)  from tbl_loginhistory where tbl_loginhistory.status = 'Online'  group by tbl_loginhistory.username order by count(tbl_loginhistory.login_id)) as DerivedTableAlias;";
            MySqlCommand cmd = new MySqlCommand(Query, Conn);
            MySqlDataReader myReader;


            try
            {

                myReader = cmd.ExecuteReader();

                while (myReader.Read())
                {



                    lblonline.Text = myReader.GetString("OnlineCount");

                
                    if (int.Parse(lblonline.Text) == 0)
                    {
                        lblonline.Visible = false;
                    }
                    else
                    {
                        lblonline.Visible = true;
                    }


                }
                Conn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error1");
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
                    lblQTYCritical2.Text = myReader.GetString("CriticalAll");

                    if (int.Parse(lblQTYcritical1.Text) >= 99)
                    {
                        lblQTYcritical1.Text = "99";
                    }

                    if (int.Parse(lblQTYCritical2.Text) >= 99)
                    {
                        lblQTYCritical2.Text = "99";
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


                    if (int.Parse(lblQTYCritical2.Text) == 0)
                    {
                     

                        lblQTYCritical2.Visible = false;
                        pCritical2.Visible = false;
                    }
                    else
                    {
                     

                        lblQTYCritical2.Visible = true;
                        pCritical2.Visible = true;
                    }

                }
                Conn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error2");
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

        private void frm_LoginHistory_FormClosing(object sender, FormClosingEventArgs e)
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

                MySqlConnection Conn = ConString.Connection;
                string Query = "delete from tbl_loginhistory where login_id = '" +LoginID + "'";

             
                MySqlCommand cmd = new MySqlCommand(Query, Conn);
                MySqlDataReader myReader;
                
          

                    try
                    {

                        myReader = cmd.ExecuteReader();
                        MessageBox.Show(Username + " removed.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                      
                        
                    Conn.Close();
                }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
               


                DGVLoginHistory();
            }




            catch (FormatException)
            {

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
               
                LoginID = row.Cells[0].Value.ToString();
                Username = row.Cells[1].Value.ToString();



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
                string Query = "delete from tbl_loginhistory;";

                MySqlCommand cmd = new MySqlCommand(Query, Conn);
                MySqlDataReader myReader;



                try
                {

                    myReader = cmd.ExecuteReader();
                    MessageBox.Show("All username removed.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    while (myReader.Read())
                    {


                 
                    }
                    Conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }



                DGVLoginHistory();
            }




            catch (FormatException)
            {

            }
        }

        private void btnScrollBottom_Click(object sender, EventArgs e)
        {
            dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.RowCount - 1;
        }

        private void btnScrollUp_Click(object sender, EventArgs e)
        {
            DGVLoginHistory();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {

                MySqlConnection Conn = ConString.Connection;
                DataTable dt = new DataTable();

                MySqlDataAdapter sda = new MySqlDataAdapter("SELECT login_id as 'Login ID', username as 'Username', time_in as 'Time In', time_out as 'Time Out', date as 'Date', status 'Status'  FROM tbl_loginhistory where username like '%" + txtSearch.Text + "%' and status != ''", Conn);
                sda.Fill(dt);
                Conn.Close();
                dataGridView1.DataSource = dt;

                dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Pink;

                if (txtSearch.Text == "Search")
                {

                    Conn = ConString.Connection;
                    dt = new DataTable();
                    sda = new MySqlDataAdapter("SELECT login_id as 'Login ID', username as 'Username', time_in as 'Time In', time_out as 'Time Out', date as 'Date' FROM tbl_loginhistory", Conn);
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

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
           

        }

        private void txtSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Search")
            {
                txtSearch.Focus();
                txtSearch.Select(0, 0);

            }
        }

        private void btnLoginHistory_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnhomenew1_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.AppStarting;

            var myForm = new frm_POS();
            myForm.Show();
            this.Hide();
        }

        private void button12_Click(object sender, EventArgs e)
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

        private void button8_Click(object sender, EventArgs e)
        {
         
        }

        private void btnmanageaccounts_Click(object sender, EventArgs e)
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

        private void button5_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.AppStarting;

            var myForm = new frm_POS();
            myForm.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
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

        private void button11_Click(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
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

        private void button3_Click(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
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

        private void button6_Click(object sender, EventArgs e)
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

        private void button9_Click(object sender, EventArgs e)
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

        private void btnHome1_Click(object sender, EventArgs e)
        {
            var pleaseWait = new frm_PleaseWait();
            pleaseWait.Show();
            Application.DoEvents();
            Cursor.Current = Cursors.WaitCursor;

            var myForm = new frm_MainHomeManager(manager);
            myForm.Show();
            pleaseWait.Hide();
            this.Hide();
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
            var pleaseWait = new frm_PleaseWait();
            pleaseWait.Show();
            Application.DoEvents();
            Cursor.Current = Cursors.WaitCursor;
            var myForm = new frm_Inventory();
            myForm.Show();
            pleaseWait.Hide();

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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DGVLoginHistory();
            NotificationOnline();
        }

        private void btnCR_Click(object sender, EventArgs e)
        {
            MySqlConnection Conn = ConString.Connection;
            DataTable dt = new DataTable();

            MySqlDataAdapter sda = new MySqlDataAdapter("SELECT login_id as 'Login ID', username as 'Username', time_in as 'Time In', time_out as 'Time Out', date as 'Date', status 'Status'  FROM tbl_loginhistory where status ='Online'", Conn);
            sda.Fill(dt);
            Conn.Close();
            dataGridView1.DataSource = dt;
            changeRowColor1();
        }
        private void changeRowColor1()
        {
            try
            {


                foreach (DataGridViewRow Myrow in dataGridView1.Rows)
                {
                    if (Myrow.Cells["Status"].Value.ToString() == "Online")
                    {
                        Myrow.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#F89D10");
                        Myrow.DefaultCellStyle.ForeColor = System.Drawing.Color.White;

                    }
                  
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }
    }
}
