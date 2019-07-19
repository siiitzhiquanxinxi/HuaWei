namespace SmartShelfUI.ChildForm
{
    partial class CellsLocation
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
            this.panel_Cells = new System.Windows.Forms.Panel();
            this.lblShelfNo = new System.Windows.Forms.Label();
            this.txtKeyInBarcode = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnPickToolByKey = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvToolList = new System.Windows.Forms.DataGridView();
            this.toolName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolBarcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblToolBarcode = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblToolName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.spCom = new System.IO.Ports.SerialPort(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblToolNum = new System.Windows.Forms.Label();
            this.panel_Cells.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvToolList)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_Cells
            // 
            this.panel_Cells.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_Cells.Controls.Add(this.lblToolNum);
            this.panel_Cells.Controls.Add(this.lblShelfNo);
            this.panel_Cells.Controls.Add(this.txtKeyInBarcode);
            this.panel_Cells.Controls.Add(this.label5);
            this.panel_Cells.Controls.Add(this.btnPickToolByKey);
            this.panel_Cells.Controls.Add(this.label4);
            this.panel_Cells.Controls.Add(this.dgvToolList);
            this.panel_Cells.Controls.Add(this.lblToolBarcode);
            this.panel_Cells.Controls.Add(this.label6);
            this.panel_Cells.Controls.Add(this.label3);
            this.panel_Cells.Controls.Add(this.lblToolName);
            this.panel_Cells.Controls.Add(this.label1);
            this.panel_Cells.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_Cells.Location = new System.Drawing.Point(0, 0);
            this.panel_Cells.Name = "panel_Cells";
            this.panel_Cells.Size = new System.Drawing.Size(1000, 880);
            this.panel_Cells.TabIndex = 0;
            // 
            // lblShelfNo
            // 
            this.lblShelfNo.AutoSize = true;
            this.lblShelfNo.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblShelfNo.Location = new System.Drawing.Point(645, 34);
            this.lblShelfNo.Name = "lblShelfNo";
            this.lblShelfNo.Size = new System.Drawing.Size(120, 28);
            this.lblShelfNo.TabIndex = 5;
            this.lblShelfNo.Text = "1号柜1号锁";
            // 
            // txtKeyInBarcode
            // 
            this.txtKeyInBarcode.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtKeyInBarcode.Location = new System.Drawing.Point(642, 451);
            this.txtKeyInBarcode.Name = "txtKeyInBarcode";
            this.txtKeyInBarcode.Size = new System.Drawing.Size(321, 33);
            this.txtKeyInBarcode.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(641, 426);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(186, 21);
            this.label5.TabIndex = 3;
            this.label5.Text = "手工输入刀具编码领料：";
            // 
            // btnPickToolByKey
            // 
            this.btnPickToolByKey.BackColor = System.Drawing.Color.Transparent;
            this.btnPickToolByKey.BackgroundImage = global::SmartShelfUI.Properties.Resources.圆角矩形_732_拷贝_4;
            this.btnPickToolByKey.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPickToolByKey.FlatAppearance.BorderSize = 0;
            this.btnPickToolByKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPickToolByKey.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Bold);
            this.btnPickToolByKey.ForeColor = System.Drawing.Color.White;
            this.btnPickToolByKey.Location = new System.Drawing.Point(706, 508);
            this.btnPickToolByKey.Name = "btnPickToolByKey";
            this.btnPickToolByKey.Size = new System.Drawing.Size(200, 75);
            this.btnPickToolByKey.TabIndex = 0;
            this.btnPickToolByKey.Text = "手动领料";
            this.btnPickToolByKey.UseVisualStyleBackColor = false;
            this.btnPickToolByKey.Click += new System.EventHandler(this.btnPickToolByKey_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(638, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 21);
            this.label4.TabIndex = 3;
            this.label4.Text = "待取刀具列表：";
            // 
            // dgvToolList
            // 
            this.dgvToolList.AllowUserToAddRows = false;
            this.dgvToolList.AllowUserToDeleteRows = false;
            this.dgvToolList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvToolList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.toolName,
            this.toolBarcode});
            this.dgvToolList.Location = new System.Drawing.Point(642, 115);
            this.dgvToolList.Name = "dgvToolList";
            this.dgvToolList.ReadOnly = true;
            this.dgvToolList.RowTemplate.Height = 23;
            this.dgvToolList.Size = new System.Drawing.Size(321, 271);
            this.dgvToolList.TabIndex = 2;
            // 
            // toolName
            // 
            this.toolName.DataPropertyName = "toolName";
            this.toolName.HeaderText = "刀具名称";
            this.toolName.Name = "toolName";
            this.toolName.ReadOnly = true;
            this.toolName.Width = 150;
            // 
            // toolBarcode
            // 
            this.toolBarcode.DataPropertyName = "toolBarcode";
            this.toolBarcode.HeaderText = "刀具编码";
            this.toolBarcode.Name = "toolBarcode";
            this.toolBarcode.ReadOnly = true;
            this.toolBarcode.Width = 120;
            // 
            // lblToolBarcode
            // 
            this.lblToolBarcode.AutoSize = true;
            this.lblToolBarcode.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblToolBarcode.Location = new System.Drawing.Point(640, 713);
            this.lblToolBarcode.Name = "lblToolBarcode";
            this.lblToolBarcode.Size = new System.Drawing.Size(0, 27);
            this.lblToolBarcode.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(629, 681);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 27);
            this.label3.TabIndex = 1;
            this.label3.Text = "刀具编码：";
            // 
            // lblToolName
            // 
            this.lblToolName.AutoSize = true;
            this.lblToolName.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblToolName.Location = new System.Drawing.Point(637, 632);
            this.lblToolName.Name = "lblToolName";
            this.lblToolName.Size = new System.Drawing.Size(0, 27);
            this.lblToolName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(629, 600);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 27);
            this.label1.TabIndex = 1;
            this.label1.Text = "刀具名称：";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.BackgroundImage = global::SmartShelfUI.Properties.Resources.圆角矩形_732_拷贝_3;
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(382, 885);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(200, 89);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "返  回";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // spCom
            // 
            this.spCom.BaudRate = 115200;
            this.spCom.Parity = System.IO.Ports.Parity.Even;
            this.spCom.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.spCom_DataReceived);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(630, 919);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(259, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "刀具领用完毕，请关闭抽屉！";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(631, 749);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 27);
            this.label6.TabIndex = 1;
            this.label6.Text = "刀具号：";
            // 
            // lblToolNum
            // 
            this.lblToolNum.AutoSize = true;
            this.lblToolNum.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblToolNum.Location = new System.Drawing.Point(729, 753);
            this.lblToolNum.Name = "lblToolNum";
            this.lblToolNum.Size = new System.Drawing.Size(0, 21);
            this.lblToolNum.TabIndex = 6;
            // 
            // CellsLocation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 980);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel_Cells);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CellsLocation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CellsLocation";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CellsLocation_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CellsLocation_FormClosed);
            this.Load += new System.EventHandler(this.CellsLocation_Load);
            this.panel_Cells.ResumeLayout(false);
            this.panel_Cells.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvToolList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel_Cells;
        private System.Windows.Forms.Button btnCancel;
        private System.IO.Ports.SerialPort spCom;
        private System.Windows.Forms.Label lblToolBarcode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblToolName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvToolList;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtKeyInBarcode;
        private System.Windows.Forms.Button btnPickToolByKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn toolName;
        private System.Windows.Forms.DataGridViewTextBoxColumn toolBarcode;
        private System.Windows.Forms.Label lblShelfNo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblToolNum;
    }
}