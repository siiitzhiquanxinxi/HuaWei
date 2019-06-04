namespace SmartShelfUI.ChildForm
{
    partial class Pick
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pick));
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel_shelf = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.btnMenu = new System.Windows.Forms.Button();
            this.btnDone = new System.Windows.Forms.Button();
            this.btnDisPick2 = new System.Windows.Forms.Button();
            this.btnDisPick1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel_CAM = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel_order = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvCamList = new System.Windows.Forms.DataGridView();
            this.PartNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ToolName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WorkTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ToolLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CabinetNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BoxNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3.SuspendLayout();
            this.panel_shelf.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel_CAM.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCamList)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackgroundImage = global::SmartShelfUI.Properties.Resources.半透明_背景;
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.Controls.Add(this.panel_shelf);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Location = new System.Drawing.Point(1382, 13);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(253, 755);
            this.panel3.TabIndex = 3;
            // 
            // panel_shelf
            // 
            this.panel_shelf.AutoScroll = true;
            this.panel_shelf.Controls.Add(this.button1);
            this.panel_shelf.Location = new System.Drawing.Point(18, 85);
            this.panel_shelf.Name = "panel_shelf";
            this.panel_shelf.Size = new System.Drawing.Size(213, 581);
            this.panel_shelf.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::SmartShelfUI.Properties.Resources.圆角矩形_732_拷贝_4;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(8, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(191, 70);
            this.button1.TabIndex = 0;
            this.button1.Text = "打开1号柜20号抽屉";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label13.Location = new System.Drawing.Point(23, 45);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(74, 22);
            this.label13.TabIndex = 0;
            this.label13.Text = "抽屉列表";
            // 
            // btnMenu
            // 
            this.btnMenu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMenu.BackgroundImage")));
            this.btnMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMenu.FlatAppearance.BorderSize = 0;
            this.btnMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenu.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnMenu.ForeColor = System.Drawing.Color.White;
            this.btnMenu.Location = new System.Drawing.Point(1650, 533);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(258, 103);
            this.btnMenu.TabIndex = 2;
            this.btnMenu.Text = "功能菜单";
            this.btnMenu.UseVisualStyleBackColor = true;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // btnDone
            // 
            this.btnDone.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDone.BackgroundImage")));
            this.btnDone.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDone.FlatAppearance.BorderSize = 0;
            this.btnDone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDone.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDone.ForeColor = System.Drawing.Color.White;
            this.btnDone.Location = new System.Drawing.Point(1650, 665);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(258, 103);
            this.btnDone.TabIndex = 2;
            this.btnDone.Text = "领用完成，退出";
            this.btnDone.UseVisualStyleBackColor = true;
            // 
            // btnDisPick2
            // 
            this.btnDisPick2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDisPick2.BackgroundImage")));
            this.btnDisPick2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDisPick2.FlatAppearance.BorderSize = 0;
            this.btnDisPick2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDisPick2.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDisPick2.ForeColor = System.Drawing.Color.White;
            this.btnDisPick2.Location = new System.Drawing.Point(1649, 140);
            this.btnDisPick2.Name = "btnDisPick2";
            this.btnDisPick2.Size = new System.Drawing.Size(258, 103);
            this.btnDisPick2.TabIndex = 2;
            this.btnDisPick2.Text = "零星领用（非任务令）刀具";
            this.btnDisPick2.UseVisualStyleBackColor = true;
            // 
            // btnDisPick1
            // 
            this.btnDisPick1.BackgroundImage = global::SmartShelfUI.Properties.Resources.圆角矩形_732_拷贝_3;
            this.btnDisPick1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDisPick1.FlatAppearance.BorderSize = 0;
            this.btnDisPick1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDisPick1.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDisPick1.ForeColor = System.Drawing.Color.White;
            this.btnDisPick1.Location = new System.Drawing.Point(1650, 13);
            this.btnDisPick1.Name = "btnDisPick1";
            this.btnDisPick1.Size = new System.Drawing.Size(258, 103);
            this.btnDisPick1.TabIndex = 2;
            this.btnDisPick1.Text = "零星领用（任务令）刀具";
            this.btnDisPick1.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::SmartShelfUI.Properties.Resources.半透明_背景;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.panel_CAM);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Location = new System.Drawing.Point(713, 13);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(651, 755);
            this.panel2.TabIndex = 1;
            // 
            // panel_CAM
            // 
            this.panel_CAM.AutoScroll = true;
            this.panel_CAM.Controls.Add(this.dgvCamList);
            this.panel_CAM.Location = new System.Drawing.Point(41, 85);
            this.panel_CAM.Name = "panel_CAM";
            this.panel_CAM.Size = new System.Drawing.Size(570, 581);
            this.panel_CAM.TabIndex = 2;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label12.Location = new System.Drawing.Point(48, 45);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(58, 22);
            this.label12.TabIndex = 0;
            this.label12.Text = "零件号";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label7.Location = new System.Drawing.Point(132, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 22);
            this.label7.TabIndex = 0;
            this.label7.Text = "刀具名称";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label8.Location = new System.Drawing.Point(316, 45);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 22);
            this.label8.TabIndex = 0;
            this.label8.Text = "加工时间";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label11.Location = new System.Drawing.Point(496, 45);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(90, 22);
            this.label11.TabIndex = 0;
            this.label11.Text = "所在抽题号";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label10.Location = new System.Drawing.Point(405, 45);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 22);
            this.label10.TabIndex = 0;
            this.label10.Text = "刀具等级";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label9.Location = new System.Drawing.Point(222, 45);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 22);
            this.label9.TabIndex = 0;
            this.label9.Text = "刀具编号";
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::SmartShelfUI.Properties.Resources.半透明_背景;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.panel_order);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(674, 755);
            this.panel1.TabIndex = 0;
            // 
            // panel_order
            // 
            this.panel_order.AutoScroll = true;
            this.panel_order.Location = new System.Drawing.Point(56, 85);
            this.panel_order.Name = "panel_order";
            this.panel_order.Size = new System.Drawing.Size(556, 581);
            this.panel_order.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label6.Location = new System.Drawing.Point(532, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 22);
            this.label6.TabIndex = 0;
            this.label6.Text = "状态";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label5.Location = new System.Drawing.Point(459, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 22);
            this.label5.TabIndex = 0;
            this.label5.Text = "机台";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label4.Location = new System.Drawing.Point(325, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 22);
            this.label4.TabIndex = 0;
            this.label4.Text = "计划开工时间";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label3.Location = new System.Drawing.Point(260, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 22);
            this.label3.TabIndex = 0;
            this.label3.Text = "材质";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label2.Location = new System.Drawing.Point(152, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 22);
            this.label2.TabIndex = 0;
            this.label2.Text = "零件名称";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label1.Location = new System.Drawing.Point(62, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "零件号";
            // 
            // dgvCamList
            // 
            this.dgvCamList.AllowUserToAddRows = false;
            this.dgvCamList.AllowUserToDeleteRows = false;
            this.dgvCamList.ColumnHeadersHeight = 40;
            this.dgvCamList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PartNum,
            this.ToolName,
            this.WorkTime,
            this.ToolLevel,
            this.CabinetNo,
            this.BoxNo});
            this.dgvCamList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCamList.Location = new System.Drawing.Point(0, 0);
            this.dgvCamList.Name = "dgvCamList";
            this.dgvCamList.ReadOnly = true;
            this.dgvCamList.RowTemplate.Height = 40;
            this.dgvCamList.Size = new System.Drawing.Size(570, 581);
            this.dgvCamList.TabIndex = 0;
            // 
            // PartNum
            // 
            this.PartNum.HeaderText = "零件号";
            this.PartNum.Name = "PartNum";
            this.PartNum.ReadOnly = true;
            // 
            // ToolName
            // 
            this.ToolName.HeaderText = "道具名称";
            this.ToolName.Name = "ToolName";
            this.ToolName.ReadOnly = true;
            // 
            // WorkTime
            // 
            this.WorkTime.HeaderText = "加工时间";
            this.WorkTime.Name = "WorkTime";
            this.WorkTime.ReadOnly = true;
            this.WorkTime.Width = 80;
            // 
            // ToolLevel
            // 
            this.ToolLevel.HeaderText = "刀具等级";
            this.ToolLevel.Name = "ToolLevel";
            this.ToolLevel.ReadOnly = true;
            // 
            // CabinetNo
            // 
            this.CabinetNo.HeaderText = "柜号";
            this.CabinetNo.Name = "CabinetNo";
            this.CabinetNo.ReadOnly = true;
            this.CabinetNo.Width = 60;
            // 
            // BoxNo
            // 
            this.BoxNo.HeaderText = "抽屉号";
            this.BoxNo.Name = "BoxNo";
            this.BoxNo.ReadOnly = true;
            this.BoxNo.Width = 70;
            // 
            // Pick
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 780);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.btnMenu);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.btnDisPick2);
            this.Controls.Add(this.btnDisPick1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Pick";
            this.Text = "Pick";
            this.Load += new System.EventHandler(this.Pick_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel_shelf.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel_CAM.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCamList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel_order;
        private System.Windows.Forms.Panel panel_CAM;
        private System.Windows.Forms.Button btnDisPick1;
        private System.Windows.Forms.Button btnDisPick2;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.Button btnMenu;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel_shelf;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgvCamList;
        private System.Windows.Forms.DataGridViewTextBoxColumn PartNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn ToolName;
        private System.Windows.Forms.DataGridViewTextBoxColumn WorkTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ToolLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn CabinetNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn BoxNo;
    }
}