using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using DGVPrinterHelper;
using MySql.Data.MySqlClient;
using NurseryVan_System.Database;

namespace NurseryVan_System
{
    public partial class frm_Report : Form
    {
        public static string manager;
        int store_id;
        public static string global_store_id;
        int salary = 7000;
        public static DataGridView datagrid1;
        public static DataGridView datagrid2;
        public static DataGridView datagrid3;
        public static DataGridView datagrid4;
        int top_id;
        int top_id2;
        public frm_Report()
        {
            InitializeComponent();
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
        }
        public void NotificationofCriticalLevel_Warehouse()
        {

            MySqlConnection Conn = ConString.Connection;

            string Query = "Select sum(Critical_All)  as 'CriticalAll' from ((SELECT *  FROM (   Select '1' as ID, count(*)   as Critical_All from (SELECT count(tbl_product.product_id)  from tbl_product where tbl_product.status_new = 'Critical Level' group by tbl_product.product_id order by count(tbl_product.product_id)) as DerivedTableAlias) AS A) UNION (SELECT *  FROM ( Select '2' as ID, count(*) as Expiry from (SELECT count(tbl_expiry.product_id), count(tbl_expiry.date_expiry) FROM tbl_expiry inner join tbl_product on tbl_expiry.product_id = tbl_product.product_id where " +
                "datediff( tbl_expiry.date_expiry, date(now())) <= tbl_product.notify_days and tbl_expiry.status != 'Removed' and tbl_expiry.date_expiry <= date(now()) and tbl_expiry.status = 'Expired' or  datediff( tbl_expiry.date_expiry, date(now())) < tbl_product.notify_days and tbl_expiry.status != 'Removed' and tbl_expiry.date_expiry > date(now()) and tbl_expiry.status = 'Soon to Expire' group by tbl_expiry.product_id, tbl_expiry.date_expiry order by count(tbl_expiry.product_id), count(tbl_expiry.date_expiry)) as DerivedTableAlias) AS B)) as subAlias";
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
        private void frm_Report_Load(object sender, EventArgs e)
        {
            NotificationofCriticalLevel_Warehouse();
            DailyReport();
            WeeklyReport();
           
            MonthlyReport();
            YearlyReport();
            subYearly();
            CriticalLevel();
            changeRowColor1();
            DGVInventoryProductList();
            DGVPaymenttoSupplierReport();
            changeRowColor1();
            DGVWarehouseBackorder();
            DGVWarehouseCritical();
            StartTimer();
            ComboboxofStore();

         
            datagrid1 = dataGridView1;
            datagrid2 = dataGridView2;
            datagrid3 = dataGridView3;
            datagrid4 = dataGridView4;

            //dateTimePicker3.Value = dateTimePicker3.Value.AddDays(+7);
            //dateTimePicker5.Value = dateTimePicker5.Value.AddMonths(+1);
            //dateTimePicker7.Value = dateTimePicker7.Value.AddYears(+1);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            dataGridView4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;


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
        void DailyReport()
        {
            // titlereport = "Daily Report";
          
            MySqlConnection Conn = ConString.Connection;
            //   MySqlCommand cmd = new MySqlCommand("SELECT tbl_product.category as 'Category', tbl_product.product_name as 'Product Name', tbl_product.remarks as 'SRP', sum(tbl_transactionrecord.quantity) as 'Quantity', sum(tbl_transactionrecord.amount) as 'Amount' FROM tbl_product right join tbl_transactionrecord on tbl_product.product_id = tbl_transactionrecord.product_id where tbl_transactionrecord.date >= DATE(NOW()) and tbl_transactionrecord.status = 'sold' and tbl_transactionrecord.store_id = '" + txtstore_id.Text+ "' group by tbl_product.product_id order by tbl_transactionrecord.time desc;", Conn);
            MySqlCommand cmd = new MySqlCommand("SELECT tbl_product.category as 'Category', tbl_product.product_name as 'Product Name', tbl_product.remarks as 'SRP', sum(tbl_critical.quantity) as 'Quantity', sum(tbl_critical.quantity) * tbl_product.remarks as 'Amount' FROM tbl_product inner join tbl_critical on tbl_product.product_id = tbl_critical.product_id where tbl_critical.date >= DATE(NOW())  and tbl_critical.store_id = '" + txtstore_id.Text + "' group by tbl_product.product_id order by tbl_critical.date asc;", Conn);


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


        void DailyQuantityReportGraph()
        {
            // titlereport = "Daily Report";
            MySqlConnection Conn = ConString.Connection;
            //   MySqlCommand cmd = new MySqlCommand("SELECT tbl_product.category as 'Category', tbl_product.product_name as 'Product Name', tbl_product.remarks as 'SRP', sum(tbl_transactionrecord.quantity) as 'Quantity', sum(tbl_transactionrecord.amount) as 'Amount' FROM tbl_product right join tbl_transactionrecord on tbl_product.product_id = tbl_transactionrecord.product_id where tbl_transactionrecord.date >= DATE(NOW()) and tbl_transactionrecord.status = 'sold' and tbl_transactionrecord.store_id = '" + txtstore_id.Text + "' group by tbl_product.Category order by Quantity desc;", Conn);
            MySqlCommand cmd = new MySqlCommand("SELECT tbl_product.category as 'Category', tbl_product.product_name as 'Product Name', tbl_product.remarks as 'SRP', sum(tbl_critical.quantity) as 'Quantity', sum(tbl_critical.quantity) * tbl_product.remarks as 'Amount' FROM tbl_product inner join tbl_critical on tbl_product.product_id = tbl_critical.product_id where tbl_critical.date >= DATE(NOW())  and tbl_critical.store_id = '"+txtstore_id.Text+"' group by tbl_product.Category order by Quantity desc;", Conn);
            try
            {



                MySqlDataReader myReader;

                myReader = cmd.ExecuteReader();

                while (myReader.Read())
                {
                    chartDaily.Series["Daily Sales"].Points.AddXY(myReader.GetString("Category"), myReader.GetInt32("Quantity"));





                    chartDaily.Series["Daily Sales"].IsValueShownAsLabel = true;




                    chartDaily.Series["Daily Sales"].XValueMember = myReader.GetString("Category");
                    chartDaily.Series["Daily Sales"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;

                    chartDaily.Series["Daily Sales"].YValueMembers = myReader.GetString("Quantity");
                    chartDaily.Series["Daily Sales"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;



                }
                Conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("keme14" + ex.Message);
            }
        }


        void DailySalesReportGraph()
        {
            // titlereport = "Daily Report";
            MySqlConnection Conn = ConString.Connection;
            //   MySqlCommand cmd = new MySqlCommand("SELECT tbl_product.category as 'Category', tbl_product.product_name as 'Product Name', tbl_product.remarks as 'SRP', sum(tbl_transactionrecord.quantity) as 'Quantity', sum(tbl_transactionrecord.amount) as 'Amount' FROM tbl_product right join tbl_transactionrecord on tbl_product.product_id = tbl_transactionrecord.product_id where tbl_transactionrecord.date >= DATE(NOW()) and tbl_transactionrecord.status = 'sold' and tbl_transactionrecord.store_id = '" + txtstore_id.Text + "' group by tbl_product.Category order by Amount desc;", Conn);
            MySqlCommand cmd = new MySqlCommand("SELECT tbl_product.category as 'Category', tbl_product.product_name as 'Product Name', tbl_product.remarks as 'SRP', sum(tbl_critical.quantity) as 'Quantity', sum(tbl_critical.quantity) * tbl_product.remarks as 'Amount' FROM tbl_product inner join tbl_critical on tbl_product.product_id = tbl_critical.product_id where tbl_critical.date >= DATE(NOW())  and tbl_critical.store_id = '" + txtstore_id.Text + "' group by tbl_product.Category order by Amount desc;", Conn);
            try
            {




                MySqlDataReader myReader;

                myReader = cmd.ExecuteReader();

                while (myReader.Read())
                {
                    chartDaily.Series["Daily Sales"].Points.AddXY(myReader.GetString("Category"), myReader.GetDecimal("Amount"));





                    chartDaily.Series["Daily Sales"].IsValueShownAsLabel = true;




                    chartDaily.Series["Daily Sales"].XValueMember = myReader.GetString("Category");
                    chartDaily.Series["Daily Sales"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;

                    chartDaily.Series["Daily Sales"].YValueMembers = myReader.GetString("Amount");
                    chartDaily.Series["Daily Sales"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;


                }
                Conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("keme15" + ex.Message);
            }
        }





        void WeeklyReport()
        {
            // titlereport = "Daily Report";
            MySqlConnection Conn = ConString.Connection;
            //     MySqlCommand cmd = new MySqlCommand("SELECT tbl_product.category as 'Category', tbl_product.product_name as 'Product Name', tbl_product.Remarks as 'SRP', sum(tbl_transactionrecord.quantity) as 'Quantity', sum(tbl_transactionrecord.amount) as 'Amount', dayname(tbl_transactionrecord.Date) as 'Day', date(tbl_transactionrecord.Date) as 'Date' FROM tbl_product inner join tbl_transactionrecord on tbl_product.product_id = tbl_transactionrecord.product_id where weekofyear(tbl_transactionrecord.date) = weekofyear(NOW()) and tbl_transactionrecord.status = 'sold' and tbl_transactionrecord.store_id = '" + txtstore_id.Text + "' group by tbl_product.product_id order by tbl_transactionrecord.date asc;", Conn);

            MySqlCommand cmd = new MySqlCommand("SELECT tbl_product.category as 'Category', tbl_product.product_name as 'Product Name', tbl_product.remarks as 'SRP', sum(tbl_critical.quantity) as 'Quantity', sum(tbl_critical.quantity) * tbl_product.remarks as 'Amount', dayname(tbl_critical.date) as 'Day', date(tbl_critical.date) as 'Date' FROM tbl_product inner join tbl_critical on tbl_product.product_id = tbl_critical.product_id where weekofyear(tbl_critical.date) = weekofyear(NOW())  and tbl_critical.store_id = '" + txtstore_id.Text + "' group by tbl_product.product_id order by tbl_critical.date asc;", Conn);
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
                    this.dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                //  this.dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                Conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("keme" + ex.Message);
            }
        }
        void WeeklyQuantityReportGraph()
        { 
            // titlereport = "Daily Report";
            MySqlConnection Conn = ConString.Connection;
            //    MySqlCommand cmd = new MySqlCommand("SELECT tbl_product.category as 'Category', tbl_product.product_name as 'Product Name', tbl_product.Remarks as 'SRP', sum(tbl_transactionrecord.quantity) as 'Quantity', sum(tbl_transactionrecord.amount) as 'Amount', dayname(tbl_transactionrecord.Date) as 'Day', date(tbl_transactionrecord.Date) as 'Date' FROM tbl_product inner join tbl_transactionrecord on tbl_product.product_id = tbl_transactionrecord.product_id where weekofyear(tbl_transactionrecord.date) = weekofyear(NOW()) and tbl_transactionrecord.status = 'sold' and tbl_transactionrecord.store_id = '"+txtstore_id.Text+ "' group by tbl_product.Category order by Quantity desc;", Conn);
            MySqlCommand cmd = new MySqlCommand("SELECT tbl_product.category as 'Category', tbl_product.product_name as 'Product Name', tbl_product.remarks as 'SRP', sum(tbl_critical.quantity) as 'Quantity', sum(tbl_critical.quantity) * tbl_product.remarks as 'Amount', dayname(tbl_critical.date) as 'Day', date(tbl_critical.date) as 'Date' FROM tbl_product inner join tbl_critical on tbl_product.product_id = tbl_critical.product_id where weekofyear(tbl_critical.date) = weekofyear(NOW())  and tbl_critical.store_id = '" + txtstore_id.Text + "' group by tbl_product.Category order by Quantity desc;", Conn);
            try
            {


               
                MySqlDataReader myReader;

                myReader = cmd.ExecuteReader();

                while (myReader.Read())
                {
                    chartWeekly.Series["Weekly Sales"].Points.AddXY(myReader.GetString("Category"), myReader.GetInt32("Quantity"));

                    



                    chartWeekly.Series["Weekly Sales"].IsValueShownAsLabel = true;

               


                    chartWeekly.Series["Weekly Sales"].XValueMember = myReader.GetString("Category");
                    chartWeekly.Series["Weekly Sales"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;

                    chartWeekly.Series["Weekly Sales"].YValueMembers = myReader.GetString("Quantity");
                    chartWeekly.Series["Weekly Sales"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
                  


                }
                Conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("keme17" + ex.Message);
            }
        }


        void WeeklySalesReportGraph()
        {
            // titlereport = "Daily Report";
            MySqlConnection Conn = ConString.Connection;
            //   MySqlCommand cmd = new MySqlCommand("SELECT tbl_product.category as 'Category', tbl_product.product_name as 'Product Name', tbl_product.Remarks as 'SRP', sum(tbl_transactionrecord.quantity) as 'Quantity', sum(tbl_transactionrecord.amount) as 'Amount', dayname(tbl_transactionrecord.Date) as 'Day', date(tbl_transactionrecord.Date) as 'Date' FROM tbl_product inner join tbl_transactionrecord on tbl_product.product_id = tbl_transactionrecord.product_id where weekofyear(tbl_transactionrecord.date) = weekofyear(NOW()) and tbl_transactionrecord.status = 'sold' and tbl_transactionrecord.store_id = '" + txtstore_id.Text + "' group by tbl_product.Category order by Amount desc;", Conn);
            MySqlCommand cmd = new MySqlCommand("SELECT tbl_product.category as 'Category', tbl_product.product_name as 'Product Name', tbl_product.remarks as 'SRP', sum(tbl_critical.quantity) as 'Quantity', sum(tbl_critical.quantity) * tbl_product.remarks as 'Amount', dayname(tbl_critical.date) as 'Day', date(tbl_critical.date) as 'Date' FROM tbl_product inner join tbl_critical on tbl_product.product_id = tbl_critical.product_id where weekofyear(tbl_critical.date) = weekofyear(NOW())  and tbl_critical.store_id = '" + txtstore_id.Text + "' group by tbl_product.Category order by Amount desc;", Conn);
            try
            {




                MySqlDataReader myReader;

                myReader = cmd.ExecuteReader();

                while (myReader.Read())
                {
                    chartWeekly.Series["Weekly Sales"].Points.AddXY(myReader.GetString("Category"), myReader.GetDecimal("Amount"));






                    chartWeekly.Series["Weekly Sales"].IsValueShownAsLabel = true;




                    chartWeekly.Series["Weekly Sales"].XValueMember = myReader.GetString("Category");
                    chartWeekly.Series["Weekly Sales"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;

                    chartWeekly.Series["Weekly Sales"].YValueMembers = myReader.GetString("Amount");
                    chartWeekly.Series["Weekly Sales"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;


                }
                Conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("keme18" + ex.Message);
            }
        }

       
        void MonthlyReport()
        {
            // titlereport = "Daily Report";
            MySqlConnection Conn = ConString.Connection;
            //   MySqlCommand cmd = new MySqlCommand("SELECT tbl_product.category as 'Category', tbl_product.product_name as 'Product Name', tbl_product.remarks as 'SRP', sum(tbl_transactionrecord.quantity) as 'Quantity', sum(tbl_transactionrecord.amount) as 'Amount', week(tbl_transactionrecord.Date) as 'Week', date(tbl_transactionrecord.Date) as 'Date' FROM tbl_product inner join tbl_transactionrecord on tbl_product.product_id = tbl_transactionrecord.product_id where month(tbl_transactionrecord.date) = Month(NOW()) and tbl_transactionrecord.status = 'sold' and tbl_transactionrecord.store_id = '" + txtstore_id.Text + "'  group by tbl_product.product_id order by tbl_transactionrecord.date asc;", Conn);
            MySqlCommand cmd = new MySqlCommand("SELECT tbl_product.category as 'Category', tbl_product.product_name as 'Product Name', tbl_product.remarks as 'SRP', sum(tbl_critical.quantity) as 'Quantity', sum(tbl_critical.quantity) * tbl_product.remarks as 'Amount', week(tbl_critical.date) as 'Week', date(tbl_critical.date) as 'Date' FROM tbl_product inner join tbl_critical on tbl_product.product_id = tbl_critical.product_id where month(tbl_critical.date) = Month(NOW())  and tbl_critical.store_id = '" + txtstore_id.Text + "' group by tbl_product.product_id order by tbl_critical.date asc;", Conn);

            try
            {

                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmd;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bSource = new BindingSource();

                bSource.DataSource = dbdataset;
                dataGridView3.DataSource = bSource;
                sda.Update(dbdataset);
               this.dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                //  this.dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                Conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void MonthlyQuantityReportGraph()
        {
            // titlereport = "Daily Report";
            MySqlConnection Conn = ConString.Connection;
            //    MySqlCommand cmd = new MySqlCommand("SELECT tbl_product.category as 'Category', tbl_product.product_name as 'Product Name', tbl_product.remarks as 'SRP', sum(tbl_transactionrecord.quantity) as 'Quantity', sum(tbl_transactionrecord.amount) as 'Amount', week(tbl_transactionrecord.Date) as 'Week', date(tbl_transactionrecord.Date) as 'Date' FROM tbl_product inner join tbl_transactionrecord on tbl_product.product_id = tbl_transactionrecord.product_id where month(tbl_transactionrecord.date) = Month(NOW()) and tbl_transactionrecord.status = 'sold' and tbl_transactionrecord.store_id = '" + txtstore_id.Text + "'  group by tbl_product.category order by Quantity desc;", Conn);
            MySqlCommand cmd = new MySqlCommand("SELECT tbl_product.category as 'Category', tbl_product.product_name as 'Product Name', tbl_product.remarks as 'SRP', sum(tbl_critical.quantity) as 'Quantity', sum(tbl_critical.quantity) * tbl_product.remarks as 'Amount', week(tbl_critical.date) as 'Week', date(tbl_critical.date) as 'Date' FROM tbl_product inner join tbl_critical on tbl_product.product_id = tbl_critical.product_id where month(tbl_critical.date) = Month(NOW())  and tbl_critical.store_id = '" + txtstore_id.Text + "' group by tbl_product.Category order by Quantity desc;", Conn);
            try
            {



                MySqlDataReader myReader;

                myReader = cmd.ExecuteReader();

                while (myReader.Read())
                {
                    chartMonthly.Series["Monthly Sales"].Points.AddXY(myReader.GetString("Category"), myReader.GetInt32("Quantity"));





                    chartMonthly.Series["Monthly Sales"].IsValueShownAsLabel = true;




                    chartMonthly.Series["Monthly Sales"].XValueMember = myReader.GetString("Category");
                    chartMonthly.Series["Monthly Sales"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;

                    chartMonthly.Series["Monthly Sales"].YValueMembers = myReader.GetString("Quantity");
                    chartMonthly.Series["Monthly Sales"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;



                }
                Conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("keme19" + ex.Message);
            }
        }


        void MonthlySalesReportGraph()
        {
            // titlereport = "Daily Report";
            MySqlConnection Conn = ConString.Connection;
            //    MySqlCommand cmd = new MySqlCommand("SELECT tbl_product.category as 'Category', tbl_product.product_name as 'Product Name', tbl_product.remarks as 'SRP', sum(tbl_transactionrecord.quantity) as 'Quantity', sum(tbl_transactionrecord.amount) as 'Amount', week(tbl_transactionrecord.Date) as 'Week', date(tbl_transactionrecord.Date) as 'Date' FROM tbl_product inner join tbl_transactionrecord on tbl_product.product_id = tbl_transactionrecord.product_id where month(tbl_transactionrecord.date) = Month(NOW()) and tbl_transactionrecord.status = 'sold' and tbl_transactionrecord.store_id = '" + txtstore_id.Text + "'  group by tbl_product.category order by Amount desc;", Conn);
            MySqlCommand cmd = new MySqlCommand("SELECT tbl_product.category as 'Category', tbl_product.product_name as 'Product Name', tbl_product.remarks as 'SRP', sum(tbl_critical.quantity) as 'Quantity', sum(tbl_critical.quantity) * tbl_product.remarks as 'Amount', week(tbl_critical.date) as 'Week', date(tbl_critical.date) as 'Date' FROM tbl_product inner join tbl_critical on tbl_product.product_id = tbl_critical.product_id where month(tbl_critical.date) = Month(NOW())  and tbl_critical.store_id = '" + txtstore_id.Text + "' group by tbl_product.Category order by Amount desc;", Conn);
            try
            {




                MySqlDataReader myReader;

                myReader = cmd.ExecuteReader();

                while (myReader.Read())
                {
                    chartMonthly.Series["Monthly Sales"].Points.AddXY(myReader.GetString("Category"), myReader.GetDecimal("Amount"));





                    chartMonthly.Series["Monthly Sales"].IsValueShownAsLabel = true;




                    chartMonthly.Series["Monthly Sales"].XValueMember = myReader.GetString("Category");
                    chartMonthly.Series["Monthly Sales"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;

                    chartMonthly.Series["Monthly Sales"].YValueMembers = myReader.GetString("Amount");
                    chartMonthly.Series["Monthly Sales"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;


                }
                Conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("keme20" + ex.Message);
            }
        }


        void YearlyReport()
        {
            // titlereport = "Daily Report";
            MySqlConnection Conn = ConString.Connection;
            //   MySqlCommand cmd = new MySqlCommand("SELECT tbl_product.Category as 'Category', tbl_product.product_name as 'Product Name', tbl_product.remarks as 'SRP', sum(tbl_transactionrecord.quantity) as 'Quantity', sum(tbl_transactionrecord.amount) as 'Amount', monthname(tbl_transactionrecord.Date) as 'Month', date(tbl_transactionrecord.Date) as 'Date' FROM tbl_product inner join tbl_transactionrecord on tbl_product.product_id = tbl_transactionrecord.product_id where year(tbl_transactionrecord.date) = Year(NOW()) and tbl_transactionrecord.status = 'sold' and tbl_transactionrecord.store_id = '" + txtstore_id.Text + "' group by tbl_product.product_id, Month order by tbl_transactionrecord.date;", Conn);
            MySqlCommand cmd = new MySqlCommand("SELECT tbl_product.category as 'Category', tbl_product.product_name as 'Product Name', tbl_product.remarks as 'SRP', sum(tbl_critical.quantity) as 'Quantity', sum(tbl_critical.quantity) * tbl_product.remarks as 'Amount', monthname(tbl_critical.date) as 'Month', date(tbl_critical.date) as 'Date' FROM tbl_product inner join tbl_critical on tbl_product.product_id = tbl_critical.product_id where year(tbl_critical.date) = Year(NOW())  and tbl_critical.store_id = '" + txtstore_id.Text + "' group by tbl_product.product_id, Month order by tbl_critical.date;", Conn);

            try
            {

                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmd;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bSource = new BindingSource();

                bSource.DataSource = dbdataset;
                dataGridView4.DataSource = bSource;
                sda.Update(dbdataset);
                //      this.dataGridView4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                //  this.dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                Conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void subYearly()
        {
            // titlereport = "Daily Report";
            MySqlConnection Conn = ConString.Connection;
            // MySqlCommand cmd = new MySqlCommand("SELECT tbl_product.Category as 'Category', tbl_product.product_name as 'Product Name', tbl_product.remarks as 'SRP', sum(tbl_transactionrecord.quantity) as 'Quantity', sum(tbl_transactionrecord.amount) as 'Amount', monthname(tbl_transactionrecord.Date) as 'Month', date(tbl_transactionrecord.Date) as 'Date' FROM tbl_product inner join tbl_transactionrecord on tbl_product.product_id = tbl_transactionrecord.product_id where year(tbl_transactionrecord.date) = Year(NOW()) and tbl_transactionrecord.status = 'sold' and tbl_transactionrecord.store_id = '" + txtstore_id.Text + "' group by tbl_product.product_id, Month order by tbl_transactionrecord.date;", Conn);
            MySqlCommand cmd = new MySqlCommand("SELECT tbl_product.category as 'Category', tbl_product.product_name as 'Product Name', tbl_product.remarks as 'SRP', sum(tbl_critical.quantity) as 'Quantity', sum(tbl_critical.quantity) * tbl_product.remarks as 'Amount', dayname(tbl_critical.date) as 'Month', date(tbl_critical.date) as 'Date' FROM tbl_product inner join tbl_critical on tbl_product.product_id = tbl_critical.product_id where year(tbl_critical.date) = Year(NOW())  and tbl_critical.store_id = '" + txtstore_id.Text + "' group by tbl_product.product_id, Month order by Quantity desc;", Conn);

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
                //      this.dataGridView4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                //  this.dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                Conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        void YearlyQuantityReportGraph()
        {
            // titlereport = "Daily Report";
            MySqlConnection Conn = ConString.Connection;
            //    MySqlCommand cmd = new MySqlCommand("SELECT tbl_product.Category as 'Category', tbl_product.product_name as 'Product Name', tbl_product.remarks as 'SRP', sum(tbl_transactionrecord.quantity) as 'Quantity', sum(tbl_transactionrecord.amount) as 'Amount', monthname(tbl_transactionrecord.Date) as 'Month', date(tbl_transactionrecord.Date) as 'Date' FROM tbl_product inner join tbl_transactionrecord on tbl_product.product_id = tbl_transactionrecord.product_id where year(tbl_transactionrecord.date) = Year(NOW()) and tbl_transactionrecord.status = 'sold' and tbl_transactionrecord.store_id = '" + txtstore_id.Text + "' group by tbl_product.Category order by Quantity desc;", Conn);
            MySqlCommand cmd = new MySqlCommand("SELECT tbl_product.category as 'Category', tbl_product.product_name as 'Product Name', tbl_product.remarks as 'SRP', sum(tbl_critical.quantity) as 'Quantity', sum(tbl_critical.quantity) * tbl_product.remarks as 'Amount', monthname(tbl_critical.date) as 'Month', date(tbl_critical.date) as 'Date' FROM tbl_product inner join tbl_critical on tbl_product.product_id = tbl_critical.product_id where year(tbl_critical.date) = Year(NOW())  and tbl_critical.store_id = '" + txtstore_id.Text + "' group by tbl_product.Category order by Quantity desc;", Conn);
            try
            {



                MySqlDataReader myReader;

                myReader = cmd.ExecuteReader();

                while (myReader.Read())
                {
                    chartYearly.Series["Yearly Sales"].Points.AddXY(myReader.GetString("Category"), myReader.GetInt32("Quantity"));



                  

                    chartYearly.Series["Yearly Sales"].IsValueShownAsLabel = true;




                    chartYearly.Series["Yearly Sales"].XValueMember = myReader.GetString("Category");
                    chartYearly.Series["Yearly Sales"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;

                    chartYearly.Series["Yearly Sales"].YValueMembers = myReader.GetString("Quantity");
                    chartYearly.Series["Yearly Sales"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;



                }
                Conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("keme21" + ex.Message);
            }
        }

        void salespermonth()
        {
            MySqlConnection Conn = ConString.Connection;
            MySqlCommand cmd = new MySqlCommand("SELECT tbl_product.category as 'Category', tbl_product.product_name as 'Product Name', tbl_product.remarks as 'SRP', sum(tbl_critical.quantity) as 'Quantity', sum(tbl_critical.quantity) * tbl_product.remarks as 'Amount', monthname(tbl_critical.date) as 'Month', date(tbl_critical.date) as 'Date' FROM tbl_product inner join tbl_critical on tbl_product.product_id = tbl_critical.product_id where year(tbl_critical.date) = Year(NOW())  and tbl_critical.store_id = '" + txtstore_id.Text + "' group by Month order by tbl_critical.date;", Conn);

            try
            {

                MySqlDataReader myReader;

                myReader = cmd.ExecuteReader();

                while (myReader.Read())
                {
                    //chartYearly.ChartAreas["ChartArea1"].AxisY.LabelStyle.Format = "'P'#0";
                    //chartYearly.ChartAreas[0].RecalculateAxesScale();
                   
                    chartYearly.Series["Yearly Sales"].Points.AddXY(myReader.GetString("Month"), myReader.GetInt32("Amount"));


                 //   chartYearly.Series["Yearly Sales"].Label = "#PERCENT";
                  
                   
                  
                    chartYearly.Series["Yearly Sales"].IsValueShownAsLabel = true;

                    chartYearly.Series["Yearly Sales"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;


                    //chartYearly.Series["Yearly Sales"].XValueMember = myReader.GetString("Month");
                    //chartYearly.Series["Yearly Sales"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;

                    //chartYearly.Series["Yearly Sales"].YValueMembers = "#PERCENT";
                  //  chartYearly.Series["Yearly Sales"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;



                }
                Conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("keme22" + ex.Message);
            }
        }
        void YearlySalesReportGraph()
        {
            // titlereport = "Daily Report";
            MySqlConnection Conn = ConString.Connection;
            //  MySqlCommand cmd = new MySqlCommand("SELECT tbl_product.Category as 'Category', tbl_product.product_name as 'Product Name', tbl_product.remarks as 'SRP', sum(tbl_transactionrecord.quantity) as 'Quantity', sum(tbl_transactionrecord.amount) as 'Amount', monthname(tbl_transactionrecord.Date) as 'Month', date(tbl_transactionrecord.Date) as 'Date' FROM tbl_product inner join tbl_transactionrecord on tbl_product.product_id = tbl_transactionrecord.product_id where year(tbl_transactionrecord.date) = Year(NOW()) and tbl_transactionrecord.status = 'sold' and tbl_transactionrecord.store_id = '" + txtstore_id.Text + "' group by tbl_product.Category order by Amount desc;", Conn);
            MySqlCommand cmd = new MySqlCommand("SELECT tbl_product.category as 'Category', tbl_product.product_name as 'Product Name', tbl_product.remarks as 'SRP', sum(tbl_critical.quantity) as 'Quantity', sum(tbl_critical.quantity) * tbl_product.remarks as 'Amount', monthname(tbl_critical.date) as 'Month', date(tbl_critical.date) as 'Date' FROM tbl_product inner join tbl_critical on tbl_product.product_id = tbl_critical.product_id where year(tbl_critical.date) = Year(NOW())  and tbl_critical.store_id = '" + txtstore_id.Text + "' group by tbl_product.Category order by Amount desc;", Conn);
            try
            {




                MySqlDataReader myReader;

                myReader = cmd.ExecuteReader();

                while (myReader.Read())
                {
                  
                    chartYearly.Series["Yearly Sales"].Points.AddXY(myReader.GetString("Category"), myReader.GetDecimal("Amount"));





                    chartYearly.Series["Yearly Sales"].IsValueShownAsLabel = true;




                    chartYearly.Series["Yearly Sales"].XValueMember =myReader.GetString("Category");
                    chartYearly.Series["Yearly Sales"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;

                    chartYearly.Series["Yearly Sales"].YValueMembers = myReader.GetString("Amount");
                    chartYearly.Series["Yearly Sales"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;


                }
                Conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("keme23" + ex.Message);
            }
        }



     

        void DGVDailyBestSeller()
        {

            if (frm_optionreport.options != "")
            {



                MySqlConnection Conn = ConString.Connection;
                //  MySqlCommand cmd = new MySqlCommand("SELECT @rn := @rn + 1 AS Top, Category, Best_Selling_Products, Quantity FROM (Select tbl_product.product_name as Best_Selling_Products, sum(tbl_transactionrecord.quantity) as 'Quantity', tbl_product.Category as Category FROM tbl_product inner join tbl_transactionrecord on tbl_product.product_id = tbl_transactionrecord.product_id where " + frm_optionreport.options + " and tbl_transactionrecord.status = 'sold' and tbl_transactionrecord.store_id = '" + txtstore_id.Text + "'  group by tbl_product.product_name order by Quantity desc limit 10) as t1,(SELECT @rn := 0) as t2", Conn);
                MySqlCommand cmd = new MySqlCommand("SELECT @rn := @rn + 1 AS Top, Category, Best_Delivery_Products, Quantity FROM (Select tbl_product.product_name as Best_Delivery_Products, sum(tbl_critical.quantity) as 'Quantity', tbl_product.Category as Category FROM tbl_product inner join tbl_critical on tbl_product.product_id = tbl_critical.product_id where  " + frm_optionreport.options + " and tbl_critical.store_id = '"+txtstore_id.Text+"'  group by tbl_product.product_name order by Quantity desc limit 10) as t1,(SELECT @rn := 0) as t2", Conn);

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
                    this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

                    //  this.dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                    Conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("c" + ex.Message);

                }
            }
        }
        void DGVWeeklySeller()
        {

            //MySqlConnection Conn = ConString.Connection;
            //MySqlCommand cmd = new MySqlCommand("SELECT max(@rn := 'Rank' + @rn+1) AS Top, Best_Selling_Products, Quantity FROM(Select  tbl_product.product_name as Best_Selling_Products, sum(tbl_critical.quantity) as 'Quantity', tbl_critical.quantity * tbl_product.remarks as 'Total Amount' FROM tbl_product  inner join tbl_critical on tbl_product.product_id = tbl_critical.product_id where  weekofyear(tbl_critical.date) = weekofyear(NOW())   and tbl_critical.store_id = '" + txtstore_id.Text + "' group by tbl_product.product_name order by Quantity desc limit 10) as t1, (SELECT @rn:= 'Rank' + 0) as t2;", Conn);


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
            //    this.dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            //    //  this.dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            //    Conn.Close();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("c" + ex.Message);
            //}
        }

        void DailyTop()
        {
           
            //// titlereport = "Daily Report";
            //MySqlConnection Conn = ConString.Connection;
            //MySqlCommand cmd = new MySqlCommand("SELECT max(@rn := 'Rank' + @rn+1) AS Top, Best_Selling_Products, Quantity FROM(Select  tbl_product.product_name as Best_Selling_Products, sum(tbl_critical.quantity) as 'Quantity', tbl_critical.quantity * tbl_product.remarks as 'Total Amount' FROM tbl_product  inner join tbl_critical on tbl_product.product_id = tbl_critical.product_id where  tbl_critical.date >= DATE(NOW())  and tbl_critical.store_id = '" + txtstore_id.Text+"' group by tbl_product.product_name order by Quantity desc limit 10) as t1, (SELECT @rn:= 'Rank' + 0) as t2;", Conn);

            //try
            //{



            //    MySqlDataReader myReader;

            //    myReader = cmd.ExecuteReader();

            //    while (myReader.Read())
            //    {

            //        top_id = myReader.GetInt32("Top");


            //    }
            //    Conn.Close();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("keme12" + ex.Message);
            //}
        }
        void WeeklyTop()
        {

            // titlereport = "Daily Report";
            //MySqlConnection Conn = ConString.Connection;
            ////   MySqlCommand cmd = new MySqlCommand("SELECT @rn := @rn + 1 AS Top, Best_Selling_Products, Quantity FROM ( SELECT  tbl_product.product_name as Best_Selling_Products,  sum(tbl_transactionrecord.quantity) as 'Quantity' FROM tbl_product inner join tbl_transactionrecord on tbl_product.product_id = tbl_transactionrecord.product_id where weekofyear(tbl_transactionrecord.date) = weekofyear(NOW()) and tbl_transactionrecord.status = 'sold' and tbl_transactionrecord.store_id = '" + txtstore_id.Text + "' group by tbl_product.product_name order by Quantity  desc limit 10) as t1,(SELECT @rn := 0) as t2;", Conn);
            //MySqlCommand cmd = new MySqlCommand("SELECT max(@rn := 'Rank' + @rn+1) AS Top, Best_Selling_Products, Quantity FROM(Select  tbl_product.product_name as Best_Selling_Products, sum(tbl_critical.quantity) as 'Quantity', tbl_critical.quantity * tbl_product.remarks as 'Total Amount' FROM tbl_product  inner join tbl_critical on tbl_product.product_id = tbl_critical.product_id where  weekofyear(tbl_critical.date) = weekofyear(NOW())   and tbl_critical.store_id = '" + txtstore_id.Text + "' group by tbl_product.product_name order by Quantity desc limit 10) as t1, (SELECT @rn:= 'Rank' + 0) as t2;", Conn);
            //try
            //{



            //    MySqlDataReader myReader;

            //    myReader = cmd.ExecuteReader();

            //    while (myReader.Read())
            //    {

            //        top_id2 = myReader.GetInt32("Top");


            //    }
            //    Conn.Close();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("keme13" + ex.Message);
            //}
        }

        private void btnGenerate1_Click(object sender, EventArgs e)
        {

            try
            {
                DateTime date2 = dateTimePicker1.Value;
            DateTime date3 = dateTimePicker2.Value;
            if (date2 > date3)
            {
               // MessageBox.Show("Invalid input DATE TO.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateTimePicker2.Text = dateTrue.Text;
                return;
            }
                MySqlConnection Conn = ConString.Connection;
                MySqlCommand cmd = new MySqlCommand("SELECT tbl_product.product_name as 'Product Name', tbl_product.product_price as 'SRP', sum(tbl_transactionrecord.quantity) as 'Quantity', sum(tbl_transactionrecord.amount) as 'Amount' FROM tbl_product inner join tbl_transactionrecord on tbl_product.product_id = tbl_transactionrecord.product_id where tbl_transactionrecord.store_id = '" + txtstore_id.Text + "' and tbl_transactionrecord.date >= DATE('" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "')  or tbl_transactionrecord.date >= DATE('" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "') and tbl_transactionrecord.status = 'sold' group by tbl_product.product_id order by tbl_transactionrecord.time;", Conn);



                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmd;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bSource = new BindingSource();

                bSource.DataSource = dbdataset;
                dataGridView1.DataSource = bSource;
                sda.Update(dbdataset);
                this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                Conn.Close();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnManageAccount_Click(object sender, EventArgs e)
        {

        }

        private void btnInventory_Click_1(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {

        }

        private void btnSales_Click(object sender, EventArgs e)
        {

        }

        private void btnLoginHistory_Click_1(object sender, EventArgs e)
        {

        }

        private void btnRecord_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView44_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnGenerate2_Click(object sender, EventArgs e)
        {
            DateTime date4 = dateTimePicker4.Value;
            DateTime date3 = dateTimePicker3.Value;
            if (date4 > date3)
            {
               // MessageBox.Show("Invalid input DATE TO.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateTimePicker3.Text = dateTrue.Text;
                return;
            }
            MySqlConnection Conn = ConString.Connection;
            MySqlCommand cmd = new MySqlCommand("SELECT tbl_product.product_name as 'Product Name', tbl_product.remarks as 'SRP', sum(tbl_transactionrecord.quantity) as 'Quantity', sum(tbl_transactionrecord.amount) as 'Amount' FROM tbl_product inner join tbl_transactionrecord on tbl_product.product_id = tbl_transactionrecord.product_id inner join tbl_inventory on tbl_transactionrecord.store_id = tbl_inventory.store_id where tbl_inventory.store_id = '" + txtstore_id.Text + "' and tbl_transactionrecord.date >= DATE('" + dateTimePicker9.Value.ToString("yyyy-MM-dd") + "')  or tbl_transactionrecord.date >= DATE('" + dateTimePicker10.Value.ToString("yyyy-MM-dd") + "') and tbl_transactionrecord.status = 'sold' group by tbl_product.product_id order by tbl_transactionrecord.time;", Conn);


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
                this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                Conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void DGVInventoryProductList()
        {

            MySqlConnection Conn = ConString.Connection;
            MySqlCommand cmd = new MySqlCommand("SELECT  tbl_product.product_name as 'Product Name', sum(tbl_expiry.QTY) as 'Stock Adjusted', tbl_expiry.Reason as 'Status', tbl_expiry.date_expiry as 'Expiry Date', tbl_expiry.date_adjust as 'Date Adjusted' FROM tbl_product  inner join tbl_expiry on tbl_expiry.product_id = tbl_product.product_id where tbl_expiry.status != 'Expired' and month(tbl_expiry.date_adjust) = Month(NOW())  group by tbl_expiry.product_id, tbl_expiry.date_expiry;", Conn);
            cmd.CommandTimeout = 0;

            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmd;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bSource = new BindingSource();

                bSource.DataSource = dbdataset;
                dataGridView7.DataSource = bSource;
                sda.Update(dbdataset);
           
                this.dataGridView7.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                Conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void DGVPaymenttoSupplierReport()
        {

            MySqlConnection Conn = ConString.Connection;
            MySqlCommand cmd = new MySqlCommand("SELECT tbl_product.product_name as 'Product Name', sum(tbl_order.total_due) as 'Total Due', sum(tbl_order.quantity) as 'Ordered QTY',  tbl_product.product_price as'Amount', tbl_supplierinfo.company as 'Supplier Name',tbl_order.date_ordered as 'Date Ordered', tbl_order.date_expected as 'Date Expected', tbl_order.status as 'Status' FROM tbl_order inner join tbl_product on tbl_order.product_id = tbl_product.product_id inner join tbl_supplierinfo on tbl_order.supplier_id = tbl_supplierinfo.supplier_id  where tbl_order.status = 'Stocked' and total_due != 0.00 or tbl_order.status = 'Cancelled order' and total_due != 0.00 group by tbl_order.product_id, tbl_order.supplier_id, tbl_order.status, tbl_order.date_expected, tbl_order.date_ordered order by tbl_order.order_id desc;", Conn);
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

                this.metroGrid2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                Conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            changeRowColor1();

        }
        public void DGVBranchStockAdjustment()
        {

            MySqlConnection Conn = ConString.Connection;
            MySqlCommand cmd = new MySqlCommand("SELECT tbl_product.product_name as 'Product Name', tbl_inventory.s_adjust as 'Stock Adjusted', tbl_inventory.reason1 as 'Status', tbl_inventory.date_adjust as 'Date' FROM tbl_inventory inner  join tbl_product on tbl_inventory.product_id = tbl_product.product_id where tbl_inventory.store_id = '" + txtstore_id.Text+ "' and tbl_inventory.status_adjust = 'Stock Adjusted' group by tbl_inventory.product_id;", Conn);
            cmd.CommandTimeout = 0;

            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmd;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bSource = new BindingSource();

                bSource.DataSource = dbdataset;
                metroGrid5.DataSource = bSource;
                sda.Update(dbdataset);

                this.metroGrid5.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                Conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
      
            public void DGVWarehouseBackorder()
        {

            MySqlConnection Conn = ConString.Connection;
            MySqlCommand cmd = new MySqlCommand("SELECT tbl_product.product_name as 'Product Name', sum(tbl_order.total_due) as 'Total Due', sum(tbl_order.quantity) as 'Ordered QTY',  tbl_product.product_price as'Amount', tbl_supplierinfo.company as 'Supplier Name',tbl_order.date_ordered as 'Date Ordered', tbl_order.date_expected as 'Date Expected' FROM tbl_order inner join tbl_product on tbl_order.product_id = tbl_product.product_id inner join tbl_supplierinfo on tbl_order.supplier_id = tbl_supplierinfo.supplier_id  where tbl_order.damage_product != 0 group by tbl_order.product_id, tbl_order.supplier_id, tbl_order.status, tbl_order.date_expected, tbl_order.date_ordered order by tbl_order.order_id desc;", Conn);
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

                this.metroGrid3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                Conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void DGVWarehouseCritical()
        {

            MySqlConnection Conn = ConString.Connection;
            MySqlCommand cmd = new MySqlCommand("SELECT  tbl_product.product_name as 'Product Name',  tbl_product.stock as 'QTY',tbl_product.critical as 'Critical',  status_new as 'Status' FROM tbl_product left join tbl_supplierinfo on tbl_product.supplier_id = tbl_supplierinfo.supplier_id where tbl_product.stock <= tbl_product.critical and tbl_product.critical !=0 group by tbl_product.product_id order by tbl_product.product_id asc", Conn);
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

                this.metroGrid4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                Conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void DGVBranchBackorder()
        {

            MySqlConnection Conn = ConString.Connection;
            MySqlCommand cmd = new MySqlCommand("SELECT tbl_product.product_name as 'Product Name', tbl_inventory.qty_replacement as 'Backorder QTY', tbl_product.product_price as 'Amount' FROM tbl_inventory inner  join tbl_product on tbl_inventory.product_id = tbl_product.product_id where tbl_inventory.store_id = '"+txtstore_id.Text+"' and tbl_inventory.s_replacement = 'Replacement' group by tbl_inventory.product_id;", Conn);
            cmd.CommandTimeout = 0;

            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmd;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bSource = new BindingSource();

                bSource.DataSource = dbdataset;
                metroGrid6.DataSource = bSource;
                sda.Update(dbdataset);

                this.metroGrid6.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                Conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void DGVBranchCritical()
        {

            MySqlConnection Conn = ConString.Connection;
            MySqlCommand cmd = new MySqlCommand("SELECT tbl_product.product_name as 'Product Name', tbl_inventory.QTY as 'QTY', tbl_inventory.critical as 'Critical Level', tbl_inventory.status as 'Status' FROM tbl_inventory inner  join tbl_product on tbl_inventory.product_id = tbl_product.product_id where tbl_inventory.store_id = '"+txtstore_id.Text+ "' and tbl_inventory.QTY <= tbl_inventory.critical and tbl_inventory.critical != 0 group by tbl_inventory.product_id;", Conn);
            cmd.CommandTimeout = 0;

            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmd;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bSource = new BindingSource();

                bSource.DataSource = dbdataset;
                metroGrid8.DataSource = bSource;
                sda.Update(dbdataset);

                this.metroGrid8.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                Conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void CriticalLevel()
        {

            MySqlConnection Conn = ConString.Connection;
            MySqlCommand cmd = new MySqlCommand("Select  product_id as 'Product ID', max(product_name) as 'Product Name', stock as 'Remaining Stock' from tbl_product where stock <= critical and stock !=0 and product_id = product_id  group by product_name", Conn);
                cmd.CommandTimeout = 50000;

                try
                {
              
                  


                
                        MySqlDataAdapter sda = new MySqlDataAdapter();
                        sda.SelectCommand = cmd;
                        DataTable dbdataset = new DataTable();
                        sda.Fill(dbdataset);
                        BindingSource bSource = new BindingSource();

                        bSource.DataSource = dbdataset;
                        dataGridView8.DataSource = bSource;
                        sda.Update(dbdataset);
                        dataGridView8.DefaultCellStyle.SelectionBackColor = Color.Red;
                        this.dataGridView8.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;


                Conn.Close();
             

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error program...", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);

            }
        }
        private void btngenerate3_Click(object sender, EventArgs e)
        {
            DateTime date6 = dateTimePicker6.Value;
            DateTime date5 = dateTimePicker5.Value;
            if (date6 > date5)
            {
              //  MessageBox.Show("Invalid input DATE TO.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateTimePicker5.Text = dateTrue.Text;
                return;
            }
            MySqlConnection Conn = ConString.Connection;
            MySqlCommand cmd = new MySqlCommand("SELECT tbl_product.product_name as 'Product Name', tbl_product.product_price as 'Unit Price', sum(tbl_transactionrecord.quantity) as 'Quantity', sum(tbl_transactionrecord.amount) as 'Amount' FROM tbl_product inner join tbl_transactionrecord on tbl_product.product_id = tbl_transactionrecord.product_id where tbl_transactionrecord.store_id = '" + txtstore_id.Text + "' and tbl_transactionrecord.date >= DATE('" + dateTimePicker6.Value.ToString("yyyy-MM-dd") + "')  or tbl_transactionrecord.date >= DATE('" + dateTimePicker5.Value.ToString("yyyy-MM-dd") + "') and tbl_transactionrecord.status = 'sold' group by tbl_product.product_id order by tbl_transactionrecord.time;", Conn);


            try
            {

                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmd;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bSource = new BindingSource();

                bSource.DataSource = dbdataset;
                dataGridView3.DataSource = bSource;
                sda.Update(dbdataset);
                this.dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                Conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btngenerate4_Click(object sender, EventArgs e)
        {
            DateTime date8 = dateTimePicker8.Value;
            DateTime date7 = dateTimePicker7.Value;
            if (date8 > date7)
            {
               // MessageBox.Show("Invalid input DATE TO.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateTimePicker7.Text = dateTrue.Text;
                return;
            }
            MySqlConnection Conn = ConString.Connection;
            MySqlCommand cmd = new MySqlCommand("SELECT tbl_product.product_name as 'Product Name', tbl_product.product_price as 'Unit Price', sum(tbl_transactionrecord.quantity) as 'Quantity', sum(tbl_transactionrecord.amount) as 'Amount' FROM tbl_product inner join tbl_transactionrecord on tbl_product.product_id = tbl_transactionrecord.product_id where tbl_transactionrecord.store_id = '" + txtstore_id.Text + "' and tbl_transactionrecord.date >= DATE('" + dateTimePicker8.Value.ToString("yyyy-MM-dd") + "')  or tbl_transactionrecord.date >= DATE('" + dateTimePicker7.Value.ToString("yyyy-MM-dd") + "') and tbl_transactionrecord.status = 'sold' group by tbl_product.product_id order by tbl_transactionrecord.time;", Conn);


            try
            {

                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmd;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bSource = new BindingSource();

                bSource.DataSource = dbdataset;
                dataGridView4.DataSource = bSource;
                sda.Update(dbdataset);
                this.dataGridView4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                Conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRecord_Click_1(object sender, EventArgs e)
        {
            var pleaseWait = new frm_PleaseWait();
            pleaseWait.Show();
            Application.DoEvents();
            var pc = Cursors.WaitCursor;
            var myForm = new frm_TransactionRecord();
            myForm.Show();
            pleaseWait.Hide();

            this.Hide();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            var pleaseWait = new frm_PleaseWait();
            pleaseWait.Show();
            Application.DoEvents();
            var pc = Cursors.WaitCursor;
            var myForm = new frm_MainHomeManager(manager);
            myForm.Show();
            pleaseWait.Hide();

            this.Hide();
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            var pleaseWait = new frm_PleaseWait();
            pleaseWait.Show();
            Application.DoEvents();
            var pc = Cursors.WaitCursor;
            var myForm = new frm_Inventory();
            myForm.Show();
            pleaseWait.Hide();

            this.Hide();
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            var pleaseWait = new frm_PleaseWait();
            pleaseWait.Show();
            Application.DoEvents();
            var pc = Cursors.WaitCursor;
            var myForm = new frm_Supplier();
            myForm.Show();
            pleaseWait.Hide();

            this.Hide();
        }

        private void btnLoginHistory_Click(object sender, EventArgs e)
        {
            var pleaseWait = new frm_PleaseWait();
            pleaseWait.Show();
            Application.DoEvents();
            var pc = Cursors.WaitCursor;
            var myForm = new frm_LoginHistory();
            myForm.Show();
            pleaseWait.Hide();

            this.Hide();
        }

        private void btnManageAccount_Click_1(object sender, EventArgs e)
        {
            var pleaseWait = new frm_PleaseWait();
            pleaseWait.Show();
            Application.DoEvents();
            var pc = Cursors.WaitCursor;
            var myForm = new frm_AccountManager();
            myForm.Show();
            pleaseWait.Hide();

            this.Hide();
        }

        private void btnLogout_Click_1(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Are you sure, you want to logout?", "Fabula's Merchandise System", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                var pc = Cursors.WaitCursor;
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
                    var pc1 = Cursors.AppStarting;
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

        private void frm_Report_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Are you sure, you want to exit?", "Fabula's Merchandise System", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {

                var pc = Cursors.WaitCursor;
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

        private void btnprint_Click(object sender, EventArgs e)
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
          
            string titlereport = "Daily Delivery Report";
            DGVPrinter printer = new DGVPrinter();
            printer.Title = titlereport;
            printer.SubTitle = string.Format("Date: {0}", lblTime.Text);
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "Fabula's Merchandise.";
            printer.FooterSpacing = 15;
            printer.PrintDataGridView(dataGridView1);

        
    }

        private void button3_Click(object sender, EventArgs e)
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

            string titlereport = "Weekly Delivery Report";
            DGVPrinter printer = new DGVPrinter();
            printer.Title = titlereport;
            printer.SubTitle = string.Format("Date: {0}", lblTime.Text);
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "Fabula's Merchandise.";
            printer.FooterSpacing = 15;
            printer.PrintDataGridView(dataGridView2);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                if (!dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].IsNewRow)
                {
                    foreach (DataGridViewCell cell in dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells)
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

            string titlereport = "Monthly Delivery Report";
            DGVPrinter printer = new DGVPrinter();
            printer.Title = titlereport;
            printer.SubTitle = string.Format("Date: {0}", lblTime.Text);
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "Fabula's Merchandise.";
            printer.FooterSpacing = 15;
            printer.PrintDataGridView(dataGridView3);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                if (!dataGridView4.Rows[dataGridView4.CurrentCell.RowIndex].IsNewRow)
                {
                    foreach (DataGridViewCell cell in dataGridView4.Rows[dataGridView4.CurrentCell.RowIndex].Cells)
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

            string titlereport = "Yearly Delivery Report";
            DGVPrinter printer = new DGVPrinter();
            printer.Title = titlereport;
            printer.SubTitle = string.Format("Date: {0}", lblTime.Text);
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "Fabula's Merchandise.";
            printer.FooterSpacing = 15;
            printer.PrintDataGridView(dataGridView4);
        }

        private void btnScrollUp_Click(object sender, EventArgs e)
        {
            DailyReport();
        }

        private void btnScrollBottom_Click(object sender, EventArgs e)
        {
            dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.RowCount - 1;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            WeeklyReport();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            MonthlyReport();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            YearlyReport();
            subYearly();
        }

        private void btnRefesh4_Click(object sender, EventArgs e)
        {
            DailyReport();
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Sort(this.dataGridView1.Columns["Product Name"], ListSortDirection.Ascending);

          

        }

        private void button18_Click(object sender, EventArgs e)
        {
            dataGridView2.FirstDisplayedScrollingRowIndex = dataGridView2.RowCount - 1;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            WeeklyReport();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.dataGridView2.Sort(this.dataGridView2.Columns["Product Name"], ListSortDirection.Ascending);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            dataGridView3.FirstDisplayedScrollingRowIndex = dataGridView3.RowCount - 1;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            MonthlyReport();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.dataGridView3.Sort(this.dataGridView3.Columns["Product Name"], ListSortDirection.Ascending);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            dataGridView4.FirstDisplayedScrollingRowIndex = dataGridView4.RowCount - 1;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            YearlyReport();
            subYearly();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.dataGridView4.Sort(this.dataGridView4.Columns["Product Name"], ListSortDirection.Ascending);
        }

        private void button23_Click(object sender, EventArgs e)
        {
            DGVInventoryProductList();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            dataGridView7.FirstDisplayedScrollingRowIndex = dataGridView7.RowCount - 1;
        }

        private void button22_Click(object sender, EventArgs e)
        {
            DGVInventoryProductList();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            this.dataGridView7.Sort(this.dataGridView7.Columns["Product Name"], ListSortDirection.Ascending);
        }

        private void button27_Click(object sender, EventArgs e)
        {
            CriticalLevel();
        }

        private void button28_Click(object sender, EventArgs e)
        {
            dataGridView8.FirstDisplayedScrollingRowIndex = dataGridView8.RowCount - 1;
        }

        private void button26_Click(object sender, EventArgs e)
        {
            CriticalLevel();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            this.dataGridView8.Sort(this.dataGridView8.Columns["Product Name"], ListSortDirection.Ascending);
        }

        private void btnprint5_Click(object sender, EventArgs e)
        {
           
        }

        private void btnprint6_Click(object sender, EventArgs e)
        {


          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!dataGridView7.Rows[dataGridView7.CurrentCell.RowIndex].IsNewRow)
                {
                    foreach (DataGridViewCell cell in dataGridView7.Rows[dataGridView7.CurrentCell.RowIndex].Cells)
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

            string titlereport = "Warehouse Stock Adjustment Report";
            DGVPrinter printer = new DGVPrinter();
            printer.Title = titlereport;
            printer.SubTitle = string.Format("Date: {0}", lblTime.Text);
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "Fabula's Merchandise.";
            printer.FooterSpacing = 15;
            printer.PrintDataGridView(dataGridView7);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            try
            {
                if (!dataGridView8.Rows[dataGridView8.CurrentCell.RowIndex].IsNewRow)
                {
                    foreach (DataGridViewCell cell in dataGridView8.Rows[dataGridView8.CurrentCell.RowIndex].Cells)
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

            string titlereport = "Critical Level Report";
            DGVPrinter printer = new DGVPrinter();
            printer.Title = titlereport;
            printer.SubTitle = string.Format("Date: {0}", lblTime.Text);
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "Fabula's Merchandise.";
            printer.FooterSpacing = 15;
            printer.PrintDataGridView(dataGridView8);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            //DateTime date1 = dateTrue.Value;

            //TimeSpan difference = date2.Subtract(date1);

            //if ((date2 < date1 && dateTrue.Text != dateTimePicker1.Text))
            //{
            //    MessageBox.Show("The date doesn't look right. Be sure to use actual date.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //   dateTimePicker1.Text = dateTrue.Text;
            //}
            DateTime date2 = dateTimePicker1.Value;
            DateTime date3 = dateTimePicker2.Value;
            if (date2 > date3)
            {
              //  MessageBox.Show("Invalid input DATE FROM.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);
              //  dateTimePicker1.Text = dateTrue.Text;
            }
        }
        public long Days1(System.DateTime StartDate, System.DateTime EndTime)
        {
            long days = 0;
            System.TimeSpan ts = new TimeSpan(EndTime.Ticks - StartDate.Ticks);
            days = (long)(ts.Days / 1);
            return days;
        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //dateTimePicker7.Value = dateTimePicker7.Value.AddYears(+1);
        

       
      


            if (tabControl1.SelectedTab == tabPage2)
            {

                dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                return;
            }
            if (tabControl1.SelectedTab == tabPage1)
            {

                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                return;
            }
            if (tabControl1.SelectedTab == tabPage3)
            {

                dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                return;
            }
            if (tabControl1.SelectedTab == tabPage4)
            {

                dataGridView4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                return;
            }
            //dateTimePicker3.MaxDate = dateTimePicker3.Value.AddDays(7);

            //dateTimePicker5.MaxDate = dateTimePicker5.Value.AddMonths(1);
            //dateTimePicker7.MaxDate = dateTimePicker7.Value.AddYears(1);
            //if (tabControl1.SelectedTab == tabPage1)
            //{
            //    tabControl1.SelectedTab = tabPage1;
            //    tabPage1.Text = "Daily Report";
            //    DailyReport();
            //    label2.Text = "Daily Report";

            //}
            //else if (tabControl1.SelectedTab == tabPage2)
            //{
            //    tabControl1.SelectedTab = tabPage1;
            //    tabPage1.Text = "Weekly Report";
            //    WeeklyReport();
            //    label2.Text = "Weekly Report";

            //}

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            DateTime date1 = dateTrue.Value;
            DateTime date2 = dateTimePicker2.Value;

            TimeSpan difference = date2.Subtract(date1);

            if ((date2 > date1 && dateTrue.Text != dateTimePicker2.Text))
            {
               // MessageBox.Show("The date doesn't look right. Be sure to use the actual date.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);
               // dateTimePicker2.Text = dateTrue.Text;
            }
        }

        private void dateTimePicker4_ValueChanged(object sender, EventArgs e)
        {
          
            //DateTime date1 = dateTrue.Value;
            //DateTime date2 = dateTimePicker4.Value;

            //TimeSpan difference = date2.Subtract(date1);

            //if ((date2 < date1 && dateTrue.Text != dateTimePicker4.Text))
            //{
            //    MessageBox.Show("The date doesn't look right. Be sure to use the actual date.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    dateTimePicker4.Text = dateTrue.Text;
            //}
            DateTime date2 = dateTimePicker4.Value;
            DateTime date3 = dateTimePicker3.Value;
            if (date2 > date3)
            {
              //  MessageBox.Show("Invalid input DATE FROM.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);
              //  dateTimePicker4.Text = dateTrue.Text;
            }
        }

        private void dateTimePicker6_ValueChanged(object sender, EventArgs e)
        {
            //DateTime date1 = dateTrue.Value;
            //DateTime date2 = dateTimePicker6.Value;

            //TimeSpan difference = date2.Subtract(date1);

            //if ((date2 < date1 && dateTrue.Text != dateTimePicker6.Text))
            //{
            //    MessageBox.Show("The date doesn't look right. Be sure to use the actual date.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    dateTimePicker6.Text = dateTrue.Text;
            //}
            DateTime date2 = dateTimePicker6.Value;
            DateTime date3 = dateTimePicker5.Value;
            if (date2 > date3)
            {
              //  MessageBox.Show("Invalid input DATE FROM.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);
             //   dateTimePicker6.Text = dateTrue.Text;
            }
        }

        private void dateTimePicker8_ValueChanged(object sender, EventArgs e)
        {
            //DateTime date1 = dateTrue.Value;
            //DateTime date2 = dateTimePicker8.Value;

            //TimeSpan difference = date2.Subtract(date1);

            //if ((date2 < date1 && dateTrue.Text != dateTimePicker8.Text))
            //{
            //    MessageBox.Show("The date doesn't look right. Be sure to use the actual date.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    dateTimePicker8.Text = dateTrue.Text;
            //}
            //DateTime date2 = dateTimePicker8.Value;
            //DateTime date3 = dateTimePicker7.Value;
            //if (date2 > date3)
            //{
            //    MessageBox.Show("Invalid input DATE FROM.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    dateTimePicker8.Text = dateTrue.Text;
            //}
        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            DateTime date1 = dateTrue.Value;
            DateTime date2 = dateTimePicker3.Value;

            TimeSpan difference = date2.Subtract(date1);

            if ((date2 > date1 && dateTrue.Text != dateTimePicker3.Text))
            {
               // MessageBox.Show("The date doesn't look right. Be sure to use the actual date.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);
              //  dateTimePicker3.Text = dateTrue.Text;
            }
        }

        private void dateTimePicker5_ValueChanged(object sender, EventArgs e)
        {
            DateTime date1 = dateTrue.Value;
            DateTime date2 = dateTimePicker5.Value;

            TimeSpan difference = date2.Subtract(date1);

            if ((date2 > date1 && dateTrue.Text != dateTimePicker5.Text))
            {
               // MessageBox.Show("The date doesn't look right. Be sure to use the actual date.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);
              //  dateTimePicker5.Text = dateTrue.Text;
            }
        }

        private void dateTimePicker7_ValueChanged(object sender, EventArgs e)
        {
            DateTime date1 = dateTrue.Value;
            DateTime date2 = dateTimePicker7.Value;

            TimeSpan difference = date2.Subtract(date1);

            if ((date2 > date1 && dateTrue.Text != dateTimePicker7.Text))
            {
               // MessageBox.Show("The date doesn't look right. Be sure to use the actual date.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);
              //  dateTimePicker7.Text = dateTrue.Text;
            }
        }

        private void tabPage7_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void cbStore_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.Cursor var = Cursors.AppStarting; 
            try
            {



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


                global_store_id = txtstore_id.Text;
                btnGenerate1.Enabled = true;
                btnGenerate1.BackColor = Color.White;

                btnGenerate2.Enabled = true;
                btnGenerate2.BackColor = Color.White;

                btngenerate3.Enabled = true;
                btngenerate3.BackColor = Color.White;

                btngenerate4.Enabled = true;
                btngenerate4.BackColor = Color.White;



                DailyReport();

                WeeklyReport();

                MonthlyReport();
                YearlyReport();
                subYearly();
                DGVBranchStockAdjustment();
                DGVBranchBackorder();
                DGVBranchCritical();


                btnGraph.Visible = true;
                btnGraph2.Visible = true;
                btnGraph3.Visible = true;
                btnGraph4.Visible = true;
                this.metroGrid5.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                btnBS1.Visible = true;
                btnBS1.Text = "Best Delivery Products";
                btnBS2.Visible = true;
                btnBS2.Text = "Best Delivery Products";
                //chartPieDaily.Visible = false;
                //btnGraph.Text = "Show Graph";
                //btnbar.Visible = false;
                //btnpie.Visible = false;
                //chartweekly.Visible = false;
                //btnGraph2.Text = "Show Graph";
                //btnbar2.Visible = false;
                //btnpie2.Visible = false;
                datagrid1 = dataGridView1;
                datagrid2 = dataGridView2;
                datagrid3 = dataGridView3;
                datagrid4 = dataGridView4;
                foreach (var series in chartDaily.Series)
                {
                    series.Points.Clear();
                }
                DailyQuantityReportGraph();
                this.chartDaily.DataBind();

                foreach (var series in chartWeekly.Series)
                {
                    series.Points.Clear();
                }
                WeeklyQuantityReportGraph();
                this.chartWeekly.DataBind();


                foreach (var series in chartMonthly.Series)
                {
                    series.Points.Clear();
                }
                MonthlyQuantityReportGraph();
                this.chartMonthly.DataBind();

                foreach (var series in chartYearly.Series)
                {
                    series.Points.Clear();
                }
                YearlyQuantityReportGraph();
              
                this.chartYearly.DataBind();
                btnBS1.Enabled = true;
                btnGraph.Enabled = true;
                try
                {
                    if (!metroGrid1.Rows[metroGrid1.CurrentCell.RowIndex].IsNewRow)
                    {
                        foreach (DataGridViewCell cell in metroGrid1.Rows[metroGrid1.CurrentCell.RowIndex].Cells)
                        {

                            if (cell.Value == System.DBNull.Value)
                            {
                                btnBS1.Enabled = true;
                                btnGraph.Enabled = true;
                             
                            }
                        }


                    }
                }
                catch (NullReferenceException)
                {
                    btnBS1.Enabled = false;
                    btnGraph.Enabled = false;
                    //lblresult.Visible = false;


                }

             
                    

            }



            catch (Exception t)
            {

            }

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
                dateTimePicker4.Text = row.Cells[6].Value.ToString();
                dateTimePicker3.Text = row.Cells[6].Value.ToString();
                dateTimePicker3.Value = dateTimePicker3.Value.AddDays(+7);

            }
        }

        private void dataGridView3_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewCell cell = null;
            foreach (DataGridViewCell selectedCell in dataGridView3.SelectedCells)
            {
                cell = selectedCell;
                break;
            }

            if (cell != null)
            {



                DataGridViewRow row = cell.OwningRow;
                dateTimePicker6.Text = row.Cells[6].Value.ToString();
                dateTimePicker5.Text = row.Cells[6].Value.ToString();
                dateTimePicker5.Value = dateTimePicker5.Value.AddMonths(1);
            }
        }

        private void dataGridView4_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewCell cell = null;
            foreach (DataGridViewCell selectedCell in dataGridView4.SelectedCells)
            {
                cell = selectedCell;
                break;
            }

            if (cell != null)
            {



                DataGridViewRow row = cell.OwningRow;
                dateTimePicker8.Text = row.Cells[6].Value.ToString();
                dateTimePicker7.Text = row.Cells[6].Value.ToString();
                dateTimePicker7.Value = dateTimePicker7.Value.AddYears(1);

            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            //chartBarDaily.Series["Daily Sales"].Points.AddXY("Peter", 1000);
            //chartBarDaily.Series["Daily Sales"].Points.AddXY("John", 5000);
            //chartBarDaily.Series["Daily Sales"].Points.AddXY("Ian", 1500);
            //chartBarDaily.Series["Daily Sales"].Points.AddXY("Lucy", salary);


            ////chartPieDaily.Series["Daily Sales"].Points.AddXY("2016", 1000);
            //chartPieDaily.Series["Daily Sales"].Points.AddXY("2017", 5000);
            //chartPieDaily.Series["Daily Sales"].Points.AddXY("2018", 1500);
            //chartPieDaily.Series["Daily Sales"].Points.AddXY("2019", salary);

            //chartPieDaily.Series["Daily Sales"].XValueMember = "Year";
            //chartPieDaily.Series["Daily Sales"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;

            //chartPieDaily.Series["Daily Sales"].YValueMembers = "Total";
            //chartPieDaily.Series["Daily Sales"].YValueType= System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;

            DailyReport();
        }

        private void btnGraph_Click(object sender, EventArgs e)
        {
            if (btnGraph.Text == "Show Graph")
            {
                chartDaily.Visible = true;
                btnGraph.Text = "Hide Graph";
                btnbar.Visible = true;
                btnpie.Visible = true;
                btnQTY.Visible = true;
                btnSR.Visible = true;
                txtdaily.Text = "Daily Quantity Report";
                btnprint.Visible = false;
                btnup.Visible = false;
                btndown.Visible = false;
                btnsort.Visible = false;
                btnrefresh.Visible = false;
                btncalcu.Visible = false;
                btnBS1.Visible = false;


            }
            else if (btnGraph.Text == "Hide Graph")
            {

                chartDaily.Visible = false;

                btnGraph.Text = "Show Graph";
                btnbar.Visible = false;
                btnpie.Visible = false;
                btnQTY.Visible = false;
                btnSR.Visible = false;

                btnprint.Visible = true;
                btnup.Visible = true;
                btndown.Visible = true;
                btnsort.Visible = true;
                btnrefresh.Visible = true;
                btncalcu.Visible = true;
                btnBS1.Visible = true;
            }
        }

        private void btnpie_Click(object sender, EventArgs e)
        {
            chartDaily.Series["Daily Sales"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
        }

        private void btnbar_Click(object sender, EventArgs e)
        {
            chartDaily.Series["Daily Sales"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
        }

        private void metroTile3_Click(object sender, EventArgs e)

        {
           
            if (btnGraph2.Text == "Show Graph")
            {
                chartWeekly.Visible = true;
                btnGraph2.Text = "Hide Graph";
                btnbar2.Visible = true;
                btnpie2.Visible = true;
                btnQTY2.Visible = true;
                btnSR2.Visible = true;
                txtWeekly.Text = "Weekly Quantity Report";
                btnprint2.Visible = false;
                btnup2.Visible = false;
                btndown2.Visible = false;
                btnsort2.Visible = false;
                btnrefresh2.Visible = false;
                btncalcu2.Visible = false;
              
              
            }
            else if (btnGraph2.Text == "Hide Graph")
            {

                chartWeekly.Visible = false;
              
                btnGraph2.Text = "Show Graph";
                btnbar2.Visible = false;
                btnpie2.Visible = false;
                btnQTY2.Visible = false;
                btnSR2.Visible = false;

                btnprint2.Visible = true;
                btnup2.Visible = true;
                btndown2.Visible = true;
                btnsort2.Visible = true;
                btnrefresh2.Visible = true;
                btncalcu2.Visible = true;
            }
        }

        private void btnpie2_Click(object sender, EventArgs e)
        {
            chartWeekly.Series["Weekly Sales"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
        }

        private void btnbar2_Click(object sender, EventArgs e)
        {
            chartWeekly.Series["Weekly Sales"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
        }

        private void btnQTY2_Click(object sender, EventArgs e)
        {
            txtWeekly.Text = "Weekly Quantity Report";
            foreach (var series in chartWeekly.Series)
            {
                series.Points.Clear();
            }
            WeeklyQuantityReportGraph();
            this.chartWeekly.DataBind();
        }

        private void btnSR2_Click(object sender, EventArgs e)
        {
            txtWeekly.Text = "Weekly Sales Report";

            foreach (var series in chartWeekly.Series)
            {
                series.Points.Clear();
            }
            WeeklySalesReportGraph();
            this.chartWeekly.DataBind();
          
        }
        private void changeRowColor1()
        {
            try
            {


                foreach (DataGridViewRow Myrow in metroGrid2.Rows)
                {
                    if (Myrow.Cells["Status"].Value.ToString() == "Cancelled order")
                    {
                        Myrow.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#F53240");
                        Myrow.DefaultCellStyle.ForeColor = System.Drawing.Color.White;

                    }
                
                 
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }
        private void chartweekly_Click(object sender, EventArgs e)
        {

        }

        private void chartweekly_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {


        //    HitTestResult result = chartweekly.HitTest(e.X, e.Y);



        }
        RectangleF ChartAreaClientRectangle(Chart chart, ChartArea CA)
        {
            RectangleF CAR = CA.Position.ToRectangleF();
            float pw = chart.ClientSize.Width / 100f;
            float ph = chart.ClientSize.Height / 100f;
            return new RectangleF(pw * CAR.X, ph * CAR.Y, pw * CAR.Width, ph * CAR.Height);
        }

        private void chartweekly_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            foreach (ChartArea ca in chartWeekly.ChartAreas)
            {
                if (ChartAreaClientRectangle(chartWeekly, ca).Contains(e.Location))
                {
                   MessageBox.Show(" You have double-clicked on chartarea " + ca.Name);
                    break;
                }
            }
        }

        private void btnQTY_Click(object sender, EventArgs e)
        {
            txtdaily.Text = "Daily Quantity Report";
            foreach (var series in chartDaily.Series)
            {
                series.Points.Clear();
            }
            DailyQuantityReportGraph();
            this.chartDaily.DataBind();
        }

        private void btnSR_Click(object sender, EventArgs e)
        {
            txtdaily.Text = "Daily Sales Report";

            foreach (var series in chartDaily.Series)
            {
                series.Points.Clear();
            }
            DailySalesReportGraph();
            this.chartDaily.DataBind();

        }

        private void btnGraph3_Click(object sender, EventArgs e)
        {
            if (btnGraph3.Text == "Show Graph")
            {
                chartMonthly.Visible = true;
                btnGraph3.Text = "Hide Graph";
                btnbar3.Visible = true;
                btnpie3.Visible = true;
                btnQTY3.Visible = true;
                btnSR3.Visible = true;
                txtmonthly.Text = "Monthly Quantity Report";
                btnprint3.Visible = false;
                btnup3.Visible = false;
                btndown3.Visible = false;
                btnsort3.Visible = false;
                btnrefresh3.Visible = false;
                btncalcu3.Visible = false;


            }
            else if (btnGraph3.Text == "Hide Graph")
            {

                chartMonthly.Visible = false;

                btnGraph3.Text = "Show Graph";
                btnbar3.Visible = false;
                btnpie3.Visible = false;
                btnQTY3.Visible = false;
                btnSR3.Visible = false;

                btnprint3.Visible = true;
                btnup3.Visible = true;
                btndown3.Visible = true;
                btnsort3.Visible = true;
                btnrefresh3.Visible = true;
                btncalcu3.Visible = true;
            }
        }

        private void btnQTY3_Click(object sender, EventArgs e)
        {
            txtmonthly.Text = "Monthly Quantity Report";
            foreach (var series in chartMonthly.Series)
            {
                series.Points.Clear();
            }
            MonthlyQuantityReportGraph();
            this.chartMonthly.DataBind();
        }

        private void btnSR3_Click(object sender, EventArgs e)
        {
            txtmonthly.Text = "Monthly Sales Report";
            foreach (var series in chartMonthly.Series)
            {
                series.Points.Clear();
            }
            MonthlySalesReportGraph();
            this.chartMonthly.DataBind();
        }

        private void btnbar3_Click(object sender, EventArgs e)
        {
            chartMonthly.Series["Monthly Sales"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
        }

        private void btnpie3_Click(object sender, EventArgs e)
        {
            chartMonthly.Series["Monthly Sales"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
        }

        private void btnGraph4_Click(object sender, EventArgs e)
        {
            if (btnGraph4.Text == "Show Graph")
            {
                chartYearly.Visible = true;
                btnGraph4.Text = "Hide Graph";
                btnbar4.Visible = true;
                btnpie4.Visible = true;
                btnQTY4.Visible = true;
                btnSR4.Visible = true;
                btnPercentage4.Visible = true;
                txtyearly.Text = "Yearly Quantity Report";
                btnprint4.Visible = false;
                btnup4.Visible = false;
                btndown4.Visible = false;
                btnsort4.Visible = false;
                btnrefresh4.Visible = false;
                btncalcu4.Visible = false;


            }
            else if (btnGraph4.Text == "Hide Graph")
            {

                chartYearly.Visible = false;

                btnGraph4.Text = "Show Graph";
                btnbar4.Visible = false;
                btnpie4.Visible = false;
                btnQTY4.Visible = false;
                btnSR4.Visible = false;
                btnPercentage4.Visible = false;

                btnprint4.Visible = true;
                btnup4.Visible = true;
                btndown4.Visible = true;
                btnsort4.Visible = true;
                btnrefresh4.Visible = true;
                btncalcu4.Visible = true;
            }
        }

        private void btnQTY4_Click(object sender, EventArgs e)
        {
           // chartYearly.Series["Yearly Sales"].Label = "#0";
            chartYearly.Series["Yearly Sales"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            txtyearly.Text = "Yearly Quantity Report";
            foreach (var series in chartYearly.Series)
            {
                series.Points.Clear();
            }
            YearlyQuantityReportGraph();
            this.chartYearly.DataBind();
        }

        private void btnSR4_Click(object sender, EventArgs e)
        {
            chartYearly.Series["Yearly Sales"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            txtyearly.Text = "Yearly Sales Report";
            foreach (var series in chartYearly.Series)
            {
                series.Points.Clear();
            }
            YearlySalesReportGraph();
            this.chartYearly.DataBind();
        }

        private void btnbar4_Click(object sender, EventArgs e)
        {
            chartYearly.Series["Yearly Sales"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
        }

        private void btnpie4_Click(object sender, EventArgs e)
        {
            chartYearly.Series["Yearly Sales"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
        }

        private void btnBS1_Click(object sender, EventArgs e)
        {
          

            if (btnBS1.Text == "Best Delivery Products")
            {
                var myForm = new frm_optionreport();
                myForm.ShowDialog();
              
                chartDaily.Visible = false;
                btnBS1.Text = "Daily Report";
                btnbar.Visible = true;
                btnpie.Visible = true;
                btnQTY.Visible = true;
                btnSR.Visible = true;
            
                btnprint.Visible = false;
                btnup.Visible = false;
                btndown.Visible = false;
                btnsort.Visible = false;
                btnrefresh.Visible = false;
                btncalcu.Visible = false;


                btnGraph.Enabled = false;
                btnQTY.Visible = false;
                btnSR.Visible = false;
                btnbar.Visible = false;
                btnpie.Visible = false;

                txtdaily.Location = new Point(153,117);

                DGVDailyBestSeller();
                DailyTop();




                  
                txtdaily.Text = frm_optionreport.option_name + " Top " +top_id+ " Best Delivery Products";

            }
            else if (btnBS1.Text == "Daily Report")
            {

                chartDaily.Visible = false;

                btnBS1.Text = "Best Delivery Products";
                btnbar.Visible = false;
                btnpie.Visible = false;
                btnQTY.Visible = false;
                btnSR.Visible = false;
                txtdaily.Text = "Daily Report";
                btnprint.Visible = true;
                btnup.Visible = true;
                btndown.Visible = true;
                btnsort.Visible = true;
                btnrefresh.Visible = true;
                btncalcu.Visible = true;

                btnGraph.Enabled = true;


                txtdaily.Location = new Point(287, 117);

                DailyReport();

            }



        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
           
        }

        private void btnHome1_Click(object sender, EventArgs e)
        {
            var pleaseWait = new frm_PleaseWait();
            pleaseWait.Show();
            Application.DoEvents();
            System.Windows.Forms.Cursor var = Cursors.WaitCursor;
            var myForm = new frm_MainHomeManager(manager);
            myForm.Show();
            pleaseWait.Hide();

            this.Hide();
        }

        private void button18_Click_1(object sender, EventArgs e)
        {
            var pleaseWait = new frm_PleaseWait();
            pleaseWait.Show();
            Application.DoEvents();
            System.Windows.Forms.Cursor var = Cursors.WaitCursor;
            var myForm = new frm_TransactionRecord();
            myForm.Show();
            pleaseWait.Hide();

            this.Hide();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            var pleaseWait = new frm_PleaseWait();
            pleaseWait.Show();
            Application.DoEvents();
            System.Windows.Forms.Cursor var = Cursors.WaitCursor;
            var myForm = new frm_Inventory();
            myForm.Show();
            pleaseWait.Hide();

            this.Hide();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            var pleaseWait = new frm_PleaseWait();
            pleaseWait.Show();
            Application.DoEvents();
            System.Windows.Forms.Cursor var = Cursors.WaitCursor;
            var myForm = new frm_Supplier();
            myForm.Show();
            pleaseWait.Hide();

            this.Hide();
        }

        private void btnmanageaccounts_Click(object sender, EventArgs e)
        {
            var pleaseWait = new frm_PleaseWait();
            pleaseWait.Show();
            Application.DoEvents();
            System.Windows.Forms.Cursor var = Cursors.WaitCursor;
            var myForm = new frm_AccountManager();
            myForm.Show();
            pleaseWait.Hide();

            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            var pleaseWait = new frm_PleaseWait();
            pleaseWait.Show();
            Application.DoEvents();
            System.Windows.Forms.Cursor var = Cursors.WaitCursor;
            var myForm = new frm_LoginHistory();
            myForm.Show();
            pleaseWait.Hide();

            this.Hide();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Are you sure, you want to logout?", "Fabula's Merchandise System", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;
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

                    System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;
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

        private void btnBS2_Click(object sender, EventArgs e)
        {
            if (btnBS2.Text == "Best Delivery Products")
            {
                chartWeekly.Visible = false;
                btnBS2.Text = "Weekly Report";
                btnbar2.Visible = true;
                btnpie2.Visible = true;
                btnQTY2.Visible = true;
                btnSR2.Visible = true;

                btnprint2.Visible = false;
                btnup2.Visible = false;
                btndown2.Visible = false;
                btnsort2.Visible = false;
                btnrefresh2.Visible = false;
                btncalcu2.Visible = false;


                btnGraph2.Enabled = false;
                btnQTY2.Visible = false;
                btnSR2.Visible = false;
                btnbar2.Visible = false;
                btnpie2.Visible = false;

                txtWeekly.Location = new Point(153, 117);

                DGVWeeklySeller();
                WeeklyTop();





                txtWeekly.Text = "Weekly Top " + top_id2 + " Best Delivery Products";

            }
            else if (btnBS2.Text == "Weekly Report")
            {

                chartWeekly.Visible = false;

                btnBS2.Text = "Best Delivery Products";
                btnbar2.Visible = false;
                btnpie2.Visible = false;
                btnQTY2.Visible = false;
                btnSR2.Visible = false;
                txtWeekly.Text = "Weekly Report";
                btnprint2.Visible = true;
                btnup2.Visible = true;
                btndown2.Visible = true;
                btnsort2.Visible = true;
                btnrefresh2.Visible = true;
                btncalcu2.Visible = true;

                btnGraph2.Enabled = true;


                txtWeekly.Location = new Point(287, 117);

                WeeklyReport();

            }
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (!metroGrid2.Rows[metroGrid2.CurrentCell.RowIndex].IsNewRow)
                {
                    foreach (DataGridViewCell cell in metroGrid2.Rows[metroGrid2.CurrentCell.RowIndex].Cells)
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

            string titlereport = "Payment to Supplier Report";
            DGVPrinter printer = new DGVPrinter();
            printer.Title = titlereport;
            printer.SubTitle = string.Format("Date: {0}", lblTime.Text);
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "Fabula's Merchandise.";
            printer.FooterSpacing = 15;
            printer.PrintDataGridView(metroGrid2);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (!metroGrid5.Rows[metroGrid5.CurrentCell.RowIndex].IsNewRow)
                {
                    foreach (DataGridViewCell cell in metroGrid5.Rows[metroGrid5.CurrentCell.RowIndex].Cells)
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

            string titlereport = cbStore.Text + " Stock Adjustment Report";
            DGVPrinter printer = new DGVPrinter();
            printer.Title = titlereport;
            printer.SubTitle = string.Format("Date: {0}", lblTime.Text);
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "Fabula's Merchandise.";
            printer.FooterSpacing = 15;
            printer.PrintDataGridView(metroGrid5);
        }

        private void button9_Click_1(object sender, EventArgs e)
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

            string titlereport ="Warehouse Backorder Report";
            DGVPrinter printer = new DGVPrinter();
            printer.Title = titlereport;
            printer.SubTitle = string.Format("Date: {0}", lblTime.Text);
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "Fabula's Merchandise.";
            printer.FooterSpacing = 15;
            printer.PrintDataGridView(metroGrid3);
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (!metroGrid6.Rows[metroGrid6.CurrentCell.RowIndex].IsNewRow)
                {
                    foreach (DataGridViewCell cell in metroGrid6.Rows[metroGrid6.CurrentCell.RowIndex].Cells)
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

            string titlereport = cbStore.Text + " Backorder Report";
            DGVPrinter printer = new DGVPrinter();
            printer.Title = titlereport;
            printer.SubTitle = string.Format("Date: {0}", lblTime.Text);
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "Fabula's Merchandise.";
            printer.FooterSpacing = 15;
            printer.PrintDataGridView(metroGrid6);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                if (!metroGrid4.Rows[metroGrid4.CurrentCell.RowIndex].IsNewRow)
                {
                    foreach (DataGridViewCell cell in metroGrid4.Rows[metroGrid4.CurrentCell.RowIndex].Cells)
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

            string titlereport = "Warehouse Critical Level Report";
            DGVPrinter printer = new DGVPrinter();
            printer.Title = titlereport;
            printer.SubTitle = string.Format("Date: {0}", lblTime.Text);
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "Fabula's Merchandise.";
            printer.FooterSpacing = 15;
            printer.PrintDataGridView(metroGrid4);
        }

        private void button12_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (!metroGrid8.Rows[metroGrid8.CurrentCell.RowIndex].IsNewRow)
                {
                    foreach (DataGridViewCell cell in metroGrid8.Rows[metroGrid8.CurrentCell.RowIndex].Cells)
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

            string titlereport = cbStore.Text + " Critical Level Report";
            DGVPrinter printer = new DGVPrinter();
            printer.Title = titlereport;
            printer.SubTitle = string.Format("Date: {0}", lblTime.Text);
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "Fabula's Merchandise.";
            printer.FooterSpacing = 15;
            printer.PrintDataGridView(metroGrid8);
        }

        private void btnPercentage4_Click(object sender, EventArgs e)
        {
          
            chartYearly.Series["Yearly Sales"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            txtyearly.Text = "Yearly Sales Report";
            foreach (var series in chartYearly.Series)
            {
                series.Points.Clear();
            }
            salespermonth();
            this.chartYearly.DataBind();
          
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
 