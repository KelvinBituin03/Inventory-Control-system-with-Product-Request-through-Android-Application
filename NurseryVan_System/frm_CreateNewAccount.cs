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
    public partial class frm_CreateNewAccount : Form
    {
        string user_type;
        string user_type1;
        string submanager = "Manager";
        string subAdmin = "Admin";
        public static string manager;
        string x;
        string storename;
        int store_id;
        public frm_CreateNewAccount()
        {
            generator();
            InitializeComponent();
        }
        public class UserDisplayName
        {
            public static string displayName;
        }


        private void txtFirstname_Leave(object sender, EventArgs e)
        {
            if (txtFirstname.Text.Length == 0)
            {
                txtFirstname.Text = "First Name";
                txtFirstname.ForeColor = SystemColors.GrayText;
            }
            if (txtFirstname.Text == "First Name" || txtFirstname.Text == "")
            {
                lbl1.Text = "You can't leave this empty.";
                return;
            }
        }

        private void txtFirstname_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtFirstname.Text.Equals(null) == true)
            {
                txtFirstname.Text = "First Name";
                txtFirstname.ForeColor = Color.Gray;
            }
            else if (txtFirstname.Text == "First Name")
            {
                txtFirstname.ForeColor = Color.Gray;
            }
            else
            {
                txtFirstname.ForeColor = Color.Black;
            }
            if (e.KeyCode == Keys.Back)
            {
                if (txtFirstname.Text.Length == 0)
                {


                    txtFirstname.Text = "First Name";

                    txtFirstname.ForeColor = Color.Gray;
                    Cursor.Current = Cursors.IBeam;


                }
            }
        }

        private void txtFirstname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtFirstname.Text == "First Name")
            {
                txtFirstname.Text = "";
            }
        }

        private void txtFirstname_Click(object sender, EventArgs e)
        {
            if (txtFirstname.Text == "First Name")
            {
                txtFirstname.Focus();
                txtFirstname.Select(0, 0);

            }
        }

        private void txtLastname_Leave(object sender, EventArgs e)
        {
            if (txtLastname.Text.Length == 0)
            {
                txtLastname.Text = "Last Name";
                txtLastname.ForeColor = SystemColors.GrayText;
            }
            if (txtLastname.Text == "Last Name" || txtLastname.Text == "")
            {
                lbl2.Text = "You can't leave this empty.";
                return;
            }
        }

        private void txtLastname_KeyUp(object sender, KeyEventArgs e)
        {

            if (txtLastname.Text.Equals(null) == true)
            {
                txtLastname.Text = "Last Name";
                txtLastname.ForeColor = Color.Gray;
            }
            else if (txtLastname.Text == "Last Name")
            {
                txtLastname.ForeColor = Color.Gray;
            }

            else
            {
                txtLastname.ForeColor = Color.Black;
            }
            if (e.KeyCode == Keys.Back)
            {
                if (txtLastname.Text.Length == 0)
                {


                    txtLastname.Text = "Last Name";

                    txtLastname.ForeColor = Color.Gray;
                    Cursor.Current = Cursors.IBeam;


                }
            }
        }

        private void txtLastname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtLastname.Text == "Last Name")
            {
                txtLastname.Text = "";
            }
        }

        private void txtLastname_Click(object sender, EventArgs e)
        {
            if (txtLastname.Text == "Last Name")
            {
                txtLastname.Focus();
                txtLastname.Select(0, 0);

            }
        }

        private void txtStreet_Leave(object sender, EventArgs e)
        {
            if (txtStreet.Text.Length == 0)
            {
                txtStreet.Text = "Street #";
                txtStreet.ForeColor = SystemColors.GrayText;
            }
            if (txtStreet.Text == "Street #" || txtStreet.Text == "")
            {
                lblStreet.Text = "You can't leave this empty.";
                return;
            }
        }

        private void txtStreet_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtStreet.Text.Equals(null) == true)
            {
                txtStreet.Text = "Street #";
                txtStreet.ForeColor = Color.Gray;
            }
            else if (txtStreet.Text == "Street #")
            {
                txtStreet.ForeColor = Color.Gray;
            }

            else
            {
                txtStreet.ForeColor = Color.Black;
            }
            if (e.KeyCode == Keys.Back)
            {
                if (txtStreet.Text.Length == 0)
                {


                    txtStreet.Text = "Street #";

                    txtStreet.ForeColor = Color.Gray;
                    Cursor.Current = Cursors.IBeam;


                }
            }
        }

        private void txtStreet_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtStreet.Text == "Street #")
            {
                txtStreet.Text = "";
            }
        }

        private void txtStreet_Click(object sender, EventArgs e)
        {
            if (txtStreet.Text == "Street #")
            {
                txtStreet.Focus();
                txtStreet.Select(0, 0);

            }
        }

        private void txtBarangay_Leave(object sender, EventArgs e)
        {
            if (txtBarangay.Text.Length == 0)
            {
                txtBarangay.Text = "Barangay";
                txtBarangay.ForeColor = SystemColors.GrayText;
            }
            if (txtBarangay.Text == "Barangay" || txtBarangay.Text == "")
            {
                lblBarangay.Text = "You can't leave this empty.";
                return;
            }
        }

        private void txtBarangay_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtBarangay.Text.Equals(null) == true)
            {
                txtBarangay.Text = "Barangay";
                txtBarangay.ForeColor = Color.Gray;
            }
            else if (txtBarangay.Text == "Barangay")
            {
                txtBarangay.ForeColor = Color.Gray;
            }

            else
            {
                txtBarangay.ForeColor = Color.Black;
            }
            if (e.KeyCode == Keys.Back)
            {
                if (txtBarangay.Text.Length == 0)
                {


                    txtBarangay.Text = "Barangay";

                    txtBarangay.ForeColor = Color.Gray;
                    Cursor.Current = Cursors.IBeam;


                }
            }
        }

        private void txtBarangay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtBarangay.Text == "Barangay")
            {
                txtBarangay.Text = "";
            }
        }

        private void txtBarangay_Click(object sender, EventArgs e)
        {
            if (txtBarangay.Text == "Barangay")
            {
                txtBarangay.Focus();
                txtBarangay.Select(0, 0);

            }
        }

        private void txtCity_Leave(object sender, EventArgs e)
        {
            if (txtCity.Text.Length == 0)
            {
                txtCity.Text = "City";
                txtCity.ForeColor = SystemColors.GrayText;
            }
            if (txtCity.Text == "City" || txtCity.Text == "")
            {
                lblCity.Text = "You can't leave this empty.";
                return;
            }
        }

        private void txtCity_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtCity.Text.Equals(null) == true)
            {
                txtCity.Text = "City";
                txtCity.ForeColor = Color.Gray;
            }
            else if (txtCity.Text == "City")
            {
                txtCity.ForeColor = Color.Gray;
            }

            else
            {
                txtCity.ForeColor = Color.Black;
            }
            if (e.KeyCode == Keys.Back)
            {
                if (txtCity.Text.Length == 0)
                {


                    txtCity.Text = "City";

                    txtCity.ForeColor = Color.Gray;
                    Cursor.Current = Cursors.IBeam;


                }
            }
        }

        private void txtCity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtCity.Text == "City")
            {
                txtCity.Text = "";
            }
        }

        private void txtCity_Click(object sender, EventArgs e)
        {
            if (txtCity.Text == "City")
            {
                txtCity.Focus();
                txtCity.Select(0, 0);

            }
        }

        private void txtFirstname_TextChanged(object sender, EventArgs e)
        {

            if (txtFirstname.Text.Length <= 0) return;
            string s = txtFirstname.Text.Substring(0, 1);
            if (s != s.ToUpper())
            {
                int curSelStart = txtFirstname.SelectionStart;
                int curSelLength = txtFirstname.SelectionLength;
                txtFirstname.SelectionStart = 0;
                txtFirstname.SelectionLength = 1;
                txtFirstname.SelectedText = s.ToUpper();
                txtFirstname.SelectionStart = curSelStart;
                txtFirstname.SelectionLength = curSelLength;
            }
            lbl1.Text = "";
        }

        private void txtCity_TextChanged(object sender, EventArgs e)
        {
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
            lblCity.Text = "";
        }

        private void txtLastname_TextChanged(object sender, EventArgs e)
        {
            if (txtLastname.Text.Length <= 0) return;
            string s = txtLastname.Text.Substring(0, 1);
            if (s != s.ToUpper())
            {
                int curSelStart = txtLastname.SelectionStart;
                int curSelLength = txtLastname.SelectionLength;
                txtLastname.SelectionStart = 0;
                txtLastname.SelectionLength = 1;
                txtLastname.SelectedText = s.ToUpper();
                txtLastname.SelectionStart = curSelStart;
                txtLastname.SelectionLength = curSelLength;
            }
            lbl2.Text = "";
        }

        private void txtStreet_TextChanged(object sender, EventArgs e)
        {

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
            lblStreet.Text = "";
        }

        private void txtBarangay_TextChanged(object sender, EventArgs e)
        {

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
            lblBarangay.Text = "";
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtContact_Leave(object sender, EventArgs e)
        {

            if (txtContact.Text == "Contact #" || txtContact.Text == "" || txtContact.Text == "Contact #" || txtContact.Text == "")
            {
                lbl6.Text = "You can't leave this empty.";
                lblphone.Hide();
                return;
            }
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


            if (txtContact.Text == "Contact #" || txtContact.Text == "")
            {
                lblphone.Hide();
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

            if (txtContact.Text.Length == 0)
            {
                txtContact.Text = "Contact #";
                txtContact.ForeColor = SystemColors.GrayText;
            }
        }

        private void txtContact_TextChanged(object sender, EventArgs e)
        {
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
            if (txtContact.Text.Contains("09"))
            {
                txtContact.MaxLength = 11;
            }
            else
            {
                txtContact.MaxLength = 13;
            }
            lblphone.Hide();

            lbl6.Text = "";
        }
        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == txtEmail.Text;

            }
            catch
            {

                return false;
            }
        }

        private void txtContact_KeyUp(object sender, KeyEventArgs e)
        {

            if (txtContact.Text.Equals(null) == true)
            {
                txtContact.Text = "Contact #";
                txtContact.ForeColor = Color.Gray;
            }
            else if (txtContact.Text == "Contact #")
            {
                txtContact.ForeColor = Color.Gray;
            }
            else
            {
                txtContact.ForeColor = Color.Black;
            }
            if (e.KeyCode == Keys.Back)
            {
                if (txtContact.Text.Length == 0)
                {


                    txtContact.Text = "Contact #";

                    txtContact.ForeColor = Color.Gray;
                    Cursor.Current = Cursors.IBeam;


                }
            }
        }

        private void txtContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtContact.Text == "Contact #")
            {
                txtContact.Text = "";
            }

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '+'))
            {
                e.Handled = true;
            }
        }

        private void txtContact_Click(object sender, EventArgs e)
        {
            if (txtContact.Text == "Contact #")
            {
                txtContact.Focus();
                txtContact.Select(0, 0);

            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            if (txtEmail.Text == "Email Address" || txtEmail.Text == "")
            {
                lblDontforget.Hide();
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
            }
            lbl7.Text = "";
            lblDontforget.Hide();
            lblEmailnotvalid.Hide();
            lblBeforeDontforget.Hide();
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (txtEmail.Text == "Email Address" || txtEmail.Text == "")
            {
                lbl7.Text = "You can't leave this empty.";
                return;
            }
            if (txtEmail.Text.Length == 0)
            {
                txtEmail.Text = "Email Address";
                txtEmail.ForeColor = SystemColors.GrayText;
            }
            if (txtEmail.Text == "Email Address")
            {
                lblDontforget.Visible = false;
                return;
            }
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

        private void txtEmail_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtEmail.Text.Equals(null) == true)
            {
                txtEmail.Text = "Email Address";
                txtEmail.ForeColor = Color.Gray;
            }
            else if (txtEmail.Text == "Email Address")
            {
                txtEmail.ForeColor = Color.Gray;
            }
            else
            {
                txtEmail.ForeColor = Color.Black;
            }
            if (e.KeyCode == Keys.Back)
            {
                if (txtEmail.Text.Length == 0)
                {


                    txtEmail.Text = "Email Address";

                    txtEmail.ForeColor = Color.Gray;
                    Cursor.Current = Cursors.IBeam;

                }
            }
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtEmail.Text == "Email Address")
            {
                txtEmail.Text = "";
            }
        }

        private void txtEmail_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text == "Email Address")
            {
                txtEmail.Focus();
                txtEmail.Select(0, 0);
            }
        }

        private void cbUsertype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbUsertype.Text == user_type)
            {
                lblonlymanager.Text = "Only owner: " + frm_Login.myName + " can manage the Fabula's Merchandise System.";
                lblonlymanager.Show();
                label6.ForeColor = Color.Gray;
                cbStore.Enabled = false;
                return;
            }
            else
            {
                lblonlymanager.Hide();
            }
         
         
            lbl10.Text = "";
            //if (cbUsertype.Text == "Staff")
            //{
            //    label6.ForeColor = Color.Black;
            //    cbStore.Enabled = true;

            //}
            //else
            //{
            //    label6.ForeColor = Color.Gray;
            //    cbStore.Enabled = false;
            //}

            label9.Text = "";
            label9.Visible = true;



            if (cbUsertype.Text == "Supervisor")
            {


                MySqlConnection Conn = ConString.Connection;
                string Query = "SELECT * FROM tbl_login inner join tbl_store on tbl_login.store_id = tbl_store.store_id where tbl_login.user_type = 'Supervisor' and tbl_store.store_id = '" + txtstore_id.Text + "'";

                MySqlCommand cmd = new MySqlCommand(Query, Conn);


                MySqlDataReader myReader = cmd.ExecuteReader();
                while (myReader.Read())
                {


                    label9.Text = "There is already Supervisor in the outlet: ." + cbStore.Text;
                }

                Conn.Close();

            }


            if (cbUsertype.Text == "Supervisor")
            {
                try
                {







                    MySqlConnection Conn = ConString.Connection;

                    DataTable dt = new DataTable();
                    MySqlDataAdapter sda = new MySqlDataAdapter("select tbl_store.store_name as 'Store', tbl_login.status as 'S' from tbl_store left join tbl_login on tbl_store.store_id = tbl_login.store_id  where tbl_store.status = 'New' or tbl_login.status = 'Deactivate' and tbl_login.user_type = 'Supervisor'", Conn);
                    sda.Fill(dt);
                    Conn.Close();
                    cbStore.DataSource = dt;

                  //  cbStore.DisplayMember = "S";
                   // cbStore.ValueMember = "S";

                    cbStore.DisplayMember = "Store";
                    cbStore.ValueMember = "Store";

                    label9.Text = "";
                    cbStore.Visible = true;
                    label6.Visible = true;


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (cbUsertype.Text == "Stockman")
            {

                //cbStore.Visible = false;
                //label6.Visible = false;




                cbStore.Text = "No assigned for outlet";
             

            }
            else if (cbUsertype.Text == "Staff")
            {
                try
                {







                    MySqlConnection Conn = ConString.Connection;

                    DataTable dt = new DataTable();
                    MySqlDataAdapter sda = new MySqlDataAdapter("select * from tbl_store", Conn);
                    sda.Fill(dt);
                    Conn.Close();
                    cbStore.DataSource = dt;

                    cbStore.DisplayMember = "store_name";
                    cbStore.ValueMember = "store_name";

                }
                catch (Exception ex)
                {

                }
                cbStore.Visible = true;
                label6.Visible = true;
            }
          
        }

        private void cbUsertype_Leave(object sender, EventArgs e)
        {
            if (cbUsertype.Text == "")
            {
                lbl10.Text = "You can't leave this empty.";
                return;
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
          
            //if (txtUsername.Text.Length <= 0) return;
            //string s = txtUsername.Text.Substring(0, 1);
            //if (s != s.ToUpper())
            //{
            //    int curSelStart = txtUsername.SelectionStart;
            //    int curSelLength = txtUsername.SelectionLength;
            //    txtUsername.SelectionStart = 0;
            //    txtUsername.SelectionLength = 1;
            //    txtUsername.SelectedText = s.ToUpper();
            //    txtUsername.SelectionStart = curSelStart;
            //    txtUsername.SelectionLength = curSelLength;
            //}


            MySqlConnection Conn = ConString.Connection;
            DataTable dtt = new DataTable();
            MySqlDataAdapter sda = new MySqlDataAdapter("select username, user_type from tbl_login where username = '" + txtUsername.Text + "'", Conn);
            sda.Fill(dtt);
            Conn.Close();

            if (dtt.Rows.Count == 1 || dtt.Rows.Count >= 1)
            {
                lblAlreadyExist.Visible = true;
                lblAlreadyExist.Text = txtUsername.Text.ToString() + (" already exists.");


                return;
            }
            else
            {
                lblAlreadyExist.Visible = false;
            }

            lbl8.Text = "";
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            if (txtUsername.Text == "Username" || txtUsername.Text == "")
            {
                lbl8.Text = "You can't leave this empty.";
                return;
            }
            if (txtUsername.Text.Length == 0)
            {
                txtUsername.Text = "Username";
                txtUsername.ForeColor = SystemColors.GrayText;
            }
        }

        private void txtUsername_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtUsername.Text.Equals(null) == true)
            {
                txtUsername.Text = "Username";
                txtUsername.ForeColor = Color.Gray;
            }
            else if (txtUsername.Text == "Username")
            {
                txtUsername.ForeColor = Color.Gray;
            }
            else
            {
                txtUsername.ForeColor = Color.Black;
            }
            if (e.KeyCode == Keys.Back)
            {
                if (txtUsername.Text.Length == 0)
                {


                    txtUsername.Text = "Username";

                    txtUsername.ForeColor = Color.Gray;
                    Cursor.Current = Cursors.IBeam;


                }
            }
        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtUsername.Text == "Username")
            {
                txtUsername.Text = "";
            }
        }

        private void txtUsername_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "Username")
            {
                txtUsername.Focus();
                txtUsername.Select(0, 0);

            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '•';
            lbl11.Text = "";
            if (txtPassword.Text == "")
            {
                lblPasswordlong.Visible = false;
                return;
            }

            if (txtPassword.Text == "Password")
            {
                lblPWeak.Visible = false;
                lblPMedium.Visible = false;
                lblTooShort.Visible = false;
                lblPStrong.Visible = false;
                lblPS.Visible = false;

                return;

            }
            if (txtPassword.Text.Length < 6)
            {
                lblTooShort.Visible = true;
                lblPWeak.Visible = false;
                lblPMedium.Visible = false;
                lblPStrong.Visible = false;
                lblPS.Visible = false;

                return;
            }
            else if (txtPassword.Text.Length >= 6 && txtPassword.Text.Length <= 7)
            {
                lblTooShort.Visible = false;
                lblPWeak.Visible = true;
                lblPMedium.Visible = false;
                lblPStrong.Visible = false;
                lblPS.Visible = true;
            }
            else if ((txtPassword.Text.Length >= 8 && txtPassword.Text.Length <= 25))
            {
                lblPWeak.Visible = false;
                lblPMedium.Visible = true;
                lblPStrong.Visible = false;
                lblPS.Visible = true;
            }
            else if ((txtPassword.Text.Length >= 26 && txtPassword.Text.Length <= 50))
            {
                lblPWeak.Visible = false;
                lblPMedium.Visible = false;
                lblPStrong.Visible = true;
                lblPS.Visible = true;
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Password" || txtPassword.Text == "")
            {
                lbl11.Text = "You can't leave this empty.";
                return;
            }
            if (txtPassword.Text.Length == 0)
            {
                txtPassword.Text = "Password";
                txtPassword.ForeColor = SystemColors.GrayText;
            }
        }

        private void txtPassword_KeyUp(object sender, KeyEventArgs e)
        {

            if (txtPassword.Text.Equals(null) == true)
            {
                txtPassword.Text = "Password";
                txtPassword.ForeColor = Color.Gray;
            }
            else if (txtPassword.Text == "Password")
            {
                txtPassword.ForeColor = Color.Gray;
            }


            else
            {

                txtPassword.ForeColor = Color.Black;


            }


            if (e.KeyCode == Keys.Back)
            {
                if (txtPassword.Text.Length == 0)
                {


                    txtPassword.Text = "Password";
                    txtPassword.PasswordChar = '\0';
                    txtPassword.ForeColor = Color.Gray;
                    Cursor.Current = Cursors.IBeam;


                }
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtPassword.Text == "Password")
            {
                txtPassword.Text = "";
            }
        }

        private void txtPassword_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Password")
            {
                txtPassword.Focus();
                txtPassword.Select(0, 0);

            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {


                btnAddAccount.PerformClick();
                if (txtPassword.Text == "Password")
                {

                    txtPassword.Focus();
                    txtPassword.Select(0, 0);


                }
            }

            if (txtPassword.Text == "Password")
            {
                txtPassword.Text = "";

            }
        }

        private void checkBoxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = checkBoxShowPassword.Checked ? '\0' : '•';
        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            if(cbStore.Text == "" && cbUsertype.Text == "Supervisor")
            {
                MessageBox.Show("Each outlets has own supervisor.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.None);
                return;
            }

            if (cbUsertype.Text == "Staff")
            {
                cbUsertype.Text = "Supervisor";



            }
            try
            {
                MySqlConnection Conn = ConString.Connection;
                DataTable dtt = new DataTable();
                MySqlDataAdapter sda = new MySqlDataAdapter("select username, user_type from tbl_login where username = '" + txtUsername.Text + "'", Conn);
                sda.Fill(dtt);
                Conn.Close();

                if (cbUsertype.Text == "Staff")
                {
                    if (cbStore.Text == "")
                    {
                        MessageBox.Show("Please enter require fields.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.None);
                        return;
                    }
                }
                if (txtGender.Text == "")
                {
                    rbgender.Text = "You can't leave this empty";
                    return;
                }
                if(label9.Text != "")
                {
                    return;
                }
                if (txtLastname.Text == "" || txtFirstname.Text == "" || radioButton1.Text == "" || radioButton2.Text == "" || txtUsername.Text == "" || txtPassword.Text == "" || cbUsertype.Text == "" || txtContact.Text == "" || txtEmail.Text == "" || txtStreet.Text == "" || txtBarangay.Text == "" || txtCity.Text == "" || txtAnswer.Text == "" || txtAge.Text == "" || cmbSQuest.Text == "" || txtGender.Text == "")
                {
                    string myStringVariable1 = string.Empty;
                    MessageBox.Show("Please enter require fields.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.None);
                    label2.Visible = true;
                    return;
                }

                if (txtLastname.Text == "Last Name" || txtFirstname.Text == "First Name" || txtUsername.Text == "Username" || txtPassword.Text == "Password" || txtStreet.Text == "Street #" || txtBarangay.Text == "Barangay" || txtCity.Text == "City" || txtContact.Text == "Contact #" || txtEmail.Text == "Email Address")
                {
                    string myStringVariable1 = string.Empty;
                    MessageBox.Show("Please enter require fields.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.None);
                    label2.Visible = true;
                    return;
                }


                if (dtt.Rows.Count == 1 || dtt.Rows.Count >= 1)
                {

                    MessageBox.Show("Username: " + txtUsername.Text + " already exists.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    txtUsername.Clear();
                    txtPassword.Clear();
                    return;
                }

                if (cbUsertype.Text == user_type)
                {
                    MessageBox.Show("Only owner: " + frm_Login.manager + " can manage the Fabula's Merchandise System.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }





                string password = txtPassword.Text;



                if (password.Contains(@"\"))

                {

                    MessageBox.Show("Your password is invalid for using " + @"'\'", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }
                string username = txtUsername.Text;



                if (txtPassword.Text.Length < 6)
                {

                    return;
                }

                if (txtAge.Text == "")
                {

                    return;
                }

                if (int.Parse(txtAge.Text) <= 17 && int.Parse(txtAge.Text) > 10)
                {
                    lbl18.Show();
                    return;
                }

                if (int.Parse(txtAge.Text) <= 10)
                {
                    lblInvaliddateofbirth.Text = "Your age doesn't look right. Be sure to use your actual age of birth.";
                    // txtAge.Text = "";
                    return;
                }

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

                if (txtContact.Text == "Contact #" || txtContact.Text == "")
                {
                    lbl6.Text = "You can't leave this empty.";
                    return;

                }
                if (txtContact.Text == "Contact #" || txtContact.Text == "")
                {
                    lblphone.Hide();
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






                if (txtEmail.Text == "Email Address" || txtEmail.Text == "")
                {
                    lblEmailnotvalid.Hide();
                    lblDontforget.Text = "";
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
                if (cbUsertype.Text == user_type1)
                {
                    lblonlymanager.Text = "Admin already exists.";
                    lblonlymanager.Show();
                    return;
                }
                else
                {
                    lblonlymanager.Hide();
                }

                string Active = "Active";

                 Conn = ConString.Connection;
                string Query = "insert into tbl_login (login_id, lastname, firstname, gender,username, password, user_type, street, barangay,city, age, email_address, contact, birthdate, security_question, answer,status, store_id)values('" + this.txtAccountID.Text + "','" + this.txtLastname.Text + "','" + this.txtFirstname.Text + "','" + this.txtGender.Text + "', '" + this.txtUsername.Text + "','" + this.txtPassword.Text + "', 'Supervisor', '" + this.txtStreet.Text + "', '" + this.txtBarangay.Text + "', '" + this.txtCity.Text + "','" + this.txtAge.Text + "', '" + this.txtEmail.Text + "','" + this.txtContact.Text + "','" + this.birthdate.Text + "', '" + cmbSQuest.Text + "', '" + txtAnswer.Text + "','" + Active + "', '"+txtstore_id.Text+"')";


                MySqlCommand cmd = new MySqlCommand(Query, Conn);
                MySqlDataReader myReader;


                try
                {
                  
                    myReader = cmd.ExecuteReader();

                    MessageBox.Show("You are signed up successfully in Fabula's Merchandise System.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    while (myReader.Read())
                    {

                       
                    }
                    Conn.Close();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                generator();


                UserDisplayName.displayName = txtUsername.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            var myForm = new frm_CreateNewAccount();
            myForm.Show();
            this.Hide();
        }

        public void generator()
        {
            NurseryVan_System.AutoGenerator.autoincrement("select max(login_id) from tbl_login ", txtAccountID);

        }

        private void frm_CreateNewAccount_Load(object sender, EventArgs e)
        {

            Comboboxofusertype();
          birthdate.Text= DateTime.Now.ToString("yyyy-MM-dd");
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
            generator();
            label2.Visible = false;
            label2.Hide();
            txtPassword.PasswordChar = '\0';
            //    signUpId = txtAccountID.Text;

            btnManageAccount.Focus();
            try
            {
                MySqlConnection Conn = ConString.Connection;
                MySqlCommand cmd = new MySqlCommand("Select * FROM tbl_login where user_type = '" + submanager + "';", Conn);

                MySqlDataReader myReader;

                myReader = cmd.ExecuteReader();

                while (myReader.Read())
                {
                    user_type = myReader.GetString("User_type");
                }

                Conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fabula's Merchandise System", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
            try
            {
                MySqlConnection Conn = ConString.Connection;

                MySqlCommand cmd = new MySqlCommand("Select * FROM tbl_login where user_type = '" + subAdmin + "';", Conn);

                MySqlDataReader myReader;

                myReader = cmd.ExecuteReader();

                while (myReader.Read())
                {
                    user_type1 = myReader.GetString("User_type");
                }

                Conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fabula's Merchandise System", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
            ComboboxofStoreSupervisor();
         
        }
        public long CalAge(System.DateTime StartDate, System.DateTime EndTime)
        {
            long age = 0;
            System.TimeSpan ts = new TimeSpan(EndTime.Ticks - StartDate.Ticks);
            age = (long)(ts.Days / 365);
            return age;
        }
        public void ComboboxofStoreSupervisor()
        {

          
            MySqlConnection Conn = ConString.Connection;
           //


            string Query = "Select store_name from tbl_store";
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
                    storename = myReader.GetString("store_name");

                 

                }
                Conn.Close();

                cbStore.AutoCompleteCustomSource = MyCollection;

             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error1");
            }
        }

        public void Comboboxofusertype()
        {


            //MySqlConnection Conn = ConString.Connection;
            ////


            //string Query = "Select user_type from tbl_login where user_type != 'Manager' and user_type != 'Admin' and user_type = 'Stockman' group by user_type";
            //MySqlCommand cmd = new MySqlCommand(Query, Conn);
            //MySqlDataReader myReader;

            //AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
            //try
            //{

            //    myReader = cmd.ExecuteReader();

            //    while (myReader.Read())
            //    {
            //        MyCollection.Add(myReader.GetString(0));

            //        cbUsertype.Items.Add(myReader[0]);
                    



            //    }
            //    Conn.Close();

            //    cbUsertype.AutoCompleteCustomSource = MyCollection;


            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Error1");
            //}
        }
        private void birthdate_ValueChanged(object sender, EventArgs e)
        {
            DateTime startdate = birthdate.Value;
            DateTime enddate = dateTimePicker2.Value;
            txtAge.Text = CalAge(startdate, enddate).ToString();
            lbl5.Text = "";
            lbl13.Text = "";


            DateTime date1 = dateTimePicker2.Value;
            DateTime date2 = birthdate.Value;

            TimeSpan difference = date2.Subtract(date1);





            if ((date2 > date1 && dateTimePicker2.Text != birthdate.Text) || int.Parse(txtAge.Text) <= 10 && dateTimePicker2.Text != birthdate.Text)
            {
                MessageBox.Show("The year of date doesn't look right. Be sure to use the actual date of birth.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblInvaliddateofbirth.Text = "Your age doesn't look right. Be sure to use your actual age of birth.";
                //  birthdate.Text = dateTimePicker2.Text;

            }
            else
            {
                lblInvaliddateofbirth.Text = "";
            }
            if (int.Parse(txtAge.Text) <= 17 && int.Parse(txtAge.Text) > 10)
            {
                lbl18.Show();
                return;
            }
            else
            {
                lbl18.Hide();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Text == "Male")
            {
                txtGender.Text = "Male";


            }

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Text == "Female")
            {
                txtGender.Text = "Female";

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

        private void txtAnswer_Leave(object sender, EventArgs e)
        {
            if (txtAnswer.Text.Length == 0)
            {
                txtAnswer.Text = "Answer";
                txtAnswer.ForeColor = SystemColors.GrayText;
            }
            if (txtAnswer.Text == "Answer" || txtAnswer.Text == "")
            {
                lblAnswer.Text = "You can't leave this empty.";
                return;
            }
        }

        private void txtAnswer_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtAnswer.Text.Equals(null) == true)
            {
                txtAnswer.Text = "Answer";
                txtAnswer.ForeColor = Color.Gray;
            }
            else if (txtAnswer.Text == "Answer")
            {
                txtAnswer.ForeColor = Color.Gray;
            }

            else
            {
                txtAnswer.ForeColor = Color.Black;
            }
            if (e.KeyCode == Keys.Back)
            {
                if (txtAnswer.Text.Length == 0)
                {


                    txtAnswer.Text = "Answer";

                    txtAnswer.ForeColor = Color.Gray;
                    Cursor.Current = Cursors.IBeam;


                }
            }
        }

        private void txtAnswer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtAnswer.Text == "Answer")
            {
                txtAnswer.Text = "";
            }
        }

        private void txtAnswer_Click(object sender, EventArgs e)
        {
            if (txtAnswer.Text == "Answer")
            {
                txtAnswer.Focus();
                txtAnswer.Select(0, 0);

            }
        }

        private void cmbSQuest_Leave(object sender, EventArgs e)
        {
            if (cmbSQuest.Text == "")
            {
                lblSQ.Text = "You can't leave this empty.";
                return;
            }
        }

        private void cmbSQuest_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSQuest.Text != "")
            {
                lblPleaseAnswer.Show();
                return;
            }

        }

        private void txtAnswer_TextChanged(object sender, EventArgs e)
        {
            lblPleaseAnswer.Hide();
            if (txtAnswer.Text != "")
            {
                lblPleaseAnswer.Hide();
            }

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

        private void frm_CreateNewAccount_FormClosing(object sender, FormClosingEventArgs e)
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

        private void btnHome_Click(object sender, EventArgs e)
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
                var pleaseWait = new frm_PleaseWait();
                pleaseWait.Show();
                Application.DoEvents();
                Cursor.Current = Cursors.WaitCursor;
                var myForm = new frm_AccountManager();
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
                var myForm = new frm_TransactionRecord();
                myForm.Show();
                pleaseWait.Hide();

                this.Hide();
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

        private void txtAge_Leave(object sender, EventArgs e)
        {

        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            var myForm = new frm_AccountManager();
            myForm.Show();
            this.Hide();


        }

        private void metroTile1_Click_1(object sender, EventArgs e)
        {

        }

        private void cbStore_SelectedIndexChanged(object sender, EventArgs e)
        {
           

                ///  metroGrid2.Columns[5].Visible = false;
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

            label9.Text = "";
            label9.Visible = true;

            if (cbUsertype.Text == "Supervisor")
            {


                Conn = ConString.Connection;
                Query = "SELECT * FROM tbl_login inner join tbl_store on tbl_login.store_id = tbl_store.store_id where tbl_login.user_type = 'Supervisor' and tbl_store.store_id = '" + txtstore_id.Text + "'";

                cmd = new MySqlCommand(Query, Conn);


                myReader = cmd.ExecuteReader();
                while (myReader.Read())
                {


                    label9.Text = "There is already Supervisor in the outlet: ." + cbStore.Text;
                }

                Conn.Close();

            }

        }

        private void btnBack_Click(object sender, EventArgs e)
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
    } 
}
