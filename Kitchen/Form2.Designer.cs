namespace Kitchen
{
    partial class Form2
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
            this.Back = new System.Windows.Forms.Button();
            this.findText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Find = new System.Windows.Forms.Button();
            this.testBox2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Back
            // 
            this.Back.Location = new System.Drawing.Point(0, 338);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(116, 21);
            this.Back.TabIndex = 0;
            this.Back.Text = "Сохранить и назад";
            this.Back.UseVisualStyleBackColor = true;
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // findText
            // 
            this.findText.BackColor = System.Drawing.Color.White;
            this.findText.Location = new System.Drawing.Point(114, 338);
            this.findText.Name = "findText";
            this.findText.Size = new System.Drawing.Size(117, 20);
            this.findText.TabIndex = 1;
            this.findText.Click += new System.EventHandler(this.findText_Click);
            this.findText.TextChanged += new System.EventHandler(this.findText_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Enabled = false;
            this.label1.Location = new System.Drawing.Point(116, 342);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Найти по названию";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Find
            // 
            this.Find.Location = new System.Drawing.Point(224, 338);
            this.Find.Name = "Find";
            this.Find.Size = new System.Drawing.Size(84, 21);
            this.Find.TabIndex = 3;
            this.Find.Text = "Искать!";
            this.Find.UseVisualStyleBackColor = true;
            this.Find.Click += new System.EventHandler(this.Find_Click);
            // 
            // testBox2
            // 
            this.testBox2.Location = new System.Drawing.Point(0, 1);
            this.testBox2.Multiline = true;
            this.testBox2.Name = "testBox2";
            this.testBox2.Size = new System.Drawing.Size(308, 338);
            this.testBox2.TabIndex = 4;
            this.testBox2.TextChanged += new System.EventHandler(this.testBox2_TextChanged);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 359);
            this.Controls.Add(this.testBox2);
            this.Controls.Add(this.Find);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.findText);
            this.Controls.Add(this.Back);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximumSize = new System.Drawing.Size(323, 398);
            this.MinimumSize = new System.Drawing.Size(323, 398);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Back;
        private System.Windows.Forms.TextBox findText;
        private System.Windows.Forms.Button Find;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox testBox2;
    }
}