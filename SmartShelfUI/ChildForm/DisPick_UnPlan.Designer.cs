namespace SmartShelfUI.ChildForm
{
    partial class DisPick_UnPlan
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
            this.label4 = new System.Windows.Forms.Label();
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
            this.ApproveState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FK_CabinetNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BoxNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnQueryTool = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvTool = new System.Windows.Forms.DataGridView();
            this.MaterialID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaterialName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Brand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Spec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbxTexture = new System.Windows.Forms.ComboBox();
            this.cbxToolLevel = new System.Windows.Forms.ComboBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.txtWorkTime = new System.Windows.Forms.TextBox();
            this.txtToolName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel_ApproveList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ApproveList)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTool)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(11, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 28);
            this.label4.TabIndex = 6;
            this.label4.Text = "取料>>";
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
            this.panel2.Size = new System.Drawing.Size(902, 755);
            this.panel2.TabIndex = 5;
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
            this.btnRefresh.Location = new System.Drawing.Point(429, 672);
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
            this.btnOpen.Location = new System.Drawing.Point(78, 672);
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
            this.panel_ApproveList.Size = new System.Drawing.Size(775, 609);
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
            this.ApproveState,
            this.FK_CabinetNo,
            this.BoxNo});
            this.dgv_ApproveList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgv_ApproveList.Location = new System.Drawing.Point(0, 33);
            this.dgv_ApproveList.Name = "dgv_ApproveList";
            this.dgv_ApproveList.ReadOnly = true;
            this.dgv_ApproveList.RowTemplate.Height = 30;
            this.dgv_ApproveList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_ApproveList.Size = new System.Drawing.Size(775, 576);
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
            // ApproveState
            // 
            this.ApproveState.DataPropertyName = "State";
            this.ApproveState.HeaderText = "申请状态";
            this.ApproveState.Name = "ApproveState";
            this.ApproveState.ReadOnly = true;
            // 
            // FK_CabinetNo
            // 
            this.FK_CabinetNo.DataPropertyName = "FK_CabinetNo";
            this.FK_CabinetNo.HeaderText = "柜号";
            this.FK_CabinetNo.Name = "FK_CabinetNo";
            this.FK_CabinetNo.ReadOnly = true;
            // 
            // BoxNo
            // 
            this.BoxNo.DataPropertyName = "BoxNo";
            this.BoxNo.HeaderText = "抽屉号";
            this.BoxNo.Name = "BoxNo";
            this.BoxNo.ReadOnly = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(1045, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 28);
            this.label3.TabIndex = 8;
            this.label3.Text = "提交申请>>";
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::SmartShelfUI.Properties.Resources.半透明_背景;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.btnQueryTool);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.cbxTexture);
            this.panel1.Controls.Add(this.cbxToolLevel);
            this.panel1.Controls.Add(this.btnApply);
            this.panel1.Controls.Add(this.txtWorkTime);
            this.panel1.Controls.Add(this.txtToolName);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(1179, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(674, 755);
            this.panel1.TabIndex = 7;
            // 
            // btnQueryTool
            // 
            this.btnQueryTool.BackColor = System.Drawing.Color.Transparent;
            this.btnQueryTool.BackgroundImage = global::SmartShelfUI.Properties.Resources.圆角矩形_732_拷贝_5;
            this.btnQueryTool.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnQueryTool.FlatAppearance.BorderSize = 0;
            this.btnQueryTool.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQueryTool.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnQueryTool.ForeColor = System.Drawing.Color.White;
            this.btnQueryTool.Location = new System.Drawing.Point(498, 35);
            this.btnQueryTool.Name = "btnQueryTool";
            this.btnQueryTool.Size = new System.Drawing.Size(92, 29);
            this.btnQueryTool.TabIndex = 3;
            this.btnQueryTool.Text = "筛 选";
            this.btnQueryTool.UseVisualStyleBackColor = false;
            this.btnQueryTool.Click += new System.EventHandler(this.btnQueryTool_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgvTool);
            this.panel3.Location = new System.Drawing.Point(58, 224);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(563, 398);
            this.panel3.TabIndex = 5;
            // 
            // dgvTool
            // 
            this.dgvTool.AllowUserToAddRows = false;
            this.dgvTool.AllowUserToDeleteRows = false;
            this.dgvTool.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTool.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaterialID,
            this.MaterialName,
            this.Brand,
            this.Spec});
            this.dgvTool.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTool.Location = new System.Drawing.Point(0, 0);
            this.dgvTool.Name = "dgvTool";
            this.dgvTool.ReadOnly = true;
            this.dgvTool.RowTemplate.Height = 30;
            this.dgvTool.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTool.Size = new System.Drawing.Size(563, 398);
            this.dgvTool.TabIndex = 0;
            // 
            // MaterialID
            // 
            this.MaterialID.DataPropertyName = "MaterialID";
            this.MaterialID.HeaderText = "MaterialID";
            this.MaterialID.Name = "MaterialID";
            this.MaterialID.ReadOnly = true;
            this.MaterialID.Visible = false;
            // 
            // MaterialName
            // 
            this.MaterialName.DataPropertyName = "MaterialName";
            this.MaterialName.HeaderText = "物料名称";
            this.MaterialName.Name = "MaterialName";
            this.MaterialName.ReadOnly = true;
            // 
            // Brand
            // 
            this.Brand.DataPropertyName = "Brand";
            this.Brand.HeaderText = "品牌";
            this.Brand.Name = "Brand";
            this.Brand.ReadOnly = true;
            // 
            // Spec
            // 
            this.Spec.DataPropertyName = "Spec";
            this.Spec.HeaderText = "规格";
            this.Spec.Name = "Spec";
            this.Spec.ReadOnly = true;
            // 
            // cbxTexture
            // 
            this.cbxTexture.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTexture.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxTexture.FormattingEnabled = true;
            this.cbxTexture.Items.AddRange(new object[] {
            "旧刀（F）",
            "新刀（X）",
            "返磨（R）"});
            this.cbxTexture.Location = new System.Drawing.Point(271, 173);
            this.cbxTexture.Name = "cbxTexture";
            this.cbxTexture.Size = new System.Drawing.Size(319, 29);
            this.cbxTexture.TabIndex = 4;
            // 
            // cbxToolLevel
            // 
            this.cbxToolLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxToolLevel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxToolLevel.FormattingEnabled = true;
            this.cbxToolLevel.Items.AddRange(new object[] {
            "--无--",
            "旧刀（F）",
            "新刀（X）",
            "返磨（R）"});
            this.cbxToolLevel.Location = new System.Drawing.Point(271, 127);
            this.cbxToolLevel.Name = "cbxToolLevel";
            this.cbxToolLevel.Size = new System.Drawing.Size(319, 29);
            this.cbxToolLevel.TabIndex = 4;
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
            this.btnApply.Location = new System.Drawing.Point(254, 656);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(187, 48);
            this.btnApply.TabIndex = 3;
            this.btnApply.Text = "申请零星领料";
            this.btnApply.UseVisualStyleBackColor = false;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // txtWorkTime
            // 
            this.txtWorkTime.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtWorkTime.Location = new System.Drawing.Point(271, 81);
            this.txtWorkTime.Name = "txtWorkTime";
            this.txtWorkTime.Size = new System.Drawing.Size(319, 29);
            this.txtWorkTime.TabIndex = 3;
            // 
            // txtToolName
            // 
            this.txtToolName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtToolName.Location = new System.Drawing.Point(271, 35);
            this.txtToolName.Name = "txtToolName";
            this.txtToolName.Size = new System.Drawing.Size(209, 29);
            this.txtToolName.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(119, 176);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(122, 22);
            this.label8.TabIndex = 2;
            this.label8.Text = "选择加工材质：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(119, 130);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 22);
            this.label6.TabIndex = 2;
            this.label6.Text = "选择刀具等级：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(597, 86);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 22);
            this.label7.TabIndex = 2;
            this.label7.Text = "Min";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(119, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 22);
            this.label5.TabIndex = 2;
            this.label5.Text = "输入加工时间：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(119, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 22);
            this.label2.TabIndex = 2;
            this.label2.Text = "输入刀具名称：";
            // 
            // DisPick_UnPlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 780);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DisPick_UnPlan";
            this.Text = "DisPick_UnPlan";
            this.Load += new System.EventHandler(this.DisPick_UnPlan_Load);
            this.panel2.ResumeLayout(false);
            this.panel_ApproveList.ResumeLayout(false);
            this.panel_ApproveList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ApproveList)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTool)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Panel panel_ApproveList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_ApproveList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.TextBox txtToolName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxToolLevel;
        private System.Windows.Forms.TextBox txtWorkTime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnQueryTool;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvTool;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaterialID;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaterialName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Brand;
        private System.Windows.Forms.DataGridViewTextBoxColumn Spec;
        private System.Windows.Forms.ComboBox cbxTexture;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApproveNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateByName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApplyToolName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApproveState;
        private System.Windows.Forms.DataGridViewTextBoxColumn FK_CabinetNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn BoxNo;
    }
}