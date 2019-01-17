namespace Kitchen
{
    partial class AddName2
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
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.сщгте = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.saveExit = new System.Windows.Forms.Button();
            this.ddescription = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(352, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(231, 68);
            this.button2.TabIndex = 21;
            this.button2.Text = "Удалить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(180, 181);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Номер инструкции";
            // 
            // сщгте
            // 
            this.сщгте.Location = new System.Drawing.Point(217, 197);
            this.сщгте.Name = "сщгте";
            this.сщгте.Size = new System.Drawing.Size(65, 20);
            this.сщгте.TabIndex = 19;
            this.сщгте.TextChanged += new System.EventHandler(this.сщгте_TextChanged);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(83, 129);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(199, 43);
            this.button1.TabIndex = 14;
            this.button1.Text = "Добавить следующую инструкцию";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // saveExit
            // 
            this.saveExit.Location = new System.Drawing.Point(3, 3);
            this.saveExit.Name = "saveExit";
            this.saveExit.Size = new System.Drawing.Size(343, 68);
            this.saveExit.TabIndex = 18;
            this.saveExit.Text = "Сохранить и выйти";
            this.saveExit.UseVisualStyleBackColor = true;
            this.saveExit.Click += new System.EventHandler(this.saveExit_Click);
            // 
            // ddescription
            // 
            this.ddescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ddescription.Font = new System.Drawing.Font("Courier New", 12F);
            this.ddescription.Location = new System.Drawing.Point(288, 97);
            this.ddescription.Multiline = true;
            this.ddescription.Name = "ddescription";
            this.ddescription.Size = new System.Drawing.Size(295, 129);
            this.ddescription.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(284, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 20);
            this.label3.TabIndex = 17;
            this.label3.Text = "А как его готовить";
            // 
            // nname
            // 
            this.nname.Font = new System.Drawing.Font("Courier New", 12F);
            this.nname.Location = new System.Drawing.Point(5, 97);
            this.nname.Name = "nname";
            this.nname.Size = new System.Drawing.Size(277, 26);
            this.nname.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(1, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 20);
            this.label1.TabIndex = 16;
            this.label1.Text = "Название рецепта";
            // 
            // AddName2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 228);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.сщгте);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.saveExit);
            this.Controls.Add(this.ddescription);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nname);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(600, 267);
            this.Name = "AddName2";
            this.Text = "AddName2";
            this.Shown += new System.EventHandler(this.AddName2_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox сщгте;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button saveExit;
        private System.Windows.Forms.TextBox ddescription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox nname;
        private System.Windows.Forms.Label label1;
    }
}