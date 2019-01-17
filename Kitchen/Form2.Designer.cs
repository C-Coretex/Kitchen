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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Back = new System.Windows.Forms.Button();
            this.findText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Find = new System.Windows.Forms.Button();
            this.AddRecept = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.colNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIngridients = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // Back
            // 
            this.Back.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Back.Location = new System.Drawing.Point(0, 338);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(116, 21);
            this.Back.TabIndex = 0;
            this.Back.Text = "Назад";
            this.Back.UseVisualStyleBackColor = true;
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // findText
            // 
            this.findText.AcceptsReturn = true;
            this.findText.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.findText.BackColor = System.Drawing.Color.White;
            this.findText.Location = new System.Drawing.Point(122, 338);
            this.findText.Name = "findText";
            this.findText.Size = new System.Drawing.Size(210, 20);
            this.findText.TabIndex = 1;
            this.findText.Click += new System.EventHandler(this.FindText_Click);
            this.findText.TextChanged += new System.EventHandler(this.FindText_TextChanged);
            this.findText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FindText_KeyDown);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Enabled = false;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(142, 339);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Найти по названию";
            this.label1.UseMnemonic = false;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Find
            // 
            this.Find.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Find.Location = new System.Drawing.Point(330, 338);
            this.Find.Name = "Find";
            this.Find.Size = new System.Drawing.Size(84, 21);
            this.Find.TabIndex = 3;
            this.Find.Text = "Искать!";
            this.Find.UseVisualStyleBackColor = true;
            this.Find.Click += new System.EventHandler(this.Find_Click);
            // 
            // AddRecept
            // 
            this.AddRecept.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.AddRecept.Location = new System.Drawing.Point(0, 319);
            this.AddRecept.Name = "AddRecept";
            this.AddRecept.Size = new System.Drawing.Size(414, 20);
            this.AddRecept.TabIndex = 5;
            this.AddRecept.Text = "Добавить";
            this.AddRecept.UseVisualStyleBackColor = true;
            this.AddRecept.Click += new System.EventHandler(this.AddRecept_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeColumns = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.colNumber,
            this.colName,
            this.colIngridients});
            this.dataGridView.EnableHeadersVisualStyles = false;
            this.dataGridView.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dataGridView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView.MinimumSize = new System.Drawing.Size(414, 319);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.ShowEditingIcon = false;
            this.dataGridView.Size = new System.Drawing.Size(414, 319);
            this.dataGridView.TabIndex = 6;
            this.dataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellDoubleClick);
            this.dataGridView.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_CellMouseClick);
            // 
            // colNumber
            // 
            this.colNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.colNumber.FillWeight = 20F;
            this.colNumber.HeaderText = "№";
            this.colNumber.Name = "colNumber";
            this.colNumber.ReadOnly = true;
            this.colNumber.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colNumber.Width = 5;
            // 
            // colName
            // 
            this.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.colName.DefaultCellStyle = dataGridViewCellStyle2;
            this.colName.HeaderText = "Название";
            this.colName.MaxInputLength = 0;
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colName.Width = 81;
            // 
            // colIngridients
            // 
            this.colIngridients.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colIngridients.HeaderText = "Ингридиенты";
            this.colIngridients.MaxInputLength = 0;
            this.colIngridients.Name = "colIngridients";
            this.colIngridients.ReadOnly = true;
            this.colIngridients.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 359);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.AddRecept);
            this.Controls.Add(this.Find);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.findText);
            this.Controls.Add(this.Back);
            this.MinimumSize = new System.Drawing.Size(369, 398);
            this.Name = "Form2";
            this.ShowIcon = false;
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Back;
        private System.Windows.Forms.TextBox findText;
        private System.Windows.Forms.Button Find;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button AddRecept;
        public System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIngridients;
    }
}