﻿namespace Kitchen
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
            this.NAMES = new System.Windows.Forms.TextBox();
            this.FindRecepts = new System.Windows.Forms.Button();
            this.BrowseRecepts = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // NAMES
            // 
            this.NAMES.BackColor = System.Drawing.Color.LightCyan;
            this.NAMES.Font = new System.Drawing.Font("Calibri", 12F);
            this.NAMES.Location = new System.Drawing.Point(-8, -22);
            this.NAMES.Multiline = true;
            this.NAMES.Name = "NAMES";
            this.NAMES.Size = new System.Drawing.Size(317, 275);
            this.NAMES.TabIndex = 0;
            this.NAMES.TextChanged += new System.EventHandler(this.NAMES_TextChanged);
            this.NAMES.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NAMES_KeyDown);
            // 
            // FindRecepts
            // 
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.LightCyan;
            this.label1.Font = new System.Drawing.Font("Calibri", 10F);
            this.label1.Location = new System.Drawing.Point(6, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Впишите ингридиенты...";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Form1
            // 
            this.AccessibleDescription = "";
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Indicator;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(307, 359);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BrowseRecepts);
            this.Controls.Add(this.FindRecepts);
            this.Controls.Add(this.NAMES);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximumSize = new System.Drawing.Size(323, 398);
            this.MinimumSize = new System.Drawing.Size(323, 398);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox NAMES;
        private System.Windows.Forms.Button FindRecepts;
        private System.Windows.Forms.Button BrowseRecepts;
        private System.Windows.Forms.Label label1;
    }
}
