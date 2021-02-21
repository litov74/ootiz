namespace OOTiZ
{
    partial class Report
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.Generate = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.CheckAll = new System.Windows.Forms.ToolStripButton();
            this.UncheckAll = new System.Windows.Forms.ToolStripButton();
            this.CheckInverse = new System.Windows.Forms.ToolStripButton();
            this.Reset = new System.Windows.Forms.ToolStripButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CountColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.планDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LKM = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CheckSelected = new System.Windows.Forms.ToolStripMenuItem();
            this.UncheckSelected = new System.Windows.Forms.ToolStripMenuItem();
            this.CheckInverseSelected = new System.Windows.Forms.ToolStripMenuItem();
            this.ResetSelected = new System.Windows.Forms.ToolStripMenuItem();
            this.продукцияBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.vypuskDataSet = new OOTiZ.vypuskDataSet();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.panel2 = new System.Windows.Forms.Panel();
            this.FindBox = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.Vid_otcheta = new System.Windows.Forms.GroupBox();
            this.radioButton8 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.Full = new System.Windows.Forms.CheckBox();
            this.UncheckAllButton = new System.Windows.Forms.Button();
            this.GenerateButton = new System.Windows.Forms.Button();
            this.ResetButton = new System.Windows.Forms.Button();
            this.CheckAllButton = new System.Windows.Forms.Button();
            this.CheckInverseButton = new System.Windows.Forms.Button();
            this.Vid_Full = new System.Windows.Forms.GroupBox();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.radioButton7 = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.бригадыBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.бригадыTableAdapter = new OOTiZ.vypuskDataSetTableAdapters.БригадыTableAdapter();
            this.продукцияTableAdapter = new OOTiZ.vypuskDataSetTableAdapters.ПродукцияTableAdapter();
            this.операцииBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.операцииTableAdapter = new OOTiZ.vypuskDataSetTableAdapters.ОперацииTableAdapter();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.LKM.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.продукцияBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vypuskDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.Vid_otcheta.SuspendLayout();
            this.Vid_Full.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.бригадыBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.операцииBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Generate,
            this.toolStripSeparator1,
            this.CheckAll,
            this.UncheckAll,
            this.CheckInverse,
            this.Reset});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStrip1.Size = new System.Drawing.Size(724, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // Generate
            // 
            this.Generate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Generate.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.Generate.Image = global::OOTiZ.Properties.Resources.Report;
            this.Generate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Generate.Name = "Generate";
            this.Generate.Size = new System.Drawing.Size(24, 24);
            this.Generate.Text = "Отчёт";
            this.Generate.Click += new System.EventHandler(this.Generate_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // CheckAll
            // 
            this.CheckAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CheckAll.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.CheckAll.Image = global::OOTiZ.Properties.Resources.Check;
            this.CheckAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CheckAll.Name = "CheckAll";
            this.CheckAll.Size = new System.Drawing.Size(24, 24);
            this.CheckAll.Text = "Отметить все";
            this.CheckAll.Click += new System.EventHandler(this.CheckAll_Click);
            // 
            // UncheckAll
            // 
            this.UncheckAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.UncheckAll.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.UncheckAll.Image = global::OOTiZ.Properties.Resources.Uncheck;
            this.UncheckAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.UncheckAll.Name = "UncheckAll";
            this.UncheckAll.Size = new System.Drawing.Size(24, 24);
            this.UncheckAll.Text = "Снять все отметки";
            this.UncheckAll.Click += new System.EventHandler(this.UncheckAll_Click);
            // 
            // CheckInverse
            // 
            this.CheckInverse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CheckInverse.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.CheckInverse.Image = global::OOTiZ.Properties.Resources.Invert;
            this.CheckInverse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CheckInverse.Name = "CheckInverse";
            this.CheckInverse.Size = new System.Drawing.Size(24, 24);
            this.CheckInverse.Text = "Обратить выбор";
            this.CheckInverse.Click += new System.EventHandler(this.CheckInverse_Click);
            // 
            // Reset
            // 
            this.Reset.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Reset.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.Reset.Image = global::OOTiZ.Properties.Resources.ZeroZeroZero;
            this.Reset.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Reset.Name = "Reset";
            this.Reset.Size = new System.Drawing.Size(24, 24);
            this.Reset.Text = "Обнулить план";
            this.Reset.Click += new System.EventHandler(this.Reset_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.NameColumn,
            this.CountColumn,
            this.Check,
            this.планDataGridViewTextBoxColumn});
            this.dataGridView1.ContextMenuStrip = this.LKM;
            this.dataGridView1.DataSource = this.продукцияBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView1.Location = new System.Drawing.Point(0, 89);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.RowHeadersWidth = 62;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(724, 269);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            this.dataGridView1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dataGridView1_KeyPress);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID Продукции";
            this.ID.HeaderText = "ID Продукции";
            this.ID.MinimumWidth = 8;
            this.ID.Name = "ID";
            this.ID.Visible = false;
            this.ID.Width = 150;
            // 
            // NameColumn
            // 
            this.NameColumn.DataPropertyName = "Наименование детали";
            this.NameColumn.HeaderText = "Наименование детали";
            this.NameColumn.MinimumWidth = 8;
            this.NameColumn.Name = "NameColumn";
            this.NameColumn.ReadOnly = true;
            this.NameColumn.Width = 350;
            // 
            // CountColumn
            // 
            this.CountColumn.DataPropertyName = "Количество";
            this.CountColumn.HeaderText = "Количество";
            this.CountColumn.MinimumWidth = 8;
            this.CountColumn.Name = "CountColumn";
            this.CountColumn.ReadOnly = true;
            this.CountColumn.Width = 150;
            // 
            // Check
            // 
            this.Check.DataPropertyName = "Отметка";
            this.Check.HeaderText = "Отметка";
            this.Check.MinimumWidth = 8;
            this.Check.Name = "Check";
            this.Check.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Check.Width = 125;
            // 
            // планDataGridViewTextBoxColumn
            // 
            this.планDataGridViewTextBoxColumn.DataPropertyName = "План";
            this.планDataGridViewTextBoxColumn.HeaderText = "План";
            this.планDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.планDataGridViewTextBoxColumn.Name = "планDataGridViewTextBoxColumn";
            this.планDataGridViewTextBoxColumn.Width = 150;
            // 
            // LKM
            // 
            this.LKM.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.LKM.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CheckSelected,
            this.UncheckSelected,
            this.CheckInverseSelected,
            this.ResetSelected});
            this.LKM.Name = "LKM";
            this.LKM.Size = new System.Drawing.Size(199, 92);
            // 
            // CheckSelected
            // 
            this.CheckSelected.Name = "CheckSelected";
            this.CheckSelected.Size = new System.Drawing.Size(198, 22);
            this.CheckSelected.Text = "Отметить выделенное";
            this.CheckSelected.Click += new System.EventHandler(this.CheckSelected_Click);
            // 
            // UncheckSelected
            // 
            this.UncheckSelected.Name = "UncheckSelected";
            this.UncheckSelected.Size = new System.Drawing.Size(198, 22);
            this.UncheckSelected.Text = "Снять отметки";
            this.UncheckSelected.Click += new System.EventHandler(this.UncheckSelected_Click);
            // 
            // CheckInverseSelected
            // 
            this.CheckInverseSelected.Name = "CheckInverseSelected";
            this.CheckInverseSelected.Size = new System.Drawing.Size(198, 22);
            this.CheckInverseSelected.Text = "Обратить отметки";
            this.CheckInverseSelected.Click += new System.EventHandler(this.CheckInverseSelected_Click);
            // 
            // ResetSelected
            // 
            this.ResetSelected.Name = "ResetSelected";
            this.ResetSelected.Size = new System.Drawing.Size(198, 22);
            this.ResetSelected.Text = "Обнулить выделенное";
            this.ResetSelected.Click += new System.EventHandler(this.ResetSelected_Click);
            // 
            // продукцияBindingSource
            // 
            this.продукцияBindingSource.DataMember = "Продукция";
            this.продукцияBindingSource.DataSource = this.vypuskDataSet;
            // 
            // vypuskDataSet
            // 
            this.vypuskDataSet.DataSetName = "vypuskDataSet";
            this.vypuskDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataMember = "Продукция";
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(0, 550);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(724, 23);
            this.progressBar1.TabIndex = 4;
            this.progressBar1.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.FindBox);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 27);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(724, 21);
            this.panel2.TabIndex = 5;
            // 
            // FindBox
            // 
            this.FindBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.FindBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.FindBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FindBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FindBox.Location = new System.Drawing.Point(181, 0);
            this.FindBox.Name = "FindBox";
            this.FindBox.Size = new System.Drawing.Size(543, 24);
            this.FindBox.TabIndex = 0;
            this.FindBox.TextChanged += new System.EventHandler(this.FindBox_TextChanged);
            this.FindBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FindBox_KeyDown);
            this.FindBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FindBox_KeyPress);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(181, 21);
            this.panel3.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Поиск по деталям:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Vid_otcheta
            // 
            this.Vid_otcheta.Controls.Add(this.radioButton8);
            this.Vid_otcheta.Controls.Add(this.radioButton3);
            this.Vid_otcheta.Controls.Add(this.radioButton5);
            this.Vid_otcheta.Controls.Add(this.radioButton4);
            this.Vid_otcheta.Controls.Add(this.radioButton2);
            this.Vid_otcheta.Controls.Add(this.radioButton1);
            this.Vid_otcheta.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Vid_otcheta.Location = new System.Drawing.Point(9, 10);
            this.Vid_otcheta.Name = "Vid_otcheta";
            this.Vid_otcheta.Size = new System.Drawing.Size(486, 93);
            this.Vid_otcheta.TabIndex = 999;
            this.Vid_otcheta.TabStop = false;
            this.Vid_otcheta.Text = "Вид отчёта";
            // 
            // radioButton8
            // 
            this.radioButton8.AutoSize = true;
            this.radioButton8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButton8.Location = new System.Drawing.Point(6, 67);
            this.radioButton8.Name = "radioButton8";
            this.radioButton8.Size = new System.Drawing.Size(160, 22);
            this.radioButton8.TabIndex = 1000;
            this.radioButton8.Text = "Отчет по бригадам";
            this.radioButton8.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButton3.Location = new System.Drawing.Point(261, 19);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(223, 22);
            this.radioButton3.TabIndex = 3;
            this.radioButton3.Text = "Нормы на плановый выпуск";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.Full_CheckedChanged);
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButton5.Location = new System.Drawing.Point(261, 65);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(200, 22);
            this.radioButton5.TabIndex = 3;
            this.radioButton5.Text = "Неотмеченные операции";
            this.radioButton5.UseVisualStyleBackColor = true;
            this.radioButton5.CheckedChanged += new System.EventHandler(this.radioButton5_CheckedChanged);
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButton4.Location = new System.Drawing.Point(261, 42);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(212, 22);
            this.radioButton4.TabIndex = 3;
            this.radioButton4.Text = "Отчёт по подразделениям";
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButton2.Location = new System.Drawing.Point(6, 42);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(249, 22);
            this.radioButton2.TabIndex = 3;
            this.radioButton2.Text = "Зарплата на единицу продукции";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButton1.Location = new System.Drawing.Point(6, 19);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(127, 22);
            this.radioButton1.TabIndex = 999;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Узел в сборке";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // Full
            // 
            this.Full.AutoSize = true;
            this.Full.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Full.Location = new System.Drawing.Point(514, 16);
            this.Full.Name = "Full";
            this.Full.Size = new System.Drawing.Size(110, 22);
            this.Full.TabIndex = 3;
            this.Full.TabStop = false;
            this.Full.Text = "Развёнутый";
            this.Full.UseVisualStyleBackColor = true;
            this.Full.CheckedChanged += new System.EventHandler(this.Full_CheckedChanged);
            // 
            // UncheckAllButton
            // 
            this.UncheckAllButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UncheckAllButton.Location = new System.Drawing.Point(130, 188);
            this.UncheckAllButton.Name = "UncheckAllButton";
            this.UncheckAllButton.Size = new System.Drawing.Size(150, 46);
            this.UncheckAllButton.TabIndex = 5;
            this.UncheckAllButton.TabStop = false;
            this.UncheckAllButton.Text = "Снять все отметки";
            this.UncheckAllButton.UseVisualStyleBackColor = true;
            this.UncheckAllButton.Click += new System.EventHandler(this.UncheckAll_Click);
            // 
            // GenerateButton
            // 
            this.GenerateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GenerateButton.Location = new System.Drawing.Point(11, 135);
            this.GenerateButton.Name = "GenerateButton";
            this.GenerateButton.Size = new System.Drawing.Size(74, 46);
            this.GenerateButton.TabIndex = 3;
            this.GenerateButton.TabStop = false;
            this.GenerateButton.Text = "Отчёт";
            this.GenerateButton.UseVisualStyleBackColor = true;
            this.GenerateButton.Click += new System.EventHandler(this.Generate_Click);
            // 
            // ResetButton
            // 
            this.ResetButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ResetButton.Location = new System.Drawing.Point(438, 188);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(127, 46);
            this.ResetButton.TabIndex = 6;
            this.ResetButton.TabStop = false;
            this.ResetButton.Text = "Обнулить план";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.Reset_Click);
            // 
            // CheckAllButton
            // 
            this.CheckAllButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CheckAllButton.Location = new System.Drawing.Point(11, 188);
            this.CheckAllButton.Name = "CheckAllButton";
            this.CheckAllButton.Size = new System.Drawing.Size(113, 46);
            this.CheckAllButton.TabIndex = 4;
            this.CheckAllButton.TabStop = false;
            this.CheckAllButton.Text = "Отметить все";
            this.CheckAllButton.UseVisualStyleBackColor = true;
            this.CheckAllButton.Click += new System.EventHandler(this.CheckAll_Click);
            // 
            // CheckInverseButton
            // 
            this.CheckInverseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CheckInverseButton.Location = new System.Drawing.Point(286, 188);
            this.CheckInverseButton.Name = "CheckInverseButton";
            this.CheckInverseButton.Size = new System.Drawing.Size(146, 46);
            this.CheckInverseButton.TabIndex = 6;
            this.CheckInverseButton.TabStop = false;
            this.CheckInverseButton.Text = "Обратить отметки";
            this.CheckInverseButton.UseVisualStyleBackColor = true;
            this.CheckInverseButton.Click += new System.EventHandler(this.CheckInverse_Click);
            // 
            // Vid_Full
            // 
            this.Vid_Full.Controls.Add(this.radioButton6);
            this.Vid_Full.Controls.Add(this.radioButton7);
            this.Vid_Full.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Vid_Full.Location = new System.Drawing.Point(511, 33);
            this.Vid_Full.Name = "Vid_Full";
            this.Vid_Full.Size = new System.Drawing.Size(182, 70);
            this.Vid_Full.TabIndex = 999;
            this.Vid_Full.TabStop = false;
            this.Vid_Full.Text = "Вид разворачивания";
            this.Vid_Full.Visible = false;
            this.Vid_Full.Enter += new System.EventHandler(this.Vid_Full_Enter);
            // 
            // radioButton6
            // 
            this.radioButton6.AutoSize = true;
            this.radioButton6.Checked = true;
            this.radioButton6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButton6.Location = new System.Drawing.Point(7, 23);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(159, 22);
            this.radioButton6.TabIndex = 3;
            this.radioButton6.TabStop = true;
            this.radioButton6.Text = "По составу сборки";
            this.radioButton6.UseVisualStyleBackColor = true;
            this.radioButton6.CheckedChanged += new System.EventHandler(this.radioButton6_CheckedChanged);
            // 
            // radioButton7
            // 
            this.radioButton7.AutoSize = true;
            this.radioButton7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButton7.Location = new System.Drawing.Point(5, 44);
            this.radioButton7.Name = "radioButton7";
            this.radioButton7.Size = new System.Drawing.Size(134, 22);
            this.radioButton7.TabIndex = 3;
            this.radioButton7.Text = "Суммированый";
            this.radioButton7.UseVisualStyleBackColor = true;
            this.radioButton7.CheckedChanged += new System.EventHandler(this.radioButton7_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.comboBox3);
            this.panel1.Controls.Add(this.comboBox2);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.Vid_Full);
            this.panel1.Controls.Add(this.CheckInverseButton);
            this.panel1.Controls.Add(this.CheckAllButton);
            this.panel1.Controls.Add(this.ResetButton);
            this.panel1.Controls.Add(this.GenerateButton);
            this.panel1.Controls.Add(this.UncheckAllButton);
            this.panel1.Controls.Add(this.Full);
            this.panel1.Controls.Add(this.Vid_otcheta);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 276);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(724, 274);
            this.panel1.TabIndex = 1;
            // 
            // comboBox3
            // 
            this.comboBox3.DataSource = this.бригадыBindingSource;
            this.comboBox3.DisplayMember = "ID Бригады";
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(11, 112);
            this.comboBox3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(75, 21);
            this.comboBox3.TabIndex = 1003;
            this.comboBox3.ValueMember = "ID Бригады";
            // 
            // бригадыBindingSource
            // 
            this.бригадыBindingSource.DataMember = "Бригады";
            this.бригадыBindingSource.DataSource = this.vypuskDataSet;
            // 
            // comboBox2
            // 
            this.comboBox2.DataSource = this.бригадыBindingSource;
            this.comboBox2.DisplayMember = "Норма выработки";
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(261, 112);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(83, 21);
            this.comboBox2.TabIndex = 1002;
            this.comboBox2.ValueMember = "Норма выработки";
            // 
            // comboBox1
            // 
            this.comboBox1.DataSource = this.бригадыBindingSource;
            this.comboBox1.DisplayMember = "Наименование";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(100, 112);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(145, 21);
            this.comboBox1.TabIndex = 1001;
            this.comboBox1.ValueMember = "Наименование";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(101, 135);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(143, 46);
            this.button1.TabIndex = 1000;
            this.button1.TabStop = false;
            this.button1.Text = "Сохранить данные по плану";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 48);
            this.panel4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(724, 41);
            this.panel4.TabIndex = 6;
            this.panel4.Paint += new System.Windows.Forms.PaintEventHandler(this.panel4_Paint);
            // 
            // бригадыTableAdapter
            // 
            this.бригадыTableAdapter.ClearBeforeFill = true;
            // 
            // продукцияTableAdapter
            // 
            this.продукцияTableAdapter.ClearBeforeFill = true;
            // 
            // операцииBindingSource
            // 
            this.операцииBindingSource.DataMember = "Операции";
            this.операцииBindingSource.DataSource = this.vypuskDataSet;
            this.операцииBindingSource.Filter = "";
            this.операцииBindingSource.Sort = "Номер";
            // 
            // операцииTableAdapter
            // 
            this.операцииTableAdapter.ClearBeforeFill = true;
            // 
            // Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 573);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.progressBar1);
            this.Name = "Report";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Отчёты";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.LKM.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.продукцияBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vypuskDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.Vid_otcheta.ResumeLayout(false);
            this.Vid_otcheta.PerformLayout();
            this.Vid_Full.ResumeLayout(false);
            this.Vid_Full.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.бригадыBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.операцииBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton Generate;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton CheckAll;
        private System.Windows.Forms.ToolStripButton UncheckAll;
        private System.Windows.Forms.ToolStripButton Reset;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ContextMenuStrip LKM;
        private System.Windows.Forms.ToolStripMenuItem CheckSelected;
        private System.Windows.Forms.ToolStripMenuItem UncheckSelected;
        private System.Windows.Forms.ToolStripMenuItem CheckInverseSelected;
        private System.Windows.Forms.ToolStripMenuItem ResetSelected;
        private System.Windows.Forms.ToolStripButton CheckInverse;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox FindBox;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private vypuskDataSet vypuskDataSet;
        private System.Windows.Forms.BindingSource бригадыBindingSource;
        private vypuskDataSetTableAdapters.БригадыTableAdapter бригадыTableAdapter;
        private System.Windows.Forms.GroupBox Vid_otcheta;
        private System.Windows.Forms.RadioButton radioButton8;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.CheckBox Full;
        private System.Windows.Forms.Button UncheckAllButton;
        private System.Windows.Forms.Button GenerateButton;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.Button CheckAllButton;
        private System.Windows.Forms.Button CheckInverseButton;
        private System.Windows.Forms.GroupBox Vid_Full;
        private System.Windows.Forms.RadioButton radioButton6;
        private System.Windows.Forms.RadioButton radioButton7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.BindingSource продукцияBindingSource;
        private vypuskDataSetTableAdapters.ПродукцияTableAdapter продукцияTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CountColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Check;
        private System.Windows.Forms.DataGridViewTextBoxColumn планDataGridViewTextBoxColumn;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox3;
        public System.Windows.Forms.BindingSource операцииBindingSource;
        public vypuskDataSetTableAdapters.ОперацииTableAdapter операцииTableAdapter;
    }
}

