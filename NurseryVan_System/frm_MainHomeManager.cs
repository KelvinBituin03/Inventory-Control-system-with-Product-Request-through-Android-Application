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
    public partial class frm_MainHomeManager : Form
    {
        public static string myName;
        public static string myName2;
        public static string manager;
        public static string user;
        string online;
        string richtextbox;
        public frm_MainHomeManager(string manager)
        {
            InitializeComponent();
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;

        

        
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



                    lblQTYCritical1.Text = myReader.GetString("CriticalAll");
              

                    if (int.Parse(lblQTYCritical1.Text) >= 99)
                    {
                        lblQTYCritical1.Text = "99";
                    }

                 

                    if (int.Parse(lblQTYCritical1.Text) == 0)
                    {
                        lblQTYCritical1.Visible = false;
                        pCritical1.Visible = false;


                    }
                    else
                    {
                        lblQTYCritical1.Visible = true;
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
       
        private void btnPOS_Click(object sender, EventArgs e)
        {
            var pleaseWait = new frm_PleaseWait();
            pleaseWait.Show();
            Application.DoEvents();
            Cursor.Current = Cursors.WaitCursor;
            var myForm = new frm_POS();
            myForm.Show();
            pleaseWait.Hide();

            this.Hide();
        }

        private void btnLogout_Click_1(object sender, EventArgs e)
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

        private void frm_MainHomeStaff_FormClosing(object sender, FormClosingEventArgs e)
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

        private void btnHome_Click(object sender, EventArgs e)
        {

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

        private void btnTransactionRecord_Click(object sender, EventArgs e)
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

        private void btnAccount_Click(object sender, EventArgs e)
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

        private void btnSavechanges_Click(object sender, EventArgs e)
        {
            if ((richTextBox1.Text.Contains("'")))
            {
                MessageBox.Show("Remove the single quote.");
                return;
            }
            if ((richTextBox1.Text.Contains(@"\")))
            {
                MessageBox.Show("Remove the backslash.");
                return;
            }
       
            btnSavechanges.Enabled = false;
            btnSavechanges.BackColor = Color.DarkGray;

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
          

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            btnSavechanges.Enabled = true;
            btnSavechanges.BackColor = Color.Blue;
            undoToolStripMenuItem.Enabled = true;
            undoToolStripMenuItem.ForeColor = Color.Black;
            if (richTextBox1.Text == richtextbox)
            {
                btnSavechanges.Enabled = false;
                btnSavechanges.BackColor = Color.DarkGray;
                undoToolStripMenuItem.Enabled = false;
                undoToolStripMenuItem.ForeColor = Color.Gray;
            }

        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
            //  undoToolStripMenuItem.ForeColor = Color.Black;
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(richTextBox1.SelectedText);
            }
            catch (Exception)
            {

            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }
        
        private void deleteAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }
        public void setSoontoExpire()
        {
            MySqlConnection Conn = ConString.Connection;


            AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();

            string Query = "update tbl_expiry as B inner join tbl_product as A on B.product_id = A.product_id set B.status = 'Soon to Expire' where datediff( B.date_expiry, date(now())) < A.notify_days and B.status != 'Removed' and B.date_expiry > date(now());";
            MySqlCommand cmd = new MySqlCommand(Query, Conn);
            MySqlDataReader myReader;

            try
            {

                myReader = cmd.ExecuteReader();

                while (myReader.Read())
                {



                }

                Conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error13");
            }
        }

        public void setExpired()
        {
            MySqlConnection Conn = ConString.Connection;


            AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();

            string Query = "update tbl_expiry as B inner join tbl_product as A on B.product_id = A.product_id set B.status = 'Expired' where datediff( B.date_expiry, date(now())) <= A.notify_days and B.status != 'Removed' and B.date_expiry <= date(now());";
            MySqlCommand cmd = new MySqlCommand(Query, Conn);
            MySqlDataReader myReader;

            try
            {

                myReader = cmd.ExecuteReader();

                while (myReader.Read())
                {



                }

                Conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error13");
            }
        }
        private void frm_MainHomeManager_Load(object sender, EventArgs e)
        {
         

            setSoontoExpire();
            setExpired();

            NotificationofCriticalLevel_Warehouse();
          
          
        
          
        }
     
        public void Online()
        {
            MySqlConnection Conn = ConString.Connection;


            AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();

            string Query = "UPDATE tbl_loginhistory set status = 'Online' where login_id = '"+ frm_Login.loginID + "'";
            MySqlCommand cmd = new MySqlCommand(Query, Conn);
            MySqlDataReader myReader;

            try
            {

                myReader = cmd.ExecuteReader();

                while (myReader.Read())
                {

                  



                }

                Conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error13");
            }
        }
        private void frm_MainHomeManager_FormClosing(object sender, FormClosingEventArgs e)
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

        private void btnInventory_Click_1(object sender, EventArgs e)
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

        private void btnRecord_Click(object sender, EventArgs e)
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

        private void btnLoginHistory_Click_1(object sender, EventArgs e)
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

        private void btnManageAccount_Click(object sender, EventArgs e)
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

        private void btnSales_Click(object sender, EventArgs e)
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

        private void btnSupplier_Click(object sender, EventArgs e)
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

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (txtSearch.Text.Length == 0)
            {
                txtSearch.Text = "Find...";
                txtSearch.ForeColor = SystemColors.GrayText;
            }

        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {



            if (txtSearch.Text.Equals(null) == true)
            {
                txtSearch.Text = "Find...";
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


                    txtSearch.Text = "Find...";

                    txtSearch.ForeColor = Color.Gray;
                    Cursor.Current = Cursors.IBeam;


                }
            }

        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtSearch.Text == "Find...")
            {
                txtSearch.Text = "";
            }


        }

        private void txtSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Find...")
            {
                txtSearch.Focus();
                txtSearch.Select(0, 0);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            int index = 0; string temp = richTextBox1.Text; richTextBox1.Text = ""; richTextBox1.Text = temp;
            while (index < richTextBox1.Text.LastIndexOf(txtSearch.Text))
            {
                richTextBox1.Find(txtSearch.Text, index, richTextBox1.TextLength, RichTextBoxFinds.None);
                richTextBox1.SelectionBackColor = Color.Yellow;
                index = richTextBox1.Text.IndexOf(txtSearch.Text, index) + 1;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int index = 0; string temp = richTextBox1.Text; richTextBox1.Text = ""; richTextBox1.Text = temp;
            while (index < richTextBox1.Text.LastIndexOf(txtSearch.Text))
            {
                richTextBox1.Find(txtSearch.Text, index, richTextBox1.TextLength, RichTextBoxFinds.None);
                richTextBox1.SelectionBackColor = Color.Yellow;
                index = richTextBox1.Text.IndexOf(txtSearch.Text, index) + 1;
            }
        }

        private void bunifuGradientPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnHome_Click_1(object sender, EventArgs e)
        {

        }


        private void button1_MouseHover(object sender, EventArgs e)
        {
           
           
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            pbxhomebig.Visible = false;
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            pbxtransachide.Visible = true;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            pbxtransachide.Visible = false;
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            pbxinventoryshow.Visible = true;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            pbxinventoryshow.Visible = false;
        }

        private void button4_MouseHover(object sender, EventArgs e)
        {
            pbxsalesreportbig.Visible = true;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            pbxsalesreportbig.Visible = false;
        }

        private void button5_MouseHover(object sender, EventArgs e)
        {
            pbxsupplierbig.Visible = true;
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            pbxsupplierbig.Visible = false;
        }

        private void button7_MouseHover(object sender, EventArgs e)
        {
            pbxloginhistorybig.Visible = true;
        }

        private void button7_MouseLeave(object sender, EventArgs e)
        {
            pbxloginhistorybig.Visible = false;
        }

        private void button6_MouseHover(object sender, EventArgs e)
        {
            pbxlogoutbig.Visible = true;
        }

        private void button6_MouseLeave(object sender, EventArgs e)
        {
            pbxlogoutbig.Visible = false;
        }

        private void bunifuGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnHome1_MouseHover(object sender, EventArgs e)
        {
            pbxhomebig.Visible = true;
            btnHome1.Font = new Font("Century Gothic", 16, FontStyle.Regular);
            //btnHome1.Image = new Image("",)
            pbxhomebig.BackColor = Color.DarkSlateGray;
            pbxhomebig.BackColor = System.Drawing.ColorTranslator.FromHtml("#247092");
            //Size newSize = new Size((int)(originalBitmap.Width * zoomFactor), (int)(originalBitmap.Height * zoomFactor));
            //Bitmap bmp = new Bitmap(originalBitmap, newSize);

        }

        private void btnHome1_MouseLeave(object sender, EventArgs e)
        {
            pbxhomebig.Visible = false;
            btnHome1.Font = new Font("Century Gothic", 12, FontStyle.Regular);
        }

        private void btnHome1_Click(object sender, EventArgs e)
        {
           // tabControl1.SelectTab(tabPage1);
        }

        private void button2_Click(object sender, EventArgs e)
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

        private void pbxhomebig_Click(object sender, EventArgs e)
        {

        }

        private void pbxinventoryshow_Click(object sender, EventArgs e)
        {

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
            var pleaseWait = new frm_PleaseWait();
            pleaseWait.Show();
            Application.DoEvents();
            Cursor.Current = Cursors.WaitCursor;
            var myForm = new frm_Report();
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

        private void button5_Click(object sender, EventArgs e)
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

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click_1(object sender, EventArgs e)
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

        private void button6_Click_1(object sender, EventArgs e)
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

        private void button5_Click_1(object sender, EventArgs e)
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

        private void label3_Click(object sender, EventArgs e)
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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void bunifuGradientPanel10_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
