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
    public partial class frm_AccountManager : Form
    {
        int selectedRow;
        string loginID;
        string status;
        string branch;
        string getStatus;
        string userpassword;
        string user;
        string street;
        int store_id;
        string barangay;
        string city;
        string contact;
        string email;
        string age;
        string password;
        string name;
        string surname;
        string manager = "Manager";
        string user_type;
        string username;
        public static string myName;
        public frm_AccountManager()
        {
            InitializeComponent();
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
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
        void DGVAccountUser()
        {

            // string Connection = "datasource=localhost;port=3306;username=root;password=1234";
            //MySqlConnection Conn = new MySqlConnection(ConString.);
             MySqlConnection Conn = ConString.Connection;

            MySqlCommand cmd = new MySqlCommand("SELECT login_id as 'Account ID', firstname as 'First Name', lastname as 'Last Name', gender as 'Gender', age as 'Age', birthdate as 'Birthdate', street as 'Street #',barangay as 'Barangay', city as 'City',contact as 'Contact #', email_address as 'Email Address', username as 'Username', user_type as 'Position', status as 'Status' FROM tbl_login where login_id = '" + frm_Login.GeneralID + "'", Conn);
            cmd.CommandTimeout = 50000;
            //mySqlConnection.Open();

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
        void DGVListofSystemUsers()
        {
         
            MySqlConnection Conn = ConString.Connection;

            MySqlCommand cmd = new MySqlCommand("SELECT tbl_login.login_id as 'User ID', tbl_login.status as 'Status',tbl_login.username as 'Username', tbl_login.user_type as 'Position', tbl_store.store_name as 'Outlet Name', tbl_login.firstname as 'First Name', tbl_login.lastname as 'Last Name', tbl_login.gender as 'Gender', tbl_login.age as 'Age', tbl_login.birthdate as 'Birthdate', tbl_login.street as 'Street #',tbl_login.barangay as 'Barangay', tbl_login.city as 'City',tbl_login.contact as 'Contact #', tbl_login.email_address as 'Email Address' FROM tbl_login left join tbl_store on tbl_login.store_id = tbl_store.store_id order by tbl_login.username;", Conn);
            cmd.CommandTimeout = 50000;
           

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
                MySqlDataReader myReader;
                myReader = cmd.ExecuteReader();
                while (myReader.Read())
                {
                }
                Conn.Close();
                dataGridView2.DefaultCellStyle.SelectionBackColor = Color.Pink;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            // string Connection = "datasource=localhost;port=3306;username=root;password=1234";
            MySqlConnection Conn = ConString.Connection;
            string Query = "UPDATE tbl_login SET street = '" + this.txtStreet.Text + "', barangay = '" + this.txtBarangay.Text + "',  city = '" + this.txtCity.Text + "', age = '" + this.txtAge.Text + "', contact = '" + this.txtContact.Text + "', email_address = '" + this.txtEmail.Text + "'  where login_id = '" + frm_Login.GeneralID + "' or login_id = '" + loginID + "'";
           // MySqlConnection Conn = new MySqlConnection(Connection);
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
                    //Conn.Open();
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
            try
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
            if (txtContact.Text == contact||txtContact.Text=="")
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
            if (txtEmail.Text == email||txtEmail.Text=="")
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
            if (txtAge.Text == age||txtAge.Text=="")
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
            if (txtOldPassword.Text == "Old Password" || txtOldPassword.Text == "")
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
            if (txtNewPassword.Text == txtConfirmPassword.Text || txtConfirmPassword.Text == "" || txtConfirmPassword.Text == "Confirm Password")
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
            //string Connection = "datasource=localhost;port=3306;username=root;password=1234";
            MySqlConnection Conn = ConString.Connection;
        //    MySqlConnection Conn = new MySqlConnection(Connection);

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

            string manager = "Manager";
            MySqlCommand cmd = new MySqlCommand("Select * from tbl_login where user_type = '" + manager + "' and login_id = '" + loginID + "'", Conn);

            cmd.CommandTimeout = 50000;
            MySqlDataReader myReader;


            try
            {
                Conn = ConString.Connection;
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



                cmd = new MySqlCommand("update tbl_login set password = '" + this.txtConfirmPassword.Text + "' where login_id =  '" + loginID + "'", Conn);
                try
                {
                    Conn = ConString.Connection;
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
            var pleaseWait = new frm_PleaseWait();
            pleaseWait.Show();
            Application.DoEvents();
            Cursor.Current = Cursors.WaitCursor;
            var myForm = new frm_MainHomeStaff(user);
            myForm.Show();
            pleaseWait.Hide();

            this.Hide();
        }

        private void btnPOS_Click_1(object sender, EventArgs e)
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
                    // string Connection = "datasource=localhost;port=3306;username=root;password=1234";
                    // MySqlConnection Conn = new MySqlConnection(Connection);
                    // Conn.Open();
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
                    //string Connection = "datasource=localhost;port=3306;username=root;password=1234";
                    //   MySqlConnection Conn = new MySqlConnection(Connection);
                    //  Conn.Open();
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
            if (txtStreet.Text == street||txtStreet.Text=="")
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
            if (txtBarangay.Text == barangay||txtBarangay.Text=="")
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
            if (txtCity.Text == city||txtCity.Text=="")
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

        private void frm_AccountManager_Load(object sender, EventArgs e)
        {
            NotificationofCriticalLevel_Warehouse();
            PictureBox pic = new PictureBox();
            pic.Width = 16;
            pic.Height = 16;
            pic.Left = 200;
            pic.BackgroundImage = NurseryVan_System.Properties.Resources.search2;
            txtSearch.Controls.Add(pic);
            if (frm_Login.user == "Admin")
            {
                btnHome.Text = "BACKUP/RESTORE";
                btnHome.TileTextFontSize = MetroFramework.MetroTileTextSize.Small;
                btnRecord.Text = "ADMIN ACCOUNT";
                btnRecord.TileTextFontSize = MetroFramework.MetroTileTextSize.Small;
                btnInventory.Visible = false;
                btnSupplier.Visible = false;
                btnSales.Visible = false;
                btnManageAccount.Visible = false;
                btnLoginHistory.Visible = false;
                btnLogout.Location = new Point(4, 109);

            }
            else if (frm_Login.user == "Manager")
            {
               
            }
            else
            {
                tabControl1.TabPages.Remove(tabPage1);
            }

            DGVAccountUser();
            DGVListofSystemUsers();
            ComboboxofStore();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            lblStaffAccount.Text = frm_Login.myName + ("'s Password Account");
            lblStaffAccount.Text = myName;
            btnNewAccount.ForeColor = Color.White;
            btnDelete.ForeColor = Color.White;
            //string Connection = "datasource=localhost;port=3306;username=root;password=1234";
            // MySqlConnection Conn = new MySqlConnection(Connection);
            MySqlConnection Conn = ConString.Connection;
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM tbl_login where login_id = '" + frm_Login.GeneralID + "'", Conn);
            cmd.CommandTimeout = 50000;
          //  Conn.Open();

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
        private void btnNewAccount_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            var myForm = new frm_CreateNewAccount();
            myForm.Show();
            this.Hide();
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
                loginID = row.Cells[0].Value.ToString();
                name = row.Cells[5].Value.ToString();
                surname = row.Cells[6].Value.ToString();
                user_type = row.Cells[3].Value.ToString();
                branch = row.Cells[4].Value.ToString();
                cbStore.Text = row.Cells[4].Value.ToString();

                username = row.Cells[2].Value.ToString();
                status = row.Cells[1].Value.ToString();
                getStatus = row.Cells[3].Value.ToString();

                //login_id as 'User ID', status as 'Status',username as 'Username', user_type as 'Position',branch, firstname as 'First Name', lastname as 'Last Name', gender as 'Gender', 
                //age as 'Age', birthdate as 'Birthdate', street as 'Street #',barangay as 'Barangay', city as 'City',contact as 'Contact #', email_address as 'Email Address'

             
                if (getStatus == "Manager" || getStatus == "Admin" || cbStore.Text == "" || getStatus == "Stockman"|| cbStore.Text == branch)
                {
                    btnUpdateBranch.Enabled = false;
                    btnUpdateBranch.BackColor = Color.DarkGray;
                }
                else
                {
                    btnUpdateBranch.Enabled = true;
                    btnUpdateBranch.BackColor = System.Drawing.ColorTranslator.FromHtml("#24262F");
                }
                if (status == "Deactivate")
                {
                    btnDelete.Enabled = false;
                    btnDelete.BackColor = Color.DarkGray;
                    btnRecover.Enabled = true;
                    btnRecover.BackColor = Color.OrangeRed;
                }
                if (status == "Active")
                {
                    btnDelete.Enabled = true;
                    btnDelete.BackColor = Color.Red;
                    btnRecover.Enabled = false;
                    btnRecover.BackColor = Color.DarkGray;
                }
             
            }
        }
        public void Removeusertype()
        {


            MySqlConnection Conn = ConString.Connection;
            //


            string Query = "Update tbl_login set store_id = '' where user_type != '' and user_type = 'Stockman'";
            MySqlCommand cmd = new MySqlCommand(Query, Conn);
            MySqlDataReader myReader;

            AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
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
                MessageBox.Show(ex.Message, "Error1");
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            //  string Connection = "datasource=localhost;port=3306;username=root;password=1234";
            //  MySqlConnection Conn = new MySqlConnection(Connection);
            MySqlConnection Conn = ConString.Connection;
            string removed = "Deactivate";
            MySqlCommand cmd = new MySqlCommand("UPDATE tbl_login SET status = '"+removed+"' where login_id = '" + loginID + "'", Conn);
            cmd.CommandTimeout = 50000;
           // Conn.Open();
            if (user_type == manager)
            {
                MessageBox.Show("Manager can't deactivate.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (user_type == "Admin")
            {
                MessageBox.Show("Admin can't deactivate.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("Are you sure, you want to deactivate " + name + (" ") + surname, "Fabula's Merchandise System", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {

                try
                {

                    MySqlDataReader myReader;
                    myReader = cmd.ExecuteReader();
                    while (myReader.Read())
                    {

                    }
                    Conn.Close();
                    MessageBox.Show("Deactivate successfully.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
           
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            DGVListofSystemUsers();
        }

        private void btnHome_Click_2(object sender, EventArgs e)
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
                var myForm = new frm_MainHomeManager(manager);
                myForm.Show();
                pleaseWait.Hide();

                this.Hide();
            }
           
        }

        private void btnRecord_Click(object sender, EventArgs e)
        {
            if (frm_Login.user == "Admin")
            {

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

        private void btnInventory_Click_2(object sender, EventArgs e)
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

        private void btnLoginHistory_Click_2(object sender, EventArgs e)
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

        }

        private void btnLogout_Click_2(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Are you sure, you want to logout?", "Fabula's Merchandise System", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                Cursor.Current = Cursors.WaitCursor;
                frm_Login.time = DateTime.Now.ToShortTimeString();
                try
                {
                    //string Connection = "datasource=localhost;port=3306;username=root;password=1234";
                    // MySqlConnection Conn = new MySqlConnection(Connection);
                    // Conn.Open();
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

        private void frm_AccountManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Are you sure, you want to exit?", "Fabula's Merchandise System", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {

                Cursor.Current = Cursors.WaitCursor;
                frm_Login.time = DateTime.Now.ToShortTimeString();
                try
                {
                    // string Connection = "datasource=localhost;port=3306;username=root;password=1234";
                    //  MySqlConnection Conn = new MySqlConnection(Connection);
                    //  Conn.Open();
                    MySqlConnection Conn = ConString.Connection;
                    MySqlCommand cmd = new MySqlCommand("update tbl_loginhistory set time_out = '" + frm_Login.time + "' where login_id = '" + frm_Login.loginID + "'", Conn);

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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {



                // MySqlConnection Conn = new MySqlConnection("datasource=localhost;port=3306;username=root;password=1234");
                // Conn.Open();
                MySqlConnection Conn = ConString.Connection;
                DataTable dt = new DataTable();

                MySqlDataAdapter sda = new MySqlDataAdapter("SELECT login_id as 'User ID', status as 'Status', firstname as 'First Name', lastname as 'Last Name', gender as 'Gender', age as 'Age', birthdate as 'Birthdate', street as 'Street #',barangay as 'Barangay', city as 'City',contact as 'Contact #', email_address as 'Email Address', username as 'Username', user_type as 'Position' FROM tbl_login where username like '%" + txtSearch.Text + "%' or firstname like '%"+txtSearch.Text+"%' or lastname like '%"+txtSearch.Text+"%'", Conn);
                sda.Fill(dt);
                Conn.Close();
                dataGridView2.DataSource = dt;

                if (txtSearch.Text == "Search")
                {

                    DGVListofSystemUsers();
                    lblMatch.Hide();

                }



            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
         
            try
            {
                if (!dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex].IsNewRow)
                {
                    foreach (DataGridViewCell cell in dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex].Cells)
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

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnRecover_Click(object sender, EventArgs e)
        {
            // string Connection = "datasource=localhost;port=3306;username=root;password=1234";
            //  MySqlConnection Conn = new MySqlConnection(Connection);
            MySqlConnection Conn = ConString.Connection;
            string recover = "Active";
            MySqlCommand cmd = new MySqlCommand("UPDATE tbl_login SET status = '" + recover + "' where login_id = '" + loginID + "'", Conn);
            cmd.CommandTimeout = 50000;
           // Conn.Open();
           
            if (MessageBox.Show("Are you sure, you want to recover " + name + (" ") + surname, "Fabula's Merchandise System", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {

                try
                {

                    MySqlDataReader myReader;
                    myReader = cmd.ExecuteReader();
                    while (myReader.Read())
                    {

                    }
                    Conn.Close();


                    MessageBox.Show("Recovered successfully.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            DGVListofSystemUsers();
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            MySqlConnection Conn = ConString.Connection;

            MySqlCommand cmd = new MySqlCommand("UPDATE tbl_login SET store_id = '" + txtstore_id.Text + "' where login_id = '" + loginID + "'", Conn);
            cmd.CommandTimeout = 50000;
            // Conn.Open();

          
                try
                {

                    MySqlDataReader myReader;
                    myReader = cmd.ExecuteReader();
                    while (myReader.Read())
                    {

                    }
                    Conn.Close();


                    MessageBox.Show("Updated user in outlet successfully.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            
            DGVListofSystemUsers();
            btnUpdateBranch.Enabled = false;
            btnUpdateBranch.BackColor = Color.DarkGray;
        }

        private void cbStore_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnUpdateBranch.Enabled = true;
            btnUpdateBranch.BackColor = System.Drawing.ColorTranslator.FromHtml("#24262F");
            if (getStatus == "Manager" || getStatus == "Admin" || getStatus == "Stockman" || cbStore.Text == branch)
            {
                btnUpdateBranch.Enabled = false;
                btnUpdateBranch.BackColor = Color.DarkGray;
            }
          
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

        }

        private void txtstore_id_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbStore_TextChanged(object sender, EventArgs e)
        {
          


            
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

        private void btnmanageaccounts_Click(object sender, EventArgs e)
        {

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
                    //string Connection = "datasource=localhost;port=3306;username=root;password=1234";
                    // MySqlConnection Conn = new MySqlConnection(Connection);
                    // Conn.Open();
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

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void metroTile1_Click_1(object sender, EventArgs e)
        {
            var myForm = new frm_distribution();
            myForm.ShowDialog();
        }
    }
}
