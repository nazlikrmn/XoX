namespace XOX
{
    partial class Form1
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnYenidenBasla = new System.Windows.Forms.Button();
            this.lblKazanan = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(310, 307);
            this.panel1.TabIndex = 0;
            // 
            // btnYenidenBasla
            // 
            this.btnYenidenBasla.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnYenidenBasla.Location = new System.Drawing.Point(12, 325);
            this.btnYenidenBasla.Name = "btnYenidenBasla";
            this.btnYenidenBasla.Size = new System.Drawing.Size(76, 36);
            this.btnYenidenBasla.TabIndex = 1;
            this.btnYenidenBasla.Text = "Yeniden Başla";
            this.btnYenidenBasla.UseVisualStyleBackColor = true;
            this.btnYenidenBasla.Click += new System.EventHandler(this.btnYenidenBasla_Click);
            // 
            // lblKazanan
            // 
            this.lblKazanan.AutoSize = true;
            this.lblKazanan.Location = new System.Drawing.Point(220, 337);
            this.lblKazanan.Name = "lblKazanan";
            this.lblKazanan.Size = new System.Drawing.Size(58, 13);
            this.lblKazanan.TabIndex = 0;
            this.lblKazanan.Text = "KAZANAN";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 358);
            this.Controls.Add(this.lblKazanan);
            this.Controls.Add(this.btnYenidenBasla);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "XOX";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnYenidenBasla;
        private System.Windows.Forms.Label lblKazanan;
    }
}

