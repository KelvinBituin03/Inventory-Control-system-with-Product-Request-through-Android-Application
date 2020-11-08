namespace NurseryVan_System
{
    partial class frm_Void
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Void));
            this.lblCountDown = new System.Windows.Forms.Label();
            this.metroTile1 = new MetroFramework.Controls.MetroTile();
            this.btnOk = new MetroFramework.Controls.MetroTile();
            this.lblVoidItem = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.bunifuGradientPanel3 = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.lblproduct = new System.Windows.Forms.Label();
            this.btnCancel = new MetroFramework.Controls.MetroTile();
            this.txtName2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.Label();
            this.bunifuGradientPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCountDown
            // 
            this.lblCountDown.AutoSize = true;
            this.lblCountDown.BackColor = System.Drawing.Color.Transparent;
            this.lblCountDown.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.lblCountDown.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountDown.ForeColor = System.Drawing.Color.White;
            this.lblCountDown.Location = new System.Drawing.Point(185, 209);
            this.lblCountDown.Name = "lblCountDown";
            this.lblCountDown.Size = new System.Drawing.Size(133, 24);
            this.lblCountDown.TabIndex = 182;
            this.lblCountDown.Text = "Countdown";
            this.lblCountDown.Visible = false;
            // 
            // metroTile1
            // 
            this.metroTile1.ActiveControl = null;
            this.metroTile1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(38)))), ((int)(((byte)(47)))));
            this.metroTile1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.metroTile1.ForeColor = System.Drawing.Color.White;
            this.metroTile1.Location = new System.Drawing.Point(282, 126);
            this.metroTile1.Name = "metroTile1";
            this.metroTile1.Size = new System.Drawing.Size(135, 39);
            this.metroTile1.TabIndex = 181;
            this.metroTile1.Text = "Cancel";
            this.metroTile1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTile1.TileImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.metroTile1.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.metroTile1.UseCustomBackColor = true;
            this.metroTile1.UseSelectable = true;
            this.metroTile1.UseTileImage = true;
            this.metroTile1.Click += new System.EventHandler(this.metroTile1_Click);
            // 
            // btnOk
            // 
            this.btnOk.ActiveControl = null;
            this.btnOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(38)))), ((int)(((byte)(47)))));
            this.btnOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOk.ForeColor = System.Drawing.Color.White;
            this.btnOk.Location = new System.Drawing.Point(141, 126);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(135, 39);
            this.btnOk.TabIndex = 180;
            this.btnOk.Text = "OK";
            this.btnOk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnOk.TileImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOk.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.btnOk.UseCustomBackColor = true;
            this.btnOk.UseSelectable = true;
            this.btnOk.UseTileImage = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lblVoidItem
            // 
            this.lblVoidItem.AutoSize = true;
            this.lblVoidItem.BackColor = System.Drawing.Color.Transparent;
            this.lblVoidItem.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.lblVoidItem.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVoidItem.ForeColor = System.Drawing.Color.White;
            this.lblVoidItem.Location = new System.Drawing.Point(89, 23);
            this.lblVoidItem.Name = "lblVoidItem";
            this.lblVoidItem.Size = new System.Drawing.Size(89, 19);
            this.lblVoidItem.TabIndex = 179;
            this.lblVoidItem.Text = "VOID ITEM:";
            // 
            // txtCode
            // 
            this.txtCode.BackColor = System.Drawing.Color.MistyRose;
            this.txtCode.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCode.Location = new System.Drawing.Point(118, 89);
            this.txtCode.MaxLength = 50;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(342, 21);
            this.txtCode.TabIndex = 177;
            this.txtCode.TextChanged += new System.EventHandler(this.txtCode_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(89, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(341, 19);
            this.label2.TabIndex = 176;
            this.label2.Text = "Please enter Supervisor\'s code to continue...";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // bunifuGradientPanel3
            // 
            this.bunifuGradientPanel3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuGradientPanel3.BackgroundImage")));
            this.bunifuGradientPanel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuGradientPanel3.Controls.Add(this.lblproduct);
            this.bunifuGradientPanel3.Controls.Add(this.btnCancel);
            this.bunifuGradientPanel3.Controls.Add(this.lblCountDown);
            this.bunifuGradientPanel3.Controls.Add(this.txtName2);
            this.bunifuGradientPanel3.Controls.Add(this.metroTile1);
            this.bunifuGradientPanel3.Controls.Add(this.txtName);
            this.bunifuGradientPanel3.Controls.Add(this.btnOk);
            this.bunifuGradientPanel3.Controls.Add(this.label2);
            this.bunifuGradientPanel3.Controls.Add(this.lblVoidItem);
            this.bunifuGradientPanel3.Controls.Add(this.txtCode);
            this.bunifuGradientPanel3.ForeColor = System.Drawing.Color.Blue;
            this.bunifuGradientPanel3.GradientBottomLeft = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(38)))), ((int)(((byte)(47)))));
            this.bunifuGradientPanel3.GradientBottomRight = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(38)))), ((int)(((byte)(47)))));
            this.bunifuGradientPanel3.GradientTopLeft = System.Drawing.Color.White;
            this.bunifuGradientPanel3.GradientTopRight = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(38)))), ((int)(((byte)(47)))));
            this.bunifuGradientPanel3.Location = new System.Drawing.Point(1, 0);
            this.bunifuGradientPanel3.Name = "bunifuGradientPanel3";
            this.bunifuGradientPanel3.Quality = 10;
            this.bunifuGradientPanel3.Size = new System.Drawing.Size(573, 273);
            this.bunifuGradientPanel3.TabIndex = 223;
            // 
            // lblproduct
            // 
            this.lblproduct.AutoSize = true;
            this.lblproduct.BackColor = System.Drawing.Color.Transparent;
            this.lblproduct.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.lblproduct.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblproduct.ForeColor = System.Drawing.Color.White;
            this.lblproduct.Location = new System.Drawing.Point(362, 241);
            this.lblproduct.Name = "lblproduct";
            this.lblproduct.Size = new System.Drawing.Size(112, 18);
            this.lblproduct.TabIndex = 218;
            this.lblproduct.Text = "VOID ITEM:";
            this.lblproduct.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.ActiveControl = null;
            this.btnCancel.BackColor = System.Drawing.Color.Blue;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(693, 136);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(129, 43);
            this.btnCancel.TabIndex = 217;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCancel.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCancel.UseCustomBackColor = true;
            this.btnCancel.UseSelectable = true;
            // 
            // txtName2
            // 
            this.txtName2.AutoSize = true;
            this.txtName2.BackColor = System.Drawing.Color.Transparent;
            this.txtName2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName2.ForeColor = System.Drawing.Color.White;
            this.txtName2.Location = new System.Drawing.Point(279, 11);
            this.txtName2.Name = "txtName2";
            this.txtName2.Size = new System.Drawing.Size(0, 19);
            this.txtName2.TabIndex = 214;
            this.txtName2.Visible = false;
            // 
            // txtName
            // 
            this.txtName.AutoSize = true;
            this.txtName.BackColor = System.Drawing.Color.Transparent;
            this.txtName.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.ForeColor = System.Drawing.Color.White;
            this.txtName.Location = new System.Drawing.Point(279, 11);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(0, 19);
            this.txtName.TabIndex = 213;
            // 
            // frm_Void
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 268);
            this.Controls.Add(this.bunifuGradientPanel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frm_Void";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frm_Void_Load);
            this.bunifuGradientPanel3.ResumeLayout(false);
            this.bunifuGradientPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblCountDown;
        private MetroFramework.Controls.MetroTile metroTile1;
        private MetroFramework.Controls.MetroTile btnOk;
        private System.Windows.Forms.Label lblVoidItem;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
        private Bunifu.Framework.UI.BunifuGradientPanel bunifuGradientPanel3;
        private MetroFramework.Controls.MetroTile btnCancel;
        private System.Windows.Forms.Label txtName2;
        private System.Windows.Forms.Label txtName;
        private System.Windows.Forms.Label lblproduct;
    }
}