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
using MySql.Data.MySqlClient;
using NurseryVan_System.Database;

namespace NurseryVan_System
{
    public partial class frm_POS : Form
    {
        public static string user, storeBarangay, storeCity, storeStreet ;
        public static string myName;
        public static string surname;
        public static string date;
        public static string total;
        public static string subqty;
        public static string substock;
        public static string subproductname;
        public static string foreignproductid;
        public static int foreigncustomerid;
        public static string recoidId;
       string datetimepicker;
        public static string store;
        int store_id, storeID;


        public static int getStock;
        public static string getTotal;
        public static string getChange;
        public static string getCash;
        public static string getVAT;
        public static string getTypeOrder;
        public static string getDate;
        public static string getTime;
        public static string getProductName;
        public static string getQTY;
        public static string getPrice;
        public static string getSubTotal;
        public static string getItem;
        public static string getDiscount;
        public static string getdiscountGiven;
        public static string getDiscountName;
        public static string getPercentage;
        public static string getOperation;
        string Sold = "Sold";
        string status;


        int selectedRow;

        public frm_POS()
        {
            InitializeComponent();
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
        }
        public void generator()
        {
            NurseryVan_System.AutoGenerator.autoincrement("select max(cart_id) from subtbl_cart ", txtCartID);
        }
        public void generator2()
        {
            NurseryVan_System.AutoGenerator.autoincrement("select max(trans_id) from tbl_transactionrecord ", txtRecordID);
        }
        public void generator3()
        {
            NurseryVan_System.AutoGenerator.autoincrement("select max(customer_id) from tbl_customers ", txtCustomerID);

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
            lblDateTime.Text = DateTime.Now.ToString();
        }

        private void btnCart1_Click(object sender, EventArgs e)
        {

        }

        private void metroGrid1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void metroGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void metroGrid1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void metroGrid1_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void btnCalculator2_Click(object sender, EventArgs e)
        {

        }

        private void btnSort_Click(object sender, EventArgs e)
        {

        }

        private void btnScrollUp_Click(object sender, EventArgs e)
        {

        }

        private void btnScrollBottom_Click(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {

        }

        private void btnRefesh4_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void lblNumber1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker5_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label36_Click(object sender, EventArgs e)
        {

        }

        private void lblPriceTag1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtQty1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtQty1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtQty1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtQty1_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void lblInventory1_Click(object sender, EventArgs e)
        {

        }

        private void lblFoodName1_Click(object sender, EventArgs e)
        {

        }

        private void lblStock1_Click(object sender, EventArgs e)
        {

        }

        private void lblQty1_Click(object sender, EventArgs e)
        {

        }

        private void lblTotalPriceSymbol1_Click(object sender, EventArgs e)
        {

        }

        private void lblTotalPriceName1_Click(object sender, EventArgs e)
        {

        }

        private void lblTax1_Click(object sender, EventArgs e)
        {

        }

      

        private void btnHome_Click(object sender, EventArgs e)
        {
            var myForm = new frm_MainHomeStaff(user);
            myForm.Show();
            this.Hide();
        }

        private void txtCustomerName_Leave(object sender, EventArgs e)
        {
            if (txtCustomerName.Text.Length == 0)
            {
                txtCustomerName.Text = "Customer Name";
                txtCustomerName.ForeColor = SystemColors.GrayText;
            }
        }

        private void txtContact_Leave(object sender, EventArgs e)
        {
            if (txtContact.Text.Length == 0)
            {
                txtContact.Text = "Customer Phone #";
                txtContact.ForeColor = SystemColors.GrayText;
            }

            if (txtContact.Text == "Customer Phone #" || txtContact.Text == "")
            {
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

        private void txtCustomerName_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtCustomerName.Text.Equals(null) == true)
            {
                txtCustomerName.Text = "Customer Name";
                txtCustomerName.ForeColor = Color.Silver;
            }
            else
            {
                txtCustomerName.ForeColor = Color.Black;
            }
            if (e.KeyCode == Keys.Back)
            {
                if (txtCustomerName.Text.Length == 0)
                {
                    txtCustomerName.Text = "Customer Name";

                    txtCustomerName.ForeColor = Color.Silver;
                    Cursor.Current = Cursors.IBeam;
                }
            }
        }

        private void txtCustomerName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && char.IsDigit(e.KeyChar);

            if (txtCustomerName.Text == "Customer Name")
            {
                txtCustomerName.Text = "";
            }
        }

        private void txtCustomerName_Click(object sender, EventArgs e)
        {
            if (txtCustomerName.Text == "Customer Name")
            {
                txtCustomerName.Focus();
                txtCustomerName.Select(0, 0);

            }
        }

        private void txtContact_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtContact.Text.Equals(null) == true)
            {
                txtContact.Text = "Customer Phone #";
                txtContact.ForeColor = Color.Silver;
            }
            else
            {
                txtContact.ForeColor = Color.Black;
            }
            if (e.KeyCode == Keys.Back)
            {
                if (txtContact.Text.Length == 0)
                {


                    txtContact.Text = "Customer Phone #";

                    txtContact.ForeColor = Color.Silver;
                    Cursor.Current = Cursors.IBeam;
                }
            }
        }

        private void txtContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {


                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '+'))
                {
                    e.Handled = true;
                }

                if (txtContact.Text == "Customer Phone #")
                {
                    txtContact.Text = "";
                }
            }
            catch (Exception)
            {

            }
        }

        private void txtContact_Click(object sender, EventArgs e)
        {
            if (txtContact.Text == "Customer Phone #")
            {
                txtContact.Focus();
                txtContact.Select(0, 0);
            }
        }

        private void txtCash5_Leave(object sender, EventArgs e)
        {

            if (txtCash.Text.Length == 0)
            {
                txtCash.Text = "0.00";
                txtCash.ForeColor = SystemColors.GrayText;
            }
        }

        private void txtCash5_KeyUp(object sender, KeyEventArgs e)
        {

            if (txtCash.Text.Equals(null) == true)
            {
                txtCash.Text = "0.00";
                txtCash.ForeColor = Color.Gray;
            }
            else
            {
                txtCash.ForeColor = Color.Black;
            }
            if (e.KeyCode == Keys.Back)
            {
                if (txtCash.Text.Length == 0)
                {


                    txtCash.Text = "0.00";

                    txtCash.ForeColor = Color.Gray;
                    Cursor.Current = Cursors.IBeam;
                }
            }
        }

        private void txtCash5_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
              
                if (txtCash.Text == "0.00")
                {
                    txtCash.Text = "";
                }

                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                    (e.KeyChar != '.'))
                {
              
                    e.Handled = true;
                }


                if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
                {
                    e.Handled = true;
                   
                }

              


             
            }
            catch (Exception)
            {

            }
        }

        private void txtCash5_Click(object sender, EventArgs e)
        {
            if (txtCash.Text == "0.00")
            {
                txtCash.Focus();
                txtCash.Select(0, 0);
              
            }
          
        }

        private void txtDiscount_Leave(object sender, EventArgs e)
        {
            if (txtDiscount.Text.Length == 0)
            {
                txtDiscount.Text = "0.00";
                txtDiscount.ForeColor = SystemColors.GrayText;
            }
        }

        private void txtDiscount_KeyUp(object sender, KeyEventArgs e)
        {

            if (txtDiscount.Text.Equals(null) == true)
            {
                txtDiscount.Text = "0.00";
                txtDiscount.ForeColor = Color.Gray;
            }
            else
            {
                txtDiscount.ForeColor = Color.Black;
            }
            if (e.KeyCode == Keys.Back)
            {
                if (txtDiscount.Text.Length == 0)
                {


                    txtDiscount.Text = "0.00";

                    txtDiscount.ForeColor = Color.Gray;
                    Cursor.Current = Cursors.IBeam;
                }
            }
        }

        private void txtDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (txtDiscount.Text == "0.00")
            {
                txtDiscount.Text = "";
            }

        }

        private void txtDiscount_Click(object sender, EventArgs e)
        {
            if (txtDiscount.Text == "0.00")
            {
                txtDiscount.Focus();
                txtDiscount.Select(0, 0);

            }
        }

        private void frm_POS_FormClosing(object sender, FormClosingEventArgs e)
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
        void enable()
        {
            try
            {
                if (!dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].IsNewRow)
                {
                    foreach (DataGridViewCell cell in dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells)
                    {
                       
                        btnVoid.BackColor = Color.IndianRed;
                        btnVoid.Enabled = true;
                        if (cell.Value == System.DBNull.Value)
                        {

                        }
                    }


                }
            }
            catch (NullReferenceException)
            {
                //btnVoid.BackColor = Color.DarkGray;
                //btnVoid.Enabled = false;
           
                return;
            }

        }

        private void frm_POS_Load(object sender, EventArgs e)
        {
        
            PictureBox pic = new PictureBox();
            pic.Width = 16;
            pic.Height = 16;
            pic.Left = 200;
            pic.BackgroundImage = NurseryVan_System.Properties.Resources.search2;
            txtSearch.Controls.Add(pic);
            StillNotAvailable();


            this.AcceptButton = btnPurchase;
            lblStore.Text = frm_Login.store;
            CriticalLevel1();
            refreshCB();
           
            lblTime.Text = DateTime.Now.ToShortTimeString();
            DGVProductList();//# 1
            DGVCart();//#2
            DGVRefreshProductList();//#3
            BranchRefresh();
            DGVSUMsomecolumncart(); //#4
            DGVsubRefreshProductList();//#5
           
                dataGridView2.DefaultCellStyle.SelectionBackColor = Color.Pink;
            changeRowColor();
            //  CriticalLevel();

            // txtLeadTime.Text = "0";
            RemoveListCritical();
            subRemoveListCritical();
            AreaCriticalLevel();
            hideColumn();

            NotificationofCriticalLevel();
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;
            toolTip1.SetToolTip(this.lblqtycritical, "Critical Level ( " + lblqtycritical.Text + " )");

            int num;
            Random rand = new Random();
            num = rand.Next(1, 999999999);
            txtRef.Text = Convert.ToString(num);

            SearchList();
            StartTimer();
            tabControl1.TabPages.Remove(tabPage5);
            StillNotAvailable();
            if (frm_Login.user == "Staff")
            {
                txtName.Text = ("Staff: " )+myName + (" ") + frm_Login.surname;

                //    panelSupervisor.Visible = false;
                 
               panelSupervisor.Visible = false;
             
              
            }


            else if (frm_Login.supervisor == "Supervisor")
            {
             
                txtName.Text = ("Supervisor: " )+ myName + (" ") + frm_Login.surname;

                // pCritical.Location = new Point(251,309);
                StillNotAvailable();
            }

          
            try
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
                    txtProductID.Text = row.Cells[0].Value.ToString();
                    lblProductName.Text = row.Cells[1].Value.ToString();
                    lblUnitPrice.Text = row.Cells[3].Value.ToString();
                    lblStock.Text = row.Cells[2].Value.ToString();
                    dateOrdered.Text = row.Cells[5].Value.ToString();
                    status = row.Cells[4].Value.ToString();
                    dateTimePicker4.Text = row.Cells[6].Value.ToString();
                    //if(txtLeadTime.Text == "")
                    //{
                    //    txtLeadTime.Text = "0";
                    //    return;
                    //}

                   // txtLeadTime.Text = (dateTimePicker4.Value - dateOrdered.Value).TotalDays.ToString("#");

                    if (status == "Available")
                    {
                        dataGridView2.DefaultCellStyle.SelectionBackColor = Color.Pink;
                    }
                    else
                    {
                      //  dataGridView2.DefaultCellStyle.SelectionBackColor = Color.Red;

                    }
                }
            }
            catch (Exception)
            {

            }
            StillNotAvailable();
            storeinfo();

        }
        public void refreshCB()
        {

            MySqlConnection Conn = ConString.Connection;



            string Query = "select * from tbl_store where store_id = '" + frm_Login.global_storeid + "'";

            MySqlCommand cmd = new MySqlCommand(Query, Conn);


            DataTable dt = new DataTable();
            MySqlDataAdapter sda = new MySqlDataAdapter("select * from tbl_store where store_id = '" + frm_Login.global_storeid + "'", Conn);
            sda.Fill(dt);
            sda.SelectCommand = cmd;

            cbStore.DataSource = dt;
        

            txtstore_id.DataSource = dt;

            cbStore.DisplayMember = "store_name";
            cbStore.ValueMember = "store_name";
         
            txtstore_id.DisplayMember = "store_id";
            txtstore_id.ValueMember = "store_id";

            DataTable dbdataset = new DataTable();
            sda.Fill(dbdataset);
            BindingSource bSource = new BindingSource();

            bSource.DataSource = dbdataset;
            cbStore.DataSource = bSource;
       
            txtstore_id.DataSource = bSource;

            sda.Update(dbdataset);
            Conn.Close();
        }
        public void StillNotAvailable()
        {
            MySqlConnection Conn = ConString.Connection;


          

            string Query = "Update tbl_inventory set status= 'Critical Level', status_pending = 'Not Available' where QTY <= critical and status != 'Pending'";
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
        }
        public void NotificationofCriticalLevel()
        {

            MySqlConnection Conn = ConString.Connection;

            string Query = "Select count(*) as 'C_Branch'  from (SELECT count(tbl_store.store_id)  from tbl_inventory inner join tbl_store on tbl_store.store_id = tbl_inventory.store_id where tbl_inventory.status_pending  = 'Not Available' and tbl_inventory.store_id = '" + txtstore_id.Text+"' group by tbl_inventory.product_id order by count(tbl_inventory.product_id)) as DerivedTableAlias";
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

                    if(int.Parse(lblqtycritical.Text) == 0)
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
        void BranchRefresh()
        {

          
            MySqlConnection Conn = ConString.Connection;

            MySqlCommand cmd = new MySqlCommand("SELECT tbl_inventory.product_id as 'Product ID', tbl_product.product_name as 'Product Name', QTY, tbl_product.remarks as 'SRP', tbl_inventory.status_pending as 'Status', date_delivered as 'Date Ordered', date_expected as 'Date Expected' FROM tbl_inventory inner join tbl_product on tbl_inventory.product_id = tbl_product.product_id inner join tbl_store on tbl_inventory.store_id = tbl_store.store_id where tbl_inventory.status_pending = 'Not Available' and tbl_store.store_id = '" + frm_Login.global_storeid + "' or tbl_inventory.status_pending = 'Available' and tbl_store.store_id = '" + frm_Login.global_storeid + "' group by tbl_inventory.product_id", Conn);
            cmd.CommandTimeout = 0;

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
               


                Conn.Close();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error5");
            }

        }

        public void SearchList()
        {
            MySqlConnection Conn = ConString.Connection;


            string Query = "Select product_name from tbl_product";
            MySqlCommand cmd = new MySqlCommand(Query, Conn);
            MySqlDataReader myReader;

            AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
            try
            {

                myReader = cmd.ExecuteReader();

                while (myReader.Read())
                {
                    MyCollection.Add(myReader.GetString(0));

                }

                txtSearch.AutoCompleteCustomSource = MyCollection;
                Conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void DGVProductList()
        {

            //string Connection = "datasource=localhost;port=3306;username=root;password=1234;Max Pool Size = 200";
            //MySqlConnection Conn = new MySqlConnection(Connection);
            //MySqlCommand cmd = new MySqlCommand("SELECT product_id as 'Product ID', product_name as 'Product Name', remarks as 'Price', quantity as 'QTY', category as 'Category', stock as 'Stock', vat as 'Vat', total_price as 'Total Price' FROM tbl_product;", Conn);
            //cmd.CommandTimeout = 0;
            //try
            //{
            //    MySqlDataAdapter sda = new MySqlDataAdapter();
            //    sda.SelectCommand = cmd;
            //    DataTable dbdataset = new DataTable();
            //    sda.Fill(dbdataset);
            //    BindingSource bSource = new BindingSource();

            //    bSource.DataSource = dbdataset;
            //    dataGridView2.DataSource = bSource;
            //    sda.Update(dbdataset);
            //    dataGridView2.DefaultCellStyle.SelectionBackColor = Color.Pink;

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

        }
        void DGVCart()
        {
            MySqlConnection Conn = ConString.Connection;
            var cmd = new MySqlCommand("SELECT subtbl_cart.cart_id as 'Cart ID', subtbl_cart.product_id as 'Product No.', subtbl_cart.product_name as 'Product Name', sum(subtbl_cart.QTY) as 'Quantity', sum(subtbl_cart.Total_Price) as 'Amount Due', subtbl_cart.description as 'Category', sum(subtbl_cart.Vat) as 'VAT', tbl_product.stock as 'Remaining Stock', subtbl_cart.discount as 'Discount', subtbl_cart.discountgiven as 'Discount Given', subtbl_cart.dateortime as 'Date/Time',subtbl_cart.unit_price as 'Unit Price', date, time, s_status,tbl_store.store_id, leadtime FROM subtbl_cart inner join tbl_product on subtbl_cart.product_id = tbl_product.product_id inner join tbl_store on subtbl_cart.store_id = tbl_store.store_id where subtbl_cart.store_id = '"+frm_Login.global_storeid+"' group by tbl_product.product_id order by subtbl_cart.cart_id desc", Conn);
           // var cmd = new MySqlCommand("SELECT tbl_cart.cart_id as 'Cart ID', tbl_product.product_id as 'Product ID', tbl_product.product_name as 'Product Name', sum(tbl_cart.sold_qty) as 'QTY', sum(tbl_cart.Total_due) as 'Amount Due', sum(tbl_cart.Vat) as 'VAT', tbl_cart.date_sold as 'Date Sold',subtbl_cart.unit_price as 'Unit Price', date, time, status FROM subtbl_cart inner join tbl_product on subtbl_cart.product_id = tbl_product.product_id group by tbl_product.product_id order by subtbl_cart.cart_id desc", Conn);
            //                        // query = "select tblinventory.itemid as 'ItemCode', tblinventory.itemname as 'Item Name' , sum(tblcart.soldqty) as 'Quantity', sum(tblcart.totaldue) as 'Amount Due' from tblcart inner join tblinventory on tblcart.itemid = tblinventory.itemid where tblcart.cartid = '"+cartnumber+"' and  tblcart.statusss = '"+statee+"' group by tblinventory.itemname";
            cmd.CommandTimeout = 65000;
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
                //  metroGrid1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

                Conn.Close();

                return;
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        void DGVRefreshProductList()
        {
            //string Connection = "datasource=localhost;port=3306;username=root;password=1234;Max Pool Size = 200;";
            //MySqlConnection Conn = new MySqlConnection(Connection);
            //Conn.Open();
            //MySqlCommand cmd = new MySqlCommand("Update tbl_product set total_price = greatest (0, 0);Update tbl_product set vat = greatest (0, 0);SELECT * FROM tbl_product where product_id = 1", Conn);
            //cmd.CommandTimeout = 0;
            //MySqlDataReader myReader;

            //try
            //{
            //    myReader = cmd.ExecuteReader();
            //    while (myReader.Read())
            //    {

            //        txtProductID.Text = myReader[0].ToString();
            //        lblProductName.Text = myReader[1].ToString();
            //        lblUnitPrice.Text = myReader[19].ToString();
            //        txtQty.Text = myReader[3].ToString();
            //        lblTotalPrice.Text = myReader[4].ToString();
            //        lblStock.Text = myReader[5].ToString();
            //        lblVat.Text = myReader[6].ToString();
            //        lblDescription.Text = myReader[14].ToString();



            //    }

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "xFabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //}
        }


        public void DGVSUMsomecolumncart()
        {

            MySqlConnection Conn = ConString.Connection;
            var cmd = new MySqlCommand("SELECT SUM(QTY) as 'Quantity',SUM(total_price) as 'Total Price', sum(vat)  as 'Vat', sum(sub_Total) FROM subtbl_cart where store_id = '"+frm_Login.global_storeid+"';Update subtbl_cart set sub_total = total_price - vat", Conn);
            cmd.CommandTimeout = 65000;
            try
            {
                try
                {
                   
                    MySqlDataAdapter sda = new MySqlDataAdapter();
                    sda.SelectCommand = cmd;
                    DataTable dbdataset = new DataTable();
                    sda.Fill(dbdataset);
                    BindingSource bSource = new BindingSource();
                    bSource.DataSource = dbdataset;
                    sda.Update(dbdataset);
                    MySqlDataReader myReader;
                    myReader = cmd.ExecuteReader();

                    while (myReader.Read())
                    {
                        txtProductItemQTY.Text = myReader[0].ToString();
                        txtGrandTotal.Text = myReader[1].ToString();
                        txtVat.Text = myReader[2].ToString();
                        txtSubTotal.Text = myReader[3].ToString();

                      

                    }
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                    dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                    Conn.Close();
                }
                catch (TimeoutException)
                {
                  
                }

                MySqlConnection.ClearPool(Conn);
                return;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fabula's Merchandise System", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);

            }
            finally
            {
                Conn.Close();
            }
        }
        void getLeadTime()
        {


            MySqlConnection Conn = ConString.Connection;

            string Query = "SELECT timestampdiff(day, date(now()), date_expected) as 'LeadTime' FROM tbl_inventory where product_id = '" + txtProductID.Text + "' and status = 'Pending' and store_id = '"+frm_Login.global_storeid+"'";

            MySqlCommand cmd = new MySqlCommand(Query, Conn);
            MySqlDataReader myReader;

            try
            {

                myReader = cmd.ExecuteReader();

                while (myReader.Read())
                {

                    txtLeadTime.Text = myReader.GetString("LeadTime");

                }

                Conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error13");
            }
        }
        public void DGVsubRefreshProductList()
        {

            MySqlConnection Conn = ConString.Connection;
            var cmd = new MySqlCommand("Select * from tbl_product where product_id = '" + txtProductID.Text + "'", Conn);
            cmd.CommandTimeout = 65000;
            try
            {
               
                MySqlDataReader myReader;
                myReader = cmd.ExecuteReader();

                while (myReader.Read())
                {
                    txtProductID.Text = myReader[0].ToString();
                    lblProductName.Text = myReader[1].ToString();
                    lblUnitPrice.Text = myReader[19].ToString();
                    txtQty.Text = myReader[3].ToString();
                    lblTotalPrice.Text = myReader[4].ToString();
                    lblStock.Text = myReader[5].ToString();
                    lblVat.Text = myReader[6].ToString();
                    lblDescription.Text = myReader[14].ToString();

                }


                //     MySqlConnection.ClearPool(Conn);
                Conn.Close();
                return;

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fabula's Merchandise System", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);

            }
            finally
            {
                Conn.Close();
            }


        }
        public void CriticalLevel1()
        {
            try
            {
              

                MySqlDataReader dr;
                MySqlCommand cmd;
                string query;


                //CRITICAL LEVEL

                if (txtLeadTime.Text == "" || txtLeadTime.Text == "0")
                {
                   

                  


                    try
                    {
                        //formula
                        //SAFETY STOCK/SS
                        MySqlConnection conn = ConString.Connection;
                        query = "update tbl_inventory A inner join (select product_id, max(quantity) - min(quantity)  as 'SS' from tbl_transactionrecord where date between date_sub(NOW(),interval 360 day) and NOW() and status = 'Sold' group by product_id) B on A.product_id=B.product_id set A.ss = B.SS where a.product_id = '" + txtProductID.Text + "' and a.store_id = '" + frm_Login.global_storeid + "';";
                        //"             update tblinventory A inner join (select itemid,max(soldqty)-min(soldqty) as 'SS' from tblcart where datesold between date_sub(NOW(),interval 60 day) and NOW() and remove='No' and payment='Yes' group by itemid) B on A.itemid=B.itemid set A.ss=B.SS where a.itemid = '"+itemid+"';";
                         cmd = new MySqlCommand(query, conn);
                        dr = cmd.ExecuteReader();

                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        //  MessageBox.Show(ex.Message, "1");
                    }

                    try
                    {
                        //AVERAGE DAILY SALES
                        MySqlConnection conn = ConString.Connection;
                        query = "update tbl_inventory A inner join (SELECT product_id,avg(quantity)/1 as 'OQ' FROM tbl_transactionrecord where date between date_sub(NOW(),interval 360 day) and NOW() and status = 'Sold' group by product_id) B on A.product_id=B.product_id set A.oq=B.OQ where a.product_id = '" + txtProductID.Text + "' and a.store_id = '" + frm_Login.global_storeid + "';";
                        //             update tblinventory A inner join (SELECT itemid,avg(soldqty)/2 as 'OQ' FROM tblcart where datesold between date_sub(NOW(),interval 60 day) and NOW() and remove='No' and payment='Yes' group by itemid) B on A.itemid=B.itemid set A.OQ=B.OQ where a.itemid = '"+itemid+"' ;";
                       cmd = new MySqlCommand(query, conn);
                        dr = cmd.ExecuteReader();

                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        //   MessageBox.Show(ex.Message, "2");
                    }


                    try
                    {
                        //MAX STOCK LEVEL
                        MySqlConnection conn = ConString.Connection;
                        query = "update tbl_inventory A inner join (SELECT product_id, max(quantity) + max(quantity) - min(quantity) + avg(quantity) - (min(quantity)) as 'MAXQTY' FROM tbl_transactionrecord where date between date_sub(NOW(),interval 360 day) and NOW() and status = 'Sold' group by product_id) B on A.product_id=B.product_id set A.maxqty=B.MAXQTY where a.product_id = '" + txtProductID.Text + "' and a.store_id = '" + frm_Login.global_storeid + "';";
                        //             update tblinventory A inner join (SELECT itemid,avg(soldqty)/2 as 'OQ' FROM tblcart where datesold between date_sub(NOW(),interval 60 day) and NOW() and remove='No' and payment='Yes' group by itemid) B on A.itemid=B.itemid set A.OQ=B.OQ where a.itemid = '"+itemid+"' ;";
                        cmd = new MySqlCommand(query, conn);
                        dr = cmd.ExecuteReader();

                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        //   MessageBox.Show(ex.Message, "2");
                    }


                    try
                    {
                        //REORDER POINT
                        MySqlConnection conn = ConString.Connection;

                        query = "update tbl_inventory set rp = oq + ss  where product_id = '" + Convert.ToUInt32(txtProductID.Text) + "' and store_id = '" + Convert.ToInt32(frm_Login.global_storeid) + "' ;";
                        cmd = new MySqlCommand(query, conn);
                        dr = cmd.ExecuteReader();

                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show(ex.Message, "3");
                    }

                    try
                    {
                        //CRITICAL
                        MySqlConnection conn = ConString.Connection;
                       
                        query = "update tbl_inventory set critical=(ss + oq)/2  where product_id = '" + Convert.ToUInt32(txtProductID.Text) + "' and store_id = '" + Convert.ToInt32(frm_Login.global_storeid) + "' ;";
                         cmd = new MySqlCommand(query, conn);
                        dr = cmd.ExecuteReader();

                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show(ex.Message, "3");
                    }
                }
                else
                {
                    try
                    {
                       
                        //SAFETY STOCK/SS
                        MySqlConnection conn = ConString.Connection;
                        query = "update tbl_inventory A inner join (select product_id, max(quantity) * max(leadtime)-avg(quantity) * avg(leadtime)  as 'SS' from tbl_transactionrecord where date between date_sub(NOW(),interval 360 day) and NOW() and status = 'Sold' group by product_id) B on A.product_id=B.product_id set A.ss = B.SS where a.product_id = '" + txtProductID.Text + "' and a.store_id = '" + frm_Login.global_storeid + "';";
                        //"             update tblinventory A inner join (select itemid,max(soldqty)-min(soldqty) as 'SS' from tblcart where datesold between date_sub(NOW(),interval 60 day) and NOW() and remove='No' and payment='Yes' group by itemid) B on A.itemid=B.itemid set A.ss=B.SS where a.itemid = '"+itemid+"';";
                        cmd = new MySqlCommand(query, conn);
                        dr = cmd.ExecuteReader();

                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        //  MessageBox.Show(ex.Message, "1");
                    }

                    try
                    {
                        //AVERAGE DAILY SALES
                        MySqlConnection conn = ConString.Connection;
                        query = "update tbl_inventory A inner join (SELECT product_id,avg(quantity)/1 as 'OQ' FROM tbl_transactionrecord where date between date_sub(NOW(),interval 360 day) and NOW() and status = 'Sold' group by product_id) B on A.product_id=B.product_id set A.oq=B.OQ where a.product_id = '" + txtProductID.Text + "' and a.store_id = '" + frm_Login.global_storeid + "';";
                        //             update tblinventory A inner join (SELECT itemid,avg(soldqty)/2 as 'OQ' FROM tblcart where datesold between date_sub(NOW(),interval 60 day) and NOW() and remove='No' and payment='Yes' group by itemid) B on A.itemid=B.itemid set A.OQ=B.OQ where a.itemid = '"+itemid+"' ;";
                        cmd = new MySqlCommand(query, conn);
                        dr = cmd.ExecuteReader();

                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        //   MessageBox.Show(ex.Message, "2");
                    }



                    try
                    {
                        //LEADTIME DEMAND
                        MySqlConnection conn = ConString.Connection;
                        query = "update tbl_inventory A inner join (SELECT product_id,avg(quantity) * avg(leadtime) as 'LTD' FROM tbl_transactionrecord where date between date_sub(NOW(),interval 360 day) and NOW() and status = 'Sold' group by product_id) B on A.product_id=B.product_id set A.ltd=B.LTD where a.product_id = '" + txtProductID.Text + "' and a.store_id = '" + frm_Login.global_storeid + "';";
                        //             update tblinventory A inner join (SELECT itemid,avg(soldqty)/2 as 'OQ' FROM tblcart where datesold between date_sub(NOW(),interval 60 day) and NOW() and remove='No' and payment='Yes' group by itemid) B on A.itemid=B.itemid set A.OQ=B.OQ where a.itemid = '"+itemid+"' ;";
                        cmd = new MySqlCommand(query, conn);
                        dr = cmd.ExecuteReader();

                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        //   MessageBox.Show(ex.Message, "2");
                    }

                    try
                    {
                        //MAX STOCK LEVEL
                        MySqlConnection conn = ConString.Connection;
                        query = "update tbl_inventory A inner join (SELECT product_id, max(quantity) * max(leadtime) + max(quantity) * max(leadtime) - avg(quantity) * avg(leadtime) + avg(quantity) * avg(leadtime) - (min(quantity) * min(leadtime)) as 'MAXQTY' FROM tbl_transactionrecord where date between date_sub(NOW(),interval 360 day) and NOW() and status = 'Sold' group by product_id) B on A.product_id=B.product_id set A.maxqty=B.MAXQTY where a.product_id = '" + txtProductID.Text + "' and a.store_id = '" + frm_Login.global_storeid + "';";
                        //             update tblinventory A inner join (SELECT itemid,avg(soldqty)/2 as 'OQ' FROM tblcart where datesold between date_sub(NOW(),interval 60 day) and NOW() and remove='No' and payment='Yes' group by itemid) B on A.itemid=B.itemid set A.OQ=B.OQ where a.itemid = '"+itemid+"' ;";
                        cmd = new MySqlCommand(query, conn);
                        dr = cmd.ExecuteReader();

                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        //   MessageBox.Show(ex.Message, "2");
                    }
                    try
                    {
                        //REORDER POINT
                        MySqlConnection conn = ConString.Connection;

                        query = "update tbl_inventory set rp = LTD + SS  where product_id = '" + Convert.ToUInt32(txtProductID.Text) + "' and store_id = '" + Convert.ToInt32(frm_Login.global_storeid) + "' ;";
                        cmd = new MySqlCommand(query, conn);
                        dr = cmd.ExecuteReader();

                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show(ex.Message, "3");
                    }

                    try
                    {
                        //CRITICAL
                        MySqlConnection conn = ConString.Connection;

                        query = "update tbl_inventory set critical=(ss + oq)/2  where product_id = '" + Convert.ToUInt32(txtProductID.Text) + "' and store_id = '" + Convert.ToInt32(frm_Login.global_storeid) + "' ;";
                        cmd = new MySqlCommand(query, conn);
                        dr = cmd.ExecuteReader();

                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show(ex.Message, "3");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "4", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);

            }
        }
        public void subCriticalLevel1()
        {
            try
            {
             

                MySqlDataReader dr;
                MySqlCommand cmd;
                string query;


                //CRITICAL LEVEL

                if (txtLeadTime.Text == "" || txtLeadTime.Text == "0")
                {





                    try
                    {
                        //formula
                        //SAFETY STOCK/SS
                        MySqlConnection conn = ConString.Connection;
                        query = "update tbl_inventory A inner join (select product_id, max(quantity) - min(quantity)  as 'SS' from tbl_transactionrecord where date between date_sub(NOW(),interval 360 day) and NOW() and status = 'Sold' group by product_id) B on A.product_id=B.product_id set A.ss = B.SS where a.product_id = '" + txtProductID.Text + "' and a.store_id = '" + frm_Login.global_storeid + "';";
                        //"             update tblinventory A inner join (select itemid,max(soldqty)-min(soldqty) as 'SS' from tblcart where datesold between date_sub(NOW(),interval 60 day) and NOW() and remove='No' and payment='Yes' group by itemid) B on A.itemid=B.itemid set A.ss=B.SS where a.itemid = '"+itemid+"';";
                        cmd = new MySqlCommand(query, conn);
                        dr = cmd.ExecuteReader();

                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        //  MessageBox.Show(ex.Message, "1");
                    }

                    try
                    {
                        //AVERAGE DAILY SALES
                        MySqlConnection conn = ConString.Connection;
                        query = "update tbl_inventory A inner join (SELECT product_id,avg(quantity)/1 as 'OQ' FROM tbl_transactionrecord where date between date_sub(NOW(),interval 360 day) and NOW() and status = 'Sold' group by product_id) B on A.product_id=B.product_id set A.oq=B.OQ where a.product_id = '" + txtProductID.Text + "' and a.store_id = '" + frm_Login.global_storeid + "';";
                        //             update tblinventory A inner join (SELECT itemid,avg(soldqty)/2 as 'OQ' FROM tblcart where datesold between date_sub(NOW(),interval 60 day) and NOW() and remove='No' and payment='Yes' group by itemid) B on A.itemid=B.itemid set A.OQ=B.OQ where a.itemid = '"+itemid+"' ;";
                        cmd = new MySqlCommand(query, conn);
                        dr = cmd.ExecuteReader();

                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        //   MessageBox.Show(ex.Message, "2");
                    }


                    try
                    {
                        //MAX STOCK LEVEL
                        MySqlConnection conn = ConString.Connection;
                        query = "update tbl_inventory A inner join (SELECT product_id, max(quantity) + max(quantity) - min(quantity) + avg(quantity) - (min(quantity)) as 'MAXQTY' FROM tbl_transactionrecord where date between date_sub(NOW(),interval 360 day) and NOW() and status = 'Sold' group by product_id) B on A.product_id=B.product_id set A.maxqty=B.MAXQTY where a.product_id = '" + txtProductID.Text + "' and a.store_id = '" + frm_Login.global_storeid + "';";
                        //             update tblinventory A inner join (SELECT itemid,avg(soldqty)/2 as 'OQ' FROM tblcart where datesold between date_sub(NOW(),interval 60 day) and NOW() and remove='No' and payment='Yes' group by itemid) B on A.itemid=B.itemid set A.OQ=B.OQ where a.itemid = '"+itemid+"' ;";
                        cmd = new MySqlCommand(query, conn);
                        dr = cmd.ExecuteReader();

                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        //   MessageBox.Show(ex.Message, "2");
                    }

                    try
                    {
                        //REORDER POINT
                        MySqlConnection conn = ConString.Connection;

                        query = "update tbl_inventory set rp = oq + ss  where product_id = '" + Convert.ToUInt32(txtProductID.Text) + "' and store_id = '" + Convert.ToInt32(frm_Login.global_storeid) + "' ;";
                        cmd = new MySqlCommand(query, conn);
                        dr = cmd.ExecuteReader();

                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show(ex.Message, "3");
                    }

                    try
                    {
                        //CRITICAL
                        MySqlConnection conn = ConString.Connection;

                        query = "update tbl_inventory set critical=(ss + oq)/2  where product_id = '" + Convert.ToUInt32(txtProductID.Text) + "' and store_id = '" + Convert.ToInt32(frm_Login.global_storeid) + "' ;";
                        cmd = new MySqlCommand(query, conn);
                        dr = cmd.ExecuteReader();

                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show(ex.Message, "3");
                    }
                }
                else
                {
                    try
                    {

                        //SAFETY STOCK/SS
                        MySqlConnection conn = ConString.Connection;
                        query = "update tbl_inventory A inner join (select product_id, max(quantity) * max(leadtime)-avg(quantity) * avg(leadtime)  as 'SS' from tbl_transactionrecord where date between date_sub(NOW(),interval 360 day) and NOW() and status = 'Sold' group by product_id) B on A.product_id=B.product_id set A.ss = B.SS where a.product_id = '" + txtProductID.Text + "' and a.store_id = '" + frm_Login.global_storeid + "';";
                        //"             update tblinventory A inner join (select itemid,max(soldqty)-min(soldqty) as 'SS' from tblcart where datesold between date_sub(NOW(),interval 60 day) and NOW() and remove='No' and payment='Yes' group by itemid) B on A.itemid=B.itemid set A.ss=B.SS where a.itemid = '"+itemid+"';";
                        cmd = new MySqlCommand(query, conn);
                        dr = cmd.ExecuteReader();

                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        //  MessageBox.Show(ex.Message, "1");
                    }

                    try
                    {
                        //AVERAGE DAILY SALES
                        MySqlConnection conn = ConString.Connection;
                        query = "update tbl_inventory A inner join (SELECT product_id,avg(quantity)/1 as 'OQ' FROM tbl_transactionrecord where date between date_sub(NOW(),interval 360 day) and NOW() and status = 'Sold' group by product_id) B on A.product_id=B.product_id set A.oq=B.OQ where a.product_id = '" + txtProductID.Text + "' and a.store_id = '" + frm_Login.global_storeid + "';";
                        //             update tblinventory A inner join (SELECT itemid,avg(soldqty)/2 as 'OQ' FROM tblcart where datesold between date_sub(NOW(),interval 60 day) and NOW() and remove='No' and payment='Yes' group by itemid) B on A.itemid=B.itemid set A.OQ=B.OQ where a.itemid = '"+itemid+"' ;";
                        cmd = new MySqlCommand(query, conn);
                        dr = cmd.ExecuteReader();

                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        //   MessageBox.Show(ex.Message, "2");
                    }



                    try
                    {
                        //LEADTIME DEMAND
                        MySqlConnection conn = ConString.Connection;
                        query = "update tbl_inventory A inner join (SELECT product_id,avg(quantity) * avg(leadtime) as 'LTD' FROM tbl_transactionrecord where date between date_sub(NOW(),interval 360 day) and NOW() and status = 'Sold' group by product_id) B on A.product_id=B.product_id set A.ltd=B.LTD where a.product_id = '" + txtProductID.Text + "' and a.store_id = '" + frm_Login.global_storeid + "';";
                        //             update tblinventory A inner join (SELECT itemid,avg(soldqty)/2 as 'OQ' FROM tblcart where datesold between date_sub(NOW(),interval 60 day) and NOW() and remove='No' and payment='Yes' group by itemid) B on A.itemid=B.itemid set A.OQ=B.OQ where a.itemid = '"+itemid+"' ;";
                        cmd = new MySqlCommand(query, conn);
                        dr = cmd.ExecuteReader();

                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        //   MessageBox.Show(ex.Message, "2");
                    }

                    try
                    {
                        //MAX STOCK LEVEL
                        MySqlConnection conn = ConString.Connection;
                        query = "update tbl_inventory A inner join (SELECT product_id, max(quantity) * max(leadtime) + max(quantity) * max(leadtime) - avg(quantity) * avg(leadtime) + avg(quantity) * avg(leadtime) - (min(quantity) * min(leadtime)) as 'MAXQTY' FROM tbl_transactionrecord where date between date_sub(NOW(),interval 360 day) and NOW() and status = 'Sold' group by product_id) B on A.product_id=B.product_id set A.maxqty=B.MAXQTY where a.product_id = '" + txtProductID.Text + "' and a.store_id = '" + frm_Login.global_storeid + "';";
                        //             update tblinventory A inner join (SELECT itemid,avg(soldqty)/2 as 'OQ' FROM tblcart where datesold between date_sub(NOW(),interval 60 day) and NOW() and remove='No' and payment='Yes' group by itemid) B on A.itemid=B.itemid set A.OQ=B.OQ where a.itemid = '"+itemid+"' ;";
                        cmd = new MySqlCommand(query, conn);
                        dr = cmd.ExecuteReader();

                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        //   MessageBox.Show(ex.Message, "2");
                    }
                    try
                    {
                        //REORDER POINT
                        MySqlConnection conn = ConString.Connection;

                        query = "update tbl_inventory set rp = LTD + SS  where product_id = '" + Convert.ToUInt32(txtProductID.Text) + "' and store_id = '" + Convert.ToInt32(frm_Login.global_storeid) + "' ;";
                        cmd = new MySqlCommand(query, conn);
                        dr = cmd.ExecuteReader();

                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show(ex.Message, "3");
                    }

                    try
                    {
                        //CRITICAL
                        MySqlConnection conn = ConString.Connection;

                        query = "update tbl_inventory set critical=(ss + oq)/2  where product_id = '" + Convert.ToUInt32(txtProductID.Text) + "' and store_id = '" + Convert.ToInt32(frm_Login.global_storeid) + "' ;";
                        cmd = new MySqlCommand(query, conn);
                        dr = cmd.ExecuteReader();

                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show(ex.Message, "3");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "4", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);

            }
        }

        public void hideColumn()
        {
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[9].Visible = false;
            dataGridView1.Columns[10].Visible = false;
            dataGridView1.Columns[11].Visible = false;
            dataGridView1.Columns[12].Visible = false;
            dataGridView1.Columns[13].Visible = false;
            dataGridView1.Columns[14].Visible = false;
            dataGridView1.Columns[15].Visible = false;
            dataGridView1.Columns[16].Visible = false;
            dataGridView2.Columns[0].Visible = false;
            dataGridView2.Columns[5].Visible = false;
            dataGridView2.Columns[6].Visible = false;
            //dataGridView2.Columns[7].Visible = false;
            
        }

        public void RemoveListCritical()
        {
            try
            {
                MySqlConnection Conn = ConString.Connection;
                MySqlCommand cmd = new MySqlCommand("Select   * from tbl_inventory inner join tbl_product on tbl_inventory.product_id = tbl_product.product_id where tbl_inventory.QTY > tbl_inventory.critical group by tbl_inventory.product_id;Update tbl_inventory set status_pending = 'Available'  where critical < qty;Update tbl_inventory set status = 'Stocked' where qty != 0 and status = 'Critical Level' and status != 'Requested' and critical < qty and status != 'Pending'", Conn);
                cmd.CommandTimeout = 50000;
               
                try
                {
                 
                    MySqlDataReader myReader = cmd.ExecuteReader();


                    while (myReader.Read())
                    {

                        lBCritical1.Items.Remove(myReader["product_name"]);

                        lBCritical1.Visible = false;

                       // dataGridView2 .DefaultCellStyle.SelectionBackColor = Color.Pink;
                        lblCritical.Hide();
                        pCritical.Hide();

                    }
                    Conn.Close();

                }
                catch (TimeoutException)
                {
                   
                }
              

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "5", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);

            }

        }
        public void subRemoveListCritical()
        {
            try
            {
                MySqlConnection Conn = ConString.Connection;
                MySqlCommand cmd = new MySqlCommand("Select   * from tbl_inventory inner join tbl_product on tbl_inventory.product_id = tbl_product.product_id where tbl_inventory.QTY > tbl_inventory.critical group by tbl_inventory.product_id", Conn);
                cmd.CommandTimeout = 50000;
              
                try
                {
                  
                    MySqlDataReader myReader = cmd.ExecuteReader();


                    while (myReader.Read())
                    {


                        lBCritical1.Items.Remove(myReader["product_name"]);

                    }

                }
                catch (TimeoutException)
                {
                    
                }
                Conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "6", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);

            }


        }
       
        private void tabPage6_Click(object sender, EventArgs e)
        {
          
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            generator();

            DGVCart();
            txtDiscountGiven.Text = "0";
            txtDiscount.Text = "0.00";
            txtCash.Text = "0.00";
            txtChange.Text = "0.00";
            txtCash.ForeColor = Color.Gray;
            txtDiscount.Enabled = true;
            btnPrintReceipt.Enabled = false;
            btnPrintReceipt.BackColor = Color.DarkGray;
            DGVProductList();
            subRemoveListCritical();
            AreaCriticalLevel();
          



            try
            {
                if (!dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].IsNewRow)
                {
                    foreach (DataGridViewCell cell in dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells)
                    {
                       
                     
                        btnVoid.Enabled = true;
                        btnVoid.BackColor = Color.IndianRed;
                        if (cell.Value == System.DBNull.Value)
                        {

                        }
                    }


                }
            }
            catch (NullReferenceException)
            {
                btnVoid.Enabled = false;
                btnVoid.BackColor = Color.DarkGray;
              
                return;
            }





        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            try
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
                    txtProductID.Text = row.Cells[0].Value.ToString();
                    lblProductName.Text = row.Cells[1].Value.ToString();
                    lblUnitPrice.Text = row.Cells[3].Value.ToString();
                    lblStock.Text = row.Cells[2].Value.ToString();
                    dateOrdered.Text = row.Cells[5].Value.ToString();
                    status = row.Cells[4].Value.ToString();
                    dateTimePicker4.Text = row.Cells[6].Value.ToString();
                    //if(txtLeadTime.Text == "")
                    //{
                    //    txtLeadTime.Text = "0";
                    //    return;
                    //}

                    //  txtLeadTime.Text = (dateTimePicker4.Value - dateOrdered.Value).TotalDays.ToString("#");
                    getLeadTime();

                    if (status == "Available")
                    {
                        //dataGridView2.DefaultCellStyle.SelectionBackColor = Color.Pink;
                        //dataGridView2.DefaultCellStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("#24262F");
                        btnSelectedCart.Enabled = true;
                        btnSelectedCart.BackColor = System.Drawing.ColorTranslator.FromHtml("#24262F");
                    }
                    else
                    {
                        //btnSelectedCart.Enabled = false;
                        //btnSelectedCart.BackColor = System.Drawing.Color.DarkGray;

                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                selectedRow = e.RowIndex;
                DataGridViewRow row = dataGridView2.Rows[selectedRow];
                txtProductID.Text = row.Cells[0].Value.ToString();
                lblProductName.Text = row.Cells[1].Value.ToString();
                lblUnitPrice.Text = row.Cells[3].Value.ToString();
                lblStock.Text = row.Cells[2].Value.ToString();
                dateOrdered.Text = row.Cells[5].Value.ToString();
                dateTimePicker4.Text = row.Cells[6].Value.ToString();
                txtQty.Enabled = true;

            }
            catch (ArgumentException)
            {

            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                selectedRow = e.RowIndex;
                DataGridViewRow row = dataGridView2.Rows[selectedRow];
                txtProductID.Text = row.Cells[0].Value.ToString();
                lblProductName.Text = row.Cells[1].Value.ToString();
                lblUnitPrice.Text = row.Cells[3].Value.ToString();
                lblStock.Text = row.Cells[2].Value.ToString();
                dateOrdered.Text = row.Cells[5].Value.ToString();
                dateTimePicker4.Text = row.Cells[6].Value.ToString();

                txtQty.Enabled = true;
            }
            catch (ArgumentException)
            {

            }
        }

        private void txtQty_TextChanged(object sender, EventArgs e)
        {
            txtChange.Text = "0.00";
            btnPrintReceipt.Enabled = false;
            btnPrintReceipt.BackColor = Color.DarkGray;
            //if (txtQty.Text == "")
            //{

            //    return;
            //}
            //try
            //{
            //    var Connection = "datasource=localhost;port=3306;username=root;password=1234;default Command Timeout=20000;Pooling = true; Max Pool Size = 20000";
            //    MySqlDataReader myReader;
            //    var Conn = new MySqlConnection(Connection);
            //    int val1, val2;
            //    double val3;
            //    val1 = int.Parse(txtQty.Text);
            //    val2 = int.Parse(lblStock.Text);
            //    val3 = double.Parse(lblUnitPrice.Text);
            //    string Query = "update tbl_product set total_price =   '" + val1 + "' * '" + val3 + "' WHERE product_id = '" + this.txtProductID.Text + "';update tbl_product set vat =  total_price-(total_price/1.12)  WHERE product_id = '" + this.txtProductID.Text + "';Select * from tbl_product where product_id = '" + this.txtProductID.Text + "'";
            //    MySqlCommand cmd = new MySqlCommand(Query, Conn);
            //    cmd.CommandTimeout = 65000;

            //    try
            //    {
            //        try
            //        {
            //            try
            //            {


            //                Conn.Open();
            //                myReader = cmd.ExecuteReader();
            //                while (myReader.Read())
            //                {
                              
            //                    lblProductName.Text = myReader[1].ToString();
            //                    lblUnitPrice.Text = myReader[2].ToString();
            //                    // txtQty.Text = myReader[3].ToString();
            //                    lblTotalPrice.Text = myReader[4].ToString();
            //                    lblStock.Text = myReader[5].ToString();
            //                    lblVat.Text = myReader[6].ToString();
            //                    lblNameCategory.Text = myReader[14].ToString();

            //                    if (int.Parse(lblStock.Text) <= 5)
            //                    {
            //                        lBCritical1.Items.Clear();
            //                        lBCritical1.Visible = false;
            //                    }
            //                    DataGridViewRow newDataRow = dataGridView2.Rows[selectedRow];
            //                    newDataRow.Cells[0].Value = txtProductID.Text;
            //                    newDataRow.Cells[1].Value = lblProductName.Text;
            //                    newDataRow.Cells[2].Value = lblUnitPrice.Text;
            //                    newDataRow.Cells[3].Value = txtQty.Text;
            //                    newDataRow.Cells[4].Value = lblDescription.Text;
            //                    newDataRow.Cells[5].Value = lblStock.Text;
            //                    newDataRow.Cells[6].Value = lblVat.Text;
            //                    newDataRow.Cells[7].Value = lblTotalPrice.Text;

            //                }
            //            }
            //            catch (ArgumentException)
            //            {
            //                MessageBox.Show("Please double click the item in selection menu list.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.None);
            //            }
            //            finally
            //            {
            //                Conn.Close();

            //            }
            //        }
            //        catch (TimeoutException)
            //        {
            //            MessageBox.Show("Program has stopped working due to the operation and server is not responding. Please exit or try again.", "Fabula's Merchandise System", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            //        }

            //        MySqlConnection.ClearPool(Conn);
            //        return;
            //    }
            //    catch (FormatException)
            //    {

            //    }
            //}

            //catch (Exception ex)
            //{

            //    //MessageBox.Show(ex.Message, "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

        }

        private void txtQty_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtQty.Text.Equals(null) == true)
            {
                txtQty.Text = "0";
                txtQty.ForeColor = Color.Gray;
            }
            else
            {
                txtQty.ForeColor = Color.Black;
            }

            if (e.KeyCode == Keys.Back)
            {
                if (txtQty.Text.Length == 0)
                {
                    txtQty.Text = "0";
                }
            }
        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtQty.Text == "0")
            {
                txtQty.Text = "";
            }
        }

     
        private void btnSelectedCart_Click(object sender, EventArgs e)
        {
            try
            {
                if (!dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex].IsNewRow)
                {
                    foreach (DataGridViewCell cell in dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex].Cells)
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
          //  try
          //  {
                date = lblDateTime.Text;
                datetimepicker = dateTimePicker.Value.ToString("yyyy-MM-dd");



            MySqlConnection Conn = ConString.Connection;
            var dtt = new DataTable();
            var sda = new MySqlDataAdapter("select * from tbl_transactionrecord where REPLACE(product_id, ' ', '') = REPLACE('"+txtProductID.Text+ "', ' ', '') and status = 'Sold' and store_id = '"+frm_Login.global_storeid+"'", Conn);
            sda.Fill(dtt);
            Conn.Close();


            if (dtt.Rows.Count >= 1 || dtt.Rows.Count == 1)
            {
                if (txtLeadTime.Text == "")
                {


                //    MessageBox.Show("A");
                    CriticalLevel1();




                    if (txtQty.Text == "" || txtQty.Text == "0")
                    {
                        MessageBox.Show("Enter quantity of product.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.None);
                        return;
                    }
                    if (lblStock.Text == "0")
                    {
                        MessageBox.Show("You don't have quantity or stock for product: " + lblProductName.Text + ". Please order amount of product from supplier.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.None);
                        return;
                    }
                    try
                    {
                        if (int.Parse(txtQty.Text) < int.Parse(lblStock.Text))
                        {



                            int quantityRemain = int.Parse(lblStock.Text);
                            int quantityPunched = quantityRemain - Convert.ToInt32(txtQty.Text);


                            Conn = ConString.Connection;
                            string Query = "update tbl_inventory set QTY = '" + quantityPunched + "' where product_id = '" + this.txtProductID.Text + "' and store_id = '" + txtstore_id.Text + "';";
                            MySqlCommand cmd = new MySqlCommand(Query, Conn);
                            MySqlDataReader myReader;

                            myReader = cmd.ExecuteReader();

                            while (myReader.Read())
                            {

                                DataGridViewRow newDataRow = dataGridView2.Rows[selectedRow];
                                //newDataRow.Cells[0].Value = txtProductID.Text;
                                //newDataRow.Cells[1].Value = lblProductName.Text;
                                //newDataRow.Cells[2].Value = lblUnitPrice.Text;
                                newDataRow.Cells[2].Value = txtQty.Text;
                                //newDataRow.Cells[4].Value = lblDescription.Text;
                                //newDataRow.Cells[5].Value = lblStock.Text;
                                //newDataRow.Cells[6].Value = lblVat.Text;
                                //newDataRow.Cells[7].Value = lblTotalPrice.Text;



                            }

                            Conn.Close();

                        }
                        else
                        {
                            MessageBox.Show("Added to cart invalid.", "POS System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error1");
                    }

                    try
                    {
                        generator();


                        try
                        {

                            int qty = Convert.ToInt32(txtQty.Text);
                            decimal UnitPrice = qty * decimal.Parse(lblUnitPrice.Text);
                            lblTotalPrice.Text = UnitPrice.ToString();

                            decimal total = decimal.Parse(lblTotalPrice.Text);
                            decimal vat = total - (decimal.Parse(lblTotalPrice.Text) / Convert.ToDecimal(1.12));
                            lblVat.Text = vat.ToString();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error2");
                        }
                        generator();
                         Conn = ConString.Connection;

                        string Query = "insert into subtbl_cart(cart_id, product_name, QTY, total_price,Vat, stock, dateortime,product_id, description, original_price, unit_price, date, time, s_status, discount, store_id, leadtime) values('" + this.txtCartID.Text + "', '" + this.lblProductName.Text + "', '" + this.txtQty.Text + "', '" + Convert.ToDouble(this.lblTotalPrice.Text) + "', '" + this.lblVat.Text + "','" + this.lblStock.Text + "', '" + lblDateTime.Text + "', '" + this.txtProductID.Text + "', '" + this.lblDescription.Text + "', '" + Convert.ToDouble(this.lblTotalPrice.Text) + "', '" + Convert.ToDouble(this.lblUnitPrice.Text) + "', '" + datetimepicker + "', '" + this.lblTime.Text + "', '" + Sold + "', '" + txtDiscount.Text + "', '" + frm_Login.global_storeid + "',0)";
                        MySqlCommand cmd = new MySqlCommand(Query, Conn);
                        MySqlDataReader myReader;

                        myReader = cmd.ExecuteReader();

                        while (myReader.Read())
                        {



                        }
                        Conn.Close();
                        MessageBox.Show(lblProductName.Text + " added to cart successfully.", "POS System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        AreaCriticalLevel();
                        NotificationofCriticalLevel();

                      
                        //     BranchRefresh();
                        //  DGVRefreshProductList();


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error2");
                    }
                    decimal sum1 = 0;
                    decimal sumitem1 = 0;
                    decimal sumvat1 = 0;
                    for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                    {

                        sum1 += Convert.ToDecimal(dataGridView1.Rows[i].Cells[4].Value);
                        sumitem1 += Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value);
                        sumvat1 += Convert.ToDecimal(dataGridView1.Rows[i].Cells[6].Value);
                    }


                    txtGrandTotal.Text = sum1.ToString();
                    txtProductItemQTY.Text = sumitem1.ToString();
                    txtVat.Text = sumvat1.ToString();


                    decimal process1 = decimal.Parse(txtGrandTotal.Text) - decimal.Parse(txtVat.Text);
                    txtSubTotal.Text = process1.ToString();


                    //int qty1 = Convert.ToInt32(txtQuantity.Text);
                    //int add = qty1 + int.Parse(lblQTY.Text);



                    txtQty.Text = "0";
                    //   DGVsubRefreshProductList();
                    DGVSUMsomecolumncart();
                    DGVCart();
               
                    subRemoveListCritical();
                    AreaCriticalLevel();
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                    dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                    BranchRefresh();
                    changeRowColor();
                    return;
                }
                else
                {
                   // MessageBox.Show("C");
                    CriticalLevel1();




                    if (txtQty.Text == "" || txtQty.Text == "0")
                    {
                        MessageBox.Show("Enter quantity of product.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.None);
                        return;
                    }
                    if (lblStock.Text == "0")
                    {
                        MessageBox.Show("You don't have quantity or stock for product: " + lblProductName.Text + ". Please order amount of product from supplier.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.None);
                        return;
                    }
                    try
                    {
                        if (int.Parse(txtQty.Text) < int.Parse(lblStock.Text))
                        {



                            int quantityRemain = int.Parse(lblStock.Text);
                            int quantityPunched = quantityRemain - Convert.ToInt32(txtQty.Text);


                             Conn = ConString.Connection;
                            string Query = "update tbl_inventory set QTY = '" + quantityPunched + "' where product_id = '" + this.txtProductID.Text + "' and store_id = '" + txtstore_id.Text + "';";
                            MySqlCommand cmd = new MySqlCommand(Query, Conn);
                            MySqlDataReader myReader;

                            myReader = cmd.ExecuteReader();

                            while (myReader.Read())
                            {

                                DataGridViewRow newDataRow = dataGridView2.Rows[selectedRow];
                                //newDataRow.Cells[0].Value = txtProductID.Text;
                                //newDataRow.Cells[1].Value = lblProductName.Text;
                                //newDataRow.Cells[2].Value = lblUnitPrice.Text;
                                newDataRow.Cells[2].Value = txtQty.Text;
                                //newDataRow.Cells[4].Value = lblDescription.Text;
                                //newDataRow.Cells[5].Value = lblStock.Text;
                                //newDataRow.Cells[6].Value = lblVat.Text;
                                //newDataRow.Cells[7].Value = lblTotalPrice.Text;



                            }

                            Conn.Close();

                        }
                        else
                        {
                            MessageBox.Show("Added to cart invalid.", "POS System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error1");
                    }

                    try
                    {
                        generator();


                        try
                        {

                            int qty = Convert.ToInt32(txtQty.Text);
                            decimal UnitPrice = qty * decimal.Parse(lblUnitPrice.Text);
                            lblTotalPrice.Text = UnitPrice.ToString();

                            decimal total = decimal.Parse(lblTotalPrice.Text);
                            decimal vat = total - (decimal.Parse(lblTotalPrice.Text) / Convert.ToDecimal(1.12));
                            lblVat.Text = vat.ToString();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error2");
                        }
                        generator();
                         Conn = ConString.Connection;

                        string Query = "insert into subtbl_cart(cart_id, product_name, QTY, total_price,Vat, stock, dateortime,product_id, description, original_price, unit_price, date, time, s_status, discount, store_id, leadtime) values('" + this.txtCartID.Text + "', '" + this.lblProductName.Text + "', '" + this.txtQty.Text + "', '" + Convert.ToDouble(this.lblTotalPrice.Text) + "', '" + this.lblVat.Text + "','" + this.lblStock.Text + "', '" + lblDateTime.Text + "', '" + this.txtProductID.Text + "', '" + this.lblDescription.Text + "', '" + Convert.ToDouble(this.lblTotalPrice.Text) + "', '" + Convert.ToDouble(this.lblUnitPrice.Text) + "', '" + datetimepicker + "', '" + this.lblTime.Text + "', '" + Sold + "', '" + txtDiscount.Text + "', '" + frm_Login.global_storeid + "', '" + Convert.ToInt32(txtLeadTime.Text) + "')";
                        MySqlCommand cmd = new MySqlCommand(Query, Conn);
                        MySqlDataReader myReader;

                        myReader = cmd.ExecuteReader();

                        while (myReader.Read())
                        {



                        }
                        Conn.Close();
                        MessageBox.Show(lblProductName.Text + " added to cart successfully.", "POS System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        AreaCriticalLevel();
                        NotificationofCriticalLevel();
                       
                        // BranchRefresh();
                        //  DGVRefreshProductList();


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error2");
                    }
                    decimal sum1 = 0;
                    decimal sumitem1 = 0;
                    decimal sumvat1 = 0;
                    for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                    {

                        sum1 += Convert.ToDecimal(dataGridView1.Rows[i].Cells[4].Value);
                        sumitem1 += Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value);
                        sumvat1 += Convert.ToDecimal(dataGridView1.Rows[i].Cells[6].Value);
                    }


                    txtGrandTotal.Text = sum1.ToString();
                    txtProductItemQTY.Text = sumitem1.ToString();
                    txtVat.Text = sumvat1.ToString();


                    decimal process1 = decimal.Parse(txtGrandTotal.Text) - decimal.Parse(txtVat.Text);
                    txtSubTotal.Text = process1.ToString();


                    //int qty1 = Convert.ToInt32(txtQuantity.Text);
                    //int add = qty1 + int.Parse(lblQTY.Text);



                    txtQty.Text = "0";
                    //   DGVsubRefreshProductList();
                    DGVSUMsomecolumncart();
                    DGVCart();

                    //   subRemoveListCritical();
                 
                    subRemoveListCritical();
                    AreaCriticalLevel();
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                    dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                    BranchRefresh();
                    changeRowColor();
                    //   DGVSUMsomecolumncart(); //#4
                    //  DGVsubRefreshProductList();//#5

                    //  dataGridView2.DefaultCellStyle.SelectionBackColor = Color.Pink;

                    //  CriticalLevel();

                    // txtLeadTime.Text = "0";
                    //RemoveListCritical();
                    //subRemoveListCritical();
                    //AreaCriticalLevel();

                    return;
                }
            }

            if (txtLeadTime.Text == "")
            {


             //   MessageBox.Show("B");


                if (txtQty.Text == "" || txtQty.Text == "0")
                {
                    MessageBox.Show("Enter quantity of product.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.None);
                    return;
                }
                if (lblStock.Text == "0")
                {
                    MessageBox.Show("You don't have quantity or stock for product: " + lblProductName.Text + ". Please order amount of product from supplier.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.None);
                    return;
                }
                try
                {
                    if (int.Parse(txtQty.Text) < int.Parse(lblStock.Text))
                    {



                        int quantityRemain = int.Parse(lblStock.Text);
                        int quantityPunched = quantityRemain - Convert.ToInt32(txtQty.Text);

                        subCriticalLevel1();
                         Conn = ConString.Connection;
                        string Query = "update tbl_inventory set QTY = '" + quantityPunched + "' where product_id = '" + this.txtProductID.Text + "' and store_id = '" + txtstore_id.Text + "';";
                        MySqlCommand cmd = new MySqlCommand(Query, Conn);
                        MySqlDataReader myReader;

                        myReader = cmd.ExecuteReader();

                        while (myReader.Read())
                        {

                            DataGridViewRow newDataRow = dataGridView2.Rows[selectedRow];
                            //newDataRow.Cells[0].Value = txtProductID.Text;
                            //newDataRow.Cells[1].Value = lblProductName.Text;
                            //newDataRow.Cells[2].Value = lblUnitPrice.Text;
                            newDataRow.Cells[2].Value = txtQty.Text;
                            //newDataRow.Cells[4].Value = lblDescription.Text;
                            //newDataRow.Cells[5].Value = lblStock.Text;
                            //newDataRow.Cells[6].Value = lblVat.Text;
                            //newDataRow.Cells[7].Value = lblTotalPrice.Text;



                        }

                        Conn.Close();

                    }
                    else
                    {
                        MessageBox.Show("Added to cart invalid.", "POS System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error1");
                }
                DateTime datenow = DateTime.Now;
                try
                {
                    generator();


                    try
                    {

                        int qty = Convert.ToInt32(txtQty.Text);
                        decimal UnitPrice = qty * decimal.Parse(lblUnitPrice.Text);
                        lblTotalPrice.Text = UnitPrice.ToString();

                        decimal total = decimal.Parse(lblTotalPrice.Text);
                        decimal vat = total - (decimal.Parse(lblTotalPrice.Text) / Convert.ToDecimal(1.12));
                        lblVat.Text = vat.ToString();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error2");
                    }
                    generator();
                     Conn = ConString.Connection;
                    string Query = "insert into subtbl_cart(cart_id, product_name, QTY, total_price,Vat, stock, dateortime,product_id, description, original_price, unit_price, date, time, s_status, discount, store_id, leadtime) values('" + this.txtCartID.Text + "', '" + this.lblProductName.Text + "', '" + this.txtQty.Text + "', '" + Convert.ToDouble(this.lblTotalPrice.Text) + "', '" + this.lblVat.Text + "','" + this.lblStock.Text + "', '" + lblDateTime.Text + "', '" + this.txtProductID.Text + "', '" + this.lblDescription.Text + "', '" + Convert.ToDouble(this.lblTotalPrice.Text) + "', '" + Convert.ToDouble(this.lblUnitPrice.Text) + "', '" + datetimepicker + "', '" + this.lblTime.Text + "', '" + Sold + "', '" + txtDiscount.Text + "', '" + frm_Login.global_storeid + "',0)";
                    MySqlCommand cmd = new MySqlCommand(Query, Conn);
                    MySqlDataReader myReader;

                    myReader = cmd.ExecuteReader();

                    while (myReader.Read())
                    {



                    }
                    Conn.Close();
                    MessageBox.Show(lblProductName.Text + " added to cart successfully.", "POS System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    AreaCriticalLevel();
                    NotificationofCriticalLevel();
                 
                    //  BranchRefresh();
                    //  DGVRefreshProductList();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error2");
                }
                decimal sum = 0;
                decimal sumitem = 0;
                decimal sumvat = 0;
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {

                    sum += Convert.ToDecimal(dataGridView1.Rows[i].Cells[4].Value);
                    sumitem += Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value);
                    sumvat += Convert.ToDecimal(dataGridView1.Rows[i].Cells[6].Value);
                }


                txtGrandTotal.Text = sum.ToString();
                txtProductItemQTY.Text = sumitem.ToString();
                txtVat.Text = sumvat.ToString();


                decimal process = decimal.Parse(txtGrandTotal.Text) - decimal.Parse(txtVat.Text);
                txtSubTotal.Text = process.ToString();


                //int qty1 = Convert.ToInt32(txtQuantity.Text);
                //int add = qty1 + int.Parse(lblQTY.Text);



                txtQty.Text = "0";
                //   DGVsubRefreshProductList();
                DGVSUMsomecolumncart();
                DGVCart();
             
                subRemoveListCritical();
                AreaCriticalLevel();
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                BranchRefresh();
                changeRowColor();

            }
            else
            {
               // MessageBox.Show("D");


                if (txtQty.Text == "" || txtQty.Text == "0")
                {
                    MessageBox.Show("Enter quantity of product.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.None);
                    return;
                }
                if (lblStock.Text == "0")
                {
                    MessageBox.Show("You don't have quantity or stock for product: " + lblProductName.Text + ". Please order amount of product from supplier.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.None);
                    return;
                }
                try
                {
                    if (int.Parse(txtQty.Text) < int.Parse(lblStock.Text))
                    {



                        int quantityRemain = int.Parse(lblStock.Text);
                        int quantityPunched = quantityRemain - Convert.ToInt32(txtQty.Text);

                        subCriticalLevel1();
                        Conn = ConString.Connection;
                        string Query = "update tbl_inventory set QTY = '" + quantityPunched + "' where product_id = '" + this.txtProductID.Text + "' and store_id = '" + txtstore_id.Text + "';";
                        MySqlCommand cmd = new MySqlCommand(Query, Conn);
                        MySqlDataReader myReader;

                        myReader = cmd.ExecuteReader();

                        while (myReader.Read())
                        {

                            DataGridViewRow newDataRow = dataGridView2.Rows[selectedRow];
                            //newDataRow.Cells[0].Value = txtProductID.Text;
                            //newDataRow.Cells[1].Value = lblProductName.Text;
                            //newDataRow.Cells[2].Value = lblUnitPrice.Text;
                            newDataRow.Cells[2].Value = txtQty.Text;
                            //newDataRow.Cells[4].Value = lblDescription.Text;
                            //newDataRow.Cells[5].Value = lblStock.Text;
                            //newDataRow.Cells[6].Value = lblVat.Text;
                            //newDataRow.Cells[7].Value = lblTotalPrice.Text;



                        }

                        Conn.Close();

                    }
                    else
                    {
                        MessageBox.Show("Added to cart invalid.", "POS System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error1");
                }
                DateTime datenow = DateTime.Now;
                try
                {
                    generator();


                    try
                    {

                        int qty = Convert.ToInt32(txtQty.Text);
                        decimal UnitPrice = qty * decimal.Parse(lblUnitPrice.Text);
                        lblTotalPrice.Text = UnitPrice.ToString();

                        decimal total = decimal.Parse(lblTotalPrice.Text);
                        decimal vat = total - (decimal.Parse(lblTotalPrice.Text) / Convert.ToDecimal(1.12));
                        lblVat.Text = vat.ToString();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error2");
                    }
                    generator();
                     Conn = ConString.Connection;
                    string Query = "insert into subtbl_cart(cart_id, product_name, QTY, total_price,Vat, stock, dateortime,product_id, description, original_price, unit_price, date, time, s_status, discount, store_id, leadtime) values('" + this.txtCartID.Text + "', '" + this.lblProductName.Text + "', '" + this.txtQty.Text + "', '" + Convert.ToDouble(this.lblTotalPrice.Text) + "', '" + this.lblVat.Text + "','" + this.lblStock.Text + "', '" + lblDateTime.Text + "', '" + this.txtProductID.Text + "', '" + this.lblDescription.Text + "', '" + Convert.ToDouble(this.lblTotalPrice.Text) + "', '" + Convert.ToDouble(this.lblUnitPrice.Text) + "', '" + datetimepicker + "', '" + this.lblTime.Text + "', '" + Sold + "', '" + txtDiscount.Text + "', '" + frm_Login.global_storeid + "', '" + Convert.ToInt32(txtLeadTime.Text) + "')";
                    MySqlCommand cmd = new MySqlCommand(Query, Conn);
                    MySqlDataReader myReader;

                    myReader = cmd.ExecuteReader();

                    while (myReader.Read())
                    {



                    }
                    Conn.Close();
                    MessageBox.Show(lblProductName.Text + " added to cart successfully.", "POS System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    AreaCriticalLevel();
                    NotificationofCriticalLevel();
                   
                    //AreaCriticalLevel();
                    //BranchRefresh();

                    //  DGVRefreshProductList();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error2");
                }
                decimal sum = 0;
                decimal sumitem = 0;
                decimal sumvat = 0;
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {

                    sum += Convert.ToDecimal(dataGridView1.Rows[i].Cells[4].Value);
                    sumitem += Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value);
                    sumvat += Convert.ToDecimal(dataGridView1.Rows[i].Cells[6].Value);
                }


                txtGrandTotal.Text = sum.ToString();
                txtProductItemQTY.Text = sumitem.ToString();
                txtVat.Text = sumvat.ToString();


                decimal process = decimal.Parse(txtGrandTotal.Text) - decimal.Parse(txtVat.Text);
                txtSubTotal.Text = process.ToString();


                //int qty1 = Convert.ToInt32(txtQuantity.Text);
                //int add = qty1 + int.Parse(lblQTY.Text);



                txtQty.Text = "0";
                //   DGVsubRefreshProductList();
                DGVSUMsomecolumncart();
                DGVCart();


                //subRemoveListCritical();

               
                //AreaCriticalLevel();
                subRemoveListCritical();
                AreaCriticalLevel();

                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                BranchRefresh();
                changeRowColor();
               
             

            }

          
            //    var Connection = "datasource=localhost;port=3306;username=root;password=1234;default Command Timeout=20000;Pooling = true; Max Pool Size = 20000";
            //    var Conn = new MySqlConnection(Connection);
            //    MySqlDataReader myReader;

            //    int val1, val2;
            //    double val3;

            //    val1 = int.Parse(txtQty.Text);
            //    val2 = int.Parse(lblStock.Text);
            //    val3 = double.Parse(lblUnitPrice.Text);

            //    if (lblStock.Text == "0")
            //    {
            //        string myStringVariable1 = string.Empty;


            //        MessageBox.Show("You don't have quantity or stock for product: " + lblProductName.Text + ". Please order amount of product from supplier.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.None);
            //        return;
            //    }

            //    if (txtQty.Text == "0" || txtQty.Text == "")
            //    {
            //        string myStringVariable1 = string.Empty;


            //        MessageBox.Show("Enter amount of product: "+lblProductName.Text+ " into Qty field.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.None);
            //        return;
            //    }


            //    try
            //    {
            //        Conn.Open();
            //        var Query = "update tbl_product set quantity = '" + val1 + "' - '" + val1 + "' WHERE product_id = '" + this.txtProductID.Text + "'";
            //        var cmd = new MySqlCommand(Query, Conn);
            //        cmd.CommandTimeout = 65000;
            //        myReader = cmd.ExecuteReader();



            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }
            //    finally
            //    {
            //        Conn.Close();
            //    }
            //    try
            //    {
            //        generator();
            //        lblTime.Text = DateTime.Now.ToShortTimeString();

            //        if (int.Parse(lblStock.Text) >= int.Parse(txtQty.Text))
            //        {
            //            string Query = "insert into subtbl_cart(cart_id, product_name, QTY, total_price,Vat, stock, dateortime,product_id, description, original_price, unit_price, date, time, status, discount) values('" + this.txtCartID.Text + "', '" + this.lblProductName.Text + "', '" +this.txtQty.Text + "', '" + Convert.ToDouble(this.lblTotalPrice.Text) + "', '" + this.lblVat.Text + "','"+this.lblStock.Text+"', '" + lblDateTime.Text + "', '" + this.txtProductID.Text + "', '" + this.lblDescription.Text + "', '" + Convert.ToDouble(this.lblTotalPrice.Text) + "', '"+Convert.ToDouble(this.lblUnitPrice.Text)+"', '"+ datetimepicker + "', '"+this.lblTime.Text+"', '"+Sold+"', '"+txtDiscount.Text+"')";


            //            var cmd = new MySqlCommand(Query, Conn);
            //            cmd.CommandTimeout = 65000;


            //            if (lblVat.Text == "0.00")
            //            {
            //                string myStringVariable1 = string.Empty;


            //                MessageBox.Show("The VAT is 0.00. Please try again.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //                return;
            //            }
            //            if (lblTotalPrice.Text == "0.00")
            //            {
            //                string myStringVariable1 = string.Empty;


            //                MessageBox.Show("The total price is 0.00. Please try again.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //                return;
            //            }
            //            try
            //            {


            //                Conn.Open();
            //                myReader = cmd.ExecuteReader();

            //                DataGridViewRow newDataRow = dataGridView2.Rows[selectedRow];
            //                newDataRow.Cells[0].Value = txtProductID.Text;
            //                newDataRow.Cells[1].Value = lblProductName.Text;
            //                newDataRow.Cells[2].Value = lblUnitPrice.Text;
            //                newDataRow.Cells[3].Value = txtQty.Text;
            //                newDataRow.Cells[4].Value = lblDescription.Text;
            //                newDataRow.Cells[5].Value = lblStock.Text;
            //                newDataRow.Cells[6].Value = lblVat.Text;
            //                newDataRow.Cells[7].Value = lblTotalPrice.Text;





            //                lblVat.Text = "0.00";
            //                MessageBox.Show(lblProductName.Text + " added to cart.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                Conn.Close();


            //                try
            //                {
            //                    cmd = new MySqlCommand("update tbl_product set stock =  stock - '" + val1 + "' WHERE product_id = '" + this.txtProductID.Text + "'", Conn);

            //                    cmd.CommandTimeout = 65000;
            //                    Conn.Open();
            //                    myReader = cmd.ExecuteReader();

            //                }
            //                catch (Exception ex)
            //                {
            //                    MessageBox.Show(ex.Message, "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //                }
            //                finally
            //                {
            //                    Conn.Close();
            //                }
            //                DGVsubRefreshProductList();            
            //                DGVSUMsomecolumncart();
            //                DGVCart();

            //                subRemoveListCritical();

            //                CriticalLevel();
            //                AreaCriticalLevel();
            //                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            //                dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            //                double value1, value2;
            //                value1 = double.Parse(txtVat.Text);
            //                value2 = double.Parse(txtGrandTotal.Text);

            //                try
            //                {
            //                    Conn.Open();
            //                    Query = "update subtbl_cart set total_amount = '" + value2 + "';update subtbl_cart set original_vat = '" + value1 + "';update subtbl_cart set sub_total = '" + value2 + "'- '" + value1 + "'";
            //                    cmd = new MySqlCommand(Query, Conn);
            //                    cmd.CommandTimeout = 65000;
            //                    myReader = cmd.ExecuteReader();
            //                    while (myReader.Read())
            //                    {
            //                        txtSubTotal.Text = myReader[13].ToString();

            //                    }


            //                    MySqlConnection.ClearPool(Conn);
            //                    return;
            //                }
            //                catch (Exception ex)
            //                {
            //                    MessageBox.Show(ex.Message);
            //                }

            //                Conn.Close();


            //            }
            //            catch (ArgumentException)
            //            {

            //            }
            //        }
            //        else
            //        {

            //            MessageBox.Show("Invalid add to cart. The stock: " + lblStock.Text + " must not be equal or higher for QTY: " + txtQty.Text + ".", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }

            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message, "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //    }
            //}
            //catch (FormatException)
            //{

            //}
            // enable();



        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
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
                    btnVoid.Enabled = true;
                    btnVoid.BackColor = Color.IndianRed;
                    datetimepicker = dateTimePicker.Value.ToString("yyyy-MM-dd");
                    txtCartID.Text = row.Cells[0].Value.ToString();
                    txtForeignProductID.Text = row.Cells[1].Value.ToString();
                    txtRecordID.Text = row.Cells[0].Value.ToString();
                    
                    txtSubQTY.Text = row.Cells[3].Value.ToString();
                  //  txtProductItemQTY.Text = row.Cells[3].Value.ToString();
                  //  txtGrandTotal.Text = row.Cells[4].Value.ToString();
                    lblsubStock.Text = row.Cells[7].Value.ToString();
                    txtnameProd.Text = row.Cells[2].Value.ToString();
                    txtPrice.Text = row.Cells[4].Value.ToString();

                    txtsubproductname.Text = row.Cells[2].Value.ToString();
                    //txtquantity.Text = row.Cells[3].Value.ToString();
                    txtDescription.Text = row.Cells[5].Value.ToString();
                  txtSubDiscount.Text = row.Cells[8].Value.ToString();
                    txtUnitPrice.Text = row.Cells[11].Value.ToString();
                    lblTime.Text = row.Cells[13].Value.ToString();
                    datetimepicker = row.Cells[12].Value.ToString();
                    Sold = row.Cells[14].Value.ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void btnHome_Click_1(object sender, EventArgs e)
        {
            var myform = new frm_MainHomeStaff(user);
            myform.Show();
            this.Hide();
        }

        private void btnPOS_Click(object sender, EventArgs e)
        {
         
        }
        private void changeRowColor()
        {
            try
            {


                foreach (DataGridViewRow Myrow in dataGridView2.Rows)
                {
                    if (Myrow.Cells["Status"].Value.ToString() == "Not Available")
                    {
                        Myrow.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#F53240");
                        Myrow.DefaultCellStyle.ForeColor = System.Drawing.Color.White;

                    }
                    else if (Myrow.Cells["Status"].Value.ToString() == "Available")
                    {
                        Myrow.DefaultCellStyle.BackColor = System.Drawing.Color.White;
                        Myrow.DefaultCellStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("#24262F");

                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }
        private void btnLogout_Click_1(object sender, EventArgs e)
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
        public void AreaCriticalLevel()
        {

            try
            {
                MySqlConnection Conn = ConString.Connection;
                MySqlCommand cmd = new MySqlCommand("Select   * from tbl_inventory inner join tbl_product on tbl_inventory.product_id = tbl_product.product_id where tbl_inventory.QTY <= tbl_inventory.critical and tbl_inventory.QTY != 0 and tbl_inventory.store_id = '"+frm_Login.global_storeid+"' group by tbl_inventory.product_id;Update tbl_inventory set status_pending = 'Not Available' where critical >=qty and status !='Pending';update tbl_inventory set status = 'Critical Level' where critical >= qty and status != 'Requested' and status != 'Pending';Update tbl_inventory set status = 'Out of stocked' where qty = 0 and status = 'Critical level'", Conn);
                cmd.CommandTimeout = 50000;


                lBCritical1.Items.Remove("Critical Level:");
               
                    MySqlDataReader myReader = cmd.ExecuteReader();


                    while (myReader.Read())
                    {

                     
                        lBCritical1.Items.Add(myReader["product_name"]);
                        lBCritical1.Visible = true;
                        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                        dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                     //   dataGridView2.DefaultCellStyle.SelectionBackColor = Color.Red;
                        lblCritical.Show();
                        pCritical.Show();
                     

                    }


               
                Conn.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message,"7");

            }
        }
        private void btnPurchase_Click(object sender, EventArgs e)
        {
            try
            {


                txtCash.Text = string.Format("{0:n}", decimal.Parse(txtCash.Text));
            }
            catch (Exception)
            {

            }
            //try
            //{
            //    Cursor.Current = Cursors.AppStarting;
            //string Connection = "datasource=localhost;port=3306;username=root;password=1234; Max Pool Size = 200";
            //MySqlDataReader myReader;
            //MySqlConnection myConn = new MySqlConnection(Connection);
            //try
            //{
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
                        MessageBox.Show("Add one or more products into cart from the selection product list.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.None);
                        return;
                    }
                    if (txtCash.Text == "0.00" || txtCash.Text == "0" || txtCash.Text == "00" || txtCash.Text == "000" || txtCash.Text == "0000" || txtCash.Text == "" || txtCash.Text == "." || (string.IsNullOrEmpty(txtCash.Text)))
                    {
                        string myStringVariable1 = string.Empty;
                        MessageBox.Show("Enter the cash.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.None);
                        txtCash.ForeColor = Color.Gray;
                        return;
                    }




                    //discount
                    //double val1, val2;
                    //val2 = double.Parse(txtGrandTotal.Text);
                    //val1 = double.Parse(txtCash.Text);
                    //if (double.Parse(txtDiscount.Text) != 0.00 || double.Parse(txtDiscount.Text) != 0 || double.Parse(txtDiscount.Text) != 00 || double.Parse(txtDiscount.Text) != 000 || txtDiscount.Text == "")
                    //{
                    //    if (double.Parse(txtDiscount.Text) <= 100)
                    //    {
                    //        try
                    //        {

                    //            if (txtSubDiscount.Text != "")
                    //            {

                    //                MessageBox.Show("This item is already discounted.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //                return;
                    //            }


                    //        }
                    //        catch (Exception ex)
                    //        {
                    //            MessageBox.Show(ex.Message);
                    //        }


                    //        string minus = "-";

                    //        string Query1 = "update subtbl_cart set Cash = '" + val1 + "';update subtbl_cart set discount = '" + txtDiscount.Text + "' where cart_id = '" + txtCartID.Text + "';update subtbl_cart set discountgiven = total_price * ('" + txtDiscount.Text + "'/100 ) where product_id = '" + txtForeignProductID.Text + "';update subtbl_cart set sub_price = '" + txtPrice.Text + "' - discountgiven where cart_id = '" + txtCartID.Text + "';update subtbl_cart set total_price = sub_price where cart_id = '" + txtCartID.Text + "';update subtbl_cart set change_amount = '" + val1 + "' - '" + val2 + "' + discountgiven;update subtbl_cart set discountname = '" + lblDiscount.Text + "' where cart_id = '" + txtCartID.Text + "';update subtbl_cart set minus = '" + minus + "' where cart_id = '" + txtCartID.Text + "';update subtbl_cart set percentage = '" + lblPercent.Text + "' where cart_id = '" + txtCartID.Text + "';Select * from subtbl_cart where cart_id = '" + txtCartID.Text + "'";

                    //        MySqlConnection Conn1 = new MySqlConnection(Connection);
                    //        MySqlCommand cmd1 = new MySqlCommand(Query1, Conn1);
                    //        cmd1.CommandTimeout = 0;

                    //        try
                    //        {

                    //            Conn1.Open();
                    //            myReader = cmd1.ExecuteReader();
                    //            while (myReader.Read())
                    //            {

                    //                txtDiscountGiven.Text = myReader[15].ToString();
                    //                txtDiscount.Text = myReader[14].ToString();
                    //                txtGrandTotal.Text = myReader[12].ToString();
                    //                txtChange.Text = myReader[6].ToString();

                    //                MessageBox.Show("The " + txtnameProd.Text + " is discounted successfully.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //                btnPrintReceipt.Enabled = true;
                    //                btnPrintReceipt.BackColor = Color.DarkBlue;


                    //            }
                    //        }

                    //        catch (Exception ex)
                    //        {
                    //            MessageBox.Show(ex.Message, "Fabula's Merchandise System", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    //        }

                    //        DGVSUMsomecolumncart();
                    //        DGVCart();

                    //    }
                    //    else
                    //    {
                    //        MessageBox.Show("Invalid input for discount. The max percentage is 100 %.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //        return;
                    //    }
                    //    return;
                    //  }

                    //  else
                    //  {



                    //        if (double.Parse(txtCash.Text) >= double.Parse(txtGrandTotal.Text))
                    //            {


                    //                double val4;
                    //             double  val1 = double.Parse(txtCash.Text);
                    //             double   val2 = double.Parse(txtGrandTotal.Text);

                    //                val4 = double.Parse(txtSubTotal.Text);
                    //                string Query = "update subtbl_cart set Cash = '" + val1 + "';update subtbl_cart set Change_Amount = '" + val1 + "' - '" + val2 + "';update subtbl_cart set original_VAT=  '" + this.txtVat.Text + "'; update subtbl_cart set total_amount=  '" + this.txtGrandTotal.Text + "';Select * from subtbl_cart where cart_id = '" + txtCartID.Text + "';";
                    //                MySqlConnection Conn = new MySqlConnection(Connection);
                    //                MySqlCommand cmd = new MySqlCommand(Query, Conn);
                    //                cmd.CommandTimeout = 0;

                    //                try
                    //                {

                    //                    Conn.Open();
                    //                    myReader = cmd.ExecuteReader();
                    //                    while (myReader.Read())
                    //                    {
                    //                        txtForeignProductID.Text = myReader[1].ToString();
                    //                        txtGrandTotal.Text = myReader[12].ToString();
                    //                        txtCategory.Text = myReader[11].ToString();
                    //                        txtCash.Text = myReader[5].ToString();

                    //                        txtDiscountGiven.Text = myReader[15].ToString();
                    //                        txtDiscount.Text = myReader[14].ToString();
                    //                        txtChange.Text = myReader[6].ToString();

                    //                        btnPrintReceipt.Enabled = true;
                    //                        txtGrandTotal.Text = total;
                    //                        txtDiscount.Text = "0.00";
                    //                        txtDiscountGiven.Text = "0";
                    //                        btnPrintReceipt.Enabled = true;
                    //                    }
                    //                }

                    //                catch (Exception ex)
                    //                {
                    //                    MessageBox.Show(ex.Message, "Fabula's Merchandise System", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    //                }

                    //                Conn.Close();


                    //               DGVSUMsomecolumncart();

                    //            }
                    //            else
                    //            {

                    //                MessageBox.Show("Purchased failed.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //                btnPrintReceipt.Enabled = false;
                    //                btnPrintReceipt.BackColor = Color.DarkGray;
                    //                txtChange.Text = "0.00";

                    //                return;

                    //            }

                    //        //}


                    //    }

                    //    catch (FormatException ex)
                    //    {
                    //        MessageBox.Show(ex.Message, "Fabula's Merchandise System", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    //    }
                    //}
                    //catch (Exception ex)
                    //{
                    //    MessageBox.Show(ex.Message, "Fabula's Merchandise System", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);

                    //}
                    //btnPrintReceipt.BackColor = Color.DarkBlue;
                    //btnPrintReceipt.Enabled = true;
                    if (txtCash.Text == "" || txtCash.Text == "0")
                    {
                        MessageBox.Show("Enter cash.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.None);
                        return;
                    }
                    try
                    {


                        decimal cash = decimal.Parse(txtCash.Text);
                        decimal change = cash - decimal.Parse(txtGrandTotal.Text);
                        txtChange.Text = change.ToString();

                        if (decimal.Parse(txtCash.Text) < decimal.Parse(txtGrandTotal.Text))
                        {
                            txtChange.Text = "0.00";
                            txtCash.Text = "0.00";
                            txtCash.ForeColor = Color.Gray;

                    MessageBox.Show("Purchased invalid.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            btnPrintReceipt.Enabled = false;
                            btnPrintReceipt.BackColor = Color.Gray;
                            return;
                        }
                        btnPrintReceipt.Enabled = true;
                        btnPrintReceipt.BackColor = Color.DarkBlue;
                    }
                    catch (Exception)
                    {

                    }

                }

        private void btnHome_Click_2(object sender, EventArgs e)
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

        private void btnCalcu_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.AppStarting;
            var myform = new frm_Calculator();
                myform.Show();
           
                
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            txtCash.Text = "0.00";
            txtCash.ForeColor = Color.Gray;
        }

        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {
            try
            {

                MySqlConnection Conn = ConString.Connection;
                DataTable dt = new DataTable();

                MySqlDataAdapter sda = new MySqlDataAdapter("SELECT tbl_inventory.product_id as 'Product ID', tbl_product.product_name as 'Product Name', QTY, tbl_product.remarks as 'SRP', tbl_inventory.status_pending as 'Status', date_delivered as 'Date Ordered', date_expected as 'Date Expected' FROM tbl_inventory inner join tbl_product on tbl_inventory.product_id = tbl_product.product_id inner join tbl_store on tbl_inventory.store_id = tbl_store.store_id where tbl_inventory.status_pending = 'Not Available' and tbl_store.store_id = '"+frm_Login.global_storeid+ "' and tbl_product.product_name like '%" + txtSearch.Text + "%' or tbl_inventory.status_pending = 'Available' and tbl_store.store_id = '" + frm_Login.global_storeid+ "' and tbl_product.product_name like '%" + txtSearch.Text + "%' group by tbl_inventory.product_id", Conn);
                sda.Fill(dt);
                Conn.Close();
                dataGridView2.DataSource = dt;

                dataGridView2.DefaultCellStyle.SelectionBackColor = Color.Pink;

                if (txtSearch.Text == "Search" || txtSearch.Text == "")
                {

                    BranchRefresh();
                    lblMatch.Hide();
                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
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
                    //txtProductID.Text = row.Cells[0].Value.ToString();
                    //lblProductName.Text = row.Cells[1].Value.ToString();
                    //lblUnitPrice.Text = row.Cells[2].Value.ToString();
                    //txtQty.Text = row.Cells[3].Value.ToString();
                    //lblDescription.Text = row.Cells[4].Value.ToString();
                    //lblStock.Text = row.Cells[5].Value.ToString();
                    //lblVat.Text = row.Cells[6].Value.ToString();
                    //lblTotalPrice.Text = row.Cells[7].Value.ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Warning);

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
        }

        private void txtSearch_Leave_1(object sender, EventArgs e)
        {
            if (txtSearch.Text.Length == 0)
            {
                txtSearch.Text = "Search";
                txtSearch.ForeColor = SystemColors.GrayText;
            }
        }

        private void txtSearch_KeyUp_1(object sender, KeyEventArgs e)
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

        private void txtSearch_KeyPress_1(object sender, KeyPressEventArgs e)
        {

            if (txtSearch.Text == "Search")
            {
                txtSearch.Text = "";
            }
        }

        private void txtSearch_KeyDown_1(object sender, KeyEventArgs e)
        {
            //Cursor.Current = Cursors.WaitCursor;
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

        private void btnVoid_Click(object sender, EventArgs e)
        {
            generator3();
            generator();
            Cursor.Current = Cursors.AppStarting;
          
            if (txtGrandTotal.Text == "" || txtGrandTotal.Text == "0")
            {
              
                string s = String.Empty;
                return;
            }
         
            subqty = txtSubQTY.Text;
            substock = lblsubStock.Text;
            recoidId = txtRecordID.Text;
            subproductname = txtsubproductname.Text;
            foreignproductid = txtForeignProductID.Text;
            foreigncustomerid =int.Parse(txtCustomerID.Text);
            date = lblDateTime.Text;


            Cursor.Current = Cursors.WaitCursor;
            var Void = new frm_Void();
            Void.ShowDialog();

            DGVCart();
           // DGVProductList();
            DGVSUMsomecolumncart();

            RemoveListCritical();
            subRemoveListCritical();
            AreaCriticalLevel();
            BranchRefresh();
            // DGVRefreshProductList();

            changeRowColor();
            txtDiscountGiven.Text = "0";
            txtDiscount.Text = "0.00";
            txtCash.Text = "0.00";
            txtChange.Text = "0.00";
            txtDiscount.Enabled = true;


            //decimal sum = 0;
            //decimal sumitem = 0;
            //decimal sumvat = 0;
            //for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            //{

            //    sum += Convert.ToDecimal(dataGridView1.Rows[i].Cells[4].Value);
            //    //sumitem += Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value);
            //    //sumvat += Convert.ToDecimal(dataGridView1.Rows[i].Cells[6].Value);
            //}


            //txtGrandTotal.Text = sum.ToString();
            //txtProductItemQTY.Text = sumitem.ToString();
            //txtVat.Text = sumvat.ToString();
            NotificationofCriticalLevel();
            try
            {
                if (!dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].IsNewRow)
                {
                    foreach (DataGridViewCell cell in dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells)
                    {
                       
                        btnVoid.BackColor = Color.IndianRed;
                        btnVoid.Enabled = true;
                        btnPrintReceipt.Enabled = true;
                        btnPrintReceipt.BackColor = Color.DarkBlue;
                        if (cell.Value == System.DBNull.Value)
                        {

                        }
                    }


                }
            }
            catch (NullReferenceException)
            {
                btnVoid.BackColor = Color.DarkGray;
                btnVoid.Enabled = false;
                btnPrintReceipt.Enabled = false;
                btnPrintReceipt.BackColor = Color.DarkGray;
  
                return;
            }
            if (txtCash.Text == "0.00")
            {
                btnPrintReceipt.Enabled = false;
                btnPrintReceipt.BackColor = Color.DarkGray;
            }


        }
        
        private void btnPrintReceipt_Click(object sender, EventArgs e)
        {
            date = lblDateTime.Text;
          
            generator3();
            //if (txtChange.Text.Contains("-"))
            //{
            //    MessageBox.Show("Save and print failed.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    txtChange.Text = "0.00";
            //    txtCash.Text = "0.00";
            //    return;
            //}
            if(txtGrandTotal.Text == "" || txtGrandTotal.Text=="0"|| txtGrandTotal.Text == "0.00")
            {
                MessageBox.Show("Enter Cash","Fabula's Merchandise System");
                return;
            }
            try
            { //catch
                generator();

                Cursor.Current = Cursors.WaitCursor;

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
                    MessageBox.Show("Please add one or more products to cart in selection product list.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.None);
                 
                    return;
                }
                if (txtCash.Text == "0.00" || txtCash.Text == "0")
                {
                    MessageBox.Show("Insert cash.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.None);
                    string s = String.Empty;
                    return;
                }
                if (txtGrandTotal.Text == "" || txtGrandTotal.Text == "0" || txtCash.Text == "" || txtCash.Text == "0.00" || txtGrandTotal.Text == "0.00" || txtSubTotal.Text == "0.00" || txtVat.Text == "")
                {
                    MessageBox.Show("Please add one or more products to cart in selection product list.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.None);
                    string s = String.Empty;
                    return;
                }

                if (txtCustomerName.Text == "Customer Name" || txtContact.Text == "Customer Phone #" || txtAddress.Text == "Address" || txtAddress.Text == "")
                {

                    if (lblphone.Visible == true)
                    {
                        MessageBox.Show("The phone number format is not recognized.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    DialogResult confirm = MessageBox.Show("Do you want to continue printing without knowing complete details for customer?", "Fabula's Merchandise System", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (confirm == DialogResult.Yes)// 1
                    {

                        try
                        {



                            //if (txtContact.Text == "Customer Phone #" && txtAddress.Text == "Address")
                            //{
                            //    txtContact.Text = "";
                            //    txtAddress.Text = "";


                            //}
                            if (txtAddress.Text == "Address")
                            {

                                txtAddress.Text = "";


                            }
                            if (txtContact.Text == "Customer Phone #")
                            {
                                txtContact.Text = "";

                            }
                            if (txtCustomerName.Text == "Customer Name")
                            {

                                txtCustomerName.Text = "";
                            }


                            //if (txtCustomerName.Text == "Customer Name" || txtContact.Text == "Customer Phone #" || txtAddress.Text != "Address")
                            //{

                            //    txtAddress.Text = "";


                            //}
                            //if (txtCustomerName.Text == "Customer Name" || txtContact.Text != "Customer Phone #" || txtAddress.Text == "Address")
                            //{

                            //    txtContact.Text = "";

                            //}

                            //keme



                            date = lblDateTime.Text;
                            Cursor.Current = Cursors.WaitCursor;

                            PrintDialog printDialog = new PrintDialog();

                            PrintDocument printDocument = new PrintDocument();

                            printDialog.Document = printDocument;

                            printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocument1_PrintPage);
                            printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocument1_PrintPage);
                            printPreviewDialog1.Document = printDocument1;
                            //  printPreviewDialog1.ShowDialog();



                            DialogResult result = printPreviewDialog1.ShowDialog();







                            //if (result == DialogResult.OK)
                            //{


                            //    MessageBox.Show("Save receipt into the files for printing the transaction.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            //   printDocument1.Print();
                            Cursor.Current = Cursors.WaitCursor;


                            try
                            {


                                MySqlConnection Conn = ConString.Connection;
                                MySqlDataReader myReader;
                                string Query = "insert into tbl_customers (customer_id, trans_id, product_id, Order_ref, customer_name, contact_no, address, store_id) values ('" + this.txtCustomerID.Text + "', '" + this.txtRecordID.Text + "', '" + this.txtProductID.Text + "', '" + Convert.ToInt32(this.txtRef.Text) + "', '" + this.txtCustomerName.Text + "', '" + this.txtContact.Text + "', '" + this.txtAddress.Text + "', '" + txtstore_id.Text + "')";


                                MySqlCommand cmd = new MySqlCommand(Query, Conn);
                                cmd.CommandTimeout = 500000;


                                myReader = cmd.ExecuteReader();
                                while (myReader.Read())
                                {

                                   // MessageBox.Show("Na-insert sa customer", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.None);

                                }
                                Conn.Close();
                            }



                            catch (FormatException ex1)
                            {
                                MessageBox.Show(ex1.Message, "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                            string remove = "No";
                            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                            {
                                MySqlConnection Conn = ConString.Connection;
                                MySqlDataReader myReader;

                                string Query = "insert into tbl_transactionrecord(trans_id, product_id, product_name, quantity, amount, description,vat, stock, discount, discountgiven, dateortime, price, date, time, status, store_id, customer_id, remove, leadtime) values('" + Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value) + "', '" + Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value) + "', '" + dataGridView1.Rows[i].Cells[2].Value + "', '" + Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value) + "', '" + Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value) + "', '" + dataGridView1.Rows[i].Cells[5].Value + "', '" + Convert.ToDouble(dataGridView1.Rows[i].Cells[6].Value) + "','" + Convert.ToInt32(dataGridView1.Rows[i].Cells[7].Value) + "', '" + dataGridView1.Rows[i].Cells[8].Value + "', '" + dataGridView1.Rows[i].Cells[9].Value + "', '" + dataGridView1.Rows[i].Cells[10].Value + "', '" + Convert.ToDouble(dataGridView1.Rows[i].Cells[11].Value) + "', '" + dataGridView1.Rows[i].Cells[12].Value + "', '" + dataGridView1.Rows[i].Cells[13].Value + "', '" + dataGridView1.Rows[i].Cells[14].Value + "', '" + dataGridView1.Rows[i].Cells[15].Value + "', '" + this.txtCustomerID.Text + "', '" + remove + "', '" + Convert.ToInt32(dataGridView1.Rows[i].Cells[16].Value) + "' );delete from subtbl_cart where store_id = '" + frm_Login.global_storeid + "'";

                                MySqlCommand cmd = new MySqlCommand(Query, Conn);
                                cmd.CommandTimeout = 0;


                                myReader = cmd.ExecuteReader();
                                while (myReader.Read())
                                {
                                   // MessageBox.Show("Na-delete", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.None);
                                    subproductname = myReader.GetString("product_name");

                                }
                                Conn.Close();
                            }

                            txtChange.Text = "0.00";
                            txtGrandTotal.Text = "0.00";
                            txtVat.Text = "0.00";
                            txtQty.Text = "0";

                            txtSubTotal.Text = "0.00";
                            txtDiscount.Text = "0.00";
                            txtDiscountGiven.Text = "0";
                            txtCash.Text = "0.00";
                            txtCash.ForeColor = Color.Gray;
                            btnPrintReceipt.Enabled = false;
                            btnPrintReceipt.BackColor = Color.DarkGray;

                            // }
                            generator3();
                            DGVCart();
                            // DGVProductList();
                            BranchRefresh();
                            DGVSUMsomecolumncart();
                            changeRowColor();
                            //  DGVRefreshProductList();

                            int num1;
                            Random rand1 = new Random();
                            num1 = rand1.Next(1, 999999999);
                            txtRef.Text = Convert.ToString(num1);
                            txtCustomerName.Text = "Customer Name";
                            txtContact.Text = "Customer Phone #";
                            txtCustomerName.ForeColor = Color.Silver;
                            txtContact.ForeColor = Color.Silver;
                            btnReceipt5.Enabled = false;
                            txtAddress.Text = "Address";
                            txtAddress.ForeColor = Color.Silver;

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
                                btnVoid.BackColor = Color.DarkGray;
                                btnVoid.Enabled = false;

                                return;
                            }
                            return;


                            //kkkk
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }

                 
                    else if (confirm == DialogResult.No)
                    {

                        return;
                    }

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

                if (txtContact.Text == "Contact Phone #" || txtContact.Text == "")
                {
                    lblphone.Hide();
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










                if (double.Parse(txtCash.Text) >= double.Parse(txtGrandTotal.Text))//2
                {





                    date = lblDateTime.Text;
                    Cursor.Current = Cursors.WaitCursor;

                    PrintDialog printDialog = new PrintDialog();

                    PrintDocument printDocument = new PrintDocument();

                    printDialog.Document = printDocument;

                    printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocument1_PrintPage);
                    printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocument1_PrintPage);
                    printPreviewDialog1.Document = printDocument1;
                //    printPreviewDialog1.ShowDialog();

                    DialogResult result = printPreviewDialog1.ShowDialog();

                  




                    //if (result == DialogResult.OK)
                    //{


                    //    MessageBox.Show("Save receipt into the files for printing the transaction.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                     //   printDocument1.Print();
                        Cursor.Current = Cursors.WaitCursor;
                      

                        try
                        {


                        MySqlConnection Conn = ConString.Connection;
                        MySqlDataReader myReader;
                            string  Query = "insert into tbl_customers (customer_id, trans_id, product_id, Order_ref, customer_name, contact_no, address, store_id) values ('" + this.txtCustomerID.Text + "', '" + this.txtRecordID.Text + "', '" + this.txtProductID.Text + "', '" + Convert.ToInt32(this.txtRef.Text) + "', '" + this.txtCustomerName.Text + "', '" + this.txtContact.Text + "', '"+this.txtAddress.Text+"', '"+frm_Login.global_storeid+"')";
                        
                        MySqlCommand cmd = new MySqlCommand(Query, Conn);
                            cmd.CommandTimeout = 500000;

                          
                          myReader = cmd.ExecuteReader();
                            while (myReader.Read())
                            {


                            }
                        Conn.Close();
                        }



                        catch (FormatException ex1)
                        {
                            MessageBox.Show(ex1.Message, "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                      
                        string remove = "No";

                        for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                        {
                        MySqlConnection Conn = ConString.Connection;
                        MySqlDataReader myReader;
                       

                            string Query = "insert into tbl_transactionrecord(trans_id, product_id, product_name, quantity, amount, description,vat, stock, discount, discountgiven, dateortime, price, date, time, status, store_id, customer_id, remove, leadtime) values('" + Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value) + "', '" + Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value) + "', '" + dataGridView1.Rows[i].Cells[2].Value + "', '" + Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value) + "', '" + Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value) + "', '" + dataGridView1.Rows[i].Cells[5].Value + "', '" + Convert.ToDouble(dataGridView1.Rows[i].Cells[6].Value) + "','" + Convert.ToInt32(dataGridView1.Rows[i].Cells[7].Value) + "', '" +dataGridView1.Rows[i].Cells[8].Value + "', '" + dataGridView1.Rows[i].Cells[9].Value+ "', '"+dataGridView1.Rows[i].Cells[10].Value + "', '"+Convert.ToDouble(dataGridView1.Rows[i].Cells[11].Value)+ "', '"+dataGridView1.Rows[i].Cells[12].Value+ "', '" +dataGridView1.Rows[i].Cells[13].Value+ "', '"+dataGridView1.Rows[i].Cells[14].Value+"', '"+ dataGridView1.Rows[i].Cells[15].Value + "', '"+txtCustomerID.Text+"','"+remove+ "', '" + Convert.ToInt32(dataGridView1.Rows[i].Cells[16].Value) + "');delete from subtbl_cart where store_id = '" + frm_Login.global_storeid+"'";
                   
        
                            MySqlCommand cmd = new MySqlCommand(Query, Conn);
                            cmd.CommandTimeout = 0;

                         
                            myReader = cmd.ExecuteReader();
                            while (myReader.Read())
                            {

                                subproductname = myReader.GetString("product_name");

                            }
                        Conn.Close();
                        }
                    changeRowColor();
                    txtChange.Text = "0.00";
                        txtGrandTotal.Text = "0.00";
                        txtVat.Text = "0.00";
                        txtQty.Text = "0";
                     
                        txtSubTotal.Text = "0.00";
                        txtDiscount.Text = "0.00";
                        txtDiscountGiven.Text = "0";
                        txtCash.Text = "0.00";
                        txtCash.ForeColor = Color.Gray;
                        btnPrintReceipt.Enabled = false;
                        btnPrintReceipt.BackColor = Color.DarkGray;
                  
                }
              
                //}
                //else
                //{

                //    MessageBox.Show("Order print failed for cash: " + txtCash.Text + ".", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
            }


            catch (Exception ex1)
            {


                MessageBox.Show(ex1.Message, "Error001", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            generator3();
            DGVCart();
           // DGVProductList();
            DGVSUMsomecolumncart();

            int num;
            Random rand = new Random();
            num = rand.Next(1, 999999999);
            txtRef.Text = Convert.ToString(num);
            txtCustomerName.Text = "Customer Name";
            txtContact.Text = "Customer Phone #";
            txtCustomerName.ForeColor = Color.Silver;
            txtContact.ForeColor = Color.Silver;
            btnReceipt5.Enabled = false;
            txtAddress.Text = "Address";
            txtAddress.ForeColor = Color.Silver;
        
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
                btnVoid.BackColor = Color.DarkGray;
                btnVoid.Enabled = false;
           
                return;
            }
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            getPrice = txtGrandTotal.Text;





            try
            {

                Graphics graphic = e.Graphics;

                Font font = new Font("Century Gothic", 16);
                Font font1 = new Font("Century Gothic", 16, FontStyle.Bold);

                float fontHeight = font.GetHeight();

                int startX = 10;
                int startY = 470;
                int offset = 40;

                //keme1

                // System.Drawing.Image img = System.Drawing.Image.FromFile("D:\\Foto.jpg");
                Point loc = new Point(165, 20);
                e.Graphics.DrawImage(Properties.Resources.f_m1, loc);







                e.Graphics.DrawString("___________________________________________________________________________________________________________________________________________________________________________________________ ", new Font("Century Gothic", 16, FontStyle.Bold), Brushes.Black, new Point(0, 210));



                e.Graphics.DrawString("SI #: ", new Font("Century Gothic", 16, FontStyle.Bold), Brushes.Black, new Point(10, 240));
                e.Graphics.DrawString(txtRef.Text, new Font("Century Gothic", 16, FontStyle.Regular), Brushes.Black, new Point(135, 240));

                e.Graphics.DrawString("Date: ", new Font("Century Gothic", 16, FontStyle.Bold), Brushes.Black, new Point(10, 270));
                e.Graphics.DrawString(lblDateTime.Text, new Font("Century Gothic", 16, FontStyle.Regular), Brushes.Black, new Point(135, 270));


                if (frm_Login.user == "Staff")
                {
                    txtName.Text = myName + (" ") + frm_Login.surname;

                    //    panelSupervisor.Visible = false;

                    panelSupervisor.Visible = false;
                    e.Graphics.DrawString("Staff: ", new Font("Century Gothic", 16, FontStyle.Bold), Brushes.Black, new Point(10, 300));
                    e.Graphics.DrawString(txtName.Text, new Font("Century Gothic", 16, FontStyle.Regular), Brushes.Black, new Point(135, 300));


                }


                else if (frm_Login.supervisor == "Supervisor")
                {

                    txtName.Text = myName + (" ") + frm_Login.surname;
                    e.Graphics.DrawString("Supervisor: ", new Font("Century Gothic", 16, FontStyle.Bold), Brushes.Black, new Point(10, 300));
                    e.Graphics.DrawString(txtName.Text, new Font("Century Gothic", 16, FontStyle.Regular), Brushes.Black, new Point(135, 300));
                }

             

                //  e.Graphics.DrawImage(newImage, 20, 20, newImage.Width, newImage.Height);
              

                e.Graphics.DrawString("Address: ", new Font("Century Gothic", 16, FontStyle.Bold), Brushes.Black, new Point(10, 330));
                e.Graphics.DrawString(storeStreet + ", "+ " "+ storeBarangay + " " + storeCity, new Font("Century Gothic", 16, FontStyle.Regular), Brushes.Black, new Point(135, 330));

              

                e.Graphics.DrawString("___________________________________________________________________________________________________________________________________________________________________________________________ ", new Font("Century Gothic", 16, FontStyle.Bold), Brushes.Black, new Point(0, 350));

              

                e.Graphics.DrawString("Sold to: ", new Font("Century Gothic", 16, FontStyle.Bold), Brushes.Black, new Point(10, 380));
                e.Graphics.DrawString(txtCustomerName.Text, new Font("Century Gothic", 16, FontStyle.Regular), Brushes.Black, new Point(135, 380));

                e.Graphics.DrawString("Contact #: ", new Font("Century Gothic", 16, FontStyle.Bold), Brushes.Black, new Point(10, 410));
                e.Graphics.DrawString(txtContact.Text, new Font("Century Gothic", 16, FontStyle.Regular), Brushes.Black, new Point(135, 410));

                e.Graphics.DrawString("Address: ", new Font("Century Gothic", 16, FontStyle.Bold), Brushes.Black, new Point(10, 440));
                e.Graphics.DrawString(txtAddress.Text, new Font("Century Gothic", 16, FontStyle.Regular), Brushes.Black, new Point(135, 440));




                e.Graphics.DrawString("___________________________________________________________________________________________________________________________________________________________________________________________ ", new Font("Century Gothic", 16, FontStyle.Bold), Brushes.Black, new Point(0, 460));

                e.Graphics.DrawString("PRODUCT ", new Font("Century Gothic", 16, FontStyle.Bold), Brushes.Black, new Point(10, 500));
                e.Graphics.DrawString("QTY ", new Font("Century Gothic", 16, FontStyle.Bold), Brushes.Black, new Point(400, 500));
                e.Graphics.DrawString("UNIT PRICE", new Font("Century Gothic", 16, FontStyle.Bold), Brushes.Black, new Point(700, 500));


                MySqlConnection Conn = ConString.Connection;
                MySqlDataReader myReader;



                MySqlCommand cmd = new MySqlCommand(" select product_name, sum(qty), product_id, sum(Total_price), Total_Amount, Cash, Change_Amount, Vat, sum(sub_total) from subtbl_cart where store_id = '" + frm_Login.global_storeid + "' and product_id = product_id group by product_name;", Conn);

                try
                {

                    myReader = cmd.ExecuteReader();

                    while (myReader.Read())
                    {
                        getProductName = myReader["product_name"].ToString();
                        getQTY = myReader["sum(QTY)"].ToString();

                        getPrice = myReader["sum(Total_Price)"].ToString();
                        getTotal = myReader["Total_Amount"].ToString();
                        getCash = myReader["Cash"].ToString();
                        getChange = myReader["Change_Amount"].ToString();
                        getSubTotal = myReader["sum(sub_total)"].ToString();
                        getItem = txtQty.Text;

                        getVAT = txtVat.Text;

                        offset = offset + 22;
                        graphic.DrawString("", font, new SolidBrush(Color.Black), startX, startY + offset);




                        try
                        {


                            getPrice = string.Format("{0:n}", double.Parse(getPrice));
                        }
                        catch (Exception)
                        {

                        }
                        //keme
                        graphic.DrawString(getProductName, font, new SolidBrush(Color.Black), startX, startY + offset);
                        offset = offset + 5;


                        graphic.DrawString("                                                              " + Convert.ToString(getQTY), font, new SolidBrush(Color.Black), startX, startY + offset);
                        offset = offset + 5;
                        graphic.DrawString("                                                                                                                 " + Convert.ToString(getPrice), font, new SolidBrush(Color.Black), startX, startY + offset);

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                Conn.Close();



                offset = offset + 10;
                graphic.DrawString("________________________________________________________________________________________________________________________________________________________________________________________", font, new SolidBrush(Color.Black), 0, startY + offset);
                offset = offset + 30;
                graphic.DrawString("                                                                                               Item(s): ", font1, new SolidBrush(Color.Black), startX, startY + offset);
                graphic.DrawString("                                                                                                                 " + txtProductItemQTY.Text, font, new SolidBrush(Color.Black), startX, startY + offset);

                offset = offset + 30;
                graphic.DrawString("                                                                                               Subtotal: ", font1, new SolidBrush(Color.Black), startX, startY + offset);
                graphic.DrawString("                                                                                                                 " + txtSubTotal.Text, font, new SolidBrush(Color.Black), startX, startY + offset);

                offset = offset + 30;
                graphic.DrawString("                                                                                               12% VAT: ", font1, new SolidBrush(Color.Black), startX, startY + offset);
                graphic.DrawString("                                                                                                                 " + txtVat.Text, font, new SolidBrush(Color.Black), startX, startY + offset);


               
                offset = offset + 30;
                graphic.DrawString("                                                                                               Total: ", font1, new SolidBrush(Color.Black), startX, startY + offset);
                graphic.DrawString("                                                                                                                 " + txtGrandTotal.Text, font, new SolidBrush(Color.Black), startX, startY + offset);

                offset = offset + 30;
                graphic.DrawString("                                                                                               Cash: ", font1, new SolidBrush(Color.Black), startX, startY + offset);
                graphic.DrawString("                                                                                                                 " + txtCash.Text, font, new SolidBrush(Color.Black), startX, startY + offset);

                offset = offset + 30;
                graphic.DrawString("                                                                                               Change: ", font1, new SolidBrush(Color.Black), startX, startY + offset);
                graphic.DrawString("                                                                                                                 " + txtChange.Text, font, new SolidBrush(Color.Black), startX, startY + offset);















                //graphic.DrawString("Fabula's Merchandise.", new Font("Courier New", 16), new SolidBrush(Color.Black), startX, startY);

                //    graphic.DrawString("University Parkway Drive,", new Font("Courier New", 14), new SolidBrush(Color.Black), startX, startY + 20);


                //offset = offset + 2;
                //graphic.DrawString("", font, new SolidBrush(Color.Black), startX, startY + offset);
                //graphic.DrawString("Fort Bonifacio Global City, Taguig City", new Font("Courier New", 14), new SolidBrush(Color.Black), startX, startY + offset);
                //offset = offset + 20;
                //graphic.DrawString("", font, new SolidBrush(Color.Black), startX, startY + offset);
                //graphic.DrawString("Date & Time: " + date, font, new SolidBrush(Color.Black), startX, startY + offset);

                //offset = offset + 20;
                //graphic.DrawString("", font, new SolidBrush(Color.Black), startX, startY + offset);
                //graphic.DrawString("Staff: " + txtName.Text, font, new SolidBrush(Color.Black), startX, startY + offset);

                //offset = offset + 20;
                //graphic.DrawString("", font, new SolidBrush(Color.Black), startX, startY + offset);
                //graphic.DrawString("Sales Invoice #: " + txtRef.Text, font, new SolidBrush(Color.Black), startX, startY + offset);
                //offset = offset + 20;
                //graphic.DrawString("", font, new SolidBrush(Color.Black), startX, startY + offset);
                //graphic.DrawString("Sold To: " + txtCustomerName.Text, font, new SolidBrush(Color.Black), startX, startY + offset);
                //offset = offset + 20;
                //graphic.DrawString("", font, new SolidBrush(Color.Black), startX, startY + offset);
                //graphic.DrawString("Contact No.: " + txtContact.Text, font, new SolidBrush(Color.Black), startX, startY + offset);
                //offset = offset + 20;
                //graphic.DrawString("", font, new SolidBrush(Color.Black), startX, startY + offset);
                //graphic.DrawString("Address: " + txtAddress.Text, font, new SolidBrush(Color.Black), startX, startY + offset);

                //    offset = offset + (int)fontHeight + 5;

                //    graphic.DrawString("----------------------------------------------------------------------------------------------------------------------------------", font, new SolidBrush(Color.Black), startX, startY + offset);




                //offset = offset + (int)fontHeight + 3;
                //graphic.DrawString("Item Name".PadRight(0), font, new SolidBrush(Color.Black), startX, startY + offset);
                //string top = "Item Name".PadRight(0);
                //offset = offset + (int)fontHeight + 3;
                //graphic.DrawString("----------------------------------------------------------------------------------------------------------------------------------", font, new SolidBrush(Color.Black), startX, startY + offset);




                //MySqlConnection Conn = ConString.Connection;
                //MySqlDataReader myReader;



                //    MySqlCommand cmd = new MySqlCommand(" select product_name, sum(qty), product_id, sum(Total_price), Total_Amount, Cash, Change_Amount, Vat, sum(sub_total) from subtbl_cart where store_id = '"+frm_Login.global_storeid+"' and product_id = product_id group by product_name;", Conn);

                //    try
                //    {

                //        myReader = cmd.ExecuteReader();

                //        while (myReader.Read())
                //        {
                //            getProductName = myReader["product_name"].ToString();
                //            getQTY = myReader["sum(QTY)"].ToString();

                //            getPrice = myReader["sum(Total_Price)"].ToString();
                //            getTotal = myReader["Total_Amount"].ToString();
                //            getCash = myReader["Cash"].ToString();
                //            getChange = myReader["Change_Amount"].ToString();
                //            getSubTotal = myReader["sum(sub_total)"].ToString();
                //            getItem = txtQty.Text;

                //            getVAT = txtVat.Text;

                //            offset = offset + 22;
                //            graphic.DrawString("", font, new SolidBrush(Color.Black), startX, startY + offset);
                //            graphic.DrawString(getQTY + (" ") + getProductName + (" ") + getPrice, font, new SolidBrush(Color.Black), startX, startY + offset);



                //        }
                //    }
                //    catch (Exception ex)
                //    {
                //        MessageBox.Show(ex.Message);
                //    }
                //    Conn.Close();



                //    offset = offset + (int)fontHeight + 5;

                //   graphic.DrawString("----------------------------------------------------------------------------------------------------------------------------------", font, new SolidBrush(Color.Black), startX, startY + offset);

                //    offset = offset + 22;
                //    graphic.DrawString("", font, new SolidBrush(Color.Black), startX, startY + offset);
                //    graphic.DrawString("Item(s): " + txtProductItemQTY.Text.PadRight(24) + txtGrandTotal.Text, font, new SolidBrush(Color.Black), startX, startY + offset);

                //    // Discount = 0.00

                //    //offset = offset + 22;
                //    //graphic.DrawString("", font, new SolidBrush(Color.Black), startX, startY + offset);
                //   // graphic.DrawString("Discount: ".PadRight(28) + txtDiscount.Text, font, new SolidBrush(Color.Black), startX, startY + offset);


                //    offset = offset + 22;
                //    graphic.DrawString("", font, new SolidBrush(Color.Black), startX, startY + offset);
                //    graphic.DrawString("Sub Total: ".PadRight(33) + txtSubTotal.Text, font, new SolidBrush(Color.Black), startX, startY + offset);


                //    offset = offset + 22;
                //    graphic.DrawString("", font, new SolidBrush(Color.Black), startX, startY + offset);
                //    graphic.DrawString("12 % VAT: ".PadRight(71) + txtVat.Text, new Font("Arial", 11, FontStyle.Regular), new SolidBrush(Color.Black), startX, startY + offset);


                //    offset = offset + 22;
                //    graphic.DrawString("", font, new SolidBrush(Color.Black), startX, startY + offset);
                //    graphic.DrawString("Total Amount: ".PadRight(33) + txtGrandTotal.Text, new Font("Courier New", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + offset);

                //    offset = offset + 22;
                //    graphic.DrawString("", font, new SolidBrush(Color.Black), startX, startY + offset);
                //    graphic.DrawString("Cash: ".PadRight(33) + txtCash.Text, font, new SolidBrush(Color.Black), startX, startY + offset);

                //    offset = offset + 22;
                //    graphic.DrawString("", font, new SolidBrush(Color.Black), startX, startY + offset);
                //    graphic.DrawString("Change: ".PadRight(33) + txtChange.Text, font, new SolidBrush(Color.Black), startX, startY + offset);



                //    offset = offset + (int)fontHeight + 5;
                //    graphic.DrawString("----------------------------------------------------------------------------------------------------------------------------------", font, new SolidBrush(Color.Black), startX, startY + offset);

                //    offset = offset + 25;
                //    graphic.DrawString("", font, new SolidBrush(Color.Black), startX, startY + offset);
                //    graphic.DrawString("      THIS SERVE AS YOUR OFFICIAL RECEIPT.", font, new SolidBrush(Color.Black), startX, startY + offset);

                //    offset = offset + 15;
                //    graphic.DrawString("       THANK YOU AND COME AGAIN!", font, new SolidBrush(Color.Black), startX, startY + offset);


            }

            catch (Exception)
                {

                }

            
        }

        private void btnPOS_Click_1(object sender, EventArgs e)
        {
            //  tabControl1.SelectedTab = tabPage5;

            if (frm_Login.user == "Staff")
            {
              
            }


            else
            {
                Cursor.Current = Cursors.AppStarting;
                var myForm = new frm_Inventory();
                myForm.Show();
                this.Hide();
            }

        }

        private void txtCustomerName_TextChanged(object sender, EventArgs e)
        {
            if (txtCustomerName.Text.Length <= 0) return;
            string s = txtCustomerName.Text.Substring(0, 1);
            if (s != s.ToUpper())
            {
                int curSelStart = txtCustomerName.SelectionStart;
                int curSelLength = txtCustomerName.SelectionLength;
                txtCustomerName.SelectionStart = 0;
                txtCustomerName.SelectionLength = 1;
                txtCustomerName.SelectedText = s.ToUpper();
                txtCustomerName.SelectionStart = curSelStart;
                txtCustomerName.SelectionLength = curSelLength;

            }
        }

        private void btnScrollUp_Click_1(object sender, EventArgs e)
        {
            DGVProductList();
        }

        private void btnScrollBottom_Click_1(object sender, EventArgs e)
        {
            dataGridView2.FirstDisplayedScrollingRowIndex = dataGridView2.RowCount - 1;
        }

        private void btnSort_Click_1(object sender, EventArgs e)
        {
            this.dataGridView2.Sort(this.dataGridView2.Columns["Product Name"], ListSortDirection.Ascending);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            BranchRefresh();
            DGVCart();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }

        private void btnCalculator2_Click_1(object sender, EventArgs e)
        {
            var myform = new frm_Calculator();
            myform.Show();
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
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void txtCash_KeyDown(object sender, KeyEventArgs e)
        {
          
          
        }

        private void txtName_Click(object sender, EventArgs e)
        {

        }

        private void txtAddress_Leave(object sender, EventArgs e)
        {
            if (txtAddress.Text.Length == 0)
            {
                txtAddress.Text = "Address";
                txtAddress.ForeColor = SystemColors.GrayText;
            }
          
        }

        private void txtAddress_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtAddress.Text.Equals(null) == true)
            {
                txtAddress.Text = "Address";
                txtAddress.ForeColor = Color.Gray;
            }
            else if (txtAddress.Text == "Address")
            {
                txtAddress.ForeColor = Color.Gray;
            }
            else
            {
                txtAddress.ForeColor = Color.Black;
            }
            if (e.KeyCode == Keys.Back)
            {
                if (txtAddress.Text.Length == 0)
                {


                    txtAddress.Text = "Address";

                    txtAddress.ForeColor = Color.Silver;
                    Cursor.Current = Cursors.IBeam;


                }
            }
        }

        private void txtAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtAddress.Text == "Address")
            {
                txtAddress.Text = "";
            }
        }

        private void txtAddress_Click(object sender, EventArgs e)
        {
            if (txtAddress.Text == "Address")
            {
                txtAddress.Focus();
                txtAddress.Select(0, 0);

            }
        }

        private void txtQty_Leave(object sender, EventArgs e)
        {
            if (txtQty.Text.Length == 0)
            {
                txtQty.Text = "0";
                txtQty.ForeColor = SystemColors.GrayText;
            }
          
        }

        private void txtQty_Click(object sender, EventArgs e)
        {

        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {
            if (txtAddress.Text.Length <= 0) return;
            string s = txtAddress.Text.Substring(0, 1);
            if (s != s.ToUpper())
            {
                int curSelStart = txtAddress.SelectionStart;
                int curSelLength = txtAddress.SelectionLength;
                txtAddress.SelectionStart = 0;
                txtAddress.SelectionLength = 1;
                txtAddress.SelectedText = s.ToUpper();
                txtAddress.SelectionStart = curSelStart;
                txtAddress.SelectionLength = curSelLength;
            }
        }

        private void txtRef_TextChanged(object sender, EventArgs e)
        {
            MySqlConnection Conn = ConString.Connection;
            var dtt = new DataTable();
            var sda = new MySqlDataAdapter("select order_ref from tbl_customers where order_ref = '" + txtRef.Text + "'", Conn);
            sda.Fill(dtt);
            Conn.Close();


            if (dtt.Rows.Count == 1 || dtt.Rows.Count >= 1)
            {

                int num;
                Random rand = new Random();
                num = rand.Next(1, 999999999);
                txtRef.Text = Convert.ToString(num);
                return;
            }
        }

        private void metroTile2_Click(object sender, EventArgs e)
        {
            

         
        }

        private void metroTile3_Click(object sender, EventArgs e)
        {
        }

        private void txtProductItemQTY_TextChanged(object sender, EventArgs e)
        {
            try
            {


                txtProductItemQTY.Text = string.Format("{0:n0}", double.Parse(txtProductItemQTY.Text));
            }
            catch (Exception)
            {

            }
        }

        private void txtChange_TextChanged(object sender, EventArgs e)
        {
            try
            {


                txtChange.Text = string.Format("{0:n}", double.Parse(txtChange.Text));
            }
            catch (Exception)
            {

            }
        }

        private void txtSubTotal_TextChanged(object sender, EventArgs e)
        {
            try
            {
               

                txtSubTotal.Text = string.Format("{0:n}", double.Parse(txtSubTotal.Text));

            }
            catch (Exception)
            {

            }
        }

        private void txtVat_TextChanged(object sender, EventArgs e)
        {
            try
            {
              
               

                txtVat.Text = string.Format("{0:n}", double.Parse(txtVat.Text));
            }
            catch (Exception)
            {

            }
        }

        private void txtGrandTotal_TextChanged(object sender, EventArgs e)
        {
            try
            {


              
              



                txtGrandTotal.Text = string.Format("{0:n}", double.Parse(txtGrandTotal.Text));
            }
            catch (Exception)
            {

            }
        }

        private void txtCash_TextChanged(object sender, EventArgs e)
        {

           
            btnPrintReceipt.BackColor = Color.Gray;
            btnPrintReceipt.Enabled = false;
            txtChange.Text = "0.00";


            try
            {



                string value = txtCash.Text.Replace(",", "");
                long ul;
                if (long.TryParse(value, out ul))
                {
                    txtCash.TextChanged -= txtCash_TextChanged;
                    txtCash.Text = string.Format("{0:#,#0}",ul);
                    txtCash.SelectionStart = txtCash.Text.Length;
                    txtCash.TextChanged += txtCash_TextChanged;
                }




            }
            catch (Exception)
            {

            }

        }
        void storeinfo()
        {
            MySqlConnection Conn = ConString.Connection;


            Cursor.Current = Cursors.WaitCursor;

            string Query = "select * from tbl_store where store_id = '" + frm_Login.global_storeid + "'; ";

            MySqlCommand cmd = new MySqlCommand(Query, Conn);
            MySqlDataReader myReader;

            myReader = cmd.ExecuteReader();
            while (myReader.Read())
            {


                storeID = Convert.ToInt32(myReader.GetInt32("store_id"));
                storeStreet = myReader.GetString("street");
                storeBarangay = myReader.GetString("barangay");
                storeCity = myReader.GetString("city");







            }

            Conn.Close();
        }
        private void cbStore_TextChanged(object sender, EventArgs e)
        {

            MySqlConnection Conn = ConString.Connection;
            string Query = "select * from tbl_store where store_id = '" + frm_Login.global_storeid + "' and store_name = '" + cbStore.Text.ToString() + "'; ";

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
            MySqlDataAdapter sda = new MySqlDataAdapter("select * from tbl_store where store_id = '"+frm_Login.global_storeid+"' and store_name like '%" + cbStore.Text + "';", Conn);
            sda.Fill(dt);
            sda.SelectCommand = cmd;
            Conn.Close();
            txtstore_id.DataSource = dt;
            txtstore_id.DisplayMember = "store_id";
            txtstore_id.ValueMember = "store_id";
        }

        private void cbStore_SelectedIndexChanged(object sender, EventArgs e)
        {
          

        }

        private void dateOrdered_ValueChanged(object sender, EventArgs e)
        {
         
        }

        private void dateTimePicker4_ValueChanged(object sender, EventArgs e)
        {

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
            Cursor.Current = Cursors.AppStarting;
            var myForm = new frm_Inventory();
            myForm.Show();
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

        private void btnmanageaccounts_Click(object sender, EventArgs e)
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

        private void button5_Click(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
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

        private void button5_Click_1(object sender, EventArgs e)
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

        private void button2_Click_1(object sender, EventArgs e)
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

        private void button1_Click_1(object sender, EventArgs e)
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

        private void button3_Click_1(object sender, EventArgs e)
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

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click_1(object sender, EventArgs e)
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

        private void button8_Click_1(object sender, EventArgs e)
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

        private void btnmanageaccounts_Click_1(object sender, EventArgs e)
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

        private void button14_Click_1(object sender, EventArgs e)
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

        private void button5_Click_2(object sender, EventArgs e)
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

        private void button2_Click_2(object sender, EventArgs e)
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

        private void button11_Click_1(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.AppStarting;
            var myForm = new frm_Inventory();
            myForm.Show();
            this.Hide();
        }

        private void button1_Click_2(object sender, EventArgs e)
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
        public void Online()
        {
            MySqlConnection Conn = ConString.Connection;


            AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();

            string Query = "UPDATE tbl_loginhistory set status = 'Online' where login_id = '" + frm_Login.loginID + "'";
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
        }
        private void button3_Click_2(object sender, EventArgs e)
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

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }
    }
}