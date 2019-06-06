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
            this.btnCancel = new System.Windows.Forms.Button();
            this.spCom = new System.IO.Ports.SerialPort(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.lblToolName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblToolBarcode = new System.Windows.Forms.Label();
            this.panel_Cells.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_Cells
            // 
            this.panel_Cells.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_Cells.Controls.Add(this.lblToolBarcode);
            this.panel_Cells.Controls.Add(this.label3);
            this.panel_Cells.Controls.Add(this.lblToolName);
            this.panel_Cells.Controls.Add(this.label1);
            this.panel_Cells.Controls.Add(this.btnCancel);
            this.panel_Cells.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Cells.Location = new System.Drawing.Point(0, 0);
            this.panel_Cells.Name = "panel_Cells";
            this.panel_Cells.Size = new System.Drawing.Size(1000, 810);
            this.panel_Cells.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.BackgroundImage = global::SmartShelfUI.Properties.Resources.返回;
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(912, 682);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 115);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // spCom
            // 
            this.spCom.BaudRate = 115200;
            this.spCom.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.spCom_DataReceived);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(804, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 27);
            this.label1.TabIndex = 1;
            this.label1.Text = "刀具名称：";
            // 
            // lblToolName
            // 
            this.lblToolName.AutoSize = true;
            this.lblToolName.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblToolName.Location = new System.Drawing.Point(804, 45);
            this.lblToolName.Name = "lblToolName";
            this.lblToolName.Size = new System.Drawing.Size(0, 27);
            this.lblToolName.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(804, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 27);
            this.label3.TabIndex = 1;
            this.label3.Text = "刀具编码：";
            // 
            // lblToolBarcode
            // 
            this.lblToolBarcode.AutoSize = true;
            this.lblToolBarcode.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblToolBarcode.Location = new System.Drawing.Point(804, 126);
            this.lblToolBarcode.Name = "lblToolBarcode";
            this.lblToolBarcode.Size = new System.Drawing.Size(0, 27);
            this.lblToolBarcode.TabIndex = 1;
            // 
            // CellsLocation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 810);
            this.Controls.Add(this.panel_Cells);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CellsLocation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CellsLocation";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CellsLocation_FormClosing);
            this.Load += new System.EventHandler(this.CellsLocation_Load);
            this.panel_Cells.ResumeLayout(false);
            this.panel_Cells.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_Cells;
        private System.Windows.Forms.Button btnCancel;
        private System.IO.Ports.SerialPort spCom;
        private System.Windows.Forms.Label lblToolBarcode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblToolName;
        private System.Windows.Forms.Label label1;
    }
}