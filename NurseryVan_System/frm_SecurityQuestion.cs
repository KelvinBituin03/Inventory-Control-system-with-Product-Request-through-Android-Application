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
    public partial class frm_SecurityQuestion : Form
    {
        string answer;
        string question;
        static int attempt = 3;
        public frm_SecurityQuestion()
        {
            InitializeComponent();
        }

        private void frm_SecurityQuestion_Load(object sender, EventArgs e)
        {
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
            MySqlConnection Conn = ConString.Connection;
            MySqlCommand cmd = new MySqlCommand("Select * from tbl_login where login_id = '" + frm_vforgotPassword_s1.getSubgeneralID + "'", Conn);
        
            try
            {

                MySqlDataReader myReader;

                myReader = cmd.ExecuteReader();

                while (myReader.Read())
                {
                    answer = myReader[15].ToString();
                    cmbSQuest.Text = myReader[14].ToString();
                    question = myReader[14].ToString();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Conn.Close();
        }
        private int counter = 10;
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (txtAnswer.Text == "")
            {
                MessageBox.Show("Input your answer.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.None);
                return;
            }
            if (txtAnswer.Text == answer)
            {
                attempt = 3;
                MessageBox.Show("Correct answer.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                var myform = new frm_RecoveryPassword();
                myform.Show();
                this.Hide();
            
                return;
            }
            else
            {
                MessageBox.Show("Wrong answer.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                attempt--;
 
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
            }
        }

        private void txtAnswer_TextChanged(object sender, EventArgs e)
        {
            if (txtAnswer.Text.Length <= 0) return;
            string s = txtAnswer.Text.Substring(0, 1);
            if (s != s.ToUpper())
            {
                int curSelStart = txtAnswer.SelectionStart;
                int curSelLength = txtAnswer.SelectionLength;
                txtAnswer.SelectionStart = 0;
                txtAnswer.SelectionLength = 1;
                txtAnswer.SelectedText = s.ToUpper();
                txtAnswer.SelectionStart = curSelStart;
                txtAnswer.SelectionLength = curSelLength;

            }
        }

        private void btnback2_Click(object sender, EventArgs e)
        {
            var myForm = new frm_vforgotPassword_s1();

            myForm.Show();
            this.Hide();

        }

        private void frm_SecurityQuestion_FormClosing(object sender, FormClosingEventArgs e)
        {
            var myForm = new frm_Login();

            myForm.Show();
            this.Hide();
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            var myForm = new frm_vforgotPassword_s1();

            myForm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
