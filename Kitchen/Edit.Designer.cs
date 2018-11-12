namespace Kitchen
{
    partial class Edit
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
            this.description = new System.Windows.Forms.TextBox();
            this.ingridients = new System.Windows.Forms.TextBox();
            this.name = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.saveDelete = new System.Windows.Forms.Button();
            this.delete = new System.Windows.Forms.Button();
            this.exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // description
            // 
            this.description.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.description.Font = new System.Drawing.Font("Courier New", 12F);
            this.description.Location = new System.Drawing.Point(291, 84);
            this.description.Multiline = true;
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(312, 229);
            this.description.TabIndex = 11;
            this.description.TextChanged += new System.EventHandler(this.description_TextChanged);
            // 
            // ingridients
            // 
            this.ingridients.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ingridients.Font = new System.Drawing.Font("Courier New", 12F);
            this.ingridients.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ingridients.Location = new System.Drawing.Point(3, 129);
            this.ingridients.Multiline = true;
            this.ingridients.Name = "ingridients";
            this.ingridients.Size = new System.Drawing.Size(282, 184);
            this.ingridients.TabIndex = 10;
            this.ingridients.TextChanged += new System.EventHandler(this.ingridients_TextChanged);
            // 
            // name
            // 
            this.name.Font = new System.Drawing.Font("Courier New", 12F);
            this.name.Location = new System.Drawing.Point(3, 83);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(282, 26);
            this.name.TabIndex = 9;
            this.name.TextChanged += new System.EventHandler(this.name_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.Location = new System.Drawing.Point(287, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(263, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Описание рецепта (как готовить)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label5.Location = new System.Drawing.Point(-1, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "Ингридиенты";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label6.Location = new System.Drawing.Point(-1, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(150, 20);
            this.label6.TabIndex = 6;
            this.label6.Text = "Название рецепта";
            // 
            // saveDelete
            // 
            this.saveDelete.Location = new System.Drawing.Point(3, 2);
            this.saveDelete.Name = "saveDelete";
            this.saveDelete.Size = new System.Drawing.Size(196, 59);
            this.saveDelete.TabIndex = 12;
            this.saveDelete.Text = "Сохранить и выйти";
            this.saveDelete.UseVisualStyleBackColor = true;
            this.saveDelete.Click += new System.EventHandler(this.saveDelete_Click);
            // 
            // delete
            // 
            this.delete.Location = new System.Drawing.Point(205, 2);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(194, 59);
            this.delete.TabIndex = 13;
            this.delete.Text = "Удалить";
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // exit
            // 
            this.exit.Location = new System.Drawing.Point(405, 2);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(202, 59);
            this.exit.TabIndex = 14;
            this.exit.Text = "Выйти не сохранив";
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 319);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.saveDelete);
            this.Controls.Add(this.description);
            this.Controls.Add(this.ingridients);
            this.Controls.Add(this.name);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Name = "Edit";
            this.Text = "Edit";
            this.Load += new System.EventHandler(this.Edit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox description;
        private System.Windows.Forms.TextBox ingridients;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button saveDelete;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.Button exit;
    }
}