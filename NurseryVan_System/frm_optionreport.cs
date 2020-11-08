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
    public partial class frm_optionreport : Form
    {
        public static string options;
        public static string option_name;
        public frm_optionreport()
        {
            InitializeComponent();
        }

        private void btnDaily_Click(object sender, EventArgs e)
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
                     //   options = " tbl_transactionrecord.date >= DATE(NOW()) ";
                        options = " tbl_critical.date >= DATE(NOW()) ";
                        option_name = "Daily ";
                        this.Hide();
                    }


                }
            }
            catch (NullReferenceException)
            {

             

            }



        

        }

        private void btnWeekly_Click(object sender, EventArgs e)
        {




            options = " weekofyear(tbl_critical.date) = weekofyear(NOW()) ";
            option_name = "Weekly ";
            this.Hide();

        }

        private void btnMonthly_Click(object sender, EventArgs e)
        {


            options = " month(tbl_critical.date) = Month(NOW()) ";
            option_name = "Monthly ";
            this.Hide();



        }

        private void btnYearly_Click(object sender, EventArgs e)
        {



            options = " year(tbl_critical.date) = Year(NOW()) ";
            option_name = "Yearly ";

            this.Hide();


        }

        private void frm_optionreport_Load(object sender, EventArgs e)
        {
            label1.Text = frm_Report.global_store_id;
            DailyReport();
            WeeklyReport();
            MonthlyReport();
            YearlyReport();



        }
        void DailyReport()
        {
            // titlereport = "Daily Report";

            MySqlConnection Conn = ConString.Connection;
            MySqlCommand cmd = new MySqlCommand("SELECT tbl_product.category as 'Category', tbl_product.product_name as 'Product Name', tbl_product.remarks as 'SRP', sum(tbl_critical.quantity) as 'Quantity', sum(tbl_critical.quantity) * tbl_product.remarks as 'Amount' FROM tbl_product inner join tbl_critical on tbl_product.product_id = tbl_critical.product_id where tbl_critical.date >= DATE(NOW())  and tbl_critical.store_id = '" + frm_Report.global_store_id + "' group by tbl_product.product_id order by tbl_critical.date asc;", Conn);


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
                //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                //  this.dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


                Conn.Close();

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

                    btnDaily.Enabled = false;

                    btnDaily.BackColor = Color.Gray;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }



        void WeeklyReport()
        {
            // titlereport = "Daily Report";
            MySqlConnection Conn = ConString.Connection;
            MySqlCommand cmd = new MySqlCommand("SELECT tbl_product.category as 'Category', tbl_product.product_name as 'Product Name', tbl_product.remarks as 'SRP', sum(tbl_critical.quantity) as 'Quantity', sum(tbl_critical.quantity) * tbl_product.remarks as 'Amount', dayname(tbl_critical.date) as 'Day', date(tbl_critical.date) as 'Date' FROM tbl_product inner join tbl_critical on tbl_product.product_id = tbl_critical.product_id where weekofyear(tbl_critical.date) = weekofyear(NOW())  and tbl_critical.store_id = '" +frm_Report.global_store_id + "' group by tbl_product.product_id order by tbl_critical.date asc;", Conn);


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

                    btnWeekly.Enabled = false;
                    btnWeekly.BackColor = Color.Gray;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("keme" + ex.Message);
            }
        }


        void MonthlyReport()
        {
            // titlereport = "Daily Report";
            MySqlConnection Conn = ConString.Connection;
            MySqlCommand cmd = new MySqlCommand("SELECT tbl_product.category as 'Category', tbl_product.product_name as 'Product Name', tbl_product.remarks as 'SRP', sum(tbl_critical.quantity) as 'Quantity', sum(tbl_critical.quantity) * tbl_product.remarks as 'Amount', week(tbl_critical.date) as 'Week', date(tbl_critical.date) as 'Date' FROM tbl_product inner join tbl_critical on tbl_product.product_id = tbl_critical.product_id where month(tbl_critical.date) = Month(NOW())  and tbl_critical.store_id = '" + frm_Report.global_store_id + "' group by tbl_product.product_id order by tbl_critical.date asc;", Conn);


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

                    btnMonthly.Enabled = false;
                    btnMonthly.BackColor = Color.Gray;

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        void YearlyReport()
        {
            // titlereport = "Daily Report";
            MySqlConnection Conn = ConString.Connection;
            MySqlCommand cmd = new MySqlCommand("SELECT tbl_product.category as 'Category', tbl_product.product_name as 'Product Name', tbl_product.remarks as 'SRP', sum(tbl_critical.quantity) as 'Quantity', sum(tbl_critical.quantity) * tbl_product.remarks as 'Amount', monthname(tbl_critical.date) as 'Month', date(tbl_critical.date) as 'Date' FROM tbl_product inner join tbl_critical on tbl_product.product_id = tbl_critical.product_id where year(tbl_critical.date) = Year(NOW())  and tbl_critical.store_id = '" + frm_Report.global_store_id + "' group by tbl_product.product_id, Month order by tbl_critical.date;", Conn);


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

                    btnYearly.Enabled = false;
                    btnYearly.BackColor = Color.Gray;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    









    }
}
