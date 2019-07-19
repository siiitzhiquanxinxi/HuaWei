namespace SmartShelfUI.ChildForm
{
    partial class Stock
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.btnRepairOpen = new System.Windows.Forms.Button();
            this.panel_CAM = new System.Windows.Forms.Panel();
            this.dgvCabinet = new System.Windows.Forms.DataGridView();
            this.CabinetNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label13 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnOpenDoor = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvShelf = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BoxNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel_Cells = new System.Windows.Forms.Panel();
            this.spCom = new System.IO.Ports.SerialPort(this.components);
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel_order = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnReScan = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblToolState = new System.Windows.Forms.Label();
            this.lblShelfNo = new System.Windows.Forms.Label();
            this.lblCabinetNo = new System.Windows.Forms.Label();
            this.lblRestWorkTime = new System.Windows.Forms.Label();
            this.lblToolLevel = new System.Windows.Forms.Label();
            this.lblToolName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel_CAM.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCabinet)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShelf)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel_order.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::SmartShelfUI.Properties.Resources.半透明_背景;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.btnRepairOpen);
            this.panel2.Controls.Add(this.panel_CAM);
            this.panel2.Location = new System.Drawing.Point(12, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(315, 755);
            this.panel2.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(158, 689);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(116, 17);
            this.label7.TabIndex = 7;
            this.label7.Text = "打开该柜的所有抽屉";
            this.label7.Visible = false;
            // 
            // btnRepairOpen
            // 
            this.btnRepairOpen.BackColor = System.Drawing.Color.Transparent;
            this.btnRepairOpen.BackgroundImage = global::SmartShelfUI.Properties.Resources.圆角矩形_732_拷贝_3;
            this.btnRepairOpen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRepairOpen.FlatAppearance.BorderSize = 0;
            this.btnRepairOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRepairOpen.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRepairOpen.ForeColor = System.Drawing.Color.Transparent;
            this.btnRepairOpen.Location = new System.Drawing.Point(41, 674);
            this.btnRepairOpen.Name = "btnRepairOpen";
            this.btnRepairOpen.Size = new System.Drawing.Size(111, 44);
            this.btnRepairOpen.TabIndex = 6;
            this.btnRepairOpen.Text = "维修开锁";
            this.btnRepairOpen.UseVisualStyleBackColor = false;
            this.btnRepairOpen.Visible = false;
            this.btnRepairOpen.Click += new System.EventHandler(this.btnRepairOpen_Click);
            // 
            // panel_CAM
            // 
            this.panel_CAM.AutoScroll = true;
            this.panel_CAM.Controls.Add(this.dgvCabinet);
            this.panel_CAM.Controls.Add(this.label13);
            this.panel_CAM.Location = new System.Drawing.Point(41, 45);
            this.panel_CAM.Name = "panel_CAM";
            this.panel_CAM.Size = new System.Drawing.Size(225, 621);
            this.panel_CAM.TabIndex = 2;
            // 
            // dgvCabinet
            // 
            this.dgvCabinet.AllowUserToAddRows = false;
            this.dgvCabinet.AllowUserToDeleteRows = false;
            this.dgvCabinet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCabinet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CabinetNo});
            this.dgvCabinet.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvCabinet.Location = new System.Drawing.Point(0, 37);
            this.dgvCabinet.Name = "dgvCabinet";
            this.dgvCabinet.ReadOnly = true;
            this.dgvCabinet.RowTemplate.Height = 45;
            this.dgvCabinet.Size = new System.Drawing.Size(225, 584);
            this.dgvCabinet.TabIndex = 2;
            this.dgvCabinet.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvCabinet_CellMouseClick);
            // 
            // CabinetNo
            // 
            this.CabinetNo.DataPropertyName = "CabinetNo";
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CabinetNo.DefaultCellStyle = dataGridViewCellStyle1;
            this.CabinetNo.HeaderText = "柜号";
            this.CabinetNo.Name = "CabinetNo";
            this.CabinetNo.ReadOnly = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label13.Location = new System.Drawing.Point(16, 12);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(58, 22);
            this.label13.TabIndex = 1;
            this.label13.Text = "柜清单";
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::SmartShelfUI.Properties.Resources.半透明_背景;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.btnOpenDoor);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Location = new System.Drawing.Point(333, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(315, 755);
            this.panel1.TabIndex = 2;
            // 
            // btnOpenDoor
            // 
            this.btnOpenDoor.BackColor = System.Drawing.Color.Transparent;
            this.btnOpenDoor.BackgroundImage = global::SmartShelfUI.Properties.Resources.圆角矩形_732_拷贝_4;
            this.btnOpenDoor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOpenDoor.FlatAppearance.BorderSize = 0;
            this.btnOpenDoor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenDoor.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOpenDoor.ForeColor = System.Drawing.Color.Transparent;
            this.btnOpenDoor.Location = new System.Drawing.Point(76, 673);
            this.btnOpenDoor.Name = "btnOpenDoor";
            this.btnOpenDoor.Size = new System.Drawing.Size(149, 47);
            this.btnOpenDoor.TabIndex = 4;
            this.btnOpenDoor.Text = "开抽屉";
            this.btnOpenDoor.UseVisualStyleBackColor = false;
            this.btnOpenDoor.Click += new System.EventHandler(this.btnOpenDoor_Click);
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.Controls.Add(this.dgvShelf);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(41, 45);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(225, 618);
            this.panel3.TabIndex = 2;
            // 
            // dgvShelf
            // 
            this.dgvShelf.AllowUserToAddRows = false;
            this.dgvShelf.AllowUserToDeleteRows = false;
            this.dgvShelf.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShelf.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.BoxNo});
            this.dgvShelf.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvShelf.Location = new System.Drawing.Point(0, 34);
            this.dgvShelf.Name = "dgvShelf";
            this.dgvShelf.ReadOnly = true;
            this.dgvShelf.RowTemplate.Height = 30;
            this.dgvShelf.Size = new System.Drawing.Size(225, 584);
            this.dgvShelf.TabIndex = 3;
            this.dgvShelf.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvShelf_CellClick);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // BoxNo
            // 
            this.BoxNo.DataPropertyName = "BoxNo";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BoxNo.DefaultCellStyle = dataGridViewCellStyle2;
            this.BoxNo.HeaderText = "抽屉号";
            this.BoxNo.Name = "BoxNo";
            this.BoxNo.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label1.Location = new System.Drawing.Point(16, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "抽屉清单";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel_Cells);
            this.groupBox2.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(661, 21);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(598, 758);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "刀具位置";
            // 
            // panel_Cells
            // 
            this.panel_Cells.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Cells.Location = new System.Drawing.Point(3, 30);
            this.panel_Cells.Name = "panel_Cells";
            this.panel_Cells.Size = new System.Drawing.Size(592, 725);
            this.panel_Cells.TabIndex = 0;
            // 
            // spCom
            // 
            this.spCom.BaudRate = 115200;
            this.spCom.Parity = System.IO.Ports.Parity.Even;
            this.spCom.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.spCom_DataReceived);
            // 
            // panel4
            // 
            this.panel4.BackgroundImage = global::SmartShelfUI.Properties.Resources.半透明_背景;
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel4.Controls.Add(this.panel_order);
            this.panel4.Location = new System.Drawing.Point(1282, 21);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(607, 755);
            this.panel4.TabIndex = 8;
            // 
            // panel_order
            // 
            this.panel_order.AutoScroll = true;
            this.panel_order.Controls.Add(this.groupBox1);
            this.panel_order.Location = new System.Drawing.Point(36, 69);
            this.panel_order.Name = "panel_order";
            this.panel_order.Size = new System.Drawing.Size(512, 630);
            this.panel_order.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnReScan);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblToolState);
            this.groupBox1.Controls.Add(this.lblShelfNo);
            this.groupBox1.Controls.Add(this.lblCabinetNo);
            this.groupBox1.Controls.Add(this.lblRestWorkTime);
            this.groupBox1.Controls.Add(this.lblToolLevel);
            this.groupBox1.Controls.Add(this.lblToolName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(512, 630);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "刀具信息";
            // 
            // btnReScan
            // 
            this.btnReScan.BackColor = System.Drawing.Color.Transparent;
            this.btnReScan.BackgroundImage = global::SmartShelfUI.Properties.Resources.圆角矩形_732_拷贝_5;
            this.btnReScan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReScan.FlatAppearance.BorderSize = 0;
            this.btnReScan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReScan.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnReScan.ForeColor = System.Drawing.Color.Transparent;
            this.btnReScan.Location = new System.Drawing.Point(159, 445);
            this.btnReScan.Name = "btnReScan";
            this.btnReScan.Size = new System.Drawing.Size(200, 60);
            this.btnReScan.TabIndex = 6;
            this.btnReScan.Text = "重新扫描";
            this.btnReScan.UseVisualStyleBackColor = false;
            this.btnReScan.Click += new System.EventHandler(this.btnReScan_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label11.Location = new System.Drawing.Point(44, 361);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(90, 21);
            this.label11.TabIndex = 1;
            this.label11.Text = "物料状态：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(28, 301);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 21);
            this.label6.TabIndex = 0;
            this.label6.Text = "所属抽屉号：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(44, 241);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 21);
            this.label5.TabIndex = 0;
            this.label5.Text = "所属柜号：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(12, 181);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 21);
            this.label4.TabIndex = 0;
            this.label4.Text = "剩余加工时间：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(44, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 21);
            this.label3.TabIndex = 0;
            this.label3.Text = "刀具等级：";
            // 
            // lblToolState
            // 
            this.lblToolState.AutoSize = true;
            this.lblToolState.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblToolState.Location = new System.Drawing.Point(155, 361);
            this.lblToolState.Name = "lblToolState";
            this.lblToolState.Size = new System.Drawing.Size(24, 21);
            this.lblToolState.TabIndex = 0;
            this.lblToolState.Text = "--";
            // 
            // lblShelfNo
            // 
            this.lblShelfNo.AutoSize = true;
            this.lblShelfNo.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblShelfNo.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblShelfNo.Location = new System.Drawing.Point(155, 299);
            this.lblShelfNo.Name = "lblShelfNo";
            this.lblShelfNo.Size = new System.Drawing.Size(24, 22);
            this.lblShelfNo.TabIndex = 0;
            this.lblShelfNo.Text = "--";
            // 
            // lblCabinetNo
            // 
            this.lblCabinetNo.AutoSize = true;
            this.lblCabinetNo.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCabinetNo.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblCabinetNo.Location = new System.Drawing.Point(155, 241);
            this.lblCabinetNo.Name = "lblCabinetNo";
            this.lblCabinetNo.Size = new System.Drawing.Size(24, 22);
            this.lblCabinetNo.TabIndex = 0;
            this.lblCabinetNo.Text = "--";
            // 
            // lblRestWorkTime
            // 
            this.lblRestWorkTime.AutoSize = true;
            this.lblRestWorkTime.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRestWorkTime.Location = new System.Drawing.Point(155, 181);
            this.lblRestWorkTime.Name = "lblRestWorkTime";
            this.lblRestWorkTime.Size = new System.Drawing.Size(24, 21);
            this.lblRestWorkTime.TabIndex = 0;
            this.lblRestWorkTime.Text = "--";
            // 
            // lblToolLevel
            // 
            this.lblToolLevel.AutoSize = true;
            this.lblToolLevel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblToolLevel.Location = new System.Drawing.Point(155, 121);
            this.lblToolLevel.Name = "lblToolLevel";
            this.lblToolLevel.Size = new System.Drawing.Size(24, 21);
            this.lblToolLevel.TabIndex = 0;
            this.lblToolLevel.Text = "--";
            // 
            // lblToolName
            // 
            this.lblToolName.AutoSize = true;
            this.lblToolName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblToolName.Location = new System.Drawing.Point(155, 61);
            this.lblToolName.Name = "lblToolName";
            this.lblToolName.Size = new System.Drawing.Size(24, 21);
            this.lblToolName.TabIndex = 0;
            this.lblToolName.Text = "--";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(44, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "刀具名称：";
            // 
            // Stock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 780);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Stock";
            this.Text = "Stock";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Stock_FormClosing);
            this.Load += new System.EventHandler(this.Stock_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel_CAM.ResumeLayout(false);
            this.panel_CAM.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCabinet)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShelf)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel_order.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel_CAM;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel_Cells;
        private System.IO.Ports.SerialPort spCom;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel_order;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblToolState;
        private System.Windows.Forms.Label lblShelfNo;
        private System.Windows.Forms.Label lblCabinetNo;
        private System.Windows.Forms.Label lblRestWorkTime;
        private System.Windows.Forms.Label lblToolLevel;
        private System.Windows.Forms.Label lblToolName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvCabinet;
        private System.Windows.Forms.DataGridView dgvShelf;
        private System.Windows.Forms.Button btnOpenDoor;
        private System.Windows.Forms.Button btnReScan;
        private System.Windows.Forms.DataGridViewTextBoxColumn CabinetNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn BoxNo;
        private System.Windows.Forms.Button btnRepairOpen;
        private System.Windows.Forms.Label label7;
    }
}