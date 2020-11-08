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
    public partial class frm_AccountStaff : Form
    {
        int selectedRow;
        string loginID;
        string userpassword;
        string user;
        string street;
        string barangay;
        string city;
        string contact;
        string email;
        string age;
        string password;
       public static string myName;
        public frm_AccountStaff()
        {
            InitializeComponent();
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click_1(object sender, EventArgs e)
        {

        }

        private void btnPOS_Click(object sender, EventArgs e)
        {

        }

        private void btnTransactionRecord_Click(object sender, EventArgs e)
        {

        }

        private void btnAccount_Click(object sender, EventArgs e)
        {

        }

        private void btnInventory_Click(object sender, EventArgs e)
        {

        }

        private void btnHome_Click(object sender, EventArgs e)
        {

        }

        private void btnLoginHistory_Click(object sender, EventArgs e)
        {

        }

        private void frm_AccountStaff_Load(object sender, EventArgs e)
        {
            DGVAccountUser();
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

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            lblStaffAccount.Text = frm_Login.myName + ("'s Password Account");
            lblStaffAccount.Text = myName;

            if (frm_Login.user == "Admin")
            {
                btnHome.Text = "BACKUP/RESTORE";
                btnHome.TileTextFontSize = MetroFramework.MetroTileTextSize.Small;
                btnPOS.Text = "ADMIN HOME";
                btnPOS.TileTextFontSize = MetroFramework.MetroTileTextSize.Small;
                btnInventory.Visible = false;
                btnTransactionRecord.Visible = false;
                btnAccount.Visible = false;
                btnLoginHistory.Visible = false;
                btnLogout.Location = new Point(3, 135);
                
            }
            else if (frm_Login.stockman == "Stockman")
            {
              //  btnPOS.Text = "Inventory";


            }

            else if (frm_Login.supervisor == "Supervisor")
            {
                // btnPOS.Text = "Inventory";
                panelStockman.Visible = false;

            }
            else if (frm_Login.user == "Staff")
            {
                //btnPOS.Text = "Inventory";

                panelSupervisor.Visible = false;
                panelStockman.Visible = false;



            }

            MySqlConnection Conn = ConString.Connection;
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM tbl_login where login_id = '" + frm_Login.GeneralID + "'", Conn);
            cmd.CommandTimeout = 50000;
           

            try
            {

                MySqlDataReader myReader;
                myReader = cmd.ExecuteReader();
                while (myReader.Read())
                {
                    street = myReader[7].ToString();
                    barangay = myReader[8].ToString();
                    city = myReader[9].ToString();
                    contact = myReader[10].ToString();
                    email = myReader[11].ToString();
                    age = myReader[12].ToString();
                   password = myReader[4].ToString();

                }
                Conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
         
        }
        void DGVAccountUser()
        {
            MySqlConnection Conn = ConString.Connection;

            MySqlCommand cmd = new MySqlCommand("SELECT login_id as 'Account ID', firstname as 'First Name', lastname as 'Last Name', gender as 'Gender', age as 'Age', birthdate as 'Birthdate', street as 'Street #',barangay as 'Barangay', city as 'City',contact as 'Contact #', email_address as 'Email Address', username as 'Username', user_type as 'Position' FROM tbl_login where login_id = '"+frm_Login.GeneralID+"'", Conn);
            cmd.CommandTimeout = 50000;
       

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

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MySqlConnection Conn = ConString.Connection;

            string Query = "UPDATE tbl_login SET street = '" + this.txtStreet.Text + "', barangay = '" + this.txtBarangay.Text + "',  city = '" + this.txtCity.Text + "', age = '" + this.txtAge.Text + "', contact = '" + this.txtContact.Text + "', email_address = '" + this.txtEmail.Text + "'  where login_id = '" + frm_Login.GeneralID + "' or login_id = '" + loginID + "'";
     
            MySqlCommand cmd = new MySqlCommand(Query, Conn);
            cmd.CommandTimeout = 50000;
            MySqlDataReader myReader;
            if (txtContact.Text.Length > 11 && txtContact.Text.Length <= 10)
            {
                lblphone.Hide();

            }
            else if (txtContact.Text.Contains("09") && txtContact.Text.Length == 11 || txtContact.Text.Contains("639") && txtContact.Text.Length == 12 || txtContact.Text.Contains("+639") && txtContact.Text.Length == 13)
            {
                lblphone.Hide();
            }
            else
            {
                MessageBox.Show("The phone number format is not recognized.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lblphone.Show();
                return;
            }


          
            if (!txtContact.Text.Contains("09") && !txtContact.Text.Contains("639") && !txtContact.Text.Contains("+639"))
            {
                MessageBox.Show("The phone number format is not recognized.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                lblphone.Show();
                return;
            }

            if (Phonevalidation.checkPhonenumber(txtContact.Text.ToString()))
            {

                lblphone.Hide();
            }
            else
            {
                MessageBox.Show("The phone number format is not recognized.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                lblphone.Show();
                return;
            }
            if (txtEmail.Text.Length <= 50 && !txtEmail.Text.Contains("@"))
            {
                lblDontforget.Visible = true;
                lblEmailnotvalid.Hide();
                return;

            }
            else
            {
                lblDontforget.Visible = false;

            }
            if (EmailforbeforeValidate.emailbeforevalidate1(txtEmail.Text.ToString()))
            {

                lblBeforeDontforget.Hide();

            }

            else
            {
                lblBeforeDontforget.Show();
                lblAfterdontForget.Hide();
                lblEmailnotvalid.Hide();
                return;
            }

            if (EmailforafterValidate.aftervalidate(txtEmail.Text.ToString()))
            {

                lblAfterdontForget.Hide();

            }

            else
            {

                lblAfterdontForget.Show();
                lblEmailnotvalid.Hide();
                lblBeforeDontforget.Hide();
                return;
            }

            if (CheckforEmail.checkForEmail(txtEmail.Text.ToString()))
            {

                lblEmailnotvalid.Hide();

            }

            else
            {

                lblEmailnotvalid.Show();
                return;
            }


            if (EmailforbeforeValidate.emailbeforevalidate1(txtEmail.Text.ToString()))
            {

                lblEmailnotvalid.Hide();

            }

            else
            {
                lblEmailnotvalid.Show();

                return;
            }
            if (txtAge.Text == "")
            {
                lbl18.Text = "Enter your age.";
                lbl18.Show();
                return;
            }

            if (int.Parse(txtAge.Text) <= 17 && int.Parse(txtAge.Text) > 10)
            {
                lbl18.Show();
                return;
            }

            if (int.Parse(txtAge.Text) <= 10)
            {
                lbl18.Text = "Your age doesn't look right. Be sure to use your actual date of birth.";
                lbl18.Show();
                return;
            }
            if (MessageBox.Show("Do you want to save the changes you have made to the field(s)?", "Fabula's Merchandise System", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                try
                {
                   
                    myReader = cmd.ExecuteReader();

                    while (myReader.Read())
                    {


                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }

            
                MessageBox.Show("Changes saved successfully!", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Conn.Close();
         
                DataGridViewRow newDataRow = dataGridView1.Rows[selectedRow];
                newDataRow.Cells[0].Value = loginID;
                newDataRow.Cells[6].Value = txtStreet.Text;
                newDataRow.Cells[7].Value = txtBarangay.Text;
                newDataRow.Cells[8].Value = txtCity.Text;
                newDataRow.Cells[4].Value = txtAge.Text;
                newDataRow.Cells[9].Value = txtContact.Text;
                newDataRow.Cells[10].Value = txtEmail.Text;
               

                DGVAccountUser();


            }
            btnSave.Enabled = false;
            btnSave.BackColor = Color.DarkGray;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[selectedRow];
           loginID = row.Cells[0].Value.ToString();
            txtStreet.Text = row.Cells[6].Value.ToString();
            txtBarangay.Text = row.Cells[7].Value.ToString();
            txtCity.Text = row.Cells[8].Value.ToString();
            txtAge.Text = row.Cells[4].Value.ToString();
            txtContact.Text = row.Cells[9].Value.ToString();
            txtEmail.Text = row.Cells[10].Value.ToString();


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
                loginID = row.Cells[0].Value.ToString();
                txtStreet.Text = row.Cells[6].Value.ToString();
                txtBarangay.Text = row.Cells[7].Value.ToString();
                txtCity.Text = row.Cells[8].Value.ToString();
                txtAge.Text = row.Cells[4].Value.ToString();
                txtContact.Text = row.Cells[9].Value.ToString();
                txtEmail.Text = row.Cells[10].Value.ToString();
                btnSave.Enabled = false;
                btnSave.BackColor = Color.DarkGray;

            }
        }

        private void txtAge_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtContact_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            btnSave.BackColor = System.Drawing.ColorTranslator.FromHtml("#24262F");
            if (txtContact.Text == contact)
            {
                btnSave.Enabled = false;
                btnSave.BackColor = Color.DarkGray;
            }
            try
            {
                if (txtContact.Text == "Contact #" || txtContact.Text == "")
                {
                    lblphone.Hide();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (txtContact.Text.Length > 11 || txtContact.Text.Length <= 10)
            {
            }
            else
            {
                lblphone.Hide();
            }
        }

        private void txtContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
             (e.KeyChar != '+'))
            {
                e.Handled = true;
            }
            
        }

        private void txtContact_Leave(object sender, EventArgs e)
        {
            if (txtContact.Text.Length > 11 && txtContact.Text.Length <= 10)
            {
                lblphone.Hide();

            }
            else if (txtContact.Text.Contains("09") && txtContact.Text.Length == 11 || txtContact.Text.Contains("639") && txtContact.Text.Length == 12 || txtContact.Text.Contains("+639") && txtContact.Text.Length == 13)
            {
                lblphone.Hide();
            }
            else
            {
                lblphone.Show();
                return;
            }



            if (!txtContact.Text.Contains("09") && !txtContact.Text.Contains("639") && !txtContact.Text.Contains("+639"))
            {
                lblphone.Show();
                return;
            }

            if (Phonevalidation.checkPhonenumber(txtContact.Text.ToString()))
            {

                lblphone.Hide();
            }
            else
            {
                lblphone.Show();
                return;
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            btnSave.BackColor = System.Drawing.ColorTranslator.FromHtml("#24262F");
            if (txtEmail.Text == email || txtEmail.Text == "")
            {
                btnSave.Enabled = false;
                btnSave.BackColor = Color.DarkGray;
            }
            if (CheckforEmail.checkForEmail(txtEmail.Text.ToString()))
            {

                lblEmailnotvalid.Hide();
            }
            else
            {
            }
   
            lblDontforget.Hide();
            lblEmailnotvalid.Hide();
            lblBeforeDontforget.Hide();
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (txtEmail.Text.Length <= 50 && !txtEmail.Text.Contains("@"))
            {
                lblDontforget.Visible = true;
                lblEmailnotvalid.Hide();
                lblBeforeDontforget.Hide();
                lblAfterdontForget.Hide();
                return;

            }
            else
            {
                lblDontforget.Visible = false;

            }


            if (txtEmail.Text == "Email Address" || txtEmail.Text == "")
            {
                lblEmailnotvalid.Hide();
                lblDontforget.Hide();
                return;
            }

            if (EmailforbeforeValidate.emailbeforevalidate1(txtEmail.Text.ToString()))
            {

                lblBeforeDontforget.Hide();

            }

            else
            {
                lblBeforeDontforget.Show();
                lblEmailnotvalid.Hide();
                lblAfterdontForget.Hide();
                return;

            }
            if (EmailforafterValidate.aftervalidate(txtEmail.Text.ToString()))
            {

                lblAfterdontForget.Hide();

            }

            else
            {

                lblAfterdontForget.Show();
                lblEmailnotvalid.Hide();
                lblBeforeDontforget.Hide();
                return;
            }



            if (CheckforEmail.checkForEmail(txtEmail.Text.ToString()))
            {

                lblEmailnotvalid.Hide();

            }

            else
            {

                lblEmailnotvalid.Show();

            }
        }

        private void txtAge_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            btnSave.BackColor = System.Drawing.ColorTranslator.FromHtml("#24262F");
            if (txtAge.Text == age || txtAge.Text == "")
            {
                btnSave.Enabled = false;
                btnSave.BackColor = Color.DarkGray;
            }
            try
            {


                if (int.Parse(txtAge.Text) <= 17 && int.Parse(txtAge.Text) > 10)
                {
                    lbl18.Show();
                    return;
                }
                else
                {
                    lbl18.Hide();
                }

                if (int.Parse(txtAge.Text) <= 10)
                {
                    lbl18.Text = "Your age doesn't look right. Be sure to use your actual date of birth.";
                    lbl18.Show();
                    return;
                }
                else
                {
                    lbl18.Hide();
                }

            }
            catch (Exception)
            {

            }
        }

        private void txtOldPassword_Leave(object sender, EventArgs e)
        {
            if (txtOldPassword.Text.Length == 0)
            {
                txtOldPassword.Text = "Old Password";
                txtOldPassword.ForeColor = SystemColors.GrayText;
            }
        }

        private void txtOldPassword_TextChanged(object sender, EventArgs e)
        {
            txtOldPassword.PasswordChar = '•';
            if (txtConfirmPassword.Text == "Confirm Password" || txtNewPassword.Text == "New Password" || txtOldPassword.Text == "Old Password")
            {

                btnSaveChanges.Enabled = false;
                btnSaveChanges.BackColor = Color.DarkGray;
            }

            else
            {


                btnSaveChanges.Enabled = true;
                btnSaveChanges.BackColor = System.Drawing.ColorTranslator.FromHtml("#24262F");


            }
            if (txtOldPassword.Text == "Old Password" || txtOldPassword.Text == "" )
            {
             
                lblOldPassword.Hide();
                lblX1.Hide();
       
            }
            if (txtOldPassword.Text == password)
            {
                lblOldPassword.Hide();
                lblX1.Hide();
            }
        

        }

        private void txtOldPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtOldPassword.Text.Equals(null) == true)
            {
                txtOldPassword.Text = "Old Password";
                txtOldPassword.ForeColor = Color.Gray;
            }
            else if (txtOldPassword.Text == "Old Password")
            {
                txtOldPassword.ForeColor = Color.Gray;
            }
            else
            {
                txtOldPassword.ForeColor = Color.Black;
            }

            if (e.KeyCode == Keys.Back)
            {
                if (txtOldPassword.Text.Length == 0)
                {

                    txtOldPassword.Text = "Old Password";
                    txtOldPassword.PasswordChar = '\0';
                    txtOldPassword.ForeColor = Color.Gray;
                    Cursor.Current = Cursors.IBeam;
                }
            }
        }

        private void txtOldPassword_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (txtOldPassword.Text == "Old Password")
            {
                txtOldPassword.Text = "";
            }
        }

        private void txtOldPassword_Click(object sender, EventArgs e)
        {
            if (txtOldPassword.Text == "Old Password")
            {
                txtOldPassword.Focus();
                txtOldPassword.Select(0, 0);
            }
        }

        private void txtNewPassword_TextChanged(object sender, EventArgs e)
        {
            txtNewPassword.PasswordChar = '•';

            if (txtConfirmPassword.Text == "Confirm Password" || txtNewPassword.Text == "New Password" || txtOldPassword.Text == "Old Password")
            {

                btnSaveChanges.Enabled = false;
                btnSaveChanges.BackColor = Color.DarkGray;
            }

            else
            {

                btnSaveChanges.Enabled = true;
                btnSaveChanges.BackColor = System.Drawing.ColorTranslator.FromHtml("#24262F");


            }
            //if (txtNewPassword.Text == txtConfirmPassword.Text || txtNewPassword.Text == "" ||txtConfirmPassword.Text == "Confirm Password")
            //{
            //    lblDoesnotMatch.Hide();
            //    lblX2.Hide();
            //}
            //else
            //{
            //    lblX2.Show();
            //    lblDoesnotMatch.Show();
            //}
            if (txtNewPassword.Text == "New Password")
            {
                lblPWeak.Visible = false;
                lblPMedium.Visible = false;
                lblTooShort.Visible = false;
                lblPStrong.Visible = false;
                lblPS.Visible = false;

                return;
            

            }
         
            if (txtNewPassword.Text.Length < 6)
            {
                lblTooShort.Visible = true;
                lblPWeak.Visible = false;
                lblPMedium.Visible = false;
                lblPStrong.Visible = false;
                lblPS.Visible = false;

                return;
              
            }
            else if (txtNewPassword.Text.Length >= 6 && txtNewPassword.Text.Length <= 7)
            {
                lblTooShort.Visible = false;
                lblPWeak.Visible = true;
                lblPMedium.Visible = false;
                lblPStrong.Visible = false;
                lblPS.Visible = true;
            }
            else if ((txtNewPassword.Text.Length >= 8 && txtNewPassword.Text.Length <= 25))
            {
                lblPWeak.Visible = false;
                lblPMedium.Visible = true;
                lblPStrong.Visible = false;
                lblPS.Visible = true;
            }
            else if ((txtNewPassword.Text.Length >= 26 && txtNewPassword.Text.Length <= 50))
            {
                lblPWeak.Visible = false;
                lblPMedium.Visible = false;
                lblPStrong.Visible = true;
                lblPS.Visible = true;
            }
        }

        private void txtNewPassword_Leave(object sender, EventArgs e)
        {
            if (txtNewPassword.Text.Length == 0)
            {
                txtNewPassword.Text = "New Password";
                txtNewPassword.ForeColor = SystemColors.GrayText;
            }
        }

        private void txtNewPassword_KeyUp(object sender, KeyEventArgs e)
        {

            if (txtNewPassword.Text.Equals(null) == true)
            {
                txtNewPassword.Text = "New Password";
                txtNewPassword.ForeColor = Color.Gray;
            }
            else if (txtNewPassword.Text == "New Password")
            {
                txtNewPassword.ForeColor = Color.Gray;
            }
            else
            {
                txtNewPassword.ForeColor = Color.Black;
            }

            if (e.KeyCode == Keys.Back)
            {
                if (txtNewPassword.Text.Length == 0)
                {


                    txtNewPassword.Text = "New Password";
                    txtNewPassword.PasswordChar = '\0';

                    txtNewPassword.ForeColor = Color.Gray;
                    Cursor.Current = Cursors.IBeam;
                }
            }
        }

        private void txtNewPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtNewPassword.Text == "New Password")
            {
                txtNewPassword.Text = "";
            }
        }

        private void txtNewPassword_Click(object sender, EventArgs e)
        {
            if (txtNewPassword.Text == "New Password")
            {
                txtNewPassword.Focus();
                txtNewPassword.Select(0, 0);
            }
        }

        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            txtConfirmPassword.PasswordChar = '•';
           
          
            if (txtConfirmPassword.Text == "Confirm Password" || txtNewPassword.Text == "New Password" || txtOldPassword.Text == "Old Password")
            {
               
                btnSaveChanges.Enabled = false;
                btnSaveChanges.BackColor = Color.DarkGray;
            }

            else
            {

                btnSaveChanges.Enabled = true;
                btnSaveChanges.BackColor = System.Drawing.ColorTranslator.FromHtml("#24262F");


            }
            if (txtNewPassword.Text == txtConfirmPassword.Text || txtConfirmPassword.Text == "" ||txtConfirmPassword.Text == "Confirm Password")
            {
                lblDoesnotMatch.Hide();
                lblX2.Hide();
            }
          
            if (txtConfirmPassword.Text.Length >= 6)
            {
                lblPasswordlong.Hide();
            }
          
        }

        private void txtConfirmPassword_Leave(object sender, EventArgs e)
        {
            if (txtConfirmPassword.Text.Length == 0)
            {
                txtConfirmPassword.Text = "Confirm Password";
                txtConfirmPassword.ForeColor = SystemColors.GrayText;
            }
        }

        private void txtConfirmPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtConfirmPassword.Text.Equals(null) == true)
            {
                txtConfirmPassword.Text = "Confirm Password";
                txtConfirmPassword.ForeColor = Color.Gray;
            }
            else if (txtConfirmPassword.Text == "Confirm Password")
            {
                txtConfirmPassword.ForeColor = Color.Gray;
            }
            else
            {
                txtConfirmPassword.ForeColor = Color.Black;
            }

            if (e.KeyCode == Keys.Back)
            {
                if (txtConfirmPassword.Text.Length == 0)
                {


                    txtConfirmPassword.Text = "Confirm Password";
                    txtConfirmPassword.PasswordChar = '\0';

                    txtConfirmPassword.ForeColor = Color.Gray;
                    Cursor.Current = Cursors.IBeam;
                }
            }
        }

        private void txtConfirmPassword_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (txtConfirmPassword.Text == "Confirm Password")
            {
                txtConfirmPassword.Text = "";
            }
        }

        private void txtConfirmPassword_Click(object sender, EventArgs e)
        {
            if (txtConfirmPassword.Text == "Confirm Password")
            {
                txtConfirmPassword.Focus();
                txtConfirmPassword.Select(0, 0);
            }
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
          

            if (txtConfirmPassword.Text == "Confirm Password" || txtNewPassword.Text == "New Password" || txtOldPassword.Text == "Old Password")
            {
                string s = String.Empty;


                return;
            }
            else
            {


            }

            if (txtNewPassword.Text == txtConfirmPassword.Text)
            {
                lblDoesnotMatch.Hide();
                lblX2.Hide();

            }

            else
            {
                lblX2.Show();
                lblDoesnotMatch.Show();
            }




            lblX3.Hide();
            lblOldAndNew.Hide();



            string password00 = txtConfirmPassword.Text;
            string password11 = txtNewPassword.Text;
            string password22 = txtOldPassword.Text;


            if (password00.Contains(@"\") || password11.Contains(@"\") || password22.Contains(@"\"))

            {

                MessageBox.Show("Your password is invalid for using " + @"'\'", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            // string [] user1 = new string [] {"Staff","Supervisor"};

            MySqlConnection Conn = ConString.Connection;
            MySqlCommand cmd = new MySqlCommand("Select * from tbl_login where user_type = 'Supervisor' and login_id = '" + loginID + "'  or user_type = 'Staff' and login_id = '" + loginID+ "' or user_type = 'Stockman' and login_id = '" + loginID + "'", Conn);

            cmd.CommandTimeout = 50000;
            MySqlDataReader myReader;
       

            try
            {
             
                myReader = cmd.ExecuteReader();

                while (myReader.Read())
                {
                    userpassword = myReader.GetString("password");
                }


                Conn.Close();

            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            if (txtOldPassword.Text == userpassword)
            {
                lblX1.Hide();
                lblOldPassword.Hide();

            }
            else
            {
                lblX1.Show();
                lblOldPassword.Show();

            }
            if (txtConfirmPassword.Text.Length < 6)
            {
                lblPasswordlong.Visible = true;
                return;
            }
            else
            {
                lblPasswordlong.Visible = false;
            }
            if (txtOldPassword.Text == userpassword && txtNewPassword.Text == txtConfirmPassword.Text)
            {
                if (txtNewPassword.Text == txtOldPassword.Text)
                {
                    lblOldAndNew.Show();
                    lblX3.Show();
                    return;
                }

                Conn = ConString.Connection;

                cmd = new MySqlCommand("update tbl_login set password = '" + this.txtConfirmPassword.Text + "' where login_id =  '" + loginID + "'", Conn);
                try
                {
                 
                    myReader = cmd.ExecuteReader();

                  
                    MessageBox.Show("Your password has been changed successfully.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    while (myReader.Read())
                    {

                    }


                    Conn.Close();
                    txtConfirmPassword.Clear();
                    txtOldPassword.Clear();
                    txtNewPassword.Clear();
                }

                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
                DGVAccountUser();
                txtOldPassword.Text = "Old Password";
                txtNewPassword.Text = "New Password";
                txtConfirmPassword.Text = "Confirm Password";
                txtNewPassword.PasswordChar = '\0';
                txtOldPassword.PasswordChar = '\0';
                txtConfirmPassword.PasswordChar = '\0';
                txtNewPassword.ForeColor = Color.Gray;
                txtConfirmPassword.ForeColor = Color.Gray;
                txtOldPassword.ForeColor = Color.Gray;
               
            }
        }

        private void btnHome_Click_1(object sender, EventArgs e)
        {
            if (frm_Login.user == "Admin")
            {
                var pleaseWait = new frm_PleaseWait();
                pleaseWait.Show();
                Application.DoEvents();
                Cursor.Current = Cursors.WaitCursor;
                var myForm = new frm_distribution();
                myForm.Show();
                pleaseWait.Hide();

                this.Hide();
            }
            else
            {
                var pleaseWait = new frm_PleaseWait();
                pleaseWait.Show();
                Application.DoEvents();
                Cursor.Current = Cursors.WaitCursor;
                var myForm = new frm_MainHomeStaff(user);
                myForm.Show();
                pleaseWait.Hide();

                this.Hide();
            }
          
        }

        private void btnPOS_Click_1(object sender, EventArgs e)
        {
            if (frm_Login.user == "Admin")
            {
                var pleaseWait = new frm_PleaseWait();
                pleaseWait.Show();
                Application.DoEvents();
                Cursor.Current = Cursors.WaitCursor;
                var myForm = new frm_distribution();
                myForm.Show();
                pleaseWait.Hide();

                this.Hide();
            }
            else if (frm_Login.stockman == "Stockman")
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
            else
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

        private void btnTransactionRecord_Click_1(object sender, EventArgs e)
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

        private void frm_AccountStaff_FormClosing(object sender, FormClosingEventArgs e)
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

        private void txtStreet_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            btnSave.BackColor = System.Drawing.ColorTranslator.FromHtml("#24262F");
            if (txtStreet.Text == street || txtStreet.Text == "")
            {
                btnSave.Enabled = false;
                btnSave.BackColor = Color.DarkGray;
            }



            if (txtStreet.Text.Length <= 0) return;
            string s = txtStreet.Text.Substring(0, 1);
            if (s != s.ToUpper())
            {
                int curSelStart = txtStreet.SelectionStart;
                int curSelLength = txtStreet.SelectionLength;
                txtStreet.SelectionStart = 0;
                txtStreet.SelectionLength = 1;
                txtStreet.SelectedText = s.ToUpper();
                txtStreet.SelectionStart = curSelStart;
                txtStreet.SelectionLength = curSelLength;
            }
        }

        private void txtBarangay_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            btnSave.BackColor = System.Drawing.ColorTranslator.FromHtml("#24262F");
            if (txtBarangay.Text == barangay || txtBarangay.Text == "")
            {
                btnSave.Enabled = false;
                btnSave.BackColor = Color.DarkGray;
            }
            if (txtBarangay.Text.Length <= 0) return;
            string s = txtBarangay.Text.Substring(0, 1);
            if (s != s.ToUpper())
            {
                int curSelStart = txtBarangay.SelectionStart;
                int curSelLength = txtBarangay.SelectionLength;
                txtBarangay.SelectionStart = 0;
                txtBarangay.SelectionLength = 1;
                txtBarangay.SelectedText = s.ToUpper();
                txtBarangay.SelectionStart = curSelStart;
                txtBarangay.SelectionLength = curSelLength;
            }
        }

        private void txtCity_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            btnSave.BackColor = System.Drawing.ColorTranslator.FromHtml("#24262F");
            if (txtCity.Text == city || txtCity.Text == "")
            {
                btnSave.Enabled = false;
                btnSave.BackColor = Color.DarkGray;
            }
            if (txtCity.Text.Length <= 0) return;
            string s = txtCity.Text.Substring(0, 1);
            if (s != s.ToUpper())
            {
                int curSelStart = txtCity.SelectionStart;
                int curSelLength = txtCity.SelectionLength;
                txtCity.SelectionStart = 0;
                txtCity.SelectionLength = 1;
                txtCity.SelectedText = s.ToUpper();
                txtCity.SelectionStart = curSelStart;
                txtCity.SelectionLength = curSelLength;
            }
        }

        private void lblForgotPassword_Click(object sender, EventArgs e)
        {
            var pleaseWait = new frm_PleaseWait();
            pleaseWait.Show();
            Application.DoEvents();
            Cursor.Current = Cursors.WaitCursor;
            var myForm = new frm_vforgotPassword_s1();
            myForm.Show();
            pleaseWait.Hide();
        }

        private void btnAccount_Click_1(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void btnhomenew1_Click(object sender, EventArgs e)
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
            var pleaseWait = new frm_PleaseWait();
            pleaseWait.Show();
            Application.DoEvents();
            Cursor.Current = Cursors.WaitCursor;
            var myForm = new frm_LoginHistory();
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
            var pleaseWait = new frm_PleaseWait();
            pleaseWait.Show();
            Application.DoEvents();
            Cursor.Current = Cursors.WaitCursor;
            var myForm = new frm_POS();
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

        private void button2_Click(object sender, EventArgs e)
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
        public void NotificationofCriticalLevel()
        {

            MySqlConnection Conn = ConString.Connection;

            string Query = "Select count(*) as 'C_Branch'  from (SELECT count(tbl_store.store_id)  from tbl_inventory inner join tbl_store on tbl_store.store_id = tbl_inventory.store_id where tbl_inventory.status  = 'Critical Level' and tbl_inventory.store_id = '" + frm_Login.global_storeid + "' group by tbl_inventory.product_id order by count(tbl_inventory.product_id)) as DerivedTableAlias";
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
                        pCritical.Visible = false;
                    }
                    else
                    {
                        lblqtycritical.Visible = true;
                        pCritical.Visible = true;
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
