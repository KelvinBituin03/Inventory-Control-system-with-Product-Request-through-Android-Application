using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using NurseryVan_System.Database;

namespace NurseryVan_System
{
    class AutoGenerator
    {
        public static void autoincrement(string sqlquery, Control textbox)
        {
            // string Connection = "SERVER = 139.162.37.87;PORT=3306;DATABASE=wzfbmehbvk;UID=wzfbmehbvk;PASSWORD= wgkTtZJC96;Allow User Variables=True;";
            //    string Connection = @"datasource=192.168.43.5;port=3306;DATABASE=wzfbmehbvk;username=root;password=pass;Allow User Variables=True;";
            //  string Connection = "datasource=localhost;port=3306;DATABASE=wzfbmehbvk;username=root;password=1234;Allow User Variables=True";
            String Connection = @"datasource=192.168.43.4;port=3306;DATABASE=wzfbmehbvk;username=root;password=pass;Allow User Variables=True;";
            string Query = sqlquery;
            try
            {
                MySqlConnection Conn = new MySqlConnection(Connection);
                MySqlCommand cmd = new MySqlCommand(Query, Conn);
                Conn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                try
                {
                    if (dr.Read())
                    {

                        string value = dr[0].ToString();
                        if (value == "")
                        {

                            textbox.Text = "1";
                        }
                        else
                        {

                            int x = 1 + Convert.ToInt16(dr[0].ToString());
                            textbox.Text = x.ToString();

                        }
                    }
                }
                catch (NullReferenceException)
                {


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

