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

namespace NurseryVan_System
{
    public partial class frm_MainHomeStaff : Form
    {
        public static string myName;
        public static string myName2;
        public static string user;
        public static string manager;
        string richtextbox;
        public frm_MainHomeStaff(string user)
        {
            InitializeComponent();
        }

        private void frm_MainHomeStaff_Load(object sender, EventArgs e)
        {
            btnHome.Focus();
            refreshRichBox();


            txtName.Text = ("Hi, ") + frm_Login.myName + (" Welcome to Nursery Van.");
            txtName.Text = myName;
            txtName2.Text = frm_Login.myName;
            txtName2.Text = myName2;
            btnSavechanges.Enabled = false;
            btnSavechanges.BackColor = Color.DarkGray;

            undoToolStripMenuItem.Enabled = false;
            undoToolStripMenuItem.ForeColor = Color.Gray;

            btnSavechanges.Visible = false;
            btnDelete.Visible = false;

        }
        void refreshRichBox()
        {
            string Connection = "datasource=localhost;port=3306;username=root;password=1234";
            string Query = "Select * from wzfbmehbvk.tbl_nurseryvan;";


            MySqlConnection Conn = new MySqlConnection(Connection);
            MySqlCommand cmd = new MySqlCommand(Query, Conn);
            MySqlDataReader myReader;


            try
            {
                Conn.Open();
                myReader = cmd.ExecuteReader();

                while (myReader.Read())
                {
                    richTextBox1.Text = myReader[0].ToString();
                    richtextbox = myReader[0].ToString();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        void History()
        {
            string Connection = "datasource=localhost;port=3306;username=root;password=1234";

            string Query = "insert into wzfbmehbvk.tbl_nurseryvan (history) values('" + this.richTextBox1.Text + "');Select * from wzfbmehbvk.tbl_nurseryvan;";
            MySqlConnection Conn = new MySqlConnection(Connection);
            MySqlCommand cmd = new MySqlCommand(Query, Conn);
            cmd.CommandTimeout = 50000;
            MySqlDataReader myReader;



            if (MessageBox.Show("Do you want to save that you made to the richbox?", "Nursery Van System", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                try
                {
                    Conn.Open();
                    myReader = cmd.ExecuteReader();

                    while (myReader.Read())
                    {



                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }


                MessageBox.Show("Saved successfully!", "Nursery Van System", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Conn.Close();


            }
            refreshRichBox();


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
            DialogResult confirm = MessageBox.Show("Are you sure, you want to logout?", "Ordering System", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                Cursor.Current = Cursors.WaitCursor;
                frm_Login.time = DateTime.Now.ToShortTimeString();
                try
                {
                    string Connection = "datasource=localhost;port=3306;username=root;password=1234";
                    MySqlConnection Conn = new MySqlConnection(Connection);
                    Conn.Open();
                    MySqlCommand cmd = new MySqlCommand("update wzfbmehbvk.tbl_loginhistory set time_out = '" + frm_Login.time + "' where login_id = '" + frm_Login.loginID + "'", Conn);

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

            DialogResult confirm = MessageBox.Show("Are you sure, you want to exit?", "Nursery Van System", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {

                Cursor.Current = Cursors.WaitCursor;
                frm_Login.time = DateTime.Now.ToShortTimeString();
                try
                {
                    string Connection = "datasource=localhost;port=3306;username=root;password=1234";
                    MySqlConnection Conn = new MySqlConnection(Connection);
                    Conn.Open();
                    MySqlCommand cmd = new MySqlCommand("update wzfbmehbvk.tbl_loginhistory set time_out = '" + frm_Login.time + "' where login_id = '" + frm_Login.loginID + "'", Conn);

                    MySqlDataReader myReader;

                    myReader = cmd.ExecuteReader();

                    while (myReader.Read())
                    {

                    }

                    Conn.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Nursery Van System", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
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
            History();
            btnSavechanges.Enabled = false;
            btnSavechanges.BackColor = Color.DarkGray;

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string Connection = "datasource=localhost;port=3306;username=root;password=1234";

            string Query = "delete from wzfbmehbvk.tbl_nurseryvan;Select * from wzfbmehbvk.tbl_nurseryvan;";
            MySqlConnection Conn = new MySqlConnection(Connection);
            MySqlCommand cmd = new MySqlCommand(Query, Conn);
            cmd.CommandTimeout = 50000;
            MySqlDataReader myReader;


            if (richTextBox1.Text == "")
            {

                return;
            }

            if (MessageBox.Show("You want to delete all -About Nursery Van-?", "Nursery Van System", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {

                try
                {
                    Conn.Open();
                    myReader = cmd.ExecuteReader();

                    while (myReader.Read())
                    {


                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }


                MessageBox.Show("Deleted successfully!", "Nursery Van System", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Conn.Close();

                var myForm = new frm_MainHomeStaff(user);
                myForm.Show();
                this.Hide();
            }


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
    }
}