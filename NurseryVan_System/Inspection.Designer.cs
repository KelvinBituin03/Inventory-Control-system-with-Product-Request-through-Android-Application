namespace NurseryVan_System
{
    partial class Inspection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inspection));
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtOrderID = new System.Windows.Forms.TextBox();
            this.btnOK = new MetroFramework.Controls.MetroTile();
            this.btnBack = new MetroFramework.Controls.MetroTile();
            this.label6 = new System.Windows.Forms.Label();
            this.dateExpected = new System.Windows.Forms.DateTimePicker();
            this.lblInput = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.txtDays = new System.Windows.Forms.TextBox();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(329, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 19);
            this.label5.TabIndex = 17;
            this.label5.Text = "orderid";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(211, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 21);
            this.label4.TabIndex = 16;
            this.label4.Text = "Ordered QTY:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1110, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 19);
            this.label3.TabIndex = 15;
            this.label3.Text = "orderid";
            this.label3.Visible = false;
            // 
            // txtDP
            // 
            this.txtDP.BackColor = System.Drawing.Color.PeachPuff;
            this.txtDP.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDP.Location = new System.Drawing.Point(517, 79);
            this.txtDP.Name = "txtDP";
            this.txtDP.ReadOnly = true;
            this.txtDP.Size = new System.Drawing.Size(147, 27);
            this.txtDP.TabIndex = 12;
            this.txtDP.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(381, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 21);
            this.label2.TabIndex = 11;
            this.label2.Text = "Backorder QTY:";
            // 
            // txtRP
            // 
            this.txtRP.BackColor = System.Drawing.Color.White;
            this.txtRP.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRP.ForeColor = System.Drawing.Color.Gray;
            this.txtRP.Location = new System.Drawing.Point(215, 79);
            this.txtRP.MaxLength = 6;
            this.txtRP.Name = "txtRP";
            this.txtRP.Size = new System.Drawing.Size(147, 27);
            this.txtRP.TabIndex = 10;
            this.txtRP.Text = "0";
            this.txtRP.Click += new System.EventHandler(this.textBox1_Click);
            this.txtRP.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.txtRP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch1_KeyPress);
            this.txtRP.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSearch1_KeyUp);
            this.txtRP.Leave += new System.EventHandler(this.txtSearch1_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(38)))), ((int)(((byte)(47)))));
            this.label1.Location = new System.Drawing.Point(84, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 21);
            this.label1.TabIndex = 9;
            this.label1.Text = "QTY Received:";
            // 
            // txtOrderID
            // 
            this.txtOrderID.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOrderID.Location = new System.Drawing.Point(1065, 64);
            this.txtOrderID.Name = "txtOrderID";
            this.txtOrderID.Size = new System.Drawing.Size(100, 27);
            this.txtOrderID.TabIndex = 18;
            this.txtOrderID.Visible = false;
            // 
            // btnOK
            // 
            this.btnOK.ActiveControl = null;
            this.btnOK.BackColor = System.Drawing.Color.DarkGray;
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOK.Enabled = false;
            this.btnOK.ForeColor = System.Drawing.Color.White;
            this.btnOK.Location = new System.Drawing.Point(215, 132);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(129, 47);
            this.btnOK.TabIndex = 192;
            this.btnOK.TabStop = false;
            this.btnOK.Text = "OK";
            this.btnOK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnOK.TileImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOK.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.btnOK.UseCustomBackColor = true;
            this.btnOK.UseSelectable = true;
            this.btnOK.UseTileImage = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnBack
            // 
            this.btnBack.ActiveControl = null;
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(48)))), ((int)(((byte)(47)))));
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(350, 132);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(129, 47);
            this.btnBack.TabIndex = 193;
            this.btnBack.TabStop = false;
            this.btnBack.Text = "Cancel";
            this.btnBack.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnBack.TileImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBack.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.btnBack.UseCustomBackColor = true;
            this.btnBack.UseSelectable = true;
            this.btnBack.UseTileImage = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(212, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(333, 19);
            this.label6.TabIndex = 194;
            this.label6.Text = "Tip: Input amount of received from order.";
            // 
            // dateExpected
            // 
            this.dateExpected.CustomFormat = "yyyy-MM-dd";
            this.dateExpected.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateExpected.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateExpected.Location = new System.Drawing.Point(283, 135);
            this.dateExpected.Name = "dateExpected";
            this.dateExpected.Size = new System.Drawing.Size(143, 27);
            this.dateExpected.TabIndex = 258;
            this.dateExpected.Visible = false;
            this.dateExpected.ValueChanged += new System.EventHandler(this.dateExpected_ValueChanged);
            // 
            // lblInput
            // 
            this.lblInput.AutoSize = true;
            this.lblInput.Font = new System.Drawing.Font("Century Gothic", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInput.ForeColor = System.Drawing.Color.Red;
            this.lblInput.Location = new System.Drawing.Point(211, 111);
            this.lblInput.Name = "lblInput";
            this.lblInput.Size = new System.Drawing.Size(277, 21);
            this.lblInput.TabIndex = 259;
            this.lblInput.Text = "Input date for backorder damage:";
            this.lblInput.Visible = false;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            this.dateTimePicker1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(50, 156);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(0, 27);
            this.dateTimePicker1.TabIndex = 260;
            // 
            // txtDays
            // 
            this.txtDays.BackColor = System.Drawing.Color.White;
            this.txtDays.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDays.ForeColor = System.Drawing.Color.Gray;
            this.txtDays.Location = new System.Drawing.Point(565, 156);
            this.txtDays.MaxLength = 4;
            this.txtDays.Name = "txtDays";
            this.txtDays.Size = new System.Drawing.Size(147, 27);
            this.txtDays.TabIndex = 261;
            this.txtDays.Visible = false;
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmount.ForeColor = System.Drawing.Color.Blue;
            this.lblTotalAmount.Location = new System.Drawing.Point(513, 46);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(65, 19);
            this.lblTotalAmount.TabIndex = 262;
            this.lblTotalAmount.Text = "orderid";
            this.lblTotalAmount.Visible = false;
            // 
            // Inspection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(733, 235);
            this.Controls.Add(this.lblTotalAmount);
            this.Controls.Add(this.txtDays);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.lblInput);
            this.Controls.Add(this.dateExpected);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtOrderID);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtRP);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Inspection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inspection in Warehouse";
            this.Load += new System.EventHandler(this.Inspection_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOrderID;
        private MetroFramework.Controls.MetroTile btnOK;
        private MetroFramework.Controls.MetroTile btnBack;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dateExpected;
        private System.Windows.Forms.Label lblInput;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox txtDays;
        private System.Windows.Forms.Label lblTotalAmount;
    }
}