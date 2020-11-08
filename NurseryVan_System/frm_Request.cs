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
    public partial class frm_Request : Form
    {
        int store_id;
        int qty;
        string status1;
        string replacement;
        int critical;
        string critic;
        string productname;
        string getproductid;
        string getStatus;
        string getID;
        string getqty;
        string getAvailable;
        string getproduct;
        string ordered;
        string expected;
        string status_sent;
        public frm_Request()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {

        }
        void DGVstoredisplayproductRequested()
        {

            MySqlConnection Conn = ConString.Connection;


            MySqlCommand cmd = new MySqlCommand("SELECT tbl_inventory.product_id as 'Product ID', tbl_product.product_name as 'Product Name', QTY as 'QTY in Outlet', tbl_inventory.r_status as 'Status',  tbl_product.stock as 'Stock', tbl_order.date_ordered as 'Delivered', tbl_order.date_expected as 'Expected', tbl_inventory.critical as 'Critical', tbl_inventory.status_sent as 'Status Sent', tbl_order.leadtime1, tbl_inventory.r_qty as 'Requested QTY', tbl_inventory.r_date as 'Date Requested' FROM tbl_inventory inner join tbl_product on tbl_inventory.product_id = tbl_product.product_id inner join tbl_store on tbl_inventory.store_id = tbl_store.store_id left join tbl_order on tbl_product.product_id = tbl_order.product_id where tbl_inventory.r_status = 'Requested' and tbl_inventory.store_id = '" + cbStoreID.Text + "' group by tbl_inventory.product_id;", Conn);
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


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error5");
            }
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[2].Visible = false;


            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[8].Visible = false;

            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[9].Visible = false;
        }
        void DGVReplacement()
        {

            MySqlConnection Conn = ConString.Connection;


            MySqlCommand cmd = new MySqlCommand("SELECT tbl_inventory.product_id as 'Product ID', tbl_product.product_name as 'Product Name', qty_replacement as 'QTY Replacement', tbl_inventory.subStatus as 'Status', tbl_inventory.subQTY as 'QTY',  tbl_inventory.status_pending as 'Available',  tbl_inventory.date_expected, tbl_inventory.s_replacement as 'Status Replacement' FROM tbl_inventory inner join tbl_product on tbl_inventory.product_id = tbl_product.product_id inner join tbl_store on tbl_inventory.store_id = tbl_store.store_id  where tbl_inventory.s_replacement = 'Replacement' and tbl_inventory.store_id = '" + this.cbStoreID1.Text + "' group by tbl_inventory.product_id;", Conn);
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
                metroGrid1.DefaultCellStyle.SelectionBackColor = Color.Pink;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error5");
            }
        }

        void BranchRefresh()
        {

            MySqlConnection Conn = ConString.Connection;

            try
            {





                DataTable dt = new DataTable();
                //keme
                if (frm_Login.manager == "Manager")
                {
                    //        dataGridView1.Columns[6].Visible = true;


                    MySqlDataAdapter sda = new MySqlDataAdapter("SELECT tbl_inventory.product_id as 'Product ID', tbl_product.product_name as 'Product Name', QTY, tbl_inventory.r_status as 'Status', tbl_product.Stock as 'Stock',  tbl_order.date_ordered as 'Ordered', tbl_order.date_expected as 'Expected', tbl_inventory.critical as 'Critical', tbl_inventory.status_sent as 'Status Sent',tbl_order.leadtime1, tbl_inventory.r_qty as 'Requested QTY', tbl_inventory.r_date as 'Date Requested'  FROM tbl_inventory inner join tbl_product on tbl_inventory.product_id = tbl_product.product_id inner join tbl_store on tbl_inventory.store_id = tbl_store.store_id left join tbl_order on tbl_product.product_id = tbl_order.product_id where tbl_inventory.r_status = 'Requested'  and tbl_inventory.store_id = '" + cbStoreID.Text + "' group by tbl_inventory.product_id", Conn);
                    sda.Fill(dt);
                    Conn.Close();
                    dataGridView1.DataSource = dt;


                    subNotifyBranch();
                }
              

            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        void BranchRefreshStockman()
        {

            MySqlConnection Conn = ConString.Connection;

            try
            {





                DataTable dt = new DataTable();
                //keme
             
                    //        dataGridView1.Columns[6].Visible = true;


                    MySqlDataAdapter sda = new MySqlDataAdapter("SELECT tbl_product.product_name as 'Product Name',  tbl_inventory.subQTY as 'Delivery QTY', tbl_inventory.r_date as 'Date Requested', tbl_inventory.date_expected as 'Delivery Date',  tbl_inventory.r_status as 'Status' FROM tbl_inventory inner join tbl_product on tbl_inventory.product_id = tbl_product.product_id inner join tbl_store on tbl_inventory.store_id = tbl_store.store_id left join tbl_order on tbl_product.product_id = tbl_order.product_id where tbl_inventory.r_status = 'Approved'  and tbl_inventory.store_id = '" + cbStoreID.Text + "' group by tbl_inventory.product_id", Conn);
                    sda.Fill(dt);
                    Conn.Close();
                    dataGridView1.DataSource = dt;


                    subNotifyBranch();
                


            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        void BranchRefresh1()
        {

            MySqlConnection Conn = ConString.Connection;

            try
            {





                DataTable dt = new DataTable();


                MySqlDataAdapter sda = new MySqlDataAdapter("SELECT tbl_inventory.product_id as 'Product ID', tbl_product.product_name as 'Product Name', qty_replacement as 'QTY Replacement', tbl_inventory.subStatus as 'Status', tbl_inventory.subQTY as 'QTY',  tbl_inventory.status_pending as 'Available',  tbl_inventory.date_expected, tbl_inventory.s_replacement as 'Status Replacement' FROM tbl_inventory inner join tbl_product on tbl_inventory.product_id = tbl_product.product_id inner join tbl_store on tbl_inventory.store_id = tbl_store.store_id where tbl_inventory.s_replacement = 'Replacement' and tbl_store.store_name like '%" + cbStore1.Text + "' group by tbl_inventory.product_id", Conn);
                sda.Fill(dt);
                Conn.Close();
                metroGrid1.DataSource = dt;




            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void StillNotAvailable()
        {
            MySqlConnection Conn = ConString.Connection;


            AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();

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

     
        public void CriticalLevel1()
        {
            try
            {
                MySqlConnection conn = ConString.Connection;
                DateTime datenow = DateTime.Now;
                MySqlDataReader dr;
                MySqlCommand cmd;
                string query;


                //CRITICAL LEVEL
                if (txtLeadTime.Text == "0" || String.IsNullOrEmpty(txtLeadTime.Text))
                {


                  


                    try
                    {
                        //formula
                        //SAFETY STOCK/SS

                        query = "insert into tbl_critical (product_id, quantity, leadtime, date, store_id) values ('" + getproductid + "','" + Convert.ToInt32(txtAmountQTY.Text) + "',0, '" + datenow.ToString("yyyy-MM-dd") + "', '"+ cbStoreID.Text + "');update tbl_product A inner join (select product_id,max(quantity) * max(leadtime)-avg(quantity) * avg(leadtime) as 'SS' from tbl_critical where date between date_sub(NOW(),interval 360 day) and NOW() group by product_id) B on A.product_id=B.product_id set A.ss = B.SS where A.product_id = '" + getproductid + "'";
                        //"             update tblinventory A inner join (select itemid,max(soldqty)-min(soldqty) as 'SS' from tblcart where datesold between date_sub(NOW(),interval 60 day) and NOW() and remove='No' and payment='Yes' group by itemid) B on A.itemid=B.itemid set A.ss=B.SS where a.itemid = '"+itemid+"';";
                        cmd = new MySqlCommand(query, conn);
                        dr = cmd.ExecuteReader();

                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "1111");
                    }

                    try
                    {
                        //AVERAGE DAILY SALES
                        conn = ConString.Connection;
                        query = "update tbl_product A inner join (SELECT product_id,avg(quantity)/1 as 'OQ' FROM tbl_critical where date between date_sub(NOW(),interval 360 day) and NOW() group by product_id) B on A.product_id=B.product_id set A.oq=B.OQ where A.product_id = '" + getproductid + "'";
                        //             update tblinventory A inner join (SELECT itemid,avg(soldqty)/2 as 'OQ' FROM tblcart where datesold between date_sub(NOW(),interval 60 day) and NOW() and remove='No' and payment='Yes' group by itemid) B on A.itemid=B.itemid set A.OQ=B.OQ where a.itemid = '"+itemid+"' ;";
                        cmd = new MySqlCommand(query, conn);
                        dr = cmd.ExecuteReader();

                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "2");
                    }

                    try
                    {
                        conn = ConString.Connection;
                        // critical = (ss + oq)/2
                        query = "update tbl_product set critical=(ss + oq)/2  where product_id = '" + getproductid + "';";
                        cmd = new MySqlCommand(query, conn);
                        dr = cmd.ExecuteReader();

                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "3");
                    }

                    //  MessageBox.Show("A");

                    try
                    {
                        //LEADTIME
                        conn = ConString.Connection;
                        query = "update tbl_product A inner join (SELECT product_id,avg(leadtime) as 'LT' FROM tbl_critical where date between date_sub(NOW(),interval 360 day) and NOW() group by product_id) B on A.product_id=B.product_id set A.lt=B.LT where A.product_id = '" + getproductid + "'";
                        //             update tblinventory A inner join (SELECT itemid,avg(soldqty)/2 as 'OQ' FROM tblcart where datesold between date_sub(NOW(),interval 60 day) and NOW() and remove='No' and payment='Yes' group by itemid) B on A.itemid=B.itemid set A.OQ=B.OQ where a.itemid = '"+itemid+"' ;";
                        cmd = new MySqlCommand(query, conn);
                        dr = cmd.ExecuteReader();

                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "6");
                    }



                    try
                    {
                        //LEADTIME DEMAND
                        conn = ConString.Connection;
                        query = "update tbl_product A inner join (SELECT product_id,  avg(leadtime) * avg(quantity) as 'LTD' FROM tbl_critical where date between date_sub(NOW(),interval 360 day) and NOW() group by product_id) B on A.product_id=B.product_id set A.ltd=B.LTD where A.product_id = '" + getproductid + "'";
                        //             update tblinventory A inner join (SELECT itemid,avg(soldqty)/2 as 'OQ' FROM tblcart where datesold between date_sub(NOW(),interval 60 day) and NOW() and remove='No' and payment='Yes' group by itemid) B on A.itemid=B.itemid set A.OQ=B.OQ where a.itemid = '"+itemid+"' ;";
                        cmd = new MySqlCommand(query, conn);
                        dr = cmd.ExecuteReader();

                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "6");
                    }



                    //REORDER POINT
                    try
                    {
                        conn = ConString.Connection;
                        // critical = (ss + oq)/2
                        query = "update tbl_product set rp= LTD + SS where product_id = '" + getproductid + "';";
                        cmd = new MySqlCommand(query, conn);
                        dr = cmd.ExecuteReader();

                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "7");
                    }

                    try
                    {
                        //MAXIMUM STOCK LEVEL
                        conn = ConString.Connection;
                        query = "update tbl_product A inner join (SELECT product_id, max(quantity) * max(leadtime) + max(quantity) * max(leadtime) - avg(quantity) * avg(leadtime) + avg(quantity) * avg(leadtime) - (min(quantity) * min(leadtime)) as 'maxqty' FROM tbl_critical where date between date_sub(NOW(),interval 360 day) and NOW() group by product_id) B on A.product_id=B.product_id set A.sqty=B.maxqty where A.product_id = '" + getproductid + "'";
                        //             update tblinventory A inner join (SELECT itemid,avg(soldqty)/2 as 'OQ' FROM tblcart where datesold between date_sub(NOW(),interval 60 day) and NOW() and remove='No' and payment='Yes' group by itemid) B on A.itemid=B.itemid set A.OQ=B.OQ where a.itemid = '"+itemid+"' ;";
                        cmd = new MySqlCommand(query, conn);
                        dr = cmd.ExecuteReader();

                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "6");
                    }
                }
                else if (txtLeadTime.Text != "0")
                {
                     

                    try
                    {
                    
                        //SAFETY STOCK
                        conn = ConString.Connection;
                        query = "insert into tbl_critical (product_id, quantity, leadtime, date, store_id) values ('" + getproductid + "','" + Convert.ToInt32(txtAmountQTY.Text) + "', '" + Convert.ToInt32(txtLeadTime.Text) + "', '" + datenow.ToString("yyyy-MM-dd") + "', '"+cbStoreID.Text+ "');update tbl_product A inner join (select product_id, max(quantity) * max(leadtime) - avg(leadtime) * avg(quantity) as 'SS' from tbl_critical where date between date_sub(NOW(),interval 360 day) and NOW() group by product_id) B on A.product_id=B.product_id set A.ss = B.SS where A.product_id = '" + getproductid + "'";
                        //"             update tblinventory A inner join (select itemid,max(soldqty)-min(soldqty) as 'SS' from tblcart where datesold between date_sub(NOW(),interval 60 day) and NOW() and remove='No' and payment='Yes' group by itemid) B on A.itemid=B.itemid set A.ss=B.SS where a.itemid = '"+itemid+"';";
                        cmd = new MySqlCommand(query, conn);
                        dr = cmd.ExecuteReader();

                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "4");
                    }

                    try
                    {
                        //AVERAGE DAILY SALES
                        conn = ConString.Connection;
                        query = "update tbl_product A inner join (SELECT product_id,avg(quantity)/1 as 'OQ' FROM tbl_critical where date between date_sub(NOW(),interval 360 day) and NOW() group by product_id) B on A.product_id=B.product_id set A.oq=B.OQ where A.product_id = '" + getproductid + "'";
                        //             update tblinventory A inner join (SELECT itemid,avg(soldqty)/2 as 'OQ' FROM tblcart where datesold between date_sub(NOW(),interval 60 day) and NOW() and remove='No' and payment='Yes' group by itemid) B on A.itemid=B.itemid set A.OQ=B.OQ where a.itemid = '"+itemid+"' ;";
                        cmd = new MySqlCommand(query, conn);
                        dr = cmd.ExecuteReader();

                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "5");
                    }

                    try
                    {
                        //LEADTIME
                        conn = ConString.Connection;
                        query = "update tbl_product A inner join (SELECT product_id,avg(leadtime) as 'LT' FROM tbl_critical where date between date_sub(NOW(),interval 360 day) and NOW() group by product_id) B on A.product_id=B.product_id set A.lt=B.LT where A.product_id = '" + getproductid + "'";
                        //             update tblinventory A inner join (SELECT itemid,avg(soldqty)/2 as 'OQ' FROM tblcart where datesold between date_sub(NOW(),interval 60 day) and NOW() and remove='No' and payment='Yes' group by itemid) B on A.itemid=B.itemid set A.OQ=B.OQ where a.itemid = '"+itemid+"' ;";
                        cmd = new MySqlCommand(query, conn);
                        dr = cmd.ExecuteReader();

                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "6");
                    }



                    try
                    {
                        //LEADTIME DEMAND
                        conn = ConString.Connection;
                        query = "update tbl_product A inner join (SELECT product_id,  avg(leadtime) * avg(quantity) as 'LTD' FROM tbl_critical where date between date_sub(NOW(),interval 360 day) and NOW() group by product_id) B on A.product_id=B.product_id set A.ltd=B.LTD where A.product_id = '" + getproductid + "'";
                        //             update tblinventory A inner join (SELECT itemid,avg(soldqty)/2 as 'OQ' FROM tblcart where datesold between date_sub(NOW(),interval 60 day) and NOW() and remove='No' and payment='Yes' group by itemid) B on A.itemid=B.itemid set A.OQ=B.OQ where a.itemid = '"+itemid+"' ;";
                        cmd = new MySqlCommand(query, conn);
                        dr = cmd.ExecuteReader();

                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "6");
                    }



                    //REORDER POINT
                    try
                    {
                        conn = ConString.Connection;
                        // critical = (ss + oq)/2
                        query = "update tbl_product set rp= ltd + SS where product_id = '" + getproductid + "';";
                        cmd = new MySqlCommand(query, conn);
                        dr = cmd.ExecuteReader();

                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "7");
                    }

                    try
                    {
                        //MAXIMUM STOCK LEVEL
                        conn = ConString.Connection;
                        query = "update tbl_product A inner join (SELECT product_id, max(quantity) * max(leadtime) + max(quantity) * max(leadtime) - avg(quantity) * avg(leadtime) + avg(quantity) * avg(leadtime) - (min(quantity) * min(leadtime)) as 'maxqty' FROM tbl_critical where date between date_sub(NOW(),interval 360 day) and NOW() group by product_id) B on A.product_id=B.product_id set A.sqty=B.maxqty where A.product_id = '" + getproductid + "'";
                        //             update tblinventory A inner join (SELECT itemid,avg(soldqty)/2 as 'OQ' FROM tblcart where datesold between date_sub(NOW(),interval 60 day) and NOW() and remove='No' and payment='Yes' group by itemid) B on A.itemid=B.itemid set A.OQ=B.OQ where a.itemid = '"+itemid+"' ;";
                        cmd = new MySqlCommand(query, conn);
                        dr = cmd.ExecuteReader();

                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "6");
                    }


                    //CRITICAL LEVEL
                    try
                    {
                        conn = ConString.Connection;
                        // critical = (ss + oq)/2
                        query = "update tbl_product set critical=(ss + oq)/2  where product_id = '" + getproductid + "';";
                        cmd = new MySqlCommand(query, conn);
                        dr = cmd.ExecuteReader();

                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "7");
                    }

                  
                    //  MessageBox.Show("B");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "4", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);

            }
        }
        public void subNotifyBranch()
        {

            MySqlConnection Conn = ConString.Connection;

            string Query = "(SELECT *  FROM ( Select '1' as ID, count(*) as C_New_Branch1 from (SELECT count(tbl_inventory.product_id)  from tbl_inventory inner join tbl_product on tbl_inventory.product_id = tbl_product.product_id where tbl_inventory.r_status  = 'Requested' and tbl_inventory.store_id = '" + cbStoreID.Text + "' group by tbl_inventory.product_id order by count(tbl_inventory.product_id)) as DerivedTableAlias) AS A) UNION  (SELECT *  FROM ( Select '2' as ID, count(*) as C_New_Branch from (SELECT count(tbl_inventory.product_id)  from tbl_inventory inner join tbl_product on tbl_inventory.product_id = tbl_product.product_id where tbl_inventory.status  = 'New Product' and tbl_inventory.store_id = '" + cbStoreID.Text + "' " +
                "group by tbl_product.product_id order by count(tbl_product.product_id)) as DerivedTableAlias) AS B) UNION (SELECT *  FROM ( Select '3' as ID, count(*) as C_New_Branch from (SELECT count(tbl_inventory.product_id)  from tbl_inventory inner join tbl_product on tbl_inventory.product_id = tbl_product.product_id where tbl_inventory.s_replacement  = 'Replacement' and tbl_inventory.store_id = '" + cbStoreID.Text + "' group by tbl_product.product_id order by count(tbl_product.product_id)) as DerivedTableAlias) AS C)";
            MySqlCommand cmd = new MySqlCommand(Query, Conn);
            MySqlDataReader myReader;


            try
            {

                myReader = cmd.ExecuteReader();

                while (myReader.Read())
                {


                    if (frm_Login.manager == "Manager")
                    {




                        int ID = myReader.GetInt32("ID");

                        if (ID == 1)
                        {
                            lblN2.Text = myReader.GetString("C_New_Branch1");
                            lblN22.Text = myReader.GetString("C_New_Branch1");
                        }

                        if (ID == 2)
                        {
                            lblN1.Text = myReader.GetString("C_New_Branch1");
                        }

                        if (ID == 3)
                        {
                            lblN3.Text = myReader.GetString("C_New_Branch1");
                            lblN33.Text = myReader.GetString("C_New_Branch1");
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
                            lblN22.Visible = false;

                        }
                        else
                        {
                            lblN2.Visible = true;
                            lblN22.Visible = true;
                        }
                        if (int.Parse(lblN3.Text) == 0)
                        {
                            lblN3.Visible = false;
                            lblN33.Visible = false;

                        }
                        else
                        {
                            lblN3.Visible = true;
                            lblN33.Visible = true;
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
      
            private void frm_Request_Load(object sender, EventArgs e)
        {

         
            PictureBox pic = new PictureBox();
            pic.Width = 16;
            pic.Height = 16;
            pic.Left = 200;


            metroTile1.BackColor = Color.DarkGray;
            metroTile1.Enabled = false;
            pic.BackgroundImage = NurseryVan_System.Properties.Resources.search2;
            txtSearch.Controls.Add(pic);
        
         
            //keme
            if (frm_Login.manager == "Manager")
            {
                DGVstoredisplayproductRequested();

                cbBranch();
                cbBranch1();
                DGVReplacement();
                metroGrid1.Columns[4].Visible = false;
                metroGrid1.Columns[5].Visible = false;
                metroGrid1.Columns[6].Visible = false;
                metroGrid1.Columns[3].Visible = false;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[2].Visible = false;


                dataGridView1.Columns[7].Visible = false;
                dataGridView1.Columns[8].Visible = false;
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[6].Visible = false;
                dataGridView1.Columns[9].Visible = false;
            }
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            metroGrid1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            if (tabControl1.SelectedTab == tabPage1)
            {
                cbStore1.Visible = false;
                cbStore.Visible = true;
            }
            if (cbStore.SelectedIndex == -1)
            {
                lblMatch1.Show();
            }
            else
            {
                lblMatch1.Hide();
            }
            subNotifyBranch();
            subCritic();
            StillReplacementAvoidSend();
            StillNotAvailable();


            if (frm_Login.stockman == "Stockman")
            {
                metroTile1.Visible = false;
                tabControl1.TabPages.Remove(tabPage2);
                comboBoxforStockman();
                ShowDeliverySentForStockman();
                ShowDeliverySentForStockmanBackordered();
                lblMatch1.Visible = false;
                btnEdit.Visible = false;
                btnNP.Visible = false;
                btnRefresh.Visible = false;
                btnCL.Visible = false;
                btnBO.Visible = false;
                lblN1.Visible = false;
                lblN2.Visible = false;
                lblN3.Visible = false;
                dataGridView1.Enabled = false;
                txtSearch.Visible = false;
                groupBox1.Visible = false;
                groupBox2.Visible = false;
                btnRedeliver.Visible = false;
                btnOk.Visible = false;
                label11.Visible = false;
                label41.Visible = false;
                label10.Visible = false;
                txtRqty.Visible = false;
                label9.Visible = false;
                txtAmountQTY.Visible = false;
                label2.Visible = false;
                txtstock.Visible = false;
                label1.Visible = false;
                lbloriginalCritical.Visible = false;
                metroGrid1.Visible = false;
                if (frm_Login.manager == "Manager")
                {
                    //metroGrid1.Columns[4].Visible = false;
                    //metroGrid1.Columns[5].Visible = false;
                    //metroGrid1.Columns[6].Visible = false;
                    //metroGrid1.Columns[3].Visible = false;
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[2].Visible = false;


                    dataGridView1.Columns[7].Visible = false;
                    dataGridView1.Columns[8].Visible = false;
                    dataGridView1.Columns[4].Visible = false;
                    dataGridView1.Columns[5].Visible = false;
                    dataGridView1.Columns[6].Visible = false;
                    dataGridView1.Columns[9].Visible = false;
                }


            }

        }
        public void comboBoxforStockman()
        {

            MySqlConnection Conn = ConString.Connection;




            string Query = "SELECT tbl_store.store_name as 'Store' FROM tbl_inventory inner join tbl_product on tbl_inventory.product_id = tbl_product.product_id inner join tbl_store on tbl_inventory.store_id = tbl_store.store_id where tbl_inventory.r_status = 'Approved' group by tbl_store.store_name;";

            MySqlCommand cmd = new MySqlCommand(Query, Conn);

            AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();

            try
            {

                MySqlDataReader myReader = cmd.ExecuteReader();

                while (myReader.Read())
                {
                    MyCollection.Add(myReader.GetString(0));

                    cbStore.Items.Add(myReader[0]);

                    //   storename = myReader.GetString("store_name");

                }

                cbStore.AutoCompleteCustomSource = MyCollection;

                Conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error1");
            }


            DataTable dt = new DataTable();
            MySqlDataAdapter sda = new MySqlDataAdapter("SELECT tbl_store.store_name as 'Store' FROM tbl_inventory inner join tbl_product on tbl_inventory.product_id = tbl_product.product_id inner join tbl_store on tbl_inventory.store_id = tbl_store.store_id where tbl_inventory.r_status = 'Requested' group by tbl_store.store_name;", Conn);
            sda.Fill(dt);
            sda.SelectCommand = cmd;


            cbStore.DataSource = dt;

            cbStore.DisplayMember = "Store";
            cbStore.ValueMember = "Store";
            DataTable dbdataset = new DataTable();
            sda.Fill(dbdataset);
            BindingSource bSource = new BindingSource();

            bSource.DataSource = dbdataset;

            cbStore.DataSource = bSource;
            sda.Update(dbdataset);

        }
        public void cbBranch()
        {

            MySqlConnection Conn = ConString.Connection;




            string Query = "SELECT tbl_store.store_name as 'Store' FROM tbl_inventory inner join tbl_product on tbl_inventory.product_id = tbl_product.product_id inner join tbl_store on tbl_inventory.store_id = tbl_store.store_id where tbl_inventory.r_status = 'Requested' group by tbl_store.store_name;";

            MySqlCommand cmd = new MySqlCommand(Query, Conn);

            AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();

            try
            {

                MySqlDataReader myReader = cmd.ExecuteReader();

                while (myReader.Read())
                {
                    MyCollection.Add(myReader.GetString(0));

                    cbStore.Items.Add(myReader[0]);

                    //   storename = myReader.GetString("store_name");

                }

                cbStore.AutoCompleteCustomSource = MyCollection;

                Conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error1");
            }


            DataTable dt = new DataTable();
            MySqlDataAdapter sda = new MySqlDataAdapter("SELECT tbl_store.store_name as 'Store' FROM tbl_inventory inner join tbl_product on tbl_inventory.product_id = tbl_product.product_id inner join tbl_store on tbl_inventory.store_id = tbl_store.store_id where tbl_inventory.r_status = 'Requested' group by tbl_store.store_name;", Conn);
            sda.Fill(dt);
            sda.SelectCommand = cmd;


            cbStore.DataSource = dt;

            cbStore.DisplayMember = "Store";
            cbStore.ValueMember = "Store";
            DataTable dbdataset = new DataTable();
            sda.Fill(dbdataset);
            BindingSource bSource = new BindingSource();

            bSource.DataSource = dbdataset;

            cbStore.DataSource = bSource;
            sda.Update(dbdataset);

        }
        public void cbBranch1()
        {

            MySqlConnection Conn = ConString.Connection;




            string Query = "SELECT tbl_store.store_name as 'Store' FROM tbl_inventory inner join tbl_product on tbl_inventory.product_id = tbl_product.product_id inner join tbl_store on tbl_inventory.store_id = tbl_store.store_id where tbl_inventory.s_replacement= 'Replacement' group by tbl_store.store_name;";

            MySqlCommand cmd = new MySqlCommand(Query, Conn);

            AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();

            try
            {

                MySqlDataReader myReader = cmd.ExecuteReader();

                while (myReader.Read())
                {
                    MyCollection.Add(myReader.GetString(0));

                    cbStore1.Items.Add(myReader[0]);

                    //   storename = myReader.GetString("store_name");

                }

                cbStore1.AutoCompleteCustomSource = MyCollection;

                Conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error1");
            }


            DataTable dt = new DataTable();
            MySqlDataAdapter sda = new MySqlDataAdapter("SELECT tbl_store.store_name as 'Store' FROM tbl_inventory inner join tbl_product on tbl_inventory.product_id = tbl_product.product_id inner join tbl_store on tbl_inventory.store_id = tbl_store.store_id where tbl_inventory.s_replacement = 'Replacement' group by tbl_store.store_name;", Conn);
            sda.Fill(dt);
            sda.SelectCommand = cmd;


            cbStore1.DataSource = dt;

            cbStore1.DisplayMember = "Store";
            cbStore1.ValueMember = "Store";
            DataTable dbdataset = new DataTable();
            sda.Fill(dbdataset);
            BindingSource bSource = new BindingSource();

            bSource.DataSource = dbdataset;

            cbStore1.DataSource = bSource;
            sda.Update(dbdataset);

        }
        private void cbStore_SelectedIndexChanged(object sender, EventArgs e)
        {

            MySqlConnection Conn = ConString.Connection;


            Cursor.Current = Cursors.WaitCursor;

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
            cbStoreID.DataSource = dt;
            cbStoreID.DisplayMember = "store_id";
            cbStoreID.ValueMember = "store_id";

            subNotifyBranch();

            if (frm_Login.stockman == "Stockman")
            {
                BranchRefreshStockman();
                ShowDeliverySentForStockman();
                btnEdit.Visible = false;
                btnNP.Visible = false;
                btnRefresh.Visible = false;
                btnCL.Visible = false;
                btnBO.Visible = false;
                lblN1.Visible = false;
                lblN2.Visible = false;
                lblN3.Visible = false;
                txtSearch.Visible = false;
                groupBox1.Visible = false;
                groupBox2.Visible = false;
                btnRedeliver.Visible = false;
                btnOk.Visible = false;
                label11.Visible = false;
                label41.Visible = false;
                label10.Visible = false;
                txtRqty.Visible = false;
                label9.Visible = false;
                txtAmountQTY.Visible = false;
                label2.Visible = false;
                txtstock.Visible = false;
                label1.Visible = false;
                lbloriginalCritical.Visible = false;

                metroGrid1.Visible = false;



            }


            if (frm_Login.manager == "Manager")
            {





                //metroGrid1.Columns[4].Visible = false;
                //metroGrid1.Columns[5].Visible = false;
                //metroGrid1.Columns[6].Visible = false;
                //metroGrid1.Columns[3].Visible = false;
                BranchRefresh1();
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[2].Visible = false;


                dataGridView1.Columns[7].Visible = false;
                dataGridView1.Columns[8].Visible = false;
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[6].Visible = false;
                dataGridView1.Columns[9].Visible = false;
            }

        }

        private void cbStore_TextChanged(object sender, EventArgs e)
        {
            if (frm_Login.manager == "Manager")
            {



                if (cbStore.Text == "")
                {

                    //CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[dataGridView1.DataSource];
                    //currencyManager1.SuspendBinding();
                    ////dataGridView1.Columns[0].Visible = false;
                    ////dataGridView1.Columns[1].Visible = false;
                    ////dataGridView1.Columns[2].Visible = false;
                    ////dataGridView1.Columns[3].Visible = false;
                    ////dataGridView1.Columns[4].Visible = false;
                    //currencyManager1.ResumeBinding();

                    return;
                }
                else
                {
                    // CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[dataGridView1.DataSource];
                    // currencyManager1.SuspendBinding();
                    //// dataGridView1.Columns[0].Visible = true;
                    //// dataGridView1.Columns[1].Visible = true;
                    //// dataGridView1.Columns[2].Visible = true;
                    //// dataGridView1.Columns[3].Visible = true;
                    ////// dataGridView1.Columns[4].Visible = true;
                    // currencyManager1.ResumeBinding();
                }

                if (cbStore.Text.Contains(@"\"))
                {
                    return;
                }
                MySqlConnection Conn = ConString.Connection;


                try
                {

                    //DataTable dt1 = new DataTable()




                    //    MySqlDataAdapter sda1 = new MySqlDataAdapter("SELECT tbl_inventory.product_id as 'Product ID', tbl_product.product_name as 'Product Name', qty_replacement as 'QTY Replacement', tbl_inventory.subStatus as 'Status' FROM tbl_inventory inner join tbl_product on tbl_inventory.product_id = tbl_product.product_id inner join tbl_store on tbl_inventory.store_id = tbl_store.store_id  where tbl_inventory.subStatus = 'Replacement' and tbl_inventory.store_id = '" + cbStoreID.Text + "' and tbl_store.store_name like '%" + cbStore.Text + "' group by tbl_inventory.product_id", Conn);
                    //    sda1.Fill(dt1);
                    //    Conn.Close();
                    //if (getStatus == "Replacement")
                    //{
                    //    metroGrid1.DataSource = dt1;
                    //    return;
                    //}
                    DataTable dt = new DataTable();
                    Conn = ConString.Connection;
                    MySqlDataAdapter sda = new MySqlDataAdapter("SELECT tbl_inventory.product_id as 'Product ID', tbl_product.product_name as 'Product Name', QTY as 'QTY in Outlet', tbl_inventory.r_status as 'Status',  tbl_product.Stock as 'Stock',  tbl_order.date_ordered, tbl_order.date_expected, tbl_inventory.critical as 'Critical', tbl_inventory.status_sent as 'Status Sent', tbl_order.leadtime1, tbl_inventory.r_qty as 'Requested QTY', tbl_inventory.r_date as 'Date Requested'  FROM tbl_inventory inner join tbl_product on tbl_inventory.product_id = tbl_product.product_id inner join tbl_store on tbl_inventory.store_id = tbl_store.store_id left join tbl_order on tbl_product.product_id = tbl_order.product_id where tbl_inventory.r_status = 'Requested' and tbl_store.store_name like '%" + cbStore.Text + "' group by tbl_inventory.product_id", Conn);
                    sda.Fill(dt);
                    Conn.Close();
                    dataGridView1.DataSource = dt;



                    subNotifyBranch();

                }


                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
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
                    lblMatch1.Text = "No results found";
                    if (lblMatch1.Visible == true)
                    {
                        txtstock.Text = "";
                    }



                }
            }

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (frm_Login.manager == "Manager")
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

                        //     txtProductID.Text = row.Cells[0].Value.ToString();

                        txtstock.Text = row.Cells[4].Value.ToString();
                        dateTimePicker2.Text = row.Cells[5].Value.ToString();
                        dateTimePicker5.Text = row.Cells[6].Value.ToString();
                        productname = row.Cells[1].Value.ToString();
                        status1 = row.Cells[3].Value.ToString();
                        lblgetcritical.Text = row.Cells[7].Value.ToString();
                        status_sent = row.Cells[8].Value.ToString();
                        lblgetstock.Text = row.Cells[2].Value.ToString();
                        getproductid = row.Cells[0].Value.ToString();
                        lblProductID.Text = row.Cells[0].Value.ToString();
                        txtProductID.Text = row.Cells[0].Value.ToString();
                        txtLeadTime.Text = row.Cells[9].Value.ToString();

                        //     txtLeadTime.Text = row.Cells[9].Value.ToString();
                        //   txtLeadTime.Text = (dateTimePicker5.Value - dateTimePicker2.Value).TotalDays.ToString("#");


                    }
                    subCritic();


                    if (status1 == "New Product")
                    {
                        // MessageBox.Show(status1);
                        lblgetcritical.Text = "0";
                        lblcritical.Text = "0";
                        dataGridView1.Columns[0].Visible = false;
                        dataGridView1.Columns[2].Visible = false;


                        dataGridView1.Columns[7].Visible = false;
                        dataGridView1.Columns[8].Visible = false;
                        dataGridView1.Columns[4].Visible = false;
                        dataGridView1.Columns[5].Visible = false;
                        dataGridView1.Columns[6].Visible = false;
                        dataGridView1.Columns[8].Visible = false;
                        dataGridView1.Columns[9].Visible = false;
                    }
                    if (status1 == "Critical Level")
                    {
                        // MessageBox.Show(status1);

                        dataGridView1.Columns[0].Visible = false;
                        dataGridView1.Columns[2].Visible = false;


                        dataGridView1.Columns[7].Visible = false;
                        dataGridView1.Columns[8].Visible = false;
                        dataGridView1.Columns[4].Visible = false;
                        dataGridView1.Columns[5].Visible = false;
                        dataGridView1.Columns[6].Visible = false;
                        dataGridView1.Columns[9].Visible = false;
                    }


                    //if (status_sent == "Sent")
                    //{

                    //    //  MessageBox.Show("There is out of stock of " + productname, "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //    metroTile1.BackColor = Color.DarkGray;
                    //    metroTile1.Enabled = false;
                    //    return;
                    //}
                    //else
                    //{

                    //    metroTile1.BackColor = System.Drawing.ColorTranslator.FromHtml("#24262F");
                    //    metroTile1.Enabled = true;


                    //}

                    if (txtstock.Text == "0")
                    {
                        //  MessageBox.Show("There is out of stock of " + productname, "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtAmountQTY.Enabled = false;
                        btnOk.Enabled = false;
                        metroTile1.Enabled = false;
                        btnOk.BackColor = Color.DarkGray;
                        metroTile1.BackColor = Color.DarkGray;

                    }
                    else
                    {

                        btnOk.Enabled = true;
                        metroTile1.Enabled = true;
                        btnOk.BackColor = System.Drawing.ColorTranslator.FromHtml("#24262F");
                        metroTile1.BackColor = System.Drawing.ColorTranslator.FromHtml("#24262F");
                    }

                    if (txtAmountQTY.Text == "")
                    {
                        btnOk.Enabled = false;
                        btnOk.BackColor = Color.DarkGray;
                    }

                    DateTime startdate = dateTimePicker1.Value;
                    DateTime enddate = dateExpected.Value;
                    txtSubdays.Text = Days1(startdate, enddate).ToString();

                    DateTime StartDate1 = dateTimePicker1.Value;
                    DateTime EndTime1 = dateExpected.Value;
                    txtHours.Text = Hours1(StartDate1, EndTime1).ToString();

                    DateTime date1 = dateTimePicker1.Value;
                    DateTime date2 = dateExpected.Value;

                    TimeSpan difference = date2.Subtract(date1);

                    txtSubdays.Text = Convert.ToInt32(date2.Subtract(date1).Days).ToString();


                    dateExpected.Enabled = false;
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


                    StillReplacementAvoidSend();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "1");
                }

                getLeadTime();
            }

        }

        private void txtAmountQTY_TextChanged(object sender, EventArgs e)
        {
            metroTile1.BackColor = System.Drawing.ColorTranslator.FromHtml("#24262F");
            metroTile1.Enabled = true;
            btnOk.Enabled = false;
            btnOk.BackColor = Color.DarkGray;


            //if (txtAmountQTY.Text == "")
            //{

            //    metroTile1.BackColor = Color.DarkGray;
            //    metroTile1.Enabled = false;
            //}
            dateOrdered.Text = dateTimePicker1.Text;
            dateExpected.Text = dateTimePicker1.Text;
            dateExpected.Enabled = true;
            txtSubdays.Text = "0";
            txtHours.Text = "0";

            if (txtSubdays.Text == "1")
            {
                lbldays.Text = "Day";
            }
            else
            {
                lbldays.Text = "Days";
            }
            if (txtHours.Text == "1")
            {
                lblhours.Text = "Hour";
            }
            else
            {
                lblhours.Text = "Hours";
            }
            //if (status_sent == "Sent")
            //{

            //    //  MessageBox.Show("There is out of stock of " + productname, "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    metroTile1.BackColor = Color.DarkGray;
            //    metroTile1.Enabled = false;
            //    return;
            //}
            //else
            //{

            //    metroTile1.BackColor = System.Drawing.ColorTranslator.FromHtml("#24262F");
            //    metroTile1.Enabled = true;


            //}

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
                txtstock.Text = "";


            }

        }

        private void txtAmountQTY_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        public void subCritic()
        {
            //MySqlConnection Conn = ConString.Connection;




            //string Query = "SELECT  * FROM tbl_product where product_id = '" + lblProductID.Text + "';";
            //MySqlCommand cmd = new MySqlCommand(Query, Conn);
            //MySqlDataReader myReader;

            //try
            //{

            //    myReader = cmd.ExecuteReader();

            //    while (myReader.Read())
            //    {
            //        lblqty.Text = myReader.GetString("stock");
            //        lbloriginalCritical.Text = myReader.GetString("status_new");




            //    }


            //    Conn.Close();


            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Error133");
            //}
        }



        private void metroTile1_Click(object sender, EventArgs e)
        {




            if (txtAmountQTY.Text == "" || txtAmountQTY.Text == "0")
            {
                MessageBox.Show("Please enter amount of QTY.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.None);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtAmountQTY.Text.Trim('0')))
            {
                MessageBox.Show("Enter amount of QTY.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }





            //if (lbloriginalCritical.Text == "Critical Level")
            //{
            //    //   txtstock.ForeColor = Color.Red;

            //    MessageBox.Show("This product is critical level in warehouse. Please order and restock it.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);



            //    //metroTile1.BackColor = System.Drawing.ColorTranslator.FromHtml("#A9A9A9");
            //    //metroTile1.Enabled = false;

            //    return;

            //}
            else
            {
                //    txtstock.ForeColor = System.Drawing.ColorTranslator.FromHtml("#24262F");
                //    metroTile1.BackColor = System.Drawing.ColorTranslator.FromHtml("#24262F");
                //    metroTile1.Enabled = true;

            //    int rQTY = Convert.ToInt32(lblgetcritical.Text) - Convert.ToInt32(lblgetstock.Text);

                try
                {

                    //if (rQTY < int.Parse(txtAmountQTY.Text))
                    //{

                        try
                        {
                            if (int.Parse(txtAmountQTY.Text) <= int.Parse(txtstock.Text))
                            {



                                int val1 = int.Parse(txtstock.Text);
                                int val2 = int.Parse(txtAmountQTY.Text);

                                int val3 = val1 - val2;

                                txtstock.Text = val3.ToString();
                            }
                            else
                            {
                             //   txtAmountQTY.Text = "";

                                MessageBox.Show("Invalid enter amount of QTY.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;

                            }


                        }
                        catch (Exception)
                        {

                        }
                        metroTile1.BackColor = Color.DarkGray;
                        metroTile1.Enabled = false;
                        btnOk.Enabled = true;
                        btnOk.BackColor = System.Drawing.ColorTranslator.FromHtml("#24262F");
                        txtAmountQTY.Enabled = false;

                        try
                        {

                            if (dateTimePicker1.Text != dateExpected.Text)
                            {


                                MySqlConnection Conn = ConString.Connection;
                                string Query = "Update tbl_product set stock = '" + txtstock.Text + "' where product_id = '" + getproductid + "';update tbl_inventory set subQTY = '" + this.txtAmountQTY.Text + "', date_delivered = '" + dateOrdered.Text + "', date_expected = '" + dateExpected.Text + "', subStatus = 'Pending', status = 'Pending' where product_id = '" + getproductid + "' and store_id = '" + cbStoreID.Text + "';update tbl_inventory set status_sent = 'Sent' where qty <= critical and product_id = '" + getproductid + "' and store_id = '" + cbStoreID.Text + "';" +
                                    "update tbl_inventory set r_status = 'Approved' where product_id = '"+getproductid+"' and store_id =  '"+cbStoreID.Text+"'";
                                MySqlCommand cmd = new MySqlCommand(Query, Conn);


                                MySqlDataReader myReader;
                                myReader = cmd.ExecuteReader();



                                while (myReader.Read())
                                {

                                }
                                Conn.Close();
                            }
                            else
                            {
                                MySqlConnection Conn = ConString.Connection;
                                string Query = "Update tbl_product set stock = '" + txtstock.Text + "' where product_id = '" + getproductid + "';update tbl_inventory set subQTY = '" + this.txtAmountQTY.Text + "',  date_delivered = '" + dateOrdered.Text + "', date_expected = '" + dateExpected.Text + "', subStatus = 'OK', status = 'OK'  where product_id = '" + getproductid + "' and store_id = '" + cbStoreID.Text + "';update tbl_inventory set status_sent = 'Sent' where qty <= critical and product_id = '" + getproductid + "' and store_id = '" + cbStoreID.Text + "';update tbl_inventory set r_status = 'Approved' where product_id = '" + getproductid + "' and store_id =  '" + cbStoreID.Text + "'";
                                MySqlCommand cmd = new MySqlCommand(Query, Conn);


                                MySqlDataReader myReader;
                                myReader = cmd.ExecuteReader();



                                while (myReader.Read())
                                {

                                }
                                Conn.Close();
                            }

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }



                        MessageBox.Show("Sent product(s) successfully.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        CriticalLevel1();
                        BranchRefresh();
                        subNotifyBranch();
                        txtAmountQTY.Text = "";

                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[2].Visible = false;


                    dataGridView1.Columns[7].Visible = false;
                    dataGridView1.Columns[8].Visible = false;

                    dataGridView1.Columns[4].Visible = false;
                    dataGridView1.Columns[5].Visible = false;
                    dataGridView1.Columns[6].Visible = false;
                    dataGridView1.Columns[9].Visible = false;

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
                            txtstock.Text = "";
                            return;
                        }
                    //}
                    //else

                    //{
                    //    MessageBox.Show("Send failed. Amount QTY must be not less than than or equal for critical QTY of '" + cbStore.Text + "'", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);


                    //}
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }



        private void btnSort_Click(object sender, EventArgs e)
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

                txtstock.Text = row.Cells[4].Value.ToString();
                productname = row.Cells[1].Value.ToString();


            }
            if (txtstock.Text == "0")
            {
                //  MessageBox.Show("There is out of stock of " + productname, "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAmountQTY.Enabled = false;
                btnOk.Enabled = false;
                metroTile1.Enabled = false;
                btnOk.BackColor = Color.DarkGray;
                metroTile1.BackColor = Color.DarkGray;

            }
            else
            {
              
                btnOk.Enabled = true;
                metroTile1.Enabled = true;
                btnOk.BackColor = System.Drawing.ColorTranslator.FromHtml("#24262F");
                metroTile1.BackColor = System.Drawing.ColorTranslator.FromHtml("#24262F");
            }
            if (txtAmountQTY.Text == "")
            {
                btnOk.Enabled = false;
                btnOk.BackColor = Color.DarkGray;
            }

         //   txtAmountQTY.Text = "";

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
            DateTime startdate = dateTimePicker1.Value;
            DateTime enddate = dateExpected.Value;
            txtSubdays.Text = Days1(startdate, enddate).ToString();



            DateTime date1 = dateTimePicker1.Value;
            DateTime date2 = dateExpected.Value;

            TimeSpan difference = date2.Subtract(date1);

            txtHours.Text = Convert.ToInt32(date2.Subtract(date1).Hours).ToString();

            if (dateTimePicker1.Text == dateExpected.Text)
            {
                txtSubdays.Text = "0";
            }
         //   txtLeadTime.Text = (dateExpected.Value - dateOrdered.Value).TotalDays.ToString("#");

            if ((date2 < date1 && dateTimePicker1.Text != dateExpected.Text))
            {
                //  MessageBox.Show("The date doesn't look right. Be sure to use the actual date.", "Nursery Van System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateExpected.Text = dateTimePicker1.Text;
            }
            if (txtHours.Text.Contains("-"))
            {
                txtHours.Text = "0";
            }
            if (txtSubdays.Text == "1")
            {
                lbldays.Text = "Day";
            }
            else
            {
                lbldays.Text = "Days";
            }
            if (txtHours.Text == "1")
            {
                lblhours.Text = "Hour";
            }
            else
            {
                lblhours.Text = "Hours";
            }
        }

        private void dateOrdered_ValueChanged(object sender, EventArgs e)
        {
            DateTime date1 = dateTimePicker1.Value;
            DateTime date2 = dateExpected.Value;

            TimeSpan difference = date2 - date1;
            txtDays.Text = difference.TotalDays.ToString();
            txtSubdays.Text = difference.TotalDays.ToString();
            txtHours.Text = difference.TotalHours.ToString();
            txtMinutes.Text = difference.TotalMinutes.ToString();
            txtSeconds.Text = difference.TotalSeconds.ToString();
            txtMilliseconds.Text = difference.TotalMilliseconds.ToString();
        }

        private void txtHours_TextChanged(object sender, EventArgs e)
        {
            if (txtHours.Text == "24")
            {
                txtSubdays.Text = "1";
                txtHours.Text = "0";
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
            if (txtHours.Text == "1")
            {
                lblhours.Text = "Hour";
            }
            else
            {
                lblhours.Text = "Hours";
            }
        }

        private void txtSubdays_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
        }

        private void txtHours_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Search product")
            {
                txtSearch.Focus();
                txtSearch.Select(0, 0);

            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtSearch.Text == "Search product")
            {
                txtSearch.Text = "";
            }
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtSearch.Text.Equals(null) == true)
            {
                txtSearch.Text = "Search product";
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


                    txtSearch.Text = "Search product";

                    txtSearch.ForeColor = Color.Gray;
                    Cursor.Current = Cursors.IBeam;


                }
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (txtSearch.Text.Length == 0)
            {
                txtSearch.Text = "Search product";
                txtSearch.ForeColor = SystemColors.GrayText;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {



            try
            {




                MySqlConnection Conn = ConString.Connection;

                DataTable dt = new DataTable();

                if (frm_Login.manager == "Manager")
                {

                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[2].Visible = false;


                    dataGridView1.Columns[7].Visible = false;
                    dataGridView1.Columns[8].Visible = false;

                    dataGridView1.Columns[4].Visible = false;
                    dataGridView1.Columns[5].Visible = false;
                    dataGridView1.Columns[6].Visible = false;
                    dataGridView1.Columns[9].Visible = false;

                }
                MySqlDataAdapter sda = new MySqlDataAdapter("SELECT  tbl_inventory.product_id as 'Product ID', tbl_product.product_name as 'Product Name', QTY as 'QTY in Outlet', tbl_inventory.r_status as 'Status',  tbl_product.stock as 'Stock', tbl_order.date_ordered as 'Delivered', tbl_order.date_expected as 'Expected', tbl_inventory.critical as 'Critical', tbl_inventory.status_sent as 'Status Sent' ,  tbl_order.leadtime1, tbl_inventory.r_qty as 'Requested QTY', tbl_inventory.r_date as 'Date Requested'  FROM tbl_inventory inner join tbl_product on tbl_inventory.product_id = tbl_product.product_id inner join tbl_store on tbl_inventory.store_id = tbl_store.store_id  left join tbl_order on tbl_product.product_id = tbl_order.product_id where tbl_inventory.r_status = 'Requested' and tbl_product.product_name like '%" + txtSearch.Text + "%' and tbl_inventory.store_id = '" + this.cbStoreID.Text + "'  group by tbl_inventory.product_id", Conn);
                sda.Fill(dt);
                Conn.Close();
                dataGridView1.DataSource = dt;

                if (txtSearch.Text == "Search product")
                {
                    DGVstoredisplayproductRequested();

                }
                if (dataGridView1.Rows.Count > 0)
                {
                    txtProductID.Text = (dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                    txtLeadTime.Text = (dataGridView1.SelectedRows[0].Cells[9].Value.ToString());

                }
                getLeadTime();


            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                            metroTile1.BackColor = System.Drawing.ColorTranslator.FromHtml("#24262F");



                            metroTile1.Enabled = true;

                        }
                    }


                }
            }
            catch (NullReferenceException)
            {
                metroTile1.BackColor = Color.DarkGray;
                metroTile1.Enabled = false;
                lblMatch1.Visible = true;
                lblMatch1.Text = "No results found.";
                if (lblMatch1.Visible == true)
                {
                    txtstock.Text = "";
                }

            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.AppStarting;
            var myForm = new frm_EditDateDelivery();
            myForm.ShowDialog();
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

                getStatus = row.Cells[3].Value.ToString();
                getproduct = row.Cells[1].Value.ToString();
                getID = row.Cells[0].Value.ToString();
                txtRqty.Text = row.Cells[2].Value.ToString();
                getqty = row.Cells[4].Value.ToString();
                textBox3.Text = row.Cells[4].Value.ToString();
                getAvailable = row.Cells[5].Value.ToString();
                status.Text = row.Cells[5].Value.ToString();
                lblAvailable.Text = row.Cells[5].Value.ToString();
                dateExpected.Text = row.Cells[6].Value.ToString();

            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage2)
            {
                cbStore1.Text = cbStore.Text;
            }
            else
            {
                cbStore.Text = cbStore1.Text;
            }
            dateExpected1.Text = dateTimePicker1.Text;
            dateExpected.Text = dateTimePicker1.Text;
            if (tabControl1.SelectedTab == tabPage1)
            {
                cbStore1.Visible = false;
                cbStore.Visible = true;
                txtSearch.Visible = true;
                lblrequested.Text = "Outlet";
                lblrequested.Font = new Font("Century Gothic", 10, FontStyle.Regular);
            }
            if (tabControl1.SelectedTab == tabPage2)
            {
                cbStore.Visible = false;
                cbStore1.Visible = true;
                txtSearch.Visible = false;
                lblrequested.Text = "Outlet";

                lblrequested.Font = new Font("Century Gothic", 10, FontStyle.Regular);

                try
                {
                    if (!metroGrid1.Rows[metroGrid1.CurrentCell.RowIndex].IsNewRow)
                    {
                        foreach (DataGridViewCell cell in metroGrid1.Rows[metroGrid1.CurrentCell.RowIndex].Cells)
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

                    if (lblMatch2.Visible == true)
                    {
                        txtstock.Text = "";
                    }
                }
            }

            StillNotAvailable();
        }

        private void cbStore1_TextChanged(object sender, EventArgs e)
        {

            if (frm_Login.manager == "Manager")
            {


                if (cbStore1.Text == "Outlet1")
                {
                    txtAmountQTY.Enabled = false;
                }

                if (cbStore1.Text == "")
                {

                    metroGrid1.Visible = false;
                    btnRedeliver.Enabled = false;
                    btnRedeliver.BackColor = Color.DarkGray;
                    txtRqty.Text = "";

                    return;
                }
                else
                {

                    btnRedeliver.Enabled = true;
                    btnRedeliver.BackColor = System.Drawing.ColorTranslator.FromHtml("#24262F");
                }

                if (cbStore1.Text.Contains(@"\"))
                {
                    return;
                }
                MySqlConnection Conn = ConString.Connection;


                try
                {

                    DataTable dt1 = new DataTable();




                    MySqlDataAdapter sda1 = new MySqlDataAdapter("SELECT tbl_inventory.product_id as 'Product ID', tbl_product.product_name as 'Product Name', qty_replacement as 'QTY Replacement', tbl_inventory.subStatus as 'Status', tbl_inventory.subQTY as 'QTY',  tbl_inventory.status_pending as 'Available',  tbl_inventory.date_expected, tbl_inventory.s_replacement as 'Status Replacement' FROM tbl_inventory inner join tbl_product on tbl_inventory.product_id = tbl_product.product_id inner join tbl_store on tbl_inventory.store_id = tbl_store.store_id  where tbl_inventory.s_replacement = 'Replacement' and tbl_store.store_name like '%" + cbStore1.Text + "' group by tbl_inventory.product_id", Conn);
                    sda1.Fill(dt1);
                    Conn.Close();

                    metroGrid1.DataSource = dt1;






                }


                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


                try
                {
                    if (!metroGrid1.Rows[metroGrid1.CurrentCell.RowIndex].IsNewRow)
                    {
                        foreach (DataGridViewCell cell in metroGrid1.Rows[metroGrid1.CurrentCell.RowIndex].Cells)
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

                    if (lblMatch2.Visible == true)
                    {
                        txtstock.Text = "";
                    }
                }
            }
        }

        private void cbStore1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlConnection Conn = ConString.Connection;


            Cursor.Current = Cursors.WaitCursor;

            string Query = "select * from tbl_store where store_name = '" + cbStore1.SelectedItem.ToString() + "'; ";

            MySqlCommand cmd = new MySqlCommand(Query, Conn);
            MySqlDataReader myReader;

            myReader = cmd.ExecuteReader();
            while (myReader.Read())
            {
                store_id = myReader.GetInt32("store_id");


            }

            Conn.Close();







            subNotifyBranch();


            txtAmountQTY.Enabled = false;
            metroTile1.Enabled = false;

            Conn = ConString.Connection;
            DataTable dt = new DataTable();
            MySqlDataAdapter sda = new MySqlDataAdapter("select * from tbl_store where store_name like '%" + cbStore1.Text + "';", Conn);
            sda.Fill(dt);
            sda.SelectCommand = cmd;
            Conn.Close();
            cbStoreID1.DataSource = dt;
            cbStoreID1.DisplayMember = "store_id";
            cbStoreID1.ValueMember = "store_id";

            if (frm_Login.stockman == "Stockman")
            {
                BranchRefreshStockman();
                ShowDeliverySentForStockman();
                btnEdit.Visible = false;
                btnNP.Visible = false;
                btnRefresh.Visible = false;
                btnCL.Visible = false;
                btnBO.Visible = false;
                lblN1.Visible = false;
                lblN2.Visible = false;
                lblN3.Visible = false;
                txtSearch.Visible = false;
                groupBox1.Visible = false;
                groupBox2.Visible = false;
                btnRedeliver.Visible = false;
                btnOk.Visible = false;
                label11.Visible = false;
                label41.Visible = false;
                label10.Visible = false;
                txtRqty.Visible = false;
                label9.Visible = false;
                txtAmountQTY.Visible = false;
                label2.Visible = false;
                txtstock.Visible = false;
                label1.Visible = false;
                lbloriginalCritical.Visible = false;

                metroGrid1.Visible = false;

                if (frm_Login.manager == "Manager")
                {

                 
                


                    metroGrid1.Columns[4].Visible = false;
                    metroGrid1.Columns[5].Visible = false;
                    metroGrid1.Columns[6].Visible = false;
                    metroGrid1.Columns[3].Visible = false;
                    BranchRefresh1();
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[2].Visible = false;


                    dataGridView1.Columns[7].Visible = false;
                    dataGridView1.Columns[8].Visible = false;
                    dataGridView1.Columns[4].Visible = false;
                    dataGridView1.Columns[5].Visible = false;
                    dataGridView1.Columns[6].Visible = false;
                    dataGridView1.Columns[9].Visible = false;
                }


            }
            if (txtAmountQTY.Enabled == true)
            {
                txtAmountQTY.Enabled = false;
                return;
            }
        }

        void ShowDeliverySentForStockman()
        {
         

            MySqlConnection Conn = ConString.Connection;
            MySqlCommand cmd = new MySqlCommand("SELECT  tbl_product.product_name as 'Product Name',  tbl_inventory.subQTY as 'Delivery QTY', tbl_inventory.r_date as 'Date Requested', tbl_inventory.date_expected as 'Delivery Date',  tbl_inventory.r_status as 'Status'  FROM tbl_inventory inner join tbl_product on tbl_inventory.product_id = tbl_product.product_id inner join tbl_store on tbl_inventory.store_id = tbl_store.store_id  left join tbl_order on tbl_product.product_id = tbl_order.product_id where tbl_inventory.r_status = 'Approved' and tbl_inventory.store_id = '" + this.cbStoreID.Text + "' group by tbl_inventory.product_id", Conn);


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
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;


                Conn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        void ShowDeliverySentForStockmanBackordered()
        {


            MySqlConnection Conn = ConString.Connection;
            MySqlCommand cmd = new MySqlCommand("SELECT  tbl_inventory.product_id as 'Product ID', tbl_product.product_name as 'Product Name', QTY as 'QTY in Outlet', tbl_inventory.status as 'Status',  tbl_product.stock as 'Stock', tbl_order.date_ordered as 'Delivered', tbl_order.date_expected as 'Expected', tbl_inventory.critical as 'Critical',tbl_inventory.status_sent as 'Status Sent', tbl_order.leadtime1   FROM tbl_inventory inner join tbl_product on tbl_inventory.product_id = tbl_product.product_id inner join tbl_store on tbl_inventory.store_id = tbl_store.store_id  left join tbl_order on tbl_product.product_id = tbl_order.product_id where" +
                " tbl_inventory.status_sent = 'Sent' and tbl_inventory.store_id = '" + this.cbStoreID.Text + "' and tbl_inventory.s_replacement = 'Backordered' and tbl_inventory.store_id = '" + this.cbStoreID.Text + "' group by tbl_inventory.product_id", Conn);


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
                metroGrid1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;


                Conn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnRedeliver_Click(object sender, EventArgs e)
        {
            if (lblAvailable.Text == "Available")
            {

                if (txtSubdays.Text != "0")
                {


                    MySqlConnection Conn = ConString.Connection;
                    string Query = "Update tbl_inventory set r_backstatus = 'BO', r_backqty = '" + Convert.ToInt32(txtRqty.Text) + "', subQTY =  '" + Convert.ToInt32(txtRqty.Text) + "', date_delivered = '" + dateTimePicker1.Text + "', date_expected = '" + dateExpected1.Text + "', subStatus = 'Backorder Pending', s_replacement = 'Backordered', status = 'Pending', status_sent = 'Sent', r_status = 'Approved' where product_id = '" + getID + "' and store_id = '" + cbStoreID1.Text + "'";
                    MySqlCommand cmd = new MySqlCommand(Query, Conn);


                    MySqlDataReader myReader;
                    myReader = cmd.ExecuteReader();

                    //   MessageBox.Show("A");

                    while (myReader.Read())
                    {

                    }
                    Conn.Close();

                    //  return;
                }
                if (txtSubdays.Text == "0")
                {
                    MySqlConnection Conn = ConString.Connection;
                   string Query = "Update tbl_inventory set r_backstatus = 'BO', r_backqty = '" + Convert.ToInt32(txtRqty.Text) + "', subQTY = '" + Convert.ToInt32(txtRqty.Text) + "', date_delivered = '" + dateTimePicker1.Text + "', date_expected = '" + dateExpected1.Text + "', subStatus = 'OK', status = 'OK', s_replacement = 'Backorder',status_sent = 'Sent', r_status = 'Approved' where product_id = '" + getID + "' and store_id = '" + cbStoreID1.Text + "'";
                    MySqlCommand cmd = new MySqlCommand(Query, Conn);

                    MySqlDataReader myReader;
                    myReader = cmd.ExecuteReader();


                    //     MessageBox.Show("B");
                    while (myReader.Read())
                    {

                    }
                    Conn.Close();

                }
            }
            else
            {


                if (dateExpected1.Text != dateOrdered.Text)
                {
                    if (status.Text == "Pending")
                    {
                        MessageBox.Show("Please restock first the QTY received of product: " + getproduct + " before adjust the delivery date.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    MySqlConnection Conn = ConString.Connection;
                    string Query = "Update tbl_inventory set r_backstatus = 'BO', r_backqty = '" + Convert.ToInt32(txtRqty.Text) + "', subQTY = '" + Convert.ToInt32(textBox3.Text) + "' + '" + Convert.ToInt32(txtRqty.Text) + "', date_delivered = '" + dateTimePicker1.Text + "', date_expected = '" + dateExpected1.Text + "', subStatus = 'Pending', status = 'Pending', s_replacement = 'Redelivered',status_sent = 'Sent', r_status = 'Approved' where product_id = '" + getID + "' and store_id = '" + cbStoreID1.Text + "'";
                    MySqlCommand cmd = new MySqlCommand(Query, Conn);


                    MySqlDataReader myReader;
                    myReader = cmd.ExecuteReader();

                    //   MessageBox.Show("C");

                    while (myReader.Read())
                    {

                    }
                    Conn.Close();
                }

                else
                {
                    MySqlConnection Conn = ConString.Connection;
                    string Query = "Update tbl_inventory set r_backstatus = 'BO', r_backqty = '" + Convert.ToInt32(txtRqty.Text) + "', subQTY = '" + Convert.ToInt32(textBox3.Text) + "' + '" + Convert.ToInt32(txtRqty.Text) + "', date_delivered = '" + dateTimePicker1.Text + "', date_expected = '" + dateExpected1.Text + "', subStatus = 'OK',status = 'OK', s_replacement = 'Redelivered',status_sent = 'Sent', r_status = 'Approved' where product_id = '" + getID + "' and store_id = '" + cbStoreID1.Text + "'";
                    MySqlCommand cmd = new MySqlCommand(Query, Conn);


                    MySqlDataReader myReader;
                    myReader = cmd.ExecuteReader();

                    //   MessageBox.Show("D");

                    while (myReader.Read())
                    {

                    }
                    Conn.Close();
                }



            }
            //if (DateTime.Today == dateExpected.Value)
            // {
            //     MySqlConnection Conn = ConString.Connection;
            //     string Query = "Update tbl_inventory set subQTY = '" + Convert.ToInt32(txtRqty.Text) + "', date_delivered = '" + dateTimePicker1.Text + "', date_expected = '" + dateExpected1.Text + "', subStatus = 'OK', s_replacement = 'Backorder' where product_id = '" + getID + "' and store_id = '" + cbStoreID1.Text + "'";
            //     MySqlCommand cmd = new MySqlCommand(Query, Conn);


            //     MySqlDataReader myReader;
            //     myReader = cmd.ExecuteReader();


            //         MessageBox.Show("B");
            //         while (myReader.Read())
            //     {

            //     }
            //     Conn.Close();

            // }
            MessageBox.Show("Sent product(s) successfully.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            BranchRefresh1();
            subNotifyBranch();


            MySqlConnection Conn1 = ConString.Connection;
            DataTable dt = new DataTable();
            MySqlDataAdapter sda = new MySqlDataAdapter("SELECT tbl_store.store_name as 'Store' FROM tbl_inventory inner join tbl_product on tbl_inventory.product_id = tbl_product.product_id inner join tbl_store on tbl_inventory.store_id = tbl_store.store_id where tbl_inventory.s_replacement = 'Replacement' group by tbl_store.store_name;", Conn1);
            sda.Fill(dt);

            //pause

            cbStore1.DataSource = dt;

            cbStore1.DisplayMember = "Store";
            cbStore1.ValueMember = "Store";
            DataTable dbdataset = new DataTable();
            sda.Fill(dbdataset);
            BindingSource bSource = new BindingSource();

            bSource.DataSource = dbdataset;

            cbStore1.DataSource = bSource;
            sda.Update(dbdataset);

            Conn1.Close();

            try
            {
                if (!metroGrid1.Rows[metroGrid1.CurrentCell.RowIndex].IsNewRow)
                {
                    foreach (DataGridViewCell cell1 in metroGrid1.Rows[metroGrid1.CurrentCell.RowIndex].Cells)
                    {
                        btnRedeliver.Enabled = true;
                        btnRedeliver.BackColor = System.Drawing.ColorTranslator.FromHtml("#24262F");
                        if (cell1.Value == System.DBNull.Value)
                        {

                        }
                    }


                }
            }
            catch (NullReferenceException)
            {
                btnRedeliver.Enabled = false;
                btnRedeliver.BackColor = Color.DarkGray;
                txtRqty.Text = "";
                return;
            }
        }

        private void dateExpected1_ValueChanged(object sender, EventArgs e)
        {
            DateTime startdate = dateTimePicker1.Value;
            DateTime enddate = dateExpected1.Value;
            txtSubdays.Text = Days1(startdate, enddate).ToString();



            DateTime date1 = dateTimePicker1.Value;
            DateTime date2 = dateExpected1.Value;

            TimeSpan difference = date2.Subtract(date1);

            txtHours.Text = Convert.ToInt32(date2.Subtract(date1).Hours).ToString();

            if (dateTimePicker1.Text == dateExpected1.Text)
            {
                txtSubdays.Text = "0";
            }

            //if ((date2 < date1 && dateTimePicker1.Text != dateExpected1.Text))
            //{
            //    //  MessageBox.Show("The date doesn't look right. Be sure to use the actual date.", "Nursery Van System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    dateExpected1.Text = dateTimePicker1.Text;
            //}
            if (txtHours.Text.Contains("-"))
            {
                txtHours.Text = "0";
            }
            if (txtSubdays.Text == "1")
            {
                lbldays.Text = "Day";
            }
            else
            {
                lbldays.Text = "Days";
            }
            if (txtHours.Text == "1")
            {
                lblhours.Text = "Hour";
            }
            else
            {
                lblhours.Text = "Hours";
            }
        }

        private void dateOrdered1_ValueChanged(object sender, EventArgs e)
        {
            DateTime date1 = dateTimePicker1.Value;
            DateTime date2 = dateExpected1.Value;

            TimeSpan difference = date2 - date1;
            txtDays.Text = difference.TotalDays.ToString();
            txtSubdays.Text = difference.TotalDays.ToString();
            txtHours.Text = difference.TotalHours.ToString();
            txtMinutes.Text = difference.TotalMinutes.ToString();
            txtSeconds.Text = difference.TotalSeconds.ToString();
            txtMilliseconds.Text = difference.TotalMilliseconds.ToString();
        }

        private void btnManage_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.AppStarting;
            var myForm = new frm_edit_replacement();
            myForm.ShowDialog();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtAmountQTY.Enabled = true;

        }

        private void btnNP_Click(object sender, EventArgs e)
        {
            if (int.Parse(lblN1.Text) != 0)
            {
                MySqlConnection Conn = ConString.Connection;

                DataTable dt = new DataTable();


                MySqlDataAdapter sda = new MySqlDataAdapter("SELECT  tbl_inventory.product_id as 'Product ID', tbl_product.product_name as 'Product Name', QTY as 'QTY in Outlet', tbl_inventory.r_status as 'Status',  tbl_product.stock as 'Stock', tbl_order.date_ordered as 'Delivered', tbl_order.date_expected as 'Expected', tbl_inventory.critical as 'Critical',tbl_inventory.status_sent as 'Status Sent', tbl_order.leadtime1, tbl_inventory.r_qty as 'Requested QTY', tbl_inventory.r_date as 'Date Requested'   FROM tbl_inventory inner join tbl_product on tbl_inventory.product_id = tbl_product.product_id inner join tbl_store on tbl_inventory.store_id = tbl_store.store_id  left join tbl_order on tbl_product.product_id = tbl_order.product_id where tbl_inventory.status = 'New Product' and tbl_inventory.store_id = '" + this.cbStoreID.Text + "' group by tbl_inventory.product_id", Conn);
                sda.Fill(dt);
                Conn.Close();
                dataGridView1.DataSource = dt;

                if (frm_Login.manager == "Manager")
                {
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[2].Visible = false;


                    dataGridView1.Columns[7].Visible = false;
                    dataGridView1.Columns[8].Visible = false;
                    dataGridView1.Columns[4].Visible = false;
                    dataGridView1.Columns[5].Visible = false;
                    dataGridView1.Columns[6].Visible = false;
                    dataGridView1.Columns[9].Visible = false;
                }


            }
            else
            {
                DGVstoredisplayproductRequested();
            }
        }
        public void StillReplacementAvoidSend()
        {
            //MySqlConnection Conn = ConString.Connection;


            //AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();

            //string Query = "SELECT * FROM tbl_inventory where store_id = '" + cbStoreID.Text + "' and product_id = '" + lblProductID.Text + "' and s_replacement = 'Replacement';";
            //MySqlCommand cmd = new MySqlCommand(Query, Conn);
            //MySqlDataReader myReader;

            //try
            //{

            //    myReader = cmd.ExecuteReader();

            //    if (myReader.Read())
            //    {
            //        metroTile1.BackColor = Color.DarkGray;
            //        metroTile1.Enabled = false;
            //      //  MessageBox.Show("Backorder is currently process.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.None);


            //    }


            //    Conn.Close();



            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Error13");
            //}
        }
        private void btnCL_Click(object sender, EventArgs e)
        {


        }

        private void btnBO_Click(object sender, EventArgs e)
        {

            //if (int.Parse(lblN3.Text) != 0)
            //{
            //    tabControl1.SelectedTab = tabPage2;
            //    cbStore1.Text = cbStore.Text;
            //}
            //else
            //{
            //    tabControl1.SelectedTab = tabPage1;

            //}


        }

        private void metroTile5_Click(object sender, EventArgs e)
        {
            BranchRefresh();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            StillReplacementAvoidSend();
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            //DGVstoredisplayproductRequested();
            //DGVReplacement();
            //BranchRefresh();
            //refreshOutlets();
            //subNotifyBranch();
            //dataGridView1.Columns[0].Visible = false;
            //dataGridView1.Columns[2].Visible = false;


            //dataGridView1.Columns[7].Visible = false;
            //dataGridView1.Columns[8].Visible = false;

            //dataGridView1.Columns[4].Visible = false;
            //dataGridView1.Columns[5].Visible = false;
            //dataGridView1.Columns[6].Visible = false;
            //dataGridView1.Columns[9].Visible = false;

            //this.Update();



            var pleaseWait = new frm_Request();
            pleaseWait.ShowDialog();
            Application.DoEvents();
            Cursor.Current = Cursors.WaitCursor;     
            this.Hide();
        }

        public void refreshOutlets()
        {

            MySqlConnection Conn = ConString.Connection;



            string Query = "SELECT tbl_store.store_name as 'Store' FROM tbl_inventory inner join tbl_product on tbl_inventory.product_id = tbl_product.product_id inner join tbl_store on tbl_inventory.store_id = tbl_store.store_id where tbl_inventory.r_status = 'Requested' group by tbl_store.store_name;";

            MySqlCommand cmd = new MySqlCommand(Query, Conn);


            DataTable dt = new DataTable();
            MySqlDataAdapter sda = new MySqlDataAdapter("SELECT tbl_store.store_name as 'Store' FROM tbl_inventory inner join tbl_product on tbl_inventory.product_id = tbl_product.product_id inner join tbl_store on tbl_inventory.store_id = tbl_store.store_id where tbl_inventory.r_status = 'Requested' group by tbl_store.store_name;", Conn);
            sda.Fill(dt);
            sda.SelectCommand = cmd;

            cbStore1.DataSource = dt;


            cbStore1.DisplayMember = "Store";
            cbStore1.ValueMember = "Store";


            DataTable dbdataset = new DataTable();
            sda.Fill(dbdataset);
            BindingSource bSource = new BindingSource();

            bSource.DataSource = dbdataset;
            cbStore1.DataSource = bSource;


            sda.Update(dbdataset);
            Conn.Close();
        }
        void getLeadTime()
        {

          
            MySqlConnection Conn = ConString.Connection;
         
            string Query = "SELECT timestampdiff(day, date(now()), date_expected) as 'LeadTime' FROM tbl_order where product_id = '"+txtProductID.Text+"' and status = 'Pending Ordered'";
      
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
        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                txtProductID.Text = (dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                txtLeadTime.Text = (dataGridView1.SelectedRows[0].Cells[9].Value.ToString());

            }
            getLeadTime();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
        
        }

        private void tabControl1_MouseHover(object sender, EventArgs e)
        {
            txtAmountQTY.Enabled = false;
        }

        private void cbStore1_Click(object sender, EventArgs e)
        {

            txtAmountQTY.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var myform = new frm_Request();
            myform.ShowDialog();
            this.Hide();
        }

        private void btnCL1_Click(object sender, EventArgs e)
        {

            if (int.Parse(lblN3.Text) != 0)
            {
                tabControl1.SelectedTab = tabPage2;
                cbStore1.Text = cbStore.Text;
            }
            else
            {
                tabControl1.SelectedTab = tabPage1;

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
