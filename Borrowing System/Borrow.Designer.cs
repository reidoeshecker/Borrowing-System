namespace Borrowing_System
{
    partial class Borrow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Borrow));
            this.label10 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customButton2 = new Borrowing_System.CustomButton();
            this.roundedPanel1 = new Borrowing_System.RoundedPanel.RoundedPanel();
            this.label8 = new System.Windows.Forms.Label();
            this.smallTextBox3 = new ReaLTaiizor.Controls.SmallTextBox();
            this.maskedTextBox2 = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.customButton1 = new Borrowing_System.CustomButton();
            this.poisonDateTime1 = new ReaLTaiizor.Controls.PoisonDateTime();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.smallTextBox2 = new ReaLTaiizor.Controls.SmallTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.smallTextBox1 = new ReaLTaiizor.Controls.SmallTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.aloneComboBox1 = new ReaLTaiizor.Controls.AloneComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.roundedPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("VAG Rounded Next", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(127)))), ((int)(((byte)(51)))));
            this.label10.Location = new System.Drawing.Point(16, 12);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(104, 37);
            this.label10.TabIndex = 16;
            this.label10.Text = "Borrow";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.ForestGreen;
            this.panel1.Location = new System.Drawing.Point(123, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(686, 1);
            this.panel1.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("VAG Rounded Next", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.label1.Location = new System.Drawing.Point(27, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 29);
            this.label1.TabIndex = 19;
            this.label1.Text = "Borrower Information";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column8,
            this.Column9,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.ForestGreen;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Location = new System.Drawing.Point(16, 194);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(796, 269);
            this.dataGridView1.TabIndex = 20;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column1.HeaderText = "#";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 39;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column2.HeaderText = "Student/Faculty ID";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 112;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column3.HeaderText = "Full Name";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 73;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Program & Section";
            this.Column8.MinimumWidth = 6;
            this.Column8.Name = "Column8";
            this.Column8.Width = 125;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Contact No.";
            this.Column9.MinimumWidth = 6;
            this.Column9.Name = "Column9";
            this.Column9.Width = 125;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column4.HeaderText = "Book Title";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 74;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column5.HeaderText = "Date Borrowed ";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 97;
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column6.HeaderText = "Due Date";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 72;
            // 
            // Column7
            // 
            this.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column7.HeaderText = "Amount Paid";
            this.Column7.MinimumWidth = 6;
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 85;
            // 
            // customButton2
            // 
            this.customButton2.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.customButton2.BorderRadius = 15;
            this.customButton2.ButtonBorderSize = 2;
            this.customButton2.FlatAppearance.BorderSize = 0;
            this.customButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.customButton2.Font = new System.Drawing.Font("Segoe UI Black", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customButton2.ForeColor = System.Drawing.Color.White;
            this.customButton2.Image = ((System.Drawing.Image)(resources.GetObject("customButton2.Image")));
            this.customButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.customButton2.IndicatorColor = System.Drawing.Color.ForestGreen;
            this.customButton2.IsActive = false;
            this.customButton2.Location = new System.Drawing.Point(722, 470);
            this.customButton2.Name = "customButton2";
            this.customButton2.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.customButton2.Size = new System.Drawing.Size(90, 34);
            this.customButton2.TabIndex = 1;
            this.customButton2.Text = "Modify";
            this.customButton2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.customButton2.UseVisualStyleBackColor = false;
            this.customButton2.Click += new System.EventHandler(this.customButton2_Click);
            // 
            // roundedPanel1
            // 
            this.roundedPanel1.BackColor = System.Drawing.Color.White;
            this.roundedPanel1.Controls.Add(this.label8);
            this.roundedPanel1.Controls.Add(this.smallTextBox3);
            this.roundedPanel1.Controls.Add(this.maskedTextBox2);
            this.roundedPanel1.Controls.Add(this.maskedTextBox1);
            this.roundedPanel1.Controls.Add(this.label7);
            this.roundedPanel1.Controls.Add(this.label6);
            this.roundedPanel1.Controls.Add(this.customButton1);
            this.roundedPanel1.Controls.Add(this.poisonDateTime1);
            this.roundedPanel1.Controls.Add(this.label5);
            this.roundedPanel1.Controls.Add(this.label4);
            this.roundedPanel1.Controls.Add(this.smallTextBox2);
            this.roundedPanel1.Controls.Add(this.label3);
            this.roundedPanel1.Controls.Add(this.smallTextBox1);
            this.roundedPanel1.Controls.Add(this.label2);
            this.roundedPanel1.Controls.Add(this.aloneComboBox1);
            this.roundedPanel1.ForeColor = System.Drawing.Color.White;
            this.roundedPanel1.Location = new System.Drawing.Point(16, 65);
            this.roundedPanel1.Name = "roundedPanel1";
            this.roundedPanel1.Size = new System.Drawing.Size(796, 121);
            this.roundedPanel1.TabIndex = 18;
            this.roundedPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.roundedPanel1_Paint);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.ForestGreen;
            this.label8.Location = new System.Drawing.Point(572, 14);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 15);
            this.label8.TabIndex = 35;
            this.label8.Text = "Amount Paid";
            // 
            // smallTextBox3
            // 
            this.smallTextBox3.BackColor = System.Drawing.Color.Transparent;
            this.smallTextBox3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.smallTextBox3.CustomBGColor = System.Drawing.Color.White;
            this.smallTextBox3.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.smallTextBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.smallTextBox3.Location = new System.Drawing.Point(575, 32);
            this.smallTextBox3.MaxLength = 32767;
            this.smallTextBox3.Multiline = false;
            this.smallTextBox3.Name = "smallTextBox3";
            this.smallTextBox3.ReadOnly = false;
            this.smallTextBox3.Size = new System.Drawing.Size(130, 25);
            this.smallTextBox3.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            this.smallTextBox3.TabIndex = 34;
            this.smallTextBox3.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.smallTextBox3.UseSystemPasswordChar = false;
            // 
            // maskedTextBox2
            // 
            this.maskedTextBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.maskedTextBox2.Location = new System.Drawing.Point(16, 84);
            this.maskedTextBox2.Mask = "0000-00000-AA-0";
            this.maskedTextBox2.Name = "maskedTextBox2";
            this.maskedTextBox2.Size = new System.Drawing.Size(126, 20);
            this.maskedTextBox2.TabIndex = 33;
            this.maskedTextBox2.ValidatingType = typeof(int);
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.maskedTextBox1.Location = new System.Drawing.Point(440, 33);
            this.maskedTextBox1.Mask = "0000-000-0000";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(126, 20);
            this.maskedTextBox1.TabIndex = 32;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.ForestGreen;
            this.label7.Location = new System.Drawing.Point(437, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 15);
            this.label7.TabIndex = 31;
            this.label7.Text = "Contact No.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.ForestGreen;
            this.label6.Location = new System.Drawing.Point(152, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 15);
            this.label6.TabIndex = 30;
            this.label6.Text = "Date Borrowed ";
            // 
            // customButton1
            // 
            this.customButton1.BackColor = System.Drawing.Color.ForestGreen;
            this.customButton1.BorderRadius = 15;
            this.customButton1.ButtonBorderSize = 2;
            this.customButton1.FlatAppearance.BorderSize = 0;
            this.customButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.customButton1.Font = new System.Drawing.Font("Segoe UI Black", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customButton1.ForeColor = System.Drawing.Color.White;
            this.customButton1.Image = ((System.Drawing.Image)(resources.GetObject("customButton1.Image")));
            this.customButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.customButton1.IndicatorColor = System.Drawing.Color.ForestGreen;
            this.customButton1.IsActive = false;
            this.customButton1.Location = new System.Drawing.Point(697, 77);
            this.customButton1.Name = "customButton1";
            this.customButton1.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.customButton1.Size = new System.Drawing.Size(91, 34);
            this.customButton1.TabIndex = 0;
            this.customButton1.Text = "Confirm";
            this.customButton1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.customButton1.UseVisualStyleBackColor = false;
            // 
            // poisonDateTime1
            // 
            this.poisonDateTime1.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.poisonDateTime1.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.poisonDateTime1.FontSize = ReaLTaiizor.Extension.Poison.PoisonDateTimeSize.Medium;
            this.poisonDateTime1.Location = new System.Drawing.Point(155, 82);
            this.poisonDateTime1.MinimumSize = new System.Drawing.Size(0, 29);
            this.poisonDateTime1.Name = "poisonDateTime1";
            this.poisonDateTime1.Size = new System.Drawing.Size(200, 29);
            this.poisonDateTime1.TabIndex = 29;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.ForestGreen;
            this.label5.Location = new System.Drawing.Point(13, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 15);
            this.label5.TabIndex = 28;
            this.label5.Text = "Student/Faculty ID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.ForestGreen;
            this.label4.Location = new System.Drawing.Point(152, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 15);
            this.label4.TabIndex = 26;
            this.label4.Text = "Program/Section";
            // 
            // smallTextBox2
            // 
            this.smallTextBox2.BackColor = System.Drawing.Color.Transparent;
            this.smallTextBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.smallTextBox2.CustomBGColor = System.Drawing.Color.White;
            this.smallTextBox2.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.smallTextBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.smallTextBox2.Location = new System.Drawing.Point(155, 32);
            this.smallTextBox2.MaxLength = 32767;
            this.smallTextBox2.Multiline = false;
            this.smallTextBox2.Name = "smallTextBox2";
            this.smallTextBox2.ReadOnly = false;
            this.smallTextBox2.Size = new System.Drawing.Size(130, 25);
            this.smallTextBox2.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            this.smallTextBox2.TabIndex = 25;
            this.smallTextBox2.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.smallTextBox2.UseSystemPasswordChar = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.ForestGreen;
            this.label3.Location = new System.Drawing.Point(13, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 15);
            this.label3.TabIndex = 24;
            this.label3.Text = "Full Name";
            // 
            // smallTextBox1
            // 
            this.smallTextBox1.BackColor = System.Drawing.Color.Transparent;
            this.smallTextBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.smallTextBox1.CustomBGColor = System.Drawing.Color.White;
            this.smallTextBox1.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.smallTextBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.smallTextBox1.Location = new System.Drawing.Point(16, 32);
            this.smallTextBox1.MaxLength = 32767;
            this.smallTextBox1.Multiline = false;
            this.smallTextBox1.Name = "smallTextBox1";
            this.smallTextBox1.ReadOnly = false;
            this.smallTextBox1.Size = new System.Drawing.Size(130, 25);
            this.smallTextBox1.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            this.smallTextBox1.TabIndex = 23;
            this.smallTextBox1.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.smallTextBox1.UseSystemPasswordChar = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.ForestGreen;
            this.label2.Location = new System.Drawing.Point(291, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 15);
            this.label2.TabIndex = 22;
            this.label2.Text = "Book Title";
            // 
            // aloneComboBox1
            // 
            this.aloneComboBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.aloneComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.aloneComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.aloneComboBox1.EnabledCalc = true;
            this.aloneComboBox1.FormattingEnabled = true;
            this.aloneComboBox1.ItemHeight = 20;
            this.aloneComboBox1.Location = new System.Drawing.Point(294, 32);
            this.aloneComboBox1.Name = "aloneComboBox1";
            this.aloneComboBox1.Size = new System.Drawing.Size(135, 26);
            this.aloneComboBox1.TabIndex = 21;
            // 
            // Borrow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(828, 523);
            this.Controls.Add(this.customButton2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.roundedPanel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label10);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Borrow";
            this.Text = "Borrow";
            this.Load += new System.EventHandler(this.Borrow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.roundedPanel1.ResumeLayout(false);
            this.roundedPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel1;
        private RoundedPanel.RoundedPanel roundedPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private CustomButton customButton1;
        private CustomButton customButton2;
        private ReaLTaiizor.Controls.AloneComboBox aloneComboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private ReaLTaiizor.Controls.SmallTextBox smallTextBox2;
        private System.Windows.Forms.Label label3;
        private ReaLTaiizor.Controls.SmallTextBox smallTextBox1;
        private System.Windows.Forms.MaskedTextBox maskedTextBox2;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private ReaLTaiizor.Controls.PoisonDateTime poisonDateTime1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.Label label8;
        private ReaLTaiizor.Controls.SmallTextBox smallTextBox3;
    }
}