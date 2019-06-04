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
            this.panel_Cells.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_Cells
            // 
            this.panel_Cells.Controls.Add(this.btnCancel);
            this.panel_Cells.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Cells.Location = new System.Drawing.Point(0, 0);
            this.panel_Cells.Name = "panel_Cells";
            this.panel_Cells.Size = new System.Drawing.Size(860, 810);
            this.panel_Cells.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.BackgroundImage = global::SmartShelfUI.Properties.Resources.返回;
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(779, 689);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 115);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // spCom
            // 
            this.spCom.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.spCom_DataReceived);
            // 
            // CellsLocation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 810);
            this.Controls.Add(this.panel_Cells);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CellsLocation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CellsLocation";
            this.Load += new System.EventHandler(this.CellsLocation_Load);
            this.panel_Cells.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_Cells;
        private System.Windows.Forms.Button btnCancel;
        private System.IO.Ports.SerialPort spCom;
    }
}