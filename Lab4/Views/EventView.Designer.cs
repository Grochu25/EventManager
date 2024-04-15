namespace Lab4
{
    partial class EventView
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            dataGridView = new DataGridView();
            textBoxName = new TextBox();
            textBoxDescription = new TextBox();
            dateTimePicker = new DateTimePicker();
            comboBoxType = new ComboBox();
            comboBoxPriority = new ComboBox();
            labelName = new Label();
            labelDate = new Label();
            labelType = new Label();
            labelPriority = new Label();
            labelDescription = new Label();
            buttonAdd = new Button();
            buttonImport = new Button();
            buttonExport = new Button();
            buttonDelete = new Button();
            checkBoxPraca = new CheckBox();
            checkBoxSport = new CheckBox();
            checkBoxRodzina = new CheckBox();
            checkBoxZdrowie = new CheckBox();
            flowLayoutPanelType = new FlowLayoutPanel();
            checkBoxRozrywka = new CheckBox();
            flowLayoutPanelPriority = new FlowLayoutPanel();
            checkBoxWysoki = new CheckBox();
            checkBoxSredni = new CheckBox();
            checkBoxNiski = new CheckBox();
            panel1 = new Panel();
            dateTimePickerFilterTo = new DateTimePicker();
            dateTimePickerFilterFrom = new DateTimePicker();
            checkBoxData = new CheckBox();
            groupBoxFilters = new GroupBox();
            labelFilterDate = new Label();
            labelFilterPrioritet = new Label();
            labelFilterType = new Label();
            errorProvider = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            flowLayoutPanelType.SuspendLayout();
            flowLayoutPanelPriority.SuspendLayout();
            panel1.SuspendLayout();
            groupBoxFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView.ImeMode = ImeMode.NoControl;
            dataGridView.Location = new Point(12, 136);
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.RowTemplate.ReadOnly = true;
            dataGridView.ShowEditingIcon = false;
            dataGridView.Size = new Size(540, 302);
            dataGridView.TabIndex = 0;
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(68, 12);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(100, 23);
            textBoxName.TabIndex = 1;
            // 
            // textBoxDescription
            // 
            textBoxDescription.Location = new Point(461, 12);
            textBoxDescription.Multiline = true;
            textBoxDescription.Name = "textBoxDescription";
            textBoxDescription.Size = new Size(306, 81);
            textBoxDescription.TabIndex = 2;
            // 
            // dateTimePicker
            // 
            dateTimePicker.CustomFormat = "dd.MM.yyyy - hh:mm";
            dateTimePicker.Format = DateTimePickerFormat.Custom;
            dateTimePicker.ImeMode = ImeMode.NoControl;
            dateTimePicker.Location = new Point(68, 57);
            dateTimePicker.Name = "dateTimePicker";
            dateTimePicker.Size = new Size(137, 23);
            dateTimePicker.TabIndex = 3;
            // 
            // comboBoxType
            // 
            comboBoxType.FormattingEnabled = true;
            comboBoxType.Location = new Point(269, 12);
            comboBoxType.Name = "comboBoxType";
            comboBoxType.Size = new Size(121, 23);
            comboBoxType.TabIndex = 4;
            // 
            // comboBoxPriority
            // 
            comboBoxPriority.FormattingEnabled = true;
            comboBoxPriority.Location = new Point(269, 57);
            comboBoxPriority.Name = "comboBoxPriority";
            comboBoxPriority.Size = new Size(121, 23);
            comboBoxPriority.TabIndex = 5;
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Location = new Point(12, 15);
            labelName.Name = "labelName";
            labelName.Size = new Size(45, 15);
            labelName.TabIndex = 6;
            labelName.Text = "Nazwa:";
            // 
            // labelDate
            // 
            labelDate.AutoSize = true;
            labelDate.Location = new Point(20, 63);
            labelDate.Name = "labelDate";
            labelDate.Size = new Size(37, 15);
            labelDate.TabIndex = 7;
            labelDate.Text = "Data: ";
            // 
            // labelType
            // 
            labelType.AutoSize = true;
            labelType.Location = new Point(235, 15);
            labelType.Name = "labelType";
            labelType.Size = new Size(28, 15);
            labelType.TabIndex = 8;
            labelType.Text = "Typ:";
            // 
            // labelPriority
            // 
            labelPriority.AutoSize = true;
            labelPriority.Location = new Point(211, 60);
            labelPriority.Name = "labelPriority";
            labelPriority.Size = new Size(55, 15);
            labelPriority.TabIndex = 9;
            labelPriority.Text = "Priorytet:";
            // 
            // labelDescription
            // 
            labelDescription.AutoSize = true;
            labelDescription.Location = new Point(417, 20);
            labelDescription.Name = "labelDescription";
            labelDescription.Size = new Size(31, 15);
            labelDescription.TabIndex = 10;
            labelDescription.Text = "Opis";
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(80, 107);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(140, 23);
            buttonAdd.TabIndex = 11;
            buttonAdd.Text = "Dodaj";
            buttonAdd.UseVisualStyleBackColor = true;
            // 
            // buttonImport
            // 
            buttonImport.Location = new Point(394, 107);
            buttonImport.Name = "buttonImport";
            buttonImport.Size = new Size(140, 23);
            buttonImport.TabIndex = 12;
            buttonImport.Text = "Import";
            buttonImport.UseVisualStyleBackColor = true;
            // 
            // buttonExport
            // 
            buttonExport.Location = new Point(549, 107);
            buttonExport.Name = "buttonExport";
            buttonExport.Size = new Size(140, 23);
            buttonExport.TabIndex = 13;
            buttonExport.Text = "Export";
            buttonExport.UseVisualStyleBackColor = true;
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(238, 107);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(140, 23);
            buttonDelete.TabIndex = 14;
            buttonDelete.Text = "Usuń";
            buttonDelete.UseVisualStyleBackColor = true;
            // 
            // checkBoxPraca
            // 
            checkBoxPraca.AutoSize = true;
            checkBoxPraca.Location = new Point(3, 3);
            checkBoxPraca.Name = "checkBoxPraca";
            checkBoxPraca.Size = new Size(64, 19);
            checkBoxPraca.TabIndex = 0;
            checkBoxPraca.Text = "PRACA";
            checkBoxPraca.UseVisualStyleBackColor = true;
            checkBoxPraca.CheckedChanged += checkboxFilterClicked;
            // 
            // checkBoxSport
            // 
            checkBoxSport.AutoSize = true;
            checkBoxSport.Location = new Point(73, 3);
            checkBoxSport.Name = "checkBoxSport";
            checkBoxSport.Size = new Size(60, 19);
            checkBoxSport.TabIndex = 1;
            checkBoxSport.Text = "SPORT";
            checkBoxSport.UseVisualStyleBackColor = true;
            checkBoxSport.CheckedChanged += checkboxFilterClicked;
            // 
            // checkBoxRodzina
            // 
            checkBoxRodzina.AutoSize = true;
            checkBoxRodzina.Location = new Point(139, 3);
            checkBoxRodzina.Name = "checkBoxRodzina";
            checkBoxRodzina.Size = new Size(77, 19);
            checkBoxRodzina.TabIndex = 2;
            checkBoxRodzina.Text = "RODZINA";
            checkBoxRodzina.UseVisualStyleBackColor = true;
            checkBoxRodzina.CheckedChanged += checkboxFilterClicked;
            // 
            // checkBoxZdrowie
            // 
            checkBoxZdrowie.AutoSize = true;
            checkBoxZdrowie.Location = new Point(3, 28);
            checkBoxZdrowie.Name = "checkBoxZdrowie";
            checkBoxZdrowie.Size = new Size(77, 19);
            checkBoxZdrowie.TabIndex = 3;
            checkBoxZdrowie.Text = "ZDROWIE";
            checkBoxZdrowie.UseVisualStyleBackColor = true;
            checkBoxZdrowie.CheckedChanged += checkboxFilterClicked;
            // 
            // flowLayoutPanelType
            // 
            flowLayoutPanelType.AutoSize = true;
            flowLayoutPanelType.Controls.Add(checkBoxPraca);
            flowLayoutPanelType.Controls.Add(checkBoxSport);
            flowLayoutPanelType.Controls.Add(checkBoxRodzina);
            flowLayoutPanelType.Controls.Add(checkBoxZdrowie);
            flowLayoutPanelType.Controls.Add(checkBoxRozrywka);
            flowLayoutPanelType.Location = new Point(6, 37);
            flowLayoutPanelType.MaximumSize = new Size(230, 100);
            flowLayoutPanelType.Name = "flowLayoutPanelType";
            flowLayoutPanelType.Size = new Size(219, 50);
            flowLayoutPanelType.TabIndex = 17;
            // 
            // checkBoxRozrywka
            // 
            checkBoxRozrywka.AutoSize = true;
            checkBoxRozrywka.Location = new Point(86, 28);
            checkBoxRozrywka.Name = "checkBoxRozrywka";
            checkBoxRozrywka.Size = new Size(89, 19);
            checkBoxRozrywka.TabIndex = 4;
            checkBoxRozrywka.Text = "ROZRYWKA";
            checkBoxRozrywka.UseVisualStyleBackColor = true;
            checkBoxRozrywka.CheckedChanged += checkboxFilterClicked;
            // 
            // flowLayoutPanelPriority
            // 
            flowLayoutPanelPriority.AutoSize = true;
            flowLayoutPanelPriority.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanelPriority.Controls.Add(checkBoxWysoki);
            flowLayoutPanelPriority.Controls.Add(checkBoxSredni);
            flowLayoutPanelPriority.Controls.Add(checkBoxNiski);
            flowLayoutPanelPriority.Location = new Point(6, 129);
            flowLayoutPanelPriority.MaximumSize = new Size(230, 100);
            flowLayoutPanelPriority.Name = "flowLayoutPanelPriority";
            flowLayoutPanelPriority.Size = new Size(206, 25);
            flowLayoutPanelPriority.TabIndex = 18;
            // 
            // checkBoxWysoki
            // 
            checkBoxWysoki.AutoSize = true;
            checkBoxWysoki.Location = new Point(3, 3);
            checkBoxWysoki.Name = "checkBoxWysoki";
            checkBoxWysoki.Size = new Size(69, 19);
            checkBoxWysoki.TabIndex = 0;
            checkBoxWysoki.Text = "WYSOKI";
            checkBoxWysoki.UseVisualStyleBackColor = true;
            checkBoxWysoki.CheckedChanged += checkboxFilterClicked;
            // 
            // checkBoxSredni
            // 
            checkBoxSredni.AutoSize = true;
            checkBoxSredni.Location = new Point(78, 3);
            checkBoxSredni.Name = "checkBoxSredni";
            checkBoxSredni.Size = new Size(65, 19);
            checkBoxSredni.TabIndex = 1;
            checkBoxSredni.Text = "SREDNI";
            checkBoxSredni.UseVisualStyleBackColor = true;
            checkBoxSredni.CheckedChanged += checkboxFilterClicked;
            // 
            // checkBoxNiski
            // 
            checkBoxNiski.AutoSize = true;
            checkBoxNiski.Location = new Point(149, 3);
            checkBoxNiski.MaximumSize = new Size(200, 100);
            checkBoxNiski.Name = "checkBoxNiski";
            checkBoxNiski.Size = new Size(54, 19);
            checkBoxNiski.TabIndex = 2;
            checkBoxNiski.Text = "NISKI";
            checkBoxNiski.UseVisualStyleBackColor = true;
            checkBoxNiski.CheckedChanged += checkboxFilterClicked;
            // 
            // panel1
            // 
            panel1.Controls.Add(dateTimePickerFilterTo);
            panel1.Controls.Add(dateTimePickerFilterFrom);
            panel1.Controls.Add(checkBoxData);
            panel1.Location = new Point(6, 196);
            panel1.Name = "panel1";
            panel1.Size = new Size(187, 93);
            panel1.TabIndex = 19;
            // 
            // dateTimePickerFilterTo
            // 
            dateTimePickerFilterTo.CustomFormat = "dd.MM.yyyy";
            dateTimePickerFilterTo.Enabled = false;
            dateTimePickerFilterTo.Format = DateTimePickerFormat.Short;
            dateTimePickerFilterTo.ImeMode = ImeMode.NoControl;
            dateTimePickerFilterTo.Location = new Point(64, 57);
            dateTimePickerFilterTo.Name = "dateTimePickerFilterTo";
            dateTimePickerFilterTo.Size = new Size(111, 23);
            dateTimePickerFilterTo.TabIndex = 22;
            dateTimePickerFilterTo.Value = DateTime.Now;
            dateTimePickerFilterTo.ValueChanged += checkboxFilterClicked;
            // 
            // dateTimePickerFilterFrom
            // 
            dateTimePickerFilterFrom.CustomFormat = "dd.MM.yyyy hh:mm:ss";
            dateTimePickerFilterFrom.Enabled = false;
            dateTimePickerFilterFrom.Format = DateTimePickerFormat.Short;
            dateTimePickerFilterFrom.ImeMode = ImeMode.NoControl;
            dateTimePickerFilterFrom.Location = new Point(64, 28);
            dateTimePickerFilterFrom.Name = "dateTimePickerFilterFrom";
            dateTimePickerFilterFrom.Size = new Size(111, 23);
            dateTimePickerFilterFrom.TabIndex = 21;
            dateTimePickerFilterFrom.Value = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            dateTimePickerFilterFrom.ValueChanged += checkboxFilterClicked;
            // 
            // checkBoxData
            // 
            checkBoxData.AutoSize = true;
            checkBoxData.Location = new Point(3, 3);
            checkBoxData.Name = "checkBoxData";
            checkBoxData.Size = new Size(50, 19);
            checkBoxData.TabIndex = 5;
            checkBoxData.Text = "Data";
            checkBoxData.UseVisualStyleBackColor = true;
            checkBoxData.CheckedChanged += checkboxFilterClicked;
            // 
            // groupBoxFilters
            // 
            groupBoxFilters.Controls.Add(labelFilterDate);
            groupBoxFilters.Controls.Add(labelFilterPrioritet);
            groupBoxFilters.Controls.Add(labelFilterType);
            groupBoxFilters.Controls.Add(flowLayoutPanelType);
            groupBoxFilters.Controls.Add(panel1);
            groupBoxFilters.Controls.Add(flowLayoutPanelPriority);
            groupBoxFilters.Location = new Point(561, 140);
            groupBoxFilters.Name = "groupBoxFilters";
            groupBoxFilters.Size = new Size(227, 298);
            groupBoxFilters.TabIndex = 20;
            groupBoxFilters.TabStop = false;
            groupBoxFilters.Text = "Filtruj po:";
            // 
            // labelFilterDate
            // 
            labelFilterDate.AutoSize = true;
            labelFilterDate.Location = new Point(9, 178);
            labelFilterDate.Name = "labelFilterDate";
            labelFilterDate.Size = new Size(42, 15);
            labelFilterDate.TabIndex = 23;
            labelFilterDate.Text = "Dacie: ";
            // 
            // labelFilterPrioritet
            // 
            labelFilterPrioritet.AutoSize = true;
            labelFilterPrioritet.Location = new Point(6, 114);
            labelFilterPrioritet.Name = "labelFilterPrioritet";
            labelFilterPrioritet.Size = new Size(66, 15);
            labelFilterPrioritet.TabIndex = 22;
            labelFilterPrioritet.Text = "Priorytecie:";
            // 
            // labelFilterType
            // 
            labelFilterType.AutoSize = true;
            labelFilterType.Location = new Point(6, 19);
            labelFilterType.Name = "labelFilterType";
            labelFilterType.Size = new Size(37, 15);
            labelFilterType.TabIndex = 21;
            labelFilterType.Text = "Typie:";
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // EventView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(groupBoxFilters);
            Controls.Add(buttonDelete);
            Controls.Add(buttonExport);
            Controls.Add(buttonImport);
            Controls.Add(buttonAdd);
            Controls.Add(labelDescription);
            Controls.Add(labelPriority);
            Controls.Add(labelType);
            Controls.Add(labelDate);
            Controls.Add(labelName);
            Controls.Add(comboBoxPriority);
            Controls.Add(comboBoxType);
            Controls.Add(dateTimePicker);
            Controls.Add(textBoxDescription);
            Controls.Add(textBoxName);
            Controls.Add(dataGridView);
            Name = "EventView";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            flowLayoutPanelType.ResumeLayout(false);
            flowLayoutPanelType.PerformLayout();
            flowLayoutPanelPriority.ResumeLayout(false);
            flowLayoutPanelPriority.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            groupBoxFilters.ResumeLayout(false);
            groupBoxFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView;
        private TextBox textBoxName;
        private TextBox textBoxDescription;
        private DateTimePicker dateTimePicker;
        private ComboBox comboBoxType;
        private ComboBox comboBoxPriority;
        private Label labelName;
        private Label labelDate;
        private Label labelType;
        private Label labelPriority;
        private Label labelDescription;
        private Button buttonAdd;
        private Button buttonImport;
        private Button buttonExport;
        private Button buttonDelete;
        private CheckBox checkBoxPraca;
        private CheckBox checkBoxZdrowie;
        private CheckBox checkBoxRodzina;
        private CheckBox checkBoxSport;
        private CheckBox checkBoxRozrywka;
        private FlowLayoutPanel flowLayoutPanelType;
        private FlowLayoutPanel flowLayoutPanelPriority;
        private CheckBox checkBoxWysoki;
        private CheckBox checkBoxSredni;
        private CheckBox checkBoxNiski;
        private Panel panel1;
        private CheckBox checkBoxData;
        private GroupBox groupBoxFilters;
        private Label labelFilterType;
        private DateTimePicker dateTimePickerFilterTo;
        private DateTimePicker dateTimePickerFilterFrom;
        private Label labelFilterDate;
        private Label labelFilterPrioritet;
        private ErrorProvider errorProvider;
    }
}
