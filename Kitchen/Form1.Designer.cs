namespace Kitchen
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
            this.FindRecepts = new System.Windows.Forms.Button();
            this.BrowseRecepts = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // FindRecepts
            // 
            this.FindRecepts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.FindRecepts.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.FindRecepts.Font = new System.Drawing.Font("Courier New", 12F);
            this.FindRecepts.Location = new System.Drawing.Point(-8, 247);
            this.FindRecepts.Name = "FindRecepts";
            this.FindRecepts.Size = new System.Drawing.Size(317, 73);
            this.FindRecepts.TabIndex = 1;
            this.FindRecepts.Text = "Найти рецепты";
            this.FindRecepts.UseVisualStyleBackColor = false;
            this.FindRecepts.Click += new System.EventHandler(this.FindRecepts_Click);
            // 
            // BrowseRecepts
            // 
            this.BrowseRecepts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BrowseRecepts.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BrowseRecepts.Font = new System.Drawing.Font("Courier New", 12F);
            this.BrowseRecepts.Location = new System.Drawing.Point(-8, 322);
            this.BrowseRecepts.Name = "BrowseRecepts";
            this.BrowseRecepts.Size = new System.Drawing.Size(317, 38);
            this.BrowseRecepts.TabIndex = 2;
            this.BrowseRecepts.Text = "Просмотреть рецепты";
            this.BrowseRecepts.UseVisualStyleBackColor = false;
            this.BrowseRecepts.Click += new System.EventHandler(this.BrowseRecepts_Click);
            // 
            // Form1
            // 
            this.AccessibleDescription = "";
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Indicator;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(307, 359);
            this.Controls.Add(this.BrowseRecepts);
            this.Controls.Add(this.FindRecepts);
            this.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.MinimumSize = new System.Drawing.Size(323, 398);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button BrowseRecepts;
        private System.Windows.Forms.Button FindRecepts;
    }
}

