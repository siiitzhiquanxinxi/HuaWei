namespace SmartShelfUI
{
    partial class Main
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
            this.lblSoftwareTitle = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.panel_content = new System.Windows.Forms.Panel();
            this.pxb_loginface = new System.Windows.Forms.PictureBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pxb_loginface)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBack)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSoftwareTitle
            // 
            this.lblSoftwareTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblSoftwareTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSoftwareTitle.Font = new System.Drawing.Font("微软雅黑", 42F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSoftwareTitle.ForeColor = System.Drawing.Color.White;
            this.lblSoftwareTitle.Location = new System.Drawing.Point(0, 0);
            this.lblSoftwareTitle.Name = "lblSoftwareTitle";
            this.lblSoftwareTitle.Size = new System.Drawing.Size(1920, 117);
            this.lblSoftwareTitle.TabIndex = 0;
            this.lblSoftwareTitle.Text = "航瑞成智能柜刀具领用系统";
            this.lblSoftwareTitle.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.BackColor = System.Drawing.Color.Transparent;
            this.lblVersion.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.ForeColor = System.Drawing.Color.White;
            this.lblVersion.Location = new System.Drawing.Point(9, 1034);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(95, 19);
            this.lblVersion.TabIndex = 40;
            this.lblVersion.Text = "Version:1.0.0";
            // 
            // panel_content
            // 
            this.panel_content.BackColor = System.Drawing.Color.Transparent;
            this.panel_content.Location = new System.Drawing.Point(0, 157);
            this.panel_content.Name = "panel_content";
            this.panel_content.Size = new System.Drawing.Size(1920, 780);
            this.panel_content.TabIndex = 41;
            // 
            // pxb_loginface
            // 
            this.pxb_loginface.BackColor = System.Drawing.Color.Transparent;
            this.pxb_loginface.BackgroundImage = global::SmartShelfUI.Properties.Resources.login_face;
            this.pxb_loginface.Location = new System.Drawing.Point(1705, 39);
            this.pxb_loginface.Name = "pxb_loginface";
            this.pxb_loginface.Size = new System.Drawing.Size(71, 78);
            this.pxb_loginface.TabIndex = 42;
            this.pxb_loginface.TabStop = false;
            this.pxb_loginface.Visible = false;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.BackColor = System.Drawing.Color.Transparent;
            this.lblUserName.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblUserName.ForeColor = System.Drawing.Color.White;
            this.lblUserName.Location = new System.Drawing.Point(1782, 48);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(96, 56);
            this.lblUserName.TabIndex = 43;
            this.lblUserName.Text = "欢迎您，\r\n刘萌萌";
            this.lblUserName.Visible = false;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Transparent;
            this.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBack.Image = global::SmartShelfUI.Properties.Resources.返回;
            this.btnBack.Location = new System.Drawing.Point(1835, 962);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(73, 106);
            this.btnBack.TabIndex = 44;
            this.btnBack.TabStop = false;
            this.btnBack.Visible = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SmartShelfUI.Properties.Resources.背景1920_1080;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.pxb_loginface);
            this.Controls.Add(this.panel_content);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.lblSoftwareTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Main";
            this.Text = "航瑞成智能柜刀具领用系统";
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pxb_loginface)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBack)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSoftwareTitle;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Panel panel_content;
        private System.Windows.Forms.PictureBox pxb_loginface;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.PictureBox btnBack;
    }
}