namespace SmartShelfUI.ChildForm
{
    partial class Menu
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
            this.btnWeb = new System.Windows.Forms.PictureBox();
            this.btnUsers = new System.Windows.Forms.PictureBox();
            this.btnStock = new System.Windows.Forms.PictureBox();
            this.btnWarehouse = new System.Windows.Forms.PictureBox();
            this.btnRepair = new System.Windows.Forms.PictureBox();
            this.btnPick = new System.Windows.Forms.PictureBox();
            this.btnReturn = new System.Windows.Forms.PictureBox();
            this.btnExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.btnWeb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnWarehouse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRepair)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPick)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnReturn)).BeginInit();
            this.SuspendLayout();
            // 
            // btnWeb
            // 
            this.btnWeb.BackgroundImage = global::SmartShelfUI.Properties.Resources.btnWeb;
            this.btnWeb.Location = new System.Drawing.Point(1010, 403);
            this.btnWeb.Name = "btnWeb";
            this.btnWeb.Size = new System.Drawing.Size(300, 300);
            this.btnWeb.TabIndex = 0;
            this.btnWeb.TabStop = false;
            this.btnWeb.Click += new System.EventHandler(this.btnWeb_Click);
            // 
            // btnUsers
            // 
            this.btnUsers.BackgroundImage = global::SmartShelfUI.Properties.Resources.btnUsercard;
            this.btnUsers.Location = new System.Drawing.Point(1402, 46);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Size = new System.Drawing.Size(300, 300);
            this.btnUsers.TabIndex = 0;
            this.btnUsers.TabStop = false;
            this.btnUsers.Click += new System.EventHandler(this.btnUsers_Click);
            // 
            // btnStock
            // 
            this.btnStock.BackgroundImage = global::SmartShelfUI.Properties.Resources.btnStock;
            this.btnStock.Location = new System.Drawing.Point(1010, 46);
            this.btnStock.Name = "btnStock";
            this.btnStock.Size = new System.Drawing.Size(300, 300);
            this.btnStock.TabIndex = 0;
            this.btnStock.TabStop = false;
            this.btnStock.Click += new System.EventHandler(this.btnStock_Click);
            // 
            // btnWarehouse
            // 
            this.btnWarehouse.BackgroundImage = global::SmartShelfUI.Properties.Resources.btnWarehousing;
            this.btnWarehouse.Location = new System.Drawing.Point(609, 46);
            this.btnWarehouse.Name = "btnWarehouse";
            this.btnWarehouse.Size = new System.Drawing.Size(300, 300);
            this.btnWarehouse.TabIndex = 0;
            this.btnWarehouse.TabStop = false;
            this.btnWarehouse.Click += new System.EventHandler(this.btnWarehouse_Click);
            // 
            // btnRepair
            // 
            this.btnRepair.BackgroundImage = global::SmartShelfUI.Properties.Resources.btnRepair;
            this.btnRepair.Location = new System.Drawing.Point(609, 403);
            this.btnRepair.Name = "btnRepair";
            this.btnRepair.Size = new System.Drawing.Size(300, 300);
            this.btnRepair.TabIndex = 0;
            this.btnRepair.TabStop = false;
            this.btnRepair.Click += new System.EventHandler(this.btnRepair_Click);
            // 
            // btnPick
            // 
            this.btnPick.BackgroundImage = global::SmartShelfUI.Properties.Resources.btnPick;
            this.btnPick.Location = new System.Drawing.Point(208, 46);
            this.btnPick.Name = "btnPick";
            this.btnPick.Size = new System.Drawing.Size(300, 300);
            this.btnPick.TabIndex = 0;
            this.btnPick.TabStop = false;
            this.btnPick.Click += new System.EventHandler(this.btnPick_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.BackgroundImage = global::SmartShelfUI.Properties.Resources.btnReturn;
            this.btnReturn.Location = new System.Drawing.Point(208, 403);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(300, 300);
            this.btnReturn.TabIndex = 0;
            this.btnReturn.TabStop = false;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackgroundImage = global::SmartShelfUI.Properties.Resources.btn_login;
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(1463, 473);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(213, 166);
            this.btnExit.TabIndex = 41;
            this.btnExit.Text = "退出\r\nEXIT";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 780);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnWeb);
            this.Controls.Add(this.btnUsers);
            this.Controls.Add(this.btnStock);
            this.Controls.Add(this.btnWarehouse);
            this.Controls.Add(this.btnRepair);
            this.Controls.Add(this.btnPick);
            this.Controls.Add(this.btnReturn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Menu";
            this.Text = "Menu";
            ((System.ComponentModel.ISupportInitialize)(this.btnWeb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnWarehouse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRepair)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPick)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnReturn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox btnReturn;
        private System.Windows.Forms.PictureBox btnRepair;
        private System.Windows.Forms.PictureBox btnWarehouse;
        private System.Windows.Forms.PictureBox btnStock;
        private System.Windows.Forms.PictureBox btnUsers;
        private System.Windows.Forms.PictureBox btnPick;
        private System.Windows.Forms.PictureBox btnWeb;
        private System.Windows.Forms.Button btnExit;
    }
}