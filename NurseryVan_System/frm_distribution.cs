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
    public partial class frm_distribution : Form
    {
        public frm_distribution()
        {
            InitializeComponent();
         
        }

        private void BtnBck_Click_1(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "SQL Files (*.sql)|*.sql|All Files (*.*)|*.*";


            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK && saveFileDialog1.FileName.Length > 0)
            {
                string path = saveFileDialog1.FileName.ToString();
                richTextBox1.Text = path;
                richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

            if (richTextBox1.Text.Length == 0)
            {
                errorProvider1.SetError(richTextBox1, "This field must be filled up");

                label16.ForeColor = Color.Red;
                MessageBox.Show("A field must be required!");
                //MessageBox.Show("Must choose a location to save backup", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
             
                string file = richTextBox1.Text;
                using (MySqlConnection conn = ConString.Connection)
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        using (MySqlBackup mb = new MySqlBackup(cmd))
                        {
                            try
                            {

                                DialogResult diaRes = MessageBox.Show("Are you sure you want to create backup?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (diaRes == DialogResult.Yes)
                                {
                                    //DialogResult diaRes = MessageBox.Show("Are you sure you want to create backup?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                                    cmd.Connection = conn;
                                   
                                    mb.ExportToFile(file);
                                    conn.Close();

                                    //s.Speak("Backup Success!");
                                    MessageBox.Show("Backup Created Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else if (diaRes == DialogResult.No)
                                {

                                }

                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                    }
                }

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = richTextBox2.Text + "SQL File(*.sql)|*.sql";
            ofd.Title = "Restore Database";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                richTextBox2.Text = ofd.FileName;
                button7.Enabled = true;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(richTextBox2.Text))
            {
                errorProvider1.SetError(richTextBox2, "This field must be filled up");
                label17.ForeColor = Color.Red;
                MessageBox.Show("A field must be required!");
                //MessageBox.Show("Must choose a the file to restore", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //s.Speak("Must choose a the file to restore");
            }

            else
            {

              
                string file = richTextBox2.Text;
                using (MySqlConnection conn = ConString.Connection)
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        using (MySqlBackup mb = new MySqlBackup(cmd))
                        {
                            try
                            {
                                DialogResult diaRes = MessageBox.Show("Restore Database?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (diaRes == DialogResult.Yes)
                                {
                                    cmd.Connection = conn;
                                  
                                    mb.ImportFromFile(file);
                                    conn.Close();

                                    //s.Speak("Restored Successfully!");
                                    MessageBox.Show("Successfully Restored!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                MessageBox.Show("Make sure that the path and filename extension(.sql) are correct.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }

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

        private void frm_HomeAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            var myForm = new frm_AccountManager();
            myForm.Show();
            this.Hide();
        }

        private void frm_HomeAdmin_Load(object sender, EventArgs e)
        {

        }
    }
}
