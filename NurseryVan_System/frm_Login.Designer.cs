namespace NurseryVan_System
{
    partial class frm_Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Login));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblTime = new System.Windows.Forms.Label();
            this.txtLoginID = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.txtGeneralID = new System.Windows.Forms.TextBox();
            this.txtlastname = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnExit = new MetroFramework.Controls.MetroButton();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.btnLogin = new MetroFramework.Controls.MetroButton();
            this.checkBoxRememberpass = new System.Windows.Forms.CheckBox();
            this.linklblForgotpassword = new System.Windows.Forms.LinkLabel();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.cbStore = new System.Windows.Forms.ComboBox();
            this.lblwelcome = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtstore_id = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.checkBoxShowPassword = new System.Windows.Forms.CheckBox();
            this.bunifuGradientPanel1 = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.checkShow = new System.Windows.Forms.PictureBox();
            this.checkHide = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCountDown = new System.Windows.Forms.Label();
            this.lblinitializing = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.lblNotfound = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.bunifuGradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkShow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkHide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(1211, 59);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(270, 177);
            this.dataGridView1.TabIndex = 173;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(1236, 278);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(35, 13);
            this.lblTime.TabIndex = 174;
            this.lblTime.Text = "label1";
            // 
            // txtLoginID
            // 
            this.txtLoginID.Location = new System.Drawing.Point(1239, 304);
            this.txtLoginID.Name = "txtLoginID";
            this.txtLoginID.Size = new System.Drawing.Size(100, 20);
            this.txtLoginID.TabIndex = 175;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(1239, 340);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 176;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // txtGeneralID
            // 
            this.txtGeneralID.BackColor = System.Drawing.Color.DarkSalmon;
            this.txtGeneralID.Location = new System.Drawing.Point(1239, 368);
            this.txtGeneralID.Name = "txtGeneralID";
            this.txtGeneralID.Size = new System.Drawing.Size(100, 20);
            this.txtGeneralID.TabIndex = 177;
            // 
            // txtlastname
            // 
            this.txtlastname.Location = new System.Drawing.Point(1239, 403);
            this.txtlastname.Name = "txtlastname";
            this.txtlastname.Size = new System.Drawing.Size(100, 20);
            this.txtlastname.TabIndex = 178;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btnExit.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(352, 0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(31, 33);
            this.btnExit.TabIndex = 180;
            this.btnExit.Text = "X";
            this.toolTip1.SetToolTip(this.btnExit, "Exit");
            this.btnExit.UseCustomBackColor = true;
            this.btnExit.UseCustomForeColor = true;
            this.btnExit.UseSelectable = true;
            this.btnExit.UseStyleColors = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // txtUsername
            // 
            this.txtUsername.AllowDrop = true;
            this.txtUsername.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtUsername.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtUsername.BackColor = System.Drawing.Color.White;
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUsername.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUsername.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(93)))), ((int)(((byte)(115)))));
            this.txtUsername.Location = new System.Drawing.Point(22, 220);
            this.txtUsername.MaxLength = 25;
            this.txtUsername.Multiline = true;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(306, 29);
            this.txtUsername.TabIndex = 1;
            this.txtUsername.Text = "Username";
            this.txtUsername.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.txtUsername, "Username");
            this.txtUsername.Click += new System.EventHandler(this.txtusername2_Click);
            this.txtUsername.TextChanged += new System.EventHandler(this.txtUsername_TextChanged);
            this.txtUsername.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtusername2_KeyPress);
            this.txtUsername.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtusername2_KeyUp);
            this.txtUsername.Leave += new System.EventHandler(this.txtusername2_Leave);
            // 
            // btnLogin
            // 
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(71, 379);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(219, 46);
            this.btnLogin.TabIndex = 175;
            this.btnLogin.Text = "LOGIN";
            this.toolTip1.SetToolTip(this.btnLogin, "Login");
            this.btnLogin.UseCustomBackColor = true;
            this.btnLogin.UseCustomForeColor = true;
            this.btnLogin.UseSelectable = true;
            this.btnLogin.UseStyleColors = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // checkBoxRememberpass
            // 
            this.checkBoxRememberpass.AutoSize = true;
            this.checkBoxRememberpass.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxRememberpass.CausesValidation = false;
            this.checkBoxRememberpass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxRememberpass.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxRememberpass.ForeColor = System.Drawing.Color.White;
            this.checkBoxRememberpass.Location = new System.Drawing.Point(45, 331);
            this.checkBoxRememberpass.Name = "checkBoxRememberpass";
            this.checkBoxRememberpass.Size = new System.Drawing.Size(130, 23);
            this.checkBoxRememberpass.TabIndex = 176;
            this.checkBoxRememberpass.Text = "Remember Me";
            this.toolTip1.SetToolTip(this.checkBoxRememberpass, "Remember Me");
            this.checkBoxRememberpass.UseVisualStyleBackColor = false;
            this.checkBoxRememberpass.CheckedChanged += new System.EventHandler(this.checkBoxRememberpass_CheckedChanged);
            // 
            // linklblForgotpassword
            // 
            this.linklblForgotpassword.AutoSize = true;
            this.linklblForgotpassword.BackColor = System.Drawing.Color.Transparent;
            this.linklblForgotpassword.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linklblForgotpassword.LinkColor = System.Drawing.Color.White;
            this.linklblForgotpassword.Location = new System.Drawing.Point(202, 331);
            this.linklblForgotpassword.Name = "linklblForgotpassword";
            this.linklblForgotpassword.Size = new System.Drawing.Size(129, 19);
            this.linklblForgotpassword.TabIndex = 150;
            this.linklblForgotpassword.TabStop = true;
            this.linklblForgotpassword.Text = "Forgot password?";
            this.toolTip1.SetToolTip(this.linklblForgotpassword, "I forgot my password");
            this.linklblForgotpassword.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklblForgotpassword_LinkClicked);
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.White;
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPassword.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(93)))), ((int)(((byte)(115)))));
            this.txtPassword.Location = new System.Drawing.Point(22, 292);
            this.txtPassword.MaxLength = 50;
            this.txtPassword.Multiline = true;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '•';
            this.txtPassword.Size = new System.Drawing.Size(306, 29);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.Text = "Password";
            this.txtPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.txtPassword, "Password");
            this.txtPassword.Click += new System.EventHandler(this.txtPassword_Click);
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword2_TextChanged);
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword2_KeyDown);
            this.txtPassword.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPassword2_KeyUp);
            this.txtPassword.Leave += new System.EventHandler(this.txtPassword2_Leave);
            // 
            // cbStore
            // 
            this.cbStore.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbStore.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cbStore.FormattingEnabled = true;
            this.cbStore.Location = new System.Drawing.Point(1073, 116);
            this.cbStore.Name = "cbStore";
            this.cbStore.Size = new System.Drawing.Size(96, 21);
            this.cbStore.TabIndex = 185;
            this.cbStore.Text = "dgffdgfdgf";
            this.cbStore.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.cbStore.TextChanged += new System.EventHandler(this.cbStore_TextChanged);
            // 
            // lblwelcome
            // 
            this.lblwelcome.AutoSize = true;
            this.lblwelcome.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblwelcome.ForeColor = System.Drawing.Color.White;
            this.lblwelcome.Location = new System.Drawing.Point(76, 187);
            this.lblwelcome.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblwelcome.Name = "lblwelcome";
            this.lblwelcome.Size = new System.Drawing.Size(167, 39);
            this.lblwelcome.TabIndex = 186;
            this.lblwelcome.Text = "Welcome";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(39)))), ((int)(((byte)(48)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(83, 238);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.MaxLength = 9999999;
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(494, 311);
            this.textBox1.TabIndex = 187;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // txtstore_id
            // 
            this.txtstore_id.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtstore_id.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtstore_id.BackColor = System.Drawing.Color.SeaShell;
            this.txtstore_id.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtstore_id.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtstore_id.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtstore_id.FormattingEnabled = true;
            this.txtstore_id.Location = new System.Drawing.Point(1004, 116);
            this.txtstore_id.MaxLength = 100;
            this.txtstore_id.Name = "txtstore_id";
            this.txtstore_id.Size = new System.Drawing.Size(58, 26);
            this.txtstore_id.TabIndex = 303;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::NurseryVan_System.Properties.Resources.fm1;
            this.pictureBox1.Location = new System.Drawing.Point(83, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(438, 161);
            this.pictureBox1.TabIndex = 304;
            this.pictureBox1.TabStop = false;
            // 
            // checkBoxShowPassword
            // 
            this.checkBoxShowPassword.AutoSize = true;
            this.checkBoxShowPassword.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxShowPassword.CausesValidation = false;
            this.checkBoxShowPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxShowPassword.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxShowPassword.ForeColor = System.Drawing.Color.White;
            this.checkBoxShowPassword.Image = ((System.Drawing.Image)(resources.GetObject("checkBoxShowPassword.Image")));
            this.checkBoxShowPassword.Location = new System.Drawing.Point(507, 377);
            this.checkBoxShowPassword.Name = "checkBoxShowPassword";
            this.checkBoxShowPassword.Size = new System.Drawing.Size(45, 30);
            this.checkBoxShowPassword.TabIndex = 3;
            this.checkBoxShowPassword.UseVisualStyleBackColor = false;
            this.checkBoxShowPassword.Visible = false;
            this.checkBoxShowPassword.CheckedChanged += new System.EventHandler(this.checkBoxShowPassword_CheckedChanged);
            // 
            // bunifuGradientPanel1
            // 
            this.bunifuGradientPanel1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuGradientPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuGradientPanel1.BackgroundImage")));
            this.bunifuGradientPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuGradientPanel1.Controls.Add(this.checkShow);
            this.bunifuGradientPanel1.Controls.Add(this.checkHide);
            this.bunifuGradientPanel1.Controls.Add(this.pictureBox2);
            this.bunifuGradientPanel1.Controls.Add(this.pictureBox3);
            this.bunifuGradientPanel1.Controls.Add(this.dateTimePicker2);
            this.bunifuGradientPanel1.Controls.Add(this.label3);
            this.bunifuGradientPanel1.Controls.Add(this.label2);
            this.bunifuGradientPanel1.Controls.Add(this.label1);
            this.bunifuGradientPanel1.Controls.Add(this.btnExit);
            this.bunifuGradientPanel1.Controls.Add(this.txtUsername);
            this.bunifuGradientPanel1.Controls.Add(this.lblCountDown);
            this.bunifuGradientPanel1.Controls.Add(this.btnLogin);
            this.bunifuGradientPanel1.Controls.Add(this.checkBoxRememberpass);
            this.bunifuGradientPanel1.Controls.Add(this.lblinitializing);
            this.bunifuGradientPanel1.Controls.Add(this.lblNotfound);
            this.bunifuGradientPanel1.Controls.Add(this.linklblForgotpassword);
            this.bunifuGradientPanel1.Controls.Add(this.txtPassword);
            this.bunifuGradientPanel1.GradientBottomLeft = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(76)))), ((int)(((byte)(94)))));
            this.bunifuGradientPanel1.GradientBottomRight = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(76)))), ((int)(((byte)(94)))));
            this.bunifuGradientPanel1.GradientTopLeft = System.Drawing.Color.Black;
            this.bunifuGradientPanel1.GradientTopRight = System.Drawing.Color.DeepSkyBlue;
            this.bunifuGradientPanel1.Location = new System.Drawing.Point(595, -2);
            this.bunifuGradientPanel1.Name = "bunifuGradientPanel1";
            this.bunifuGradientPanel1.Quality = 10;
            this.bunifuGradientPanel1.Size = new System.Drawing.Size(390, 605);
            this.bunifuGradientPanel1.TabIndex = 172;
            this.bunifuGradientPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.bunifuGradientPanel1_Paint);
            // 
            // checkShow
            // 
            this.checkShow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkShow.Image = global::NurseryVan_System.Properties.Resources.view;
            this.checkShow.Location = new System.Drawing.Point(333, 292);
            this.checkShow.Name = "checkShow";
            this.checkShow.Size = new System.Drawing.Size(35, 29);
            this.checkShow.TabIndex = 305;
            this.checkShow.TabStop = false;
            this.checkShow.Visible = false;
            this.checkShow.Click += new System.EventHandler(this.checkShow_Click);
            // 
            // checkHide
            // 
            this.checkHide.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkHide.Image = global::NurseryVan_System.Properties.Resources.hide__2_;
            this.checkHide.Location = new System.Drawing.Point(333, 292);
            this.checkHide.Name = "checkHide";
            this.checkHide.Size = new System.Drawing.Size(35, 29);
            this.checkHide.TabIndex = 304;
            this.checkHide.TabStop = false;
            this.checkHide.Click += new System.EventHandler(this.checkHide_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::NurseryVan_System.Properties.Resources._lock;
            this.pictureBox2.Location = new System.Drawing.Point(0, 292);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(44, 29);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 186;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::NurseryVan_System.Properties.Resources.avatar;
            this.pictureBox3.Location = new System.Drawing.Point(0, 220);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(44, 29);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox3.TabIndex = 187;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(2, 0);
            this.dateTimePicker2.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(151, 20);
            this.dateTimePicker2.TabIndex = 184;
            this.dateTimePicker2.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 25.2F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(30, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(303, 40);
            this.label3.TabIndex = 183;
            this.label3.Text = "LOGIN ACCOUNT";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(3, 517);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 24);
            this.label2.TabIndex = 182;
            this.label2.Text = "Password";
            this.label2.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 448);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 24);
            this.label1.TabIndex = 181;
            this.label1.Text = "Username";
            this.label1.Visible = false;
            // 
            // lblCountDown
            // 
            this.lblCountDown.AutoSize = true;
            this.lblCountDown.BackColor = System.Drawing.Color.Transparent;
            this.lblCountDown.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.lblCountDown.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountDown.ForeColor = System.Drawing.Color.White;
            this.lblCountDown.Location = new System.Drawing.Point(67, 540);
            this.lblCountDown.Name = "lblCountDown";
            this.lblCountDown.Size = new System.Drawing.Size(133, 24);
            this.lblCountDown.TabIndex = 177;
            this.lblCountDown.Text = "Countdown";
            this.lblCountDown.Visible = false;
            // 
            // lblinitializing
            // 
            this.lblinitializing.AutoSize = true;
            this.lblinitializing.BackColor = System.Drawing.Color.Transparent;
            this.lblinitializing.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblinitializing.ForeColor = System.Drawing.Color.White;
            this.lblinitializing.Location = new System.Drawing.Point(121, 449);
            this.lblinitializing.Name = "lblinitializing";
            this.lblinitializing.Size = new System.Drawing.Size(118, 23);
            this.lblinitializing.TabIndex = 173;
            this.lblinitializing.Text = "Initializing...";
            this.lblinitializing.Visible = false;
            // 
            // lblNotfound
            // 
            this.lblNotfound.AutoSize = true;
            this.lblNotfound.BackColor = System.Drawing.Color.Transparent;
            this.lblNotfound.CausesValidation = false;
            this.lblNotfound.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.lblNotfound.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotfound.ForeColor = System.Drawing.Color.Tomato;
            this.lblNotfound.Location = new System.Drawing.Point(121, 189);
            this.lblNotfound.Name = "lblNotfound";
            this.lblNotfound.Size = new System.Drawing.Size(133, 23);
            this.lblNotfound.TabIndex = 148;
            this.lblNotfound.Text = "User not found.";
            this.lblNotfound.Visible = false;
            // 
            // frm_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(38)))), ((int)(((byte)(47)))));
            this.ClientSize = new System.Drawing.Size(982, 596);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtstore_id);
            this.Controls.Add(this.cbStore);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblwelcome);
            this.Controls.Add(this.txtlastname);
            this.Controls.Add(this.txtGeneralID);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.txtLoginID);
            this.Controls.Add(this.checkBoxShowPassword);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.bunifuGradientPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frm_Login_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frm_Login_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frm_Login_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.frm_Login_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.bunifuGradientPanel1.ResumeLayout(false);
            this.bunifuGradientPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkShow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkHide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblCountDown;
        private System.Windows.Forms.CheckBox checkBoxRememberpass;
        private MetroFramework.Controls.MetroButton btnLogin;
        private Bunifu.Framework.UI.BunifuCustomLabel lblinitializing;
        private System.Windows.Forms.Label lblNotfound;
        private System.Windows.Forms.CheckBox checkBoxShowPassword;
        private System.Windows.Forms.LinkLabel linklblForgotpassword;
        private System.Windows.Forms.TextBox txtPassword;
        private MetroFramework.Controls.MetroButton btnExit;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.TextBox txtLoginID;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox txtGeneralID;
        private System.Windows.Forms.TextBox txtlastname;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private Bunifu.Framework.UI.BunifuGradientPanel bunifuGradientPanel1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblwelcome;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox cbStore;
        private System.Windows.Forms.ComboBox txtstore_id;
        private System.Windows.Forms.PictureBox checkHide;
        private System.Windows.Forms.PictureBox checkShow;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}