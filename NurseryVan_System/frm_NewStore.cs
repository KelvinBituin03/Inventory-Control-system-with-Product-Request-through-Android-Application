using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using NurseryVan_System.Database;

namespace NurseryVan_System
{
    public partial class frm_NewStore : Form
    {
        string getbranchid;
        string getbranchname;
        string getcperson;
        string getcontactno;
        string gettelephoneno;
        string getstreet;
        string getbarangay;
        string getcity;

        public frm_NewStore()
        {
            InitializeComponent();
        }

        private void frm_NewStore_Load(object sender, EventArgs e)
        {
            this.AcceptButton = btnAdd;
            DGVBranchInfo();
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            try
            {
                if (!dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].IsNewRow)
                {
                    foreach (DataGridViewCell cell1 in dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells)
                    {
                        metroTile1.BackColor = System.Drawing.ColorTranslator.FromHtml("#24262F");
                        metroTile1.Enabled = true;
                        if (cell1.Value == System.DBNull.Value)
                        {

                        }
                    }


                }
            }
            catch (NullReferenceException)
            {
                metroTile1.Enabled = false;
                metroTile1.BackColor = Color.DarkGray;
                txtCity.Enabled = false;
                txtBarangay.Enabled = false;
                txtStreet.Enabled = false;
                txtStore.Enabled = false;
                txtCPerson.Enabled = false;
                txtContact.Enabled = false;
                txtTelephone.Enabled = false;

            }
        }
        void DGVBranchInfo()
        {

            MySqlConnection Conn = ConString.Connection;

            MySqlCommand cmd = new MySqlCommand("SELECT tbl_store.store_name as 'Outlet Name',  tbl_login.username as 'Staff', tbl_login.contact as 'Contact No.', tbl_store.telephone as 'Telephone No.', tbl_store.street as 'Street', tbl_store.barangay as 'Barangay', tbl_store.city as 'City', tbl_store.store_id, tbl_store.status as 'Status' FROM tbl_store left join tbl_login on tbl_store.store_id = tbl_login.store_id where tbl_login.user_type = 'Supervisor' or tbl_store.status = 'New';", Conn);
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

                Conn.Close();




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error5");
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            MySqlConnection Conn = ConString.Connection;
            MySqlDataReader myReader;

            Cursor.Current = Cursors.WaitCursor;


            if(txtStore.Text == "" || txtBarangay.Text == "" || txtCity.Text == ""|| txtStreet.Text =="" ||txtTelephone.Text == "")
            {
                MessageBox.Show("Please enter require fields.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.None);

                return;
            }
            //if (txtContact.Text.Length > 11 && txtContact.Text.Length <= 10)
            //{
            //    lblphone.Hide();

            //}
            //else if (txtContact.Text.Contains("09") && txtContact.Text.Length == 11 || txtContact.Text.Contains("639") && txtContact.Text.Length == 12 || txtContact.Text.Contains("+639") && txtContact.Text.Length == 13)
            //{
            //    lblphone.Hide();
            //}
            //else
            //{
            //    //   MessageBox.Show("The phone number format is not recognized.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    lblphone.Show();
            //    return;
            //}
            //if (!txtContact.Text.Contains("09") && !txtContact.Text.Contains("639") && !txtContact.Text.Contains("+639"))
            //{
            //    MessageBox.Show("The phone number format is not recognized.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            //    lblphone.Show();
            //    return;
            //}

            //if (Phonevalidation.checkPhonenumber(txtContact.Text.ToString()))
            //{

            //    lblphone.Hide();
            //}
            //else
            //{
            //    MessageBox.Show("The phone number format is not recognized.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            //    lblphone.Show();
            //    return;
            //}
            if (TelephoneValidation.TelephoneNumber(txtTelephone.Text.ToString()))
            {

                lbltelephone.Hide();
            }
            else
            {
                lbltelephone.Show();
                return;
            }
          
            string Query = "insert into tbl_store (store_name,  telephone, street, barangay, city, status) values ('" + this.txtStore.Text + "',  '"+txtTelephone.Text+"', '"+txtStreet.Text+"', '"+txtBarangay.Text+"', '"+txtCity.Text+"', 'New')";
    
            MySqlCommand cmd = new MySqlCommand(Query, Conn);
            cmd.CommandTimeout = 50000;



      
            var dtt = new DataTable();
            var sda = new MySqlDataAdapter("select store_name from tbl_store where REPLACE(store_name, ' ', '') = REPLACE('"+txtStore.Text+"', ' ', '')", Conn);
            sda.Fill(dtt);
  


            if (dtt.Rows.Count >= 1 || dtt.Rows.Count == 1)
            {
                if(txtStore.Text.Contains(""))
                MessageBox.Show("The outlet: " + txtStore.Text + " already exists.", "Fabulas Merchandise", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


          
            try
            {


                myReader = cmd.ExecuteReader();
                while (myReader.Read())
                {



                }
            }
            catch (Exception ex1)
            {
                MessageBox.Show(ex1.Message);
            }



            MessageBox.Show("Outlet added successfully.", "Fabulas Merchandise", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
         
            Conn.Close();
        
            //Cursor.Current = Cursors.AppStarting;
            //var myForm = new frm_Inventory();
            //myForm.Show();
            DGVBranchInfo();
            btnAdd.Enabled = false;
            btnAdd.BackColor = Color.DarkGray;


        }

        private void metroTile2_Click(object sender, EventArgs e)
        {

            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            MySqlConnection Conn = ConString.Connection;

            MySqlCommand cmd = new MySqlCommand("Delete FROM tbl_inventory where store_id = '" + getbranchid + "';Delete FROM tbl_store where store_id = '" + getbranchid + "'", Conn);
            cmd.CommandTimeout = 50000;
            // Conn.Open();


            if (MessageBox.Show("Are you sure, you want to remove branch: " + txtStore.Text, "Fabulas Merchandise", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {

                try
                {

                    MySqlDataReader myReader;
                    myReader = cmd.ExecuteReader();
                    while (myReader.Read())
                    {

                    }
                    Conn.Close();
                    MessageBox.Show("Removed successfully.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                DGVBranchInfo();
            }
            try
            {
                if (!dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].IsNewRow)
                {
                    foreach (DataGridViewCell cell in dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells)
                    {
                        lblMatch1.Visible = false;
                        if (cell.Value == System.DBNull.Value)
                        {

                        }
                    }


                }
            }
            catch (NullReferenceException)
            {
                lblMatch1.Visible = true;
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
           
                txtStore.Text = row.Cells[0].Value.ToString();
                txtCPerson.Text = row.Cells[1].Value.ToString();
                txtContact.Text = row.Cells[2].Value.ToString();
                txtTelephone.Text = row.Cells[3].Value.ToString();
                txtBarangay.Text = row.Cells[5].Value.ToString();
                txtStreet.Text = row.Cells[4].Value.ToString();
                txtCity.Text = row.Cells[6].Value.ToString();
                getbranchid = row.Cells[7].Value.ToString();

                getbranchname = row.Cells[0].Value.ToString();
                getcperson = row.Cells[1].Value.ToString();
                getcontactno = row.Cells[2].Value.ToString();
                gettelephoneno = row.Cells[3].Value.ToString();
                getbarangay = row.Cells[5].Value.ToString();
                getstreet = row.Cells[4].Value.ToString();
                getcity = row.Cells[6].Value.ToString();
                btnSave1.Enabled = false;
                btnAdd.BackColor = Color.DarkGray;
                btnAdd.Enabled = false;
                btnSave1.BackColor = Color.DarkGray;
                metroTile1.Enabled = true;
                metroTile1.BackColor = System.Drawing.ColorTranslator.FromHtml("#24262F");


                try
                {
                    if (!dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].IsNewRow)
                    {
                        foreach (DataGridViewCell cell1 in dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells)
                        {
                           
                            if (cell1.Value == System.DBNull.Value)
                            {

                            }
                        }


                    }
                }
                catch (NullReferenceException)
                {
                    btnSave1.Enabled = false;
                    btnSave1.BackColor = Color.DarkGray;
                    return;

                }
            }
        }

        private void metroTile3_Click(object sender, EventArgs e)
        {
            txtCity.Text = "";
            txtBarangay.Text = "";
            txtStreet.Text = "";
            txtStore.Text = "";
            txtCPerson.Text = "";

            txtContact.Text = "";
            txtTelephone.Text = "";
            btnAdd.Enabled = true;
            btnAdd.BackColor = System.Drawing.ColorTranslator.FromHtml("#24262F");
            lbltelephone.Hide();
            lblphone.Hide();
            metroTile1.Enabled = false;

            metroTile1.BackColor = Color.DarkGray;
            txtCity.Enabled = true;
            txtBarangay.Enabled = true;
            txtStreet.Enabled = true;
            txtStore.Enabled = true;
            txtCPerson.Enabled = false;
        
            txtTelephone.Enabled = true;
        }

        private void btnSaveChange_Click(object sender, EventArgs e)
        {
            MySqlConnection Conn = ConString.Connection;
            string Query = "Update tbl_store set store_name = '" + txtStore.Text + "', contact_person = '" + txtCPerson.Text + "', contact_number = '" + txtContact.Text + "',  telephone = '" + txtTelephone.Text + "', street = '" + txtStreet.Text + "', barangay = '" + txtBarangay.Text + "', city = '" + txtCity.Text + "'  where store_id = '" + getbranchid + "'";
            MySqlCommand cmd = new MySqlCommand(Query, Conn);
            cmd.CommandTimeout = 50000;
            // Conn.Open();

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
                //   MessageBox.Show("The phone number format is not recognized.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            if (TelephoneValidation.TelephoneNumber(txtTelephone.Text.ToString()))
            {

                lbltelephone.Hide();
            }
            else
            {
                lbltelephone.Show();
                return;
            }
            if (MessageBox.Show("Do you want to save the changes you have made to the field(s)?", "Fabula's Merchandise System", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {

                try
                {

                    MySqlDataReader myReader;
                    myReader = cmd.ExecuteReader();
                    while (myReader.Read())
                    {

                    }
                    Conn.Close();
                    MessageBox.Show("Save changed successfully.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                DGVBranchInfo();
                btnSave1.Enabled = false;
                btnSave1.BackColor = Color.DarkGray;
            }
        }

        private void txtStore_TextChanged(object sender, EventArgs e)
        {
            btnSave1.Enabled = true;
            btnSave1.BackColor = System.Drawing.ColorTranslator.FromHtml("#24262F");

            if (txtStore.Text == getbranchname || txtStore.Text == "")
            {
                btnSave1.Enabled = false;
                btnSave1.BackColor = Color.DarkGray;

            }
            if (btnAdd.Enabled == true)
            {
                btnSave1.Enabled = false;
                btnSave1.BackColor = Color.DarkGray;
            }
            try
            {
                if (!dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].IsNewRow)
                {
                    foreach (DataGridViewCell cell1 in dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells)
                    {
                       
                        if (cell1.Value == System.DBNull.Value)
                        {

                        }
                    }


                }
            }
            catch (NullReferenceException)
            {
                btnSave1.Enabled = false;
                btnSave1.BackColor = Color.DarkGray;
              

            }
            if (txtStore.Text.Contains(@"\"))
            {
                return;



            }
            MySqlConnection Conn = ConString.Connection;
          
            var dtt = new DataTable();
            var sda = new MySqlDataAdapter("select store_name from tbl_store where REPLACE(store_name, ' ', '') = REPLACE('" + txtStore.Text + "', ' ', '')", Conn);
            sda.Fill(dtt);
            Conn.Close();


            if (dtt.Rows.Count >= 1 || dtt.Rows.Count == 1)
            {
                btnSave1.Enabled = false;
                btnSave1.BackColor = Color.DarkGray;
                //   MessageBox.Show("The " + txtProductName.Text + " already added in product list.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

        }

        private void txtStreet_TextChanged(object sender, EventArgs e)
        {
            btnSave1.Enabled = true;
            btnSave1.BackColor = System.Drawing.ColorTranslator.FromHtml("#24262F");

            if (txtStreet.Text == getstreet || txtStreet.Text == "")
            {
                btnSave1.Enabled = false;
                btnSave1.BackColor = Color.DarkGray;

            }
            if (btnAdd.Enabled == true)
            {
                btnSave1.Enabled = false;
                btnSave1.BackColor = Color.DarkGray;
            }
            try
            {
                if (!dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].IsNewRow)
                {
                    foreach (DataGridViewCell cell1 in dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells)
                    {
                     
                        if (cell1.Value == System.DBNull.Value)
                        {

                        }
                    }


                }
            }
            catch (NullReferenceException)
            {
                btnSave1.Enabled = false;
                btnSave1.BackColor = Color.DarkGray;


            }
        }

        private void txtBarangay_TextChanged(object sender, EventArgs e)
        {
            btnSave1.Enabled = true;
            btnSave1.BackColor = System.Drawing.ColorTranslator.FromHtml("#24262F");

            if (txtBarangay.Text == getbarangay || txtBarangay.Text == "")
            {
                btnSave1.Enabled = false;
                btnSave1.BackColor = Color.DarkGray;

            }
            if (btnAdd.Enabled == true)
            {
                btnSave1.Enabled = false;
                btnSave1.BackColor = Color.DarkGray;
            }
            try
            {
                if (!dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].IsNewRow)
                {
                    foreach (DataGridViewCell cell1 in dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells)
                    {
                        
                        if (cell1.Value == System.DBNull.Value)
                        {

                        }
                    }


                }
            }
            catch (NullReferenceException)
            {
                btnSave1.Enabled = false;
                btnSave1.BackColor = Color.DarkGray;


            }
        }

        private void txtCity_TextChanged(object sender, EventArgs e)
        {
            btnSave1.Enabled = true;
            btnSave1.BackColor = System.Drawing.ColorTranslator.FromHtml("#24262F");

            if (txtCity.Text == getcity || txtCity.Text == "")
            {
                btnSave1.Enabled = false;
                btnSave1.BackColor = Color.DarkGray;

            }
            if (btnAdd.Enabled == true)
            {
                btnSave1.Enabled = false;
                btnSave1.BackColor = Color.DarkGray;
            }
            try
            {
                if (!dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].IsNewRow)
                {
                    foreach (DataGridViewCell cell1 in dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells)
                    {
                       
                        if (cell1.Value == System.DBNull.Value)
                        {

                        }
                    }


                }
            }
            catch (NullReferenceException)
            {
                btnSave1.Enabled = false;
                btnSave1.BackColor = Color.DarkGray;


            }
        }

        private void txtCPerson_TextChanged(object sender, EventArgs e)
        {
            btnSave1.Enabled = true;
            btnSave1.BackColor = System.Drawing.ColorTranslator.FromHtml("#24262F");

            if (txtCPerson.Text == getcperson || txtCPerson.Text == "")
            {
                btnSave1.Enabled = false;
                btnSave1.BackColor = Color.DarkGray;

            }
            if (btnAdd.Enabled == true)
            {
                btnSave1.Enabled = false;
                btnSave1.BackColor = Color.DarkGray;
            }
            try
            {
                if (!dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].IsNewRow)
                {
                    foreach (DataGridViewCell cell1 in dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells)
                    {
                     
                        if (cell1.Value == System.DBNull.Value)
                        {

                        }
                    }


                }
            }
            catch (NullReferenceException)
            {
                btnSave1.Enabled = false;
                btnSave1.BackColor = Color.DarkGray;


            }
        }

        private void txtContactNumber_TextChanged(object sender, EventArgs e)
        {
            btnSave1.Enabled = true;
            btnSave1.BackColor = System.Drawing.ColorTranslator.FromHtml("#24262F");

            if (txtContact.Text == getcontactno || txtContact.Text == "")
            {
                btnSave1.Enabled = false;
                btnSave1.BackColor = Color.DarkGray;

            }
            if (btnAdd.Enabled == true)
            {
                btnSave1.Enabled = false;
                btnSave1.BackColor = Color.DarkGray;
            }
            try
            {
                if (!dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].IsNewRow)
                {
                    foreach (DataGridViewCell cell1 in dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells)
                    {
                        
                        if (cell1.Value == System.DBNull.Value)
                        {

                        }
                    }


                }
            }
            catch (NullReferenceException)
            {
                btnSave1.Enabled = false;
                btnSave1.BackColor = Color.DarkGray;


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
            if (txtContact.Text.Contains("09"))
            {
                txtContact.MaxLength = 11;
            }
            else
            {
                txtContact.MaxLength = 13;
            }
        }

        private void txtTelephoneNumber_TextChanged(object sender, EventArgs e)
        {
            btnSave1.Enabled = true;
            btnSave1.BackColor = System.Drawing.ColorTranslator.FromHtml("#24262F");

            if (txtTelephone.Text == gettelephoneno || txtTelephone.Text == "")
            {
                btnSave1.Enabled = false;
                btnSave1.BackColor = Color.DarkGray;

            }
            if (btnAdd.Enabled == true)
            {
                btnSave1.Enabled = false;
                btnSave1.BackColor = Color.DarkGray;
            }
            try
            {
                if (!dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].IsNewRow)
                {
                    foreach (DataGridViewCell cell1 in dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells)
                    {
                        
                        if (cell1.Value == System.DBNull.Value)
                        {

                        }
                    }


                }
            }
            catch (NullReferenceException)
            {
                btnSave1.Enabled = false;
                btnSave1.BackColor = Color.DarkGray;


            }
        }

        private void txtContact_KeyDown(object sender, KeyEventArgs e)
        {

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

        private void txtTelephoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
       (e.KeyChar != '+') && (e.KeyChar != '-') && (e.KeyChar != '(') && (e.KeyChar != ')'))
            {
                e.Handled = true;
            }
        }

        private void txtTelephoneNumber_Leave(object sender, EventArgs e)
        {
            if (TelephoneValidation.TelephoneNumber(txtTelephone.Text.ToString()))
            {

                lbltelephone.Hide();
            }
            else
            {
                lbltelephone.Show();
                return;
            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    } 
}
