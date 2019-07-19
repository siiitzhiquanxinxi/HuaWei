namespace SmartShelfUI.ChildForm
{
    partial class DisPick_Plan
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.panel_ApproveList = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_ApproveList = new System.Windows.Forms.DataGridView();
            this.ApproveNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateByName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ApplyToolName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ApplyPartNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ApproveState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CabinetNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BoxNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnApply = new System.Windows.Forms.Button();
            this.panel_order = new System.Windows.Forms.Panel();
            this.dgvCamList = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PartNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ToolName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WorkTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ToolLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ToolReadyState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel_ApproveList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ApproveList)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel_order.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCamList)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::SmartShelfUI.Properties.Resources.半透明_背景;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.btnRefresh);
            this.panel2.Controls.Add(this.btnOpen);
            this.panel2.Controls.Add(this.panel_ApproveList);
            this.panel2.Location = new System.Drawing.Point(103, 13);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(912, 755);
            this.panel2.TabIndex = 2;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.Transparent;
            this.btnRefresh.BackgroundImage = global::SmartShelfUI.Properties.Resources.圆角矩形_732_拷贝_5;
            this.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(566, 672);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(187, 48);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "刷  新";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.BackColor = System.Drawing.Color.Transparent;
            this.btnOpen.BackgroundImage = global::SmartShelfUI.Properties.Resources.圆角矩形_732_拷贝_4;
            this.btnOpen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOpen.FlatAppearance.BorderSize = 0;
            this.btnOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpen.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOpen.ForeColor = System.Drawing.Color.White;
            this.btnOpen.Location = new System.Drawing.Point(156, 672);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(187, 48);
            this.btnOpen.TabIndex = 3;
            this.btnOpen.Text = "开  锁";
            this.btnOpen.UseVisualStyleBackColor = false;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // panel_ApproveList
            // 
            this.panel_ApproveList.AutoScroll = true;
            this.panel_ApproveList.Controls.Add(this.label1);
            this.panel_ApproveList.Controls.Add(this.dgv_ApproveList);
            this.panel_ApproveList.Location = new System.Drawing.Point(41, 45);
            this.panel_ApproveList.Name = "panel_ApproveList";
            this.panel_ApproveList.Size = new System.Drawing.Size(824, 609);
            this.panel_ApproveList.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(19, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "待审核清单";
            // 
            // dgv_ApproveList
            // 
            this.dgv_ApproveList.AllowUserToAddRows = false;
            this.dgv_ApproveList.AllowUserToDeleteRows = false;
            this.dgv_ApproveList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ApproveList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ApproveNum,
            this.CreateDate,
            this.CreateByName,
            this.ApplyToolName,
            this.ApplyPartNum,
            this.ApproveState,
            this.CabinetNo,
            this.BoxNo});
            this.dgv_ApproveList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgv_ApproveList.Location = new System.Drawing.Point(0, 33);
            this.dgv_ApproveList.Name = "dgv_ApproveList";
            this.dgv_ApproveList.ReadOnly = true;
            this.dgv_ApproveList.RowTemplate.Height = 30;
            this.dgv_ApproveList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_ApproveList.Size = new System.Drawing.Size(824, 576);
            this.dgv_ApproveList.TabIndex = 0;
            // 
            // ApproveNum
            // 
            this.ApproveNum.DataPropertyName = "ApproveNum";
            this.ApproveNum.HeaderText = "申请单号";
            this.ApproveNum.Name = "ApproveNum";
            this.ApproveNum.ReadOnly = true;
            // 
            // CreateDate
            // 
            this.CreateDate.DataPropertyName = "CreateDate";
            this.CreateDate.HeaderText = "申请时间";
            this.CreateDate.Name = "CreateDate";
            this.CreateDate.ReadOnly = true;
            // 
            // CreateByName
            // 
            this.CreateByName.DataPropertyName = "CreateByName";
            this.CreateByName.HeaderText = "申请人";
            this.CreateByName.Name = "CreateByName";
            this.CreateByName.ReadOnly = true;
            // 
            // ApplyToolName
            // 
            this.ApplyToolName.DataPropertyName = "ApplyToolName";
            this.ApplyToolName.HeaderText = "申请刀具";
            this.ApplyToolName.Name = "ApplyToolName";
            this.ApplyToolName.ReadOnly = true;
            // 
            // ApplyPartNum
            // 
            this.ApplyPartNum.DataPropertyName = "ApplyPartNum";
            this.ApplyPartNum.HeaderText = "零件号";
            this.ApplyPartNum.Name = "ApplyPartNum";
            this.ApplyPartNum.ReadOnly = true;
            // 
            // ApproveState
            // 
            this.ApproveState.DataPropertyName = "state";
            this.ApproveState.HeaderText = "审核状态";
            this.ApproveState.Name = "ApproveState";
            this.ApproveState.ReadOnly = true;
            // 
            // CabinetNo
            // 
            this.CabinetNo.DataPropertyName = "FK_CabinetNo";
            this.CabinetNo.HeaderText = "柜号";
            this.CabinetNo.Name = "CabinetNo";
            this.CabinetNo.ReadOnly = true;
            // 
            // BoxNo
            // 
            this.BoxNo.DataPropertyName = "BoxNo";
            this.BoxNo.HeaderText = "抽屉号";
            this.BoxNo.Name = "BoxNo";
            this.BoxNo.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::SmartShelfUI.Properties.Resources.半透明_背景;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.btnApply);
            this.panel1.Controls.Add(this.panel_order);
            this.panel1.Location = new System.Drawing.Point(1179, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(674, 755);
            this.panel1.TabIndex = 3;
            // 
            // btnApply
            // 
            this.btnApply.BackColor = System.Drawing.Color.Transparent;
            this.btnApply.BackgroundImage = global::SmartShelfUI.Properties.Resources.圆角矩形_732_拷贝_4;
            this.btnApply.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnApply.FlatAppearance.BorderSize = 0;
            this.btnApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApply.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnApply.ForeColor = System.Drawing.Color.White;
            this.btnApply.Location = new System.Drawing.Point(238, 672);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(187, 48);
            this.btnApply.TabIndex = 3;
            this.btnApply.Text = "申请零星领料";
            this.btnApply.UseVisualStyleBackColor = false;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // panel_order
            // 
            this.panel_order.AutoScroll = true;
            this.panel_order.Controls.Add(this.dgvCamList);
            this.panel_order.Location = new System.Drawing.Point(56, 52);
            this.panel_order.Name = "panel_order";
            this.panel_order.Size = new System.Drawing.Size(556, 614);
            this.panel_order.TabIndex = 1;
            // 
            // dgvCamList
            // 
            this.dgvCamList.AllowUserToAddRows = false;
            this.dgvCamList.AllowUserToDeleteRows = false;
            this.dgvCamList.ColumnHeadersHeight = 40;
            this.dgvCamList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.PartNum,
            this.ToolName,
            this.WorkTime,
            this.ToolLevel,
            this.ToolReadyState});
            this.dgvCamList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCamList.Location = new System.Drawing.Point(0, 0);
            this.dgvCamList.Name = "dgvCamList";
            this.dgvCamList.ReadOnly = true;
            this.dgvCamList.RowTemplate.Height = 40;
            this.dgvCamList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCamList.Size = new System.Drawing.Size(556, 614);
            this.dgvCamList.TabIndex = 1;
            this.dgvCamList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvCamList_DataBindingComplete);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // PartNum
            // 
            this.PartNum.DataPropertyName = "PartNum";
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PartNum.DefaultCellStyle = dataGridViewCellStyle1;
            this.PartNum.HeaderText = "零件号";
            this.PartNum.Name = "PartNum";
            this.PartNum.ReadOnly = true;
            // 
            // ToolName
            // 
            this.ToolName.DataPropertyName = "ToolName";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ToolName.DefaultCellStyle = dataGridViewCellStyle2;
            this.ToolName.HeaderText = "刀具名称";
            this.ToolName.Name = "ToolName";
            this.ToolName.ReadOnly = true;
            // 
            // WorkTime
            // 
            this.WorkTime.DataPropertyName = "WorkTime";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.WorkTime.DefaultCellStyle = dataGridViewCellStyle3;
            this.WorkTime.HeaderText = "加工时间";
            this.WorkTime.Name = "WorkTime";
            this.WorkTime.ReadOnly = true;
            this.WorkTime.Width = 80;
            // 
            // ToolLevel
            // 
            this.ToolLevel.DataPropertyName = "ToolLevel";
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.ToolLevel.DefaultCellStyle = dataGridViewCellStyle4;
            this.ToolLevel.HeaderText = "刀具等级";
            this.ToolLevel.Name = "ToolLevel";
            this.ToolLevel.ReadOnly = true;
            this.ToolLevel.Width = 90;
            // 
            // ToolReadyState
            // 
            this.ToolReadyState.DataPropertyName = "ToolState";
            dataGridViewCellStyle5.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.ToolReadyState.DefaultCellStyle = dataGridViewCellStyle5;
            this.ToolReadyState.HeaderText = "备料状态";
            this.ToolReadyState.Name = "ToolReadyState";
            this.ToolReadyState.ReadOnly = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(1045, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 28);
            this.label3.TabIndex = 4;
            this.label3.Text = "提交申请>>";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(11, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 28);
            this.label4.TabIndex = 4;
            this.label4.Text = "取料>>";
            // 
            // DisPick_Plan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 780);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DisPick_Plan";
            this.Text = "DisPick_Plan";
            this.Load += new System.EventHandler(this.DisPick_Plan_Load);
            this.panel2.ResumeLayout(false);
            this.panel_ApproveList.ResumeLayout(false);
            this.panel_ApproveList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ApproveList)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel_order.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCamList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel_ApproveList;
        private System.Windows.Forms.DataGridView dgv_ApproveList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel_order;
        private System.Windows.Forms.DataGridView dgvCamList;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn PartNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn ToolName;
        private System.Windows.Forms.DataGridViewTextBoxColumn WorkTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ToolLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ToolReadyState;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApproveNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateByName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApplyToolName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApplyPartNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApproveState;
        private System.Windows.Forms.DataGridViewTextBoxColumn CabinetNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn BoxNo;
    }
}