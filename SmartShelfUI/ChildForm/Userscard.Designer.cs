namespace SmartShelfUI.ChildForm
{
    partial class Userscard
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel_order = new System.Windows.Forms.Panel();
            this.dgvUserList = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.user_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.real_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.spCom = new System.IO.Ports.SerialPort(this.components);
            this.panel1.SuspendLayout();
            this.panel_order.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserList)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::SmartShelfUI.Properties.Resources.半透明_背景;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.panel_order);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(26, 22);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(674, 755);
            this.panel1.TabIndex = 1;
            // 
            // panel_order
            // 
            this.panel_order.AutoScroll = true;
            this.panel_order.Controls.Add(this.dgvUserList);
            this.panel_order.Location = new System.Drawing.Point(56, 85);
            this.panel_order.Name = "panel_order";
            this.panel_order.Size = new System.Drawing.Size(556, 581);
            this.panel_order.TabIndex = 1;
            // 
            // dgvUserList
            // 
            this.dgvUserList.AllowUserToAddRows = false;
            this.dgvUserList.AllowUserToDeleteRows = false;
            this.dgvUserList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUserList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.user_name,
            this.real_name});
            this.dgvUserList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUserList.Location = new System.Drawing.Point(0, 0);
            this.dgvUserList.Name = "dgvUserList";
            this.dgvUserList.ReadOnly = true;
            this.dgvUserList.RowTemplate.Height = 35;
            this.dgvUserList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUserList.Size = new System.Drawing.Size(556, 581);
            this.dgvUserList.TabIndex = 0;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // user_name
            // 
            this.user_name.DataPropertyName = "user_name";
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.user_name.DefaultCellStyle = dataGridViewCellStyle1;
            this.user_name.HeaderText = "用户名";
            this.user_name.Name = "user_name";
            this.user_name.ReadOnly = true;
            this.user_name.Width = 250;
            // 
            // real_name
            // 
            this.real_name.DataPropertyName = "real_name";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.real_name.DefaultCellStyle = dataGridViewCellStyle2;
            this.real_name.HeaderText = "姓名";
            this.real_name.Name = "real_name";
            this.real_name.ReadOnly = true;
            this.real_name.Width = 250;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label1.Location = new System.Drawing.Point(62, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "用户列表";
            // 
            // spCom
            // 
            this.spCom.BaudRate = 115200;
            this.spCom.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.spCom_DataReceived);
            // 
            // Userscard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 780);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Userscard";
            this.Text = "Userscard";
            this.Load += new System.EventHandler(this.Userscard_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel_order.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel_order;
        private System.Windows.Forms.Label label1;
        private System.IO.Ports.SerialPort spCom;
        private System.Windows.Forms.DataGridView dgvUserList;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn user_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn real_name;
    }
}