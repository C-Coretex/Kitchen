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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Back = new System.Windows.Forms.Button();
            this.findText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Find = new System.Windows.Forms.Button();
            this.AddRecept = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.testBox2 = new System.Windows.Forms.TextBox();
            this.form2BindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.form2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colIngridients = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.form2BindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.form2BindingSource)).BeginInit();
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
            this.findText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.findText_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Enabled = false;
            this.label1.Location = new System.Drawing.Point(117, 342);
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
            // AddRecept
            // 
            this.AddRecept.Location = new System.Drawing.Point(0, 319);
            this.AddRecept.Name = "AddRecept";
            this.AddRecept.Size = new System.Drawing.Size(308, 20);
            this.AddRecept.TabIndex = 5;
            this.AddRecept.Text = "Добавить";
            this.AddRecept.UseVisualStyleBackColor = true;
            this.AddRecept.Click += new System.EventHandler(this.AddRecept_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToOrderColumns = true;
            this.dataGridView.BackgroundColor = System.Drawing.Color.LightCyan;
            this.dataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIngridients,
            this.colName,
            this.colDescription});
            this.dataGridView.EnableHeadersVisualStyles = false;
            this.dataGridView.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dataGridView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.ShowEditingIcon = false;
            this.dataGridView.Size = new System.Drawing.Size(308, 297);
            this.dataGridView.TabIndex = 6;
            this.dataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellContentClick);
            // 
            // testBox2
            // 
            this.testBox2.Location = new System.Drawing.Point(0, 303);
            this.testBox2.Name = "testBox2";
            this.testBox2.Size = new System.Drawing.Size(308, 20);
            this.testBox2.TabIndex = 7;
            // 
            // form2BindingSource1
            // 
            this.form2BindingSource1.DataSource = typeof(Kitchen.Form2);
            // 
            // form2BindingSource
            // 
            this.form2BindingSource.DataSource = typeof(Kitchen.Form2);
            // 
            // colIngridients
            // 
            this.colIngridients.HeaderText = "Ингридиенты";
            this.colIngridients.Name = "colIngridients";
            this.colIngridients.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colIngridients.Width = 110;
            // 
            // colName
            // 
            this.colName.HeaderText = "Название";
            this.colName.Name = "colName";
            this.colName.Text = "";
            // 
            // colDescription
            // 
            this.colDescription.HeaderText = "Описание";
            this.colDescription.Name = "colDescription";
            this.colDescription.Text = "";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 359);
            this.Controls.Add(this.testBox2);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.AddRecept);
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.form2BindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.form2BindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Back;
        private System.Windows.Forms.TextBox findText;
        private System.Windows.Forms.Button Find;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button AddRecept;
        private System.Windows.Forms.BindingSource form2BindingSource;
        public System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.TextBox testBox2;
        private System.Windows.Forms.BindingSource form2BindingSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIngridients;
        private System.Windows.Forms.DataGridViewButtonColumn colName;
        private System.Windows.Forms.DataGridViewButtonColumn colDescription;
    }
}