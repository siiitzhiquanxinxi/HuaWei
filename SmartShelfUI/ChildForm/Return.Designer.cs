namespace SmartShelfUI.ChildForm
{
    partial class Return
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblToolName = new System.Windows.Forms.Label();
            this.lblToolLevel = new System.Windows.Forms.Label();
            this.lblRestWorkTime = new System.Windows.Forms.Label();
            this.lblCabinetNo = new System.Windows.Forms.Label();
            this.lblShelfNo = new System.Windows.Forms.Label();
            this.lblLastPickMan = new System.Windows.Forms.Label();
            this.lblLastPickTime = new System.Windows.Forms.Label();
            this.lblLastPickType = new System.Windows.Forms.Label();
            this.lblLastPickPartNum = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnBaofei = new System.Windows.Forms.Button();
            this.btnXiumo = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            this.pbxToolPic = new System.Windows.Forms.PictureBox();
            this.btnBack = new System.Windows.Forms.PictureBox();
            this.spCom = new System.IO.Ports.SerialPort(this.components);
            this.panel_Cells = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.lblToolState = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxToolPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBack)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(78, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(278, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "请扫描刀具编码还刀";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblLastPickPartNum);
            this.groupBox1.Controls.Add(this.lblLastPickType);
            this.groupBox1.Controls.Add(this.lblLastPickTime);
            this.groupBox1.Controls.Add(this.lblLastPickMan);
            this.groupBox1.Controls.Add(this.lblToolState);
            this.groupBox1.Controls.Add(this.lblShelfNo);
            this.groupBox1.Controls.Add(this.lblCabinetNo);
            this.groupBox1.Controls.Add(this.lblRestWorkTime);
            this.groupBox1.Controls.Add(this.lblToolLevel);
            this.groupBox1.Controls.Add(this.lblToolName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(40, 77);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(527, 674);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "刀具信息";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(60, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "刀具名称：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(60, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 21);
            this.label3.TabIndex = 0;
            this.label3.Text = "刀具等级：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(28, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 21);
            this.label4.TabIndex = 0;
            this.label4.Text = "剩余加工时间：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(60, 199);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 21);
            this.label5.TabIndex = 0;
            this.label5.Text = "所属柜号：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(44, 251);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 21);
            this.label6.TabIndex = 0;
            this.label6.Text = "所属抽屉号：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(44, 355);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 21);
            this.label7.TabIndex = 0;
            this.label7.Text = "最后领用人：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(28, 407);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(122, 21);
            this.label8.TabIndex = 0;
            this.label8.Text = "最后领用时间：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(60, 459);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 21);
            this.label9.TabIndex = 0;
            this.label9.Text = "领用类别：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(12, 511);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(138, 21);
            this.label10.TabIndex = 0;
            this.label10.Text = "领用所属零件号：";
            // 
            // lblToolName
            // 
            this.lblToolName.AutoSize = true;
            this.lblToolName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblToolName.Location = new System.Drawing.Point(156, 43);
            this.lblToolName.Name = "lblToolName";
            this.lblToolName.Size = new System.Drawing.Size(24, 21);
            this.lblToolName.TabIndex = 0;
            this.lblToolName.Text = "--";
            // 
            // lblToolLevel
            // 
            this.lblToolLevel.AutoSize = true;
            this.lblToolLevel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblToolLevel.Location = new System.Drawing.Point(156, 95);
            this.lblToolLevel.Name = "lblToolLevel";
            this.lblToolLevel.Size = new System.Drawing.Size(24, 21);
            this.lblToolLevel.TabIndex = 0;
            this.lblToolLevel.Text = "--";
            // 
            // lblRestWorkTime
            // 
            this.lblRestWorkTime.AutoSize = true;
            this.lblRestWorkTime.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRestWorkTime.Location = new System.Drawing.Point(156, 147);
            this.lblRestWorkTime.Name = "lblRestWorkTime";
            this.lblRestWorkTime.Size = new System.Drawing.Size(24, 21);
            this.lblRestWorkTime.TabIndex = 0;
            this.lblRestWorkTime.Text = "--";
            // 
            // lblCabinetNo
            // 
            this.lblCabinetNo.AutoSize = true;
            this.lblCabinetNo.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCabinetNo.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblCabinetNo.Location = new System.Drawing.Point(156, 199);
            this.lblCabinetNo.Name = "lblCabinetNo";
            this.lblCabinetNo.Size = new System.Drawing.Size(24, 22);
            this.lblCabinetNo.TabIndex = 0;
            this.lblCabinetNo.Text = "--";
            // 
            // lblShelfNo
            // 
            this.lblShelfNo.AutoSize = true;
            this.lblShelfNo.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblShelfNo.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblShelfNo.Location = new System.Drawing.Point(156, 251);
            this.lblShelfNo.Name = "lblShelfNo";
            this.lblShelfNo.Size = new System.Drawing.Size(24, 22);
            this.lblShelfNo.TabIndex = 0;
            this.lblShelfNo.Text = "--";
            // 
            // lblLastPickMan
            // 
            this.lblLastPickMan.AutoSize = true;
            this.lblLastPickMan.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblLastPickMan.Location = new System.Drawing.Point(156, 355);
            this.lblLastPickMan.Name = "lblLastPickMan";
            this.lblLastPickMan.Size = new System.Drawing.Size(24, 21);
            this.lblLastPickMan.TabIndex = 0;
            this.lblLastPickMan.Text = "--";
            // 
            // lblLastPickTime
            // 
            this.lblLastPickTime.AutoSize = true;
            this.lblLastPickTime.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblLastPickTime.Location = new System.Drawing.Point(156, 407);
            this.lblLastPickTime.Name = "lblLastPickTime";
            this.lblLastPickTime.Size = new System.Drawing.Size(24, 21);
            this.lblLastPickTime.TabIndex = 0;
            this.lblLastPickTime.Text = "--";
            // 
            // lblLastPickType
            // 
            this.lblLastPickType.AutoSize = true;
            this.lblLastPickType.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblLastPickType.Location = new System.Drawing.Point(156, 459);
            this.lblLastPickType.Name = "lblLastPickType";
            this.lblLastPickType.Size = new System.Drawing.Size(24, 21);
            this.lblLastPickType.TabIndex = 0;
            this.lblLastPickType.Text = "--";
            // 
            // lblLastPickPartNum
            // 
            this.lblLastPickPartNum.AutoSize = true;
            this.lblLastPickPartNum.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblLastPickPartNum.Location = new System.Drawing.Point(156, 511);
            this.lblLastPickPartNum.Name = "lblLastPickPartNum";
            this.lblLastPickPartNum.Size = new System.Drawing.Size(24, 21);
            this.lblLastPickPartNum.TabIndex = 0;
            this.lblLastPickPartNum.Text = "--";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel_Cells);
            this.groupBox2.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(590, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(598, 739);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "刀具位置";
            // 
            // btnBaofei
            // 
            this.btnBaofei.BackgroundImage = global::SmartShelfUI.Properties.Resources.圆角矩形_732_拷贝_3;
            this.btnBaofei.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBaofei.FlatAppearance.BorderSize = 0;
            this.btnBaofei.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBaofei.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnBaofei.ForeColor = System.Drawing.Color.Transparent;
            this.btnBaofei.Location = new System.Drawing.Point(1220, 668);
            this.btnBaofei.Name = "btnBaofei";
            this.btnBaofei.Size = new System.Drawing.Size(120, 65);
            this.btnBaofei.TabIndex = 3;
            this.btnBaofei.Text = "报 废";
            this.btnBaofei.UseVisualStyleBackColor = true;
            this.btnBaofei.Click += new System.EventHandler(this.btnBaofei_Click);
            // 
            // btnXiumo
            // 
            this.btnXiumo.BackgroundImage = global::SmartShelfUI.Properties.Resources.圆角矩形_732_拷贝_5;
            this.btnXiumo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnXiumo.FlatAppearance.BorderSize = 0;
            this.btnXiumo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXiumo.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnXiumo.ForeColor = System.Drawing.Color.Transparent;
            this.btnXiumo.Location = new System.Drawing.Point(1450, 668);
            this.btnXiumo.Name = "btnXiumo";
            this.btnXiumo.Size = new System.Drawing.Size(120, 60);
            this.btnXiumo.TabIndex = 3;
            this.btnXiumo.Text = "修 磨";
            this.btnXiumo.UseVisualStyleBackColor = true;
            this.btnXiumo.Click += new System.EventHandler(this.btnXiumo_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.BackgroundImage = global::SmartShelfUI.Properties.Resources.圆角矩形_732_拷贝_4;
            this.btnReturn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReturn.FlatAppearance.BorderSize = 0;
            this.btnReturn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReturn.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnReturn.ForeColor = System.Drawing.Color.Transparent;
            this.btnReturn.Location = new System.Drawing.Point(1250, 77);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(281, 105);
            this.btnReturn.TabIndex = 3;
            this.btnReturn.Text = "归 还";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // pbxToolPic
            // 
            this.pbxToolPic.Location = new System.Drawing.Point(1220, 224);
            this.pbxToolPic.Name = "pbxToolPic";
            this.pbxToolPic.Size = new System.Drawing.Size(350, 400);
            this.pbxToolPic.TabIndex = 1;
            this.pbxToolPic.TabStop = false;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Transparent;
            this.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBack.Image = global::SmartShelfUI.Properties.Resources.返回;
            this.btnBack.Location = new System.Drawing.Point(1835, 662);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(73, 106);
            this.btnBack.TabIndex = 41;
            this.btnBack.TabStop = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // spCom
            // 
            this.spCom.BaudRate = 115200;
            this.spCom.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.spCom_DataReceived);
            // 
            // panel_Cells
            // 
            this.panel_Cells.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Cells.Location = new System.Drawing.Point(3, 30);
            this.panel_Cells.Name = "panel_Cells";
            this.panel_Cells.Size = new System.Drawing.Size(592, 706);
            this.panel_Cells.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label11.Location = new System.Drawing.Point(60, 303);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(90, 21);
            this.label11.TabIndex = 1;
            this.label11.Text = "物料状态：";
            // 
            // lblToolState
            // 
            this.lblToolState.AutoSize = true;
            this.lblToolState.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblToolState.Location = new System.Drawing.Point(156, 303);
            this.lblToolState.Name = "lblToolState";
            this.lblToolState.Size = new System.Drawing.Size(24, 21);
            this.lblToolState.TabIndex = 0;
            this.lblToolState.Text = "--";
            // 
            // Return
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 780);
            this.Controls.Add(this.pbxToolPic);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnBaofei);
            this.Controls.Add(this.btnXiumo);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Return";
            this.Text = "Return";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Return_FormClosing);
            this.Load += new System.EventHandler(this.Return_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxToolPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBack)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pbxToolPic;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblLastPickPartNum;
        private System.Windows.Forms.Label lblLastPickType;
        private System.Windows.Forms.Label lblLastPickTime;
        private System.Windows.Forms.Label lblLastPickMan;
        private System.Windows.Forms.Label lblShelfNo;
        private System.Windows.Forms.Label lblCabinetNo;
        private System.Windows.Forms.Label lblRestWorkTime;
        private System.Windows.Forms.Label lblToolLevel;
        private System.Windows.Forms.Label lblToolName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Button btnXiumo;
        private System.Windows.Forms.Button btnBaofei;
        private System.Windows.Forms.PictureBox btnBack;
        private System.IO.Ports.SerialPort spCom;
        private System.Windows.Forms.Panel panel_Cells;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblToolState;
    }
}