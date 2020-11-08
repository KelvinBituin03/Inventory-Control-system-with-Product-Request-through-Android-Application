namespace NurseryVan_System
{
    partial class frm_Inspection_of_Product_In_Branch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Inspection_of_Product_In_Branch));
            this.txtDays = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.lblInput = new System.Windows.Forms.Label();
            this.dateExpected = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.btnBack = new MetroFramework.Controls.MetroTile();
            this.btnOK = new MetroFramework.Controls.MetroTile();
            this.txtOrderID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtDays
            // 
            this.txtDays.BackColor = System.Drawing.Color.White;
            this.txtDays.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDays.ForeColor = System.Drawing.Color.Gray;
            this.txtDays.Location = new System.Drawing.Point(399, 176);
            this.txtDays.MaxLength = 4;
            this.txtDays.Name = "txtDays";
            this.txtDays.Size = new System.Drawing.Size(147, 27);
            this.txtDays.TabIndex = 276;
            this.txtDays.Visible = false;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            this.dateTimePicker1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(50, 156);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(0, 27);
            this.dateTimePicker1.TabIndex = 275;
            // 
            // lblInput
            // 
            this.lblInput.AutoSize = true;
            this.lblInput.Font = new System.Drawing.Font("Century Gothic", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInput.ForeColor = System.Drawing.Color.Red;
            this.lblInput.Location = new System.Drawing.Point(12, 205);
            this.lblInput.Name = "lblInput";
            this.lblInput.Size = new System.Drawing.Size(0, 21);
            this.lblInput.TabIndex = 274;
            this.lblInput.Visible = false;
            // 
            // dateExpected
            // 
            this.dateExpected.CustomFormat = "yyyy-MM-dd";
            this.dateExpected.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateExpected.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateExpected.Location = new System.Drawing.Point(36, 170);
            this.dateExpected.Name = "dateExpected";
            this.dateExpected.Size = new System.Drawing.Size(0, 27);
            this.dateExpected.TabIndex = 273;
            this.dateExpected.Visible = false;
            this.dateExpected.ValueChanged += new System.EventHandler(this.dateExpected_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(12, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(333, 19);
            this.label6.TabIndex = 272;
            this.label6.Text = "Tip: Input amount of received from order.";
            // 
            // btnBack
            // 
            this.btnBack.ActiveControl = null;
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(48)))), ((int)(((byte)(47)))));
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(183, 156);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(135, 39);
            this.btnBack.TabIndex = 271;
            this.btnBack.TabStop = false;
            this.btnBack.Text = "Cancel";
            this.btnBack.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnBack.TileImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBack.UseCustomBackColor = true;
            this.btnBack.UseSelectable = true;
            this.btnBack.UseTileImage = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnOK
            // 
            this.btnOK.ActiveControl = null;
            this.btnOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(38)))), ((int)(((byte)(47)))));
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOK.Enabled = false;
            this.btnOK.ForeColor = System.Drawing.Color.White;
            this.btnOK.Location = new System.Drawing.Point(42, 156);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(135, 39);
            this.btnOK.TabIndex = 270;
            this.btnOK.TabStop = false;
            this.btnOK.Text = "OK";
            this.btnOK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnOK.TileImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOK.UseCustomBackColor = true;
            this.btnOK.UseSelectable = true;
            this.btnOK.UseTileImage = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtOrderID
            // 
            this.txtOrderID.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOrderID.Location = new System.Drawing.Point(1065, 64);
            this.txtOrderID.Name = "txtOrderID";
            this.txtOrderID.Size = new System.Drawing.Size(100, 27);
            this.txtOrderID.TabIndex = 269;
            this.txtOrderID.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(172, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 19);
            this.label5.TabIndex = 268;
            this.label5.Text = "orderid";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(19, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 21);
            this.label4.TabIndex = 267;
            this.label4.Text = "Delivered QTY:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1110, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 19);
            this.label3.TabIndex = 266;
            this.label3.Text = "orderid";
            this.label3.Visible = false;
            // 
            // txtDP
            // 
            this.txtDP.BackColor = System.Drawing.Color.White;
            this.txtDP.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDP.Location = new System.Drawing.Point(176, 111);
            this.txtDP.Name = "txtDP";
            this.txtDP.ReadOnly = true;
            this.txtDP.Size = new System.Drawing.Size(147, 27);
            this.txtDP.TabIndex = 265;
            this.txtDP.TextChanged += new System.EventHandler(this.txtDP_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(17, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 21);
            this.label2.TabIndex = 264;
            this.label2.Text = "Backorder QTY:";
            // 
            // txtRP
            // 
            this.txtRP.BackColor = System.Drawing.Color.White;
            this.txtRP.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRP.ForeColor = System.Drawing.Color.Gray;
            this.txtRP.Location = new System.Drawing.Point(175, 78);
            this.txtRP.MaxLength = 6;
            this.txtRP.Name = "txtRP";
            this.txtRP.Size = new System.Drawing.Size(147, 27);
            this.txtRP.TabIndex = 263;
            this.txtRP.Text = "0";
            this.txtRP.Click += new System.EventHandler(this.textBox1_Click);
            this.txtRP.TextChanged += new System.EventHandler(this.txtRP_TextChanged);
            this.txtRP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch1_KeyPress);
            this.txtRP.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSearch1_KeyUp);
            this.txtRP.Leave += new System.EventHandler(this.txtSearch1_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(38)))), ((int)(((byte)(47)))));
            this.label1.Location = new System.Drawing.Point(19, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 21);
            this.label1.TabIndex = 262;
            this.label1.Text = "QTY Received:";
            // 
            // frm_Inspection_of_Product_In_Branch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(371, 232);
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
            this.Name = "frm_Inspection_of_Product_In_Branch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inspection in Outlet";
            this.Load += new System.EventHandler(this.frm_Inspection_of_Product_In_Branch_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDays;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label lblInput;
        private System.Windows.Forms.DateTimePicker dateExpected;
        private System.Windows.Forms.Label label6;
        private MetroFramework.Controls.MetroTile btnBack;
        private MetroFramework.Controls.MetroTile btnOK;
        private System.Windows.Forms.TextBox txtOrderID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRP;
        private System.Windows.Forms.Label label1;
    }
}