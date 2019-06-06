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
            this.SuspendLayout();
            // 
            // spCom
            // 
            this.spCom.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.spCom_DataReceived);
            // 
            // Warehousing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 780);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Warehousing";
            this.Text = "Warehousing";
            this.Load += new System.EventHandler(this.Warehousing_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.IO.Ports.SerialPort spCom;
    }
}