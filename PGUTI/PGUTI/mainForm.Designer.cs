namespace PGUTI
{
    partial class mainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.CairsComboBox1 = new System.Windows.Forms.ComboBox();
            this.FacultyGridView1 = new System.Windows.Forms.DataGridView();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.добавитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изменитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.таблицыОтчётаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.печатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.PPCaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DekansbToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ChairsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.FacultyGridView1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CairsComboBox1
            // 
            this.CairsComboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CairsComboBox1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.CairsComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CairsComboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CairsComboBox1.FormattingEnabled = true;
            this.CairsComboBox1.Location = new System.Drawing.Point(534, 3);
            this.CairsComboBox1.Name = "CairsComboBox1";
            this.CairsComboBox1.Size = new System.Drawing.Size(220, 21);
            this.CairsComboBox1.TabIndex = 8;
            this.CairsComboBox1.Visible = false;
            this.CairsComboBox1.SelectedIndexChanged += new System.EventHandler(this.CairsComboBox1_SelectedIndexChanged);
            // 
            // FacultyGridView1
            // 
            this.FacultyGridView1.AllowUserToAddRows = false;
            this.FacultyGridView1.AllowUserToDeleteRows = false;
            this.FacultyGridView1.AllowUserToOrderColumns = true;
            this.FacultyGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FacultyGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.NullValue = null;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.FacultyGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            this.FacultyGridView1.Location = new System.Drawing.Point(0, 31);
            this.FacultyGridView1.Name = "FacultyGridView1";
            this.FacultyGridView1.ReadOnly = true;
            this.FacultyGridView1.Size = new System.Drawing.Size(754, 304);
            this.FacultyGridView1.TabIndex = 5;
            this.FacultyGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.FacultyGridView1_CellContentClick);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.toolStripSplitButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(754, 25);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьToolStripMenuItem,
            this.изменитьToolStripMenuItem,
            this.таблицыОтчётаToolStripMenuItem,
            this.печатьToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(54, 22);
            this.toolStripDropDownButton1.Text = "Меню";
            // 
            // добавитьToolStripMenuItem
            // 
            this.добавитьToolStripMenuItem.Name = "добавитьToolStripMenuItem";
            this.добавитьToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.добавитьToolStripMenuItem.Text = "Добавить";
            this.добавитьToolStripMenuItem.Click += new System.EventHandler(this.добавитьToolStripMenuItem_Click);
            // 
            // изменитьToolStripMenuItem
            // 
            this.изменитьToolStripMenuItem.Name = "изменитьToolStripMenuItem";
            this.изменитьToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.изменитьToolStripMenuItem.Text = "Редактировать";
            this.изменитьToolStripMenuItem.Click += new System.EventHandler(this.изменитьToolStripMenuItem_Click);
            // 
            // таблицыОтчётаToolStripMenuItem
            // 
            this.таблицыОтчётаToolStripMenuItem.Name = "таблицыОтчётаToolStripMenuItem";
            this.таблицыОтчётаToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.таблицыОтчётаToolStripMenuItem.Text = "Таблицы отчёта";
            this.таблицыОтчётаToolStripMenuItem.Click += new System.EventHandler(this.таблицыОтчётаToolStripMenuItem_Click);
            // 
            // печатьToolStripMenuItem
            // 
            this.печатьToolStripMenuItem.Name = "печатьToolStripMenuItem";
            this.печатьToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.печатьToolStripMenuItem.Text = "Экспорт";
            this.печатьToolStripMenuItem.Click += new System.EventHandler(this.печатьToolStripMenuItem_Click);
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PPCaToolStripMenuItem,
            this.DekansbToolStripMenuItem,
            this.ChairsToolStripMenuItem});
            this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(208, 22);
            this.toolStripSplitButton1.Text = "Преподователи/Деканы/Кафедры";
            // 
            // PPCaToolStripMenuItem
            // 
            this.PPCaToolStripMenuItem.Checked = true;
            this.PPCaToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.PPCaToolStripMenuItem.Name = "PPCaToolStripMenuItem";
            this.PPCaToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.PPCaToolStripMenuItem.Text = "Преподователи";
            this.PPCaToolStripMenuItem.Click += new System.EventHandler(this.aToolStripMenuItem_Click);
            // 
            // DekansbToolStripMenuItem
            // 
            this.DekansbToolStripMenuItem.Name = "DekansbToolStripMenuItem";
            this.DekansbToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.DekansbToolStripMenuItem.Text = "Деканы";
            this.DekansbToolStripMenuItem.Click += new System.EventHandler(this.bToolStripMenuItem_Click);
            // 
            // ChairsToolStripMenuItem
            // 
            this.ChairsToolStripMenuItem.Name = "ChairsToolStripMenuItem";
            this.ChairsToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.ChairsToolStripMenuItem.Text = "Кафедры";
            this.ChairsToolStripMenuItem.Click += new System.EventHandler(this.кафедрыToolStripMenuItem_Click);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 335);
            this.Controls.Add(this.CairsComboBox1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.FacultyGridView1);
            this.MinimumSize = new System.Drawing.Size(641, 373);
            this.Name = "mainForm";
            this.Text = "Профессорско-преподавательский состав ПГУТИ";
            this.Load += new System.EventHandler(this.mainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.FacultyGridView1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PGUTIDataSet pGUTIDataSet;
        private PGUTIDataSetTableAdapters.ППСTableAdapter пПСTableAdapter;
        private System.Windows.Forms.DataGridView FacultyGridView1;
        private System.Windows.Forms.ComboBox CairsComboBox1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem добавитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem изменитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem таблицыОтчётаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem печатьToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripMenuItem PPCaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DekansbToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ChairsToolStripMenuItem;
    }
}

