namespace SmartShelfUI.ChildForm
{
    partial class Warehousing
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
            this.spCom = new System.IO.Ports.SerialPort(this.components);
            this.pbxToolPic = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel_Cells = new System.Windows.Forms.Panel();
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel_order = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pbxToolPic)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel_order.SuspendLayout();
            this.SuspendLayout();
            // 
            // spCom
            // 
            this.spCom.BaudRate = 115200;
            this.spCom.Parity = System.IO.Ports.Parity.Even;
            this.spCom.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.spCom_DataReceived);
            // 
            // pbxToolPic
            // 
            this.pbxToolPic.Location = new System.Drawing.Point(1389, 204);
            this.pbxToolPic.Name = "pbxToolPic";
            this.pbxToolPic.Size = new System.Drawing.Size(350, 400);
            this.pbxToolPic.TabIndex = 4;
            this.pbxToolPic.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel_Cells);
            this.groupBox2.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(705, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(598, 739);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "刀具位置";
            // 
            // panel_Cells
            // 
            this.panel_Cells.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Cells.Location = new System.Drawing.Point(3, 30);
            this.panel_Cells.Name = "panel_Cells";
            this.panel_Cells.Size = new System.Drawing.Size(592, 706);
            this.panel_Cells.TabIndex = 0;
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
            this.groupBox1.Size = new System.Drawing.Size(556, 581);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "刀具信息";
            // 
            // btnReScan
            // 
            this.btnReScan.BackColor = System.Drawing.Color.Transparent;
            this.btnReScan.BackgroundImage = global::SmartShelfUI.Properties.Resources.圆角矩形_732_拷贝_3;
            this.btnReScan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReScan.FlatAppearance.BorderSize = 0;
            this.btnReScan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReScan.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnReScan.ForeColor = System.Drawing.Color.Transparent;
            this.btnReScan.Location = new System.Drawing.Point(159, 500);
            this.btnReScan.Name = "btnReScan";
            this.btnReScan.Size = new System.Drawing.Size(200, 60);
            this.btnReScan.TabIndex = 7;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(58, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(278, 39);
            this.label1.TabIndex = 3;
            this.label1.Text = "请扫描刀具编码入库";
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::SmartShelfUI.Properties.Resources.半透明_背景;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.panel_order);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(674, 755);
            this.panel1.TabIndex = 7;
            // 
            // panel_order
            // 
            this.panel_order.AutoScroll = true;
            this.panel_order.Controls.Add(this.groupBox1);
            this.panel_order.Location = new System.Drawing.Point(56, 85);
            this.panel_order.Name = "panel_order";
            this.panel_order.Size = new System.Drawing.Size(556, 581);
            this.panel_order.TabIndex = 1;
            // 
            // Warehousing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 780);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pbxToolPic);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Warehousing";
            this.Text = "Warehousing";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Warehousing_FormClosing);
            this.Load += new System.EventHandler(this.Warehousing_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxToolPic)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel_order.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.IO.Ports.SerialPort spCom;
        private System.Windows.Forms.PictureBox pbxToolPic;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel_Cells;
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel_order;
        private System.Windows.Forms.Button btnReScan;
    }
}