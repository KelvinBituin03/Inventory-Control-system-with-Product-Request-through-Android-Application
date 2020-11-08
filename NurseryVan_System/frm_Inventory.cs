using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using NurseryVan_System.Database;

namespace NurseryVan_System
{

    public partial class frm_Inventory : Form
    {
        public static string user;
        int selectedRow;
        public static int mSupplier_ID, mProduct_ID;
        string receivefirst;

        public static string mOrderedQTY, mTotalDue, mStatus, gCategory, gStatus, mDateExpected, mDateOrdered;
        int subOrderID;
        string statusss;
        string productname, subss, subrp, submax;
        string orderstatusss, uncheck;
        public static int orderid;
        public static int receivedzero;



        string mCategory;
        int criticalqty;
        int expiryqty;


        int qtynew;
        int qtycritical1;
        int qtybackorder;
        int ID;

        string nameproduct;
        string description;
        string unitprice;
        public static string manager;
        public static string username;
        string statusnew;
        int productid;
        string category;
        string reason;
        string adjustqty;
        int store_id;
        string storename;
        int suppID;
        int sum;
        string status_receive;
        int quantity_receive;
        int orderID;
        string company;
        string expirydate;
        int product_id;
        string getproductid;
        string pending;
        string request;
        string gettingproductid;
        string statusOK;
        string getpname;
        string status_replacement;
        public static int getting_store_id;
        public static int getting_product_id;
        string image;
        public static string leadtime;
        string getting_status;
        public static DataGridView datagrid;

        OpenFileDialog openFileDialog = new OpenFileDialog();
        string imageFolder = "C:\\\\Users\\\\Elixer Abaya Macafe\\\\Pictures\\\\";
        public frm_Inventory()
        {
            InitializeComponent();
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;

            dataGridView1.Controls.Add(pArrow);
            pArrow.Location = new Point(670, 0);
            pArrow.BackColor = Color.Transparent;

            //  var path = new System.Drawing.Drawing2D.GraphicsPath();
            //path.AddEllipse(0, 0, lblbranchqty.Width, lblbranchqty.Height);

            //this.lblbranchqty.Region = new Region(path);

            // path = new System.Drawing.Drawing2D.GraphicsPath();
            //path.AddEllipse(0, 0, lblqtycritical.Width, lblqtycritical.Height);

            //this.lblqtycritical.Region = new Region(path);


            this.Size = Screen.PrimaryScreen.WorkingArea.Size;

            dataGridView1.Controls.Add(pArrow2);
            pArrow2.Location = new Point(618, 0);
            pArrow2.BackColor = Color.Transparent;


            btnBranchNotify.TabStop = false;
            btnBranchNotify.FlatStyle = FlatStyle.Flat;
            btnBranchNotify.FlatAppearance.BorderSize = 0;

            btngraph.TabStop = false;
            btngraph.FlatStyle = FlatStyle.Flat;
            btngraph.FlatAppearance.BorderSize = 0;

            btnOpenNotify.TabStop = false;
            btnOpenNotify.FlatStyle = FlatStyle.Flat;
            btnOpenNotify.FlatAppearance.BorderSize = 0;


            btnhistorydeliver.TabStop = false;
            btnhistorydeliver.FlatStyle = FlatStyle.Flat;
            btnhistorydeliver.FlatAppearance.BorderSize = 0;




        }


        private void frm_Inventory_Load(object sender, EventArgs e)
        {
            NotifyBranch();
            NotifyCritical();
            setSoontoExpire();
            setExpired();
            NotifyExpiry();
            subNotifyBranch();
            ByNotifyWarehouse();

            subdate.Value = subdate.Value.AddDays(14);

            Production.Text = DateTime.Now.ToString("yyyy-MM-dd");
            Expiry.Text = DateTime.Now.ToString("yyyy-MM-dd");


            //btnRequest1.TextAlign = ContentAlignment.MiddleLeft;
            //btnRequest1.Text = "       Branch Control " + "(" + branchcontrol + ")";

            btnCritical.TextAlign = ContentAlignment.MiddleLeft;
            btnCritical.Text = "       Critical Level " + "(" + criticalqty + ")";

            btnExpiration.TextAlign = ContentAlignment.MiddleLeft;
            btnExpiration.Text = "       Expiration " + "(" + expiryqty + ")";


            btnNP.TextAlign = ContentAlignment.MiddleLeft;
            btnNP.Text = "       New Products " + "(" + qtynew + ")";

            btnCL.TextAlign = ContentAlignment.MiddleLeft;
            btnCL.Text = "       Requests " + "(" + qtycritical1 + ")";


            btnBO.TextAlign = ContentAlignment.MiddleLeft;
            btnBO.Text = "       Backorder " + "(" + qtybackorder + ")";

            int notifyadd = criticalqty + expiryqty;

            int notifyaddbranch = qtycritical1 + qtybackorder;

            lblbranchqty.Text = notifyaddbranch.ToString();

            lblqtycritical.Text = notifyadd.ToString();



            btnSave1.BackColor = Color.DarkGray;


            btnSave1.Enabled = false;

            ComboboxofStore();//checked
            PendingOrdered();
            Ordered();
            OverdueOrdered();
            DGVReceivedProductList();//checked
            DGVstoredisplayproduct();//checked
                                     //checked
            datenotEqual();
            refreshCB();//checked

            PictureBox pic = new PictureBox();
            pic.Width = 16;
            pic.Height = 16;
            pic.Left = 200;

            pic.BackgroundImage = NurseryVan_System.Properties.Resources.search2;
            txtSearch.Controls.Add(pic);

            pic = new PictureBox();
            pic.Width = 16;
            pic.Height = 16;
            pic.Left = 200;

            pic.BackgroundImage = NurseryVan_System.Properties.Resources.search2;
            txtSearch1.Controls.Add(pic);

            try
            {

                metroGrid2.Columns[0].Visible = false;

                metroGrid2.Columns[4].Visible = false;



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Supplier();//checked


            Maxstoreid();//checked
            DGVstoreOK();//checked
            dateNowReceived();

            dataGridView2.Columns[0].Visible = false;
            metroGrid3.Columns[0].Visible = false;
            metroGrid3.Columns[4].Visible = false;
            metroGrid3.Columns[5].Visible = false;
            metroGrid3.Columns[7].Visible = false;
            metroGrid3.Columns[8].Visible = false;
            cbProductList();//
            //ExpiryDate();//
            //ExpiryDateforBranch();

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            metroGrid3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            metroGrid1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            dataGridView44.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            metroGrid2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            SearchList();//
            RemoveListCritical();//
            AreaCriticalLevel();//
            DGVInventoryProductList();

            changeRowColor1();
            changeRowColor();
            changeRowColor2();
            //    CriticalLevel();// 

            showCategory();//

            refreshInventoryProductList();
            StartTimer();
            btnSave1.BackColor = Color.DarkGray;
            btnSave1.Enabled = false;
            //subExpiryDate1();

            // subExpiryDate(); 
            pCritical1.Visible = true;
            btnBranchNotify.Visible = true;



            if (frm_Login.manager == "Manager")
            {
                btnSupplier.Visible = true;
                btngraph.Visible = true;
                btnconfig.Visible = true;
                btnhistorydeliver.Visible = true;
                btnNewStore.Location = new Point(557, 542);
                txtAdjustQty.Visible = true;
                label14.Visible = true;
                label12.Visible = false;
                cbServer.Visible = false;
                panel1.Visible = false;
                tabControl1.TabPages.Remove(tabPage6);
                tabControl1.TabPages.Remove(tabPage5);
                listBox1.Visible = false;
                comboBox2.Visible = false;

                metroGrid1.Visible = false;
                label22.Visible = false;
                tabControl1.TabPages.Remove(tabPage4);
                btnupdatedeliver.Visible = true;
                hideRQ();//checked
                showRQ();//checked
                hideColumn();


            }
            else if (frm_Login.supervisor == "Supervisor")
            {
                tabControl1.TabPages.Remove(tabPage1);
                tabControl1.TabPages.Remove(tabPage5);
                lblNR.Visible = false;
                lblNOrders.Visible = false;
                txtSearch2.Visible = false;
                lblNPend.Visible = false;
                // tabControl1.TabPages.Remove(tabPage3);
                listBox1.Location = new Point(97, 38);
                comboBox2.Location = new Point(369, 9);
                cbServer.Location = new Point(342, 9);
                panel1.Location = new Point(27, 38);
                label26.Visible = false;
                ListCritical.Visible = false;
                label12.Location = new Point(241, 9);
                metroGrid1.Location = new Point(54, 86);



                //   comboBox1.Location = new Point(384, 38);
                btnHome.Text = "CART PAYMENT";
                btnRefresh3.Visible = true;
                dataGridView2.Visible = false;
                label21.Visible = false;
                label22.Visible = false;
                btnAddProduct.Visible = false;
                btnNew.Visible = false;
                changeRowColor();
                btnupdatedeliver.Visible = false;
                btnHome1.Text = "          Point of Sales";
                btnsalereports.Visible = false;
                btnloginhistory1.Location = new Point(0, 362);
                btnmanageaccounts.Location = new Point(0, 436);
                btnmanageaccounts.Text = "                  Manage Account";
                btnLogout1.Location = new Point(0, 508);
                // btnsalereports.Text = "        Login History";
                //   btnmanageaccounts.Visible = false;
                // btnSupp.Text = "Logout";
                btnSupp.Visible = false;
                subSearchingNew();
                SearchingNew();
                ByNotifyBranch();



                changeRowColor1();
                changeRowColor();
                changeRowColor2();
            }
            else


            {
                txtAdjustQty.Visible = true;
                label14.Visible = true;
                btnSave1.Location = new Point(149, 542);
                btnupdatedeliver.Visible = false;
                cbServer.Visible = false;
                panel1.Visible = false;
                btnbackorder.Visible = true;
                lblbackorder.Visible = true;
                btnRefresh1.Visible = true;
                btnReceive1.Visible = true;
                btnPending1.Visible = true;
                btnOrder1.Visible = true;
                dateExpected.Visible = true;
                date_ordered.Visible = true;
                label42.Visible = true;
                btnSent.Visible = true;
                label43.Visible = true;
                dataGridView2.Visible = true;
                tabControl1.TabPages.Remove(tabPage6);
                btnAddProduct.Location = new Point(322, 542);
                tabControl1.TabPages.Remove(tabPage5);
                listBox1.Visible = false;
                comboBox2.Visible = false;
                //  comboBox1.Visible = false;
                metroGrid1.Visible = false;
                label22.Visible = false;
                label12.Visible = false;

                txtProductName.Enabled = false;
                txtUnitPrice.Enabled = false;
                txtDescription.Enabled = false;
                txtRemarks.Enabled = false;
                txtCategory.Enabled = false;

                btnBranchNotify.Visible = false;

                lblbranchqty.Visible = false;
                //  tabControl1.TabPages.Remove(tabPage4);

                //   btnAddProduct.Location = new Point(372, 542);
                btnNewSupplierName.Location = new Point(569, 542);
                btnNewStore.Visible = false;
                btnSupplier.Visible = false;
                //tabControl1.TabPages.Remove(tabPage3);
                btnNewSupplierName.Visible = false;
                cbSupplier.Enabled = false;
                txtAdjustQty.Visible = true;
                label14.Visible = true;
                groupBox1.Visible = true;
                btnLogout.Location = new Point(3, 215);
                btnSave1.Visible = false;
                btnAddProduct.Location = new Point(285, 542);
                btnNewSupplierName.Location = new Point(569, 542);
                btnAddProduct.Visible = false;
                btnNew.Visible = false;

                //btnHome1.Text = "Inventory";
                //btntransactions.Text = "Account";
                //btninventory1.Text = "Login History";
                //btnsalereports.Text = "Logout";
                btninventory1.Location = new Point(0, 153);
                btnloginhistory1.Location = new Point(0, 219);
                btnmanageaccounts.Location = new Point(0, 292);
                btnmanageaccounts.Text = "                  Manage Account";
                btnLogout1.Location = new Point(0, 362);

                btnHome1.Visible = false;
                btntransactions.Visible = false;
                btnsalereports.Visible = false;
                groupBox3.Visible = true;
                hideColumn();
                btnupload.Visible = false;
                btnSupp.Visible = false;
                //  btnmanageaccounts.Visible = false;
                // btnloginhistory1.Visible = false;
                // btnLogout1.Visible = false;
            }
            //  txtQtyRestock.Enabled = false;
            datagrid = dataGridView1;
            //SearchingNew();
            if (txtSubdays.Text == "")
            {
                txtSubdays.Text = "0";
            }
            //try
            //{
            //    if (!dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].IsNewRow)
            //    {
            //        foreach (DataGridViewCell cell in dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells)
            //        {

            //            if (cell.Value == System.DBNull.Value)
            //            {

            //            }
            //        }


            //    }
            //}
            //catch (NullReferenceException ex)
            //{
            //    MessageBox.Show(ex.Message);
            //    //txtProductName.Enabled = false;
            //    //txtCategory.Enabled = false;
            //    //txtUnitPrice.Enabled = false;
            //    //cbSupplier.Enabled = false;


            //}

            zeronotify();
            if (frm_Login.stockman == "Stockman")
            {
                lblbranchqty.Visible = false;
                btnBranchNotify.Visible = false;
            }


            //end
        }

        System.Windows.Forms.Timer time1 = null;
        private void StartTimer()
        {
            time1 = new System.Windows.Forms.Timer();
            time1.Interval = 1000;
            time1.Tick += new EventHandler(t_Tick);
            time1.Enabled = true;
        }

        void zeronotify()
        {
            if (int.Parse(lblqtycritical.Text) == 0)
            {
                lblqtycritical.Visible = false;

            }
            else
            {
                lblqtycritical.Visible = true;
            }
            if (int.Parse(lblbranchqty.Text) == 0)
            {
                lblbranchqty.Visible = false;
                linkLabel1.Visible = false;
            }
            else
            {
                lblbranchqty.Visible = true;
                linkLabel1.Visible = true;
            }
        }

        void subzeronotify()
        {
            if (int.Parse(lblqtycritical.Text) != 0)
            {
                lblqtycritical.Visible = false;

            }
            else
            {

            }

        }
        void subzeronotify1()
        {

            if (int.Parse(lblbranchqty.Text) != 0)
            {
                lblbranchqty.Visible = false;

            }
            else
            {
            }
        }

        void hideNotifyPanel()
        {
            if (frm_Login.manager == "Manager")
            {


                panelNotifyBranch.Visible = false;
                panelNotification.Visible = false;
                pArrow.Visible = false;
                pArrow2.Visible = false;

                btnOpenNotify.Visible = false;
                btnBranchNotify.Visible = true;
                pictureBox1.Visible = false;
                lblqtycritical.Visible = false;
                lblbranchqty.Visible = false;

                zeronotify();
            }
            else if (frm_Login.stockman == "Stockman")
            {



                panelNotifyBranch.Visible = false;
                panelNotification.Visible = false;
                pArrow.Visible = false;
                pArrow2.Visible = false;

                btnOpenNotify.Visible = false;

                pictureBox1.Visible = false;
                lblqtycritical.Visible = false;
                lblbranchqty.Visible = false;



            }

        }

        private void changeRowColor1()
        {
            try
            {


                foreach (DataGridViewRow Myrow in dataGridView1.Rows)
                {
                    if (Myrow.Cells["Status"].Value.ToString() == "Critical Level")
                    {
                        Myrow.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#F53240");
                        Myrow.DefaultCellStyle.ForeColor = System.Drawing.Color.White;

                    }
                    else if (Myrow.Cells["Status"].Value.ToString() == "New Product")
                    {
                        Myrow.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFF00");
                        Myrow.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFF00");
                        Myrow.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;

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
        private void changeRowColor4()
        {
            try
            {


                foreach (DataGridViewRow Myrow in dataGridView1.Rows)
                {
                    if (Myrow.Cells["Status"].Value.ToString() == "Soon to Expire")
                    {
                        Myrow.DefaultCellStyle.BackColor = Color.DarkOrange;
                        Myrow.DefaultCellStyle.ForeColor = System.Drawing.Color.White;

                        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

                    }

                    else if (Myrow.Cells["Status"].Value.ToString() == "Expired")
                    {
                        Myrow.DefaultCellStyle.BackColor = System.Drawing.Color.Red;
                        Myrow.DefaultCellStyle.ForeColor = System.Drawing.Color.White;

                    }

                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }
        private void changeRowColor3()
        {
            try
            {


                foreach (DataGridViewRow Myrow in dataGridView2.Rows)
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
        private void changeRowColor2()
        {
            try
            {


                foreach (DataGridViewRow Myrow in metroGrid3.Rows)
                {
                    if (Myrow.Cells["Status"].Value.ToString() == "OK")
                    {
                        Myrow.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFF00");
                        Myrow.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;

                    }

                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }
        void t_Tick(object sender, EventArgs e)
        {
            lblDateTime.Text = DateTime.Now.ToString();
        }

        public void dateNowReceived()
        {
            try
            {


                MySqlConnection Conn = ConString.Connection;
                string Query = "update tbl_inventory set subStatus = 'OK', status = 'OK', s_replacement = 'Good' " +
                    "where date_expected <= DATE(NOW()) and status != 'Stocked'  and subStatus != 'Received' and subStatus != 'Stocked' and status != 'Not Available'";
                MySqlCommand cmd = new MySqlCommand(Query, Conn);


                MySqlDataReader myReader;
                myReader = cmd.ExecuteReader();



                while (myReader.Read())
                {

                }
                Conn.Close();
                DGVstoreOK();
            }
            catch (Exception)
            {

            }
        }
        public void datenotEqual()
        {
            try
            {


                MySqlConnection Conn = ConString.Connection;
                string Query = "update tbl_inventory set subStatus = 'Pending', status ='Pending', s_replacement = 'Pending' where date_expected > DATE(NOW()) '";
                MySqlCommand cmd = new MySqlCommand(Query, Conn);


                MySqlDataReader myReader;
                myReader = cmd.ExecuteReader();



                while (myReader.Read())
                {

                }
                Conn.Close();
                DGVstoreOK();
            }
            catch (Exception)
            {

            }
        }
        public void subSearchingNew()
        {
            MySqlConnection Conn = ConString.Connection;

            string Query = "Select * from tbl_store where status = 'New' and store_id = '" + txtstore_id.Text + "'";
            MySqlCommand cmd = new MySqlCommand(Query, Conn);
            MySqlDataReader myReader;

            try
            {

                myReader = cmd.ExecuteReader();

                while (myReader.Read())
                {


                    statusnew = myReader.GetString("status");
                    txtnew.Text = myReader.GetString("status");



                }

                Conn.Close();
                btnNew1.Visible = true;
                btnNew1.BackColor = System.Drawing.ColorTranslator.FromHtml("#24262F");
                DGVstoredisplayproduct();
                Maxstoreid();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Error1");
            }

        }
        public void SearchingNew()
        {


            if (txtnew.Text == "New")
            {


                Cursor.Current = Cursors.WaitCursor;




                try
                {

                    for (int i = 0; i < cbProductID.Items.Count; i++)
                    {
                        string value = cbProductID.GetItemText(cbProductID.Items[i]);
                        for (int j = 0; j < txtstore_id.Items.Count; j++)
                        {

                            string value1 = txtstore_id.GetItemText(txtstore_id.Items[j]);

                            int qty = 0;
                            MySqlConnection Conn = ConString.Connection;
                            string Query = "insert into tbl_inventory (product_id, store_id, QTY, subQTY, status, r_status) values ('" + value + "','" + value1 + "', '" + qty + "', 0, 'New Product', 'N/A');update tbl_store set status = 'Available' where status = 'New' and store_id = '" + txtstore_id.Text + "'";

                            MySqlCommand cmd = new MySqlCommand(Query, Conn);
                            cmd.CommandTimeout = 50000;


                            try
                            {


                                MySqlDataReader myReader = cmd.ExecuteReader();
                                while (myReader.Read())
                                {

                                }


                                Conn.Close();
                            }

                            catch (Exception ex1)
                            {
                                MessageBox.Show(ex1.Message);
                            }

                        }
                        //    }
                        //}

                        btnAddproduct1.Visible = false;

                    }
                    MessageBox.Show("All products added successfully.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);





                    btnNew1.Visible = true;
                    btnNew1.BackColor = System.Drawing.ColorTranslator.FromHtml("#24262F");
                    DGVstoredisplayproduct();
                    Maxstoreid();
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message, "Error1");
                }
            }
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

        public void ComboboxofStore()
        {
            MySqlConnection Conn = ConString.Connection;


            AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();

            string Query = "Select store_name from tbl_store";
            MySqlCommand cmd = new MySqlCommand(Query, Conn);
            MySqlDataReader myReader;

            try
            {

                myReader = cmd.ExecuteReader();

                while (myReader.Read())
                {
                    MyCollection.Add(myReader.GetString(0));

                    cbStore.Items.Add(myReader[0]);
                    cbServer.Items.Add(myReader[0]);
                    //   storename = myReader.GetString("store_name");

                }

                cbStore.AutoCompleteCustomSource = MyCollection;
                cbServer.AutoCompleteCustomSource = MyCollection;
                Conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error13");
            }
        }

        public void hideRQ()
        {
            MySqlConnection Conn = ConString.Connection;

            string Query = "Select * from tbl_inventory where status != 'Critical Level' or status != 'New Product'";
            MySqlCommand cmd = new MySqlCommand(Query, Conn);
            MySqlDataReader myReader;

            try
            {

                myReader = cmd.ExecuteReader();

                while (myReader.Read())
                {

                    //  btnBranchNotify.Visible = false;
                    //  lblbranchqty.Visible = false;


                }

                Conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error14");
            }
        }
        public void showRQ()
        {
            MySqlConnection Conn = ConString.Connection;


            string Query = "Select * from tbl_inventory where status = 'Critical Level' or s_replacement = 'Replacement'";
            MySqlCommand cmd = new MySqlCommand(Query, Conn);
            MySqlDataReader myReader;

            try
            {

                myReader = cmd.ExecuteReader();

                while (myReader.Read())
                {

                    btnBranchNotify.Visible = true;
                    lblbranchqty.Visible = true;

                }

                Conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error16");
            }
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
            cbServer.DataSource = dt;

            txtstore_id.DataSource = dt;

            cbStore.DisplayMember = "store_name";
            cbStore.ValueMember = "store_name";
            cbServer.DisplayMember = "store_name";
            cbServer.ValueMember = "store_name";
            txtstore_id.DisplayMember = "store_id";
            txtstore_id.ValueMember = "store_id";

            DataTable dbdataset = new DataTable();
            sda.Fill(dbdataset);
            BindingSource bSource = new BindingSource();

            bSource.DataSource = dbdataset;
            cbStore.DataSource = bSource;
            cbServer.DataSource = bSource;
            txtstore_id.DataSource = bSource;

            sda.Update(dbdataset);
            Conn.Close();
        }
        public void refreshCategory()
        {

            MySqlConnection Conn = ConString.Connection;



            string Query = "select Category from tbl_product group by category";

            MySqlCommand cmd = new MySqlCommand(Query, Conn);


            DataTable dt = new DataTable();
            MySqlDataAdapter sda = new MySqlDataAdapter("select Category from tbl_product group by category", Conn);
            sda.Fill(dt);
            sda.SelectCommand = cmd;

            txtCategory.DataSource = dt;


            txtCategory.DisplayMember = "Category";
            txtCategory.ValueMember = "Category";


            DataTable dbdataset = new DataTable();
            sda.Fill(dbdataset);
            BindingSource bSource = new BindingSource();

            bSource.DataSource = dbdataset;
            txtCategory.DataSource = bSource;


            sda.Update(dbdataset);
            Conn.Close();
        }
        public void Maxstoreid()
        {

            MySqlConnection Conn = ConString.Connection;




            string Query = "select * from tbl_inventory group by store_id";

            MySqlCommand cmd = new MySqlCommand(Query, Conn);


            DataTable dt = new DataTable();
            MySqlDataAdapter sda = new MySqlDataAdapter("select * from tbl_inventory group by store_id", Conn);
            sda.Fill(dt);
            sda.SelectCommand = cmd;


            cbStoreid.DataSource = dt;

            cbStoreid.DisplayMember = "store_id";
            cbStoreid.ValueMember = "store_id";
            DataTable dbdataset = new DataTable();
            sda.Fill(dbdataset);
            BindingSource bSource = new BindingSource();

            bSource.DataSource = dbdataset;

            cbStoreid.DataSource = bSource;
            sda.Update(dbdataset);
            Conn.Close();




        }
        public void refreshCBproduct()
        {

            MySqlConnection Conn = ConString.Connection;




            string Query = "select * from tbl_product";

            MySqlCommand cmd = new MySqlCommand(Query, Conn);


            DataTable dt = new DataTable();
            MySqlDataAdapter sda = new MySqlDataAdapter("select * from tbl_product", Conn);
            sda.Fill(dt);
            sda.SelectCommand = cmd;

            cbProductname.DataSource = dt;
            cbPrice.DataSource = dt;
            cbProductID.DataSource = dt;
            cbProductname.DisplayMember = "product_name";
            cbProductname.ValueMember = "product_name";
            cbPrice.DisplayMember = "remarks";
            cbPrice.ValueMember = "remarks";
            cbProductID.DisplayMember = "product_id";
            cbProductID.ValueMember = "product_id";
            DataTable dbdataset = new DataTable();
            sda.Fill(dbdataset);
            BindingSource bSource = new BindingSource();

            bSource.DataSource = dbdataset;
            cbProductname.DataSource = bSource;
            cbPrice.DataSource = bSource;
            cbProductID.DataSource = bSource;
            sda.Update(dbdataset);
            Conn.Close();

        }


        public void cbProductList()
        {
            MySqlConnection Conn = ConString.Connection;


            string Query = "Select product_name, product_id from tbl_product";
            MySqlCommand cmd = new MySqlCommand(Query, Conn);
            MySqlDataReader myReader;

            AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
            try
            {

                myReader = cmd.ExecuteReader();

                while (myReader.Read())
                {
                    MyCollection.Add(myReader.GetString(0));
                    cbProductname.Items.Add(myReader[0]);
                    cbProductID.Items.Add(myReader[1]);
                    product_id = myReader.GetInt32("product_id");
                }

                cbProductname.AutoCompleteCustomSource = MyCollection;
                cbProductID.AutoCompleteCustomSource = MyCollection;
                Conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void changeRowColor()
        {
            try
            {


                foreach (DataGridViewRow Myrow in metroGrid2.Rows)
                {
                    if (Myrow.Cells["Status"].Value.ToString() == "Critical Level")
                    {
                        Myrow.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#F53240");
                        Myrow.DefaultCellStyle.ForeColor = System.Drawing.Color.White;

                    }
                    //else if (Myrow.Cells["Status"].Value.ToString() == "Available")
                    //{
                    //    Myrow.DefaultCellStyle.BackColor = System.Drawing.Color.White;
                    //    Myrow.DefaultCellStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("#24262F");

                    //}
                    //else if (Myrow.Cells["Status"].Value.ToString() == "Requested")
                    //{
                    //    Myrow.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
                    //    Myrow.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF00FF");

                    //}
                    else if (Myrow.Cells["Status"].Value.ToString() == "OK")
                    {
                        Myrow.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                        Myrow.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFF00");

                    }
                    else if (Myrow.Cells["Status"].Value.ToString() == "")
                    {
                        Myrow.DefaultCellStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("#24262F");
                        Myrow.DefaultCellStyle.BackColor = Color.White;

                    }
                    else if (Myrow.Cells["Status"].Value.ToString() == "Stocked")
                    {
                        Myrow.DefaultCellStyle.BackColor = System.Drawing.Color.White;
                        Myrow.DefaultCellStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("#24262F");


                    }
                    else if (Myrow.Cells["Status"].Value.ToString() == "Pending")
                    {
                        Myrow.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                        Myrow.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#AAF726");


                    }
                    //else if (Myrow.Cells["Status"].Value.ToString() == "Out of Stocked")
                    //{
                    //    Myrow.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
                    //    Myrow.DefaultCellStyle.BackColor = System.Drawing.Color.Red;


                    //}
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }
        void DGVstoredisplayproduct()
        {

            MySqlConnection Conn = ConString.Connection;


            MySqlCommand cmd = new MySqlCommand("SELECT tbl_inventory.product_id as 'Product ID', tbl_product.product_name as 'Product Name', tbl_inventory.QTY as 'QTY', tbl_product.remarks as 'Price', tbl_inventory.status_pending as 'S', tbl_inventory.oq as 'Average Daily Sales', tbl_inventory.critical as 'Critical Level', tbl_inventory.ss as 'Safety Stock', tbl_inventory.rp as 'Reorder Point', tbl_inventory.maxqty as 'Maximum Stock Level', tbl_inventory.status as 'Status' FROM tbl_inventory inner join tbl_product on tbl_inventory.product_id = tbl_product.product_id inner join tbl_store on tbl_inventory.store_id = tbl_store.store_id where tbl_inventory.store_id = '" + frm_Login.global_storeid + "' group by tbl_inventory.product_id;", Conn);
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
                metroGrid2.DefaultCellStyle.SelectionBackColor = Color.Pink;


                Conn.Close();

                changeRowColor();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error55");
            }
        }
        public void ByNotifyBranch()
        {

            MySqlConnection Conn = ConString.Connection;

            string Query = "(SELECT *  FROM ( Select '1' as ID, count(*)  as C_New_Branch1 from (SELECT count(tbl_inventory.product_id)  from tbl_inventory inner join tbl_product on tbl_inventory.product_id = tbl_product.product_id where tbl_inventory.status_pending  = 'Not Available' and tbl_inventory.store_id = '" + frm_Login.global_storeid + "' group by tbl_product.product_id order by count(tbl_product.product_id)) as DerivedTableAlias) AS A) UNION  (SELECT *  FROM ( Select '2' as ID, count(*) as C_New_Branch from (SELECT count(tbl_inventory.product_id)  from tbl_inventory inner join tbl_product on tbl_inventory.product_id = tbl_product.product_id where tbl_inventory.status  = 'New Product' and tbl_inventory.store_id = '" + frm_Login.global_storeid + "' group by tbl_product.product_id order by count(tbl_product.product_id)) as DerivedTableAlias) AS B) UNION (SELECT *  FROM ( Select '3' as ID, count(*) as C_New_Branch from (SELECT count(tbl_inventory.product_id)  from tbl_inventory inner join tbl_product on tbl_inventory.product_id = tbl_product.product_id where tbl_inventory.subStatus  = 'OK' and tbl_inventory.store_id = '" + frm_Login.global_storeid + "' group by tbl_product.product_id order by count(tbl_product.product_id)) as DerivedTableAlias) AS C) UNION (SELECT * FROM(Select '4' as ID, count(*) as C_New_Branch from(SELECT count(tbl_inventory.product_id)  from tbl_inventory inner join tbl_product on tbl_inventory.product_id = tbl_product.product_id where tbl_inventory.status = 'Pending' and tbl_inventory.store_id = '" + frm_Login.global_storeid + "' group by tbl_product.product_id order by count(tbl_product.product_id)) as DerivedTableAlias) AS D)";
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
                        lblN2.Text = myReader.GetString("C_New_Branch1");
                    }

                    if (ID == 2)
                    {
                        lblN1.Text = myReader.GetString("C_New_Branch1");
                    }

                    if (ID == 3)
                    {
                        lblN3.Text = myReader.GetString("C_New_Branch1");
                    }
                    if (ID == 4)
                    {
                        lblN4.Text = myReader.GetString("C_New_Branch1");
                    }



                    if (int.Parse(lblN1.Text) == 0)
                    {
                        lblN1.Visible = false;
                    }
                    else
                    {
                        lblN1.Visible = true;
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

                }
                Conn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error2");
            }
        }
        void DGVstoreOK()
        {

            MySqlConnection Conn = ConString.Connection;

            MySqlCommand cmd = new MySqlCommand("SELECT tbl_inventory.product_id as 'Product ID', tbl_product.product_name as 'Product Name', QTY as 'QTY in Outlet',  tbl_inventory.subQTY as 'Delivered QTY', tbl_inventory.date_delivered as 'Date Delivered', tbl_inventory.date_expected as 'Delivery Date', tbl_inventory.subStatus as 'Status', tbl_inventory.store_id, tbl_inventory.s_replacement FROM tbl_inventory inner join tbl_product on tbl_inventory.product_id = tbl_product.product_id where tbl_inventory.store_id = '" + txtstore_id.Text + "'  and status != 'Stocked' and subStatus != '' and subStatus != 'Stocked' or status_sent = 'Sent' and tbl_inventory.store_id = '" + txtstore_id.Text + "'  group by tbl_inventory.product_id", Conn);
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
                metroGrid3.DefaultCellStyle.SelectionBackColor = Color.Pink;


                Conn.Close();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error555");
            }
            changeRowColor1();
            changeRowColor();
            changeRowColor2();
        }
        public void refreshInventoryProductList()
        {
            MySqlConnection Conn = ConString.Connection;
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM tbl_product where product_id = '" + this.txtProductID.Text + "'", Conn);
            MySqlDataReader myReader = cmd.ExecuteReader();
            generator();
            try
            {
                while (myReader.Read())

                    txtProductID.Text = myReader[0].ToString();
                txtProductName.Text = myReader[1].ToString();
                txtUnitPrice.Text = myReader[2].ToString();

                txtCategory.Text = myReader[14].ToString();
                txtDescription.Text = myReader[7].ToString();
                description = myReader[7].ToString();
                nameproduct = myReader[1].ToString();
                unitprice = myReader[2].ToString();
                Conn.Close();
            }
            catch (Exception)
            {

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
                MessageBox.Show(ex.Message, "Error17");
            }
        }

        void showpic()
        {
            MySqlConnection Conn = ConString.Connection;

            MySqlCommand comm = new MySqlCommand("Select * from tbl_product where product_id =  " + txtProductID.Text + "", Conn);


            MySqlDataAdapter adapt = new MySqlDataAdapter();
            adapt.SelectCommand = comm;
            DataTable table = new DataTable();
            adapt.Fill(table);
            //dataGridView1.DataSource = dt;


            byte[] img = (byte[])table.Rows[0][21];

            MemoryStream ms = new MemoryStream(img);
            pictureBox3.Image = Image.FromStream(ms);

            Conn.Close();
        }
        public void showCategory()
        {
            MySqlConnection Conn = ConString.Connection;


            string Query = "Select category from tbl_product group by category";
            MySqlCommand cmd = new MySqlCommand(Query, Conn);
            MySqlDataReader myReader;

            AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
            try
            {

                myReader = cmd.ExecuteReader();

                while (myReader.Read())
                {
                    MyCollection.Add(myReader.GetString(0));
                    txtCategory.Items.Add(myReader[0]);

                }

                txtCategory.AutoCompleteCustomSource = MyCollection;
                Conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error3");
            }
        }

        public void RemoveListCritical()
        {
            try
            {
                MySqlConnection Conn = ConString.Connection;
                MySqlCommand cmd = new MySqlCommand("Select  max(product_name), stock from tbl_product where stock > critical and product_id = product_id  group by product_name", Conn);
                cmd.CommandTimeout = 50000;

                try
                {

                    MySqlDataReader myReader = cmd.ExecuteReader();


                    while (myReader.Read())
                    {

                        //  lBCritical1.Items.Remove("Critical Level:");

                        ListCritical.Items.Remove(myReader["max(product_name)"]);
                        //   lBCritical1.Items.Remove("Stock: " + myReader["Stock"]);


                        ListCritical.Visible = true;
                        //    lblqtycritical.Hide();
                        // ListCritical.Hide();
                        //pCritical.Hide();
                        //dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Pink;
                        lblRemainingStock.ForeColor = Color.Black;
                        label7.ForeColor = Color.Black;
                    }

                }
                catch (TimeoutException)
                {
                    MessageBox.Show("Program has stopped working due to the operation and server is not responding. Please exit or try again.", "Error program...", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                }
                Conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error4");

            }


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            hideNotifyPanel();
            btnNewSupplierName.Enabled = false;
            btnNewSupplierName.BackColor = Color.DarkGray;
            label19.Visible = true;
            label18.Visible = true;
            dProduction.Visible = true;
            dExpiry.Visible = true;
            changeRowColor1();
            changeRowColor4();

            if (frm_Login.manager == "Manager")
            {
                btnupdatedeliver.Visible = true;
            }
            // txtQtyRestock.BackColor = Color.Linen;

            btnAddProduct.Enabled = false;
            btnAddProduct.BackColor = Color.DarkGray;


            try
            {

                selectedRow = e.RowIndex;
                DataGridViewRow row = dataGridView1.Rows[selectedRow];
                txtProductID.Text = row.Cells[0].Value.ToString();
                txtProductName.Text = row.Cells[1].Value.ToString();
                txtUnitPrice.Text = row.Cells[13].Value.ToString();
                txtRemarks.Text = row.Cells[2].Value.ToString();
                txtAdjustQty.Text = row.Cells[3].Value.ToString();
                txtCategory.Text = row.Cells[4].Value.ToString();
                cbSupplier.Text = row.Cells[5].Value.ToString();
                txtDescription.Text = row.Cells[9].Value.ToString();
                //    txtReason.Text = row.Cells[10].Value.ToString();
                //dProduction.Text = row.Cells[11].Value.ToString();
                //dExpiry.Text = row.Cells[12].Value.ToString();


                //  lblRemainingStock.Text = row.Cells[3].Value.ToString();

            }
            catch (ArgumentException)
            {

            }
            // selectPic_();
        }

        //   void selectPic_()
        //{
        //    MySqlConnection con = ConString.Connection;
        //    //con.Open();
        //    MySqlCommand command = new MySqlCommand("SELECT imageLocation FROM tbl_product WHERE product_id = @product_id", con);
        //    command.Parameters.Add("@product_id", MySqlDbType.Int32).Value = int.Parse(txtProductID.Text);
        //    MySqlDataReader reader = command.ExecuteReader();
        //    while (reader.Read())
        //    {
        //        pictureBox3.Image = new Bitmap(string.Format("\\\\{0}\\{1}",ConString.ip, reader["imageLocation"]).ToString());
        //    }
        //    con.Close();
        //   }

        private void btnLogout_Click_1(object sender, EventArgs e)
        {

        }

        private void btnPOS_Click(object sender, EventArgs e)
        {

        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;


            if (frm_Login.manager == "Manager")
            {
                Cursor.Current = Cursors.AppStarting;
                var myForm = new frm_MainHomeManager(manager);
                myForm.Show();
                this.Hide();
            }
            else if (frm_Login.supervisor == "Supervisor")
            {
                Cursor.Current = Cursors.AppStarting;
                var myForm = new frm_POS();
                myForm.Show();
                this.Hide();
            }

            else
            {
                Cursor.Current = Cursors.AppStarting;
                var myForm = new frm_Inventory();
                myForm.Show();
                this.Hide();
            }
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

        private void btnInventory_Click(object sender, EventArgs e)
        {



            //if (frm_Login.manager == "Manager")
            //{
            //    Cursor.Current = Cursors.AppStarting;
            //    var myForm = new frm_Inventory();
            //    myForm.Show();
            //    this.Hide();

            //}


            //else 
            //{
            //    Cursor.Current = Cursors.AppStarting;
            //    var myForm = new frm_AccountStaff();
            //    myForm.Show();
            //    this.Hide();
            //}
        }
        public void DGVInventoryProductList()
        {

            MySqlConnection Conn = ConString.Connection;

            MySqlCommand cmd = new MySqlCommand("SELECT tbl_product.product_id as 'Product ID', tbl_product.product_name as 'Product Name', tbl_product.remarks as 'Price Remarks', tbl_product.stock as 'Stock', tbl_product.Category as 'Category', tbl_supplierinfo.company as 'Supplier Name', tbl_product.date_added as 'Date Added', tbl_product.date_updated as 'Date Received', tbl_product.critical as 'Critical Level', tbl_product.description, tbl_product.reason, tbl_product.production_date as 'Production Date', tbl_product.expiry_date as 'Expiration Date', tbl_product.product_price as 'Original Price', tbl_product.imageLocation as 'Image', ss as 'Safety Stock', rp as 'Reorder Point', sqty as 'Maximum Level of Stock',  floor((tbl_product.sqty + tbl_product.rp + tbl_product.ss + tbl_product.critical)/4)  as 'Suggested QTY', status_new as 'Status' FROM tbl_product left join tbl_supplierinfo on tbl_product.supplier_id = tbl_supplierinfo.supplier_id group by tbl_product.product_id order by tbl_product.product_id asc", Conn);
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
                //dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Pink;
                Conn.Close();

                btnNewSupplierName.Enabled = false;
                btnNewSupplierName.BackColor = Color.DarkGray;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error5555");
            }


            changeRowColor1();

        }
        public void ExpiryDate()
        {
            try
            {
                if (!dataGridView44.Rows[dataGridView44.CurrentCell.RowIndex].IsNewRow)
                {
                    foreach (DataGridViewCell cell in dataGridView44.Rows[dataGridView44.CurrentCell.RowIndex].Cells)
                    {


                        lblNoExpire.Hide();

                        if (cell.Value == System.DBNull.Value)
                        {

                        }
                    }


                }
            }
            catch (NullReferenceException)
            {


                lblNoExpire.Show();


            }
            MySqlConnection Conn = ConString.Connection;
            MySqlCommand cmd = new MySqlCommand("SELECT product_name as 'Product Name', production_date as 'Production Date', expiry_date as 'Expiration Date' FROM tbl_product where expiry_date <= (date_sub(curdate(), interval - 1 month)) and stock != 0", Conn);
            cmd.CommandTimeout = 0;

            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmd;

                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bSource = new BindingSource();

                bSource.DataSource = dbdataset;

                dataGridView44.DataSource = bSource;

                sda.Update(dbdataset);


                //dataGridView3.DefaultCellStyle.SelectionBackColor = Color.Red;

                //dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Red;



                Conn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error15");
            }

        }

        public void ExpiryDateforBranch()
        {
            try
            {
                if (!dataGridView44.Rows[dataGridView44.CurrentCell.RowIndex].IsNewRow)
                {
                    foreach (DataGridViewCell cell in dataGridView44.Rows[dataGridView44.CurrentCell.RowIndex].Cells)
                    {


                        lblNoExpire.Hide();

                        if (cell.Value == System.DBNull.Value)
                        {

                        }
                    }


                }
            }
            catch (NullReferenceException)
            {


                lblNoExpire.Show();


            }
            MySqlConnection Conn = ConString.Connection;
            MySqlCommand cmd = new MySqlCommand("SELECT tbl_product.product_name as 'Product Name', tbl_product.production_date as 'Production Date', tbl_product.expiry_date as 'Expiration Date' FROM tbl_product inner join tbl_inventory on tbl_product.product_id = tbl_inventory.product_id where tbl_inventory.store_id = '" + txtstore_id.Text + "' and tbl_product.expiry_date <= (date_sub(curdate(), interval - 1 month)) and stock != 0 group by tbl_inventory.product_id;", Conn);
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


                //dataGridView3.DefaultCellStyle.SelectionBackColor = Color.Red;

                //dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Red;



                Conn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error15");
            }

        }

        public void subExpiryDate1()
        {


            DataTable p_table = new DataTable();

            MySqlConnection con = ConString.Connection;
            MySqlCommand command1 = new MySqlCommand("SELECT * FROM tbl_expiry inner join tbl_product on tbl_expiry.product_id = tbl_product.product_id where datediff( tbl_expiry.date_expiry, date(now())) <= tbl_product.notify_days  and tbl_expiry.status != 'Removed';", con);

            p_table.Clear();
            MySqlDataAdapter m_da = new MySqlDataAdapter("SELECT * FROM tbl_expiry inner join tbl_product on tbl_expiry.product_id = tbl_product.product_id where datediff( tbl_expiry.date_expiry, date(now())) <= tbl_product.notify_days  and tbl_expiry.status != 'Removed';", con);

            m_da.Fill(p_table);

            MySqlDataReader reader;
            reader = command1.ExecuteReader();

            StringBuilder productNames = new StringBuilder();

            while (reader.Read())
            {
                productNames.Append(reader["product_name"].ToString() + Environment.NewLine);
            }

            for (int i = 0; i < p_table.Rows.Count; i++)
            {
                DataRow drow = p_table.Rows[i];

                if (drow.RowState != DataRowState.Deleted)
                {

                    ListViewItem lvi = new ListViewItem(drow["expiry_date"].ToString());
                    lvi.SubItems.Add(drow["product_name"].ToString());

                    lblqtycritical.Visible = false;
                    // pCritical1.Hide();
                }



            }
            con.Close();
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


            string Query = "Update tbl_order set status = 'Ordered' where DATE(NOW()) = date_expected and status != 'Received' and quantity_receive = 0 and status != 'Backorder' and status != 'Cancelled Order'";
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
        public void DGVReceivedProductList()
        {



            MySqlConnection Conn = ConString.Connection;

            MySqlCommand cmd = new MySqlCommand("SELECT tbl_order.order_id as 'Order ID', tbl_product.product_name as 'Product', tbl_order.status as 'Status', sum(tbl_order.total_due) as 'Total Due', sum(tbl_order.quantity) as 'Ordered QTY', tbl_order.quantity_receive as 'QTY Received', tbl_order.damage_product as 'Backorder QTY', tbl_supplierinfo.company as 'Supplier Name' ,tbl_order.date_ordered as 'Date Ordered', tbl_order.date_expected as 'Delivery Date', tbl_product.product_id as 'Product ID', tbl_product.stock as 'Stock', tbl_order.supplier_id as 'Supplier ID', tbl_order.subStatus1 as 'S', timestampdiff(day, date(now()), date_expected) as 'Days Left'  FROM tbl_order inner join tbl_product on tbl_order.product_id = tbl_product.product_id inner join tbl_supplierinfo on tbl_order.supplier_id = tbl_supplierinfo.supplier_id  where " +
                "tbl_order.status = 'Ordered' or tbl_order.total_due != 0.00 and tbl_order.status = 'Overdue Ordered' or tbl_order.total_due != 0.00 and tbl_order.status = 'Pending Ordered' or tbl_order.total_due != 0.00 and tbl_order.status = 'Backorder'  or tbl_order.total_due != 0.00 and tbl_order.status = 'Received' " +
                "group by tbl_order.product_id, tbl_order.supplier_id, tbl_order.status, tbl_order.date_expected, tbl_order.date_ordered order by tbl_order.order_id desc", Conn);
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
                //dataGridView2.DefaultCellStyle.SelectionBackColor = Color.Pink;
                Conn.Close();


                dataGridView2.Columns[10].Visible = false;
                dataGridView2.Columns[11].Visible = false;
                dataGridView2.Columns[12].Visible = false;
                dataGridView2.Columns[13].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error6");
            }

            changeRowColor3();


        }
        public void DGVApprovedListProducts()
        {

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            hideNotifyPanel();
            generator();
            btnconfig.Visible = false;

            if (btnAddProduct.Enabled == true)
            {
                btnSave1.Enabled = false;
                btnSave1.BackColor = Color.DarkGray;
            }

            btnNewStore.Location = new Point(557, 542);
            txtCategory.DropDownStyle = ComboBoxStyle.DropDown;
            pictureBox3.Image = null;
            label19.Visible = false;
            label18.Visible = false;
            dProduction.Visible = false;
            dExpiry.Visible = false;
            btnupdatedeliver.Visible = false;
            txtProductName.Text = "";
            txtRemarks.Text = "";
            txtCategory.Text = "";
            txtDescription.Text = "";
            dExpiry.Text = dateTimePicker1.Text;
            dProduction.Text = dateTimePicker1.Text;
            txtUnitPrice.Text = "";
            groupBox1.Visible = false;
            cbSupplier.Visible = false;
            label3.Visible = false;
            btnNewSupplierName.Visible = false;
            txtProductName.Enabled = true;
            txtCategory.Enabled = true;
            txtUnitPrice.Enabled = true;
            btnAddProduct.Enabled = true;
            btnAddProduct.BackColor = System.Drawing.ColorTranslator.FromHtml("#24262F");
            txtProductName.Focus();

            if (btnAddProduct.Enabled == true)
            {
                btnSave1.Enabled = false;
                btnSave1.BackColor = Color.DarkGray;




            }
            btnNew.Enabled = false;
            btnNew.BackColor = Color.DarkGray;




        }

        public void generator()
        {
            NurseryVan_System.AutoGenerator.autoincrement("select max(product_id) from tbl_product ", txtProductID);

        }
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            hideNotifyPanel();
            if (txtUnitPrice.Text == ".")
            {
                MessageBox.Show("Please input price.");
                return;
            }
            MySqlConnection Conn = ConString.Connection;

            var dtt = new DataTable();
            var sda = new MySqlDataAdapter("select product_name from tbl_product where REPLACE(product_name, ' ', '') = REPLACE('" + txtProductName.Text + "', ' ', '')", Conn);
            sda.Fill(dtt);
            Conn.Close();
            if (dtt.Rows.Count >= 1 || dtt.Rows.Count == 1)
            {
                MessageBox.Show("The " + txtProductName.Text + " already exists in warehouse.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            AddProduct();
        
        }


        void AddProduct()
        {

            for (int j = 0; j < cbStoreid.Items.Count; j++)
            {

                string value1 = cbStoreid.GetItemText(cbStoreid.Items[j]);
                //for (int i = 0; i < txtProductID.Items.Count; i++)
                //{

                //string value = txtProductID.GetItemText(txtProductID.Items[i]);
                int qty = 0;
                MySqlConnection Conn = ConString.Connection;
                string Query = "insert into tbl_inventory (product_id,store_id, qty, subQTY, status, r_status) values('" + txtProductID.Text + "', '" + value1 + "', '" + qty + "', 0, 'New Product', 'N/A')";

                MySqlCommand cmd = new MySqlCommand(Query, Conn);
                try
                {



                    MySqlDataReader myReader = cmd.ExecuteReader();
                    while (myReader.Read())
                    {




                    }
                    Conn.Close();
                }
                catch (Exception ex1)
                {
                    //  MessageBox.Show(ex1.Message);
                }

                //}
            }
            try
            {


                generator();
                Cursor.Current = Cursors.WaitCursor;
                MySqlConnection Conn = ConString.Connection;
                MySqlDataReader myReader;

                Cursor.Current = Cursors.WaitCursor;





                string Query = "insert into tbl_product (product_id, product_name, product_price, quantity, vat, category, stock,date_added, description, production_date, expiry_date, remarks, status_new, rp, ltd, sqty) values ('" + this.txtProductID.Text + "', '" + this.txtProductName.Text + "', '" + this.txtUnitPrice.Text + "',  '" + this.txtQty.Text + "', '" + this.txtVat.Text + "', '" + this.txtCategory.Text + "', '" + this.txtStock.Text + "', '" + this.lblDateTime.Text + "','" + this.txtDescription.Text + "','" + dProduction.Text + "','" + dExpiry.Text + "', '" + txtRemarks.Text + "', 'New Product', 0, 0.00, 0)";

                MySqlCommand cmd = new MySqlCommand(Query, Conn);
                cmd.CommandTimeout = 50000;
                if (txtProductName.Text == "" || txtUnitPrice.Text == "" || txtCategory.Text == "" || txtDescription.Text == "")
                {

                    MessageBox.Show("Please enter require fields.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.None);

                    return;
                }
                if ((txtDescription.Text.Contains("'")))
                {
                    MessageBox.Show("Remove the single quote.");
                    return;
                }
                if ((txtDescription.Text.Contains(@"\")))
                {
                    MessageBox.Show("Remove the backslash.");
                    return;
                }
                //if (cbSupplier.Text == "")
                //{
                //    MessageBox.Show("Company or supplier name can't be empty for product: " + txtProductName.Text, "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //}

                if (txtUnitPrice.Text == "0" || txtUnitPrice.Text == "0.00" || txtUnitPrice.Text == "00" || txtUnitPrice.Text == "000" || txtUnitPrice.Text == "0000" || txtUnitPrice.Text == "00.0" || txtUnitPrice.Text == ".000" || txtUnitPrice.Text == "000.")
                {

                    MessageBox.Show("Zero price is not valid.", "POS System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }



                //if (dProduction.Text == dExpiry.Text)
                //{

                //    MessageBox.Show("Please input date for expiration of product.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}


                try
                {

                    try
                    {


                        myReader = cmd.ExecuteReader();
                        while (myReader.Read())
                        {

                            DataGridViewRow newDataRow = dataGridView1.Rows[selectedRow];
                            newDataRow.Cells[0].Value = txtProductID.Text;
                            newDataRow.Cells[1].Value = txtProductName.Text;
                            newDataRow.Cells[2].Value = txtRemarks.Text;
                            newDataRow.Cells[3].Value = txtQtyRestock.Text;
                            newDataRow.Cells[3].Value = txtAdjustQty.Text;
                            newDataRow.Cells[4].Value = txtCategory.Text;
                            newDataRow.Cells[5].Value = cbSupplier.Text;
                            newDataRow.Cells[9].Value = txtDescription.Text;
                            //     newDataRow.Cells[10].Value = txtReason.Text;
                            newDataRow.Cells[11].Value = dProduction.Text;
                            newDataRow.Cells[12].Value = dExpiry.Text;
                            newDataRow.Cells[13].Value = txtRemarks.Text;


                        }
                    }
                    catch (Exception ex1)
                    {
                        MessageBox.Show(ex1.Message);
                    }




                    Conn.Close();



                    MemoryStream ms = new MemoryStream();
                    pictureBox3.Image.Save(ms, pictureBox3.Image.RawFormat);
                    byte[] img = ms.ToArray();

                    MySqlConnection Conn1 = ConString.Connection;

                    // string Query = "UPDATE  INTO tbl_product(product_id, imageLocation) VALUES('"+this.txtProductID.Text+ "', @img)";
                    string Query1 = "Update tbl_product set imageLocation = @img where product_id = '" + this.txtProductID.Text + "'";

                    MySqlCommand cmd1 = new MySqlCommand(Query1, Conn1);

                    cmd1.Parameters.Add("@img", MySqlDbType.Blob);

                    cmd1.Parameters["@img"].Value = img;


                    if (cmd1.ExecuteNonQuery() == 1)
                    {

                    }
                    Conn1.Close();



                    NotifyBranch();
                    NotifyCritical();
                    NotifyExpiry();
                    subNotifyBranch();


                    changeRowColor();
                    changeRowColor1();
                    changeRowColor2();

                    //  SearchList();
                    dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.RowCount - 1;


                }
                catch (FormatException)
                {

                }


                txtQtyRestock.Text = "";

                btnAddProduct.Enabled = false;
                btnSave1.Enabled = false;
                btnSave1.BackColor = Color.DarkGray;
                btnAddProduct.BackColor = Color.DarkGray;
                //btnAdd1.Visible = false;
                //btnMinus.Visible = false;

                //txtQtyRestock.Enabled = false;
                //lblstock.ForeColor = Color.Gray;


            }

            catch (Exception)
            {

            }
            refreshInventoryProductList();

            refreshCategory();

            if (frm_Login.manager == "Manager")
            {

                cbSupplier.Visible = true;
                btnNewSupplierName.Visible = true;
                label8.Text = "";

                label3.Visible = true;
                groupBox1.Visible = false;
            }
            else if (frm_Login.stockman == "Stockman")
            {

                cbSupplier.Visible = true;
                btnNewSupplierName.Visible = true;
                label8.Text = "";

                label3.Visible = true;
                groupBox1.Visible = true;
            }

            else
            {
                cbSupplier.Enabled = true;
                btnNewSupplierName.Visible = false;
                groupBox1.Visible = false;
            }
            btnNew.Enabled = true;
            btnNew.BackColor = System.Drawing.ColorTranslator.FromHtml("#24262F");

            ExpiryDate();
            refreshCBproduct();
            Maxstoreid();
            MessageBox.Show("Product added successfully.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            DGVInventoryProductList();

        }


        private void txtProductName_TextChanged(object sender, EventArgs e)
        {
            hideNotifyPanel();
            btnSave1.Enabled = true;
            btnSave1.BackColor = System.Drawing.ColorTranslator.FromHtml("#24262F");
            label10.Text = "";

            if (txtProductName.Text == nameproduct || txtProductName.Text == "")
            {

                btnSave1.Enabled = false;
                btnSave1.BackColor = Color.DarkGray;

            }
            else
            {
                btnSave1.Enabled = true;
                btnSave1.BackColor = System.Drawing.ColorTranslator.FromHtml("#24262F");
            }
            if (btnAddProduct.Enabled == true)
            {
                btnSave1.Enabled = false;
                btnSave1.BackColor = Color.DarkGray;
            }

            if (txtProductName.Text.Contains(@"\") || txtProductName.Text.Contains("@'"))
            {
                return;



            }
            try
            {


                MySqlConnection Conn = ConString.Connection;
                DataTable dtt = new DataTable();
                MySqlDataAdapter sda = new MySqlDataAdapter("select product_name from tbl_product where REPLACE(product_name, ' ', '') = REPLACE('" + txtProductName.Text + "', ' ', '')", Conn);
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
            catch (Exception)
            {

            }
            if (txtProductName.Text.Length <= 0) return;
            string s = txtProductName.Text.Substring(0, 1);
            if (s != s.ToUpper())
            {
                int curSelStart = txtProductName.SelectionStart;
                int curSelLength = txtProductName.SelectionLength;
                txtProductName.SelectionStart = 0;
                txtProductName.SelectionLength = 1;
                txtProductName.SelectedText = s.ToUpper();
                txtProductName.SelectionStart = curSelStart;
                txtProductName.SelectionLength = curSelLength;

            }

        }
        public void AreaCriticalLevel()
        {

            try
            {
                MySqlConnection Conn = ConString.Connection;
                MySqlCommand cmd = new MySqlCommand("Select   * from tbl_product where stock <= critical and stock != 0;Update tbl_product set status_new = 'Critical Level' where critical >= stock;Update tbl_product set status_new = 'Out of Stocked' where stock = 0 and status_new != 'New Product'", Conn);
                cmd.CommandTimeout = 50000;


                //   lBCritical1.Items.Remove("Critical Level:");

                MySqlDataReader myReader = cmd.ExecuteReader();


                while (myReader.Read())
                {


                    //lBCritical1.Items.Add(myReader["product_name"]);
                    //lBCritical1.Visible = true;
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                    //  dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                    //   dataGridView2.DefaultCellStyle.SelectionBackColor = Color.Red;
                    lblqtycritical.Show();
                    //   pCritical.Show();


                }



                Conn.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "7");

            }
        }
        private void cbDescription_SelectedIndexChanged(object sender, EventArgs e)
        {
            //btnSave1.Enabled = true;
            //btnSave1.BackColor = Color.Blue;
            //label10.Text = "";
            //if (txtCategory.Text == category || txtCategory.Text == "")
            //{
            //    btnSave1.Enabled = false;
            //    btnSave1.BackColor = Color.DarkGray;
            //}
            //if (btnAddProduct.Enabled == true)
            //{
            //    btnSave1.Enabled = false;
            //    btnSave1.BackColor = Color.DarkGray;
            //}


        }

        private void txtUnitPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
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

        private void txtQtyRestock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
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
                    btnNewSupplierName.Enabled = false;
                    btnNewSupplierName.BackColor = Color.DarkGray;
                    txtProductID.Text = row.Cells[0].Value.ToString();

                    txtProductName.Text = row.Cells[1].Value.ToString();
                    txtUnitPrice.Text = row.Cells[13].Value.ToString();
                    txtRemarks.Text = row.Cells[2].Value.ToString();
                    nameproduct = row.Cells[1].Value.ToString();
                    unitprice = row.Cells[13].Value.ToString();

                    subss = row.Cells[15].Value.ToString();
                    subrp = row.Cells[16].Value.ToString();
                    submax = row.Cells[17].Value.ToString();


                    //   pictureBox3.ImageLocation = row.Cells[14].Value.ToString();

                    //  image = row.Cells[14].Value.ToString();
                    //  picture.Text = row.Cells[14].Value.ToString();


                    lblRemainingStock.Text = row.Cells[3].Value.ToString();
                    txtAdjustQty.Text = row.Cells[3].Value.ToString();
                    txtCategory.Text = row.Cells[4].Value.ToString();
                    category = row.Cells[4].Value.ToString();
                    dProduction.Text = row.Cells[11].Value.ToString();
                    dExpiry.Text = row.Cells[12].Value.ToString();
                    expirydate = row.Cells[12].Value.ToString();
                    description = row.Cells[9].Value.ToString();
                    cbSupplier.Text = row.Cells[5].Value.ToString();
                    company = row.Cells[5].Value.ToString();
                    txtsubcompany.Text = row.Cells[5].Value.ToString();
                    adjustqty = row.Cells[3].Value.ToString();
                    txtDescription.Text = row.Cells[9].Value.ToString();
                    //      txtReason.Text = row.Cells[10].Value.ToString();
                    pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
                    // pictureBox3.Image = new Bitmap(string.Format("{0}", picture.Text));

                    //      reason = row.Cells[10].Value.ToString();

                    //    txtQtyRestock.Enabled = false;


                    btnAddProduct.Enabled = false;
                    btnAddProduct.BackColor = Color.DarkGray;


                    btnNew.Enabled = true;
                    btnNew.BackColor = System.Drawing.ColorTranslator.FromHtml("#24262F");
                    btnNewStore.Location = new Point(557, 542);


                    label19.Visible = true;
                    label18.Visible = true;
                    dProduction.Visible = true;
                    dExpiry.Visible = true;
                    showpic();

                    lblminusqty.Text = row.Cells[17].Value.ToString();
                    lblexpirydate.Text = row.Cells[19].Value.ToString();
                    txtMinusQTY.Text = row.Cells[17].Value.ToString();
                    lblexpiredstatus.Text = row.Cells[20].Value.ToString();
                    gStatus = row.Cells[20].Value.ToString();
                    txtMinusQTY.Text = lblminusqty.Text;
                    txtCategory.DropDownStyle = ComboBoxStyle.DropDownList;
                    btnNewSupplierName.Enabled = false;
                    btnNewSupplierName.BackColor = Color.DarkGray;
                    if (frm_Login.manager == "Manager")
                    {
                        btnupdatedeliver.Visible = true;

                        if (lblexpiredstatus.Text == "Expired")
                        {
                            txtMinusQTY.Enabled = false;
                        }
                    }
                    else if (frm_Login.stockman == "Stockman")
                    {

                        if (gStatus == "Soon to Expire")
                        {
                            groupBox1.Visible = false;
                        }
                        else if (gStatus == "Expired")
                        {
                            groupBox1.Visible = true;
                        }


                    }

                    btnAddProduct.Enabled = false;
                    btnAddProduct.BackColor = Color.DarkGray;

                    if (frm_Login.manager == "Manager")
                    {
                        btnNewSupplierName.Enabled = false;
                        btnNewSupplierName.BackColor = Color.DarkGray;
                        cbSupplier.Visible = true;
                        btnNewSupplierName.Visible = true;
                        groupBox1.Visible = false;
                        label3.Visible = true;

                        // btnAdjust.Enabled = false;
                        btnSave1.Enabled = false;
                        btnSave1.BackColor = Color.DarkGray;
                        btnNew.Enabled = true;
                        btnNew.BackColor = System.Drawing.ColorTranslator.FromHtml("#24262F");


                    }
                    else if (frm_Login.stockman == "Stockman")
                    {

                        cbSupplier.Visible = true;
                        txtAdjustQty.Visible = true;
                        label14.Visible = true;
                        btnNewSupplierName.Visible = true;
                        label8.Text = "";
                        btnSave1.Visible = false;
                        label3.Visible = true;

                    }
                    else
                    {
                        cbSupplier.Enabled = true;
                        btnNewSupplierName.Visible = false;
                        groupBox1.Visible = false;
                        btnSave1.Enabled = false;
                        btnSave1.BackColor = Color.DarkGray;
                    }
                    //  

                }
            }
            catch (Exception ex)
            {
                //  MessageBox.Show(ex.Message, "Error7");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnNewSupplierName.Enabled = false;
            btnNewSupplierName.BackColor = Color.DarkGray;
            try
            {

                selectedRow = e.RowIndex;
                DataGridViewRow row = dataGridView1.Rows[selectedRow];
                txtProductID.Text = row.Cells[0].Value.ToString();
                txtProductName.Text = row.Cells[1].Value.ToString();
                txtUnitPrice.Text = row.Cells[13].Value.ToString();
                txtRemarks.Text = row.Cells[2].Value.ToString();
                txtAdjustQty.Text = row.Cells[3].Value.ToString();
                txtCategory.Text = row.Cells[4].Value.ToString();
                cbSupplier.Text = row.Cells[5].Value.ToString();
                txtDescription.Text = row.Cells[9].Value.ToString();
                //   txtReason.Text = row.Cells[10].Value.ToString();
                //dProduction.Text = row.Cells[11].Value.ToString();
                //dExpiry.Text = row.Cells[12].Value.ToString();
            }
            catch (ArgumentException)
            {

            }
            btnAddProduct.Enabled = false;
            btnAddProduct.BackColor = Color.DarkGray;
            //btnSave1.Enabled = false;
            //btnSave1.BackColor = Color.DarkGray;


        }

        private void btnSave1_Click(object sender, EventArgs e)
        {




        }
        void save()
        {

            try
            {


                txtQtyRestock.Text = "";
                //     btnSave1.Enabled = false;
                MySqlConnection Conn = ConString.Connection;
                string Query = "UPDATE tbl_product SET product_name = '" + this.txtProductName.Text + "', product_price = '" + Convert.ToDecimal(this.txtUnitPrice.Text) + "', category = '" + this.txtCategory.Text + "',stock = '" + Convert.ToInt32(this.txtAdjustQty.Text) + "', description = '" + this.txtDescription.Text + "', reason = '" + this.txtReason.Text + "', remarks = '" + Convert.ToDecimal(txtRemarks.Text) + "', s_adjust_ware = '" + Convert.ToInt32(txtMinusQTY.Text) + "', date_adjust_ware = '" + lblDateTime.Text + "' where product_id = '" + Convert.ToInt32(this.txtProductID.Text) + "';";


                MySqlCommand cmd = new MySqlCommand(Query, Conn);
                MySqlDataReader myReader;

                if ((txtDescription.Text.Contains("'")))
                {
                    MessageBox.Show("Remove the single quote.");
                    return;
                }
                if ((txtDescription.Text.Contains(@"\")))
                {
                    MessageBox.Show("Remove the backslash.");
                    return;
                }




                if (txtProductName.Text == "" || txtUnitPrice.Text == "" || txtCategory.Text == "")
                {
                    MessageBox.Show("Invalid fill the blank fields.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.None);

                    return;
                }
                if (MessageBox.Show("Do you want to save the changes you have made to the field(s)?", "Fabula's Merchandise System", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    try
                    {

                        myReader = cmd.ExecuteReader();

                        while (myReader.Read())
                        {
                            //Cursor.Current = Cursors.WaitCursor;
                            //DataGridViewRow newDataRow = dataGridView1.Rows[selectedRow];
                            //newDataRow.Cells[0].Value = txtProductID.Text;
                            //newDataRow.Cells[1].Value = txtProductName.Text;
                            //newDataRow.Cells[2].Value = txtRemarks.Text;
                            //newDataRow.Cells[3].Value = txtQtyRestock.Text;
                            //newDataRow.Cells[3].Value = txtAdjustQty.Text;
                            //newDataRow.Cells[4].Value = txtCategory.Text;
                            //newDataRow.Cells[5].Value = cbSupplier.Text;
                            //newDataRow.Cells[9].Value = txtDescription.Text;
                            ////  newDataRow.Cells[10].Value = txtReason.Text;
                            //newDataRow.Cells[11].Value = dProduction.Text;
                            //newDataRow.Cells[12].Value = dExpiry.Text;
                            //btnSave1.BackColor = Color.DarkGray;
                            ////  btnSave1.Enabled = false;
                        }
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message, "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.None);
                    }
                    Cursor.Current = Cursors.WaitCursor;

                    MessageBox.Show("Changes saved successfully!", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    Conn.Close();

                    changeRowColor();
                    changeRowColor1();
                    changeRowColor2();
                    damaged();
                    bite();
                    expired();

                    ExpiryDate();




                    //     btnAdjust.Enabled = false;
                    txtReason.Enabled = true;
                    if (frm_Login.stockman == "Stockman")
                    {
                        btnSave1.Visible = false;
                    }
                    MemoryStream ms = new MemoryStream();
                    pictureBox3.Image.Save(ms, pictureBox3.Image.RawFormat);
                    byte[] img = ms.ToArray();

                    MySqlConnection Conn1 = ConString.Connection;

                    // string Query = "UPDATE  INTO tbl_product(product_id, imageLocation) VALUES('"+this.txtProductID.Text+ "', @img)";
                    string Query1 = "Update tbl_product set imageLocation = @img where product_id = '" + this.txtProductID.Text + "'";

                    MySqlCommand cmd1 = new MySqlCommand(Query1, Conn1);

                    cmd1.Parameters.Add("@img", MySqlDbType.Blob);

                    cmd1.Parameters["@img"].Value = img;


                    if (cmd1.ExecuteNonQuery() == 1)
                    {

                    }
                    Conn1.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"ex");
            }
            //if (txtMinusQTY.Text != "0")
            //{


            //    try
            //    {
            //        MySqlConnection Conn = ConString.Connection;


            //        string Query = "Update tbl_product set status_sa = 'Stock Adjusted' where product_id = '" + txtProductID.Text + "'";
            //        MySqlCommand cmd = new MySqlCommand(Query, Conn);


            //        MySqlDataReader myReader;
            //        myReader = cmd.ExecuteReader();



            //        while (myReader.Read())
            //        {

            //        }
            //        Conn.Close();
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }
            //}
            subExpiryDate1();
            subExpiryDate();
            refreshCBproduct();

            pictureBox3.Image = null;

            DGVInventoryProductList();
            txtMinusQTY.Text = "0";
            subshowcolumn();
            refreshCategory();


            NotifyBranch();
            NotifyCritical();
            NotifyExpiry();
            subNotifyBranch();

            btnCritical.TextAlign = ContentAlignment.MiddleLeft;
            btnCritical.Text = "       Critical Level " + "(" + criticalqty + ")";

            btnExpiration.TextAlign = ContentAlignment.MiddleLeft;
            btnExpiration.Text = "       Expiration " + "(" + expiryqty + ")";


            btnNP.TextAlign = ContentAlignment.MiddleLeft;
            btnNP.Text = "       New Products " + "(" + qtynew + ")";

            btnCL.TextAlign = ContentAlignment.MiddleLeft;
            btnCL.Text = "       Requests " + "(" + qtycritical1 + ")";


            btnBO.TextAlign = ContentAlignment.MiddleLeft;
            btnBO.Text = "       Backorder " + "(" + qtybackorder + ")";

            int notifyadd = criticalqty + expiryqty;

            int notifyaddbranch = qtycritical1 + qtybackorder;

            lblbranchqty.Text = notifyaddbranch.ToString();

            lblqtycritical.Text = notifyadd.ToString();
            txtReason.Items.Remove("Expired");
            if (frm_Login.stockman == "Stockman")
            {
                btnSave1.Visible = false;
            }
            dataGridView1.Columns[5].Visible = false;

        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void txtUnitPrice_TextChanged(object sender, EventArgs e)
        {
            btnSave1.Enabled = true;
            btnSave1.BackColor = System.Drawing.ColorTranslator.FromHtml("#24262F");
            label10.Text = "";
            if (btnAddProduct.Enabled == true)
            {
                btnSave1.Enabled = false;
                btnSave1.BackColor = Color.DarkGray;
            }
            if (txtUnitPrice.Text == unitprice || txtUnitPrice.Text == "")
            {
                btnSave1.Enabled = false;
                btnSave1.BackColor = Color.DarkGray;

            }
            else
            {
                btnSave1.Enabled = true;
                btnSave1.BackColor = System.Drawing.ColorTranslator.FromHtml("#24262F");
            }
            try
            {


                decimal val1 = decimal.Parse(txtUnitPrice.Text) - (decimal.Parse(txtUnitPrice.Text) / Convert.ToDecimal(1.12)) + decimal.Parse(txtUnitPrice.Text);
                txtRemarks.Text = val1.ToString();

            }
            catch (Exception)
            {

            }


            if (txtUnitPrice.Text == "")
            {
                txtRemarks.Text = "";
            }
        }

        private void btnAdd1_Click(object sender, EventArgs e)
        {












            //string Connection = "datasource=localhost;port=3306;username=root;password=1234";

            //try
            //{
            //    string statuset = "Stocked";
            //    sum = Convert.ToInt32(txtStockqty.Text) + Convert.ToInt32(txtQtyRestock.Text);
            //    string Query = "update tbl_product set stock = '" + sum + "' where product_id = '" + productid + "'; update tbl_order set status = '" + statuset + "' where order_id = '" + frm_Supplier.idOrder + "'";
            //    MySqlConnection Conn = new MySqlConnection(Connection);
            //    MySqlCommand cmd = new MySqlCommand(Query, Conn);
            //    MySqlDataReader myReader;



            //    try
            //    {
            //        Conn.Open();
            //        myReader = cmd.ExecuteReader();


            //        while (myReader.Read())
            //        {
            //            txtQtyRestock.Text = myReader[5].ToString();
            //            lblRemainingStock.Text = myReader[5].ToString();
            //            DataGridViewRow newDataRow = dataGridView1.Rows[selectedRow];

            //            newDataRow.Cells[3].Value = txtQtyRestock.Text;

            //        }
            //    }
            //    catch (Exception)
            //    {

            //        MessageBox.Show("Please double click the item in selection product list.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.None);
            //    }

            //    txtQtyRestock.Clear();

            //    MessageBox.Show("Restocked successfully.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //    Conn.Close();

            //   RemoveListCritical();

            //   CriticalLevel();
            //    btnAdd1.BackColor = Color.White;
            //    DGVInventoryProductList();
            //}

            //catch (FormatException)
            //{

            //}
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            if (txtQtyRestock.Text == "")
            {
                MessageBox.Show("Enter amount for restock.");
                return;
            }
            MySqlConnection Conn = ConString.Connection;
            try
            {


                int val1, val2;
                val1 = int.Parse(txtQtyRestock.Text);
                val2 = int.Parse(lblRemainingStock.Text);
                string Query = "update tbl_product set stock = greatest(0, stock - '" + val1 + "')  where product_id = '" + this.txtProductID.Text + "';Select * from tbl_product where product_id = '" + this.txtProductID.Text + "'";

                MySqlCommand cmd = new MySqlCommand(Query, Conn);
                MySqlDataReader myReader;


                if (val1 < val2)
                {


                    try
                    {

                        myReader = cmd.ExecuteReader();


                        while (myReader.Read())
                        {
                            txtQtyRestock.Text = myReader[5].ToString();
                            lblRemainingStock.Text = myReader[5].ToString();
                            DataGridViewRow newDataRow = dataGridView1.Rows[selectedRow];

                            newDataRow.Cells[3].Value = txtQtyRestock.Text;

                        }

                    }
                    catch (Exception)
                    {

                        MessageBox.Show("Please double click the item in selection product list.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.None);
                    }
                    MessageBox.Show("Stock deducted!", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("Invalid deduct.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                txtQtyRestock.Text = "";



                Conn.Close();
                //     CriticalLevel();
            }

            catch (FormatException)
            {


            }
        }
        public void hideColumn()
        {
            try
            {


                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[6].Visible = false;
                dataGridView1.Columns[7].Visible = false;
                dataGridView1.Columns[9].Visible = false;
                dataGridView1.Columns[10].Visible = false;
                dataGridView1.Columns[11].Visible = false;
                dataGridView1.Columns[12].Visible = false;
                dataGridView1.Columns[13].Visible = false;
                dataGridView1.Columns[14].Visible = false;
                dataGridView2.Columns[11].Visible = false;
                dataGridView2.Columns[10].Visible = false;
                //  dataGridView1.Columns[16].Visible = false;

                //dataGridView2.Columns[7].Visible = false;
            }
            catch (Exception)
            {

            }

        }
        private void tabPage1_Click(object sender, EventArgs e)
        {
            hideNotifyPanel();
        }

        //public void ShowCritical()
        //{

        //    try
        //    {
        //        MySqlConnection Conn = ConString.Connection;
        //        MySqlCommand cmd = new MySqlCommand("Select  product_name, stock from tbl_product where critical >= stock and stock != 0", Conn);
        //        cmd.CommandTimeout = 50000;



        //        try
        //        {

        //            MySqlDataReader myReader = cmd.ExecuteReader();


        //            while (myReader.Read())
        //            {

        //                ListCritical.Items.Remove(myReader["product_name"]);
        //                ListCritical.Items.Add(myReader["product_name"]);

        //                ListCritical.Visible = true;
        //                pictureBox1.Show();

        //                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        //                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        //                dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Red;
        //                lblCritical.Show();


        //            }


        //        }
        //        catch (TimeoutException)
        //        {

        //        }
        //        Conn.Close();

        //    }
        //    catch (Exception ex)
        //    {

        //        MessageBox.Show(ex.Message);

        //    }
        //}
        void refresh_autocomplete()
        {

            MySqlConnection Conn = ConString.Connection;

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



                }

                cbStore.AutoCompleteCustomSource = MyCollection;
                cbServer.AutoCompleteCustomSource = MyCollection;

                Conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error12");
            }
        }
        public void StillNotAvailable()
        {
            MySqlConnection Conn = ConString.Connection;



            string Query = "Update tbl_inventory set status= 'Critical Level' where QTY <= critical and status != 'Pending'";
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

        public void setSoontoExpire()
        {
            MySqlConnection Conn = ConString.Connection;


            AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();

            string Query = "update tbl_expiry as B inner join tbl_product as A on B.product_id = A.product_id set B.status = 'Soon to Expire' where datediff( B.date_expiry, date(now())) < A.notify_days and B.status != 'Removed' and B.date_expiry > date(now());";
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

        public void setExpired()
        {
            MySqlConnection Conn = ConString.Connection;


            AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();

            string Query = "update tbl_expiry as B inner join tbl_product as A on B.product_id = A.product_id set B.status = 'Expired' where datediff( B.date_expiry, date(now())) <= A.notify_days and B.status != 'Removed' and B.date_expiry <= date(now());";
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
        public void damaged()
        {
            if (txtReason.Text == "Damaged" && txtMinusQTY.Text != "0")
            {


                MySqlConnection Conn = ConString.Connection;



                string Query = "insert into tbl_expiry (product_id, QTY, status, date_adjust, reason) values ('" + this.txtProductID.Text + "', '" + int.Parse(txtMinusQTY.Text) + "', 'Damaged', '" + DateTime.Now.ToString("yyyy-MM-dd") + "', 'Damaged');";
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
        }
        public void bite()
        {
            //    if(txtReason.Text == "Bite" && txtMinusQTY.Text != "0")
            //    {


            //    MySqlConnection Conn = ConString.Connection;




            //    string Query = "insert into tbl_expiry (product_id, QTY, status, date_adjust, reason) values ('" + this.txtProductID.Text + "', '" + int.Parse(txtMinusQTY.Text) + "', 'Bite', '" + DateTime.Now.ToString("yyyy-MM-dd") + "', 'Bite');";
            //        MySqlCommand cmd = new MySqlCommand(Query, Conn);
            //    MySqlDataReader myReader;

            //    try
            //    {

            //        myReader = cmd.ExecuteReader();

            //        while (myReader.Read())
            //        {



            //        }

            //        Conn.Close();
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message, "Error13");
            //    }
            //}


        }
        public void expired()
        {
            if (txtReason.Text == "Expired" && txtMinusQTY.Text != "0")
            {


                MySqlConnection Conn = ConString.Connection;




                string Query = "UPDATE tbl_expiry set status = 'Removed', reason = 'Expired', date_adjust = '" + DateTime.Now.ToString("yyyy-MM-dd") + "' where product_id = '" + this.txtProductID.Text + "' and date_expiry = '" + lblexpirydate.Text + "'";
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


        }
        //public void setStatusexpired()
        //{



        //    MySqlConnection Conn = ConString.Connection;




        //    string Query = "UPDATE tbl_expiry set status = 'Expired' where tbl_expiry.date_expiry <= (date_sub(curdate(), interval - 1 month)) and status != 'Stocked'";
        //    MySqlCommand cmd = new MySqlCommand(Query, Conn);
        //    MySqlDataReader myReader;

        //    try
        //    {

        //        myReader = cmd.ExecuteReader();

        //        while (myReader.Read())
        //        {



        //        }

        //        Conn.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Error13");
        //    }



        //}
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            hideNotifyPanel();
            StillNotAvailable();
            //sshideNotifyPanel();
            DGVInventoryProductList();
            DGVstoredisplayproduct();
            //   SearchingOK();
            //      CriticalLevel();
            AreaCriticalLevel();
            ExpiryDate();
            subExpiryDate1();
            subExpiryDate();
            refresh_autocomplete();
            refreshCBproduct();
            btnAddproduct1.Visible = false;

            changeRowColor();
            changeRowColor1();
            changeRowColor2();
            changeRowColor3();

            if (frm_Login.stockman == "Stockman" && lblstatusExpiry.Text == "Expiry")
            {
                setSoontoExpire();
                setExpired();
                NotifyExpiry();
                NotifyCritical();
                expiry();

                btnCritical.TextAlign = ContentAlignment.MiddleLeft;
                btnCritical.Text = "       Critical Level " + "(" + criticalqty + ")";

                btnExpiration.TextAlign = ContentAlignment.MiddleLeft;
                btnExpiration.Text = "       Expiration " + "(" + expiryqty + ")";


                btnNP.TextAlign = ContentAlignment.MiddleLeft;
                btnNP.Text = "       New Products " + "(" + qtynew + ")";

                btnCL.TextAlign = ContentAlignment.MiddleLeft;
                btnCL.Text = "       Requests " + "(" + qtycritical1 + ")";


                btnBO.TextAlign = ContentAlignment.MiddleLeft;
                btnBO.Text = "       Backorder " + "(" + qtybackorder + ")";

                int notifyadd = criticalqty + expiryqty;
                int notifyaddbranch = qtycritical1 + qtybackorder;

                lblbranchqty.Text = notifyaddbranch.ToString();
                lblqtycritical.Text = notifyadd.ToString();
            }

            // metroGrid2.Columns[5].Visible = false;

            if (frm_Login.manager == "Manager")
            {

                hideRQ();
                showRQ();
            }

            NotifyBranch();
            NotifyCritical();
            NotifyExpiry();
            subNotifyBranch();



            if (cbStore.Text != "")
            {
                lblMatch1.Visible = false;
            }
            if (cbStore.Text == "")
            {
                btnRequestAll.Enabled = false;
                btnRequestAll.BackColor = Color.DarkGray;
                btnRequest.Enabled = false;
                btnRequest.BackColor = Color.DarkGray;
                btnAddproduct1.Visible = false;

            }



            //if (tabControl1.SelectedTab == tabPage3)
            //{
            //    var pleaseWait = new frm_PleaseWait();
            //    pleaseWait.Show();
            //    Application.DoEvents();
            //    Cursor.Current = Cursors.WaitCursor;
            //    var myForm = new frm_Supplier();
            //    myForm.Show();
            //    pleaseWait.Hide();

            //    this.Hide();
            //}


            try
            {
                if (!metroGrid2.Rows[metroGrid2.CurrentCell.RowIndex].IsNewRow)
                {
                    foreach (DataGridViewCell cell in metroGrid2.Rows[metroGrid2.CurrentCell.RowIndex].Cells)
                    {
                        btnAddproduct1.Visible = false;
                        if (cell.Value == System.DBNull.Value)
                        {

                        }
                    }


                }
            }
            catch (NullReferenceException)
            {
                if (lblMatch1.Visible == true)
                {
                    btnAddproduct1.Visible = false;
                    return;
                }
                btnAddproduct1.Visible = true;


            }

            try
            {
                if (!metroGrid3.Rows[metroGrid3.CurrentCell.RowIndex].IsNewRow)
                {
                    foreach (DataGridViewCell cell in metroGrid3.Rows[metroGrid3.CurrentCell.RowIndex].Cells)
                    {
                        lblMatch2.Visible = false;
                        if (cell.Value == System.DBNull.Value)
                        {

                        }
                    }


                }
            }
            catch (NullReferenceException)
            {

                lblMatch2.Visible = true;
                lblMatch2.Text = "No delivery product(s)";


            }
            try
            {
                if (!dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex].IsNewRow)
                {
                    foreach (DataGridViewCell cell in dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex].Cells)
                    {

                        lblNoReceive.Visible = false;

                        //    txtStockqty.Visible = true;
                        //     txtQtyRestock.Visible = true;
                        //   label27.Visible = true;
                        //    label25.Visible = true;
                        //    label9.Visible = true;
                        if (cell.Value == System.DBNull.Value)
                        {

                        }
                    }


                }
            }
            catch (NullReferenceException)
            {
                if (frm_Login.stockman == "Stockman")
                {
                    lblNoReceive.Visible = true;
                }

                btnRestock.Enabled = false;
                btnRestock.BackColor = Color.DarkGray;

                txtStockqty.Visible = false;
                txtQtyRestock.Visible = false;
                label27.Visible = false;
                label25.Visible = false;
                label9.Visible = false;
                return;
            }


        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            hideNotifyPanel();
            metroGrid4.Visible = false;
            chartForecast.Visible = false;
            if (txtSearch.Text.Contains(@"\"))
            {
                return;



            }
            try
            {



                MySqlConnection Conn = ConString.Connection;
                DataTable dt = new DataTable();

                MySqlDataAdapter sda = new MySqlDataAdapter("SELECT tbl_product.product_id as 'Product ID', tbl_product.product_name as 'Product Name', tbl_product.remarks as 'Price Remarks', tbl_product.stock as 'Stock', tbl_product.Category as 'Category', tbl_supplierinfo.company as 'Supplier Name', tbl_product.date_added as 'Date Added', tbl_product.date_updated as 'Date Received', tbl_product.critical as 'Critical Level', tbl_product.description, tbl_product.reason, tbl_product.production_date as 'Production Date', tbl_product.expiry_date as 'Expiration Date', tbl_product.product_price as 'Original Price', tbl_product.imageLocation as 'Image', ss as 'Safety Stock', rp as 'Reorder Point', sqty as 'Maximum Level of Stock', floor((tbl_product.sqty + tbl_product.rp + tbl_product.ss + tbl_product.critical)/4)  as 'Suggested QTY', status_new as 'Status' FROM tbl_product left join tbl_supplierinfo on tbl_product.supplier_id = tbl_supplierinfo.supplier_id where tbl_product.product_name like '%" + txtSearch.Text + "%' group by tbl_product.product_id order by tbl_product.product_id asc", Conn);
                sda.Fill(dt);
                Conn.Close();
                dataGridView1.DataSource = dt;
                changeRowColor1();
                if (txtSearch.Text == "Search")
                {
                    changeRowColor1();
                    DGVInventoryProductList();

                    lblMatch.Hide();
                    pictureBox3.Visible = true;
                    changeRowColor();
                    changeRowColor1();
                    changeRowColor2();
                    subshowcolumn();
                }

                hideColumn();
                changeRowColor1();
                changeRowColor();
                changeRowColor1();
                changeRowColor2();
                subshowcolumn();
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
                    txtProductID.Text = row.Cells[0].Value.ToString();
                    txtProductName.Text = row.Cells[1].Value.ToString();
                    txtUnitPrice.Text = row.Cells[2].Value.ToString();
                    txtCategory.Text = row.Cells[4].Value.ToString();
                    txtDescription.Text = row.Cells[9].Value.ToString();
                    //   txtReason.Text = row.Cells[10].Value.ToString();
                    btnSave1.Enabled = false;
                    btnSave1.BackColor = Color.DarkGray;

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
                        lblMatch.Hide();
                        pictureBox3.Visible = true;
                        if (cell.Value == System.DBNull.Value)
                        {

                        }
                    }


                }
            }
            catch (NullReferenceException)
            {
                lblMatch.Show();
                pictureBox3.Visible = false;
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

        private void btnSearch_Click(object sender, EventArgs e)
        {

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

            if (e.KeyCode == Keys.Enter)
            {


                // btnSearch.PerformClick();
            }
        }

        private void txtSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Search")
            {
                txtSearch.Focus();
                txtSearch.Select(0, 0);

            }
        }

        private void frm_Inventory_FormClosing(object sender, FormClosingEventArgs e)
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

        private void txtQtyRestock_TextChanged(object sender, EventArgs e)
        {
            if (txtQtyRestock.Text == "")
            {

                return;
            }

            if (btnAddProduct.Enabled == true)
            {
                btnSave1.Enabled = false;
                btnSave1.BackColor = Color.DarkGray;
            }


        }

        private void cbDescription_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void cbDescription_TextChanged(object sender, EventArgs e)
        {
            btnSave1.Enabled = true;
            btnSave1.BackColor = System.Drawing.ColorTranslator.FromHtml("#24262F");
            label10.Text = "";
            if (btnAddProduct.Enabled == true)
            {
                btnSave1.Enabled = false;
                btnSave1.BackColor = Color.DarkGray;
            }
            if (txtCategory.Text == category)
            {
                btnSave1.Enabled = false;
                btnSave1.BackColor = Color.DarkGray;
            }

            //MySqlConnection Conn = ConString.Connection;
            //var dtt = new DataTable();
            //var sda = new MySqlDataAdapter("select category from tbl_product where REPLACE(category, ' ', '') = REPLACE('" + txtCategory.Text + "', ' ', '')", Conn);
            //sda.Fill(dtt);
            //Conn.Close();
            //if (dtt.Rows.Count >= 1 || dtt.Rows.Count == 1)
            //{
            //    //btnSave1.Enabled = false;
            //    //btnSave1.BackColor = Color.DarkGray;
            //       MessageBox.Show("The " + txtProductName.Text + " already added in product list.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            if (txtCategory.Text.Length <= 0) return;
            string s = txtCategory.Text.Substring(0, 1);
            if (s != s.ToUpper())
            {
                int curSelStart = txtCategory.SelectionStart;
                int curSelLength = txtCategory.SelectionLength;
                txtCategory.SelectionStart = 0;
                txtCategory.SelectionLength = 1;
                txtCategory.SelectedText = s.ToUpper();
                txtCategory.SelectionStart = curSelStart;
                txtCategory.SelectionLength = curSelLength;

            }
        }

        private void btnScrollUp_Click(object sender, EventArgs e)
        {
            hideNotifyPanel();
            chartForecast.Series["Forecast Demand"].Label = "#PERCENT";
            try
            {

                int rowIndex = dataGridView1.FirstDisplayedScrollingRowIndex;



                dataGridView1.FirstDisplayedScrollingRowIndex = rowIndex - 1;
            }
            catch (Exception)
            {

            }

            changeRowColor();
            changeRowColor1();
            changeRowColor2();
        }

        private void btnCalculator_Click(object sender, EventArgs e)
        {
            var myForm = new frm_Calculator();
            myForm.Show();
        }

        private void btnSort_Click(object sender, EventArgs e)
        {

            DGVInventoryProductList();
            txtReason.Enabled = true;
            btnNewStore.Location = new Point(557, 542);
            btnNew.Enabled = true;
            btnNew.BackColor = System.Drawing.ColorTranslator.FromHtml("#24262F");
            label19.Visible = true;
            label18.Visible = true;
            dProduction.Visible = true;
            dExpiry.Visible = true;

            if (frm_Login.manager == "Manager")
            {
                btnupdatedeliver.Visible = true;
            }
        }

        private void btnScrollBottom_Click(object sender, EventArgs e)
        {
            hideNotifyPanel();
            dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.RowCount - 1;

            changeRowColor();
            changeRowColor1();
            changeRowColor2();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            hideNotifyPanel();
            this.dataGridView1.Sort(this.dataGridView1.Columns["Product Name"], ListSortDirection.Ascending);

            changeRowColor();
            changeRowColor1();
            changeRowColor2();

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

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {


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


                try
                {


                    DataGridViewRow row = cell.OwningRow;
                    txtProductID.Text = row.Cells[10].Value.ToString();
                    label5.Text = row.Cells[0].Value.ToString();
                    txtProductName.Text = row.Cells[1].Value.ToString();
                    lblStatus.Text = row.Cells[2].Value.ToString();
                    mStatus = row.Cells[2].Value.ToString();

                    //  unitprice = row.Cells[3].Value.ToString();
                    txtStockqty.Text = row.Cells[11].Value.ToString();

                    txtQtyRestock.Text = row.Cells[5].Value.ToString();
                    dateExpected.Text = row.Cells[9].Value.ToString();
                    date_ordered.Text = row.Cells[8].Value.ToString();
                    mOrderedQTY = row.Cells[4].Value.ToString();
                    mTotalDue = row.Cells[3].Value.ToString();

                    //  Production.Text = row.Cells[6].Value.ToString();
                    //   Expiry.Text = row.Cells[7].Value.ToString();


                    btnSave1.Enabled = false;
                    btnSave1.BackColor = Color.DarkGray;

                    //    txtQtyRestock.Enabled = false;




                    btnAddProduct.Enabled = false;
                    btnAddProduct.BackColor = Color.DarkGray;

                    DateTime date1 = DateTime.Now;
                    DateTime date2 = subdate.Value;

                    TimeSpan difference = date2.Subtract(date1);

                    if (Expiry.Value < date2)
                    {

                        btnRestock.Enabled = false;
                        btnRestock.BackColor = Color.DarkGray;


                    }
                    else
                    {

                        btnRestock.Enabled = true;
                        btnRestock.BackColor = System.Drawing.ColorTranslator.FromHtml("#24262F");

                    }

                   date1 = DateTime.Now;
                   date2 = subdate.Value;

                    difference = date2.Subtract(date1);

                    if (Expiry.Value < date2 || lblStatus.Text != "Received")

                    {

                        btnRestock.Enabled = false;
                        btnRestock.BackColor = Color.DarkGray;


                    }
                    else
                    {

                        btnRestock.Enabled = true;
                        btnRestock.BackColor = System.Drawing.ColorTranslator.FromHtml("#24262F");

                    }



                    txtOrderID.Text = row.Cells[0].Value.ToString();
                    dateExpected.Text = row.Cells[9].Value.ToString();
                    productname = row.Cells[1].Value.ToString();
                    statusss = row.Cells[2].Value.ToString();
                    dateOrdered.Text = row.Cells[8].Value.ToString();

                    date_ordered.Text = row.Cells[8].Value.ToString();


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

                    txtSubdays.Text = (dateExpected.Value - DateTime.Today).TotalDays.ToString("#");
                    dateExpected.Enabled = false;
                    //if (txtHours.Text.Contains("-"))
                    //{
                    //    txtHours.Text = "0";
                    //}
                    if (txtSubdays.Text.Contains("-"))
                    {
                        txtSubdays.Text = "0";
                    }

                    if (txtSubdays.Text == "1")
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


                }
                catch (Exception)
                {

                }







                try
                {


                    if (dataGridView2.Rows.Count > 0)
                    {
                        productid = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells[10].Value.ToString());

                    }
                    MySqlConnection Conn = ConString.Connection;
                    string Query = "Select * from tbl_order where product_id = '" + productid + "'";
                    MySqlCommand cmd = new MySqlCommand(Query, Conn);
                    MySqlDataReader myReader;

                    try
                    {

                        myReader = cmd.ExecuteReader();

                        while (myReader.Read())
                        {
                            //  quantity_receive = myReader.GetInt32("quantity_receive");
                            status_receive = myReader.GetString("status");
                            orderID = myReader.GetInt32("order_id");

                        }

                        //  label5.Text = productid.ToString();

                        Conn.Close();


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }


                    if (lblStatus.Text == "Received")
                    {
                        btnRestock.Enabled = true;
                        btnRestock.BackColor = System.Drawing.ColorTranslator.FromHtml("#24262F");




                    }

                    else
                    {
                        btnRestock.Enabled = false;
                        btnRestock.BackColor = Color.DarkGray;
                        txtQtyRestock.Text = "0";
                        //  txtQtyRestock.Enabled = false;
                        return;
                    }

                    if (status_receive == "Backorder")
                    {
                        orderID--;
                        try
                        {
                            MySqlConnection conn = ConString.Connection;

                            string query = "select * from tbl_order where order_id = '" + orderID + "'  ";
                            //and status = 'Received'
                            cmd = new MySqlCommand(query, conn);
                            MySqlDataReader dr;
                            dr = cmd.ExecuteReader();

                            while (dr.Read())
                            {
                                // quantity_receive = dr.GetInt32("quantity_receive");
                                status_receive = dr.GetString("status");
                                orderID = dr.GetInt32("order_id");
                            }

                            conn.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }






                        if (dataGridView2.Rows.Count > 0)
                        {
                            productid = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells[10].Value.ToString());


                            txtStockqty.Text = dataGridView2.SelectedRows[0].Cells[11].Value.ToString();
                            //  txtQtyRestock.Text = quantity_receive.ToString();


                        }
                    }
                }
                catch (Exception)
                {

                }
            }
        }

        private void btnRestock_Click_1(object sender, EventArgs e)
        {
            if (Production.Text == Expiry.Text)
            {
                MessageBox.Show("Please set the date of production and expiry.", "Fabula's Merchandise System");
                return;
            }

            DateTime date1 = DateTime.Now;
            DateTime date2 = subdate.Value;

            TimeSpan difference = date2.Subtract(date1);

            if (Expiry.Value < date2 || lblStatus.Text != "Received")

            {

                btnRestock.Enabled = false;
                btnRestock.BackColor = Color.DarkGray;

                return;


            }
            else
            {

                btnRestock.Enabled = true;
                btnRestock.BackColor = System.Drawing.ColorTranslator.FromHtml("#24262F");

            }
            if (txtQtyRestock.Text == "")
            {
                MessageBox.Show("There is no more restock.");
                return;
            }


            if (dataGridView2.Rows.Count > 0)
            {

                mSupplier_ID = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells[12].Value.ToString());


            }
            MySqlConnection Conn = ConString.Connection;
            try
            {
                string statuset = "Stocked";
                string received = "Received";
                sum = Convert.ToInt32(txtStockqty.Text) + Convert.ToInt32(txtQtyRestock.Text);

                string Query = "update tbl_order set status = '" + statuset + "' where status = '" + received + "' and product_id = '" + productid + "' and supplier_id = '" + mSupplier_ID + "' and date_expected = '" + dateExpected.Text + "' and date_ordered = '" + date_ordered.Text + "';update tbl_product set stock = '" + sum + "', production_date = '" + Production.Text + "', expiry_date = '" + Expiry.Text + "', status_new = 'Stocked' where product_id = '" + productid + "';update tbl_product set date_updated = '" + this.lblDateTime.Text + "' where product_id = '" + productid + "';insert into tbl_expiry (product_id, date_expiry, QTY, date_pro, status) values ('" + productid + "', '" + Expiry.Text + "', '" + txtQtyRestock.Text + "', '" + Production.Text + "', 'New Stocked')";

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
                catch (Exception)
                {

                    MessageBox.Show("Please double click the item in selection product list.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.None);
                }

                txtQtyRestock.Text = "";

                MessageBox.Show("Stocked successfully.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                receivefirst = "";
                RemoveListCritical();

                //       CriticalLevel();

                DGVReceivedProductList();
                ByNotifyWarehouse();
                NotifyBranch();
                NotifyCritical();
                NotifyExpiry();
                subNotifyBranch();
                setSoontoExpire();
                setExpired();

            }

            catch (FormatException)
            {

            }
            try
            {
                if (!dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex].IsNewRow)
                {
                    foreach (DataGridViewCell cell in dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex].Cells)
                    {

                        lblNoReceive.Visible = false;
                        //    txtStockqty.Visible = true;
                        //     txtQtyRestock.Visible = true;
                        //     label27.Visible = true;
                        // label25.Visible = true;
                        // label9.Visible = true;
                        if (cell.Value == System.DBNull.Value)
                        {

                        }
                    }


                }
            }
            catch (NullReferenceException)
            {
                label25.Visible = false;
                label9.Visible = false;

                if (frm_Login.stockman == "Stockman")
                {
                    lblNoReceive.Visible = true;

                }

                txtStockqty.Visible = false;
                txtQtyRestock.Visible = false;
                label27.Visible = false;
                btnRestock.Enabled = false;
                btnRestock.BackColor = Color.DarkGray;

            }


        }

        private void cbSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSave1.Enabled = false;
            btnSave1.BackColor = Color.DarkGray;
            btnAddProduct.Enabled = false;
            btnAddProduct.BackColor = Color.DarkGray;

            //if (company == "")
            //{



            MySqlConnection Conn = ConString.Connection;




            string Query = "select * from tbl_supplierinfo where company = '" + cbSupplier.SelectedItem.ToString() + "'; ";

            MySqlCommand cmd = new MySqlCommand(Query, Conn);
            MySqlDataReader myReader;

            myReader = cmd.ExecuteReader();
            while (myReader.Read())
            {
                suppID = myReader.GetInt32("supplier_id");


            }
            Conn.Close();





            Conn = ConString.Connection;

            DataTable dt = new DataTable();
            MySqlDataAdapter sda = new MySqlDataAdapter("select * from tbl_supplierinfo  where tbl_supplierinfo.company like '" + cbSupplier.Text + "%'", Conn);
            sda.Fill(dt);
            Conn.Close();
            cbSupplierID.DataSource = dt;

            cbSupplierID.DisplayMember = "supplier_id";
            cbSupplierID.ValueMember = "supplier_id";

            //}
            //else if (company != cbSupplier.Text)
            //{
            //    btnNewSupplierName.Enabled = false;
            //    btnNewSupplierName.BackColor = Color.DarkGray;

            //}
            //else
            //{
            //    btnNewSupplierName.Enabled = false;
            //    btnNewSupplierName.BackColor = Color.DarkGray;
            //}
            //btnNewSupplierName.BackColor = System.Drawing.ColorTranslator.FromHtml("#24262F");
            //btnNewSupplierName.Enabled = true;

            btnNewSupplierName.BackColor = System.Drawing.ColorTranslator.FromHtml("#24262F");
            btnNewSupplierName.Enabled = true;
            if (company == cbSupplier.Text)
            {
                btnNewSupplierName.Enabled = false;
                btnNewSupplierName.BackColor = Color.DarkGray;


            }



        }

        private void cbSupplier_TextChanged(object sender, EventArgs e)
        {
            btnSave1.Enabled = false;
            btnSave1.BackColor = Color.DarkGray;
            cbSupplier.Text = "";
            //if ((txtProductName.Text == "" || txtUnitPrice.Text == "" || cbDescription.Text == "") && (btnNew.Enabled != true))
            //{
            //    label10.Text = "Enter require fields to the product name, description and unit price.";
            //    label8.Text = "";
            //}

            //else if (btnSave1.Enabled == true)
            //{
            //    label8.Text = "";
            //    label10.Text = "";

            //}


        }

        private void btnPlus_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            hideNotifyPanel();
            btnSave1.Enabled = false;
            btnSave1.BackColor = Color.DarkGray;



            MySqlConnection Conn = ConString.Connection;
            string Query = "UPDATE tbl_product SET supplier_id = '" + this.cbSupplierID.Text + "' where product_id = '" + this.txtProductID.Text + "'";

            MySqlCommand cmd = new MySqlCommand(Query, Conn);
            MySqlDataReader myReader;

            try
            {

                myReader = cmd.ExecuteReader();

                while (myReader.Read())
                {
                    Cursor.Current = Cursors.WaitCursor;

                    btnSave1.BackColor = Color.DarkGray;
                    btnSave1.Enabled = false;

                }

                Conn.Close();
            }
            catch (Exception)
            {

                MessageBox.Show("Please double click the item in selection product list.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            MessageBox.Show("Supplier name updated successfully!", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            Cursor.Current = Cursors.WaitCursor;

            btnNewSupplierName.Enabled = false;
            btnNewSupplierName.BackColor = Color.DarkGray;
            DGVInventoryProductList();
            changeRowColor();
            changeRowColor1();
            changeRowColor2();


        }

        private void cbSupplier_Click(object sender, EventArgs e)
        {

            // if (txtProductName.Text == "" || txtUnitPrice.Text == "" || cbDescription.Text == "")
            // {
            //     label10.Text = "Enter require fields to the product name, description and unit price.";
            //     label8.Text = "";
            // }
            //else if (btnAddProduct.Enabled == true)
            // {
            //     label8.Text = "Click 'Add Product' first then add new supplier name for new product.";

            // }
            // else if (btnSave1.Enabled == true)
            // {
            //     label8.Text = "";

            // }
        }





        private void txtReason_TextChanged_1(object sender, EventArgs e)
        {
            if (txtReason.Text.Length >= 20)
            {
                txtMinusQTY.Enabled = true;
                btnAdjust.Enabled = true;
            }
            else
            {
                txtMinusQTY.Enabled = false;
                btnAdjust.Enabled = false;
            }
            btnSave1.Enabled = false;
            btnSave1.BackColor = Color.DarkGray;
            label10.Text = "";
            if (txtReason.Text == reason || txtReason.Text == "")
            {
                btnSave1.Enabled = false;
                btnSave1.BackColor = Color.DarkGray;
            }
            if (btnAddProduct.Enabled == true)
            {
                btnSave1.Enabled = false;
                btnSave1.BackColor = Color.DarkGray;
            }
        }

        private void txtMinusQTY_TextChanged_1(object sender, EventArgs e)
        {
            btnSave1.Visible = true;

        }

        private void txtAdjustQty_TextChanged(object sender, EventArgs e)
        {
            btnSave1.Enabled = true;
            btnSave1.BackColor = Color.Blue;
            if (txtReason.Text != "Expired")
            {
                btnAdjust.Enabled = true;
            }

            label10.Text = "";
            if (txtAdjustQty.Text == adjustqty || txtAdjustQty.Text == "")
            {
                btnSave1.Enabled = false;
                btnSave1.BackColor = Color.DarkGray;
            }
            if (btnAddProduct.Enabled == true)
            {
                btnSave1.Enabled = false;
                btnSave1.BackColor = Color.DarkGray;
            }
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            btnSave1.Enabled = true;
            btnSave1.BackColor = System.Drawing.ColorTranslator.FromHtml("#24262F");
            label10.Text = "";
            if (btnAddProduct.Enabled == true)
            {
                btnSave1.Enabled = false;
                btnSave1.BackColor = Color.DarkGray;
            }
            if (txtDescription.Text == description || txtDescription.Text == "")
            {
                btnSave1.Enabled = false;
                btnSave1.BackColor = Color.DarkGray;
            }


        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMinusQTY.Text == "")
                {
                    MessageBox.Show("Enter amount of QTY for stock adjustment.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (txtMinusQTY.Text == "0")
                {
                    MessageBox.Show("Enter amount of QTY for stock adjustment.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (txtAdjustQty.Text == "0")
                {
                    MessageBox.Show("You don't have stock. Please add amount of product from supplier.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (txtAdjustQty.Text == "" || txtAdjustQty.Text == "0")
                {
                    MessageBox.Show("Enter amount of QTY for stock adjustment.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (int.Parse(txtMinusQTY.Text) <= int.Parse(txtAdjustQty.Text))
                {



                    int val1 = int.Parse(txtAdjustQty.Text);
                    int val2 = int.Parse(txtMinusQTY.Text);

                    int val3 = val1 - val2;

                    txtAdjustQty.Text = val3.ToString();
                }
                else
                {
                    txtMinusQTY.Text = "0";
                    MessageBox.Show("Stock adjustment failed.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }

                txtMinusQTY.Enabled = false;
                txtReason.Enabled = false;


            }
            catch (FormatException)
            {

            }
            btnAdjust.Enabled = false;

            NotifyBranch();
            NotifyCritical();
            NotifyExpiry();
            subNotifyBranch();


            btnSave1.Enabled = true;
            btnSave1.Visible = true;
            btnSave1.BackColor = Color.DarkBlue;
        }

        private void txtMinusQTY_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtProductName_Leave(object sender, EventArgs e)
        {

        }

        private void dExpiry_ValueChanged(object sender, EventArgs e)
        {
            btnSave1.Enabled = true;
            btnSave1.BackColor = System.Drawing.ColorTranslator.FromHtml("#24262F");
            label10.Text = "";
            if (btnAddProduct.Enabled == true)
            {
                btnSave1.Enabled = false;
                btnSave1.BackColor = Color.DarkGray;
            }
            if (dExpiry.Text == expirydate)
            {
                btnSave1.Enabled = false;
                btnSave1.BackColor = Color.DarkGray;
            }

            DateTime date1 = dateTimePicker1.Value;
            DateTime date2 = dExpiry.Value;

            TimeSpan difference = date2.Subtract(date1);



            if (DateTime.Now > date2)
            {

                btnSave1.Enabled = false;
                btnSave1.BackColor = Color.DarkGray;
                btnAddProduct.Enabled = false;
                btnAddProduct.BackColor = Color.DarkGray;
                //  MessageBox.Show("The date doesn't look right. Be sure to use the actual expiry date.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (btnNew.Enabled == false)
                {
                    btnAddProduct.Enabled = true;
                    btnAddProduct.BackColor = Color.Blue;
                }



            }
            if (btnAddProduct.Enabled == true)
            {
                btnSave1.Enabled = false;
                btnSave1.BackColor = Color.DarkGray;
            }
            //if ((date2 < date1 && dateTimePicker1.Text != dExpiry.Text))
            //{
            //     MessageBox.Show("The date doesn't look right. Be sure to use the actual expiry date.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    dExpiry.Text = expirydate;
            //}
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dProduction_ValueChanged(object sender, EventArgs e)
        {
            btnSave1.Enabled = true;
            btnSave1.BackColor = System.Drawing.ColorTranslator.FromHtml("#24262F");

            label10.Text = "";
            if (btnAddProduct.Enabled == true)
            {
                btnSave1.Enabled = false;
                btnSave1.BackColor = Color.DarkGray;
            }
            if (dExpiry.Text == expirydate)
            {
                btnSave1.Enabled = false;
                btnSave1.BackColor = Color.DarkGray;
            }

            DateTime date1 = dProduction.Value;
            DateTime date2 = dExpiry.Value;

            TimeSpan difference = date2.Subtract(date1);





            if (date1 > date2)
            {
                //  MessageBox.Show("Invalid date for production.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);

                dProduction.Text = dateTimePicker1.Text;
            }
        }

        private void txtRemarks_TextChanged(object sender, EventArgs e)
        {
            btnSave1.Enabled = true;
            btnSave1.BackColor = System.Drawing.ColorTranslator.FromHtml("#24262F");
            label10.Text = "";
            if (txtUnitPrice.Text == unitprice || txtUnitPrice.Text == "")
            {
                btnSave1.Enabled = false;
                btnSave1.BackColor = Color.DarkGray;
            }
            if (btnAddProduct.Enabled == true)
            {
                btnSave1.Enabled = false;
                btnSave1.BackColor = Color.DarkGray;
            }

            try
            {


                txtRemarks.Text = string.Format("{0:n}", double.Parse(txtRemarks.Text));
            }
            catch (Exception)
            {

            }
        }

        private void btnNewStore_Click(object sender, EventArgs e)
        {
            hideNotifyPanel();
            //Cursor.Current = Cursors.AppStarting;
            //var myForm = new frm_NewStore();
            //myForm.Show();
            //this.Hide();
            Cursor.Current = Cursors.AppStarting;
            var myForm = new frm_NewStore();
            myForm.ShowDialog();
            refreshCB();
            refresh_autocomplete();

            NotifyBranch();
            NotifyCritical();
            NotifyExpiry();
            subNotifyBranch();
        }

        private void btnAddproduct1_Click(object sender, EventArgs e)
        {

            //   Cursor.Current = Cursors.WaitCursor;
            //   MySqlConnection Conn = ConString.Connection;
            //   MySqlDataReader myReader;

            //   Cursor.Current = Cursors.WaitCursor;

            //   for (int i = 0; i < cbProductID.Items.Count; i++)
            //   {
            //       string value = cbProductID.GetItemText(cbProductID.Items[i]);
            //       for (int j = 0; j < txtstore_id.Items.Count; j++)
            //       {


            //           string value1 = txtstore_id.GetItemText(txtstore_id.Items[j]);



            //                   int qty = 0;
            //                   string Query = "insert into tbl_inventory (product_id, store_id, QTY, subQTY) values ('" + value + "','" + value1 + "', '" + qty + "', 0);";
            //                   MySqlConnection Conn = new MySqlConnection(Connection);
            //                   MySqlCommand cmd = new MySqlCommand(Query, Conn);
            //                   cmd.CommandTimeout = 50000;

            //                   if (cbProductname.Text == "" || cbPrice.Text == "")
            //                   {

            //                       MessageBox.Show("Please enter require fields.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.None);

            //                       return;
            //                   }




            //                   Conn.Open();
            //                   try
            //                   {


            //                       myReader = cmd.ExecuteReader();
            //                       while (myReader.Read())
            //                       {

            //                       }

            //                       Conn.Close();

            //                   }

            //                   catch (Exception ex1)
            //                   {
            //                       MessageBox.Show(ex1.Message);
            //                   }

            //               }
            //       //    }
            //       //}

            //       btnAddproduct1.Visible = false;
            //   }
            ////   MessageBox.Show("All products added successfully.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);



            //   btnNew1.Visible = true;
            //   btnNew1.BackColor = System.Drawing.ColorTranslator.FromHtml("#24262F");
            //   DGVstoredisplayproduct();
            //   Maxstoreid();
        }

        private void btnNew1_Click(object sender, EventArgs e)
        {

            btnNew1.Enabled = false;
            btnNew1.BackColor = Color.DarkGray;
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection Conn = ConString.Connection;


                Cursor.Current = Cursors.WaitCursor;

                string Query = "select * from tbl_product where product_name = '" + cbProductname.SelectedItem.ToString() + "'; ";

                MySqlCommand cmd = new MySqlCommand(Query, Conn);
                MySqlDataReader myReader;

                myReader = cmd.ExecuteReader();
                while (myReader.Read())
                {
                    product_id = myReader.GetInt32("product_id");


                }

                Conn.Close();

                //Conn.Open();
                //DataTable dt = new DataTable();
                //MySqlDataAdapter sda = new MySqlDataAdapter("select * from tbl_product where product_name like '" + cbProductname.Text + "%';", Conn);
                //sda.Fill(dt);
                //Conn.Close();
                //cb.DataSource = dt;
                //cbProductName.DisplayMember = "product_name";
                //cbProductName.ValueMember = "product_id";


                Conn = ConString.Connection;
                Query = "select product_id from tbl_product where product_id = '" + product_id + "'; ";
                cmd = new MySqlCommand(Query, Conn);
                myReader = cmd.ExecuteReader();

                while (myReader.Read())
                {

                    cbProductID.Text = myReader.GetString("product_id").ToString();
                }

                Conn.Close();

                Conn = ConString.Connection;
                DataTable dt = new DataTable();
                MySqlDataAdapter sda = new MySqlDataAdapter("select * from tbl_product where product_name like '" + cbProductname.Text + "%';", Conn);
                sda.Fill(dt);
                Conn.Close();
                cbPrice.DataSource = dt;
                cbPrice.DisplayMember = "remarks";

            }
            catch (Exception ex)
            {
                //  MessageBox.Show(ex.Message);
            }
        }

        private void cbProductname_TextChanged(object sender, EventArgs e)
        {
            if (cbProductname.Text == "")
            {
                cbPrice.Text = "";
                btnAddproduct1.Enabled = false;
                btnAddproduct1.BackColor = Color.DarkGray;
            }
            if (cbProductname.Text.Contains(@"\"))
            {
                return;
            }
            MySqlConnection Conn = ConString.Connection;
            var dtt = new DataTable();
            var sda = new MySqlDataAdapter("select product_name from tbl_product where product_name = '" + this.cbProductname.Text + "'", Conn);
            sda.Fill(dtt);
            Conn.Close();


            if (dtt.Rows.Count >= 1 || dtt.Rows.Count == 1)
            {

                btnAddproduct1.Enabled = true;
                btnAddproduct1.BackColor = System.Drawing.ColorTranslator.FromHtml("#24262F");

            }
            else
            {
                //btnAddproduct1.Enabled = false;
                //btnAddproduct1.BackColor = Color.DarkGray;
                cbPrice.Text = "";
            }
            if (cbProductname.Text.Length <= 0) return;
            string s = cbProductname.Text.Substring(0, 1);
            if (s != s.ToUpper())
            {
                int curSelStart = cbProductname.SelectionStart;
                int curSelLength = cbProductname.SelectionLength;
                cbProductname.SelectionStart = 0;
                cbProductname.SelectionLength = 1;
                cbProductname.SelectedText = s.ToUpper();
                cbProductname.SelectionStart = curSelStart;
                cbProductname.SelectionLength = curSelLength;

            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {




                ///  metroGrid2.Columns[5].Visible = false;

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
                MySqlDataAdapter sda = new MySqlDataAdapter("select * from tbl_store where store_id = '" + frm_Login.global_storeid + "' and store_name like '%" + cbStore.Text + "';", Conn);
                sda.Fill(dt);
                sda.SelectCommand = cmd;
                Conn.Close();
                txtstore_id.DataSource = dt;
                txtstore_id.DisplayMember = "store_id";
                txtstore_id.ValueMember = "store_id";



                btnNew1.Enabled = true;
                btnNew1.BackColor = System.Drawing.ColorTranslator.FromHtml("#24262F");

                //if (groupBox3.Visible == true)
                //{
                //    btnNew1.Enabled = false;
                //    btnNew1.BackColor = Color.DarkGray;
                //}

                btnRemove.Enabled = true;
                btnRemove.BackColor = System.Drawing.ColorTranslator.FromHtml("#24262F");
                dateNowReceived();
                // DGVstoredisplayproduct();
                if (cbStore.Text == "")
                {
                    btnNew1.Enabled = false;
                    btnNew1.BackColor = Color.DarkGray;
                    btnRemove.Enabled = false;
                    btnRemove.BackColor = Color.DarkGray;
                    btnAddproduct1.Visible = false;

                }

                try
                {
                    if (!metroGrid2.Rows[metroGrid2.CurrentCell.RowIndex].IsNewRow)
                    {
                        foreach (DataGridViewCell cell in metroGrid2.Rows[metroGrid2.CurrentCell.RowIndex].Cells)
                        {
                            btnAddproduct1.Visible = false;
                            if (cell.Value == System.DBNull.Value)
                            {

                            }
                        }


                    }
                }
                catch (NullReferenceException)
                {
                    btnAddproduct1.Visible = true;
                    return;
                }
            }
            catch (Exception)
            {

            }

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {


                MySqlConnection Conn = ConString.Connection;

                Cursor.Current = Cursors.WaitCursor;

                string Query = "select * from tbl_store where store_name = '" + cbServer.SelectedItem.ToString() + "'; ";

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
                MySqlDataAdapter sda = new MySqlDataAdapter("select * from tbl_store where store_name like '%" + cbServer.Text + "';", Conn);
                sda.Fill(dt);
                sda.SelectCommand = cmd;
                Conn.Close();
                txtstore_id.DataSource = dt;
                txtstore_id.DisplayMember = "store_id";
                txtstore_id.ValueMember = "store_id";



                btnNew1.Enabled = true;
                btnNew1.BackColor = System.Drawing.ColorTranslator.FromHtml("#24262F");

                //if (groupBox3.Visible == true)
                //{
                //    btnNew1.Enabled = false;
                //    btnNew1.BackColor = Color.DarkGray;
                //}

                btnRemove.Enabled = true;
                btnRemove.BackColor = System.Drawing.ColorTranslator.FromHtml("#24262F");
                // DGVstoredisplayproduct();
                if (cbServer.Text == "")
                {
                    btnNew1.Enabled = false;
                    btnNew1.BackColor = Color.DarkGray;
                    btnRemove.Enabled = false;
                    btnRemove.BackColor = Color.DarkGray;
                    btnAddproduct1.Visible = false;

                }

                try
                {
                    if (!metroGrid3.Rows[metroGrid3.CurrentCell.RowIndex].IsNewRow)
                    {
                        foreach (DataGridViewCell cell in metroGrid3.Rows[metroGrid3.CurrentCell.RowIndex].Cells)
                        {
                            lblMatch2.Visible = false;

                            groupBox2.Visible = true;
                            lbldatenow.Visible = true;
                            if (cell.Value == System.DBNull.Value)
                            {

                            }
                        }


                    }
                }
                catch (NullReferenceException)
                {

                    lblMatch2.Visible = true;
                    if (lblMatch2.Visible == true)
                    {
                        lblMatch2.Text = "No delivered product(s).";
                        btnRestock1.Enabled = false;
                        btnRestock1.BackColor = Color.DarkGray;
                        lblshowmessage.Text = "";
                        txtSubdays.Text = "";
                        txtHours.Text = "";
                        groupBox2.Visible = false;
                        lbldatenow.Visible = false;
                        return;
                    }



                }
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.Message);
            }



        }

        private void cbPrice_SelectedIndexChanged(object sender, EventArgs e)
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
                getproductid = row.Cells[0].Value.ToString();
                pending = row.Cells[10].Value.ToString();
                label29.Text = row.Cells[4].Value.ToString();
                txtAdjustQty1.Text = row.Cells[2].Value.ToString();

                if (pending == "Stocked" || pending == "Critical Level" || pending == "Out of Stocked")
                {
                    btnRequestAll.Enabled = true;
                    btnRequestAll.BackColor = System.Drawing.ColorTranslator.FromHtml("#24262F");
                    btnRequest.Enabled = true;
                    btnRequest.BackColor = System.Drawing.ColorTranslator.FromHtml("#24262F");
                }
                else
                {
                    btnRequestAll.Enabled = false;
                    btnRequestAll.BackColor = Color.DarkGray;
                    btnRequest.Enabled = false;
                    btnRequest.BackColor = Color.DarkGray;
                }



                if (pending == "")
                {
                    btnRequestAll.Enabled = true;
                    btnRequestAll.BackColor = System.Drawing.ColorTranslator.FromHtml("#24262F");
                    btnRequest.Enabled = true;
                    btnRequest.BackColor = System.Drawing.ColorTranslator.FromHtml("#24262F");
                    return;

                }
                if (pending == "Pending" || lblMatch1.Visible == true || pending == "OK")
                {
                    btnRequestAll.Enabled = false;
                    btnRequestAll.BackColor = Color.DarkGray;
                    btnRequest.Enabled = false;
                    btnRequest.BackColor = Color.DarkGray;
                }
                else
                {
                    btnRequestAll.Enabled = true;
                    btnRequestAll.BackColor = System.Drawing.ColorTranslator.FromHtml("#24262F");
                    btnRequest.Enabled = true;
                    btnRequest.BackColor = System.Drawing.ColorTranslator.FromHtml("#24262F");

                }
            }

            try
            {
                if (!metroGrid2.Rows[metroGrid2.CurrentCell.RowIndex].IsNewRow)
                {
                    foreach (DataGridViewCell cell1 in metroGrid2.Rows[metroGrid2.CurrentCell.RowIndex].Cells)
                    {
                        btnAddproduct1.Visible = false;
                        if (cell1.Value == System.DBNull.Value)
                        {

                        }
                    }


                }
            }
            catch (NullReferenceException)
            {
                btnAddproduct1.Visible = true;
                return;
            }
        }
        private void cbStore_TextChanged(object sender, EventArgs e)
        {


            if (cbStore.Text == "")
            {
                btnNew1.Enabled = false;
                btnNew1.BackColor = Color.DarkGray;
                btnRemove.Enabled = false;
                btnRemove.BackColor = Color.DarkGray;
                //CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[metroGrid2.DataSource];
                //currencyManager1.SuspendBinding();
                //metroGrid2.Columns[0].Visible = false;
                //metroGrid2.Columns[1].Visible = false;
                //metroGrid2.Columns[2].Visible = false;
                //metroGrid2.Columns[3].Visible = false;
                //currencyManager1.ResumeBinding();

                return;
            }
            else
            {
                CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[metroGrid2.DataSource];
                currencyManager1.SuspendBinding();
                metroGrid2.Columns[0].Visible = true;
                metroGrid2.Columns[1].Visible = true;
                metroGrid2.Columns[2].Visible = true;
                metroGrid2.Columns[3].Visible = true;
                currencyManager1.ResumeBinding();
            }

            if (cbStore.Text.Contains(@"\"))
            {
                return;
            }
            MySqlConnection Conn = ConString.Connection;


            var dtt = new DataTable();
            var sda = new MySqlDataAdapter("select store_name from tbl_store where store_name = '" + this.cbStore.Text + "'", Conn);
            sda.Fill(dtt);

            Conn.Close();


            if (dtt.Rows.Count >= 1 || dtt.Rows.Count == 1)
            {

                btnNew1.Enabled = true;
                btnNew1.BackColor = System.Drawing.ColorTranslator.FromHtml("#24262F");
                btnRemove.Enabled = true;
                btnRemove.BackColor = System.Drawing.ColorTranslator.FromHtml("#24262F");

                lblMatch1.Hide();



            }
            else
            {
                btnNew1.Enabled = false;
                btnNew1.BackColor = Color.DarkGray;
                btnRemove.Enabled = false;
                btnRemove.BackColor = Color.DarkGray;

                lblMatch1.Show();
                btnAddproduct1.Visible = false;

                btnRequestAll.Enabled = false;
                btnRequestAll.BackColor = Color.DarkGray;
                btnRequest.Enabled = false;
                btnRequest.BackColor = Color.DarkGray;

            }



            try
            {





                //Conn = ConString.Connection;
                // DataTable dt = new DataTable();

                // // sda = new MySqlDataAdapter("SELECT tbl_inventory.product_id as 'Product ID', tbl_inventory.product_name as 'Product Name', tbl_inventory.QTY as 'QTY', tbl_inventory.Price as 'Price'  FROM tbl_inventory left join tbl_store on tbl_inventory.store_id = tbl_store.store_id where tbl_store.store_name like '%"+cbStore.Text+"'", Conn);
                // sda = new MySqlDataAdapter("SELECT tbl_inventory.product_id as 'Product ID', tbl_product.product_name as 'Product Name', tbl_inventory.QTY as 'QTY', tbl_product.remarks as 'Price', tbl_inventory.status_pending as 'Status',tbl_inventory.status as 'Status' FROM tbl_inventory inner join tbl_product on tbl_inventory.product_id = tbl_product.product_id inner join tbl_store on tbl_inventory.store_id = tbl_store.store_id where tbl_store.store_id = '"+frm_Login.global_storeid+"' and tbl_store.store_name like '%" + cbStore.Text + "' group by tbl_inventory.product_id", Conn);
                // sda.Fill(dt);
                // Conn.Close();
                // metroGrid2.DataSource = dt;

                if (lblMatch1.Visible == true || cbStore.SelectedIndex == -1)
                {
                    txtstore_id.Text = "";
                    //btnRequestAll.Enabled = false;
                    //btnRequestAll.BackColor = Color.DarkGray;
                    //btnRequest.Enabled = false;
                    //btnRequest.BackColor = Color.DarkGray;
                }




                Conn = ConString.Connection;
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
                sda = new MySqlDataAdapter("select * from tbl_store where store_id = '" + frm_Login.global_storeid + "' and store_name like '%" + cbStore.Text + "';", Conn);
                sda.Fill(dt);
                sda.SelectCommand = cmd;
                Conn.Close();
                txtstore_id.DataSource = dt;
                txtstore_id.DisplayMember = "store_id";
                txtstore_id.ValueMember = "store_id";





            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                if (!metroGrid2.Rows[metroGrid2.CurrentCell.RowIndex].IsNewRow)
                {
                    foreach (DataGridViewCell cell in metroGrid2.Rows[metroGrid2.CurrentCell.RowIndex].Cells)
                    {
                        btnAddproduct1.Visible = false;
                        if (cell.Value == System.DBNull.Value)
                        {

                        }
                    }


                }
            }
            catch (NullReferenceException)
            {
                if (lblMatch1.Visible == true)
                {
                    btnRequestAll.Enabled = false;
                    btnRequestAll.BackColor = Color.DarkGray;
                    btnRequest.Enabled = false;
                    btnRequest.BackColor = Color.DarkGray;
                    return;
                }

                btnAddproduct1.Visible = true;

            }

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            MySqlConnection Conn = ConString.Connection;

            MySqlCommand cmd = new MySqlCommand("Delete FROM tbl_inventory where store_id = '" + txtstore_id.Text + "';Delete FROM tbl_store where store_id = '" + txtstore_id.Text + "'", Conn);
            cmd.CommandTimeout = 50000;
            // Conn.Open();


            if (MessageBox.Show("Are you sure, you want to remove server: " + cbStore.Text, "Fabula's Merchandise System", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
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
                if (cbStore.SelectedIndex == -1)
                {
                    cbStore.Text = "";
                    lblMatch1.Show();
                }
                else
                {
                    lblMatch1.Hide();
                }
                refreshCB();
                refresh_autocomplete();
                DGVstoredisplayproduct();

                if (cbStore.SelectedIndex == -1)
                {
                    lblMatch1.Show();
                    cbStore.Text = "";
                }
                else
                {
                    lblMatch1.Hide();
                }

            }
            try
            {
                if (!metroGrid2.Rows[metroGrid2.CurrentCell.RowIndex].IsNewRow)
                {
                    foreach (DataGridViewCell cell in metroGrid2.Rows[metroGrid2.CurrentCell.RowIndex].Cells)
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
                btnRemove.Enabled = false;
                btnRemove.BackColor = Color.DarkGray;
                if (lblMatch1.Visible == true)
                {
                    btnAddproduct1.Visible = false;
                    return;
                }



            }
        }

        private void cbProductname_Click(object sender, EventArgs e)
        {

        }

        private void cbProductID_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnAddproduct1.Visible = true;
            btnAddproduct1.BackColor = System.Drawing.ColorTranslator.FromHtml("#24262F");
        }

        private void btnRequest_Click(object sender, EventArgs e)
        {

            MySqlConnection Conn = ConString.Connection;
            MySqlDataReader myReader;

            Cursor.Current = Cursors.WaitCursor;
            string status = "Requested";
            string pending = "Pending";
            string Query = "update tbl_inventory set status = '" + status + "' where store_id = '" + txtstore_id.Text + "' and subQTY = 0 and status = 'New Product'";

            MySqlCommand cmd = new MySqlCommand(Query, Conn);
            cmd.CommandTimeout = 50000;






            try
            {


                myReader = cmd.ExecuteReader();
                while (myReader.Read())
                {



                }
                Conn.Close();
            }
            catch (Exception ex1)
            {
                MessageBox.Show(ex1.Message);
            }
            //  metroGrid2.Columns[5].Visible = true;


            MessageBox.Show("Requested all successfully.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);



            btnRequestAll.Enabled = false;
            btnRequestAll.BackColor = Color.DarkGray;
            btnRequest.Enabled = false;
            btnRequest.BackColor = Color.DarkGray;
            DGVstoredisplayproduct();
            showRQ();
            changeRowColor();
        }

        private void btnRQ_MouseHover(object sender, EventArgs e)
        {


        }

        private void btnRQ_Click(object sender, EventArgs e)
        {
            metroGrid4.Visible = false;
            panelNotifyBranch.Visible = true;
            chartForecast.Visible = false;
            pArrow2.Visible = true;

            pictureBox1.Visible = false;
            lblqtycritical.Visible = true;
            pCritical1.Visible = true;

            if (panelNotifyBranch.Visible == true)
            {
                btnBranchNotify.Visible = false;
                btnOpenNotify.Visible = true;
                lblbranchqty.Visible = false;

                pArrow.Visible = false;
                panelNotification.Visible = false;
            }
            else
            {
                btnBranchNotify.Visible = true;
                btnOpenNotify.Visible = false;
                lblbranchqty.Visible = true;
                pArrow.Visible = true;

            }
            zeronotify();
            subzeronotify1();
        }

        private void dataGridView1_MultiSelectChanged(object sender, EventArgs e)
        {

            //foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
            //{

            //    MessageBox.Show(cell.Value.ToString());
            //    dataGridView1.Rows[cell.RowIndex].Cells[cell.ColumnIndex].Value = 1;
            //    break;
            //}
        }

        private void cbServer_TextChanged(object sender, EventArgs e)
        {


            if (cbServer.Text.Contains(@"\"))
            {
                return;



            }

            //   SearchingOK();
            //if(cbServer.Text == "")
            //  {
            //      SearchingOK();
            //  }

            if (lblMatch2.Visible == true)
            {
                // groupBox2.Visible = false;
            }
            else
            {
                groupBox2.Visible = true;
            }
        }
        //void SearchingOK()
        //{
        //    //MySqlConnection Conn = ConString.Connection;
        //    //try
        //    //{






        //    //    DataTable dt = new DataTable();

        //    //    // sda = new MySqlDataAdapter("SELECT tbl_inventory.product_id as 'Product ID', tbl_inventory.product_name as 'Product Name', tbl_inventory.QTY as 'QTY', tbl_inventory.Price as 'Price'  FROM tbl_inventory left join tbl_store on tbl_inventory.store_id = tbl_store.store_id where tbl_store.store_name like '%"+cbStore.Text+"'", Conn);
        //    //    MySqlDataAdapter sda = new MySqlDataAdapter("SELECT tbl_inventory.product_id as 'Product ID', tbl_product.product_name as 'Product Name', QTY as 'QTY in Branch',  tbl_inventory.subQTY as 'QTY Received', tbl_inventory.date_delivered as 'Date Delivered', tbl_inventory.date_expected as 'Delivery Date', tbl_inventory.subStatus as 'Status', tbl_inventory.store_id,tbl_inventory.s_replacement FROM tbl_inventory inner join tbl_product on tbl_inventory.product_id = tbl_product.product_id where tbl_inventory.store_id = '" + txtstore_id.Text + "' and tbl_inventory.subStatus = 'Pending' or  tbl_inventory.subStatus = 'OK' and tbl_inventory.store_id = '" + txtstore_id.Text + "' group by tbl_inventory.product_id", Conn);
        //    //    sda.Fill(dt);
        //    //    Conn.Close();
        //    //    metroGrid3.DataSource = dt;

        //    //    try
        //    //    {
        //    //        if (!metroGrid3.Rows[metroGrid3.CurrentCell.RowIndex].IsNewRow)
        //    //        {
        //    //            foreach (DataGridViewCell cell in metroGrid3.Rows[metroGrid3.CurrentCell.RowIndex].Cells)
        //    //            {
        //    //                lblMatch2.Visible = false;
        //    //                lbldatenow.Visible = true;
        //    //                groupBox2.Visible = true;
        //    //                if (cell.Value == System.DBNull.Value)
        //    //                {

        //    //                }
        //    //            }


        //    //        }
        //    //    }
        //    //    catch (NullReferenceException)
        //    //    {

        //    //        lblMatch2.Visible = true;
        //    //        if (lblMatch2.Visible == true)
        //    //        {
        //    //            lblMatch2.Text = "No delivered product(s).";
        //    //            btnRestock1.Enabled = false;
        //    //            btnRestock1.BackColor = Color.DarkGray;
        //    //            lbldatenow.Visible = false;
        //    //            lblshowmessage.Text = "";
        //    //            txtSubdays.Text = "";
        //    //            txtHours.Text = "";
        //    //            groupBox2.Visible = false;
        //    //            return;
        //    //        }



        //    //    }


        //    //}




        //    //catch (Exception ex)
        //    //{
        //    //    MessageBox.Show(ex.Message);
        //    //}

        //}

        private void metroGrid3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void metroTile2_Click(object sender, EventArgs e)
        {

        }

        private void metroGrid3_SelectionChanged(object sender, EventArgs e)
        {
            try
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
                    gettingproductid = row.Cells[0].Value.ToString();
                    getpname = row.Cells[1].Value.ToString();
                    lblreceived.Text = row.Cells[3].Value.ToString();
                    lblcurrentstock.Text = row.Cells[2].Value.ToString();
                    dateOrdered.Text = row.Cells[4].Value.ToString();
                    dateTimePicker4.Text = row.Cells[5].Value.ToString();
                    getting_status = row.Cells[6].Value.ToString();
                    label32.Text = row.Cells[6].Value.ToString();
                    label30.Text = row.Cells[6].Value.ToString();
                    status_replacement = row.Cells[8].Value.ToString();




                    //DateTime startdate = dateTimePicker3.Value;
                    //DateTime enddate = dateTimePicker4.Value;
                    //txtSubdays.Text = Days1(startdate, enddate).ToString();

                    //DateTime StartDate1 = dateTimePicker3.Value;
                    //DateTime EndTime1 = dateTimePicker4.Value;
                    //txtHours.Text = Hours1(StartDate1, EndTime1).ToString();

                    //DateTime date1 = dateTimePicker2.Value;
                    //DateTime date2 = dateExpected.Value;

                    //TimeSpan difference = date2.Subtract(date1);

                    //txtSubdays.Text = Convert.ToInt32(date2.Subtract(date1).Days).ToString();

                    if (txtSubdays.Text == "" || txtSubdays.Text == "0")
                    {
                        //txtSubdays.Text = "0";
                        txtHours.Text = "0";
                        lblshowmessage.Text = "";
                    }

                    txtSubdays.Text = (dateTimePicker4.Value - DateTime.Today).TotalDays.ToString("#");

                    dateTimePicker4.Enabled = false;
                    if (txtHours.Text.Contains("-"))
                    {
                        txtHours.Text = "0";
                    }
                    if (txtSubdays.Text.Contains("-"))
                    {
                        txtSubdays.Text = "0";
                    }

                    if (txtSubdays.Text == "1")
                    {
                        lbldays.Text = "Day left";
                    }
                    else
                    {
                        lbldays.Text = "Days left";
                    }
                    if (txtHours.Text == "1")
                    {
                        lblhours.Text = "Hour left";
                    }
                    else
                    {
                        lblhours.Text = "Hours left";
                    }

                    if (lblMatch2.Visible == true)
                    {
                        //groupBox2.Visible = false;
                    }
                    else
                    {
                        groupBox2.Visible = true;
                    }


                    if (label30.Text == "Received")
                    {
                        btnRestock1.Enabled = true;
                        btnRestock1.BackColor = System.Drawing.ColorTranslator.FromHtml("#24262F");
                        lblshowmessage.Text = "";
                        return;
                    }

                    if (getting_status == "OK" || getting_status == "Backorder" || getting_status == "Delayed order" || getting_status == "Backorder Pending")
                    {
                        btnRestock1.Enabled = false;
                        btnRestock1.BackColor = Color.DarkGray;
                        lblshowmessage.Text = "";
                        return;

                    }

                    if (dateTimePicker3.Text != dateTimePicker4.Text)
                    {
                        btnRestock1.Enabled = false;
                        btnRestock1.BackColor = Color.DarkGray;
                        lblshowmessage.Text = "The product: '" + getpname + "' will be delivered: " + txtSubdays.Text + (" day(s) left in ") + dateTimePicker4.Text;

                    }
                    else
                    {
                        lblshowmessage.Text = "";

                    }
                    if (!(txtSubdays.Text == ""))
                    {

                        lblshowmessage.Text = "The product: '" + getpname + "' will be delivered: " + txtSubdays.Text + (" day(s) left in ") + dateTimePicker4.Text;
                        btnRestock1.Enabled = false;
                        btnRestock1.BackColor = Color.DarkGray;
                        return;
                    }
                    else
                    {
                        lblshowmessage.Text = "";


                    }

                    if (!(txtSubdays.Text == "") && dateTimePicker3.Text != dateTimePicker4.Text)
                    {

                        //MessageBox.Show("The product: '" +productname + "' will be delidgvered: " +txtSubdays.Text +(" day(s) and ") +txtHours.Text+(" hour(s) left in ") + dateExpected.Text, "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lblshowmessage.Text = "The product: '" + getpname + "' will be delivered: " + txtSubdays.Text + (" day(s) left in ") + dateTimePicker4.Text;
                        btnRestock1.Enabled = false;
                        btnRestock1.BackColor = Color.DarkGray;


                        return;
                    }
                    else
                    {
                        lblshowmessage.Text = "";

                    }

                    if (dateTimePicker3.Text == dateTimePicker4.Text && txtSubdays.Text == "")
                    {
                        btnRestock1.Enabled = true;
                        btnRestock1.BackColor = System.Drawing.ColorTranslator.FromHtml("#24262F");


                        return;

                    }

                    else
                    {
                        btnRestock1.Enabled = false;
                        btnRestock1.BackColor = Color.DarkGray;
                        lblreceived.Text = "0";
                        //  txtQtyRestock.Enabled = false;

                    }

                    if (lblMatch2.Visible == true)
                    {
                        btnRestock1.Enabled = false;
                        btnRestock1.BackColor = Color.DarkGray;
                    }


                }
            }
            catch (Exception)
            {

            }

        }

        private void metroTile3_Click(object sender, EventArgs e)
        {
            if (lblcurrentstock.Text == "")
            {
                MessageBox.Show("There is no more restock.");
                return;
            }




            try
            {
                MySqlConnection Conn = ConString.Connection;
                string statuset = "Available";
                string pending = "Pending";

                sum = Convert.ToInt32(lblcurrentstock.Text) + Convert.ToInt32(lblreceived.Text);


                string Query = "update tbl_inventory set  subStatus = 'Stocked', status_pending = '" + statuset + "', QTY = '" + sum + "',  status = 'Stocked' where product_id = '" + gettingproductid + "' and store_id = '" + txtstore_id.Text + "';update tbl_inventory set  status_sent = 'Distribute' where product_id = '" + gettingproductid + "' and store_id = '" + txtstore_id.Text + "' and status_sent = 'Sent';";
                //                    "update tbl_inventory set critical = 0 where qty > critical and product_id = '" + gettingproductid + "' and store_id = '" + txtstore_id.Text + "'
                MySqlCommand cmd = new MySqlCommand(Query, Conn);
                MySqlDataReader myReader;



                try
                {

                    myReader = cmd.ExecuteReader();


                    while (myReader.Read())
                    {
                        lblreceived.Text = myReader[1].ToString();
                        lblcurrentstock.Text = myReader[2].ToString();
                        DataGridViewRow newDataRow = dataGridView1.Rows[selectedRow];

                        // newDataRow.Cells[1].Value = lblreceived.Text;

                    }
                }
                catch (Exception)
                {

                    MessageBox.Show("Please double click the item in selection product list.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.None);
                }













                lblreceived.Text = "";


                Conn.Close();

                //RemoveListCritical();

                //CriticalLevel();












            }

            catch (FormatException)
            {

            }

            MessageBox.Show("Stocked successfully.", "Fabula's Merchandise", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            DGVstoreOK();
            ByNotifyBranch();

            try
            {
                if (!metroGrid3.Rows[metroGrid3.CurrentCell.RowIndex].IsNewRow)
                {
                    foreach (DataGridViewCell cell in metroGrid3.Rows[metroGrid3.CurrentCell.RowIndex].Cells)
                    {

                        lblMatch2.Visible = false;

                        if (cell.Value == System.DBNull.Value)
                        {
                            btnRestock1.BackColor = System.Drawing.ColorTranslator.FromHtml("#24262F");
                            btnRestock1.Enabled = true;
                        }
                    }


                }
            }
            catch (NullReferenceException)
            {
                lblMatch2.Visible = true;

                btnRestock1.Enabled = false;
                btnRestock1.BackColor = Color.DarkGray;

            }
        }

        private void metroGrid2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void metroTile2_Click_1(object sender, EventArgs e)
        {
            hideNotifyPanel();
            Cursor.Current = Cursors.AppStarting;
            var myForm = new frm_EditDateDelivery();
            myForm.ShowDialog();
        }

        private void metroTile3_Click_1(object sender, EventArgs e)
        {
            MySqlConnection Conn = ConString.Connection;

            MySqlDataReader myReader;

            Cursor.Current = Cursors.WaitCursor;
            string status = "Requested";
            string pending = "Pending";

            if (label29.Text == "Available")
            {

                string Query = "update tbl_inventory set status = 'Requested', subStatus = 'Stocked'  where store_id = '" + txtstore_id.Text + "' and product_id = '" + getproductid + "' and status = 'Stocked'";

                MySqlCommand cmd = new MySqlCommand(Query, Conn);
                cmd.CommandTimeout = 50000;


                try
                {


                    myReader = cmd.ExecuteReader();
                    while (myReader.Read())
                    {



                    }
                    Conn.Close();
                }
                catch (Exception ex1)
                {
                    MessageBox.Show(ex1.Message);
                }
            }
            else if (label29.Text == "Not Available")
            {
                Conn = ConString.Connection;
                string Query = "update tbl_inventory set subStatus = 'Stocked'  where store_id = '" + txtstore_id.Text + "' and product_id = '" + getproductid + "' and status = 'Critical Level'";

                MySqlCommand cmd = new MySqlCommand(Query, Conn);
                cmd.CommandTimeout = 50000;


                try
                {


                    myReader = cmd.ExecuteReader();
                    while (myReader.Read())
                    {



                    }
                    Conn.Close();
                }
                catch (Exception ex1)
                {
                    MessageBox.Show(ex1.Message);
                }

            }
            else
            {


                string Query = "update tbl_inventory set status = '" + status + "', status_pending = '" + pending + "' where store_id = '" + txtstore_id.Text + "' and subQTY = 0 and product_id = '" + getproductid + "'";

                MySqlCommand cmd = new MySqlCommand(Query, Conn);
                cmd.CommandTimeout = 50000;






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


            }
            //metroGrid2.Columns[5].Visible = true;
            MessageBox.Show("Requested successfully.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            Conn.Close();

            btnRequestAll.Enabled = false;
            btnRequestAll.BackColor = Color.DarkGray;
            btnRequest.Enabled = false;
            btnRequest.BackColor = Color.DarkGray;
            DGVstoredisplayproduct();
            showRQ();
            changeRowColor();
        }
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
            //  DateTime startdate = dateTimePicker2.Value;
            //  DateTime enddate = dateExpected.Value;
            ////  txtSubdays.Text = Days1(startdate, enddate).ToString();



            //  DateTime date1 = dateTimePicker2.Value;
            //  DateTime date2 = dateExpected.Value;

            //   TimeSpan difference = date2.Subtract(date1);
            txtSubdays.Text = (dateTimePicker4.Value - DateTime.Today).TotalDays.ToString("#");
            //  txtHours.Text = Convert.ToInt32(date2.Subtract(date1).Hours).ToString();

            if (dateTimePicker4.Text == dateTimePicker3.Text)
            {
                txtSubdays.Text = "0";
            }

            //if ((date2 < date1 && dateTimePicker2.Text != dateExpected.Text))
            //{
            //    //  MessageBox.Show("The date doesn't look right. Be sure to use the actual date.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    dateExpected.Text = dateTimePicker1.Text;
            //}
            if (txtHours.Text.Contains("-"))
            {
                txtHours.Text = "0";
            }
            if (txtSubdays.Text == "1")
            {
                lbldays.Text = "Day Left";
            }
            else
            {
                lbldays.Text = "Days Left";
            }
            if (txtHours.Text == "1")
            {
                lblhours.Text = "Hour Left";
            }
            else
            {
                lblhours.Text = "Hours Left";
            }
        }

        private void metroGrid3_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtSubdays.Text == "")
            {
                // txtSubdays.Text = "0";
                txtHours.Text = "0";
            }

            //if (!(txtSubdays.Text == ""))
            //{
            //    //MessageBox.Show("The product: '" +productname + "' will be delivered: " +txtSubdays.Text +(" day(s) and ") +txtHours.Text+(" hour(s) left in ") + dateExpected.Text, "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    lblshowmessage.Text = "The product: '" + getpname + "' will be delivered: " + txtSubdays.Text + (" day(s) left in ") + dateTimePicker4.Text;
            //    btnRestock1.Enabled = false;
            //    btnRestock1.BackColor = Color.DarkGray;
            //    return;
            //}

            //if (!(txtSubdays.Text == "0" && txtHours.Text == "0"))
            //{

            //    //MessageBox.Show("The product: '" +productname + "' will be delivered: " +txtSubdays.Text +(" day(s) and ") +txtHours.Text+(" hour(s) left in ") + dateExpected.Text, "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    lblshowmessage.Text = "The product: '" + getpname + "' will be delivered: " + txtHours.Text + (" hour(s) left in ") + dateTimePicker4.Text;
            //    btnRestock1.Enabled = false;
            //    btnRestock1.BackColor = Color.DarkGray;
            //    return;
            //}
            try
            {




                if (metroGrid3.Rows.Count > 0)
                {
                    getting_store_id = Convert.ToInt32(metroGrid3.SelectedRows[0].Cells[7].Value.ToString());
                    getting_product_id = Convert.ToInt32(metroGrid3.SelectedRows[0].Cells[0].Value.ToString());
                    getting_status = metroGrid3.SelectedRows[0].Cells[6].Value.ToString();
                    status_replacement = metroGrid3.SelectedRows[0].Cells[8].Value.ToString();

                }

            }
            catch (Exception)
            {

            }
            //MySqlConnection Conn = ConString.Connection;


            //string Query = "select* from tbl_order where order_id = '" + orderid + "'";
            //MySqlCommand cmd = new MySqlCommand(Query, Conn);
            //MySqlDataReader myReader;

            //try
            //{

            //    myReader = cmd.ExecuteReader();

            //    while (myReader.Read())
            //    {

            //        orderstatusss = myReader.GetString("status");

            //    }

            //    label17.Text = productid.ToString();
            //    label16.Text = statusss;

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}




            //Conn.Close();
            //if(status_replacement == "")
            //{
            //    MessageBox.Show("Replacement", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //}

            if (getting_status == "Received")
            {
                //MessageBox.Show("Product(s) is/are already inspected", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
            else if (getting_status == "Delayed order")
            {


            }
            else if (getting_status == "Pending")
            {


            }
            else if (getting_status == "Backorder Pending")
            {


            }
            else
            {
                frm_Inspection_of_Product_In_Branch cq = new frm_Inspection_of_Product_In_Branch();
                cq.ShowDialog();

                DGVstoreOK();

                NotifyBranch();
                NotifyCritical();
                NotifyExpiry();
                subNotifyBranch();
            }
        }

        private void dateOrdered_ValueChanged(object sender, EventArgs e)
        {
            //DateTime date1 = dateTimePicker2.Value;
            //DateTime date2 = dateExpected.Value;

            //TimeSpan difference = date2 - date1;
            //txtDays.Text = difference.TotalDays.ToString();
            //txtSubdays.Text = difference.TotalDays.ToString();
            //txtHours.Text = difference.TotalHours.ToString();
            //txtMinutes.Text = difference.TotalMinutes.ToString();
            //txtSeconds.Text = difference.TotalSeconds.ToString();
            //txtMilliseconds.Text = difference.TotalMilliseconds.ToString();
        }

        private void metroGrid3_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            // txtSubdays.Text = (dateTimePicker4.Value - dateTimePicker3.Value).TotalDays.ToString("#");
        }

        private void metroGrid3_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void Production_ValueChanged(object sender, EventArgs e)
        {
            DateTime date1 = Production.Value;
            DateTime date2 = Expiry.Value;

            TimeSpan difference = date2.Subtract(date1);


            if (date1 > date2)
            {
                MessageBox.Show("Invalid date for production.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnRestock.Enabled = false;
                btnRestock.BackColor = Color.Gray;

                Production.Text = dateTimePicker1.Text;
            }
        }

        private void Expiry_ValueChanged(object sender, EventArgs e)
        {
            DateTime date1 = DateTime.Now;
            DateTime date2 = subdate.Value;

            TimeSpan difference = date2.Subtract(date1);

            if (Expiry.Value < date2 || lblStatus.Text != "Received")

            {

                btnRestock.Enabled = false;
                btnRestock.BackColor = Color.DarkGray;


            }
            else
            {

                btnRestock.Enabled = true;
                btnRestock.BackColor = System.Drawing.ColorTranslator.FromHtml("#24262F");

            }
        }

        private void metroTile2_Click_2(object sender, EventArgs e)
        {
            hideNotifyPanel();
            //try
            //{

            //    if (openFileDialog.ShowDialog() == DialogResult.OK)
            //    {



            //        btnSave1.Enabled = true;
            //        btnSave1.BackColor = Color.DarkBlue;

            //        if (btnAddProduct.Enabled == true)
            //        {
            //            btnSave1.Enabled = false;
            //            btnSave1.BackColor = Color.DarkGray;
            //        }
            //        else if (pictureBox3.WaitOnLoad == false)
            //        {
            //            btnSave1.Enabled = true;
            //            btnSave1.BackColor = Color.DarkBlue;
            //        }
            //        dataGridView1.Focus();

            //        pictureBox3.Image = new Bitmap(openFileDialog.FileName);
            //        label35.Text = string.Format("C:\\\\Users\\\\Elixer Abaya Macafe\\\\Pictures\\\\{0}", openFileDialog.SafeFileName);
            //        pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;



            //        for (int i = 0; i < dataGridView1.Rows.Count; i++)
            //        {
            //            if (dataGridView1.Rows[i].Cells[14].Value.ToString() == label35.Text)
            //            {
            //                btnSave1.Enabled = false;
            //                btnSave1.BackColor = Color.DarkGray;
            //                MessageBox.Show("This picture has been existed.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //                btnSave1.Enabled = false;
            //                btnSave1.BackColor = Color.DarkGray;
            //            }
            //        }
            //    }

            //}
            //catch (Exception ex)
            //{
            //    //MessageBox.Show("Image error " + ex.ToString());
            //}
            //finally
            //{
            //    MySqlConnection Conn = ConString.Connection;
            //    Conn.Close();
            //}
            try
            {



                OpenFileDialog opf = new OpenFileDialog();
                opf.Filter = "Choose Image(*.jpg; *.png; *.gif)|*.jpg; *.png; *.gif";
                if (opf.ShowDialog() == DialogResult.OK)
                {
                    pictureBox3.Image = Image.FromFile(opf.FileName);
                    if (btnAddProduct.Enabled == true)
                    {
                        btnSave1.Enabled = false;
                        btnSave1.BackColor = Color.DarkGray;
                    }
                    else if (pictureBox3.WaitOnLoad == false)
                    {
                        btnSave1.Enabled = true;
                        btnSave1.BackColor = Color.DarkBlue;
                    }

                    if (btnSave1.BackColor == System.Drawing.ColorTranslator.FromHtml("#24262F"))
                    {


                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void btnSave1_Click_1(object sender, EventArgs e)
        {
            hideNotifyPanel();
            if (txtUnitPrice.Text == ".")
            {
                MessageBox.Show("Please input price.");
                return;
            }
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
            try
            {


                string newLocation = string.Format("\\\\{0}\\\\{1}\\\\{2}", ConString.ip, imageFolder, openFileDialog.SafeFileName);

                if (System.IO.File.Exists(openFileDialog.FileName) == true)
                {

                    System.IO.File.Copy(openFileDialog.FileName, newLocation);
                    save();

                }
                else
                {
                    // MessageBox.Show("No such item exists.");

                    try
                    {


                        txtQtyRestock.Text = "";
                        //   btnSave1.Enabled = false;
                        MySqlConnection Conn = ConString.Connection;
                        string Query = "UPDATE tbl_product SET product_name = '" + this.txtProductName.Text + "', product_price = '" + this.txtUnitPrice.Text + "', category = '" + this.txtCategory.Text + "',stock = '" + this.txtAdjustQty.Text + "', description = '" + this.txtDescription.Text + "', reason = '" + this.txtReason.Text + "',production_date = '" + dProduction.Text + "',expiry_date = '" + dExpiry.Text + "', remarks = '" + txtRemarks.Text + "',  s_adjust_ware = '" + Convert.ToInt32(txtMinusQTY.Text) + "', date_adjust_ware = '" + lblDateTime.Text + "' where product_id = '" + this.txtProductID.Text + "'";



                        MySqlCommand cmd = new MySqlCommand(Query, Conn);
                        MySqlDataReader myReader;

                        if ((txtDescription.Text.Contains("'")))
                        {
                            MessageBox.Show("Remove the single quote.");
                            return;
                        }
                        if ((txtDescription.Text.Contains(@"\")))
                        {
                            MessageBox.Show("Remove the backslash.");
                            return;
                        }




                        if (txtProductName.Text == "" || txtUnitPrice.Text == "" || txtCategory.Text == "")
                        {
                            MessageBox.Show("Invalid fill the blank fields.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.None);

                            return;
                        }
                        if (MessageBox.Show("Do you want to save the changes you have made to the field(s)?", "Fabula's Merchandise System", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {

                            try
                            {

                                myReader = cmd.ExecuteReader();

                                while (myReader.Read())
                                {
                                    Cursor.Current = Cursors.WaitCursor;
                                    DataGridViewRow newDataRow = dataGridView1.Rows[selectedRow];
                                    newDataRow.Cells[0].Value = txtProductID.Text;
                                    newDataRow.Cells[1].Value = txtProductName.Text;
                                    newDataRow.Cells[2].Value = txtRemarks.Text;
                                    newDataRow.Cells[3].Value = txtQtyRestock.Text;
                                    newDataRow.Cells[3].Value = txtAdjustQty.Text;
                                    newDataRow.Cells[4].Value = txtCategory.Text;
                                    newDataRow.Cells[5].Value = cbSupplier.Text;
                                    newDataRow.Cells[9].Value = txtDescription.Text;
                                    //      newDataRow.Cells[10].Value = txtReason.Text;
                                    newDataRow.Cells[11].Value = dProduction.Text;
                                    newDataRow.Cells[12].Value = dExpiry.Text;
                                    btnSave1.BackColor = Color.DarkGray;
                                    //  btnSave1.Enabled = false;
                                }
                            }
                            catch (Exception ex)
                            {

                                MessageBox.Show(ex.Message, "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.None);
                            }
                            Cursor.Current = Cursors.WaitCursor;

                            MessageBox.Show("Changes saved successfully!", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            Conn.Close();
                            ExpiryDate();




                            //btnSave1.BackColor = Color.DarkGray;
                            //btnSave1.Enabled = false;
                            // SearchList();


                            btnAdjust.Enabled = false;
                            txtReason.Enabled = true;

                            if (frm_Login.stockman == "Stockman")
                            {
                                btnSave1.Visible = false;
                            }

                            //if (txtMinusQTY.Text != "0")
                            //{


                            //    try
                            //    {
                            //        MySqlConnection Conn = ConString.Connection;


                            //        string Query = "Update tbl_product set status_sa = 'Stock Adjusted' where product_id = '" + txtProductID.Text + "'";
                            //        MySqlCommand cmd = new MySqlCommand(Query, Conn);


                            //        MySqlDataReader myReader;
                            //        myReader = cmd.ExecuteReader();



                            //        while (myReader.Read())
                            //        {

                            //        }
                            //        Conn.Close();
                            //    }
                            //    catch (Exception ex)
                            //    {
                            //        MessageBox.Show(ex.Message);
                            //    }
                            //}
                            subExpiryDate1();
                            subExpiryDate();
                            refreshCBproduct();
                            expired();
                            damaged();
                            bite();



                            // pictureBox3.Image = null;
                            MemoryStream ms = new MemoryStream();
                            pictureBox3.Image.Save(ms, pictureBox3.Image.RawFormat);
                            byte[] img = ms.ToArray();

                            MySqlConnection Conn1 = ConString.Connection;

                            // string Query = "UPDATE  INTO tbl_product(product_id, imageLocation) VALUES('"+this.txtProductID.Text+ "', @img)";
                            string Query1 = "Update tbl_product set imageLocation = @img where product_id = '" + this.txtProductID.Text + "'";

                            MySqlCommand cmd1 = new MySqlCommand(Query1, Conn1);

                            cmd1.Parameters.Add("@img", MySqlDbType.Blob);

                            cmd1.Parameters["@img"].Value = img;


                            if (cmd1.ExecuteNonQuery() == 1)
                            {

                            }
                            Conn1.Close();
                        }
                    }
                    catch (Exception)
                    {

                    }
                }
            }

            catch (Exception)
            {
                save();
            }

            DGVInventoryProductList();
            subshowcolumn();
            txtMinusQTY.Text = "0";
            NotifyBranch();
            NotifyCritical();
            NotifyExpiry();
            subNotifyBranch();
            refreshCategory();
            btnCritical.TextAlign = ContentAlignment.MiddleLeft;
            btnCritical.Text = "       Critical Level " + "(" + criticalqty + ")";

            btnExpiration.TextAlign = ContentAlignment.MiddleLeft;
            btnExpiration.Text = "       Expiration " + "(" + expiryqty + ")";


            btnNP.TextAlign = ContentAlignment.MiddleLeft;
            btnNP.Text = "       New Products " + "(" + qtynew + ")";

            btnCL.TextAlign = ContentAlignment.MiddleLeft;
            btnCL.Text = "       Requests " + "(" + qtycritical1 + ")";


            btnBO.TextAlign = ContentAlignment.MiddleLeft;
            btnBO.Text = "       Backorder " + "(" + qtybackorder + ")";

            int notifyadd = criticalqty + expiryqty;
            int notifyaddbranch = qtycritical1 + qtybackorder;

            lblbranchqty.Text = notifyaddbranch.ToString();

            lblqtycritical.Text = notifyadd.ToString();
            if (frm_Login.stockman == "Stockman")
            {
                btnSave1.Visible = false;
            }


            txtReason.Items.Remove("Expired");
            dataGridView1.Columns[5].Visible = false;



        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            hideNotifyPanel();
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void tabPage6_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DGVstoredisplayproduct();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.metroGrid2.Sort(this.metroGrid2.Columns["Product Name"], ListSortDirection.Ascending);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            metroGrid2.FirstDisplayedScrollingRowIndex = metroGrid2.RowCount - 1;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DGVstoredisplayproduct();
        }

        private void btnAdjust1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMinusQTY1.Text == "0")
                {
                    MessageBox.Show("Enter amount of QTY for stock adjustment.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (txtAdjustQty1.Text == "0")
                {
                    MessageBox.Show("You don't have stock. Please add amount of product from warehouse.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (txtAdjustQty1.Text == "" || txtAdjustQty1.Text == "0")
                {
                    MessageBox.Show("Enter amount of QTY for stock adjustment.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (int.Parse(txtMinusQTY1.Text) < int.Parse(txtAdjustQty1.Text))
                {



                    int val1 = int.Parse(txtAdjustQty1.Text);
                    int val2 = int.Parse(txtMinusQTY1.Text);

                    int val3 = val1 - val2;

                    txtAdjustQty1.Text = val3.ToString();
                }
                else
                {
                    txtMinusQTY1.Text = "0";
                    MessageBox.Show("Stock adjustment failed.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }

                txtMinusQTY1.Enabled = false;



            }
            catch (FormatException)
            {

            }
            btnAdjust1.Enabled = false;


            try
            {
                MySqlConnection Conn = ConString.Connection;


                string Query = "Update tbl_inventory set QTY = '" + Convert.ToInt32(txtAdjustQty1.Text) + "', s_adjust = '" + Convert.ToInt32(txtMinusQTY1.Text) + "', status_adjust = 'Stock Adjusted', reason1 = '" + txtReason1.Text + "', date_adjust = '" + lblDateTime.Text + "' where product_id = '" + getproductid + "' and store_id = '" + frm_Login.global_storeid + "';";
                MySqlCommand cmd = new MySqlCommand(Query, Conn);


                MySqlDataReader myReader;
                myReader = cmd.ExecuteReader();



                while (myReader.Read())
                {

                }
                MessageBox.Show("Stock adjustment successful.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            DGVstoredisplayproduct();
            ByNotifyBranch();
        }

        private void txtReason1_TextChanged(object sender, EventArgs e)
        {
            if (txtReason1.Text.Length >= 20)
            {
                txtMinusQTY1.Enabled = true;
                btnAdjust1.Enabled = true;
            }
            else
            {
                txtMinusQTY1.Enabled = false;
                btnAdjust1.Enabled = false;
            }
        }

        private void txtMinusQTY1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtMinusQTY_Leave(object sender, EventArgs e)
        {

        }

        private void txtMinusQTY_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void txtMinusQTY_Click(object sender, EventArgs e)
        {

        }

        private void btnHome1_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;


            if (frm_Login.manager == "Manager")
            {
                Cursor.Current = Cursors.AppStarting;
                var myForm = new frm_MainHomeManager(manager);
                myForm.Show();
                this.Hide();
            }
            else if (frm_Login.supervisor == "Supervisor")
            {
                Cursor.Current = Cursors.AppStarting;
                var myForm = new frm_POS();
                myForm.Show();
                this.Hide();
            }

            else
            {
                //Cursor.Current = Cursors.AppStarting;
                //var myForm = new frm_Inventory();
                //myForm.Show();
                //this.Hide();
            }
        }

        private void btntransactions_Click(object sender, EventArgs e)
        {
            if (frm_Login.stockman == "Stockman")
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

        private void btnsalereports_Click(object sender, EventArgs e)
        {

            if (frm_Login.supervisor == "Supervisor")
            {
                Cursor.Current = Cursors.AppStarting;
                var myForm1 = new frm_LoginHistory();
                myForm1.Show();
                this.Hide();
            }
            else if (frm_Login.stockman == "Stockman")
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
                        var myForm1 = new frm_Login();
                        myForm1.Show();
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
            else
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
        }

        private void button6_Click(object sender, EventArgs e)
        {

            if (frm_Login.supervisor == "Supervisor")
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
                        var myForm1 = new frm_Login();
                        myForm1.Show();
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
            else
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
        }

        private void btnmanageaccounts_Click(object sender, EventArgs e)
        {


            if (frm_Login.manager == "Manager")
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
                var myForm = new frm_AccountStaff();
                myForm.Show();
                pleaseWait.Hide();

                this.Hide();
            }
        }

        private void btnloginhistory1_Click(object sender, EventArgs e)
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

        private void btnLogout1_Click(object sender, EventArgs e)
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

        private void metrorefresh_Click(object sender, EventArgs e)
        {
            hideNotifyPanel();
            lblstatusExpiry.Text = "";
            chartForecast.Visible = false;
            metroGrid4.Visible = false;
            subshowcolumn();
            txtReason.Enabled = true;
            txtMinusQTY.Enabled = true;
            txtMinusQTY.Enabled = false;
            txtMinusQTY.Text = "0";
            DGVInventoryProductList();
            txtReason.Enabled = true;
            btnNewStore.Location = new Point(557, 542);
            txtCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            btnNew.Enabled = true;
            btnNew.BackColor = System.Drawing.ColorTranslator.FromHtml("#24262F");
            label19.Visible = true;
            label18.Visible = true;
            dProduction.Visible = true;
            dExpiry.Visible = true;

            txtReason.SelectedIndex = -1;
            if (txtReason.SelectedIndex == -1)
            {
                txtMinusQTY.Enabled = false;
            }

            if (frm_Login.stockman == "Stockman")
            {
                groupBox1.Visible = true;
                btnSave1.Visible = false;

            }

            changeRowColor();
            changeRowColor1();
            changeRowColor2();

            NotifyBranch();
            NotifyCritical();
            NotifyExpiry();
            subNotifyBranch();
            zeronotify();


            txtReason.Items.Remove("Expired");

            if (frm_Login.manager == "Manager")
            {
                btnupdatedeliver.Visible = true;
                btnconfig.Visible = true;
            }
            dataGridView1.Columns[5].Visible = false;

            btnCritical.TextAlign = ContentAlignment.MiddleLeft;
            btnCritical.Text = "       Critical Level " + "(" + criticalqty + ")";

            btnExpiration.TextAlign = ContentAlignment.MiddleLeft;
            btnExpiration.Text = "       Expiration " + "(" + expiryqty + ")";


            btnNP.TextAlign = ContentAlignment.MiddleLeft;
            btnNP.Text = "       New Products " + "(" + qtynew + ")";

            btnCL.TextAlign = ContentAlignment.MiddleLeft;
            btnCL.Text = "       Requests " + "(" + qtycritical1 + ")";


            btnBO.TextAlign = ContentAlignment.MiddleLeft;
            btnBO.Text = "       Backorder " + "(" + qtybackorder + ")";

            int notifyadd = criticalqty + expiryqty;

            int notifyaddbranch = qtycritical1 + qtybackorder;

            lblbranchqty.Text = notifyaddbranch.ToString();

            lblqtycritical.Text = notifyadd.ToString();


        }

        private void lblCritical_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btninventory1_Click(object sender, EventArgs e)
        {
            //if (frm_Login.stockman == "Stockman")
            //{
            //    var pleaseWait = new frm_PleaseWait();
            //    pleaseWait.Show();
            //    Application.DoEvents();
            //    Cursor.Current = Cursors.WaitCursor;
            //    var myForm = new frm_LoginHistory();
            //    myForm.Show();
            //    pleaseWait.Hide();

            //    this.Hide();
            //}
        }

        private void pCritical2_Click(object sender, EventArgs e)
        {
            metroGrid4.Visible = false;

            pArrow2.Visible = false;
            panelNotifyBranch.Visible = false;
            chartForecast.Visible = false;

            btnOpenNotify.Visible = false;
            lblbranchqty.Visible = true;
            btnBranchNotify.Visible = true;


            if (panelNotification.Visible == false)
            {
                pArrow.Visible = true;
                panelNotification.Visible = true;
                lblqtycritical.Visible = false;
                pictureBox1.Visible = true;

                zeronotify();
                subzeronotify();

                if (frm_Login.stockman == "Stockman")
                {
                    lblbranchqty.Visible = false;
                    btnBranchNotify.Visible = false;



                }

            }
            else
            {

                pArrow.Visible = false;
                panelNotification.Visible = false;
                lblqtycritical.Visible = true;
                pictureBox1.Visible = false;


            }


        }

        private void pCritical2_DoubleClick(object sender, EventArgs e)
        {

        }

        private void pCritical1_MouseHover(object sender, EventArgs e)
        {
            pCritical1.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5E5E5");
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

            pArrow.Visible = false;
            panelNotification.Visible = false;
            lblqtycritical.Visible = true;
            pictureBox1.Visible = false;

            zeronotify();

            if (frm_Login.stockman == "Stockman")
            {
                lblbranchqty.Visible = false;
                btnBranchNotify.Visible = false;



            }
        }

        private void btnRequest1_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.AppStarting;
            var myForm = new frm_Request();
            myForm.ShowDialog();
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



                    if (ID == 2)
                    {
                        lblNPend.Text = myReader.GetString("S_Notify");
                    }

                    if (ID == 3)
                    {
                        lblNOrders.Text = myReader.GetString("S_Notify");
                    }
                    if (ID == 4)
                    {
                        lblNR.Text = myReader.GetString("S_Notify");
                    }

                    if (ID == 5)
                    {
                        lblbackorder.Text = myReader.GetString("S_Notify");
                    }

                    if (int.Parse(lblNOrders.Text) == 0)
                    {
                        lblNOrders.Visible = false;
                    }
                    else
                    {
                        lblNOrders.Visible = true;
                    }
                    if (int.Parse(lblNPend.Text) == 0)
                    {
                        lblNPend.Visible = false;
                    }
                    else
                    {
                        lblNPend.Visible = true;
                    }
                    if (int.Parse(lblNR.Text) == 0)
                    {
                        lblNR.Visible = false;
                    }
                    else
                    {
                        lblNR.Visible = true;
                    }

                    if (int.Parse(lblbackorder.Text) == 0)
                    {
                        lblbackorder.Visible = false;
                    }
                    else
                    {
                      
                    }
                    if (frm_Login.stockman == "Stockman")
                    {


                        if (int.Parse(lblbackorder.Text) == 0)
                        {
                            lblbackorder.Visible = false;
                        }
                        else
                        {
                            lblbackorder.Visible = true;
                        }

                    }
                }
                Conn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error2");
            }
        }

        public void NotifyBranch()
        {

            MySqlConnection Conn = ConString.Connection;

            string Query = "Select sum(C_New_Branch)  as C_New_Branch1 from ((SELECT *  FROM ( Select '1' as ID, count(*) as C_New_Branch from (SELECT count(tbl_store.store_id)  from tbl_inventory inner join tbl_store on tbl_store.store_id = tbl_inventory.store_id where tbl_inventory.r_status  = 'Requested' group by tbl_inventory.r_status, tbl_inventory.product_id, tbl_store.store_name order by count(tbl_store.store_name)) as DerivedTableAlias) AS A) UNION  (SELECT * FROM ( Select '2' as ID, count(*) as C_New_Branch from (SELECT count(tbl_store.store_id)  from tbl_inventory inner join tbl_store on tbl_store.store_id = tbl_inventory.store_id where tbl_inventory.status  = 'New Produc' group by tbl_store.store_name order by count(tbl_store.store_name)) as DerivedTableAlias) AS B) UNION (SELECT * FROM ( Select '3' as ID, count(*) as C_New_Branch from (SELECT count(tbl_store.store_id)  from tbl_inventory inner join tbl_store on tbl_store.store_id = tbl_inventory.store_id where tbl_inventory.s_replacement  = 'Replacement' group by tbl_inventory.s_replacement, tbl_inventory.product_id, tbl_store.store_name order by count(tbl_store.store_name)) as DerivedTableAlias) AS C)) as subAlias";
            MySqlCommand cmd = new MySqlCommand(Query, Conn);
            MySqlDataReader myReader;


            try
            {

                myReader = cmd.ExecuteReader();

                while (myReader.Read())
                {



                    lblbranchqty.Text = myReader.GetString("C_New_Branch1");



                }
                Conn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error2");
            }
        }
        public void NotifyCritical()
        {

            MySqlConnection Conn = ConString.Connection;

            string Query = "(SELECT *  FROM (   Select '1' as ID, count(*)  as Critical_All from (SELECT count(tbl_product.product_id)  from tbl_product where tbl_product.stock <= tbl_product.critical and tbl_product.critical !=0 group by tbl_product.product_id order by count(tbl_product.product_id)) as DerivedTableAlias) AS A)";
            MySqlCommand cmd = new MySqlCommand(Query, Conn);
            MySqlDataReader myReader;


            try
            {

                myReader = cmd.ExecuteReader();

                while (myReader.Read())
                {

                    criticalqty = myReader.GetInt32("Critical_All");


                }
                Conn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error2");
            }
        }



        public void NotifyExpiry()
        {

            MySqlConnection Conn = ConString.Connection;

            string Query = "(SELECT *  FROM ( Select '2' as ID, count(*) as Expiry from (SELECT count(tbl_expiry.product_id), count(tbl_expiry.date_expiry) FROM tbl_expiry inner join tbl_product on tbl_expiry.product_id = tbl_product.product_id where datediff( tbl_expiry.date_expiry, date(now())) <= tbl_product.notify_days and tbl_expiry.status != 'Removed' and tbl_expiry.date_expiry <= date(now()) and tbl_expiry.status = 'Expired' or  datediff( tbl_expiry.date_expiry, date(now())) < tbl_product.notify_days and tbl_expiry.status != 'Removed' and tbl_expiry.date_expiry > date(now()) and tbl_expiry.status = 'Soon to Expire' group by tbl_expiry.product_id, tbl_expiry.date_expiry order by count(tbl_expiry.product_id), count(tbl_expiry.date_expiry)) as DerivedTableAlias) AS B)";
            MySqlCommand cmd = new MySqlCommand(Query, Conn);
            MySqlDataReader myReader;


            try
            {

                myReader = cmd.ExecuteReader();

                while (myReader.Read())
                {

                    expiryqty = myReader.GetInt32("Expiry");


                }
                Conn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error2");
            }
        }

        public void subNotifyBranch()
        {

            MySqlConnection Conn = ConString.Connection;

            string Query = "(SELECT *  FROM ( Select '1' as ID, count(*) as C_New_Branch1 from (SELECT count(tbl_store.store_id)  from tbl_inventory inner join tbl_store on tbl_store.store_id = tbl_inventory.store_id where tbl_inventory.r_status  = 'Requested' group by tbl_store.store_name, tbl_inventory.r_status, tbl_inventory.product_id order by count(tbl_store.store_name)) as DerivedTableAlias) AS A) UNION  (SELECT * FROM ( Select '2' as ID, count(*) as C_New_Branch from (SELECT count(tbl_store.store_id)  from tbl_inventory inner join tbl_store on tbl_store.store_id = tbl_inventory.store_id where tbl_inventory.status  = 'New Product' group by tbl_store.store_name order by count(tbl_store.store_name)) as DerivedTableAlias) AS B) UNION (SELECT * FROM ( Select '3' as ID, count(*) as C_New_Branch from (SELECT count(tbl_store.store_id)  from tbl_inventory inner join tbl_store on tbl_store.store_id = tbl_inventory.store_id where tbl_inventory.s_replacement  = 'Replacement' group by tbl_inventory.s_replacement, tbl_inventory.product_id, tbl_store.store_name order by count(tbl_store.store_name)) as DerivedTableAlias) AS C)";
            MySqlCommand cmd = new MySqlCommand(Query, Conn);
            MySqlDataReader myReader;


            try
            {

                myReader = cmd.ExecuteReader();

                while (myReader.Read())
                {





                    ID = myReader.GetInt32("ID");

                    if (ID == 1)
                    {
                        qtycritical1 = myReader.GetInt32("C_New_Branch1");
                    }

                    if (ID == 2)
                    {
                        qtynew = myReader.GetInt32("C_New_Branch1");
                    }

                    if (ID == 3)
                    {
                        qtybackorder = myReader.GetInt32("C_New_Branch1");
                    }




                }
                Conn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error2");
            }
        }

        private void button6_Click_1(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Cursor.Current = Cursors.AppStarting;
            var myForm = new frm_Request();
            myForm.ShowDialog();
            hideRQ();
            showRQ();

            lblbranchqty.Visible = false;
            lblqtycritical.Visible = false;
            //   SearchingOK();
            DGVstoreOK();
            datenotEqual();

            RemoveListCritical();//
            AreaCriticalLevel();//
            DGVInventoryProductList();
            changeRowColor1();

            NotifyBranch();
            NotifyCritical();
            NotifyExpiry();
            subNotifyBranch();

            zeronotify();
            lblbranchqty.Visible = false;

            btnCritical.TextAlign = ContentAlignment.MiddleLeft;
            btnCritical.Text = "       Critical Level " + "(" + criticalqty + ")";

            btnExpiration.TextAlign = ContentAlignment.MiddleLeft;
            btnExpiration.Text = "       Expiration " + "(" + expiryqty + ")";


            btnNP.TextAlign = ContentAlignment.MiddleLeft;
            btnNP.Text = "       New Products " + "(" + qtynew + ")";

            btnCL.TextAlign = ContentAlignment.MiddleLeft;
            btnCL.Text = "       Requests " + "(" + qtycritical1 + ")";


            btnBO.TextAlign = ContentAlignment.MiddleLeft;
            btnBO.Text = "       Backorder " + "(" + qtybackorder + ")";

            int notifyadd = criticalqty + expiryqty;

            int notifyaddbranch = qtycritical1 + qtybackorder;

            lblbranchqty.Text = notifyaddbranch.ToString();

            lblqtycritical.Text = notifyadd.ToString();
            btnSave1.Enabled = false;
            btnSave1.BackColor = Color.DarkGray;
        }

        private void btnOpenNotify_Click(object sender, EventArgs e)
        {
            panelNotifyBranch.Visible = false;
            pArrow2.Visible = false;
            btnOpenNotify.Visible = false;
            btnBranchNotify.Visible = true;
            lblbranchqty.Visible = true;

            zeronotify();
        }

        private void pCritical1_MouseLeave(object sender, EventArgs e)
        {
            pCritical1.BackColor = Color.White;
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5E5E5");
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            hideNotifyPanel();
        }

        private void btnCritical_Click(object sender, EventArgs e)
        {
            MySqlConnection Conn = ConString.Connection;
            DataTable dt = new DataTable();

            MySqlDataAdapter sda = new MySqlDataAdapter("SELECT tbl_product.product_id as 'Product ID', tbl_product.product_name as 'Product Name', tbl_product.remarks as 'Price Remarks', tbl_product.stock as 'Stock', tbl_product.Category as 'Category', tbl_supplierinfo.company as 'Supplier Name', tbl_product.date_added as 'Date Added', tbl_product.date_updated as 'Date Received', tbl_product.critical as 'Critical Level', tbl_product.description, tbl_product.reason, tbl_product.production_date as 'Production Date', tbl_product.expiry_date as 'Expiration Date', tbl_product.product_price as 'Original Price', tbl_product.imageLocation as 'Image', ss as 'Safety Stock', rp as 'Reorder Point', sqty as 'Maximum Level of Stock', floor((tbl_product.sqty + tbl_product.rp + tbl_product.ss + tbl_product.critical)/4)  as 'Suggested QTY',  status_new as 'Status' FROM tbl_product left join tbl_supplierinfo on tbl_product.supplier_id = tbl_supplierinfo.supplier_id where tbl_product.stock <= tbl_product.critical and tbl_product.critical !=0 group by tbl_product.product_id order by tbl_product.product_id asc", Conn);
            sda.Fill(dt);
            Conn.Close();
            dataGridView1.DataSource = dt;

            hideNotifyPanel();
            changeRowColor();
            changeRowColor1();
            changeRowColor2();
        }

        private void btnExpiration_Click(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            lblstatusExpiry.Text = "Expiry";
            txtReason.Items.Add("Expired");
            txtMinusQTY.Enabled = false;
            expiry();
            changeRowColor4();


            groupBox1.Visible = false;


        }
        void expiry()
        {

            MySqlConnection Conn = ConString.Connection;
            DataTable dt = new DataTable();

            MySqlDataAdapter sda = new MySqlDataAdapter("SELECT tbl_product.product_id as 'Product ID', tbl_product.product_name as 'Product Name', tbl_product.remarks as 'Price Remarks', tbl_product.stock as 'Stock', tbl_product.Category as 'Category', tbl_supplierinfo.company as 'Supplier Name', tbl_product.date_added as 'Date Added', tbl_product.date_updated as 'Date Received', tbl_product.critical as 'Critical', tbl_product.description, tbl_product.reason, tbl_product.production_date as 'Production Date', tbl_product.expiry_date as 'Expiration Date', tbl_product.product_price as 'Original Price', tbl_product.imageLocation as 'Image', ss as 'Safety Stock', status_new as 'Statuss',  sum(tbl_expiry.QTY) as 'QTY',   datediff( tbl_expiry.date_expiry, date(now())) as 'Days Left',  tbl_expiry.date_expiry as 'Expiry Date', tbl_expiry.Status as 'Status' FROM tbl_product left join tbl_supplierinfo on tbl_product.supplier_id = tbl_supplierinfo.supplier_id inner join tbl_expiry on tbl_expiry.product_id = tbl_product.product_id" +
                "  where datediff( tbl_expiry.date_expiry, date(now())) < tbl_product.notify_days and tbl_expiry.status != 'Removed' and tbl_expiry.date_expiry > date(now()) or " +
                "datediff( tbl_expiry.date_expiry, date(now())) <= tbl_product.notify_days and tbl_expiry.status != 'Removed' and tbl_expiry.date_expiry <= date(now()) group by tbl_expiry.product_id, tbl_expiry.date_expiry,  tbl_product.Category, tbl_expiry.status order by tbl_expiry.date_expiry asc", Conn);
            sda.Fill(dt);
            Conn.Close();
            dataGridView1.DataSource = dt;

            hideNotifyPanel();
            changeRowColor();
            changeRowColor1();
            changeRowColor2();
            subhidecolumn();


            txtReason.Text = "Expired";
            txtReason.Enabled = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }
        void subhidecolumn()
        {
            dataGridView1.Columns[0].Visible = false;

            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].Visible = true;
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

        }
        void subshowcolumn()
        {
            dataGridView1.Columns[2].Visible = true;

            dataGridView1.Columns[1].Visible = true;
            dataGridView1.Columns[4].Visible = false;

            dataGridView1.Columns[3].Visible = true;

            dataGridView1.Columns[8].Visible = true;
            dataGridView1.Columns[15].Visible = true;
            dataGridView1.Columns[16].Visible = true;

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {

                int rowIndex = metroGrid2.FirstDisplayedScrollingRowIndex;



                metroGrid2.FirstDisplayedScrollingRowIndex = rowIndex - 1;
            }
            catch (Exception)
            {

            }
            changeRowColor();
            changeRowColor1();
            changeRowColor2();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            metroGrid2.FirstDisplayedScrollingRowIndex = metroGrid2.RowCount - 1;
            changeRowColor();
            changeRowColor1();
            changeRowColor2();
        }

        private void button6_Click_2(object sender, EventArgs e)
        {
            this.metroGrid2.Sort(this.metroGrid2.Columns["Product Name"], ListSortDirection.Ascending);
            changeRowColor();
            changeRowColor1();
            changeRowColor2();
        }

        private void txtSearch1_Click(object sender, EventArgs e)
        {
            if (txtSearch1.Text == "Search")
            {
                txtSearch1.Focus();
                txtSearch1.Select(0, 0);

            }
        }

        private void txtSearch1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtSearch1.Text == "Search")
            {
                txtSearch1.Text = "";
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

        private void txtSearch1_Leave(object sender, EventArgs e)
        {
            if (txtSearch1.Text.Length == 0)
            {
                txtSearch1.Text = "Search";
                txtSearch1.ForeColor = SystemColors.GrayText;
            }
        }

        private void txtSearch1_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch1.Text.Contains(@"\"))
            {
                return;



            }
            try
            {



                MySqlConnection Conn = ConString.Connection;
                DataTable dt = new DataTable();

                MySqlDataAdapter sda = new MySqlDataAdapter("SELECT tbl_inventory.product_id as 'Product ID', tbl_product.product_name as 'Product Name', tbl_inventory.QTY as 'QTY', tbl_product.remarks as 'Price', tbl_inventory.status_pending as 'S', tbl_inventory.oq as 'Average Daily Sales', tbl_inventory.critical as 'Critical Level', tbl_inventory.ss as 'Safety Stock', tbl_inventory.rp as 'Reorder Point', tbl_inventory.maxqty as 'Maximum Stock Level', tbl_inventory.status as 'Status' FROM tbl_inventory inner join tbl_product on tbl_inventory.product_id = tbl_product.product_id inner join tbl_store on tbl_inventory.store_id = tbl_store.store_id where tbl_inventory.store_id = '" + frm_Login.global_storeid + "' and tbl_product.product_name like '%" + txtSearch1.Text + "%' group by tbl_inventory.product_id;", Conn);
                sda.Fill(dt);
                Conn.Close();
                metroGrid2.DataSource = dt;
                changeRowColor1();
                if (txtSearch1.Text == "Search")
                {
                    changeRowColor1();
                    DGVstoredisplayproduct();

                    lblMatch1.Hide();
                    pictureBox3.Visible = true;
                    changeRowColor();
                    changeRowColor1();
                    changeRowColor2();
                }

                hideColumn();
                changeRowColor1();
                changeRowColor();
                changeRowColor1();
                changeRowColor2();
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                if (!metroGrid2.Rows[metroGrid2.CurrentCell.RowIndex].IsNewRow)
                {
                    foreach (DataGridViewCell cell in metroGrid2.Rows[metroGrid2.CurrentCell.RowIndex].Cells)
                    {
                        lblMatch1.Hide();

                        if (cell.Value == System.DBNull.Value)
                        {

                        }
                    }


                }
            }
            catch (NullReferenceException)
            {
                lblMatch1.Show();

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

        private void panelNotifyBranch_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnN_Click(object sender, EventArgs e)
        {

            MySqlConnection Conn = ConString.Connection;
            DataTable dt = new DataTable();

            MySqlDataAdapter sda = new MySqlDataAdapter("SELECT tbl_inventory.product_id as 'Product ID', tbl_product.product_name as 'Product Name', tbl_inventory.QTY as 'QTY', tbl_product.remarks as 'Price', tbl_inventory.status_pending as 'S', tbl_inventory.oq as 'Average Daily Sales', tbl_inventory.critical as 'Critical Level', tbl_inventory.ss as 'Safety Stock', tbl_inventory.rp as 'Reorder Point', tbl_inventory.maxqty as 'Maximum Stock Level', tbl_inventory.status as 'Status' FROM tbl_inventory inner join tbl_product on tbl_inventory.product_id = tbl_product.product_id inner join tbl_store on tbl_inventory.store_id = tbl_store.store_id where tbl_inventory.store_id = '" + frm_Login.global_storeid + "' and tbl_inventory.status = 'New Product' group by tbl_inventory.product_id;", Conn);
            sda.Fill(dt);
            Conn.Close();
            metroGrid2.DataSource = dt;
            changeRowColor1();
            changeRowColor();
            changeRowColor1();
            changeRowColor2();

        }

        private void btnCR_Click(object sender, EventArgs e)
        {

            MySqlConnection Conn = ConString.Connection;
            DataTable dt = new DataTable();

            MySqlDataAdapter sda = new MySqlDataAdapter("SELECT tbl_inventory.product_id as 'Product ID', tbl_product.product_name as 'Product Name', tbl_inventory.QTY as 'QTY', tbl_product.remarks as 'Price', tbl_inventory.status_pending as 'S', tbl_inventory.oq as 'Average Daily Sales', tbl_inventory.critical as 'Critical Level', tbl_inventory.ss as 'Safety Stock', tbl_inventory.rp as 'Reorder Point', tbl_inventory.maxqty as 'Maximum Stock Level', tbl_inventory.status as 'Status' FROM tbl_inventory inner join tbl_product on tbl_inventory.product_id = tbl_product.product_id inner join tbl_store on tbl_inventory.store_id = tbl_store.store_id where tbl_inventory.store_id = '" + frm_Login.global_storeid + "' and tbl_inventory.qty  <= tbl_inventory.critical group by tbl_inventory.product_id;", Conn);
            sda.Fill(dt);
            Conn.Close();
            metroGrid2.DataSource = dt;
            changeRowColor1();
            changeRowColor();
            changeRowColor1();
            changeRowColor2();
        }

        private void btnPending_Click(object sender, EventArgs e)
        {

            MySqlConnection Conn = ConString.Connection;
            DataTable dt = new DataTable();

            MySqlDataAdapter sda = new MySqlDataAdapter("SELECT tbl_inventory.product_id as 'Product ID', tbl_product.product_name as 'Product Name', tbl_inventory.QTY as 'QTY', tbl_product.remarks as 'Price', tbl_inventory.status_pending as 'S', tbl_inventory.oq as 'Average Daily Sales', tbl_inventory.critical as 'Critical Level', tbl_inventory.ss as 'Safety Stock', tbl_inventory.rp as 'Reorder Point', tbl_inventory.maxqty as 'Maximum Stock Level', tbl_inventory.status as 'Status' FROM tbl_inventory inner join tbl_product on tbl_inventory.product_id = tbl_product.product_id inner join tbl_store on tbl_inventory.store_id = tbl_store.store_id where tbl_inventory.store_id = '" + frm_Login.global_storeid + "' and tbl_inventory.status = 'Pending' group by tbl_inventory.product_id;", Conn);
            sda.Fill(dt);
            Conn.Close();
            metroGrid2.DataSource = dt;
            changeRowColor1();
            changeRowColor();
            changeRowColor1();
            changeRowColor2();

        }

        private void btnSP_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage4;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DGVstoredisplayproduct();
            ByNotifyBranch();
        }

        private void txtReason_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSave1.Enabled = false;
            btnSave1.BackColor = Color.DarkGray;
            label10.Text = "";
            if (txtReason.Text != "Expired")
            {


                txtMinusQTY.Enabled = true;
            }
            if (txtReason.Text == reason || txtReason.Text == "")
            {
                btnSave1.Enabled = false;
                btnSave1.BackColor = Color.DarkGray;
            }
            if (btnAddProduct.Enabled == true)
            {
                btnSave1.Enabled = false;
                btnSave1.BackColor = Color.DarkGray;
            }


        }

        private void txtMinusQTY1_TextChanged(object sender, EventArgs e)
        {
            btnAdjust1.Enabled = true;
        }

        private void txtReason1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtMinusQTY1.Enabled = true;
        }

        private void txtCategory_DrawItem(object sender, DrawItemEventArgs e)
        {

        }

        private void txtMinusQTY_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void label26_Click(object sender, EventArgs e)
        {
            DateTime date1 = DateTime.Now;
            DateTime date2 = subdate.Value;

            TimeSpan difference = date2.Subtract(date1);

            if (Expiry.Value < date2)
            {

                btnRestock.Enabled = false;
                btnRestock.BackColor = Color.DarkGray;

                MessageBox.Show("The date doesn't look right. Be sure to use the actual expiry date.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                btnRestock.Enabled = true;
                btnRestock.BackColor = System.Drawing.ColorTranslator.FromHtml("#24262F");

            }
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        void ReceiveFirst()
        {
            MySqlConnection Conn = ConString.Connection;


            string Query = "select* from tbl_order where product_id = '" + mProduct_ID + "' and supplier_id = '" + mSupplier_ID + "' and status = 'Received' and quantity_receive != 0 and date_expected = '" + dateExpected.Text + "' and date_ordered = '" + date_ordered.Text + "'";
            MySqlCommand cmd = new MySqlCommand(Query, Conn);
            MySqlDataReader myReader;

            try
            {

                myReader = cmd.ExecuteReader();

                while (myReader.Read())
                {

                    receivefirst = myReader.GetString("status");

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }




            Conn.Close();

        }

        void BackorderFirst()
        {
            MySqlConnection Conn = ConString.Connection;


            string Query = "select* from tbl_order where product_id = '" + mProduct_ID + "' and supplier_id = '" + mSupplier_ID + "' and subStatus1 = 'Uncheck' " +
                "and date_expected = '" + dateExpected.Text + "' and date_ordered = '" + date_ordered.Text + "' and subStatus1 != 'Checked'";
            MySqlCommand cmd = new MySqlCommand(Query, Conn);
            MySqlDataReader myReader;

            try
            {

                myReader = cmd.ExecuteReader();

                while (myReader.Read())
                {

                    uncheck = myReader.GetString("subStatus1");

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }




            Conn.Close();

        }

        void getCategoryforNotify()
        {
            MySqlConnection Conn = ConString.Connection;

            string Query = "select* from tbl_order where category = '" + mCategory + "';";
            MySqlCommand cmd = new MySqlCommand(Query, Conn);
            MySqlDataReader myReader;

            try
            {

                myReader = cmd.ExecuteReader();

                while (myReader.Read())
                {

                    gCategory = myReader.GetString("notify_days");

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }




            Conn.Close();

        }

        private void dataGridView2_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                //if (date_ordered != date_expect)
                //{
                //  //  MessageBox.Show("The product: '" + productname + "' will be delivered: " + txtHours.Text + (" hour(s) left in ") + dateExpected.Text, "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //  label24.Text = "The product: '" + productname + "' will be delivered: " + txtHours.Text + (" hour(s) left in ") + dateExpected.Text;
                //    return;
                //}

                if (!(txtSubdays.Text == "") && lblStatus.Text != "Overdue Ordered" && txtSubdays.Text != "0" || lblStatus.Text == "Pending Ordered" && lblStatus.Text != "Overdue Ordered" && txtSubdays.Text != "0")
                {
                    //MessageBox.Show("The product: '" +productname + "' will be delivered: " +txtSubdays.Text +(" day(s) and ") +txtHours.Text+(" hour(s) left in ") + dateExpected.Text, "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lbldeliver.Text = "The product: '" + productname + "' will be delivered: " + txtSubdays.Text + (" day(s) left in ") + dateExpected.Text;
                    return;
                }


                if (dataGridView2.Rows.Count > 0)
                {
                    orderid = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells[0].Value.ToString());
                    mSupplier_ID = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells[12].Value.ToString());
                    mProduct_ID = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells[10].Value.ToString());
                    subOrderID = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells[0].Value.ToString());

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

                    label44.Text = productid.ToString();
                    label45.Text = statusss;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }




                Conn.Close();

                mDateExpected = dateExpected.Text;
                mDateOrdered = date_ordered.Text;
                ReceiveFirst();
                BackorderFirst();
                //  label26.Text = uncheck.ToString();
                if (orderstatusss == "Received")
                {
                    lbldeliver.Text = "";
                    receivefirst = "";
                    //  MessageBox.Show("Product(s) is/are already inspected", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);


                }
                else if (uncheck == "Uncheck" && lblStatus.Text == "Backorder" && uncheck != "Checked")
                {
                    MessageBox.Show("Please wait checking for this backorder product: " + txtProductName.Text, "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    receivefirst = "";
                    uncheck = "";


                }

                else if (lblStatus.Text == "Backorder" && receivefirst == "Received" || lblStatus.Text == "Ordered" && receivefirst == "Received")
                {
                    MessageBox.Show("Received first of product name: " + txtProductName.Text, "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    receivefirst = "";
                }


                else
                {


                    Inspection cq = new Inspection();
                    cq.ShowDialog();

                    DGVReceivedProductList();
                    ByNotifyWarehouse();
                    receivefirst = "";
                }
            }
            catch (Exception)
            {

            }
        }

        private void date_ordered_ValueChanged(object sender, EventArgs e)
        {
            DateTime date1 = dateTimePicker1.Value;
            DateTime date2 = dateExpected.Value;

            TimeSpan difference = date2 - date1;
            txtDays.Text = difference.TotalDays.ToString();
            txtSubdays.Text = difference.TotalDays.ToString();
            //    txtHours.Text = difference.TotalHours.ToString();
            txtMinutes.Text = difference.TotalMinutes.ToString();
            txtSeconds.Text = difference.TotalSeconds.ToString();
            txtMilliseconds.Text = difference.TotalMilliseconds.ToString();
        }

        private void dateExpected_ValueChanged_1(object sender, EventArgs e)
        {
            DateTime startdate = dateTimePicker1.Value;
            DateTime enddate = dateExpected.Value;
            txtSubdays.Text = Days1(startdate, enddate).ToString();



            DateTime date1 = dateTimePicker1.Value;
            DateTime date2 = dateExpected.Value;

            TimeSpan difference = date2.Subtract(date1);

            //   txtSubdays.Text = (dateExpected.Value - DateTime.Today).TotalDays.ToString("#");

            if (dateTimePicker1.Text == dateExpected.Text)
            {
                txtSubdays.Text = "0";
            }

            if ((date2 < date1 && dateTimePicker1.Text != dateExpected.Text))
            {
                //  MessageBox.Show("The date doesn't look right. Be sure to use the actual date.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //  dateExpected.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
            //if (txtHours.Text.Contains("-"))
            //{
            //    txtHours.Text = "0";
            //}
            if (txtSubdays.Text == "1")
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

        private void btnRefresh1_Click(object sender, EventArgs e)
        {
            DGVReceivedProductList();
            ByNotifyWarehouse();


        }

        private void btnReceive1_Click(object sender, EventArgs e)
        {
            MySqlConnection Conn = ConString.Connection;
            DataTable dt = new DataTable();

            MySqlDataAdapter sda = new MySqlDataAdapter(" SELECT tbl_order.order_id as 'Order ID', tbl_product.product_name as 'Product', tbl_order.status as 'Status', sum(tbl_order.total_due) as 'Total Due', sum(tbl_order.quantity) as 'Ordered QTY', tbl_order.quantity_receive as 'QTY Received', tbl_order.damage_product as 'Backorder QTY', tbl_supplierinfo.company as 'Supplier Name' ,tbl_order.date_ordered as 'Date Ordered', tbl_order.date_expected as 'Delivery Date', tbl_product.product_id as 'Product ID', tbl_product.stock as 'Stock', tbl_order.supplier_id as 'Supplier ID', tbl_order.subStatus1 as 'S', timestampdiff(day, date(now()), date_expected) as 'Days Left'  FROM tbl_order inner join tbl_product on tbl_order.product_id = tbl_product.product_id inner join tbl_supplierinfo on tbl_order.supplier_id = tbl_supplierinfo.supplier_id  where tbl_order.status = 'Received' " +
                "group by tbl_order.product_id, tbl_order.supplier_id, tbl_order.status, tbl_order.date_expected, tbl_order.date_ordered order by tbl_order.order_id desc;", Conn);
            sda.Fill(dt);
            Conn.Close();
            dataGridView2.DataSource = dt;

            changeRowColor3();
            if (int.Parse(lblNR.Text) == 0)
            {
                DGVReceivedProductList();
            }
        }

        private void btnPending1_Click(object sender, EventArgs e)
        {
            MySqlConnection Conn = ConString.Connection;
            DataTable dt = new DataTable();

            MySqlDataAdapter sda = new MySqlDataAdapter("SELECT tbl_order.order_id as 'Order ID', tbl_product.product_name as 'Product', tbl_order.status as 'Status', sum(tbl_order.total_due) as 'Total Due', sum(tbl_order.quantity) as 'Ordered QTY', tbl_order.quantity_receive as 'QTY Received', tbl_order.damage_product as 'Backorder QTY', tbl_supplierinfo.company as 'Supplier Name' ,tbl_order.date_ordered as 'Date Ordered', tbl_order.date_expected as 'Delivery Date', tbl_product.product_id as 'Product ID', tbl_product.stock as 'Stock', tbl_order.supplier_id as 'Supplier ID', tbl_order.subStatus1 as 'S', timestampdiff(day, date(now()), date_expected) as 'Days Left'  FROM tbl_order inner join tbl_product on tbl_order.product_id = tbl_product.product_id inner join tbl_supplierinfo on tbl_order.supplier_id = tbl_supplierinfo.supplier_id  where tbl_order.status = 'Pending Ordered' " +
                "group by tbl_order.product_id, tbl_order.supplier_id, tbl_order.status, tbl_order.date_expected, tbl_order.date_ordered order by tbl_order.order_id desc;", Conn);
            sda.Fill(dt);
            Conn.Close();
            dataGridView2.DataSource = dt;
            changeRowColor3();
            if (int.Parse(lblNPend.Text) == 0)
            {
                DGVReceivedProductList();
            }
        }

        private void btnOrder1_Click(object sender, EventArgs e)
        {
            MySqlConnection Conn = ConString.Connection;
            DataTable dt = new DataTable();

            MySqlDataAdapter sda = new MySqlDataAdapter("SELECT tbl_order.order_id as 'Order ID', tbl_product.product_name as 'Product', tbl_order.status as 'Status', sum(tbl_order.total_due) as 'Total Due', sum(tbl_order.quantity) as 'Ordered QTY', tbl_order.quantity_receive as 'QTY Received', tbl_order.damage_product as 'Backorder QTY', tbl_supplierinfo.company as 'Supplier Name' ,tbl_order.date_ordered as 'Date Ordered', tbl_order.date_expected as 'Delivery Date', tbl_product.product_id as 'Product ID', tbl_product.stock as 'Stock', tbl_order.supplier_id as 'Supplier ID', tbl_order.subStatus1 as 'S', timestampdiff(day, date(now()), date_expected) as 'Days Left'  FROM tbl_order inner join tbl_product on tbl_order.product_id = tbl_product.product_id inner join tbl_supplierinfo on tbl_order.supplier_id = tbl_supplierinfo.supplier_id  where " +
                "tbl_order.status = 'Ordered' and tbl_order.total_due != 0.00 or tbl_order.status = 'Overdue Ordered' and tbl_order.total_due != 0.00 " +
                "group by tbl_order.product_id, tbl_order.supplier_id, tbl_order.status, tbl_order.date_expected, tbl_order.date_ordered order by tbl_order.order_id desc;", Conn);
            sda.Fill(dt);
            Conn.Close();
            dataGridView2.DataSource = dt;
            changeRowColor3();
            if (int.Parse(lblNOrders.Text) == 0)
            {
                DGVReceivedProductList();
            }
        }

        private void txtSearch2_TextChanged(object sender, EventArgs e)
        {
            try
            {


            
                MySqlConnection Conn = ConString.Connection;
                DataTable dt = new DataTable();

                MySqlDataAdapter sda = new MySqlDataAdapter("SELECT tbl_order.order_id as 'Order ID', tbl_product.product_name as 'Product', tbl_order.status as 'Status', sum(tbl_order.total_due) as 'Total Due', sum(tbl_order.quantity) as 'Ordered QTY', tbl_order.quantity_receive as 'QTY Received', tbl_order.damage_product as 'Backorder QTY', tbl_supplierinfo.company as 'Supplier Name' ,tbl_order.date_ordered as 'Date Ordered', tbl_order.date_expected as 'Delivery Date', tbl_product.product_id as 'Product ID', tbl_product.stock as 'Stock', tbl_order.supplier_id as 'Supplier ID', tbl_order.subStatus1 as 'S', timestampdiff(day, date(now()), date_expected) as 'Days Left'  FROM tbl_order inner join tbl_product on tbl_order.product_id = tbl_product.product_id inner join tbl_supplierinfo on tbl_order.supplier_id = tbl_supplierinfo.supplier_id  where " +
                    "tbl_order.total_due != 0.00 and tbl_order.status = 'Ordered' and tbl_product.product_name like '%" + txtSearch2.Text + "%' " +
                    " or tbl_order.total_due != 0.00 and tbl_order.status = 'Overdue Ordered' and tbl_product.product_name like '%" + txtSearch2.Text + "%' " +
                      " or tbl_order.total_due != 0.00 and tbl_order.status = 'Pending Ordered' and tbl_product.product_name like '%" + txtSearch2.Text + "%' " +
                        " or tbl_order.total_due != 0.00 and tbl_order.status = 'Backorder' and tbl_product.product_name like '%" + txtSearch2.Text + "%' " +
                         " or tbl_order.total_due != 0.00 and tbl_order.status = 'Received' and tbl_product.product_name like '%" + txtSearch2.Text + "%' " +
                    "group by tbl_order.product_id, tbl_order.supplier_id, tbl_order.status order by tbl_order.order_id desc;", Conn);
                sda.Fill(dt);
                Conn.Close();
                dataGridView2.DataSource = dt;

                dataGridView2.Columns[10].Visible = false;
                dataGridView2.Columns[11].Visible = false;
                dataGridView2.Columns[12].Visible = false;
                dataGridView2.Columns[13].Visible = false;
                if (txtSearch2.Text == "Search")
                {

                    DGVReceivedProductList();


                    lblNoReceive.Text = "No received product(s). ";
                    lblNoReceive.Hide();
                    dataGridView2.Columns[10].Visible = false;

                    dataGridView2.Columns[11].Visible = false;

                }


                changeRowColor3();
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

                        lblNoReceive.Text = "No received product(s). ";
                        lblNoReceive.Hide();
                        if (cell.Value == System.DBNull.Value)
                        {

                        }
                    }


                }
            }
            catch (NullReferenceException)
            {
                lblNoReceive.Show();
                lblNoReceive.Text = "No results found. ";

            }
            if (txtSearch2.Text.Length <= 0) return;
            string s = txtSearch2.Text.Substring(0, 1);
            if (s != s.ToUpper())
            {
                int curSelStart = txtSearch2.SelectionStart;
                int curSelLength = txtSearch2.SelectionLength;
                txtSearch2.SelectionStart = 0;
                txtSearch2.SelectionLength = 1;
                txtSearch2.SelectedText = s.ToUpper();
                txtSearch2.SelectionStart = curSelStart;
                txtSearch2.SelectionLength = curSelLength;

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

        public void subExpiryDate()
        {

            MySqlConnection con = ConString.Connection;
            DataTable p_table = new DataTable();


            MySqlCommand command1 = new MySqlCommand("SELECT product_name, production_date as 'Production Date', expiry_date FROM tbl_product where expiry_date <= (date_sub(curdate(), interval - 1 month)) and stock != 0", con);

            p_table.Clear();
            MySqlDataAdapter m_da = new MySqlDataAdapter("SELECT product_name, production_date as 'Production Date', expiry_date FROM tbl_product where expiry_date <= (date_sub(curdate(), interval - 1 month)) and stock != 0", con);

            m_da.Fill(p_table);

            MySqlDataReader reader;
            reader = command1.ExecuteReader();

            StringBuilder productNames = new StringBuilder();

            while (reader.Read())
            {
                productNames.Append(reader["product_name"].ToString() + Environment.NewLine);
            }

            for (int i = 0; i < p_table.Rows.Count; i++)
            {
                DataRow drow = p_table.Rows[i];

                if (drow.RowState != DataRowState.Deleted)
                {

                    ListViewItem lvi = new ListViewItem(drow["expiry_date"].ToString());
                    lvi.SubItems.Add(drow["product_name"].ToString());

                    lblqtycritical.Visible = true;
                    pCritical1.Show();
                }



            }
            con.Close();

        }

        private void btnSent_Click(object sender, EventArgs e)
        {
            var myform = new frm_Request();
            myform.ShowDialog();

        }

        private void btnhistorydeliver_Click(object sender, EventArgs e)
        {
            chartForecast.Visible = false;

            if (metroGrid4.Visible == true)
            {
                metroGrid4.Visible = false;
            }
            else
            {
                metroGrid4.Visible = true;
            }

            hideNotifyPanel();
            MySqlConnection Conn = ConString.Connection;


            MySqlCommand cmd = new MySqlCommand("SELECT tbl_product.product_name as 'Product', tbl_critical.quantity as 'Quantity', floor(tbl_critical.leadtime) as 'Leadtime', tbl_critical.date as 'Delivered Date' FROM tbl_critical inner join tbl_product on tbl_product.product_id = tbl_critical.product_id where tbl_product.product_id = '" + txtProductID.Text+"'", Conn);
            cmd.CommandTimeout = 0;

            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmd;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bSource = new BindingSource();

                bSource.DataSource = dbdataset;
                metroGrid4.DataSource = bSource;
                sda.Update(dbdataset);
                metroGrid4.DefaultCellStyle.SelectionBackColor = Color.Pink;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error5");
            }
        }

        private void btnCL_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.AppStarting;
            var myForm = new frm_Request();
            myForm.ShowDialog();
            hideRQ();
            showRQ();

            lblbranchqty.Visible = false;
            lblqtycritical.Visible = false;
            //   SearchingOK();
            DGVstoreOK();
            datenotEqual();

            RemoveListCritical();//
            AreaCriticalLevel();//
            DGVInventoryProductList();
            changeRowColor1();

            NotifyBranch();
            NotifyCritical();
            NotifyExpiry();
            subNotifyBranch();

            zeronotify();
            lblbranchqty.Visible = false;

            btnCritical.TextAlign = ContentAlignment.MiddleLeft;
            btnCritical.Text = "       Critical Level " + "(" + criticalqty + ")";

            btnExpiration.TextAlign = ContentAlignment.MiddleLeft;
            btnExpiration.Text = "       Expiration " + "(" + expiryqty + ")";


            btnNP.TextAlign = ContentAlignment.MiddleLeft;
            btnNP.Text = "       New Products " + "(" + qtynew + ")";

            btnCL.TextAlign = ContentAlignment.MiddleLeft;
            btnCL.Text = "       Requests " + "(" + qtycritical1 + ")";


            btnBO.TextAlign = ContentAlignment.MiddleLeft;
            btnBO.Text = "       Backorder " + "(" + qtybackorder + ")";

            int notifyadd = criticalqty + expiryqty;

            int notifyaddbranch = qtycritical1 + qtybackorder;

            lblbranchqty.Text = notifyaddbranch.ToString();

            lblqtycritical.Text = notifyadd.ToString();
            btnSave1.Enabled = false;
            btnSave1.BackColor = Color.DarkGray;
        }

        private void btnBO_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.AppStarting;
            var myForm = new frm_Request();
            myForm.ShowDialog();
            hideRQ();
            showRQ();

            lblbranchqty.Visible = false;
            lblqtycritical.Visible = false;
            //   SearchingOK();
            DGVstoreOK();
            datenotEqual();

            RemoveListCritical();//
            AreaCriticalLevel();//
            DGVInventoryProductList();
            changeRowColor1();

            NotifyBranch();
            NotifyCritical();
            NotifyExpiry();
            subNotifyBranch();

            zeronotify();
            lblbranchqty.Visible = false;

            btnCritical.TextAlign = ContentAlignment.MiddleLeft;
            btnCritical.Text = "       Critical Level " + "(" + criticalqty + ")";

            btnExpiration.TextAlign = ContentAlignment.MiddleLeft;
            btnExpiration.Text = "       Expiration " + "(" + expiryqty + ")";


            btnNP.TextAlign = ContentAlignment.MiddleLeft;
            btnNP.Text = "       New Products " + "(" + qtynew + ")";

            btnCL.TextAlign = ContentAlignment.MiddleLeft;
            btnCL.Text = "       Requests " + "(" + qtycritical1 + ")";


            btnBO.TextAlign = ContentAlignment.MiddleLeft;
            btnBO.Text = "       Backorder " + "(" + qtybackorder + ")";

            int notifyadd = criticalqty + expiryqty;
            int notifyaddbranch = qtycritical1 + qtybackorder;

            lblbranchqty.Text = notifyaddbranch.ToString();


            lblqtycritical.Text = notifyadd.ToString();
            btnSave1.Enabled = false;
            btnSave1.BackColor = Color.DarkGray;
        }

        private void label41_Click(object sender, EventArgs e)
        {
            hideNotifyPanel();
        }

        private void btngraph_Click(object sender, EventArgs e)
        {
            metroGrid4.Visible = false;
            //for (int i = 0; i < dataGridView1.Rows.Count; i++)
            //{
            //    if (dataGridView1.Rows[i].Cells[16].Value.ToString().Trim() == "" || dataGridView1.Rows[i].Cells[16].Value == null)
            //    {


            //        return;
            //    }
            //}

            if (subss == "0" || subss == "" || subrp == "0" || subrp == "" || submax == "0" || submax == "")
            {

                return;

            }

                foreach (var series in chartForecast.Series)
            {
                series.Points.Clear();
            }
            ForecasttGraph();
           
            if (chartForecast.Visible == true)
            {
                chartForecast.Visible = false;
            }
            else
            {
                chartForecast.Visible = true;
            }
            hideNotifyPanel();
            
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void btnbackorder_Click(object sender, EventArgs e)
        {
            MySqlConnection Conn = ConString.Connection;
            DataTable dt = new DataTable();

            MySqlDataAdapter sda = new MySqlDataAdapter("SELECT tbl_order.order_id as 'Order ID', tbl_product.product_name as 'Product', tbl_order.status as 'Status', sum(tbl_order.total_due) as 'Total Due', sum(tbl_order.quantity) as 'Ordered QTY', tbl_order.quantity_receive as 'QTY Received', tbl_order.damage_product as 'Backorder QTY', tbl_supplierinfo.company as 'Supplier Name' ,tbl_order.date_ordered as 'Date Ordered', tbl_order.date_expected as 'Delivery Date', tbl_product.product_id as 'Product ID', tbl_product.stock as 'Stock', tbl_order.supplier_id as 'Supplier ID', tbl_order.subStatus1 as 'S', timestampdiff(day, date(now()), date_expected) as 'Days Left'  FROM tbl_order inner join tbl_product on tbl_order.product_id = tbl_product.product_id inner join tbl_supplierinfo on tbl_order.supplier_id = tbl_supplierinfo.supplier_id  where tbl_order.status = 'Backorder' and tbl_order.subStatus1 = 'Uncheck' " +
                "group by tbl_order.product_id, tbl_order.supplier_id, tbl_order.status, tbl_order.date_expected, tbl_order.date_ordered order by tbl_order.order_id desc;", Conn);
            sda.Fill(dt);
            Conn.Close();
            dataGridView2.DataSource = dt;
            changeRowColor3();
            if (int.Parse(lblbackorder.Text) == 0)
            {
                DGVReceivedProductList();
            }
        }
        void ForecasttGraph()
        {
            // titlereport = "Daily Report";
            MySqlConnection Conn = ConString.Connection;
            MySqlCommand cmd = new MySqlCommand("SELECT product_name, critical, ss, rp, sqty, stock  from tbl_product where product_id = '"+txtProductID.Text+"'", Conn);

            try
            {



                MySqlDataReader myReader;

                myReader = cmd.ExecuteReader();

                while (myReader.Read())

                {
                   
                    chartForecast.Series["Forecast Demand"].Points.AddXY("Maximum of Level Stock", myReader.GetInt32("sqty"));
                    chartForecast.Series["Forecast Demand"].Points.AddXY("Reorder Point", myReader.GetInt32("rp"));
                    chartForecast.Series["Forecast Demand"].Points.AddXY("Safety Stock", myReader.GetInt32("ss"));
                    chartForecast.Series["Forecast Demand"].Points.AddXY("Critical Level", myReader.GetInt32("critical"));
                    chartForecast.Series["Forecast Demand"].Points.AddXY("Stock on Hand", myReader.GetInt32("stock"));






                    chartForecast.Series["Forecast Demand"].IsValueShownAsLabel = true;
                    //chartForecast.Series["Forecast Demand"].MarkerSize;
                    //chartForecast.Series["Forecast Demand"].MarkerStyle= true;

                    chartForecast.Series["Forecast Demand"].XValueMember = "Maximum of Level Stock";
                    chartForecast.Series["Forecast Demand"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;

                    chartForecast.Series["Forecast Demand"].YValueMembers = myReader.GetString("sqty");
                    chartForecast.Series["Forecast Demand"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;

                    chartForecast.Series["Forecast Demand"].XValueMember = "Reorder Point";
                    chartForecast.Series["Forecast Demand"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;

                    chartForecast.Series["Forecast Demand"].YValueMembers = myReader.GetString("rp");
                    chartForecast.Series["Forecast Demand"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;

                    chartForecast.Series["Forecast Demand"].XValueMember = "Safety Stock";
                    chartForecast.Series["Forecast Demand"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;

                    chartForecast.Series["Forecast Demand"].YValueMembers = myReader.GetString("ss");
                    chartForecast.Series["Forecast Demand"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;

                    chartForecast.Series["Forecast Demand"].XValueMember = "Critical Level";
                    chartForecast.Series["Forecast Demand"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;

                    chartForecast.Series["Forecast Demand"].XValueMember = "Critical Level";
            

                    chartForecast.Series["Forecast Demand"].YValueMembers = myReader.GetString("critical");
                    chartForecast.Series["Forecast Demand"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;


                    //this.chartForecast.BackColor = Color.AliceBlue;

                    //this.chartForecast.ChartAreas[0].AxisX.LineColor = Color.Red;
                    //this.chartForecast.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Red;
                    //this.chartForecast.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.Red;

                    //this.chartForecast.ChartAreas[-1].AxisY.LineColor = Color.Red;
                    //this.chartForecast.ChartAreas[-1].AxisY.MajorGrid.LineColor = Color.Red;
                    //this.chartForecast.ChartAreas[-1].AxisY.LabelStyle.ForeColor = Color.Red;

                    //double[] yValue21 = { 5, 5, 5, 5, 5, 5, 5 };
                    //double[] yValue22 = { 8, 8, 8, 8, 8, 8, 8 };

                    chartForecast.Series["Forecast Demand"].BorderWidth = 2;
                    //chartForecast.Series["Forecast Demand"].Points[0].Color = Color.Green;
                    //chartForecast.Series["Forecast Demand"].Points[1].Color = Color.Red;
                    //chartForecast.Series["Forecast Demand"].Points[2].Color = Color.PowderBlue;
                   //  chartForecast.Series["Forecast Demand"].Points[3].Color = Color.Red;
                    //  chartForecast.Series["Forecast Demand"].Points[4].Color = Color.Pink;


                    //if (chartForecast.ChartAreas.Count == 3)
                    //{
                    //    chartForecast.ChartAreas[3].AxisX.MajorGrid.LineWidth = 20;
                    //    chartForecast.ChartAreas[3].AxisY.MajorGrid.LineWidth = 30;
                    //    chartForecast.Series["Forecast Demand"].Points[3].Color = Color.Red;
                    //    chartForecast.ChartAreas[3].AxisX.LabelStyle.Angle = -45;
                    //}

                    //  chartForecast.BackColor = Color.FromArgb(70, 255, 0, 0);
                    ///   chartForecast.Series.Add(chartForecast);
                    //    chartForecast.Series[0].Points.DataBindY(yValue21, yValue22);

                    chartForecast.Series["Forecast Demand"].XValueMember = "Stock";
                    chartForecast.Series["Forecast Demand"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;

                    chartForecast.Series["Forecast Demand"].YValueMembers = myReader.GetString("stock");
                    chartForecast.Series["Forecast Demand"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;

                }
                Conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("keme1" + ex.Message);
            }
        }
        private void label43_Click(object sender, EventArgs e)
        {
           
        
        }

        private void btnconfig_Click(object sender, EventArgs e)
        {

            frm_edit_replacement cq = new frm_edit_replacement();
            cq.ShowDialog();
      
            DGVInventoryProductList();
            subshowcolumn();
        }

        private void lblNPend_Click(object sender, EventArgs e)
        {

        }

        private void lblNR_Click(object sender, EventArgs e)
        {

        }

        private void btnRefresh3_Click(object sender, EventArgs e)
        {
            DGVstoreOK();
        }
    }
}
