namespace SmartShelfUI.ChildForm
{
    partial class ComfirmDelayTime
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblPalnWorkPlan = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblNowTime = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDelayTime = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(88, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "原计划开工时间：";
            // 
            // lblPalnWorkPlan
            // 
            this.lblPalnWorkPlan.AutoSize = true;
            this.lblPalnWorkPlan.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPalnWorkPlan.Location = new System.Drawing.Point(283, 33);
            this.lblPalnWorkPlan.Name = "lblPalnWorkPlan";
            this.lblPalnWorkPlan.Size = new System.Drawing.Size(256, 27);
            this.lblPalnWorkPlan.TabIndex = 0;
            this.lblPalnWorkPlan.Text = "2019年12月12日 12:00:00";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(148, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 27);
            this.label3.TabIndex = 0;
            this.label3.Text = "当前时间：";
            // 
            // lblNowTime
            // 
            this.lblNowTime.AutoSize = true;
            this.lblNowTime.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblNowTime.Location = new System.Drawing.Point(283, 84);
            this.lblNowTime.Name = "lblNowTime";
            this.lblNowTime.Size = new System.Drawing.Size(256, 27);
            this.lblNowTime.TabIndex = 0;
            this.lblNowTime.Text = "2019年12月12日 12:00:00";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(108, 157);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(152, 27);
            this.label5.TabIndex = 0;
            this.label5.Text = "输入开工时间：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(283, 157);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 27);
            this.label6.TabIndex = 0;
            this.label6.Text = "开工前";
            // 
            // txtDelayTime
            // 
            this.txtDelayTime.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.txtDelayTime.Location = new System.Drawing.Point(361, 154);
            this.txtDelayTime.Name = "txtDelayTime";
            this.txtDelayTime.Size = new System.Drawing.Size(100, 34);
            this.txtDelayTime.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(467, 157);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 27);
            this.label7.TabIndex = 0;
            this.label7.Text = "分钟";
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOK.Location = new System.Drawing.Point(129, 213);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(131, 49);
            this.btnOK.TabIndex = 11;
            this.btnOK.Text = "确  认";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Location = new System.Drawing.Point(361, 213);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(131, 49);
            this.btnCancel.TabIndex = 111;
            this.btnCancel.Text = "取  消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ComfirmDelayTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 306);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtDelayTime);
            this.Controls.Add(this.lblNowTime);
            this.Controls.Add(this.lblPalnWorkPlan);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ComfirmDelayTime";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "输入推迟时间：";
            this.Load += new System.EventHandler(this.ComfirmDelayTime_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPalnWorkPlan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblNowTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDelayTime;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}