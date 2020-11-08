using NurseryVan_System.Database;
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

namespace NurseryVan_System
{
    public partial class frm_subLoading : Form
    {
        public frm_subLoading()
        {
            InitializeComponent();
        }
        public void Online()
        {
            MySqlConnection Conn = ConString.Connection;


            AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();

            string Query = "UPDATE wzfbmehbvk.tbl_loginhistory set status = 'Online' where login_id = '" + frm_Login.loginID + "'";
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
        private void frm_subLoading_Load(object sender, EventArgs e)
        {
            Online();
        }
    }
}
