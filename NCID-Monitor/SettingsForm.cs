using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NCID_Monitor
{
    public class SettingsForm : Form
    {
        private TabControl tabControl1;
        private TabPage tabpage_General;
        private TabPage tabpage_Phonebook;
        private TabPage tabpage_Phones;
        private DataGridView dataGridView1;
        private Button button_Change;
        private Button button_Delete;
        private Label label_Number;
        private Label label_Name;
        private TextBox textBox_Number;
        private TextBox textBox_Name;
        private Button button_Add;
        private Label label_Port;
        private Label label_Hostname;
        private TextBox textBox_Port;
        private TextBox textBox_Hostname;
        private Button button_Clear;
        private Label label_Language;
        private ComboBox comboBox_Language;
        private Button button_SaveRestart;
        private DataGridView dataGridView2;
        private Label label_ToolTipDelay;
        private NumericUpDown numericUpDown_Delay;
        private CheckBox checkBox_CreateLogfiles;
        private string tempValue;

        public SettingsForm()
        {
            InitializeComponent();

            Text = Program.AppName + " - SettingsForm";

            tabpage_General.GetText();
            tabpage_Phonebook.GetText();
            tabpage_Phones.GetText();

            checkBox_CreateLogfiles.GetText();

            label_ToolTipDelay.GetText();
            label_Hostname.GetText();
            label_Port.GetText();
            label_Language.GetText();
            label_Name.GetText();
            label_Number.GetText();

            button_SaveRestart.GetText();
            button_Add.GetText();
            button_Change.GetText();
            button_Delete.GetText();
            button_Clear.GetText();

            checkBox_CreateLogfiles.Checked = Config.createlogfiles;

            numericUpDown_Delay.Value = Config.tooltipdelay;

            textBox_Hostname.Text = Config.hostname;
            textBox_Port.Text = Config.port.ToString();

            Dictionary<string, string> languages = new Dictionary<string, string>();
            languages.Add("default", Language.GetString("language_Default"));
            languages.Add("de-DE", Language.GetString("language_german"));
            languages.Add("en-US", Language.GetString("language_english"));

            this.comboBox_Language.SelectedIndexChanged -= new System.EventHandler(this.comboBox_Language_SelectedIndexChanged);
            comboBox_Language.DataSource = new BindingSource(languages, null);
            this.comboBox_Language.SelectedIndexChanged += new System.EventHandler(this.comboBox_Language_SelectedIndexChanged);

            comboBox_Language.DisplayMember = "Value";
            comboBox_Language.ValueMember = "Key";

            comboBox_Language.SelectedValue = Config.language;
            if (comboBox_Language.SelectedIndex < 0) comboBox_Language.SelectedIndex = 0;

            dataGridView1.Columns.Add("Name", Language.GetString("headertext_Name"));
            dataGridView1.Columns.Add("Number", Language.GetString("headertext_Number"));

            dataGridView2.Columns.Add("PhoneID", Language.GetString("headertext_PhoneID"));
            dataGridView2.Columns["PhoneID"].ReadOnly = true;
            dataGridView2.Columns.Add("PhoneName", Language.GetString("headertext_PhoneName"));
        }

        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabpage_General = new System.Windows.Forms.TabPage();
            this.checkBox_CreateLogfiles = new System.Windows.Forms.CheckBox();
            this.numericUpDown_Delay = new System.Windows.Forms.NumericUpDown();
            this.label_ToolTipDelay = new System.Windows.Forms.Label();
            this.button_SaveRestart = new System.Windows.Forms.Button();
            this.label_Language = new System.Windows.Forms.Label();
            this.comboBox_Language = new System.Windows.Forms.ComboBox();
            this.label_Port = new System.Windows.Forms.Label();
            this.label_Hostname = new System.Windows.Forms.Label();
            this.textBox_Port = new System.Windows.Forms.TextBox();
            this.textBox_Hostname = new System.Windows.Forms.TextBox();
            this.tabpage_Phonebook = new System.Windows.Forms.TabPage();
            this.button_Clear = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button_Change = new System.Windows.Forms.Button();
            this.button_Delete = new System.Windows.Forms.Button();
            this.label_Number = new System.Windows.Forms.Label();
            this.label_Name = new System.Windows.Forms.Label();
            this.textBox_Number = new System.Windows.Forms.TextBox();
            this.textBox_Name = new System.Windows.Forms.TextBox();
            this.button_Add = new System.Windows.Forms.Button();
            this.tabpage_Phones = new System.Windows.Forms.TabPage();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.tabpage_General.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Delay)).BeginInit();
            this.tabpage_Phonebook.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabpage_Phones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabpage_General);
            this.tabControl1.Controls.Add(this.tabpage_Phonebook);
            this.tabControl1.Controls.Add(this.tabpage_Phones);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(622, 435);
            this.tabControl1.TabIndex = 9;
            // 
            // tabpage_General
            // 
            this.tabpage_General.BackColor = System.Drawing.SystemColors.Control;
            this.tabpage_General.Controls.Add(this.checkBox_CreateLogfiles);
            this.tabpage_General.Controls.Add(this.numericUpDown_Delay);
            this.tabpage_General.Controls.Add(this.label_ToolTipDelay);
            this.tabpage_General.Controls.Add(this.button_SaveRestart);
            this.tabpage_General.Controls.Add(this.label_Language);
            this.tabpage_General.Controls.Add(this.comboBox_Language);
            this.tabpage_General.Controls.Add(this.label_Port);
            this.tabpage_General.Controls.Add(this.label_Hostname);
            this.tabpage_General.Controls.Add(this.textBox_Port);
            this.tabpage_General.Controls.Add(this.textBox_Hostname);
            this.tabpage_General.Location = new System.Drawing.Point(4, 25);
            this.tabpage_General.Name = "tabpage_General";
            this.tabpage_General.Padding = new System.Windows.Forms.Padding(3);
            this.tabpage_General.Size = new System.Drawing.Size(614, 406);
            this.tabpage_General.TabIndex = 0;
            this.tabpage_General.Text = "tabpage_General";
            // 
            // checkBox_CreateLogfiles
            // 
            this.checkBox_CreateLogfiles.AutoSize = true;
            this.checkBox_CreateLogfiles.Location = new System.Drawing.Point(8, 12);
            this.checkBox_CreateLogfiles.Name = "checkBox_CreateLogfiles";
            this.checkBox_CreateLogfiles.Size = new System.Drawing.Size(189, 21);
            this.checkBox_CreateLogfiles.TabIndex = 25;
            this.checkBox_CreateLogfiles.Text = "checkBox_CreateLogfiles";
            this.checkBox_CreateLogfiles.UseVisualStyleBackColor = true;
            this.checkBox_CreateLogfiles.CheckedChanged += new System.EventHandler(this.checkBox_CreateLogfiles_CheckedChanged);
            // 
            // numericUpDown_Delay
            // 
            this.numericUpDown_Delay.Location = new System.Drawing.Point(356, 10);
            this.numericUpDown_Delay.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_Delay.Name = "numericUpDown_Delay";
            this.numericUpDown_Delay.Size = new System.Drawing.Size(62, 22);
            this.numericUpDown_Delay.TabIndex = 24;
            this.numericUpDown_Delay.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_Delay.ValueChanged += new System.EventHandler(this.numericUpDown_Delay_ValueChanged);
            // 
            // label_ToolTipDelay
            // 
            this.label_ToolTipDelay.AutoSize = true;
            this.label_ToolTipDelay.Location = new System.Drawing.Point(258, 12);
            this.label_ToolTipDelay.Name = "label_ToolTipDelay";
            this.label_ToolTipDelay.Size = new System.Drawing.Size(130, 17);
            this.label_ToolTipDelay.TabIndex = 23;
            this.label_ToolTipDelay.Text = "label_ToolTipDelay";
            // 
            // button_SaveRestart
            // 
            this.button_SaveRestart.Location = new System.Drawing.Point(487, 106);
            this.button_SaveRestart.Margin = new System.Windows.Forms.Padding(5);
            this.button_SaveRestart.Name = "button_SaveRestart";
            this.button_SaveRestart.Size = new System.Drawing.Size(119, 43);
            this.button_SaveRestart.TabIndex = 21;
            this.button_SaveRestart.Text = "button_SaveRestart";
            this.button_SaveRestart.UseVisualStyleBackColor = true;
            this.button_SaveRestart.Click += new System.EventHandler(this.button_SaveExit_Click);
            // 
            // label_Language
            // 
            this.label_Language.AutoSize = true;
            this.label_Language.Location = new System.Drawing.Point(258, 109);
            this.label_Language.Name = "label_Language";
            this.label_Language.Size = new System.Drawing.Size(110, 17);
            this.label_Language.TabIndex = 19;
            this.label_Language.Text = "label_Language";
            // 
            // comboBox_Language
            // 
            this.comboBox_Language.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Language.FormattingEnabled = true;
            this.comboBox_Language.Location = new System.Drawing.Point(356, 106);
            this.comboBox_Language.Margin = new System.Windows.Forms.Padding(5);
            this.comboBox_Language.Name = "comboBox_Language";
            this.comboBox_Language.Size = new System.Drawing.Size(121, 24);
            this.comboBox_Language.TabIndex = 18;
            this.comboBox_Language.SelectedIndexChanged += new System.EventHandler(this.comboBox_Language_SelectedIndexChanged);
            // 
            // label_Port
            // 
            this.label_Port.AutoSize = true;
            this.label_Port.Location = new System.Drawing.Point(258, 77);
            this.label_Port.Name = "label_Port";
            this.label_Port.Size = new System.Drawing.Size(72, 17);
            this.label_Port.TabIndex = 17;
            this.label_Port.Text = "label_Port";
            // 
            // label_Hostname
            // 
            this.label_Hostname.AutoSize = true;
            this.label_Hostname.Location = new System.Drawing.Point(258, 44);
            this.label_Hostname.Name = "label_Hostname";
            this.label_Hostname.Size = new System.Drawing.Size(110, 17);
            this.label_Hostname.TabIndex = 16;
            this.label_Hostname.Text = "label_Hostname";
            // 
            // textBox_Port
            // 
            this.textBox_Port.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Port.Location = new System.Drawing.Point(356, 74);
            this.textBox_Port.Margin = new System.Windows.Forms.Padding(5);
            this.textBox_Port.Name = "textBox_Port";
            this.textBox_Port.Size = new System.Drawing.Size(250, 22);
            this.textBox_Port.TabIndex = 15;
            this.textBox_Port.TextChanged += new System.EventHandler(this.textBox_Port_TextChanged);
            // 
            // textBox_Hostname
            // 
            this.textBox_Hostname.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Hostname.Location = new System.Drawing.Point(356, 41);
            this.textBox_Hostname.Margin = new System.Windows.Forms.Padding(5);
            this.textBox_Hostname.Name = "textBox_Hostname";
            this.textBox_Hostname.Size = new System.Drawing.Size(250, 22);
            this.textBox_Hostname.TabIndex = 14;
            this.textBox_Hostname.TextChanged += new System.EventHandler(this.textBox_Hostname_TextChanged);
            // 
            // tabpage_Phonebook
            // 
            this.tabpage_Phonebook.BackColor = System.Drawing.SystemColors.Control;
            this.tabpage_Phonebook.Controls.Add(this.button_Clear);
            this.tabpage_Phonebook.Controls.Add(this.dataGridView1);
            this.tabpage_Phonebook.Controls.Add(this.button_Change);
            this.tabpage_Phonebook.Controls.Add(this.button_Delete);
            this.tabpage_Phonebook.Controls.Add(this.label_Number);
            this.tabpage_Phonebook.Controls.Add(this.label_Name);
            this.tabpage_Phonebook.Controls.Add(this.textBox_Number);
            this.tabpage_Phonebook.Controls.Add(this.textBox_Name);
            this.tabpage_Phonebook.Controls.Add(this.button_Add);
            this.tabpage_Phonebook.Location = new System.Drawing.Point(4, 25);
            this.tabpage_Phonebook.Name = "tabpage_Phonebook";
            this.tabpage_Phonebook.Padding = new System.Windows.Forms.Padding(3);
            this.tabpage_Phonebook.Size = new System.Drawing.Size(614, 406);
            this.tabpage_Phonebook.TabIndex = 1;
            this.tabpage_Phonebook.Text = "tabpage_Phonebook";
            // 
            // button_Clear
            // 
            this.button_Clear.Location = new System.Drawing.Point(93, 41);
            this.button_Clear.Margin = new System.Windows.Forms.Padding(5);
            this.button_Clear.Name = "button_Clear";
            this.button_Clear.Size = new System.Drawing.Size(75, 23);
            this.button_Clear.TabIndex = 17;
            this.button_Clear.Text = "button_Clear";
            this.button_Clear.UseVisualStyleBackColor = true;
            this.button_Clear.Click += new System.EventHandler(this.button_Clear_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(3, 74);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(5);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.ShowCellErrors = false;
            this.dataGridView1.ShowCellToolTips = false;
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.ShowRowErrors = false;
            this.dataGridView1.Size = new System.Drawing.Size(608, 329);
            this.dataGridView1.TabIndex = 16;
            // 
            // button_Change
            // 
            this.button_Change.Enabled = false;
            this.button_Change.Location = new System.Drawing.Point(93, 8);
            this.button_Change.Margin = new System.Windows.Forms.Padding(5);
            this.button_Change.Name = "button_Change";
            this.button_Change.Size = new System.Drawing.Size(75, 23);
            this.button_Change.TabIndex = 15;
            this.button_Change.Text = "button_Change";
            this.button_Change.UseVisualStyleBackColor = true;
            this.button_Change.Click += new System.EventHandler(this.button_Change_Click);
            // 
            // button_Delete
            // 
            this.button_Delete.Enabled = false;
            this.button_Delete.Location = new System.Drawing.Point(8, 41);
            this.button_Delete.Margin = new System.Windows.Forms.Padding(5);
            this.button_Delete.Name = "button_Delete";
            this.button_Delete.Size = new System.Drawing.Size(75, 23);
            this.button_Delete.TabIndex = 14;
            this.button_Delete.Text = "button_Delete";
            this.button_Delete.UseVisualStyleBackColor = true;
            this.button_Delete.Click += new System.EventHandler(this.button_Delete_Click);
            // 
            // label_Number
            // 
            this.label_Number.AutoSize = true;
            this.label_Number.Location = new System.Drawing.Point(276, 44);
            this.label_Number.Name = "label_Number";
            this.label_Number.Size = new System.Drawing.Size(96, 17);
            this.label_Number.TabIndex = 13;
            this.label_Number.Text = "label_Number";
            // 
            // label_Name
            // 
            this.label_Name.AutoSize = true;
            this.label_Name.Location = new System.Drawing.Point(276, 11);
            this.label_Name.Name = "label_Name";
            this.label_Name.Size = new System.Drawing.Size(83, 17);
            this.label_Name.TabIndex = 12;
            this.label_Name.Text = "label_Name";
            // 
            // textBox_Number
            // 
            this.textBox_Number.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Number.Location = new System.Drawing.Point(356, 41);
            this.textBox_Number.Margin = new System.Windows.Forms.Padding(5);
            this.textBox_Number.Name = "textBox_Number";
            this.textBox_Number.Size = new System.Drawing.Size(250, 22);
            this.textBox_Number.TabIndex = 11;
            this.textBox_Number.TextChanged += new System.EventHandler(this.textBox_Number_TextChanged);
            // 
            // textBox_Name
            // 
            this.textBox_Name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Name.Location = new System.Drawing.Point(356, 8);
            this.textBox_Name.Margin = new System.Windows.Forms.Padding(5);
            this.textBox_Name.Name = "textBox_Name";
            this.textBox_Name.Size = new System.Drawing.Size(250, 22);
            this.textBox_Name.TabIndex = 10;
            this.textBox_Name.TextChanged += new System.EventHandler(this.textBox_Name_TextChanged);
            // 
            // button_Add
            // 
            this.button_Add.Enabled = false;
            this.button_Add.Location = new System.Drawing.Point(8, 8);
            this.button_Add.Margin = new System.Windows.Forms.Padding(5);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(75, 23);
            this.button_Add.TabIndex = 9;
            this.button_Add.Text = "button_Add";
            this.button_Add.UseVisualStyleBackColor = true;
            this.button_Add.Click += new System.EventHandler(this.button_Add_Click);
            // 
            // tabpage_Phones
            // 
            this.tabpage_Phones.BackColor = System.Drawing.SystemColors.Control;
            this.tabpage_Phones.Controls.Add(this.dataGridView2);
            this.tabpage_Phones.Location = new System.Drawing.Point(4, 25);
            this.tabpage_Phones.Name = "tabpage_Phones";
            this.tabpage_Phones.Padding = new System.Windows.Forms.Padding(3);
            this.tabpage_Phones.Size = new System.Drawing.Size(614, 406);
            this.tabpage_Phones.TabIndex = 2;
            this.tabpage_Phones.Text = "tabpage_Phones";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToResizeRows = false;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView2.Location = new System.Drawing.Point(3, 3);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(5);
            this.dataGridView2.MultiSelect = false;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.ShowCellErrors = false;
            this.dataGridView2.ShowCellToolTips = false;
            this.dataGridView2.ShowEditingIcon = false;
            this.dataGridView2.ShowRowErrors = false;
            this.dataGridView2.Size = new System.Drawing.Size(608, 400);
            this.dataGridView2.TabIndex = 0;
            this.dataGridView2.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView2_CellBeginEdit);
            this.dataGridView2.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellEndEdit);
            // 
            // SettingsForm
            // 
            this.ClientSize = new System.Drawing.Size(622, 435);
            this.Controls.Add(this.tabControl1);
            this.Icon = global::NCID_Monitor.Properties.Resources.Icojam_Blue_Bits_Phone;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " - SettingsForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsForm_FormClosing);
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabpage_General.ResumeLayout(false);
            this.tabpage_General.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Delay)).EndInit();
            this.tabpage_Phonebook.ResumeLayout(false);
            this.tabpage_Phonebook.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabpage_Phones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            updateDataGridView1();
            updateDataGridView2();
        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                textBox_Name.Text = dataGridView1.SelectedCells[0].OwningRow.Cells["Name"].Value.ToString();
                textBox_Number.Text = dataGridView1.SelectedCells[0].OwningRow.Cells["Number"].Value.ToString();
                button_Delete.Enabled = true;
                button_Change.Enabled = true;
            }
            else
            {
                button_Delete.Enabled = false;
                button_Change.Enabled = false;
            }
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            if (addEntryToDictionary())
            {
                textBox_Name.Clear();
                textBox_Number.Clear();

                updateDataGridView1();
            }
            else
            {
                MessageBox.Show(Language.GetString("text_already_in_phonebook"));
            }
        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            removeSelectedRowFromDictionary();
            updateDataGridView1();
        }

        private void button_Change_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                //Selected Row Number is Textbox Number
                if (dataGridView1.SelectedCells[0].OwningRow.Cells["Number"].Value.ToString() == textBox_Number.Text)
                {
                    removeSelectedRowFromDictionary();
                    addEntryToDictionary();
                }
                else
                {
                    //Textbox Number elsewhere in Dictionary
                    if (Config.phoneNameDictionary.ContainsKey(textBox_Number.Text))
                    {
                        MessageBox.Show(Language.GetString("text_already_at_other_entry_in_phonebook"));
                    }
                    else
                    {
                        removeSelectedRowFromDictionary();
                        addEntryToDictionary();
                    }
                }

                updateDataGridView1();
            }
        }


        private void button_Clear_Click(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            textBox_Name.Clear();
            textBox_Number.Clear();
        }

        private void textBox_Name_TextChanged(object sender, EventArgs e)
        {
            validateInput();
        }

        private void textBox_Number_TextChanged(object sender, EventArgs e)
        {
            validateInput();
        }

        private void validateInput()
        {
            if (textBox_Name.Text != String.Empty)
            {
                if (textBox_Number.Text != String.Empty)
                {
                    button_Add.Enabled = true;
                    return;
                }
            }

            button_Add.Enabled = false;
        }

        private void updateDataGridView1()
        {
            dataGridView1.SelectionChanged -= new System.EventHandler(this.dataGridView1_SelectionChanged);
            dataGridView1.Rows.Clear();
            foreach (var entry in Config.phoneNameDictionary)
            {
                dataGridView1.Rows.Add(entry.Value, entry.Key);
            }
            dataGridView1.Sort(dataGridView1.Columns["Name"], System.ComponentModel.ListSortDirection.Ascending);
            dataGridView1.ClearSelection();
            dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            dataGridView1_SelectionChanged(null, null);
        }

        private void updateDataGridView2()
        {
            dataGridView2.Rows.Clear();

            foreach (var entry in Config.phoneIDDictionary)
            {
                if ((entry.Key.Length == 1) || entry.Key.StartsWith("0") || entry.Key.StartsWith("5"))
                {
                    dataGridView2.Rows.Add(entry.Key + " (**" + entry.Key + ")", entry.Value);
                }
                else
                {
                    dataGridView2.Rows.Add(entry.Key + " (**6" + entry.Key + ")", entry.Value);
                }
            }

            dataGridView2.ClearSelection();
        }

        private bool addEntryToDictionary()
        {
            if (!Config.phoneNameDictionary.ContainsKey(textBox_Number.Text))
            {
                Config.phoneNameDictionary.Add(textBox_Number.Text, textBox_Name.Text);
                return true;
            }

            return false;
        }

        private bool selectedRowInDictionary()
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                if (Config.phoneNameDictionary.ContainsKey(dataGridView1.SelectedCells[0].OwningRow.Cells["Number"].Value.ToString()))
                {
                    if (Config.phoneNameDictionary[dataGridView1.SelectedCells[0].OwningRow.Cells["Number"].Value.ToString()].ToString() == dataGridView1.SelectedCells[0].OwningRow.Cells["Name"].Value.ToString())
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private void removeSelectedRowFromDictionary()
        {
            if (selectedRowInDictionary())
            {
                Config.phoneNameDictionary.Remove(dataGridView1.SelectedCells[0].OwningRow.Cells["Number"].Value.ToString());
            }
        }

        private void checkBox_CreateLogfiles_CheckedChanged(object sender, EventArgs e)
        {
            Config.createlogfiles = checkBox_CreateLogfiles.Checked;
        }

        private void comboBox_Language_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_Language.SelectedItem != null)
            {
                Config.language = comboBox_Language.SelectedValue.ToString();
            }
        }

        private void numericUpDown_Delay_ValueChanged(object sender, EventArgs e)
        {
            Config.tooltipdelay = Convert.ToInt32(numericUpDown_Delay.Value);
        }

        private void textBox_Hostname_TextChanged(object sender, EventArgs e)
        {
            Config.hostname = textBox_Hostname.Text;
        }

        private void textBox_Port_TextChanged(object sender, EventArgs e)
        {
            int port;

            if (Int32.TryParse(textBox_Port.Text, out port))
            {
                Config.port = port;
            }
        }

        private void button_SaveExit_Click(object sender, EventArgs e)
        {
            MainContext.Exit(true);
        }

        private void dataGridView2_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            tempValue = dataGridView2.Rows[e.RowIndex].Cells["PhoneName"].Value.ToString();
        }

        private void dataGridView2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (Config.phoneIDDictionary.ContainsKey(dataGridView2.Rows[e.RowIndex].Cells["PhoneID"].Value.ToString().Split(' ')[0]))
            {
                Config.phoneIDDictionary.Remove(dataGridView2.Rows[e.RowIndex].Cells["PhoneID"].Value.ToString().Split(' ')[0]);
                Config.phoneIDDictionary.Add(dataGridView2.Rows[e.RowIndex].Cells["PhoneID"].Value.ToString().Split(' ')[0], dataGridView2.Rows[e.RowIndex].Cells["PhoneName"].Value.ToString());
            }
            else
            {
                dataGridView2.Rows[e.RowIndex].Cells["PhoneName"].Value = tempValue;
            }
        }
    }
}
