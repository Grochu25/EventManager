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
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
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
            dataGridView.Size = new Size(776, 302);
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
            textBoxDescription.Location = new Point(482, 12);
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
            labelDescription.Location = new Point(438, 20);
            labelDescription.Name = "labelDescription";
            labelDescription.Size = new Size(31, 15);
            labelDescription.TabIndex = 10;
            labelDescription.Text = "Opis";
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(68, 107);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(140, 23);
            buttonAdd.TabIndex = 11;
            buttonAdd.Text = "Dodaj";
            buttonAdd.UseVisualStyleBackColor = true;
            // 
            // buttonImport
            // 
            buttonImport.Location = new Point(382, 107);
            buttonImport.Name = "buttonImport";
            buttonImport.Size = new Size(140, 23);
            buttonImport.TabIndex = 12;
            buttonImport.Text = "Import";
            buttonImport.UseVisualStyleBackColor = true;
            // 
            // buttonExport
            // 
            buttonExport.Location = new Point(537, 107);
            buttonExport.Name = "buttonExport";
            buttonExport.Size = new Size(140, 23);
            buttonExport.TabIndex = 13;
            buttonExport.Text = "Export";
            buttonExport.UseVisualStyleBackColor = true;
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(226, 107);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(140, 23);
            buttonDelete.TabIndex = 14;
            buttonDelete.Text = "Usuń";
            buttonDelete.UseVisualStyleBackColor = true;
            // 
            // EventView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
    }
}
