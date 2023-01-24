namespace EntityFrameworkQueries
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSelectAllVendors = new System.Windows.Forms.Button();
            this.btnSelectAllVendorsInCA = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSelectAllVendors
            // 
            this.btnSelectAllVendors.Location = new System.Drawing.Point(79, 37);
            this.btnSelectAllVendors.Name = "btnSelectAllVendors";
            this.btnSelectAllVendors.Size = new System.Drawing.Size(183, 45);
            this.btnSelectAllVendors.TabIndex = 0;
            this.btnSelectAllVendors.Text = "SELECT * \r\nFROM Vendors";
            this.btnSelectAllVendors.UseVisualStyleBackColor = true;
            this.btnSelectAllVendors.Click += new System.EventHandler(this.BtnSelectAllVendors_Click);
            // 
            // btnSelectAllVendorsInCA
            // 
            this.btnSelectAllVendorsInCA.Location = new System.Drawing.Point(79, 88);
            this.btnSelectAllVendorsInCA.Name = "btnSelectAllVendorsInCA";
            this.btnSelectAllVendorsInCA.Size = new System.Drawing.Size(183, 87);
            this.btnSelectAllVendorsInCA.TabIndex = 1;
            this.btnSelectAllVendorsInCA.Text = "SELECT * \r\nFROM Vendors\r\nWHERE VendorState = \'CA\'\r\nORDER BY VendorName ASC";
            this.btnSelectAllVendorsInCA.UseVisualStyleBackColor = true;
            this.btnSelectAllVendorsInCA.Click += new System.EventHandler(this.BtnSelectAllVendorsInCA_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 342);
            this.Controls.Add(this.btnSelectAllVendorsInCA);
            this.Controls.Add(this.btnSelectAllVendors);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnSelectAllVendors;
        private Button btnSelectAllVendorsInCA;
    }
}