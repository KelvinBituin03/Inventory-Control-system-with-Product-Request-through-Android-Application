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
    public partial class frm_Void : Form
    {
        public frm_Void()
        {
            InitializeComponent();
        }

       
        MySqlDataReader myReader;
        MySqlCommand cmd;
        public static string manager;
        public static string user;
        public static string qty;
        public static string total1;
        public static string  vat;
        string managercode;
        string Query;
        int val1, val2;
        string Void = "Voided";
        double cash = 0.00;
        double change = 0.00;
        double total = 0.00;
        string ordertype = "None";
        static int attempt = 3;
        public static Action worker { get; set; }

        private void frm_Void_Load(object sender, EventArgs e)
        {
            lblVoidItem.Text = ("VOID ITEM: ") + frm_POS.subproductname;
            lblproduct.Text = frm_POS.subproductname;
           // label2.Text = frm_Login.global_storeid;
            this.AcceptButton = btnOk;
            if (attempt == 0)
            {


                lblCountDown.Visible = true;
                btnOk.Enabled = false;
                timer1 = new System.Windows.Forms.Timer();
                timer1.Tick += new EventHandler(timer1_Tick);
                timer1.Interval = 1000; // 1 second
                timer1.Start();
                counter = 10;
                lblCountDown.Text = ("Try again in ") + counter.ToString() + (" seconds.");





            }
            else if (attempt == -1)
            {
                counter = 30;
                lblCountDown.Visible = true;
                btnOk.Enabled = false;
                timer1 = new System.Windows.Forms.Timer();
                timer1.Tick += new EventHandler(timer1_Tick);
                timer1.Interval = 1000; // 1 second
                timer1.Start();
                lblCountDown.Text = ("Try again in ") + counter.ToString() + (" seconds.");

                counter = 30;

            }
            else if (attempt <= -2)
            {
                counter = 60;
                lblCountDown.Visible = true;
                btnOk.Enabled = false;
                timer1 = new System.Windows.Forms.Timer();
                timer1.Tick += new EventHandler(timer1_Tick);
                timer1.Interval = 1000; // 1 second
                timer1.Start();
                lblCountDown.Text = ("Try again in ") + counter.ToString() + (" seconds.");

                counter = 60;

            }
        }
        private int counter = 10;

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {

                counter--;
                if (counter == 0)
                    timer1.Stop();
                lblCountDown.Text = ("Try again in ") + counter.ToString() + (" seconds.");
                if (counter == 1)
                {

                    lblCountDown.Text = ("Try again in ") + counter.ToString() + (" second.");
                }

                if (counter == 0)
                {
                    this.btnOk.Enabled = true;
                    this.AcceptButton = btnOk;
                    lblCountDown.Visible = false;
                    return;
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtCode_TextChanged(object sender, EventArgs e)
        {
            txtCode.PasswordChar = '•';
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCode.Text == "")
                {
                    return;
                }
                Cursor.Current = Cursors.AppStarting;
                string password = txtCode.Text;


                if (password.Contains(@"\"))

                {

                    MessageBox.Show("Your password is invalid for using " + @"'\'", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCode.Text = "";
                    return;
                }
                string supervisor = "Supervisor";
                MySqlConnection Conn = ConString.Connection;
                cmd = new MySqlCommand("Select * from tbl_login where user_type = '" + supervisor + "' and store_id = '"+frm_Login.global_storeid+"'", Conn);
                cmd.CommandTimeout = 0;
                try
                {
                    myReader = cmd.ExecuteReader();
                    while (myReader.Read())
                    {
                        managercode = myReader.GetString("password");
                    }
                    Conn.Close();
                }
                catch (Exception)
                {

                }

                if (managercode == txtCode.Text)
                {
                    attempt = 3;
                    try
                    {
                        val1 = int.Parse(frm_POS.subqty);
                        val2 = int.Parse(frm_POS.substock);
                        try
                        {
                         Conn = ConString.Connection;
                            Query = "delete from subtbl_cart where product_id = '" + frm_POS.foreignproductid + "' and store_id = '"+frm_Login.global_storeid+"'";


                            cmd = new MySqlCommand(Query, Conn);
                            cmd.CommandTimeout = 0;
                            myReader = cmd.ExecuteReader();



                            MessageBox.Show(lblproduct.Text + " voided successfully.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Conn.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Fabula's Merchandise System", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                        }


                        try
                        {

                             Conn = ConString.Connection;
                            Query = "update tbl_inventory set QTY =  QTY + '" + val1 + "' WHERE product_id = '" + frm_POS.foreignproductid + "' and store_id = '"+frm_Login.global_storeid+"' ";
                            cmd = new MySqlCommand(Query, Conn);
                            cmd.CommandTimeout = 0;
                            myReader = cmd.ExecuteReader();
                            Conn.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Fabula's Merchandise System", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                        }



                      

                         Conn = ConString.Connection;
                        Query = "insert into tbl_transactionrecord(trans_id, product_id, product_name,quantity, status, dateortime, store_id) values('" + frm_POS.recoidId + "', '" + frm_POS.foreignproductid + "', '" + frm_POS.subproductname + "', '"+frm_POS.subqty+"','" +Void+ "' , '" + frm_POS.date + "', '"+frm_Login.global_storeid+"')";
                    

                       cmd = new MySqlCommand(Query, Conn);
                        cmd.CommandTimeout = 0;

                        myReader = cmd.ExecuteReader();
                        Conn.Close();




                     

                        this.Hide();

                    }
                    catch (FormatException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }




















                }
                else
                {
                    attempt--;
                    MessageBox.Show("Supervisor's code doesn't match.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCode.Clear();
                }
                if (attempt == 0)
                {


                    lblCountDown.Visible = true;
                    btnOk.Enabled = false;
                    timer1 = new System.Windows.Forms.Timer();
                    timer1.Tick += new EventHandler(timer1_Tick);
                    timer1.Interval = 1000; // 1 second
                    timer1.Start();
                    counter = 10;
                    lblCountDown.Text = ("Try again in ") + counter.ToString() + (" seconds.");





                }
                else if (attempt == -1)
                {
                    counter = 30;
                    lblCountDown.Visible = true;
                    btnOk.Enabled = false;
                    timer1 = new System.Windows.Forms.Timer();
                    timer1.Tick += new EventHandler(timer1_Tick);
                    timer1.Interval = 1000; // 1 second
                    timer1.Start();
                    lblCountDown.Text = ("Try again in ") + counter.ToString() + (" seconds.");

                    counter = 30;

                }
                else if (attempt <= -2)
                {
                
                    counter = 60;
                    lblCountDown.Visible = true;
                    btnOk.Enabled = false;
                    timer1 = new System.Windows.Forms.Timer();
                    timer1.Tick += new EventHandler(timer1_Tick);
                    timer1.Interval = 1000; // 1 second
                    timer1.Start();
                    lblCountDown.Text = ("Try again in ") + counter.ToString() + (" seconds.");

                    counter = 60;

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
