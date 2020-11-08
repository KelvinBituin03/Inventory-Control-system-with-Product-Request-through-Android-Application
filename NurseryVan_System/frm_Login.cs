using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using NurseryVan_System.Database;
using System.Speech.Recognition;

namespace NurseryVan_System
{

    public partial class frm_Login : Form
    {
        SpeechRecognitionEngine recEngine = new SpeechRecognitionEngine();


        public static string user;
        public static string stockman;
        public static string stockman1;
        public static string manager;
        public static string managerpassword;
        public static string firstname; public static string myName;
        public static string lastname;  public static string surname;
        public static string loginID;
        public static string time;
        public static string password;
        public static string userpassword;
        public static string user2;
        string online;
        public static string Admin;
        public static string store;
        public static string global_storeid;
        public static string username;

        int store_id;
        public static string supervisor;


        int store_ID;

        public static string GeneralID;
 
        public static string getlastname;
        public static string getusername;
        public static string getpassword;

       static int attempt = 4;
        string status;
        string storename;


        public frm_Login()
        {
          
            InitializeComponent();
        

        }

        public void generator1()
        {
            NurseryVan_System.AutoGenerator.autoincrement("select max(login_id) from tbl_loginhistory ", txtLoginID);
        }


        private void txtusername2_Leave(object sender, EventArgs e)
        {
            if (txtUsername.Text.Length == 0)
            {
                txtUsername.Text = "Username";
                txtUsername.ForeColor = SystemColors.GrayText;
            }
        }

        private void txtusername2_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtUsername.Text.Equals(null) == true)
            {
                txtUsername.Text = "Username";
                txtUsername.ForeColor = Color.Gray;
            }
            else if (txtUsername.Text == "Username")
            {
                txtUsername.ForeColor = Color.Gray;
            }


            else
            {

                txtUsername.ForeColor = Color.Black;


            }


            if (e.KeyCode == Keys.Back)
            {
                if (txtUsername.Text.Length == 0)
                {


                    txtUsername.Text = "Username";

                    txtUsername.ForeColor = Color.Gray;
                    ///     Cursor.Current = Cursors.IBeam;

                }
            }
        }

        private void txtusername2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtUsername.Text == "Username")
            {
                txtUsername.Text = "";

            }
        }

        private void txtusername2_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "Username")
            {
                txtUsername.Focus();
                txtUsername.Select(0, 0);

            }
        }

        private void txtPassword2_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text.Length == 0)
            {
                txtPassword.Text = "Password";
                txtPassword.ForeColor = SystemColors.GrayText;
            }
        }

        private void txtPassword2_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtPassword.Text.Equals(null) == true)
            {
                txtPassword.Text = "Password";
                txtPassword.ForeColor = Color.Gray;
            }
            else if (txtPassword.Text == "Password")
            {
                txtPassword.ForeColor = Color.Gray;
            }


            else
            {

                txtPassword.ForeColor = Color.Black;


            }


            if (e.KeyCode == Keys.Back)
            {
                if (txtPassword.Text.Length == 0)
                {


                    txtPassword.Text = "Password";
                    txtPassword.PasswordChar = '\0';
                    txtPassword.ForeColor = Color.Gray;
                    ///     Cursor.Current = Cursors.IBeam;


                }



            }
        }

        private void txtPassword2_KeyDown(object sender, KeyEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (e.KeyCode == Keys.Enter)
            {


                btnLogin.PerformClick();

                if (txtPassword.Text == "Password")
                {

                    txtUsername.Focus();
                    txtUsername.Select(0, 0);


                }

            }

            if (txtPassword.Text == "Password")
            {
                txtPassword.Text = "";

            }

        }

        private void checkBoxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
           // txtPassword.PasswordChar = checkBoxShowPassword.Checked ? '\0' : '•';
        }

        private void checkBoxRememberpass_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxRememberpass.Checked)
            {

                Properties.Settings.Default.UserName = txtUsername.Text;
                Properties.Settings.Default.UserPass = txtPassword.Text;
                Properties.Settings.Default.Save();
            }
            if (checkBoxRememberpass.Checked == false)
            {
                txtUsername.Text = "Username";
                txtPassword.Text = "Password";
                txtPassword.PasswordChar = '\0';
                txtUsername.ForeColor = Color.Gray;
                txtPassword.ForeColor = Color.Gray;
                txtUsername.Focus();
                txtUsername.Select(0, 0);
                checkBoxRememberpass.Checked = false;
                Properties.Settings.Default.Reset();
            }
        }

      
        private int counter = 10;
        private void btnLogin_Click(object sender, EventArgs e)
        {
            // getUsernameandPassword();
            generator1();
            lblinitializing.Show();
            lblTime.Text = DateTime.Now.ToShortTimeString();
            if (txtUsername.Text == "Username" && txtPassword.Text == "Password")
            {
                string myStringVariable1 = string.Empty;
                lblinitializing.Hide();
                MessageBox.Show("Enter username and password!", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.None);
                txtPassword.Text = "";
                txtUsername.Text = "";

                txtUsername.Focus();
                txtUsername.Select(0, 0);
                return;

            }

            if (txtUsername.Text == "" && txtPassword.Text == "")
            {
                string myStringVariable1 = string.Empty;
                lblinitializing.Hide();
                MessageBox.Show("Enter username and password!", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.None);
                txtPassword.Text = "";
                txtUsername.Text = "";

                txtUsername.Focus();
                txtUsername.Select(0, 0);
                return;
            }
            else if (txtPassword.Text == "" || txtPassword.Text == "Password")
            {
                string myStringVariable2 = string.Empty;
                lblinitializing.Hide();
                MessageBox.Show("Enter password!", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.None);
                txtPassword.Focus();

                txtPassword.Select(0, 0);
                return;
            }
            if (txtUsername.Text == "" || txtUsername.Text == "Username")
            {
                string myStringVariable2 = string.Empty;
                lblinitializing.Hide();
                MessageBox.Show("Enter username!", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.None);

                txtUsername.Focus();
                txtUsername.Select(0, 0);

                return;
            }
            string password = txtPassword.Text;


            if (password.Contains(@"\") || password.Contains("'"))

            {
                lblinitializing.Hide();
                MessageBox.Show("Your password is invalid using symbol.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Text = "";
                txtPassword.Focus();

                txtPassword.Select(0, 0);
                return;
            }




            //   myprogressBar1.Visible = true; label3.Visible = true; pictureBox2.Visible = true;


            MySqlConnection Conn = ConString.Connection;
            MySqlCommand cmd = new MySqlCommand(" select * from tbl_login where username = '" + this.txtUsername.Text + "' and password = '" + this.txtPassword.Text + "' and status = 'Active';insert into tbl_loginhistory (Login_Id, username, time_in, date) values ('" + txtLoginID.Text + "', '" + this.txtUsername.Text + "', '" + lblTime.Text + "', '" + dateTimePicker1.Text + "')", Conn);
            //cmd.CommandTimeout = 500000;
            int count = 0;
            try
            {

                MySqlDataReader myReader;
               
                myReader = cmd.ExecuteReader();

                while (myReader.Read())
                {
                    count += 1;
                    manager = myReader["user_type"].ToString();
                    user = myReader["user_type"].ToString();
                    Admin = myReader["user_type"].ToString();
                    stockman = myReader["user_type"].ToString();
                    supervisor = myReader["user_type"].ToString();
                    stockman1 = myReader["user_type"].ToString();
                    loginID = myReader.GetString("login_id");
                    firstname = myReader.GetString("firstname");
                    lastname = myReader.GetString("lastname");
                    username = myReader.GetString("lastname");


                }
                Conn.Close();
                //case sensitive username
                  if (txtPassword.Text != getpassword || txtUsername.Text != getusername || status == "Deactivate")

                {



                    attempt--;
                   
                    lblinitializing.Hide();

                    MessageBox.Show("You've entered incorrect username or password. Please try again.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsername.ForeColor = Color.Gray;

                    checkBoxRememberpass.Checked = false;
                  
                    txtPassword.Text = "Password";
                    txtUsername.Text = "Username";
                    

                    txtUsername.Focus();
                    txtUsername.Select(0, 0);

                     Conn = ConString.Connection;
                    cmd = new MySqlCommand("delete from tbl_loginhistory where login_id = '" + this.txtLoginID.Text + "'", Conn);
                   // cmd.CommandTimeout = 500000;
                  
                    myReader = cmd.ExecuteReader();
                    txtPassword.PasswordChar =  '\0';
                    txtPassword.ForeColor = Color.Gray;

                    while (myReader.Read())
                    {


                    }
                    Conn.Close();

                    if (attempt == 0)
                    {



                        lblCountDown.Visible = true;
                        btnLogin.Enabled = false;
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
                        btnLogin.Enabled = false;
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
                        btnLogin.Enabled = false;
                        timer1 = new System.Windows.Forms.Timer();
                        timer1.Tick += new EventHandler(timer1_Tick);
                        timer1.Interval = 1000; // 1 second
                        timer1.Start();
                        lblCountDown.Text = ("Try again in ") + counter.ToString() + (" seconds.");

                        counter = 60;

                    }
                   
                    return;
                }
        else  if (count == 1)
                {


                    if (manager == "Manager")
                    {
                        attempt = 4;

                        //    managerpassword = txtPassword.Text;
                        time = lblTime.Text;
                        loginID = txtLoginID.Text;
                        GeneralID = txtGeneralID.Text;
                        username = txtUsername.Text;
                        myName = firstname;
                        frm_MainHomeManager.myName = ("Hi, ") + myName + (" Welcome to Fabula's Merchandise.");
                        frm_AccountManager.myName = myName + ("'s Password Account");
                        btnLogin.Focus();
                        

                        for (int i = 0; i <= 100; i++)
                        {
                           
                            Thread.Sleep(5);
                            Cursor.Current = Cursors.WaitCursor;


                        }
                        lblinitializing.Show();



                        if (online == "Online" && username == txtUsername.Text)
                        {
                            //Cursor.Current = Cursors.WaitCursor;
                            //frm_Login.time = DateTime.Now.ToShortTimeString();

                            // Conn = ConString.Connection;
                            // cmd = new MySqlCommand("update tbl_loginhistory set time_out = '" + frm_Login.time + "', status = 'Offline' where login_id = '" + frm_Login.loginID + "'", Conn);



                            //myReader = cmd.ExecuteReader();

                            //while (myReader.Read())
                            //{



                            //}
                            //Conn.Close();
                            MessageBox.Show("Access denied: your account is in another logged in.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Cursor.Current = Cursors.AppStarting;
                            var myForm = new frm_Login();
                            myForm.Show();
                            this.Hide();
                            return;
                        }

                        Cursor.Current = Cursors.WaitCursor;
                        var pleaseWait = new frm_subLoading();
                        pleaseWait.Show();
                        Application.DoEvents();
                        Cursor.Current = Cursors.WaitCursor;
                        var myForm1 = new frm_MainHomeManager(manager);
                        myForm1.Show();
                        pleaseWait.Hide();

                        this.Hide();
                        Cursor.Current = Cursors.AppStarting;


                    }
                    else if (user == "Staff")

                    {
                        attempt = 4;


                        username = txtUsername.Text;

                        time = lblTime.Text;
                        loginID = txtLoginID.Text;
                        myName = firstname;
                        surname = lastname;

                        userpassword = txtPassword.Text;
                        GeneralID = txtGeneralID.Text;
                        global_storeid = txtstore_id.Text;
                        getlastname = txtlastname.Text;
                        //global_storeid = cbStore.Text;
                        frm_POS.myName = myName;
                        frm_POS.surname = surname;
                        frm_MainHomeStaff.myName = ("Hi, ") + firstname + (" Welcome to Fabula's Merchandise.");
                        frm_AccountStaff.myName = myName + ("'s Password Account");
                        btnLogin.Focus();
                        Cursor.Current = Cursors.WaitCursor;
                       
                      
                        lblinitializing.Show();

                        if (online == "Online" && username == txtUsername.Text)
                        {
                            //Cursor.Current = Cursors.WaitCursor;
                            //frm_Login.time = DateTime.Now.ToShortTimeString();

                            // Conn = ConString.Connection;
                            // cmd = new MySqlCommand("update tbl_loginhistory set time_out = '" + frm_Login.time + "', status = 'Offline' where login_id = '" + frm_Login.loginID + "'", Conn);



                            //myReader = cmd.ExecuteReader();

                            //while (myReader.Read())
                            //{



                            //}
                            //Conn.Close();
                            MessageBox.Show("Access denied: your account is in another logged in.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Cursor.Current = Cursors.AppStarting;
                            var myForm = new frm_Login();
                            myForm.Show();
                            this.Hide();
                            return;
                        }

                        Cursor.Current = Cursors.WaitCursor;
                        var pleaseWait = new frm_subLoading();
                        pleaseWait.Show();
                        Application.DoEvents();
                        Cursor.Current = Cursors.WaitCursor;
                        var myForm1 = new frm_POS();
                        myForm1.Show();
                        pleaseWait.Hide();

                        this.Hide();
                        Cursor.Current = Cursors.AppStarting;
                    }
                    else if (supervisor == "Supervisor")

                    {
                        attempt = 4;



                        username = txtUsername.Text;
                        time = lblTime.Text;
                        loginID = txtLoginID.Text;
                        myName = firstname;
                        surname = lastname;

                        userpassword = txtPassword.Text;
                        GeneralID = txtGeneralID.Text;
                       global_storeid = txtstore_id.Text;
                        getlastname = txtlastname.Text;
                        //global_storeid = cbStore.Text;
                        frm_POS.myName = myName;
                        frm_POS.surname = surname;
                        frm_MainHomeStaff.myName = ("Hi, ") + firstname + (" Welcome to Fabula's Merchandise.");
                        frm_AccountStaff.myName = myName + ("'s Password Account");
                        btnLogin.Focus();
                        Cursor.Current = Cursors.WaitCursor;
                       
                        lblinitializing.Show();


                        if (online == "Online" && username == txtUsername.Text) 
                        {
                            //Cursor.Current = Cursors.WaitCursor;
                            //frm_Login.time = DateTime.Now.ToShortTimeString();

                            // Conn = ConString.Connection;
                            // cmd = new MySqlCommand("update tbl_loginhistory set time_out = '" + frm_Login.time + "', status = 'Offline' where login_id = '" + frm_Login.loginID + "'", Conn);



                            //myReader = cmd.ExecuteReader();

                            //while (myReader.Read())
                            //{



                            //}
                            //Conn.Close();
                            MessageBox.Show("Access denied: your account is in another logged in.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Cursor.Current = Cursors.AppStarting;
                            var myForm = new frm_Login();
                            myForm.Show();
                            this.Hide();
                            return;
                        }
                        Cursor.Current = Cursors.WaitCursor;
                        var pleaseWait = new frm_subLoading();
                        pleaseWait.Show();
                        Application.DoEvents();
                        Cursor.Current = Cursors.WaitCursor;
                        var myForm1 = new frm_POS();
                        myForm1.Show();
                        pleaseWait.Hide();

                        this.Hide();
                        Cursor.Current = Cursors.AppStarting;
                    }
                    else if (stockman == "Stockman")

                    {
                        attempt = 4;

                        username = txtUsername.Text;


                        time = lblTime.Text;
                        loginID = txtLoginID.Text;
                        myName = firstname;
                        surname = lastname;
                       
                        userpassword = txtPassword.Text;
                        GeneralID = txtGeneralID.Text;
                        getlastname = txtlastname.Text;

                        frm_POS.myName = myName;
                        frm_POS.surname = surname;
                        frm_MainHomeStaff.myName = ("Hi, ") + firstname + (" Welcome to Fabula's Merchandise.");
                        frm_AccountStaff.myName = myName + ("'s Password Account");
                        btnLogin.Focus();
                        Cursor.Current = Cursors.WaitCursor;
                      

                        for (int i = 0; i <= 100; i++)
                        {
                           
                            Thread.Sleep(5);
                        }
                        lblinitializing.Show();

                        if (online == "Online" && username == txtUsername.Text)
                        {
                            //Cursor.Current = Cursors.WaitCursor;
                            //frm_Login.time = DateTime.Now.ToShortTimeString();

                            // Conn = ConString.Connection;
                            // cmd = new MySqlCommand("update tbl_loginhistory set time_out = '" + frm_Login.time + "', status = 'Offline' where login_id = '" + frm_Login.loginID + "'", Conn);



                            //myReader = cmd.ExecuteReader();

                            //while (myReader.Read())
                            //{



                            //}
                            //Conn.Close();
                            MessageBox.Show("Access denied: your account is in another logged in.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Cursor.Current = Cursors.AppStarting;
                            var myForm = new frm_Login();
                            myForm.Show();
                            this.Hide();
                            return;
                        }
                        Cursor.Current = Cursors.WaitCursor;
                        var pleaseWait = new frm_subLoading();
                        pleaseWait.Show();
                        Application.DoEvents();
                        Cursor.Current = Cursors.WaitCursor;
                        var myForm1 = new frm_Inventory();
                        myForm1.Show();
                        pleaseWait.Hide();

                        this.Hide();
                        Cursor.Current = Cursors.AppStarting;
                    }
                 
                    else if (Admin == "Admin")

                    {
                        //attempt = 4;



                        //username = txtUsername.Text;
                        //time = lblTime.Text;
                        //loginID = txtLoginID.Text;
                        //myName = firstname;
                        //surname = lastname;

                        //userpassword = txtPassword.Text;
                        //GeneralID = txtGeneralID.Text;
                        //getlastname = txtlastname.Text;

                        //frm_POS.myName = myName;
                        //frm_POS.surname = surname;
                        //frm_MainHomeStaff.myName = ("Hi, ") + firstname + (" Welcome to Fabula's Merchandise.");
                        //frm_AccountStaff.myName = myName + ("'s Password Account");
                        //btnLogin.Focus();
                        //Cursor.Current = Cursors.WaitCursor;
                      
                        //lblinitializing.Show();
                        //if (online == "Online" && username == txtUsername.Text)
                        //{
                        //    //Cursor.Current = Cursors.WaitCursor;
                        //    //frm_Login.time = DateTime.Now.ToShortTimeString();

                        //    // Conn = ConString.Connection;
                        //    // cmd = new MySqlCommand("update tbl_loginhistory set time_out = '" + frm_Login.time + "', status = 'Offline' where login_id = '" + frm_Login.loginID + "'", Conn);



                        //    //myReader = cmd.ExecuteReader();

                        //    //while (myReader.Read())
                        //    //{



                        //    //}
                        //    //Conn.Close();
                        //    MessageBox.Show("Access denied: your account is in another logged in.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //    Cursor.Current = Cursors.AppStarting;
                        //    var myForm = new frm_Login();
                        //    myForm.Show();
                        //    this.Hide();
                        //    return;
                        //}
                        //Cursor.Current = Cursors.AppStarting;

                        //Cursor.Current = Cursors.WaitCursor;
                        //var pleaseWait = new frm_subLoading();
                        //pleaseWait.Show();
                        //Application.DoEvents();
                        //Cursor.Current = Cursors.WaitCursor;
                        //var myForm1 = new frm_HomeAdmin();
                        //myForm1.Show();
                        //pleaseWait.Hide();

                        //this.Hide();
                        //Cursor.Current = Cursors.AppStarting;
                    }
                }
            }
            catch (Exception)
            {

            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }

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
                    this.btnLogin.Enabled = true;
                    this.AcceptButton = btnLogin;
                    lblCountDown.Visible = false;
                    return;
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;
      
        private void frm_Login_Load(object sender, EventArgs e)
        {
         
          
            PictureBox pic = new PictureBox();
            pic.Width = 16;
            pic.Height = 16;
          

            pic.BackgroundImage = NurseryVan_System.Properties.Resources.search2;
            txtUsername.Controls.Add(pic);

            Choices commands = new Choices();
            commands.Add(new string[] {"say hello", "print my name"});
            GrammarBuilder gBuilder = new GrammarBuilder();
            gBuilder.Append(commands);
            Grammar grammar = new Grammar(gBuilder);
            recEngine.LoadGrammarAsync(grammar);
            recEngine.SetInputToDefaultAudioDevice();
            recEngine.SpeechRecognized += recEngine_SpeechRecognized;
           
            ComboboxofStore();
        
            lblTime.Text = DateTime.Now.ToShortTimeString();
            txtUsername.Focus();
            txtUsername.Select(0, 0);

            //user = txtUsername.Text;
            //GeneralID = txtGeneralID.Text;
            store = cbStore.Text;
         
            this.AcceptButton = btnLogin;
            DGVAccountUser();
            SearchList();
            generator1();
           
    




            if (attempt == 0)
            {



                lblCountDown.Visible = true;
                btnLogin.Enabled = false;
                timer1 = new System.Windows.Forms.Timer();
                timer1.Tick += new EventHandler(timer1_Tick);
                timer1.Interval = 1000; // 1 second
                timer1.Start();

                counter = 10;
                lblCountDown.Text = ("Try again in ") + counter.ToString() + (" second(s).");


            }
            else if (attempt == -1)
            {
                counter = 30;
                lblCountDown.Visible = true;
                btnLogin.Enabled = false;
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
                btnLogin.Enabled = false;
                timer1 = new System.Windows.Forms.Timer();
                timer1.Tick += new EventHandler(timer1_Tick);
                timer1.Interval = 1000; // 1 second
                timer1.Start();
                lblCountDown.Text = ("Try again in ") + counter.ToString() + (" seconds.");

                counter = 60;

            }
            if (Properties.Settings.Default.UserName != "Username")
            {
                txtUsername.Text = Properties.Settings.Default.UserName;
                txtPassword.Text = Properties.Settings.Default.UserPass;

                txtUsername.ForeColor = Color.Black;
                txtPassword.ForeColor = Color.Black;
                return;
            }
            checkBoxRememberpass.Checked = true;




           
        }

        void recEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            switch (e.Result.Text)
            {
                case "say hello":
                    MessageBox.Show("Hello " + txtUsername.Text);
                    break;
                case "print my name":
                    txtUsername.Text += txtUsername.Text;
                    break;

            }
        }
        public void AccessDeniedOnline()
        {
            MySqlConnection Conn = ConString.Connection;


            AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();

            string Query = "SELECT * FROM tbl_loginhistory  where status = 'Online' and username = '" + txtUsername.Text + "';";
            MySqlCommand cmd = new MySqlCommand(Query, Conn);
            MySqlDataReader myReader;

            try
            {

                myReader = cmd.ExecuteReader();

                while (myReader.Read())
                {

                    online = myReader.GetString("status");



                }

                Conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error13");
            }
        }
        public void SearchList()
        {
            MySqlConnection Conn = ConString.Connection;


            string Query = "Select username,status from tbl_login where status = 'Active'";
            MySqlCommand cmd = new MySqlCommand(Query, Conn);
            MySqlDataReader myReader;

            AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
            try
            {

                myReader = cmd.ExecuteReader();

                while (myReader.Read())
                {
                    MyCollection.Add(myReader.GetString(0));
                    status = myReader.GetString("status");

                }

                txtUsername.AutoCompleteCustomSource = MyCollection;
                Conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error1");
            }
        }
        public void ComboboxofStore()
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
            
                    cbStore.Items.Add(myReader[0]);
                 
                    storename = myReader.GetString("store_name");

                }

                cbStore.AutoCompleteCustomSource = MyCollection;
           
                Conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error1");
            }
        }

        private void txtPassword2_TextChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '•';
        }
        void DGVAccountUser()
        {

            MySqlConnection Conn = ConString.Connection;
            MySqlCommand cmd = new MySqlCommand("SELECT login_id as 'Login ID', firstname as 'First Name', lastname as 'Last Name', username as 'Username', password as 'Password', status as 'Status' FROM tbl_login;", Conn);

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
                Conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
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
                txtGeneralID.Text = row.Cells[0].Value.ToString();
                firstname = row.Cells[1].Value.ToString();
                surname = row.Cells[2].Value.ToString();
                getusername = row.Cells[3].Value.ToString();
                getpassword = row.Cells[4].Value.ToString();
                status = row.Cells[5].Value.ToString();
             

            }
        }

        private void bunifuGradientPanel1_Paint(object sender, PaintEventArgs e)
        {
            if (txtPassword.Text.Length == 0)
            {

                txtUsername.Text = "Username";
                txtUsername.ForeColor = Color.Gray;
                Cursor.Current = Cursors.IBeam;


            }

            if (txtPassword.Text.Length == 0)
            {

                txtPassword.Text = "Password";
                txtPassword.PasswordChar = '\0';
                txtPassword.ForeColor = Color.Gray;
                Cursor.Current = Cursors.IBeam;

            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            if (txtUsername.Text.Contains(@"\"))
            {
                return;



            }
         
            cbStore.Text = txtUsername.Text;
      //      AccessDeniedOnline();

            if(txtUsername.Text == "" || txtUsername.Text == "Username"|| txtUsername.Text == "Enter your username" || txtUsername.Text == "Manager")
            {
                txtstore_id.Text = "";
            }
            try
            {
                MySqlConnection Conn = ConString.Connection;
                DataTable dt = new DataTable();
                MySqlDataAdapter sda = new MySqlDataAdapter("Select login_id as 'Login ID', firstname as 'First Name', lastname as 'Last Name', username as 'Username', password as 'Password', status as 'Status'  from tbl_login where username like '" + txtUsername.Text + "%'", Conn);
                sda.Fill(dt);
                Conn.Close();
                dataGridView1.DataSource = dt;


                string username = txtUsername.Text;




                if (txtUsername.Text == "Username" || txtUsername.Text == "")
                {

                    Conn = ConString.Connection;
                    dt = new DataTable();
                    sda = new MySqlDataAdapter("Select login_id as 'Login ID', firstname as 'First Name', lastname as 'Last Name', username as 'Username', password as 'Password', status as 'Status'  from tbl_login where username like '%" + txtUsername.Text + "%'", Conn);
                    sda.Fill(dt);
                    Conn.Close();
                    dataGridView1.DataSource = dt;
                
                }
                if (txtUsername.Text == "Username")
                {
                    lblNotfound.Hide();
                    return;
                }
             
                try
                {
                    if (!dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].IsNewRow)
                    {
                        foreach (DataGridViewCell cell in dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells)
                        {
                    
                            lblNotfound.Hide();
                            if (cell.Value == System.DBNull.Value)
                            {
                               
                            }
                        }
                    }
                }
                catch (NullReferenceException)
                {
                   
                    lblNotfound.Show();

                }

                //if (txtUsername.Text.Length <= 0) return;
                //string s = txtUsername.Text.Substring(0, 1);
                //if (s != s.ToUpper())
                //{
                //    int curSelStart = txtUsername.SelectionStart;
                //    int curSelLength = txtUsername.SelectionLength;
                //    txtUsername.SelectionStart = 0;
                //    txtUsername.SelectionLength = 1;
                //    txtUsername.SelectedText = s.ToUpper();
                //    txtUsername.SelectionStart = curSelStart;
                //    txtUsername.SelectionLength = curSelLength;

                //}


                //if (txtUsername.Text != getusername)
                //{
                //    pChecked.Hide();



                //}
                //else if (txtUsername.Text == getusername)
                //{
                //    pChecked.Show();

                //}
           
            }
            catch (Exception)
            {

            }
         
        }

        private void linklblForgotpassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var myform = new frm_vforgotPassword_s1();
            myform.Show();
            this.Hide();
            
        }

        private void txtPassword_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Password")
            {
                txtPassword.Focus();
                txtPassword.Select(0, 0);

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void frm_Login_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void frm_Login_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void frm_Login_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void btnloginVB_Click(object sender, EventArgs e)
        {
            // getUsernameandPassword();
            generator1();
            lblinitializing.Show();
            lblTime.Text = DateTime.Now.ToShortTimeString();
            if (txtUsername.Text == "Username" && txtPassword.Text == "Password")
            {
                string myStringVariable1 = string.Empty;
                lblinitializing.Hide();
                MessageBox.Show("Enter username and password!", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.None);
                txtPassword.Text = "";
                txtUsername.Text = "";

                txtUsername.Focus();
                txtUsername.Select(0, 0);
                return;

            }

            if (txtUsername.Text == "" && txtPassword.Text == "")
            {
                string myStringVariable1 = string.Empty;
                lblinitializing.Hide();
                MessageBox.Show("Enter username and password!", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.None);
                txtPassword.Text = "";
                txtUsername.Text = "";

                txtUsername.Focus();
                txtUsername.Select(0, 0);
                return;
            }
            else if (txtPassword.Text == "" || txtPassword.Text == "Password")
            {
                string myStringVariable2 = string.Empty;
                lblinitializing.Hide();
                MessageBox.Show("Enter password!", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.None);
                txtPassword.Focus();

                txtPassword.Select(0, 0);
                return;
            }
            if (txtUsername.Text == "" || txtUsername.Text == "Username")
            {
                string myStringVariable2 = string.Empty;
                lblinitializing.Hide();
                MessageBox.Show("Enter username!", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.None);

                txtUsername.Focus();
                txtUsername.Select(0, 0);

                return;
            }
            string password = txtPassword.Text;


            if (password.Contains(@"\") || password.Contains("'"))

            {
                lblinitializing.Hide();
                MessageBox.Show("Your password is invalid using symbol.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Text = "";
                txtPassword.Focus();

                txtPassword.Select(0, 0);
                return;
            }




            //   myprogressBar1.Visible = true; label3.Visible = true; pictureBox2.Visible = true;


            MySqlConnection Conn = ConString.Connection;
            MySqlCommand cmd = new MySqlCommand(" select * from tbl_login where username = '" + this.txtUsername.Text + "' and password = '" + this.txtPassword.Text + "' and status = 'Active';insert into tbl_loginhistory (Login_Id, username, time_in, date) values ('" + txtLoginID.Text + "', '" + this.txtUsername.Text + "', '" + lblTime.Text + "', '" + dateTimePicker1.Text + "')", Conn);
            //cmd.CommandTimeout = 500000;
            int count = 0;
            try
            {

                MySqlDataReader myReader;
            
                myReader = cmd.ExecuteReader();

                while (myReader.Read())
                {
                    count += 1;
                    manager = myReader["user_type"].ToString();
                    user = myReader["user_type"].ToString();
                    Admin = myReader["user_type"].ToString();
                    stockman = myReader["user_type"].ToString();
                    stockman1 = myReader["user_type"].ToString();
                    loginID = myReader.GetString("login_id");
                    firstname = myReader.GetString("firstname");
                    lastname = myReader.GetString("lastname");


                }
                Conn.Close();
                //case sensitive username
                if (txtPassword.Text != getpassword || txtUsername.Text != getusername || status == "Archive")

                {



                    attempt--;

                    lblinitializing.Hide();

                    MessageBox.Show("You've entered incorrect username or password. Please try again.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsername.ForeColor = Color.Gray;

                    checkBoxRememberpass.Checked = false;

                    txtPassword.Text = "Password";
                    txtUsername.Text = "Username";


                    txtUsername.Focus();
                    txtUsername.Select(0, 0);

                   Conn = ConString.Connection;
                    cmd = new MySqlCommand("delete from tbl_loginhistory where login_id = '" + this.txtLoginID.Text + "'", Conn);
                  //  cmd.CommandTimeout = 500000;
                  
                    myReader = cmd.ExecuteReader();
                    txtPassword.PasswordChar = '\0';
                    txtPassword.ForeColor = Color.Gray;

                    while (myReader.Read())
                    {


                    }
                    Conn.Close();

                    if (attempt == 0)
                    {



                        lblCountDown.Visible = true;
                        btnLogin.Enabled = false;
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
                        btnLogin.Enabled = false;
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
                        btnLogin.Enabled = false;
                        timer1 = new System.Windows.Forms.Timer();
                        timer1.Tick += new EventHandler(timer1_Tick);
                        timer1.Interval = 1000; // 1 second
                        timer1.Start();
                        lblCountDown.Text = ("Try again in ") + counter.ToString() + (" seconds.");

                        counter = 60;

                    }

                    return;
                }
                else if (count == 1)
                {


                    if (manager == "Manager")
                    {
                        attempt = 4;

                        //    managerpassword = txtPassword.Text;
                        time = lblTime.Text;
                        loginID = txtLoginID.Text;
                        GeneralID = txtGeneralID.Text;
                        myName = firstname;
                        frm_MainHomeManager.myName = ("Hi, ") + myName + (" Welcome to Fabula's Merchandise.");
                        frm_AccountManager.myName = myName + ("'s Password Account");
                        btnLogin.Focus();
                       
                        lblinitializing.Show();
                        Cursor.Current = Cursors.WaitCursor;

                        var Managerhome = new frm_MainHomeManager(manager);
                        Managerhome = new frm_MainHomeManager(manager);
                        Managerhome.Show();
                        this.Hide();

                        Cursor.Current = Cursors.AppStarting;

                    }
                    else if (user == "Staff")

                    {
                        attempt = 4;

                      

                        time = lblTime.Text;
                        loginID = txtLoginID.Text;
                        myName = firstname;
                        surname = lastname;

                        userpassword = txtPassword.Text;
                        GeneralID = txtGeneralID.Text;
                        getlastname = txtlastname.Text;

                        frm_POS.myName = myName;
                        frm_POS.surname = surname;
                        frm_MainHomeStaff.myName = ("Hi, ") + firstname + (" Welcome to Fabula's Merchandise.");
                        frm_AccountStaff.myName = myName + ("'s Password Account");
                        btnLogin.Focus();
                        Cursor.Current = Cursors.WaitCursor;
                       
                        lblinitializing.Show();
                        if (online == "Online")
                        {
                            //Cursor.Current = Cursors.WaitCursor;
                            //frm_Login.time = DateTime.Now.ToShortTimeString();

                            // Conn = ConString.Connection;
                            // cmd = new MySqlCommand("update tbl_loginhistory set time_out = '" + frm_Login.time + "', status = 'Offline' where login_id = '" + frm_Login.loginID + "'", Conn);



                            //myReader = cmd.ExecuteReader();

                            //while (myReader.Read())
                            //{



                            //}
                            //Conn.Close();
                            MessageBox.Show("Access denied: your account is in another logged in.", "Fabula's Merchandise System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Cursor.Current = Cursors.AppStarting;
                            var myForm = new frm_Login();
                            myForm.Show();
                            this.Hide();
                            return;
                        }
                        Cursor.Current = Cursors.AppStarting;

                        var Staffhome = new frm_POS();
                        Staffhome = new frm_POS();
                        Staffhome.Show();

                        this.Hide();
                        Cursor.Current = Cursors.AppStarting;
                    }
                 
                 
                    //else if (Admin == "Admin")

                    //{
                    //    attempt = 4;

                      

                    //    time = lblTime.Text;
                    //    loginID = txtLoginID.Text;
                    //    myName = firstname;
                    //    surname = lastname;

                    //    userpassword = txtPassword.Text;
                    //    GeneralID = txtGeneralID.Text;
                    //    getlastname = txtlastname.Text;

                    //    frm_POS.myName = myName;
                    //    frm_POS.surname = surname;
                    //    frm_MainHomeStaff.myName = ("Hi, ") + firstname + (" Welcome to Fabula's Merchandise.");
                    //    frm_AccountStaff.myName = myName + ("'s Password Account");
                    //    btnLogin.Focus();
                    //    Cursor.Current = Cursors.WaitCursor;
                       
                    //    lblinitializing.Show();
                    //    Cursor.Current = Cursors.AppStarting;

                    //    var AdminHome = new frm_HomeAdmin();
                    //    AdminHome = new frm_HomeAdmin();
                    //    AdminHome.Show();

                    //    this.Hide();
                    //    Cursor.Current = Cursors.AppStarting;
                    //}
                }
            }
            catch (Exception)
            {

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            MySqlConnection Conn = ConString.Connection;

            Cursor.Current = Cursors.WaitCursor;

                string Query = "select * from tbl_store where store_name = '" + cbStore.SelectedItem.ToString() + "'; ";
              
                MySqlCommand cmd = new MySqlCommand(Query, Conn);
                MySqlDataReader myReader;
            
                myReader = cmd.ExecuteReader();
                while (myReader.Read())
                {
                    store_ID = myReader.GetInt32("store_id");


                }

                Conn.Close();
            
        }

        private void cbStore_TextChanged(object sender, EventArgs e)
        {
            if (txtUsername.Text.Contains(@"\"))
            {
                return;



            }
            MySqlConnection Conn = ConString.Connection;
            string Query = "select * from tbl_store inner join tbl_login on tbl_store.store_id = tbl_login.store_id where tbl_login.username = '" + cbStore.Text.ToString() + "';";

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
            MySqlDataAdapter sda = new MySqlDataAdapter("select * from tbl_store inner join tbl_login on tbl_store.store_id = tbl_login.store_id where tbl_login.username like '%" + cbStore.Text + "';", Conn);
            sda.Fill(dt);
            sda.SelectCommand = cmd;
            Conn.Close();
            txtstore_id.DataSource = dt;
            txtstore_id.DisplayMember = "store_id";
            txtstore_id.ValueMember = "store_id";

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            recEngine.RecognizeAsync(RecognizeMode.Multiple);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            recEngine.RecognizeAsyncStop();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //dateTimePicker4.Text=  DateTime.Parse(dateTimePicker3.Text).AddDays(dateTimePicker3.Value).ToString();
          //  textBox2.Text = (dateTimePicker4.Value - dateTimePicker3.Value).TotalDays.ToString("#");
        }
        public void ReverseDeniedAccess()
        {
            MySqlConnection Conn = ConString.Connection;


            string Query = "delete from tbl_loginhistory where status = 'Online'";
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
        private void checkHide_Click(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
            checkShow.Visible = true;
            checkHide.Visible = false;
        }

        private void checkShow_Click(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = false;
            checkShow.Visible = false;
            checkHide.Visible = true;
        }

        private void subcb_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void label3_Click(object sender, EventArgs e)
        {
            ReverseDeniedAccess();
        }
    }
}
