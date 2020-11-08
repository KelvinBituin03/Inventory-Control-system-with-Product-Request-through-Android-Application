using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace NurseryVan_System.Database
{
    public class ConString
    {

        private static MySqlConnection _Connection;
        public static string ip = "139.162.37.87";
        public static MySqlConnection Connection
       
        {

            //string Connection = "datasource=localhost;port=3306;username=root;password=1234";
            //Server=localhost; userid=root; password='1234'; database =nurseryvan_db
        get
            {
                //"SERVER= kelvinsample.x10host.com;PORT=3306;DATABASE=kelvinsa_sampledatabase;UID=kelvinsa;PASSWORD=RamkelvS;

                // @"Server=localhost;port=3306;username=root;password=1234;Allow User Variables=True;"

                //SERVER = 166.62.28.145; PORT = 3306; DATABASE = kelvinsa_sampledatabase; UID = kelvinsa; PASSWORD = RamkelvS;

             
                //166.62.28.145
                if (_Connection == null)
                {
                     // String cs = "datasource=localhost;port=3306;username=root;password=1234;Allow User Variables=True";
                    //    String cs = @"SERVER = 139.162.37.87;PORT=3306;DATABASE=wzfbmehbvk;UID=wzfbmehbvk;PASSWORD= wgkTtZJC96;Allow User Variables=True;";
                    // String cs = @"SERVER = 139.162.37.87;PORT=3306;DATABASE=wzfbmehbvk;UID=wzfbmehbvk;PASSWORD= wgkTtZJC96;Allow User Variables=True;";
                      String cs = @"datasource=192.168.43.4;port=3306;DATABASE=wzfbmehbvk;username=root;password=pass;Allow User Variables=True;";
                    // string cs = "datasource=localhost;port=3306;DATABASE=wzfbmehbvk;username=root;password=1234;Allow User Variables=True";
                    _Connection = new MySqlConnection(cs);
               }

                if (_Connection.State == System.Data.ConnectionState.Closed)
                    try
                    {
                        _Connection.Open();
                    }
                    catch (Exception ex)
                    {
                      
                    }

                return _Connection;
            }

        }









    //    public void constring()

    //    {
    //    public string ip = "localhost";
    //    public string port = "3306";
    //    public string database = "nurseryvan_db";

    //}

    //  string Cons = "{0},{1},{2}";
    }
}
