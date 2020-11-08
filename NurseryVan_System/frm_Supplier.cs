using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DGVPrinterHelper;
using MySql.Data.MySqlClient;
using NurseryVan_System.Database;

namespace NurseryVan_System
{
    public partial class frm_Supplier : Form
    {
        string suppliername;
        string statusnew;
        string street;
        string barangay;
        string city;
        string contact;
        string email;
        decimal mPrice;
        int suppID, mQTY;
        string mCritical;
        int mStock, mQTYcritical;
        string mSupplierID, mProductID, mPO, mProduct, mCompany, ok , cancel;
        string suppStreet, suppBarangay, suppCity, suppTel, suppEmail, suppMobile, suppCompany, mStreet, mBarangay, mCity, mPhone, mContact, mEmail;
        int po;
        int productID;
        decimal totaldue;
        int productid;
        string orderstatusss;
        public static int qtyretri;
        public static string statusss;
        public static string manager;
        public static int idOrder;
        public static int orderid;
        public static int subOrderID;
        public static int receivedzero;

        string P_Productid;

        string productname;
        string date_expected;
        string telephone;
        string date_ordered;
        string date_expect;
        string getsupplier_id;

        string p_id, p_supplierid, p_quantity;
        

        public frm_Supplier()
        {
            InitializeComponent();
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;

        }

        private void lblMatch_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
        public void generator()
        {
            NurseryVan_System.AutoGenerator.autoincrement("select max(supplier_id) from tbl_supplierinfo ", txtSupplierID);
        }
        public void generator1()
        {
            NurseryVan_System.AutoGenerator.autoincrement("select max(order_id) from tbl_order ", txtOrderID);
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

        System.Windows.Forms.Timer time1 = null;
        private void StartTimer()
        {
            time1 = new System.Windows.Forms.Timer();
            time1.Interval = 1000;
            time1.Tick += new EventHandler(t_Tick);
            time1.Enabled = true;
        }

        void t_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString();
        }
        private void frm_Supplier_Load(object sender, EventArgs e)
        {
            StartTimer();
            generator();
            generator1();
            int num;
            Random rand = new Random();
            num = rand.Next(100, 999);
            mPO = Convert.ToString(num);
            NotificationofCriticalLevel_Warehouse();
            cbCritical.Visible = false;
            PictureBox pic = new PictureBox();
            pic.Width = 16;
            pic.Height = 16;
            pic.Left = 200;
            pic.BackgroundImage = NurseryVan_System.Properties.Resources.search2;
            txtSearch2.Controls.Add(pic);

             pic = new PictureBox();
            pic.Width = 16;
            pic.Height = 16;
            pic.Left = 200;
            pic.BackgroundImage = NurseryVan_System.Properties.Resources.search2;
            txtSearch1.Controls.Add(pic);

             pic = new PictureBox();
            pic.Width = 16;
            pic.Height = 16;
            pic.Left = 200;
            pic.BackgroundImage = NurseryVan_System.Properties.Resources.search2;
            txtSearch.Controls.Add(pic);


            subSearchingNew();
        
            DGVSupplier();
         
            ListoFCritical();
            Supplier();
            productDeliver();
            btnSupplier.Focus();
            ContactPerson();
            ByNotifyWarehouse();
            PendingOrdered();
            Ordered();
            OverdueOrdered();
            DGVOrder();
            metroGrid2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridView1.Columns[0].Visible = false;
            metroGrid1.Columns[2].Visible = false;
            metroGrid1.Columns[0].Visible = false;
            //  metroGrid2.Columns[3].Visible = false;
            if (int.Parse(txtSupplierID.Text) >= 2)
            {
                txtSupplierName.Enabled = true;
                txtStreet.Enabled = true;
                txtBarangay.Enabled = true;
                txtCity.Enabled = true;
                txtContact.Enabled = true;
                txtEmail.Enabled = true;
            }

            //try
            //{
            //    if (!metroGrid1.Rows[metroGrid1.CurrentCell.RowIndex].IsNewRow)
            //    {
            //        foreach (DataGridViewCell cell1 in metroGrid1.Rows[metroGrid1.CurrentCell.RowIndex].Cells)
            //        {
            //            btnDelete.Enabled = true;
            //            btnDelete.BackColor = Color.Red;

            //            if (cell1.Value == System.DBNull.Value)
            //            {

            //            }
            //        }

            //    }
            //}
            //catch (NullReferenceException)
            //{
            //    btnDelete.Enabled = false;
            //    btnDelete.BackColor = Color.DarkGray;
            //    return;
            //}

            try
            {
                if (!metroGrid3.Rows[metroGrid3.CurrentCell.RowIndex].IsNewRow)
                {
                    foreach (DataGridViewCell cell in metroGrid3.Rows[metroGrid3.CurrentCell.RowIndex].Cells)
                    {
                        btnPrintPurchase.Enabled = true;
                        btnPrintPurchase.BackColor = System.Drawing.ColorTranslator.FromHtml("#24262F");

                        if (cell.Value == System.DBNull.Value)
                        {

                        }
                    }


                }
            }
            catch (Exception)
            {
                metroGrid3.Enabled = false;

                return;
            }
            btnSave.Enabled = false;
            btnSave.BackColor = Color.DarkGray;


        }

        public void Supplier()
        {
            MySqlConnection Conn = ConString.Connection;


            string Query = "Select company, supplier_id from tbl_supplierinfo";
            MySqlCommand cmd = new MySqlCommand(Query, Conn);
            MySqlDataReader myReader;

            AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
            try
            {

                myReader = cmd.ExecuteReader();

                while (myReader.Read())
                {
                    MyCollection.Add(myReader.GetString(0));
                    cbSupplier.Items.Add(myReader[0]);
                    suppID = myReader.GetInt32("supplier_id");
                }

                cbSupplier.AutoCompleteCustomSource = MyCollection;
                Conn.Close();
            }
         
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void ListoFCritical()
        {
            MySqlConnection Conn = ConString.Connection;


            string Query = "Select product_name from tbl_product where critical >= stock and stock !=0";
            MySqlCommand cmd = new MySqlCommand(Query, Conn);
            MySqlDataReader myReader;

            AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
            try
            {

                myReader = cmd.ExecuteReader();

                while (myReader.Read())
                {
                    MyCollection.Add(myReader.GetString(0));
                    cbCritical.Items.Add(myReader[0]);

                }

                cbCritical.AutoCompleteCustomSource = MyCollection;
                Conn.Close();
            }
           
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void productDeliver()
        {
            MySqlConnection Conn = ConString.Connection;

            string Query = "select product_name, product_id from tbl_product";
            //  string Query = "select product_name, product_id from tbl_product inner join tbl_supplierinfo on tbl_product.supplier_name = tbl_supplierinfo.company where tbl_product.product_name like '" + cbProductName.Text + "%';";
            MySqlCommand cmd = new MySqlCommand(Query, Conn);
            MySqlDataReader myReader;

            AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
            try
            {

                myReader = cmd.ExecuteReader();

                while (myReader.Read())
                {
                    MyCollection.Add(myReader.GetString(0));
                    
                    productID = myReader.GetInt32("product_id");
                }

                cbProductName.AutoCompleteCustomSource = MyCollection;
                Conn.Close();
            }
           
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        public void PendingOrdered()
        {
            MySqlConnection Conn = ConString.Connection;


            string Query = "Update tbl_order set status = 'Pending Ordered' where date_ordered < date_expected and DATE(NOW()) < date_expected and status != 'Backorder' and status != 'Cancelled order'";
          
            //  string Query = "select product_name, product_id from tbl_product inner join tbl_supplierinfo on tbl_product.supplier_name = tbl_supplierinfo.company where tbl_product.product_name like '" + cbProductName.Text + "%';";
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
                MessageBox.Show(ex.Message);
            }
        }
        public void OverdueOrdered()
        {
            MySqlConnection Conn = ConString.Connection;


            string Query = "Update tbl_order set status = 'Overdue Ordered' where date_ordered < date_expected and DATE(NOW()) > date_expected and status != 'Received' and quantity_receive = 0";
            //  string Query = "select product_name, product_id from tbl_product inner join tbl_supplierinfo on tbl_product.supplier_name = tbl_supplierinfo.company where tbl_product.product_name like '" + cbProductName.Text + "%';";
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
                MessageBox.Show(ex.Message);
            }
        }
        public void Ordered()
        {
            MySqlConnection Conn = ConString.Connection;


            string Query = "Update tbl_order set status = 'Ordered' where DATE(NOW()) = date_expected and status != 'Received' and quantity_receive = 0 and status != 'Backorder'  and status != 'Cancelled Order'";
            //  string Query = "select product_name, product_id from tbl_product inner join tbl_supplierinfo on tbl_product.supplier_name = tbl_supplierinfo.company where tbl_product.product_name like '" + cbProductName.Text + "%';";
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
                MessageBox.Show(ex.Message);
            }
        }

        public void ContactPerson()
        {
            MySqlConnection Conn = ConString.Connection;


            string Query = "Select contact_person from tbl_supplierinfo";
            MySqlCommand cmd = new MySqlCommand(Query, Conn);
            MySqlDataReader myReader;

            AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
            try
            {

                myReader = cmd.ExecuteReader();

                while (myReader.Read())
                {
                    MyCollection.Add(myReader.GetString(0));
                    cbContactPerson.Items.Add(myReader[0]);

                }

                cbContactPerson.AutoCompleteCustomSource = MyCollection;
                Conn.Close();

            }
          
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void DGVSupplier()
        {
            generator();
            MySqlConnection Conn = ConString.Connection;
            MySqlCommand cmd = new MySqlCommand("SELECT supplier_id as 'Supplier ID',  company as 'Supplier Name', contact_person as 'Contact Person', street as 'Street #', barangay as 'Barangay', city as 'City', contact as 'Cellphone #', telephone as 'Telephone #', email as 'Email' FROM tbl_supplierinfo;", Conn);
            cmd.CommandTimeout = 0;


            try
            {

                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmd;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bSource = new BindingSource();
                bSource.DataSource = dbdataset;
                metroGrid1.DataSource = bSource;
                sda.Update(dbdataset);

                MySqlDataReader myReader;
                myReader = cmd.ExecuteReader();


                metroGrid1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                metroGrid1.Columns[2].Visible = false;
                metroGrid1.Columns[0].Visible = false;

                Conn.Close();
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            Conn.Close();

            metroGrid1.Columns[2].Visible = false;
            metroGrid1.Columns[0].Visible = false;
        }
        void DGVOrder()
        {
            generator1();
            MySqlConnection Conn = ConString.Connection;
            MySqlCommand cmd = new MySqlCommand("SELECT tbl_order.order_id as 'Order ID', tbl_product.product_name as 'Product', tbl_order.status as 'Status', sum(tbl_order.total_due) as 'Total Due', sum(tbl_order.quantity) as 'Ordered QTY', tbl_order.quantity_receive as 'QTY Received', tbl_order.damage_product as 'Backorder QTY', tbl_supplierinfo.company as 'Supplier Name' ,tbl_order.date_ordered as 'Date Ordered', tbl_order.date_expected as 'Delivery Date', tbl_product.product_id as 'Product ID', tbl_product.stock as 'Stock', tbl_order.supplier_id as 'Supplier ID', timestampdiff(day, date(now()), date_expected) as 'Days Left'  FROM tbl_order inner join tbl_product on tbl_order.product_id = tbl_product.product_id inner join tbl_supplierinfo on tbl_order.supplier_id = tbl_supplierinfo.supplier_id  where " +
                "tbl_order.status = 'Ordered' or tbl_order.total_due != 0.00 and tbl_order.status = 'Overdue Ordered' or tbl_order.total_due != 0.00 and tbl_order.status = 'Pending Ordered' or tbl_order.total_due != 0.00 and tbl_order.status = 'Backorder'  or tbl_order.total_due != 0.00 and tbl_order.status = 'Received' " +
                "group by tbl_order.product_id, tbl_order.supplier_id, tbl_order.status, tbl_order.date_expected, tbl_order.date_ordered order by tbl_order.order_id desc;", Conn);
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

                MySqlDataReader myReader;
                myReader = cmd.ExecuteReader();


                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

                Conn.Close();

                dataGridView1.Columns[3].Visible = true;
                dataGridView1.Columns[4].Visible = true;
                dataGridView1.Columns[5].Visible = true;
                dataGridView1.Columns[6].Visible = true;
                dataGridView1.Columns[7].Visible = true;
                dataGridView1.Columns[8].Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            Conn.Close();

            changeRowColor1();
        
            dataGridView1.Columns[10].Visible = false;
            dataGridView1.Columns[11].Visible = false;
            dataGridView1.Columns[12].Visible = false;
        }
        private void metroGrid1_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewCell cell = null;
            foreach (DataGridViewCell selectedCell in metroGrid1.SelectedCells)
            {
                cell = selectedCell;
                break;
            }

            if (cell != null)
            {



                DataGridViewRow row = cell.OwningRow;
                txtSupplierID.Text = row.Cells[0].Value.ToString();
                txtSupplierName.Text = row.Cells[1].Value.ToString();
                txtContactPerson.Text = row.Cells[2].Value.ToString();
                txtStreet.Text = row.Cells[3].Value.ToString();
                txtBarangay.Text = row.Cells[4].Value.ToString();
                txtCity.Text = row.Cells[5].Value.ToString();
                txtContact.Text = row.Cells[6].Value.ToString();
                txtTelephone.Text = row.Cells[7].Value.ToString();
                txtEmail.Text = row.Cells[8].Value.ToString();

                suppliername = row.Cells[1].Value.ToString();
                street = row.Cells[3].Value.ToString();
                barangay = row.Cells[4].Value.ToString();
                city = row.Cells[5].Value.ToString();
                contact = row.Cells[6].Value.ToString();
                telephone = row.Cells[7].Value.ToString();
                email = row.Cells[8].Value.ToString();
                txtStreet.ForeColor = Color.Black;
                txtCity.ForeColor = Color.Black;
                txtBarangay.ForeColor = Color.Black;
                txtSupplierName.Enabled = true;
                txtStreet.Enabled = true;
                txtBarangay.Enabled = true;
                txtCity.Enabled = true;
                txtContact.Enabled = true;
                txtEmail.Enabled = true;

                btnSave.Enabled = false;
                btnSave.BackColor = Color.DarkGray;

                txtContactPerson.ReadOnly = true;
                txtSupplierName.ReadOnly = true;
                txtSupplierName.BackColor = Color.PeachPuff;
                txtContactPerson.BackColor = Color.PeachPuff;
                btnAdd.Enabled = false;
                btnAdd.BackColor = Color.DarkGray;

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {


                generator();
                Cursor.Current = Cursors.WaitCursor;

                MySqlConnection Conn = ConString.Connection;

              
                var dtt = new DataTable();
                var sda = new MySqlDataAdapter("select company from tbl_supplierinfo where company = '" + txtSupplierName.Text + "'", Conn);
                sda.Fill(dtt);
                Conn.Close();


                if (dtt.Rows.Count == 1 || dtt.Rows.Count >= 1)
                {
                    MessageBox.Show("The supplier name: " + txtSupplierName.Text + " already exists.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                MySqlDataReader myReader;
                

                Cursor.Current = Cursors.WaitCursor;

                string Query = "insert into tbl_supplierinfo (supplier_id,  company, street, barangay, city, contact, email, telephone) values ('" + this.txtSupplierID.Text + "',  '" + this.txtSupplierName.Text + "', '" + this.txtStreet.Text + "', '" + this.txtBarangay.Text + "', '" + this.txtCity.Text + "', '" + this.txtContact.Text + "', '" + this.txtEmail.Text + "', '" + this.txtTelephone.Text + "')";
            
                MySqlCommand cmd = new MySqlCommand(Query, Conn);
                cmd.CommandTimeout = 50000;

                if (txtSupplierName.Text == "" || txtStreet.Text == "" || txtBarangay.Text == "" || txtCity.Text == "" || txtContact.Text == "" || txtEmail.Text == "" || txtStreet.Text == "Street #" || txtBarangay.Text == "Barangay" || txtCity.Text == "City")
                {
                    MessageBox.Show("Please enter require fields.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.None);
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
                if (TelephoneValidation.TelephoneNumber(txtTelephone.Text.ToString()))
                {

                    lbltelephone.Hide();
                }
                else
                {
                    lbltelephone.Show();
                    return;
                }

                try
                {

                    try
                    {
                        Conn = ConString.Connection;

                        myReader = cmd.ExecuteReader();
                        while (myReader.Read())
                        {

                        }
                    }
                    catch (Exception ex1)
                    {
                        MessageBox.Show(ex1.Message);
                    }



                    MessageBox.Show("Supplier: " + txtContactPerson.Text + " added successfully.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    Conn.Close();




                }
                catch (FormatException)
                {

                }




            }

            catch (Exception)
            {

            }
            DGVSupplier();
            metroGrid1.FirstDisplayedScrollingRowIndex = metroGrid1.RowCount - 1;
            txtContactPerson.ReadOnly = true;
            txtSupplierName.ReadOnly = true;
            txtSupplierName.BackColor = Color.PeachPuff;
            txtContactPerson.BackColor = Color.PeachPuff;


            try
            {
                if (!metroGrid1.Rows[metroGrid1.CurrentCell.RowIndex].IsNewRow)
                {
                    foreach (DataGridViewCell cell in metroGrid1.Rows[metroGrid1.CurrentCell.RowIndex].Cells)
                    {
                        btnDelete.Enabled = true;
                        btnDelete.BackColor = Color.Red;

                        if (cell.Value == System.DBNull.Value)
                        {

                        }
                    }

                }
            }
            catch (NullReferenceException)
            {
                btnDelete.Enabled = false;
                btnDelete.BackColor = Color.DarkGray;
                return;
            }
            btnAdd.Enabled = false;
            btnAdd.BackColor = Color.DarkGray;
        }
        public void subSearchingNew()
        {
            MySqlConnection Conn = ConString.Connection;

            string Query = "Select * from tbl_product where status_new = 'New Product'";
            MySqlCommand cmd = new MySqlCommand(Query, Conn);
            MySqlDataReader myReader;

            try
            {

                myReader = cmd.ExecuteReader();

                while (myReader.Read())
                {


                    statusnew = myReader.GetString("status_new");
                 





                }

                Conn.Close();
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error1");
            }

        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (!frm_Inventory.datagrid.Rows[frm_Inventory.datagrid.CurrentCell.RowIndex].IsNewRow)
            //    {
            //        foreach (DataGridViewCell cell in frm_Inventory.datagrid.Rows[frm_Inventory.datagrid.CurrentCell.RowIndex].Cells)
            //        {

            //            if (cell.Value == System.DBNull.Value)
            //            {


            //            }
            //        }


            //    }
            //}
            //catch (NullReferenceException)
            //{

            //    MessageBox.Show("Add new product(s) first from inventory before you add new supplier information.", "Nursery Van", MessageBoxButtons.OK, MessageBoxIcon.None);

            //    return;
            //}

            if (statusnew == "New Product")
            {


                generator();
                txtContactPerson.Text = "";
                txtTelephone.Text = "";
                txtSupplierName.Text = "";
                txtStreet.Text = "Street #";
                txtStreet.ForeColor = Color.Gray;
                txtBarangay.Text = "Barangay";
                txtBarangay.ForeColor = Color.Gray;
                txtCity.Text = "City";
                txtCity.ForeColor = Color.Gray;
                txtContact.Text = "";
                txtEmail.Text = "";
                txtSupplierName.ReadOnly = false;
                txtSupplierName.Focus();

                txtContactPerson.ReadOnly = false;

                btnSave.Enabled = false;
                btnDelete.Enabled = false;
                btnDelete.BackColor = Color.DarkGray;
                btnSave.BackColor = Color.DarkGray;
                txtSupplierName.BackColor = Color.SeaShell;
                txtContactPerson.BackColor = Color.SeaShell;
                btnAdd.Enabled = true;
                btnAdd.BackColor = System.Drawing.ColorTranslator.FromHtml("#24262F");
                txtSupplierName.Enabled = true;
                txtStreet.Enabled = true;
                txtBarangay.Enabled = true;
                txtCity.Enabled = true;
                txtContact.Enabled = true;
                txtEmail.Enabled = true;
            }
            else
            {
                MessageBox.Show("Add new product(s) first from inventory before you add new supplier information.", "Nursery Van", MessageBoxButtons.OK, MessageBoxIcon.None);
            }


        }

        private void txtSupplierName_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            btnSave.BackColor = Color.DarkGray;
            if (txtContactPerson.Text.Length <= 0) return;
            string s = txtContactPerson.Text.Substring(0, 1);

            if (s != s.ToUpper())
            {
                int curSelStart = txtContactPerson.SelectionStart;
                int curSelLength = txtContactPerson.SelectionLength;
                txtContactPerson.SelectionStart = 0;
                txtContactPerson.SelectionLength = 1;
                txtContactPerson.SelectedText = s.ToUpper();
                txtContactPerson.SelectionStart = curSelStart;
                txtContactPerson.SelectionLength = curSelLength;
            }
        }



        private void txtCompany_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            btnSave.BackColor = Color.DarkGray;

            if (txtSupplierName.Text.Length <= 0) return;
            string s = txtSupplierName.Text.Substring(0, 1);
            if (s != s.ToUpper())
            {
                int curSelStart = txtSupplierName.SelectionStart;
                int curSelLength = txtSupplierName.SelectionLength;
                txtSupplierName.SelectionStart = 0;
                txtSupplierName.SelectionLength = 1;
                txtSupplierName.SelectedText = s.ToUpper();
                txtSupplierName.SelectionStart = curSelStart;
                txtSupplierName.SelectionLength = curSelLength;
            }
        }

        private void txtStreet_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;

            btnSave.BackColor = System.Drawing.ColorTranslator.FromHtml("#24262F");
            if (btnAdd.Enabled == true || txtStreet.Text == "Street #")
            {
                btnSave.Enabled = false;
                btnSave.BackColor = Color.DarkGray;
            }

            if (txtStreet.Text == street)
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
            if (btnAdd.Enabled == true || txtBarangay.Text == "Barangay")
            {
                btnSave.Enabled = false;
                btnSave.BackColor = Color.DarkGray;
            }
            if (txtBarangay.Text == barangay)
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
            if (btnAdd.Enabled == true || txtCity.Text == "City")
            {
                btnSave.Enabled = false;
                btnSave.BackColor = Color.DarkGray;
            }
            if (txtCity.Text == city)
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (!metroGrid1.Rows[metroGrid1.CurrentCell.RowIndex].IsNewRow)
                {
                    foreach (DataGridViewCell cell in metroGrid1.Rows[metroGrid1.CurrentCell.RowIndex].Cells)
                    {
                        btnDelete.Enabled = true;
                        btnDelete.BackColor = Color.Red;

                        if (cell.Value == System.DBNull.Value)
                        {

                        }
                    }

                }
            }
            catch (NullReferenceException)
            {
                btnDelete.Enabled = false;
                btnDelete.BackColor = Color.DarkGray;
                return;
            }
          MySqlConnection  Conn = ConString.Connection;
            string empty = "";
            MySqlCommand cmd = new MySqlCommand("Delete FROM tbl_supplierinfo where supplier_id = '" + txtSupplierID.Text + "';Delete FROM tbl_order where supplier_id = '" + txtSupplierID.Text + "'", Conn);
            cmd.CommandTimeout = 50000;
           

            if (MessageBox.Show("Are you sure, you want to delete supplier: " + txtContactPerson.Text, "Fabula's Merchandise System", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {

                try
                {

                    MySqlDataReader myReader;
                    myReader = cmd.ExecuteReader();
                    while (myReader.Read())
                    {

                    }
                    Conn.Close();
                    MessageBox.Show("Deleted successfully.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                DGVSupplier();

            }

            try
            {
                if (!metroGrid1.Rows[metroGrid1.CurrentCell.RowIndex].IsNewRow)
                {
                    foreach (DataGridViewCell cell in metroGrid1.Rows[metroGrid1.CurrentCell.RowIndex].Cells)
                    {
                        btnDelete.Enabled = true;
                        btnDelete.BackColor = Color.Red;
                        txtSupplierName.Enabled = true;
                        txtStreet.Enabled = true;
                        txtBarangay.Enabled = true;
                        txtCity.Enabled = true;
                        txtContact.Enabled = true;
                        txtEmail.Enabled = true;
                        if (cell.Value == System.DBNull.Value)
                        {

                        }
                    }

                }
            }
            catch (NullReferenceException)
            {
                txtSupplierName.Enabled = false;
                txtStreet.Enabled = false;
                txtBarangay.Enabled = false;
                txtCity.Enabled = false;
                txtContact.Enabled = false;
                txtEmail.Enabled = false;
                txtContactPerson.Text = "";

                txtSupplierName.Text = "";
                txtStreet.Text = "";
                txtBarangay.Text = "";
                txtCity.Text = "";

                txtContact.Text = "";
                txtEmail.Text = "";
                btnDelete.Enabled = false;
                btnDelete.BackColor = Color.DarkGray;
                btnSave.Enabled = false;
                btnSave.BackColor = Color.DarkGray;
                return;
            }

            if (int.Parse(txtSupplierID.Text) >= 2)
            {
                txtSupplierName.Enabled = true;
                txtStreet.Enabled = true;
                txtBarangay.Enabled = true;
                txtCity.Enabled = true;
                txtContact.Enabled = true;
                txtEmail.Enabled = true;
            }
            else
            {

                btnSave.Enabled = false;
                btnSave.BackColor = Color.DarkGray;
            }
        }

        private void txtContact_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            btnSave.BackColor = System.Drawing.ColorTranslator.FromHtml("#24262F");
            if (btnAdd.Enabled == true)
            {
                btnSave.Enabled = false;
                btnSave.BackColor = Color.DarkGray;
            }
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
            if (txtContact.Text.Contains("09"))
            {
                txtContact.MaxLength = 11;
            }
            else
            {
                txtContact.MaxLength = 13;
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

        private void txtContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
           (e.KeyChar != '+'))
            {
                e.Handled = true;
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            btnSave.BackColor = System.Drawing.ColorTranslator.FromHtml("#24262F");
            if (btnAdd.Enabled == true)
            {
                btnSave.Enabled = false;
                btnSave.BackColor = Color.DarkGray;
            }
            if (txtEmail.Text == email)
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            MySqlConnection Conn = ConString.Connection;

            string Query = "UPDATE tbl_supplierinfo SET street = '" + this.txtStreet.Text + "', barangay = '" + this.txtBarangay.Text + "',  city = '" + this.txtCity.Text + "',  email = '" + this.txtEmail.Text + "', telephone = '" + this.txtTelephone.Text + "'  where supplier_id = '" + this.txtSupplierID.Text + "'";
         
            MySqlCommand cmd = new MySqlCommand(Query, Conn);
            cmd.CommandTimeout = 50000;
            MySqlDataReader myReader;
            if ( txtSupplierName.Text == "" || txtStreet.Text == "" || txtBarangay.Text == "" || txtCity.Text == "" || txtContact.Text == "" || txtEmail.Text == "" || txtTelephone.Text == "")
            {
                MessageBox.Show("Please enter require fields.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.None);
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
                //  MessageBox.Show("The phone number format is not recognized.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Warning);

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
            if (TelephoneValidation.TelephoneNumber(txtTelephone.Text.ToString()))
            {

                lbltelephone.Hide();
            }
            else
            {
                lbltelephone.Show();
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
                Conn.Close();

                MessageBox.Show("Changes saved successfully!", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);


                DGVSupplier();


            }
            try
            {
                if (!metroGrid1.Rows[metroGrid1.CurrentCell.RowIndex].IsNewRow)
                {
                    foreach (DataGridViewCell cell in metroGrid1.Rows[metroGrid1.CurrentCell.RowIndex].Cells)
                    {
                        btnDelete.Enabled = true;
                        btnDelete.BackColor = Color.Red;

                        if (cell.Value == System.DBNull.Value)
                        {

                        }
                    }

                }
            }
            catch (NullReferenceException)
            {
                btnDelete.Enabled = false;
                btnDelete.BackColor = Color.DarkGray;
                return;
            }
            btnSave.Enabled = false;
            btnSave.BackColor = Color.DarkGray;
        }

        private void txtSearch1_TextChanged(object sender, EventArgs e)
        {
            try
            {



                MySqlConnection Conn = ConString.Connection;
                DataTable dt = new DataTable();

                MySqlDataAdapter sda = new MySqlDataAdapter("SELECT supplier_id as 'Supplier ID',  company as 'Supplier Name', contact_person as 'Contact Person', street as 'Street #', barangay as 'Barangay', city as 'City', contact as 'Cellphone #', telephone as 'Telephone #', email as 'Email'  FROM tbl_supplierinfo where company like '%" + txtSearch1.Text + "%'", Conn);
                sda.Fill(dt);
                Conn.Close();
                metroGrid1.DataSource = dt;

                if (txtSearch1.Text == "Search")
                {

                    Conn = ConString.Connection;
                    dt = new DataTable();
                    sda = new MySqlDataAdapter("SELECT supplier_id as 'Supplier ID',  company as 'Supplier Name', contact_person as 'Contact Person', street as 'Street #', barangay as 'Barangay', city as 'City', contact as 'Cellphone #', telephone as 'Telephone #', email as 'Email'   FROM tbl_supplierinfo", Conn);
                    sda.Fill(dt);
                    Conn.Close();
                    metroGrid1.DataSource = dt;
                    lblmatch1.Hide();

                }



            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                DataGridViewCell cell = null;
                foreach (DataGridViewCell selectedCell in metroGrid1.SelectedCells)
                {
                    cell = selectedCell;
                    break;
                }

                if (cell != null)
                {
                    DataGridViewRow row = cell.OwningRow;
                    txtSupplierID.Text = row.Cells[0].Value.ToString();
                    txtSupplierName.Text = row.Cells[1].Value.ToString();
                    txtContactPerson.Text = row.Cells[2].Value.ToString();
                    txtStreet.Text = row.Cells[3].Value.ToString();
                    txtBarangay.Text = row.Cells[4].Value.ToString();
                    txtCity.Text = row.Cells[5].Value.ToString();
                    txtContact.Text = row.Cells[6].Value.ToString();
                    txtTelephone.Text = row.Cells[7].Value.ToString();
                    txtEmail.Text = row.Cells[8].Value.ToString();


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            try
            {
                if (!metroGrid1.Rows[metroGrid1.CurrentCell.RowIndex].IsNewRow)
                {
                    foreach (DataGridViewCell cell in metroGrid1.Rows[metroGrid1.CurrentCell.RowIndex].Cells)
                    {
                        lblmatch1.Hide();
                        if (cell.Value == System.DBNull.Value)
                        {

                        }
                    }


                }
            }
            catch (NullReferenceException)
            {
                lblmatch1.Show();
            }
            if (txtSearch1.Text.Length <= 0) return;
            string s = txtSearch1.Text.Substring(0, 1);
            if (s != s.ToUpper())
            {
                int curSelStart = txtSearch1.SelectionStart;
                int curSelLength = txtSearch1.SelectionLength;
                txtSearch1.SelectionStart = 0;
                txtSearch1.SelectionLength = 1;
                txtSearch1.SelectedText = s.ToUpper();
                txtSearch1.SelectionStart = curSelStart;
                txtSearch1.SelectionLength = curSelLength;

            }
        }

        private void txtSearch1_Leave(object sender, EventArgs e)
        {
            if (txtSearch1.Text.Length == 0)
            {
                txtSearch1.Text = "Search";
                txtSearch1.ForeColor = SystemColors.GrayText;
            }
        }

        private void txtSearch1_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtSearch1.Text.Equals(null) == true)
            {
                txtSearch1.Text = "Search";
                txtSearch1.ForeColor = Color.Gray;
            }
            else
            {
                txtSearch1.ForeColor = Color.Black;
            }
            if (e.KeyCode == Keys.Back)
            {
                if (txtSearch1.Text.Length == 0)
                {


                    txtSearch1.Text = "Search";

                    txtSearch1.ForeColor = Color.Gray;
                    Cursor.Current = Cursors.IBeam;


                }
            }
        }

        private void txtSearch1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtSearch1.Text == "Search")
            {
                txtSearch1.Text = "";
            }
        }

        private void txtSearch1_Click(object sender, EventArgs e)
        {
            if (txtSearch1.Text == "Search")
            {
                txtSearch1.Focus();
                txtSearch1.Select(0, 0);

            }
        }

        private void txtSearch1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {


                btnSearch1.PerformClick();
            }
        }

        private void txtSupplierID_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            btnSave.BackColor = Color.DarkGray;
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void lblBeforeDontforget_Click(object sender, EventArgs e)
        {

        }

        private void lblInvalid_Click(object sender, EventArgs e)
        {

        }

        private void lblDontforget_Click(object sender, EventArgs e)
        {

        }

        private void lblEmailnotvalid_Click(object sender, EventArgs e)
        {

        }

        private void lblphone_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void lblAfterdontForget_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch1_Click(object sender, EventArgs e)
        {

        }

        private void txtStreet_Leave(object sender, EventArgs e)
        {
            if (txtStreet.Text.Length == 0)
            {
                txtStreet.Text = "Street #";
                txtStreet.ForeColor = SystemColors.GrayText;
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnAddProductDeliver_Click(object sender, EventArgs e)
        {


            try
            {
                if (cbSupplier.Text == "" || cbProductName.Text == "" || cbContactPerson.Text == "" || cbUnitPrice.Text == "" || txtAmountQTY.Text == "" || txtAmountQTY.Enabled == false)
                {
                    MessageBox.Show("Please enter require fields.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.None);
                    return;
                }
                DateTime date3 = dateTimePicker1.Value;
                DateTime date4 = dateExpected.Value;

                TimeSpan difference1 = date4.Subtract(date3);
                if ((date4 < date3 && dateTimePicker1.Text != dateExpected.Text))
                {
                    MessageBox.Show("The date doesn't look right. Be sure to use the actual date.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dateExpected.Text = dateTimePicker1.Text;
                }

                if (dateExpected.Text != dateOrdered.Text)
                {
                    generator1();
                    Cursor.Current = Cursors.WaitCursor;
                    int val1 = Convert.ToInt32(txtAmountQTY.Text);
                    decimal val2 = Convert.ToDecimal(cbUnitPrice.Text);

                    totaldue = val1 * val2;

                    MySqlConnection Conn = ConString.Connection;
                    MySqlDataReader myReader;

                    Cursor.Current = Cursors.WaitCursor;
                    string ordered = "Pending Ordered";
                    string Query = "insert into tbl_order (order_id, product_id,supplier_id,total_due,quantity,quantity_receive,damage_product, date_ordered, date_expected,status, leadtime1) values ('" + txtOrderID.Text + "','" + cbProductid.Text + "','" + suppID + "', '" + Convert.ToDecimal(totaldue) + "','" + Convert.ToInt32(txtAmountQTY.Text) + "',0,0,'" + dateOrdered.Text + "', '" + dateExpected.Text + "', '" + ordered + "', '"+txtLeadTime.Text+"')";
                
                    MySqlCommand cmd = new MySqlCommand(Query, Conn);
                    cmd.CommandTimeout = 50000;




                    try
                    {

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



                        MessageBox.Show("Ordered successfully.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        Conn.Close();

                        


                    }
                    catch (FormatException ex1)
                    {
                        MessageBox.Show(ex1.Message);
                    }
                    CriticalLevel1();
                    txtAmountQTY.Text = "";

                    txtAmountQTY.Enabled = true;
                    cbSupplier.SelectedIndex = -1;
                    cbContactPerson.SelectedIndex = -1;
                    cbProductName.Text = "";
                    cbUnitPrice.Text = "";
                    cbProductName.Enabled = false;
                    txtSearch2.Text = "";
                    btnOrder.Enabled = false;
                    btnOrder.BackColor = Color.DarkGray;
                    txtSearch2.Text = "Search";
                    txtSearch2.ForeColor = SystemColors.GrayText;
                    dataGridView1.Focus();
                    DGVOrder();
                 
                    ByNotifyWarehouse();

                }
              else  if (MessageBox.Show("Set date for delivery?", "Fabula's Merchandise System", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes && dateExpected.Text == dateOrdered.Text)
                {
                    int val1 = Convert.ToInt32(txtAmountQTY.Text);
                    decimal val2 = Convert.ToDecimal(cbUnitPrice.Text);

                    totaldue = val1 * val2;


                }
                else
                {
                    generator1();
                    Cursor.Current = Cursors.WaitCursor;
                    int val1 = Convert.ToInt32(txtAmountQTY.Text);
                    decimal val2 = Convert.ToDecimal(cbUnitPrice.Text);

                    totaldue = val1 * val2;

                    MySqlConnection Conn = ConString.Connection;
                    MySqlDataReader myReader;

                    Cursor.Current = Cursors.WaitCursor;
                    string ordered = "Ordered";
                    string Query = "insert into tbl_order (order_id, product_id,supplier_id,total_due,quantity,quantity_receive,damage_product, date_ordered, date_expected,status, leadtime1) values ('" + txtOrderID.Text + "','" + cbProductid.Text + "','" + suppID + "', '" + Convert.ToDecimal(totaldue) + "','" + Convert.ToInt32(txtAmountQTY.Text) + "',0,0,'" + dateOrdered.Text + "', '" + dateExpected.Text + "', '" + ordered + "',  '"+txtLeadTime.Text+"' )";
                   
                    MySqlCommand cmd = new MySqlCommand(Query, Conn);
                    cmd.CommandTimeout = 50000;




                    try
                    {

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



                        MessageBox.Show("Ordered successfully.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        Conn.Close();
                        ByNotifyWarehouse();


                    }
                    catch (FormatException ex1)
                    {
                        MessageBox.Show(ex1.Message);
                    }
                    CriticalLevel1();
                    txtAmountQTY.Text = "";

                    txtAmountQTY.Enabled = true;
                    cbSupplier.SelectedIndex = -1;
                    cbContactPerson.SelectedIndex = -1;
                    cbProductName.Text = "";
                    cbUnitPrice.Text = "";
                    cbProductName.Enabled = false;
                    dataGridView1.Focus();
                    DGVOrder();
                 
                    ByNotifyWarehouse();


                }
            }
            catch (Exception ex1)
            {
                MessageBox.Show(ex1.Message);
            }

            ByNotifyWarehouse();
         

        }

        private void cbSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
           // btnAddtoCart.Visible = true;
            lblresultfound.Visible = false;
            txtAmountQTY.Enabled = true;
            dateExpected.Enabled = true;
            metroGrid3.Enabled = true;
            try
            {
                txtSearch2.Enabled = true;

                lblresultfound.Visible = false;
                if (cbSupplier.Text == "")
                {

                    txtSearch2.Enabled = false;
                    txtSearch2.Text = "Search";
                    txtSearch2.ForeColor = SystemColors.GrayText;
                    btnOrder.BackColor = Color.DarkGray;
                    btnOrder.Enabled = false;
                    metroGrid2.Visible = false;
                }
                else
                {
                    btnOrder.BackColor = System.Drawing.ColorTranslator.FromHtml("#24262F");
                    btnOrder.Enabled = true;
                    metroGrid2.Visible = true;
                }
             
               dateOrdered.Text = DateTime.Now.ToString("yyyy-MM-dd");
                dateExpected.Text = DateTime.Now.ToString("yyyy-MM-dd");
             

                dateExpected.Enabled = true;

                if (txtLeadTime.Text.Contains("-"))
                {
                    txtLeadTime.Text = "0";
                }

                MySqlConnection Conn = ConString.Connection;


                Cursor.Current = Cursors.WaitCursor;

                string Query = "select * from tbl_supplierinfo where company = '" + cbSupplier.SelectedItem.ToString() + "'; ";
                
                MySqlCommand cmd = new MySqlCommand(Query, Conn);
                MySqlDataReader myReader;
               
                myReader = cmd.ExecuteReader();
                while (myReader.Read())
                {

                  //////  suppStreet, suppBarangay, suppCity, suppTel, suppEmail, suppMobile
                    suppID = myReader.GetInt32("supplier_id");
                    suppStreet = myReader.GetString("street");
                    suppBarangay = myReader.GetString("barangay");
                    suppCity = myReader.GetString("city");
                    suppTel = myReader.GetString("telephone");
                    suppMobile = myReader.GetString("contact");
                    suppEmail = myReader.GetString("email");
                    mCompany = myReader.GetString("company");






                }

                Conn.Close();

                Managerinfo();

                //Conn = ConString.Connection;
                //DataTable dt = new DataTable();
                //MySqlDataAdapter sda = new MySqlDataAdapter("select tbl_product.product_id as 'Product ID', tbl_product.product_name as 'Product Name', tbl_product.product_price as 'Price', tbl_product.supplier_id as 'Supplier ID'from tbl_product inner join tbl_supplierinfo on tbl_product.supplier_id = tbl_supplierinfo.supplier_id", Conn);
                //sda.Fill(dt);
                //Conn.Close();
                ////cbProductName.DataSource = dt;
                //metroGrid2.DataSource = dt;
                DGVListofProducts();
             
                //cbProductName.DisplayMember = "Product Name";
                //cbProductName.ValueMember = "Product ID";

                metroGrid2.Columns[0].Visible = false;
                metroGrid2.Columns[3].Visible = false;
                 Conn = ConString.Connection;
                Query = "select contact_person from tbl_supplierinfo where supplier_id = '" + suppID + "'; ";
                cmd = new MySqlCommand(Query, Conn);
                myReader = cmd.ExecuteReader();

                while (myReader.Read())
                {
                    cbContactPerson.Text = myReader.GetString("contact_person").ToString();
                }

                Conn.Close();
               metroGrid2.Columns[0].Visible = false;
                DGVPurchaseOrder();

                total();
                //  subPO();


                dateExpected.Enabled = true;
                btnAddtoCart.Enabled = true;

                btnAddtoCart.BackColor = System.Drawing.ColorTranslator.FromHtml("#24262F");

                try
                {
                    if (!metroGrid3.Rows[metroGrid3.CurrentCell.RowIndex].IsNewRow)
                    {
                        foreach (DataGridViewCell cell in metroGrid3.Rows[metroGrid3.CurrentCell.RowIndex].Cells)
                        {
                            //btnOrder.Enabled = true;
                            //lblresultfound.Hide();
                            btnPrintPurchase.BackColor = System.Drawing.ColorTranslator.FromHtml("#24262F");
                            lblnoorders.Visible = false;
                            btnPrintPurchase.Enabled = true;

                            if (cell.Value == System.DBNull.Value)
                            {

                            }
                        }


                    }
                }
                catch (Exception)
                {
                    //btnOrder.Enabled = false;
                    lblnoorders.Visible = true;
                    btnPrintPurchase.Enabled = false;
                    btnPrintPurchase.BackColor = Color.DarkGray;


                    return;
                }
            }
            catch (Exception ex)
            {
                //  MessageBox.Show(ex.Message);
            }
            cbContactPerson.Enabled = false;
          //  cbProductName.Enabled = true;
            txtAmountQTY.Enabled = true;
            txtAmountQTY.Text = "";
            dateOrdered.Text = dateTimePicker1.Text;
            dateExpected.Text = dateTimePicker1.Text;
            dateExpected.Enabled = true;
            txtLeadTime.Text = "0";
           // txtHours.Text = "0";

            if (txtLeadTime.Text == "1")
            {
                lbldays.Text = "Day";
            }
            else
            {
                lbldays.Text = "Days";
            }
            //if (txtHours.Text == "1")
            //{
            //    lblhours.Text = "Hour";
            //}
            //else
            //{
            //    lblhours.Text = "Hours";
            //}
        }
        void Managerinfo()
        {
            MySqlConnection Conn = ConString.Connection;


            Cursor.Current = Cursors.WaitCursor;

            string Query = "select * from tbl_login where user_type = 'Manager'";

            MySqlCommand cmd = new MySqlCommand(Query, Conn);
            MySqlDataReader myReader;

            myReader = cmd.ExecuteReader();
            while (myReader.Read())
            {

                //////  suppStreet, suppBarangay, suppCity, suppTel, suppEmail, suppMobile
               
                mStreet = myReader.GetString("street");
                mBarangay = myReader.GetString("barangay");
                mCity = myReader.GetString("city");
              
                mContact = myReader.GetString("contact");
                mEmail = myReader.GetString("email_address");
            






            }

            Conn.Close();
        }

        void total()
        {
            int price = 0;
            for (int i = 0; i < metroGrid3.Rows.Count; ++i)
            {
                price += Convert.ToInt32(metroGrid3.Rows[i].Cells[2].Value);
            }
            txtTotal.Text = price.ToString();

            int sum = 0;
            for (int i = 0; i < metroGrid3.Rows.Count; ++i)
            {
                sum += Convert.ToInt32(metroGrid3.Rows[i].Cells[1].Value);
            }
            txtQTY.Text = sum.ToString();



            decimal totalprice = decimal.Parse(txtTotal.Text);
            decimal tax = totalprice - (totalprice / Convert.ToDecimal((1.12)));
            txtSalestax.Text = tax.ToString();



            decimal subtotal = totalprice - tax;
            txtSubtotal.Text = subtotal.ToString();
        }
        private void txtProductDeliver_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbProductName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbDescription_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection Conn = ConString.Connection;


                Cursor.Current = Cursors.WaitCursor;

                string Query = "select * from tbl_supplierinfo where contact_person = '" + cbContactPerson.SelectedItem.ToString() + "'; ";
                
                MySqlCommand cmd = new MySqlCommand(Query, Conn);
                MySqlDataReader myReader;
           
                myReader = cmd.ExecuteReader();
                while (myReader.Read())
                {
                    suppID = myReader.GetInt32("supplier_id");

                }

                Conn.Close();

            }
            catch (Exception ex)
            {

            }
        }

        private void cbProductName_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbDescription_TextChanged(object sender, EventArgs e)
        {
            cbContactPerson.Text = "";
        }

        private void txtUnitPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;

            cbCritical.Size = new Size(0, 24);
        }

        private void btnInspect_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
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

        private void metroGrid4_MouseClick(object sender, MouseEventArgs e)
        {

            try
            {
                //if (date_ordered != date_expect)
                //{
                //  //  MessageBox.Show("The product: '" + productname + "' will be delivered: " + txtHours.Text + (" hour(s) left in ") + dateExpected.Text, "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //  label24.Text = "The product: '" + productname + "' will be delivered: " + txtHours.Text + (" hour(s) left in ") + dateExpected.Text;
                //    return;
                //}


                if (!(txtLeadTime.Text == "" || orderstatusss != "Ordered"))
                {
                    //MessageBox.Show("The product: '" +productname + "' will be delivered: " +txtSubdays.Text +(" day(s) and ") +txtHours.Text+(" hour(s) left in ") + dateExpected.Text, "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    label24.Text = "The product: '" + productname + "' will be delivered: " + txtLeadTime.Text + (" day(s) left in ") + dateExpected.Text;
                    return;
                }
              

                if (dataGridView1.Rows.Count > 0)
                {
                    orderid = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                    subOrderID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());

                }

                MySqlConnection Conn = ConString.Connection;


                string Query = "select* from tbl_order where order_id = '" + orderid + "'";
                MySqlCommand cmd = new MySqlCommand(Query, Conn);
                MySqlDataReader myReader;

                try
                {

                    myReader = cmd.ExecuteReader();

                    while (myReader.Read())
                    {

                        orderstatusss = myReader.GetString("status");

                    }

                    label17.Text = productid.ToString();
                    label16.Text = statusss;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }




                Conn.Close();


                if (orderstatusss == "Received")
                {
                    label24.Text = "";
                    MessageBox.Show("Product(s) is/are already inspected.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else if (orderstatusss == "Reordered")
                {
                    MessageBox.Show("Product(s) is/are already inspected and reordered", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                }
                else
                {
                //   Conn = ConString.Connection;


                //   Query = "update tbl_order set status = 'Received'  where order_id = '" + orderid + "' and status = 'Ordered'";
                //  cmd = new MySqlCommand(Query, Conn);
                   

                //    try
                //    {

                //        myReader = cmd.ExecuteReader();

                //        while (myReader.Read())
                //        {

                //            orderstatusss = myReader.GetString("status");

                //        }

                //        label17.Text = productid.ToString();
                //        label16.Text = statusss;

                //    }
                //    catch (Exception ex)
                //    {
                //        MessageBox.Show(ex.Message);
                //    }




                //    Conn.Close();
                }
            }
            catch (Exception)
            {

            }
        }
        public void CriticalLevel1()
        {
            //try
            //{
            //    MySqlConnection conn = ConString.Connection;
            //    DateTime datenow = DateTime.Now;
            //    MySqlDataReader dr;
            //    MySqlCommand cmd;
            //    string query;


            //    //CRITICAL LEVEL
            //    if (txtLeadTime.Text == "0")
            //    {





            //        try
            //        {
            //            //formula
            //            //SAFETY STOCK/SS

            //            query = "insert into tbl_critical (product_id, quantity, leadtime, date) values ('" + Convert.ToInt32(cbProductid.Text) + "','" + Convert.ToInt32(txtAmountQTY.Text) + "',0, '" + datenow.ToString("yyyy-MM-dd") + "');update tbl_product A inner join (select product_id,max(quantity) * max(leadtime)-avg(quantity) * avg(leadtime) as 'SS' from tbl_critical where date between date_sub(NOW(),interval 360 day) and NOW() group by product_id) B on A.product_id=B.product_id set A.ss = B.SS where A.product_id = '" + cbProductid.Text + "'";
            //            //"             update tblinventory A inner join (select itemid,max(soldqty)-min(soldqty) as 'SS' from tblcart where datesold between date_sub(NOW(),interval 60 day) and NOW() and remove='No' and payment='Yes' group by itemid) B on A.itemid=B.itemid set A.ss=B.SS where a.itemid = '"+itemid+"';";
            //            cmd = new MySqlCommand(query, conn);
            //            dr = cmd.ExecuteReader();

            //            conn.Close();
            //        }
            //        catch (Exception ex)
            //        {
            //            MessageBox.Show(ex.Message, "1111");
            //        }

            //        try
            //        {
            //            //AVERAGE DAILY SALES
            //            conn = ConString.Connection;
            //            query = "update tbl_product A inner join (SELECT product_id,avg(quantity)/2 as 'OQ' FROM tbl_critical where date between date_sub(NOW(),interval 360 day) and NOW() group by product_id) B on A.product_id=B.product_id set A.oq=B.OQ where A.product_id = '" + cbProductid.Text + "'";
            //            //             update tblinventory A inner join (SELECT itemid,avg(soldqty)/2 as 'OQ' FROM tblcart where datesold between date_sub(NOW(),interval 60 day) and NOW() and remove='No' and payment='Yes' group by itemid) B on A.itemid=B.itemid set A.OQ=B.OQ where a.itemid = '"+itemid+"' ;";
            //            cmd = new MySqlCommand(query, conn);
            //            dr = cmd.ExecuteReader();

            //            conn.Close();
            //        }
            //        catch (Exception ex)
            //        {
            //            MessageBox.Show(ex.Message, "2");
            //        }

            //        try
            //        {
            //            conn = ConString.Connection;
            //            // critical = (ss + oq)/2
            //            query = "update tbl_product set critical=(ss + oq)/2  where product_id = '" + cbProductid.Text + "';";
            //            cmd = new MySqlCommand(query, conn);
            //            dr = cmd.ExecuteReader();

            //            conn.Close();
            //        }
            //        catch (Exception ex)
            //        {
            //            MessageBox.Show(ex.Message, "3");
            //        }
            //    }
            //    else if (txtLeadTime.Text != "0")
            //    {
            //        //    MessageBox.Show("B");

            //        try
            //        {
            //            //formula
            //            //SAFETY STOCK/SS
            //            conn = ConString.Connection;
            //            query = "insert into tbl_critical (product_id, quantity, leadtime, date) values ('" + Convert.ToInt32(cbProductid.Text) + "','" + Convert.ToInt32(txtAmountQTY.Text) + "', '" + Convert.ToInt32(txtLeadTime.Text) + "', '" + datenow.ToString("yyyy-MM-dd") + "');update tbl_product A inner join (select product_id, max(quantity) * max(leadtime) - avg(leadtime) * avg(quantity) as 'SS' from tbl_critical where date between date_sub(NOW(),interval 360 day) and NOW() group by product_id) B on A.product_id=B.product_id set A.ss = B.SS where A.product_id = '" + cbProductid.Text + "'";
            //            //"             update tblinventory A inner join (select itemid,max(soldqty)-min(soldqty) as 'SS' from tblcart where datesold between date_sub(NOW(),interval 60 day) and NOW() and remove='No' and payment='Yes' group by itemid) B on A.itemid=B.itemid set A.ss=B.SS where a.itemid = '"+itemid+"';";
            //            cmd = new MySqlCommand(query, conn);
            //            dr = cmd.ExecuteReader();

            //            conn.Close();
            //        }
            //        catch (Exception ex)
            //        {
            //            MessageBox.Show(ex.Message, "4yea");
            //        }

            //        try
            //        {
            //            //AVERAGE DAILY SALES
            //            conn = ConString.Connection;
            //            query = "update tbl_product A inner join (SELECT product_id,avg(quantity)/2 as 'OQ' FROM tbl_critical where date between date_sub(NOW(),interval 360 day) and NOW() group by product_id) B on A.product_id=B.product_id set A.oq=B.OQ where A.product_id = '" + cbProductid.Text + "'";
            //            //             update tblinventory A inner join (SELECT itemid,avg(soldqty)/2 as 'OQ' FROM tblcart where datesold between date_sub(NOW(),interval 60 day) and NOW() and remove='No' and payment='Yes' group by itemid) B on A.itemid=B.itemid set A.OQ=B.OQ where a.itemid = '"+itemid+"' ;";
            //            cmd = new MySqlCommand(query, conn);
            //            dr = cmd.ExecuteReader();

            //            conn.Close();
            //        }
            //        catch (Exception ex)
            //        {
            //            MessageBox.Show(ex.Message, "5");
            //        }

            //        try
            //        {
            //            //AVERAGE DAILY SALES
            //            conn = ConString.Connection;
            //            query = "update tbl_product A inner join (SELECT product_id,avg(leadtime) as 'LT' FROM tbl_critical where date between date_sub(NOW(),interval 360 day) and NOW() group by product_id) B on A.product_id=B.product_id set A.lt=B.LT where A.product_id = '" + cbProductid.Text + "'";
            //            //             update tblinventory A inner join (SELECT itemid,avg(soldqty)/2 as 'OQ' FROM tblcart where datesold between date_sub(NOW(),interval 60 day) and NOW() and remove='No' and payment='Yes' group by itemid) B on A.itemid=B.itemid set A.OQ=B.OQ where a.itemid = '"+itemid+"' ;";
            //            cmd = new MySqlCommand(query, conn);
            //            dr = cmd.ExecuteReader();

            //            conn.Close();
            //        }
            //        catch (Exception ex)
            //        {
            //            MessageBox.Show(ex.Message, "6");
            //        }

            //        try
            //        {
            //            conn = ConString.Connection;
            //            // critical = (ss + oq)/2
            //            query = "update tbl_product set critical=(ss + oq)/2 * LT where product_id = '" + cbProductid.Text + "';";
            //            cmd = new MySqlCommand(query, conn);
            //            dr = cmd.ExecuteReader();

            //            conn.Close();
            //        }
            //        catch (Exception ex)
            //        {
            //            MessageBox.Show(ex.Message, "7");
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "4", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);

            //}
        }
        private void metroGrid4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            cbCritical.Visible = false;
            cbCritical.Size = new Size(0, 24);
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void metroGrid4_SelectionChanged(object sender, EventArgs e)
        {
            try
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
                    txtOrderID.Text = row.Cells[0].Value.ToString();
                    date_expected = row.Cells[9].Value.ToString();
                    productname = row.Cells[1].Value.ToString();
                    statusss = row.Cells[2].Value.ToString();
                    dateOrdered.Text = row.Cells[8].Value.ToString();
                    dateExpected.Text = row.Cells[9].Value.ToString();
                    date_ordered = row.Cells[8].Value.ToString();
                    date_expect = row.Cells[9].Value.ToString();
                  mProductID = row.Cells[10].Value.ToString();
                    mSupplierID = row.Cells[12].Value.ToString();


                    if(sublblcritical.Text == "Critical")
                    {
                        lblcritical.Text = row.Cells[15].Value.ToString();
                     
                    }
                    //DateTime date1 = dateTimePicker1.Value;
                    //DateTime date2 = dateExpected.Value;

                    //TimeSpan difference = date2.Subtract(date1);
                    //txtDays.Text = difference.TotalDays.ToString();
                    //txtSubdays.Text = difference.TotalDays.ToString();
                    //txtHours.Text = difference.TotalHours.ToString();
                    //txtMinutes.Text = difference.TotalMinutes.ToString();
                    //txtSeconds.Text = difference.TotalSeconds.ToString();
                    //txtMilliseconds.Text = difference.TotalMilliseconds.ToString();
                    //txtSubdays.Text = Convert.ToInt32(date2.Subtract(date1).Days + 1).ToString();
                    //  txtHours.Text = Convert.ToInt32(date2.Subtract(date1).Hours).ToString();

                    //DateTime startdate = dateTimePicker1.Value;
                    //DateTime enddate = dateExpected.Value;
                    //txtSubdays.Text = Days1(startdate, enddate).ToString();

                    //DateTime StartDate1 = dateTimePicker1.Value;
                    //DateTime EndTime1 = dateExpected.Value;
                    //txtHours.Text = Hours1(StartDate1, EndTime1).ToString();

                    //DateTime date1 = dateTimePicker1.Value;
                    //DateTime date2 = dateExpected.Value;

                    //TimeSpan difference = date2.Subtract(date1);

                    //txtSubdays.Text = Convert.ToInt32(date2.Subtract(date1).Days).ToString();

                    txtLeadTime.Text = (dateExpected.Value - DateTime.Today).TotalDays.ToString("#");
                  
                    //if (txtHours.Text.Contains("-"))
                    //{
                    //    txtHours.Text = "0";
                    //}
                    if (txtLeadTime.Text.Contains("-"))
                    {
                        txtLeadTime.Text = "0";
                    }

                    if (txtLeadTime.Text == "1")
                    {
                        lbldays.Text = "Day left";
                    }
                    else
                    {
                        lbldays.Text = "Days left";
                    }
                    //if (txtHours.Text == "1")
                    //{
                    //    lblhours.Text = "Hour left";
                    //}
                    //else
                    //{
                    //    lblhours.Text = "Hours left";
                    //}
                    btnPrintPurchase.Enabled = false;
                    btnPrintPurchase.BackColor = Color.DarkGray;
                    btnPrintPurchase.ForeColor = Color.White;
                    if (btnPrintPurchase.Enabled == false)
                    {
                        Cursor.Current = Cursors.AppStarting;
                    }

                    if (statusss != "Ordered")
                    {
                        btnCancelOrdered.Enabled = false;
                        btnCancelOrdered.BackColor = Color.Gray;

                    }
                    else
                    {
                        btnCancelOrdered.Enabled = true;
                        btnCancelOrdered.BackColor = Color.Red;
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Hoy");
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
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

            //if (e.KeyCode == Keys.Enter)
            //{


            //    btnSearch.PerformClick();
            //}
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



                MySqlConnection Conn = ConString.Connection;
                DataTable dt = new DataTable();

                MySqlDataAdapter sda = new MySqlDataAdapter("SELECT tbl_order.order_id as 'Order ID', tbl_product.product_name as 'Product', tbl_order.status as 'Status', sum(tbl_order.total_due) as 'Total Due', sum(tbl_order.quantity) as 'Ordered QTY', tbl_order.quantity_receive as 'QTY Received', tbl_order.damage_product as 'Backorder QTY', tbl_supplierinfo.company as 'Supplier Name' ,tbl_order.date_ordered as 'Date Ordered', tbl_order.date_expected as 'Delivery Date', tbl_product.product_id as 'Product ID', tbl_product.stock as 'Stock', tbl_order.supplier_id as 'Supplier ID', timestampdiff(day, date(now()), date_expected) as 'Days Left'  FROM tbl_order inner join tbl_product on tbl_order.product_id = tbl_product.product_id inner join tbl_supplierinfo on tbl_order.supplier_id = tbl_supplierinfo.supplier_id  where " +
                    "tbl_order.total_due != 0.00 and tbl_order.status = 'Ordered' and tbl_product.product_name like '%" + txtSearch.Text + "%' " +
                    " or tbl_order.total_due != 0.00 and tbl_order.status = 'Overdue Ordered' and tbl_product.product_name like '%" + txtSearch.Text + "%' " +
                      " or tbl_order.total_due != 0.00 and tbl_order.status = 'Pending Ordered' and tbl_product.product_name like '%" + txtSearch.Text + "%' " +
                        " or tbl_order.total_due != 0.00 and tbl_order.status = 'Backorder' and tbl_product.product_name like '%" + txtSearch.Text + "%' " +
                         " or tbl_order.total_due != 0.00 and tbl_order.status = 'Received' and tbl_product.product_name like '%" + txtSearch.Text + "%' " +
                    "group by tbl_order.product_id, tbl_order.supplier_id, tbl_order.status order by tbl_order.order_id desc;", Conn);
                sda.Fill(dt);
                Conn.Close();
                dataGridView1.DataSource = dt;

                dataGridView1.Columns[0].Visible = false;
             
                dataGridView1.Columns[10].Visible = false;
                dataGridView1.Columns[11].Visible = false;
                dataGridView1.Columns[12].Visible = false;
                if (txtSearch.Text == "Search")
                {
                    DGVOrder();

                }
                changeRowColor1();


            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
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
                    date_expected = row.Cells[9].Value.ToString();
                    productname = row.Cells[1].Value.ToString();
                    dateOrdered.Text = row.Cells[8].Value.ToString();
                    dateExpected.Text = row.Cells[9].Value.ToString();



                    //DateTime date1 = dateOrdered.Value;
                    //DateTime date2 = dateExpected.Value;

                    //TimeSpan difference = date2 - date1;
                    //txtDays.Text = difference.TotalDays.ToString();
                    //txtSubdays.Text = difference.TotalDays.ToString();
                    //txtHours.Text = difference.TotalHours.ToString();
                    //txtMinutes.Text = difference.TotalMinutes.ToString();
                    //txtSeconds.Text = difference.TotalSeconds.ToString();
                    //txtMilliseconds.Text = difference.TotalMilliseconds.ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            try
            {
                if (!dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].IsNewRow)
                {
                    foreach (DataGridViewCell cell in dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells)
                    {
                        lblresult.Hide();
                        if (cell.Value == System.DBNull.Value)
                        {

                        }
                    }


                }
            }
            catch (NullReferenceException)
            {
                lblresult.Show();
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

        private void frm_Supplier_FormClosing(object sender, FormClosingEventArgs e)
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
        //private bool ValidateDate(string date)
        //{
        //    try
        //    {

        //        string[] dateParts = date.Split('/');

        //        DateTime testDate = new
        //            DateTime(Convert.ToInt32(dateParts[2]),
        //            Convert.ToInt32(dateParts[0]),
        //            Convert.ToInt32(dateParts[1]));

        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
        public long Days1(System.DateTime StartDate, System.DateTime EndTime)
        {
            long days = 0;
            System.TimeSpan ts = new TimeSpan(EndTime.Ticks - StartDate.Ticks);
            days = (long)(ts.Days / 1);
            return days;
        }
        public long Hours1(System.DateTime StartDate1, System.DateTime EndTime1)
        {
            long hours = 0;
            System.TimeSpan ts = new TimeSpan(EndTime1.Ticks - StartDate1.Ticks);
            hours = (long)(ts.Hours);
            return hours;
        }
        private void dateExpected_ValueChanged(object sender, EventArgs e)
        {
            DateTime startdate = dateTimePicker1.Value;
            DateTime enddate = dateExpected.Value;
            txtLeadTime.Text = Days1(startdate, enddate).ToString();

         

            DateTime date1 = dateTimePicker1.Value;
            DateTime date2 = dateExpected.Value;
           
            TimeSpan difference = date2.Subtract(date1);

            txtLeadTime.Text = (dateExpected.Value - DateTime.Today).TotalDays.ToString("#");

            if (dateTimePicker1.Text == dateExpected.Text)
            {
                txtLeadTime.Text = "0";
            }

            if ((date2 < date1 && dateTimePicker1.Text != dateExpected.Text))
            {
              //  MessageBox.Show("The date doesn't look right. Be sure to use the actual date.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateExpected.Text = dateTimePicker1.Text;
            }
            //if (txtHours.Text.Contains("-"))
            //{
            //    txtHours.Text = "0";
            //}
            if (txtLeadTime.Text == "1")
            {
                lbldays.Text = "Day";
            }
            else
            {
                lbldays.Text = "Days";
            }
            //if (txtHours.Text == "1")
            //{
            //    lblhours.Text = "Hour";
            //}
            //else
            //{
            //  //  lblhours.Text = "Hours";
            //}




        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void cbUnitPrice_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void metroGrid4_DoubleClick(object sender, EventArgs e)
        {
            //if (!(txtSubdays.Text == "0" && txtHours.Text == "0"))
            //{
            //    MessageBox.Show("The product: '" +productname + "' will be delivered: " +txtSubdays.Text +(" day(s) remaining in ") + dateExpected.Text, "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}
            //else
            //{

            //}
        }

        private void dateOrdered_ValueChanged(object sender, EventArgs e)
        {
            DateTime date1 = dateTimePicker1.Value;
            DateTime date2 = dateExpected.Value;

            TimeSpan difference = date2 - date1;
            txtDays.Text = difference.TotalDays.ToString();
            txtLeadTime.Text = difference.TotalDays.ToString();
        //    txtHours.Text = difference.TotalHours.ToString();
            txtMinutes.Text = difference.TotalMinutes.ToString();
            txtSeconds.Text = difference.TotalSeconds.ToString();
            txtMilliseconds.Text = difference.TotalMilliseconds.ToString();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
           
        }
      
        private void lblTime_ValueChanged(object sender, EventArgs e)
        {
           

        }

        private void btnCancelOrdered_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection Conn = ConString.Connection;


                Cursor.Current = Cursors.WaitCursor;
                string cancelled = "Cancelled order";
                string Query = "UPDATE tbl_order set status =  '" + cancelled + "' where order_id = '" + txtOrderID.Text + "'";
               
                MySqlCommand cmd = new MySqlCommand(Query, Conn);
                MySqlDataReader myReader;
                if (statusss != "Ordered")
                {
                   
                    return;
                }
                if (MessageBox.Show("Are you sure, you want to cancel order?", "Fabula's Merchandise System", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                   
                    myReader = cmd.ExecuteReader();
                    while (myReader.Read())
                    {


                    }

                    Conn.Close();
                    MessageBox.Show("Cancelled order successfully.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
             
                DGVOrder();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtTelephone_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            btnSave.BackColor = System.Drawing.ColorTranslator.FromHtml("#24262F");
            if (btnAdd.Enabled == true || txtTelephone.Text == "")
            {
                btnSave.Enabled = false;
                btnSave.BackColor = Color.DarkGray;
            }

            if (txtTelephone.Text == telephone)
            {
                btnSave.Enabled = false;
                btnSave.BackColor = Color.DarkGray;
            }
          
        }

        private void txtTelephone_Leave(object sender, EventArgs e)
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

        private void txtTelephone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
         (e.KeyChar != '+') && (e.KeyChar != '-') && (e.KeyChar != '(') && (e.KeyChar != ')'))
            {
                e.Handled = true;
            }
        }

        private void metroGrid4_Leave(object sender, EventArgs e)
        {
           
        }

        private void cbProductid_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtSeconds_TextChanged(object sender, EventArgs e)
        {

        }

        private void metroGrid2_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewCell cell = null;
            foreach (DataGridViewCell selectedCell in metroGrid2.SelectedCells)
            {
                cell = selectedCell;
                break;
            }

            if (cell != null)
            {

                DataGridViewRow row = cell.OwningRow;
                cbProductid.Text = row.Cells[0].Value.ToString();
                cbProductName.Text = row.Cells[1].Value.ToString();
                cbUnitPrice.Text = row.Cells[2].Value.ToString();
                getsupplier_id = row.Cells[3].Value.ToString();


            }
        }

        private void txtSearch2_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (txtSearch2.Text == "Search")
            {
                txtSearch2.Text = "";
            }
        }

        private void txtSearch2_Click(object sender, EventArgs e)
        {
            if (txtSearch2.Text == "Search")
            {
                txtSearch2.Focus();
                txtSearch2.Select(0, 0);

            }
        }

        private void txtSearch2_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtSearch2.Text.Equals(null) == true)
            {
                txtSearch2.Text = "Search";
                txtSearch2.ForeColor = Color.Gray;
            }
            else
            {
                txtSearch2.ForeColor = Color.Black;
            }
            if (e.KeyCode == Keys.Back)
            {
                if (txtSearch2.Text.Length == 0)
                {


                    txtSearch2.Text = "Search";

                    txtSearch2.ForeColor = Color.Gray;
                    Cursor.Current = Cursors.IBeam;


                }
            }
        }

        private void txtSearch2_Leave(object sender, EventArgs e)
        {
            if (txtSearch2.Text.Length == 0)
            {
                txtSearch2.Text = "Search";
                txtSearch2.ForeColor = SystemColors.GrayText;
            }
        }

        private void txtSearch2_TextChanged(object sender, EventArgs e)
        {
            try
            {



                MySqlConnection Conn = ConString.Connection;
                DataTable dt = new DataTable();
                cbProductName.Text = txtSearch2.Text;
                MySqlDataAdapter sda = new MySqlDataAdapter("select tbl_product.product_id as 'Product ID', tbl_product.product_name as 'Product Name', tbl_product.product_price as 'Price', tbl_product.supplier_id as 'Supplier ID'from tbl_product left join tbl_supplierinfo on tbl_product.supplier_id = tbl_supplierinfo.supplier_id where tbl_product.product_name like '%" + txtSearch2.Text+"%'  or tbl_product.product_price like '%"+txtSearch2.Text+"%'", Conn);
                sda.Fill(dt);
                Conn.Close();
                metroGrid2.DataSource = dt;
                

                if (txtSearch2.Text == "Search" || txtSearch2.Text == "")
                {


                     Conn = ConString.Connection;
                    dt = new DataTable();
                    sda = new MySqlDataAdapter("select tbl_product.product_id as 'Product ID', tbl_product.product_name as 'Product Name', tbl_product.product_price as 'Price', tbl_product.supplier_id as 'Supplier ID'from tbl_product left join tbl_supplierinfo on tbl_product.supplier_id = tbl_supplierinfo.supplier_id", Conn);
                    sda.Fill(dt);
                    Conn.Close();
                    metroGrid2.DataSource = dt;
                    lblresultfound.Hide();
                    metroGrid2.Columns[3].Visible = false;
                    metroGrid2.Columns[0].Visible = false;

                }
                metroGrid2.Columns[3].Visible = false;
                metroGrid2.Columns[0].Visible = false;



                try
                {
                    if (!metroGrid2.Rows[metroGrid2.CurrentCell.RowIndex].IsNewRow)
                    {
                        foreach (DataGridViewCell cell1 in metroGrid2.Rows[metroGrid2.CurrentCell.RowIndex].Cells)
                        {
                            btnOrder.Enabled = true;
                            lblresultfound.Hide();
                            btnOrder.BackColor = System.Drawing.ColorTranslator.FromHtml("#24262F");

                            if (cell1.Value == System.DBNull.Value)
                            {

                            }
                        }


                    }
                }
                catch (NullReferenceException)
                {
                    btnOrder.Enabled = false;
                    cbProductName.Text = "";
                    lblresultfound.Show();
                    cbUnitPrice.Text = "";

                    btnOrder.BackColor = Color.DarkGray;
                    return;
                }

            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void cbSupplier_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!metroGrid3.Rows[metroGrid3.CurrentCell.RowIndex].IsNewRow)
                {
                    foreach (DataGridViewCell cell in metroGrid3.Rows[metroGrid3.CurrentCell.RowIndex].Cells)
                    {
                      
                        if (cell.Value == System.DBNull.Value)
                        {

                        }
                    }


                }
            }
            catch (NullReferenceException)
            {
                btnPrintPurchase.Enabled = false;
                btnPrintPurchase.BackColor = Color.DarkGray;
                btnPrintPurchase.ForeColor = Color.White;
                if (btnPrintPurchase.Enabled == false)
                {
                    Cursor.Current = Cursors.AppStarting;
                }

                return;
            }
        }
        private void UpdateFont()
        {
            //Change cell font
            foreach (DataGridViewColumn c in dataGridView1.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Century Gothic", 15, FontStyle.Regular);
             
            }
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            UpdateFont();
         //   metroGrid4.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 15, FontStyle.Regular);
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

        private void btnSupplier_Click(object sender, EventArgs e)
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

        private void button6_Click(object sender, EventArgs e)
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

        private void btnhomenew1_Click(object sender, EventArgs e)
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

        private void button10_Click(object sender, EventArgs e)
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

        private void button9_Click(object sender, EventArgs e)
        {

        }

        void productSQTY()
        {
            MySqlConnection Conn = ConString.Connection;



            string Query = "Select * from tbl_product where product_id = '"+cbProductid.Text+"' and status_new = 'Critical Level'";
            MySqlCommand cmd = new MySqlCommand(Query, Conn);
            MySqlDataReader myReader;

            try
            {

                myReader = cmd.ExecuteReader();

                while (myReader.Read())
                {

                    mCritical = myReader.GetString("status_new");

                    mQTYcritical = myReader.GetInt32("critical");

                    mStock = myReader.GetInt32("stock");

                    int sQTY = mQTYcritical - mStock + 1;
                    if (Convert.ToInt32(txtAmountQTY.Text) < sQTY && mCritical == "Critical Level")
                    {
                        MessageBox.Show("Your order is too too low in suggestive QTY: " + sQTY + ".", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                   else if (Convert.ToInt32(txtAmountQTY.Text) > sQTY && mCritical == "Critical Level")
                    {
                        MessageBox.Show("Your order is too too high in suggestive QTY: " + sQTY + ".", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                }

                Conn.Close();


             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error13");
            }

        }

        private void btnCR_Click(object sender, EventArgs e)
        {
            sublblcritical.Text = "Critical";
            btnCancel.Visible = false;
            //   panel3.Visible = true;



            //if (cbCritical.Size == new Size(0, 24))
            //{
            //    cbCritical.Size = new Size(223, 24);
            //    cbCritical.DroppedDown = true;
            //}
            //else
            //{
            //    cbCritical.Size = new Size(0, 0);
            //    cbCritical.DroppedDown = false;
            //}
          
            MySqlConnection Conn = ConString.Connection;
            DataTable dt = new DataTable();

            MySqlDataAdapter sda = new MySqlDataAdapter("SELECT tbl_order.order_id as 'Order ID', tbl_product.product_name as 'Product', tbl_order.status as 'Status', sum(tbl_order.total_due) as 'Total Due', sum(tbl_order.quantity) as 'Ordered QTY', tbl_order.quantity_receive as 'QTY Received', tbl_order.damage_product as 'Backorder QTY', tbl_supplierinfo.company as 'Supplier Name' ,tbl_order.date_ordered as 'Date Ordered', tbl_order.date_expected as 'Delivery Date', tbl_product.product_id as 'Product ID', tbl_product.stock as 'Stock', tbl_order.supplier_id as 'Supplier ID', timestampdiff(day, date(now()), date_expected) as 'Days Left', tbl_product.stock as 'Remaining Stock', tbl_product.critical as 'Critical Level', " +
                "tbl_product.ss as 'Safety Stock', tbl_product.rp as 'Reorder Point', tbl_product.sqty as 'Maximum Level of Stock', " +
                "floor((tbl_product.sqty + tbl_product.rp + tbl_product.ss + tbl_product.critical)/4)  as 'Suggested QTY', tbl_product.status_new as 'Status' FROM tbl_order inner join tbl_product on tbl_order.product_id = tbl_product.product_id inner join tbl_supplierinfo on tbl_order.supplier_id = tbl_supplierinfo.supplier_id  where tbl_product.stock <= tbl_product.critical and tbl_product.status_new  = 'Critical Level' group by tbl_product.product_id", Conn);
            sda.Fill(dt);
            Conn.Close();

            dataGridView1.DataSource = dt;

            dataGridView1.Columns[2].Visible = false;

            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[9].Visible = false;
            dataGridView1.Columns[10].Visible = false;
            dataGridView1.Columns[13].Visible = false;


        }


        public void CancelledOrders()


        {


            MySqlConnection Conn = ConString.Connection;


           

            string Query = "Update tbl_order set status= 'Cancelled order' where product_id = '"+mProductID+"' and supplier_id = '"+mSupplierID+ "' and status = 'Pending Ordered' and date_expected = '" + date_expect + "' and date_ordered = '"+dateOrdered.Text+"' or product_id = '" + mProductID + "' and supplier_id = '" + mSupplierID + "' and status = 'Backorder' and date_expected = '" + date_expect + "' and date_ordered = '" + dateOrdered.Text + "';Update tbl_order set subStatus1 = 'Checked' where product_id = '" + mProductID + "' and supplier_id = '" + mSupplierID + "' and subStatus1 = 'Uncheck' and date_expected = '"+date_expect+ "' and date_ordered = '" + dateOrdered.Text + "'";
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
            MessageBox.Show("Cancelled successfully.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ByNotifyWarehouse()
        {

            MySqlConnection Conn = ConString.Connection;

            string Query = "(SELECT *  FROM (   Select '1' as ID, count(*)  as S_Notify from (SELECT count(tbl_product.product_id)  from tbl_product where tbl_product.status_new = 'Critical Level' group by tbl_product.product_id order by count(tbl_product.product_id)) as DerivedTableAlias) AS A) UNION (SELECT *  FROM ( Select '3' as ID, count(*) as S_Notify from (SELECT * FROM tbl_order where tbl_order.status = 'Ordered' and tbl_order.total_due != 0.00 or tbl_order.status = 'Overdue Ordered' and tbl_order.total_due != 0.00 group by tbl_order.product_id, tbl_order.supplier_id, tbl_order.status, tbl_order.date_expected, tbl_order.date_ordered order by count(tbl_order.order_id) desc) as DerivedTableAlias) AS B) UNION (SELECT *  FROM ( Select '2' as ID, count(*) as S_Notify from (SELECT * FROM tbl_order where tbl_order.status = 'Pending Ordered' group by tbl_order.product_id, tbl_order.supplier_id, tbl_order.status, tbl_order.date_expected, tbl_order.date_ordered order by count(tbl_order.order_id) desc) as DerivedTableAlias) AS C) UNION (SELECT *  FROM ( Select '4' as ID, count(*) as S_Notify from (SELECT * FROM tbl_order where tbl_order.status = 'Received'group by tbl_order.product_id, tbl_order.supplier_id, tbl_order.status, tbl_order.date_expected, tbl_order.date_ordered order by count(tbl_order.order_id) desc) as DerivedTableAlias) as D) UNION (SELECT *  FROM ( Select '5' as ID, count(*) as S_Notify from (SELECT * FROM tbl_order where tbl_order.status = 'Backorder' and tbl_order.subStatus1 = 'Uncheck' group by tbl_order.product_id, tbl_order.supplier_id, tbl_order.status, tbl_order.date_expected, tbl_order.date_ordered order by count(tbl_order.order_id) desc) as DerivedTableAlias) AS E)";
            MySqlCommand cmd = new MySqlCommand(Query, Conn);
            MySqlDataReader myReader;


            try
            {

                myReader = cmd.ExecuteReader();

                while (myReader.Read())
                {





                    int ID = myReader.GetInt32("ID");

                    if (ID == 1)
                    {
                        lblN1.Text = myReader.GetString("S_Notify");

                    }

                    if (ID == 2)
                    {
                        lblN2.Text = myReader.GetString("S_Notify");
                    }

                    if (ID == 3)
                    {
                        lblN3.Text = myReader.GetString("S_Notify");
                    }
                    if (ID == 4)
                    {
                        lblN4.Text = myReader.GetString("S_Notify");
                    }
                    if (ID == 5)
                    {
                        lblbackorder.Text = myReader.GetString("S_Notify");
                    }


                    if (int.Parse(lblN1.Text) == 0)
                    {
                        lblN1.Visible = false;
                        cbCritical.Visible = false;
                    }
                    else
                    {
                        lblN1.Visible = true;
                        cbCritical.Visible = true;
                    }
                    if (int.Parse(lblN2.Text) == 0)
                    {
                        lblN2.Visible = false;
                    }
                    else
                    {
                        lblN2.Visible = true;
                    }
                    if (int.Parse(lblN3.Text) == 0)
                    {
                        lblN3.Visible = false;
                    }
                    else
                    {
                        lblN3.Visible = true;
                    }
                    if (int.Parse(lblN4.Text) == 0)
                    {
                        lblN4.Visible = false;
                    }
                    else
                    {
                        lblN4.Visible = true;
                    }

                    if (int.Parse(lblbackorder.Text) == 0)
                    {
                        lblbackorder.Visible = false;
                    }
                    else
                    {
                        lblbackorder.Visible = true;
                    }



                }
                Conn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error2");
            }
        }

        private void lblN1_Click(object sender, EventArgs e)
        {

        }

        private void btnCR_MouseHover(object sender, EventArgs e)
        {
            //if (cbCritical.Size == new Size(0, 24))
            //{
            //    cbCritical.Size = new Size(223, 24);
            //    cbCritical.DroppedDown = true;
            //}
            //else
            //{
            //    cbCritical.Size = new Size(0, 0);
            //    cbCritical.DroppedDown = false;
            //}
        }

        private void btnCR_MouseLeave(object sender, EventArgs e)
        {
          
        }

        private void tabPage4_MouseHover(object sender, EventArgs e)
        {
            cbCritical.Size = new Size(0, 24);
        }

        private void metroGrid4_MouseHover(object sender, EventArgs e)
        {
            cbCritical.Size = new Size(0, 24);
        }

        private void metroGrid2_MouseHover(object sender, EventArgs e)
        {
            cbCritical.Size = new Size(0, 24);
        }

        private void groupBox2_MouseHover(object sender, EventArgs e)
        {
            cbCritical.Size = new Size(0, 24);
        }

        private void btnReceive1_Click(object sender, EventArgs e)
        {
            cbCritical.Size = new Size(0, 24);
            btnCancel.Visible = false;
            MySqlConnection Conn = ConString.Connection;
            DataTable dt = new DataTable();

            MySqlDataAdapter sda = new MySqlDataAdapter("SELECT tbl_order.order_id as 'Order ID', tbl_product.product_name as 'Product', tbl_order.status as 'Status', sum(tbl_order.total_due) as 'Total Due', sum(tbl_order.quantity) as 'Ordered QTY', tbl_order.quantity_receive as 'QTY Received', tbl_order.damage_product as 'Backorder QTY', tbl_supplierinfo.company as 'Supplier Name' ,tbl_order.date_ordered as 'Date Ordered', tbl_order.date_expected as 'Delivery Date', tbl_product.product_id as 'Product ID', tbl_product.stock as 'Stock', tbl_order.supplier_id as 'Supplier ID', timestampdiff(day, date(now()), date_expected) as 'Days Left' FROM tbl_order inner join tbl_product on tbl_order.product_id = tbl_product.product_id inner join tbl_supplierinfo on tbl_order.supplier_id = tbl_supplierinfo.supplier_id  where tbl_order.status = 'Received' " +
                "group by tbl_order.product_id, tbl_order.supplier_id, tbl_order.status, tbl_order.date_expected, tbl_order.date_ordered order by tbl_order.order_id desc;", Conn);
            sda.Fill(dt);
            Conn.Close();
            dataGridView1.DataSource = dt;

            dataGridView1.Columns[10].Visible = false;
            dataGridView1.Columns[11].Visible = false;
            dataGridView1.Columns[12].Visible = false;
            dataGridView1.Columns[3].Visible = true;
            dataGridView1.Columns[4].Visible = true;
            dataGridView1.Columns[5].Visible = true;
            dataGridView1.Columns[6].Visible = true;
            dataGridView1.Columns[7].Visible = true;
            dataGridView1.Columns[8].Visible = true;
            changeRowColor1();
            if(int.Parse(lblN4.Text) == 0)
            {
                DGVOrder();
            }

        }

        private void btnPending_Click(object sender, EventArgs e)
        {
            cbCritical.Size = new Size(0, 24);

            MySqlConnection Conn = ConString.Connection;
            DataTable dt = new DataTable();

            MySqlDataAdapter sda = new MySqlDataAdapter("SELECT tbl_order.order_id as 'Order ID', tbl_product.product_name as 'Product', tbl_order.status as 'Status', sum(tbl_order.total_due) as 'Total Due', sum(tbl_order.quantity) as 'Ordered QTY', tbl_order.quantity_receive as 'QTY Received', tbl_order.damage_product as 'Backorder QTY', tbl_supplierinfo.company as 'Supplier Name' ,tbl_order.date_ordered as 'Date Ordered', tbl_order.date_expected as 'Delivery Date', tbl_product.product_id as 'Product ID', tbl_product.stock as 'Stock', tbl_order.supplier_id as 'Supplier ID', timestampdiff(day, date(now()), date_expected) as 'Days Left' FROM tbl_order inner join tbl_product on tbl_order.product_id = tbl_product.product_id inner join tbl_supplierinfo on tbl_order.supplier_id = tbl_supplierinfo.supplier_id  where tbl_order.status = 'Pending Ordered' " +
                "group by tbl_order.product_id, tbl_order.supplier_id, tbl_order.status, tbl_order.date_expected, tbl_order.date_ordered order by tbl_order.order_id desc;", Conn);
            sda.Fill(dt);
            Conn.Close();
            dataGridView1.DataSource = dt;


            dataGridView1.Columns[10].Visible = false;
            dataGridView1.Columns[11].Visible = false;
            dataGridView1.Columns[12].Visible = false;
            dataGridView1.Columns[3].Visible = true;
            dataGridView1.Columns[4].Visible = true;
            dataGridView1.Columns[5].Visible = true;
            dataGridView1.Columns[6].Visible = true;
            dataGridView1.Columns[7].Visible = true;
            dataGridView1.Columns[8].Visible = true;
            changeRowColor1();
            if (int.Parse(lblN2.Text) == 0)
            {
                DGVOrder();
            }
        }

        private void btnSP_Click(object sender, EventArgs e)
        {
            btnCancel.Visible = false;
            cbCritical.Size = new Size(0, 24);

            MySqlConnection Conn = ConString.Connection;
            DataTable dt = new DataTable();

            MySqlDataAdapter sda = new MySqlDataAdapter("SELECT tbl_order.order_id as 'Order ID', tbl_product.product_name as 'Product', tbl_order.status as 'Status', sum(tbl_order.total_due) as 'Total Due', sum(tbl_order.quantity) as 'Ordered QTY', tbl_order.quantity_receive as 'QTY Received', tbl_order.damage_product as 'Backorder QTY', tbl_supplierinfo.company as 'Supplier Name' ,tbl_order.date_ordered as 'Date Ordered', tbl_order.date_expected as 'Delivery Date', tbl_product.product_id as 'Product ID', tbl_product.stock as 'Stock', tbl_order.supplier_id as 'Supplier ID', timestampdiff(day, date(now()), date_expected) as 'Days Left' FROM tbl_order inner join tbl_product on tbl_order.product_id = tbl_product.product_id inner join tbl_supplierinfo on tbl_order.supplier_id = tbl_supplierinfo.supplier_id  where " +
                "tbl_order.status = 'Ordered' and tbl_order.total_due != 0.00 or tbl_order.status = 'Overdue Ordered' and tbl_order.total_due != 0.00 " +
                "group by tbl_order.product_id, tbl_order.supplier_id, tbl_order.status, tbl_order.date_expected, tbl_order.date_ordered order by tbl_order.order_id desc;", Conn);
            sda.Fill(dt);
            Conn.Close();
            dataGridView1.DataSource = dt;


            changeRowColor1();

            dataGridView1.Columns[10].Visible = false;
            dataGridView1.Columns[11].Visible = false;
            dataGridView1.Columns[12].Visible = false;
            dataGridView1.Columns[3].Visible = true;
            dataGridView1.Columns[4].Visible = true;
            dataGridView1.Columns[5].Visible = true;
            dataGridView1.Columns[6].Visible = true;
            dataGridView1.Columns[7].Visible = true;
            dataGridView1.Columns[8].Visible = true;
            if (int.Parse(lblN3.Text) == 0)
            {
                DGVOrder();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            sublblcritical.Text = "";
            lblcritical.Text = "";
         
            btnCancel.Visible = true;
            DGVOrder();

            ByNotifyWarehouse();
            dataGridView1.Columns[3].Visible = true;
            dataGridView1.Columns[4].Visible = true;
            dataGridView1.Columns[5].Visible = true;
            dataGridView1.Columns[6].Visible = true;
            dataGridView1.Columns[7].Visible = true;
            dataGridView1.Columns[8].Visible = true;
            dataGridView1.Columns[13].Visible = true;
            cbCritical.Size = new Size(0, 24);
        }

        private void btnRefresh_MouseHover(object sender, EventArgs e)
        {
            cbCritical.Size = new Size(0, 24);
        }

        private void changeRowColor1()
        {
            try
            {


                foreach (DataGridViewRow Myrow in dataGridView1.Rows)
                {
                    if (Myrow.Cells["Status"].Value.ToString() == "Received")
                    {
                        //Myrow.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFC0CB");
                        //Myrow.DefaultCellStyle.ForeColor = System.Drawing.Color.White;

                    }
                    else if (Myrow.Cells["Status"].Value.ToString() == "Ordered")
                    {
                        Myrow.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFF00");

                        Myrow.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;

                    }
                    else if (Myrow.Cells["Status"].Value.ToString() == "Overdue Ordered")
                    {
                        Myrow.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#F78000");

                        Myrow.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;

                    }
                    else if (Myrow.Cells["Status"].Value.ToString() == "Pending Ordered")
                    {
                        Myrow.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#AAF726");

                        Myrow.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;

                    }
                    else if (Myrow.Cells["Status"].Value.ToString() == "Backorder")
                    {
                        Myrow.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF8000");

                        Myrow.DefaultCellStyle.ForeColor = System.Drawing.Color.White;

                    }
                    //else if (Myrow.Cells["Status"].Value.ToString() == "Out of Stocked")
                    //{
                    //    Myrow.DefaultCellStyle.BackColor = System.Drawing.Color.Red;
                    //    Myrow.DefaultCellStyle.ForeColor = System.Drawing.Color.White;

                    //}
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }
        //public void subPO()
        //{
        //    MySqlConnection Conn = ConString.Connection;




        //    string Query = "Select tbl_product.product_name as 'Product', sum(tbl_order.quantity) as 'QTY', sum(tbl_order.total_due) as 'Price', tbl_product.product_id as 'Product ID' from tbl_order inner join tbl_product on tbl_order.product_id = tbl_product.product_id where tbl_order.supplier_id = '" + suppID + "' and tbl_order.status = 'Punched' group by tbl_order.product_id";
        //    MySqlCommand cmd = new MySqlCommand(Query, Conn);
        //    MySqlDataReader myReader;

        //    try
        //    {

        //        myReader = cmd.ExecuteReader();

        //        while (myReader.Read())
        //        {

        //            mPrice = myReader.GetDecimal("Price");
        //            mQTY = myReader.GetInt32("QTY");

        //            txtTotal.Text = mPrice.ToString();
        //        }

        //        Conn.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Error13");
        //    }
        //}
        public void DGVPurchaseOrder()
        {
          
            // string Query = "Select * from tbl_order where supplier_id = '" + getsupplier_id + "' and status = 'Punched' ";
            MySqlConnection Conn = ConString.Connection;
            MySqlCommand cmd = new MySqlCommand("Select tbl_product.product_name as 'Product', sum(tbl_order.quantity) as 'QTY', sum(tbl_order.total_due) as 'Price', tbl_product.product_id as 'Product ID', tbl_supplierinfo.supplier_id as 'Supplier ID' from tbl_order inner join tbl_product on tbl_order.product_id = tbl_product.product_id inner join tbl_supplierinfo on  tbl_supplierinfo.supplier_id = tbl_order.supplier_id  where tbl_order.supplier_id = '" + suppID + "' and tbl_order.status = 'Punched' group by tbl_order.product_id", Conn);
            cmd.CommandTimeout = 0;


            try
            {

                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmd;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bSource = new BindingSource();
                bSource.DataSource = dbdataset;
                metroGrid3.DataSource = bSource;
                sda.Update(dbdataset);

                MySqlDataReader myReader;
                myReader = cmd.ExecuteReader();


                metroGrid3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

                Conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            Conn.Close();

           // metroGrid3.Columns[2].Visible = false;
            metroGrid3.Columns[3].Visible = false;
            metroGrid3.Columns[4].Visible = false;
        }

        public void DGVListofProducts()
        {

            // string Query = "Select * from tbl_order where supplier_id = '" + getsupplier_id + "' and status = 'Punched' ";
            MySqlConnection Conn = ConString.Connection;
            MySqlCommand cmd = new MySqlCommand("select tbl_product.product_id as 'Product ID', tbl_product.product_name as 'Product Name', tbl_product.product_price as 'Price', tbl_product.supplier_id as 'Supplier ID'from tbl_product left join tbl_supplierinfo on tbl_product.supplier_id = tbl_supplierinfo.supplier_id", Conn);
            cmd.CommandTimeout = 0;


            try
            {

                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmd;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bSource = new BindingSource();
                bSource.DataSource = dbdataset;
                metroGrid2.DataSource = bSource;
                sda.Update(dbdataset);

                MySqlDataReader myReader;
                myReader = cmd.ExecuteReader();


                metroGrid2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

                Conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            Conn.Close();
        }
        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btneditdeliver_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            var form = new frm_DeliverProduct();
            form.ShowDialog();
         
            DGVOrder();
            ByNotifyWarehouse();

        }

        private void btnPrintPurchase_Click(object sender, EventArgs e)
        {
            try
            {
                if (!metroGrid3.Rows[metroGrid3.CurrentCell.RowIndex].IsNewRow)
                {
                    foreach (DataGridViewCell cell in metroGrid3.Rows[metroGrid3.CurrentCell.RowIndex].Cells)
                    {
                        btnPrintPurchase.Enabled = true;
                        btnPrintPurchase.BackColor = System.Drawing.ColorTranslator.FromHtml("#24262F");






                        if (cell.Value == System.DBNull.Value)
                        {

                        }
                    }


                }
            }
            catch (NullReferenceException)
            {
                btnPrintPurchase.Enabled = false;
                btnPrintPurchase.BackColor = Color.DarkGray;
                btnPrintPurchase.ForeColor = Color.White;
                if (btnPrintPurchase.Enabled == false)
                {
                    Cursor.Current = Cursors.AppStarting;
                }

                return;
            }


            //string titlereport = "Purchase Order";
            //DGVPrinter printer = new DGVPrinter();
            //printer.Title = titlereport;
            //printer.SubTitle = string.Format("Date: {0}", lblTime.Text);
            //printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            //printer.PageNumbers = true;
            //printer.PageNumberInHeader = false;
            //printer.PorportionalColumns = true;
            //printer.HeaderCellAlignment = StringAlignment.Near;
            //printer.Footer = "Fabula's Merchandise.";
            //printer.FooterSpacing = 15;
            //printer.PrintDataGridView(metroGrid3);

          
            try
            {
                //if (cbSupplier.Text == "" || cbProductName.Text == "" || cbContactPerson.Text == "" || cbUnitPrice.Text == "" || txtAmountQTY.Text == "" || txtAmountQTY.Enabled == false)
                //{
                //    MessageBox.Show("Please enter require fields.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.None);
                //    return;
                //}
                DateTime date3 = dateTimePicker1.Value;
                DateTime date4 = dateExpected.Value;

                TimeSpan difference1 = date4.Subtract(date3);
                if ((date4 < date3 && dateTimePicker1.Text != dateExpected.Text))
                {
                    MessageBox.Show("The date doesn't look right. Be sure to use the actual date.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dateExpected.Text = dateTimePicker1.Text;
                }

                if (dateExpected.Text != dateOrdered.Text)
                {



                    Cursor.Current = Cursors.WaitCursor;

                    PrintDialog printDialog = new PrintDialog();

                    PrintDocument printDocument = new PrintDocument();

                    printDialog.Document = printDocument;

                    printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocument1_PrintPage);
                    printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocument1_PrintPage);
                    printPreviewDialog1.Document = printDocument1;
                    //  printPreviewDialog1.ShowDialog();



                    DialogResult result = printPreviewDialog1.ShowDialog();

                    MySqlConnection Conn = ConString.Connection;
                    MySqlDataReader myReader;

                    Cursor.Current = Cursors.WaitCursor;



                    string ordered = "Pending Ordered";


                    string Query = "update tbl_order set quantity_receive = 0, damage_product = 0, date_ordered = '" + dateOrdered.Text + "', date_expected = '" + dateExpected.Text + "', status = '" + ordered + "' where supplier_id = '" + suppID + "' and status = 'Punched'";

                    MySqlCommand cmd = new MySqlCommand(Query, Conn);
                    cmd.CommandTimeout = 50000;




                    try
                    {

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




                        Conn.Close();




                        MessageBox.Show("Ordered successfully.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                    }
                    catch (FormatException ex1)
                    {
                        MessageBox.Show(ex1.Message);
                    }
                    CriticalLevel1();
                    txtAmountQTY.Text = "";

                    txtAmountQTY.Enabled = true;
                    cbSupplier.SelectedIndex = -1;
                    cbContactPerson.SelectedIndex = -1;
                    cbProductName.Text = "";
                    cbUnitPrice.Text = "";
                    cbProductName.Enabled = false;
                    txtSearch2.Text = "";
                    btnOrder.Enabled = false;
                    btnOrder.BackColor = Color.DarkGray;
                    txtSearch2.Text = "Search";
                    txtSearch2.ForeColor = SystemColors.GrayText;
                    dataGridView1.Focus();
                    DGVPurchaseOrder();
                    PendingOrdered();
                    DGVOrder();
                    int num;
                    Random rand = new Random();
                    num = rand.Next(100, 999);
                    mPO = Convert.ToString(num);
                    ByNotifyWarehouse();
                    btnPrintPurchase.Enabled = false;
                    btnPrintPurchase.BackColor = Color.DarkGray;
                    btnPrintPurchase.ForeColor = Color.White;


                    if (btnPrintPurchase.Enabled == false)
                    {
                        Cursor.Current = Cursors.AppStarting;
                    }


                    txtSubtotal.Text = "";
                    txtSalestax.Text = "";
                    txtQTY.Text = "";
                    txtTotal.Text = "";

                    btnAddtoCart.Enabled = false;

                    btnAddtoCart.BackColor = Color.DarkGray;
               
                }
                else if (MessageBox.Show("Do you want to set Delivery Date?", "Fabula's Merchandise System", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes && dateExpected.Text == dateOrdered.Text)
                {
                    var form = new frm_shipping();
                    form.ShowDialog();
                    dateExpected.Text = frm_shipping.mDateDelivery;

                    ok = frm_shipping.ok;
                    cancel = frm_shipping.cancel;

               
                  
                }
                else
                {

                    Cursor.Current = Cursors.WaitCursor;

                    PrintDialog printDialog = new PrintDialog();

                    PrintDocument printDocument = new PrintDocument();

                    printDialog.Document = printDocument;

                    printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocument1_PrintPage);
                    printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocument1_PrintPage);
                    printPreviewDialog1.Document = printDocument1;
                    //  printPreviewDialog1.ShowDialog();



                    DialogResult result = printPreviewDialog1.ShowDialog();

                    MySqlConnection Conn = ConString.Connection;
                    MySqlDataReader myReader;

                    Cursor.Current = Cursors.WaitCursor;
                    dateOrdered.Text = DateTime.Now.ToString("yyyy-MM-dd");
                    dateExpected.Text = DateTime.Now.ToString("yyyy-MM-dd");
                    string ordered = "Ordered";
                    string Query = "update tbl_order set quantity_receive = 0, damage_product = 0, date_ordered = '" + dateOrdered.Text + "', date_expected = '" + dateExpected.Text + "', status = '" + ordered + "' where supplier_id = '" + suppID + "' and status = 'Punched'";

                    MySqlCommand cmd = new MySqlCommand(Query, Conn);
                    cmd.CommandTimeout = 50000;




                    try
                    {

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


                        Conn.Close();



                        MessageBox.Show("Ordered successfully.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        ByNotifyWarehouse();


                    }
                    catch (FormatException ex1)
                    {
                        MessageBox.Show(ex1.Message);
                    }
                    CriticalLevel1();
                    txtAmountQTY.Text = "";

                    txtAmountQTY.Enabled = true;
                    cbSupplier.SelectedIndex = -1;
                    cbContactPerson.SelectedIndex = -1;
                    cbProductName.Text = "";
                    cbUnitPrice.Text = "";
                    cbProductName.Enabled = false;
                    dataGridView1.Focus();
                    DGVPurchaseOrder();
                    Ordered();
                    DGVOrder();

                    ByNotifyWarehouse();

                    btnPrintPurchase.Enabled = false;
                    btnPrintPurchase.BackColor = Color.DarkGray;
                    btnPrintPurchase.ForeColor = Color.White;
                    int num;
                    Random rand = new Random();
                    num = rand.Next(100, 999);
                    mPO = Convert.ToString(num);
                    if (btnPrintPurchase.Enabled == false)
                    {
                        Cursor.Current = Cursors.AppStarting;
                    }


                    txtSubtotal.Text = "";
                    txtSalestax.Text = "";
                    txtQTY.Text = "";
                    txtTotal.Text = "";


                    btnAddtoCart.Enabled = false;

                    btnAddtoCart.BackColor = Color.DarkGray;

                }

            
            }
            catch (Exception ex1)
            {
                MessageBox.Show(ex1.Message);
            }

            ByNotifyWarehouse();

            
        }

        private void label22_Click(object sender, EventArgs e)
        {

           
           

        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {

            try
            {







                txtTotal.Text = string.Format("{0:n}", double.Parse(txtTotal.Text));
            }
            catch (Exception)
            {

            }
        }

        private void txtSalestax_TextChanged(object sender, EventArgs e)
        {
            try
            {







                txtSalestax.Text = string.Format("{0:n}", double.Parse(txtSalestax.Text));
            }
            catch (Exception)
            {

            }
        }

        private void txtSubtotal_TextChanged(object sender, EventArgs e)
        {
            try
            {







                txtSubtotal.Text = string.Format("{0:n}", double.Parse(txtSubtotal.Text));
            }
            catch (Exception)
            {

            }
        }

        private void metroGrid3_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewCell cell = null;
            foreach (DataGridViewCell selectedCell in metroGrid3.SelectedCells)
            {
                cell = selectedCell;
                break;
            }

            if (cell != null)
            {

                DataGridViewRow row = cell.OwningRow;
                P_Productid = row.Cells[3].Value.ToString();

               suppID = Convert.ToInt32(row.Cells[4].Value);



            }
        }

        private void metroGrid3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (!metroGrid3.Rows[metroGrid3.CurrentCell.RowIndex].IsNewRow)
                {
                    foreach (DataGridViewCell cell in metroGrid3.Rows[metroGrid3.CurrentCell.RowIndex].Cells)
                    {
                        btnPrintPurchase.Enabled = true;
                        btnPrintPurchase.BackColor = System.Drawing.ColorTranslator.FromHtml("#24262F");

                        if (cell.Value == System.DBNull.Value)
                        {
                            
                        }
                    }


                }
            }
            catch (Exception)
            {
                btnPrintPurchase.Enabled = false;
                btnPrintPurchase.BackColor = Color.DarkGray;
                btnPrintPurchase.ForeColor = Color.White;
                if(btnPrintPurchase.Enabled == false)
                {
                    Cursor.Current = Cursors.AppStarting;
                }

                return;
            }
        }

        private void metroGrid3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                if (!metroGrid3.Rows[metroGrid3.CurrentCell.RowIndex].IsNewRow)
                {
                    foreach (DataGridViewCell cell in metroGrid3.Rows[metroGrid3.CurrentCell.RowIndex].Cells)
                    {
                        btnPrintPurchase.Enabled = true;
                        btnPrintPurchase.BackColor = System.Drawing.ColorTranslator.FromHtml("#24262F");






                        if (cell.Value == System.DBNull.Value)
                        {

                        }
                    }


                }
            }
            catch (Exception)
            {
                btnPrintPurchase.Enabled = false;
                btnPrintPurchase.BackColor = Color.DarkGray;
                btnPrintPurchase.ForeColor = Color.White;
                if (btnPrintPurchase.Enabled == false)
                {
                    Cursor.Current = Cursors.AppStarting;
                }

                return;
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {

            try
            {
                if (!metroGrid3.Rows[metroGrid3.CurrentCell.RowIndex].IsNewRow)
                {
                    foreach (DataGridViewCell cell in metroGrid3.Rows[metroGrid3.CurrentCell.RowIndex].Cells)
                    {
                       






                        if (cell.Value == System.DBNull.Value)
                        {

                        }
                    }


                }
            }
            catch (NullReferenceException)
            {
              

                return;
            }


            MySqlConnection Conn = ConString.Connection;
            MySqlDataReader myReader;

            Cursor.Current = Cursors.WaitCursor;



            string removed = "Removed";


            string Query = "update tbl_order set  status = '" + removed + "' where supplier_id = '" + suppID + "' and status = 'Punched' and product_id = '"+P_Productid+"'";

            MySqlCommand cmd = new MySqlCommand(Query, Conn);
            cmd.CommandTimeout = 50000;




            try
            {

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



                MessageBox.Show("Removed successfully.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Conn.Close();




            }
            catch (FormatException ex1)
            {
                MessageBox.Show(ex1.Message);
            }
          
            DGVPurchaseOrder();
            total();
         
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {


            try
            {
                if (!dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].IsNewRow)
                {
                    foreach (DataGridViewCell cell in dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells)
                    {







                        if (cell.Value == System.DBNull.Value)
                        {

                        }
                    }


                }
            }
            catch (NullReferenceException)
            {


                return;
            }
            if (statusss == "Ordered" || statusss == "Overdue Ordered"|| statusss == "Received")
            {
                MessageBox.Show("You can't cancel this order(s)", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            CancelledOrders();
            DGVOrder();
            ByNotifyWarehouse();

        }

        private void txtAmountQTY_TextChanged(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
          
        
                Graphics graphic = e.Graphics;

                Font font = new Font("Century Gothic", 16);
                Font font1 = new Font("Century Gothic", 16, FontStyle.Bold);

                float fontHeight = font.GetHeight();

                int startX = 10;
                int startY = 480;
                int offset = 40;

            //Bitmap bmp = Properties.Resources.companysample1;
            //Image newImage = bmp;

            Point loc = new Point(165, 20);

            e.Graphics.DrawImage(Properties.Resources.f_m1, loc);

        







            e.Graphics.DrawString("___________________________________________________________________________________________________________________________________________________________________________________________ ", new Font("Century Gothic", 16, FontStyle.Bold), Brushes.Black, new Point(0, 210));



            e.Graphics.DrawString("P.O NO.  ", new Font("Century Gothic", 16, FontStyle.Bold), Brushes.Black, new Point(10, 240));
            e.Graphics.DrawString(mPO, new Font("Century Gothic", 16, FontStyle.Regular), Brushes.Black, new Point(155, 240));

            e.Graphics.DrawString("Date: ", new Font("Century Gothic", 16, FontStyle.Bold), Brushes.Black, new Point(10, 270));
            e.Graphics.DrawString(lblTime.Text, new Font("Century Gothic", 16, FontStyle.Regular), Brushes.Black, new Point(155, 270));

            e.Graphics.DrawString("Delivery Date: ", new Font("Century Gothic", 14, FontStyle.Bold), Brushes.Black, new Point(10, 300));
            e.Graphics.DrawString(dateExpected.Text, new Font("Century Gothic", 16, FontStyle.Regular), Brushes.Black, new Point(155, 300));




            e.Graphics.DrawString("Supplier: ", new Font("Century Gothic", 16, FontStyle.Bold), Brushes.Black, new Point(10, 330));
                e.Graphics.DrawString(cbSupplier.Text, new Font("Century Gothic", 16, FontStyle.Regular), Brushes.Black, new Point(155, 330));


         

           
                e.Graphics.DrawString("Address: ", new Font("Century Gothic", 16, FontStyle.Bold), Brushes.Black, new Point(10, 360));
                e.Graphics.DrawString(mStreet +" "+ mBarangay + " " + mCity , new Font("Century Gothic", 16, FontStyle.Regular), Brushes.Black, new Point(155, 360));
         



            //  e.Graphics.DrawImage(newImage, 20, 20, newImage.Width, newImage.Height);


            e.Graphics.DrawString("Phone: ", new Font("Century Gothic", 16, FontStyle.Bold), Brushes.Black, new Point(10, 390));
            e.Graphics.DrawString("(46)779-2549", new Font("Century Gothic", 16, FontStyle.Regular), Brushes.Black, new Point(155, 390));



            e.Graphics.DrawString("Mobile: ", new Font("Century Gothic", 16, FontStyle.Bold), Brushes.Black, new Point(10, 420));
            e.Graphics.DrawString(mContact, new Font("Century Gothic", 16, FontStyle.Regular), Brushes.Black, new Point(155, 420));


            e.Graphics.DrawString("Email: ", new Font("Century Gothic", 16, FontStyle.Bold), Brushes.Black, new Point(10, 450));
            e.Graphics.DrawString(mEmail, new Font("Century Gothic", 16, FontStyle.Regular), Brushes.Black, new Point(155, 450));

         



     
            e.Graphics.DrawString("___________________________________________________________________________________________________________________________________________________________________________________________ ", new Font("Century Gothic", 16, FontStyle.Bold), Brushes.Black, new Point(0, 470));

            e.Graphics.DrawString("PRODUCT ", new Font("Century Gothic", 16, FontStyle.Bold), Brushes.Black, new Point(10, 510));
            e.Graphics.DrawString("QTY ", new Font("Century Gothic", 16, FontStyle.Bold), Brushes.Black, new Point(400, 510));
            e.Graphics.DrawString("UNIT PRICE", new Font("Century Gothic", 16, FontStyle.Bold), Brushes.Black, new Point(700, 510));



            MySqlConnection Conn = ConString.Connection;




                string Query = "Select tbl_product.product_name as 'Product', sum(tbl_order.quantity) as 'QTY', sum(tbl_order.total_due) as 'Price', tbl_product.product_id as 'Product ID' from tbl_order inner join tbl_product on tbl_order.product_id = tbl_product.product_id where tbl_order.supplier_id = '" + suppID + "' and tbl_order.status = 'Punched' group by tbl_order.product_id";
                MySqlCommand cmd = new MySqlCommand(Query, Conn);
                MySqlDataReader myReader;

                try
                {

                    myReader = cmd.ExecuteReader();

                    while (myReader.Read())
                    {

                        mProduct = myReader.GetString("Product");
                        mPrice = myReader.GetDecimal("Price");
                        mQTY = myReader.GetInt32("QTY");
                        offset = offset + 20;
                    /// graphic.DrawString("", font, new SolidBrush(Color.Black), startX, startY + offset);

                    //graphic.DrawString(mProduct, font, new SolidBrush(Color.Black), startX, startY + offset);
                    //graphic.DrawString("                                                " + Convert.ToString(mQTY), font, new SolidBrush(Color.Black), startX, startY + offset);
                    //graphic.DrawString("                                                                          " + Convert.ToString(mPrice), font, new SolidBrush(Color.Black), startX, startY + offset);
                    //  graphic.DrawString("__________________________________________________", font, new SolidBrush(Color.Black), startX, startY + offset);
                    graphic.DrawString(mProduct, font, new SolidBrush(Color.Black), startX, startY + offset);
                    offset = offset + 5;

                    graphic.DrawString("                                                              " + Convert.ToString(mQTY), font, new SolidBrush(Color.Black), startX, startY + offset);
                    offset = offset + 5;
                    graphic.DrawString("                                                                                                                 " + Convert.ToString(mPrice), font, new SolidBrush(Color.Black), startX, startY + offset);
                }
                    Conn.Close();

                }




                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error13");
                }

                offset = offset + 20;
                graphic.DrawString("___________________________________________________________________________________________________________________________________________________________________________________________ ", font, new SolidBrush(Color.Black), 0, startY + offset);
                offset = offset + 30;
                graphic.DrawString("                                                                                               Subtotal: ", font1, new SolidBrush(Color.Black), startX, startY + offset);
                graphic.DrawString("                                                                                                                 " + txtSubtotal.Text, font, new SolidBrush(Color.Black), startX, startY + offset);

                offset = offset + 30;
                graphic.DrawString("                                                                                               Sales Tax: ", font1, new SolidBrush(Color.Black), startX, startY + offset);
                graphic.DrawString("                                                                                                                 " + txtSalestax.Text, font, new SolidBrush(Color.Black), startX, startY + offset);

                offset = offset + 30;
                graphic.DrawString("                                                                                               Total: ", font1, new SolidBrush(Color.Black), startX, startY + offset);
                graphic.DrawString("                                                                                                                 " + txtTotal.Text, font, new SolidBrush(Color.Black), startX, startY + offset);
            


         
        }

       

        private void btnEditDelivery_Click(object sender, EventArgs e)
        {
            MySqlConnection Conn = ConString.Connection;
            DataTable dt = new DataTable();

            MySqlDataAdapter sda = new MySqlDataAdapter("SELECT tbl_order.order_id as 'Order ID', tbl_product.product_name as 'Product', tbl_order.status as 'Status', sum(tbl_order.total_due) as 'Total Due', sum(tbl_order.quantity) as 'Ordered QTY', tbl_order.quantity_receive as 'QTY Received', tbl_order.damage_product as 'Backorder QTY', tbl_supplierinfo.company as 'Supplier Name' ,tbl_order.date_ordered as 'Date Ordered', tbl_order.date_expected as 'Delivery Date', tbl_product.product_id as 'Product ID', tbl_product.stock as 'Stock', tbl_order.supplier_id as 'Supplier ID', timestampdiff(day, date(now()), date_expected) as 'Days Left' FROM tbl_order inner join tbl_product on tbl_order.product_id = tbl_product.product_id inner join tbl_supplierinfo on tbl_order.supplier_id = tbl_supplierinfo.supplier_id  where tbl_order.status = 'Backorder' and tbl_order.subStatus1 = 'Uncheck' " +
                "group by tbl_order.product_id, tbl_order.supplier_id, tbl_order.status, tbl_order.date_expected, tbl_order.date_ordered order by tbl_order.order_id desc;", Conn);
            sda.Fill(dt);
            Conn.Close();
            dataGridView1.DataSource = dt;
            changeRowColor1();

            dataGridView1.Columns[10].Visible = false;
            dataGridView1.Columns[11].Visible = false;
            dataGridView1.Columns[12].Visible = false;
            dataGridView1.Columns[3].Visible = true;
            dataGridView1.Columns[4].Visible = true;
            dataGridView1.Columns[5].Visible = true;
            dataGridView1.Columns[6].Visible = true;
            dataGridView1.Columns[7].Visible = true;
            dataGridView1.Columns[8].Visible = true;

            if (int.Parse(lblbackorder.Text) == 0)
            {
                DGVOrder();
            }
        }

        private void metroGrid2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       

        private void btnAddtoCart_Click(object sender, EventArgs e)
        {


            if(txtAmountQTY.Text == "" || txtAmountQTY.Text == "0" || cbProductName.Text == "" || cbUnitPrice.Text == "")
            {
                MessageBox.Show("Enter amount of QTY.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
         
            if (string.IsNullOrWhiteSpace(txtAmountQTY.Text.Trim('0')))
            {
                MessageBox.Show("Enter amount of QTY.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            productSQTY();
            dateOrdered.Text = DateTime.Now.ToString("yyyy-MM-dd");
            dateExpected.Text = DateTime.Now.ToString("yyyy-MM-dd");
            int qty = int.Parse(txtAmountQTY.Text);
            decimal price = decimal.Parse(cbUnitPrice.Text);
            decimal total_due = qty * price;
         

            MySqlConnection Conn = ConString.Connection;


             

                string Query = "insert into tbl_order (product_id, supplier_id, quantity, status, total_due) values ('"+cbProductid.Text+"', '"+suppID+"', '"+txtAmountQTY.Text+"', 'Punched', '"+total_due+"' )";
                MySqlCommand cmd = new MySqlCommand(Query, Conn);
                MySqlDataReader myReader;

                try
                {

                    myReader = cmd.ExecuteReader();

                    while (myReader.Read())
                    {



                    }

                    Conn.Close();


                MessageBox.Show("Added cart successfully.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error13");
                }

            DGVPurchaseOrder();
         //   metroGrid3.Columns[2].Visible = false;
            btnPrintPurchase.Enabled = true;
            btnPrintPurchase.BackColor = System.Drawing.ColorTranslator.FromHtml("#24262F");
            total();
            try
            {
                if (!metroGrid3.Rows[metroGrid3.CurrentCell.RowIndex].IsNewRow)
                {
                    foreach (DataGridViewCell cell in metroGrid3.Rows[metroGrid3.CurrentCell.RowIndex].Cells)
                    {
                        //btnOrder.Enabled = true;
                        //lblresultfound.Hide();
                        //btnOrder.BackColor = System.Drawing.ColorTranslator.FromHtml("#24262F");
                        lblnoorders.Visible = false;


                        if (cell.Value == System.DBNull.Value)
                        {

                        }
                    }


                }
            }
            catch (Exception)
            {
                //btnOrder.Enabled = false;
                lblnoorders.Visible = true;

                //btnOrder.BackColor = Color.DarkGray;


                return;
            }
        }

    }
}
