namespace Kitchen
{
    partial class Form3
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.TextBox();
            this.ingridients = new System.Windows.Forms.TextBox();
            this.description = new System.Windows.Forms.TextBox();
            this.saveExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(-2, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Название рецепта";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(-2, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ингридиенты";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(276, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(263, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Описание рецепта (как готовить)";
            // 
            // name
            // 
            this.name.Font = new System.Drawing.Font("Courier New", 12F);
            this.name.Location = new System.Drawing.Point(2, 93);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(272, 26);
            this.name.TabIndex = 3;
            this.name.TextChanged += new System.EventHandler(this.name_TextChanged);
            // 
            // ingridients
            // 
            this.ingridients.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ingridients.Font = new System.Drawing.Font("Courier New", 12F);
            this.ingridients.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ingridients.Location = new System.Drawing.Point(2, 139);
            this.ingridients.Multiline = true;
            this.ingridients.Name = "ingridients";
            this.ingridients.Size = new System.Drawing.Size(272, 187);
            this.ingridients.TabIndex = 4;
            this.ingridients.TextChanged += new System.EventHandler(this.ingridients_TextChanged);
            // 
            // description
            // 
            this.description.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.description.Font = new System.Drawing.Font("Courier New", 12F);
            this.description.Location = new System.Drawing.Point(280, 94);
            this.description.Multiline = true;
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(292, 232);
            this.description.TabIndex = 5;
            this.description.TextChanged += new System.EventHandler(this.description_TextChanged);
            // 
            // saveExit
            // 
            this.saveExit.Location = new System.Drawing.Point(2, 0);
            this.saveExit.Name = "saveExit";
            this.saveExit.Size = new System.Drawing.Size(272, 67);
            this.saveExit.TabIndex = 6;
            this.saveExit.Text = "Сохранить и выйти";
            this.saveExit.UseVisualStyleBackColor = true;
            this.saveExit.Click += new System.EventHandler(this.saveExit_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 332);
            this.Controls.Add(this.saveExit);
            this.Controls.Add(this.description);
            this.Controls.Add(this.ingridients);
            this.Controls.Add(this.name);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(596, 371);
            this.Name = "Form3";
            this.Text = "Form3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.TextBox ingridients;
        private System.Windows.Forms.TextBox description;
        private System.Windows.Forms.Button saveExit;
    }
}