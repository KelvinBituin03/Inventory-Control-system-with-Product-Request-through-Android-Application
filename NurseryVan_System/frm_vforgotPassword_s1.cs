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
    public partial class frm_vforgotPassword_s1 : Form
    {
        public static string getEmail;
        public static string getSubgeneralID;
        public static string getmanagerCode = "Manager";
        public static string user;

        static int attempt = 3;
        public frm_vforgotPassword_s1()
        {
            InitializeComponent();
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

                txtID.Text = row.Cells[0].Value.ToString();
               

            }
        }

        private void frm_vforgotPassword_s1_Load(object sender, EventArgs e)
        {
            DGVEmailandUsername();
           
            this.AcceptButton = btnNextStep;
            if (attempt == 0)
            {
                counter = 10;
                lblCountDown.Visible = true;
                btnNextStep.Enabled = false;
                timer1 = new System.Windows.Forms.Timer();
                timer1.Tick += new EventHandler(timer1_Tick);
                timer1.Interval = 1000; // 1 second
                timer1.Start();
                lblCountDown.Text = ("Try again in ") + counter.ToString() + (" seconds.");

                counter = 10;

            }
            else if (attempt == -1)
            {
                counter = 30;
                lblCountDown.Visible = true;
                btnNextStep.Enabled = false;
                timer1 = new System.Windows.Forms.Timer();
                timer1.Tick += new EventHandler(timer1_Tick);
                timer1.Interval = 1000; // 1 second
                timer1.Start();
                lblCountDown.Text = ("Try again in ") + counter.ToString() + (" seconds.");

                counter = 30;

            }
            else if (attempt <= -2)
            {
                counter = 60;
                lblCountDown.Visible = true;
                btnNextStep.Enabled = false;
                timer1 = new System.Windows.Forms.Timer();
                timer1.Tick += new EventHandler(timer1_Tick);
                timer1.Interval = 1000; // 1 second
                timer1.Start();
                lblCountDown.Text = ("Try again in ") + counter.ToString() + (" seconds.");
                counter = 60;

            }
        }
        private int counter = 10;

        private void btnNextStep_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;




            if (txtEmail.Text == "" || txtUsername.Text == "")
            {
                MessageBox.Show("Please input the require fields.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.None);
                return;
            }
          
            string email = txtEmail.Text;


            if (email.Contains(@"\"))

            {

                MessageBox.Show("Your email is invalid for using " + @"'\'", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
            if (txtUsername.Text.Contains(@"\"))

            {

                MessageBox.Show("Your email is invalid for using " + @"'\'", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
            MySqlConnection Conn = ConString.Connection;
            MySqlCommand cmd = new MySqlCommand("select * from tbl_login where email_address = '" + this.txtEmail.Text + "' and username = '" + this.txtUsername.Text + "'", Conn);
            cmd.CommandTimeout = 500000;

            try
            {

                MySqlDataReader myReader;
             
                myReader = cmd.ExecuteReader();

                int count = 0;

                while (myReader.Read())
                {

                    count = count + 1;

                    user = myReader.GetString("user_type");
               

                }
                Conn.Close();
                if (count == 1)
                {


                }


                if (count != 1)
                {
                    attempt--;
                    MessageBox.Show("Make sure you've entered the correct username or email address.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (attempt == 0)
                    {



                        lblCountDown.Visible = true;
                        btnNextStep.Enabled = false;
                        timer1 = new System.Windows.Forms.Timer();
                        timer1.Tick += new EventHandler(timer1_Tick);
                        timer1.Interval = 1000; // 1 second
                        timer1.Start();
                        counter = 10;
                        lblCountDown.Text = ("Try again in ") + counter.ToString() + (" seconds.");


                    }
                    else if (attempt == -1)
                    {
                        counter = 30;
                        lblCountDown.Visible = true;
                        btnNextStep.Enabled = false;
                        timer1 = new System.Windows.Forms.Timer();
                        timer1.Tick += new EventHandler(timer1_Tick);
                        timer1.Interval = 1000; // 1 second
                        timer1.Start();
                        lblCountDown.Text = ("Try again in ") + counter.ToString() + (" seconds.");

                        counter = 30;

                    }
                    else if (attempt <= -2)
                    {
                        counter = 60;
                        lblCountDown.Visible = true;
                        btnNextStep.Enabled = false;
                        timer1 = new System.Windows.Forms.Timer();
                        timer1.Tick += new EventHandler(timer1_Tick);
                        timer1.Interval = 1000; // 1 second
                        timer1.Start();
                        lblCountDown.Text = ("Try again in ") + counter.ToString() + (" seconds.");

                        counter = 60;

                    }

                    return;
                }



                else if (user == "Staff")

                {
                    //  MessageBox.Show("Success.", "Ordering System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    getSubgeneralID = txtID.Text;
                    Cursor.Current = Cursors.WaitCursor;
                    attempt = 3;
                    Cursor.Current = Cursors.AppStarting;
                    var myForm = new frm_SecurityQuestion();
                    
                    myForm.Show();
                    this.Hide();
                  

                }

                else if (user == "Manager")

                {
                    //  MessageBox.Show("Success.", "Ordering System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    getSubgeneralID = txtID.Text;
                    Cursor.Current = Cursors.WaitCursor;
                    attempt = 3;
                    Cursor.Current = Cursors.AppStarting;
                    var myForm = new frm_SecurityQuestion();

                    myForm.Show();
                    this.Hide();
                }




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {

                counter--;
                if (counter == 0)
                    timer1.Stop();
                lblCountDown.Text = ("Try again in ") + counter.ToString() + (" seconds.");
                if (counter == 1)
                {

                    lblCountDown.Text = ("Try again in ") + counter.ToString() + (" second.");
                }

                if (counter == 0)
                {
                    this.btnNextStep.Enabled = true;
                    this.AcceptButton = btnNextStep;
                    lblCountDown.Visible = false;
                    return;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void DGVEmailandUsername()
        {

            MySqlConnection Conn = ConString.Connection;
            MySqlCommand cmd = new MySqlCommand("Select * from tbl_login where login_id = '" + txtID.Text + "'", Conn);

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
                MessageBox.Show(ex.Message);
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            MySqlConnection Conn = ConString.Connection;
            DataTable dt = new DataTable();
            MySqlDataAdapter sda = new MySqlDataAdapter("Select * from tbl_login where username like '" + txtUsername.Text + "%'", Conn);
            sda.Fill(dt);
            Conn.Close();
            dataGridView1.DataSource = dt;
            if (txtUsername.Text.Length <= 0) return;
            string s = txtUsername.Text.Substring(0, 1);
            if (s != s.ToUpper())
            {
                int curSelStart = txtUsername.SelectionStart;
                int curSelLength = txtUsername.SelectionLength;
                txtUsername.SelectionStart = 0;
                txtUsername.SelectionLength = 1;
                txtUsername.SelectedText = s.ToUpper();
                txtUsername.SelectionStart = curSelStart;
                txtUsername.SelectionLength = curSelLength;

            }
        }

        private void btnback_Click(object sender, EventArgs e)
        {

            var myForm = new frm_Login();

            myForm.Show();
            this.Hide();
        }

        private void frm_vforgotPassword_s1_FormClosing(object sender, FormClosingEventArgs e)
        {
            var myForm = new frm_Login();

            myForm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            var myForm = new frm_Login();

            myForm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
