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
    public partial class frm_RecoveryPassword : Form
    {
        string oldpass;
        public frm_RecoveryPassword()
        {
            InitializeComponent();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {


            MySqlConnection Conn = ConString.Connection;


            if (txtConfirmPassword.Text == "" || txtNewPassword.Text == "")
                {
                    string s = String.Empty;

                    MessageBox.Show("Please input the require fields.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.None);

                    return;
                }
                else
                {


                }

                if (txtNewPassword.Text == txtConfirmPassword.Text)
                {

                }

                else
                {
                    MessageBox.Show("Password doesn't match.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }



                if (txtConfirmPassword.Text.Length < 6)
                {
                    MessageBox.Show("The length of password should be 6 or 25 characters.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {

                }


                string password00 = txtConfirmPassword.Text;
                string password11 = txtNewPassword.Text;



                if (password00.Contains(@"\") || password11.Contains(@"\"))

                {

                    MessageBox.Show("Your password is invalid for using " + @"'\'", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }
               if (txtConfirmPassword.Text == oldpass)
               {
                MessageBox.Show("New and old password must not be equal.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
               }
                MySqlCommand cmd = cmd = new MySqlCommand("update tbl_login set password = '" + this.txtConfirmPassword.Text + "' where login_id = '" + frm_vforgotPassword_s1.getSubgeneralID + "'", Conn);

                cmd.CommandTimeout = 50000;
                MySqlDataReader myReader;
                try
                {
                    myReader = cmd.ExecuteReader();

                    while (myReader.Read())
                    {

                    }
                    MessageBox.Show("Your password has been verified successfully.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

              
                Conn.Close();

                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

           

            this.Hide();
           
                var pleaseWait = new frm_PleaseWait();
                pleaseWait.Show();
                Application.DoEvents();
                Cursor.Current = Cursors.WaitCursor;
                var myForm = new frm_Login();
                myForm.Show();
                pleaseWait.Hide();
            
        }

        private void frm_RecoveryPassword_Load(object sender, EventArgs e)
        {
            this.AcceptButton = btnConfirm;
            try
            {
                MySqlConnection Conn = ConString.Connection;

                Cursor.Current = Cursors.WaitCursor;

                string Query = "select * from tbl_login where login_id = '"+frm_vforgotPassword_s1.getSubgeneralID+"';";
               
                MySqlCommand cmd = new MySqlCommand(Query, Conn);
                MySqlDataReader myReader;
              
                myReader = cmd.ExecuteReader();
                while (myReader.Read())
                {
                    oldpass = myReader.GetString("password");

                }

                Conn.Close();

            }
            catch (Exception ex)
            {

            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtNewPassword.PasswordChar = checkBox1.Checked ? '\0' : '•';
            txtConfirmPassword.PasswordChar = checkBox1.Checked ? '\0' : '•';
        }

        private void btnback2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void frm_RecoveryPassword_FormClosing(object sender, FormClosingEventArgs e)
        {
            var myForm = new frm_Login();

            myForm.Show();
            this.Hide();
        }

        private void frm_RecoveryPassword_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
