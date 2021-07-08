using System;
using System.IO;
using System.Windows.Forms;

namespace NCID_Monitor
{
    public class LogForm : Form
    {
        private DataGridView dataGridView1;
        private ListBox logBox;

        private bool update_active = false;

        private delegate void SafeCallDelegate(string message);

        public LogForm()
        {
            InitializeComponent();

            Text = Program.AppName + " - LogForm";

            //dataGridView1.Columns.Add(new DataGridViewImageColumn(true));
            dataGridView1.Columns.Add(new DataGridViewImageColumn(false));
            dataGridView1.Columns.Add("CallTime", Language.GetString("headertext_Calltime"));
            dataGridView1.Columns.Add("Line", Language.GetString("headertext_Line"));
            dataGridView1.Columns.Add("PhoneName", Language.GetString("headertext_PhoneName"));
            dataGridView1.Columns.Add("PhoneID", Language.GetString("headertext_PhoneID"));
            dataGridView1.Columns.Add("LocalName", Language.GetString("headertext_LocalName"));
            dataGridView1.Columns.Add("LocalNR", Language.GetString("headertext_LocalNR"));
            dataGridView1.Columns.Add("RemoteName", Language.GetString("headertext_RemoteName"));
            dataGridView1.Columns.Add("RemoteNR", Language.GetString("headertext_RemoteNR"));
            dataGridView1.Columns.Add("Duration", Language.GetString("headertext_Duration"));

            dataGridView1.Columns[0].MinimumWidth = 20;
            dataGridView1.Columns[0].Width = 20;
            dataGridView1.Columns[0].FillWeight = 1;
            dataGridView1.Columns["CallTime"].MinimumWidth = 135;
            dataGridView1.Columns["CallTime"].Width = 135;
            dataGridView1.Columns["CallTime"].FillWeight = 10;
            dataGridView1.Columns["Line"].Visible = false;
            dataGridView1.Columns["Line"].FillWeight = 1;
            dataGridView1.Columns["PhoneName"].MinimumWidth = 110;
            dataGridView1.Columns["PhoneName"].Width = 110;
            dataGridView1.Columns["PhoneName"].FillWeight = 250;
            dataGridView1.Columns["PhoneID"].Visible = false;
            dataGridView1.Columns["PhoneID"].FillWeight = 1;
            dataGridView1.Columns["LocalName"].MinimumWidth = 135;
            dataGridView1.Columns["LocalName"].Width = 140;
            dataGridView1.Columns["LocalName"].FillWeight = 500;
            dataGridView1.Columns["LocalNR"].Visible = false;
            dataGridView1.Columns["LocalNR"].FillWeight = 1;
            dataGridView1.Columns["RemoteName"].MinimumWidth = 135;
            dataGridView1.Columns["RemoteName"].FillWeight = 1000;
            dataGridView1.Columns["RemoteNR"].Visible = false;
            dataGridView1.Columns["RemoteNR"].FillWeight = 1;
            dataGridView1.Columns["Duration"].MinimumWidth = 80;
            dataGridView1.Columns["Duration"].Width = 80;
            dataGridView1.Columns["Duration"].FillWeight = 10;

            logBox.RemoveFocusRectangle();
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.logBox = new System.Windows.Forms.ListBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // logBox
            // 
            this.logBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.logBox.FormattingEnabled = true;
            this.logBox.IntegralHeight = false;
            this.logBox.ItemHeight = 16;
            this.logBox.Location = new System.Drawing.Point(9, 314);
            this.logBox.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.logBox.Name = "logBox";
            this.logBox.Size = new System.Drawing.Size(604, 112);
            this.logBox.TabIndex = 0;
            this.logBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.logBox_MouseUp);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(9, 9);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 20;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.ShowCellErrors = false;
            this.dataGridView1.ShowCellToolTips = false;
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.ShowRowErrors = false;
            this.dataGridView1.Size = new System.Drawing.Size(604, 299);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            // 
            // LogForm
            // 
            this.ClientSize = new System.Drawing.Size(622, 435);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.logBox);
            this.Icon = global::NCID_Monitor.Properties.Resources.Icojam_Blue_Bits_Phone;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "LogForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " - LogForm";
            this.Activated += new System.EventHandler(this.LogForm_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LogForm_FormClosing);
            this.Load += new System.EventHandler(this.LogForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        private void LogForm_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoResizeColumns();
        }

        private void LogForm_Activated(object sender, EventArgs e)
        {
            updateDataGridView();
        }

        private void LogForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        public void updateDataGridView()
        {
            update_active = true;

            dataGridView1.Rows.Clear();

            foreach (Call call in Calllist.calllist)
            {
                //dataGridView1.Rows.Add(call.Icon, call.CallTime, call.Line, Functions.getPhoneID(call.PhoneID), call.PhoneID, Functions.getPhoneName(call.LocalNR), call.LocalNR, Functions.getPhoneName(call.RemoteNR), call.RemoteNR, call.Duration);
                dataGridView1.Rows.Add(call.Icon.ToBitmap(), call.CallTime, call.Line, Functions.getPhoneID(call.PhoneID), call.PhoneID, Functions.getPhoneName(call.LocalNR), call.LocalNR, Functions.getPhoneName(call.RemoteNR), call.RemoteNR, call.Duration);
            }

            dataGridView1.ClearSelection();

            update_active = false;
        }

        private void logBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                logBox.Items.Clear();
            }
        }

        public void AddMessage(string message)
        {
            if (logBox.InvokeRequired)
            {
                var d = new SafeCallDelegate(AddMessage);
                logBox.Invoke(d, new object[] { message });
            }
            else
            {
                Calllist.processMessage(message.RemoveHashs());
                updateDataGridView();
                logBox.Items.Add(message);
                if (Config.createlogfiles)
                {
                    SaveMessage(message);
                }
            }
        }

        private void SaveMessage(string message)
        {
            string filename = Path.ChangeExtension(Path.Combine(Config.path, DateTime.Now.ToString("yyyy-MM-dd")), ".log");

            using (StreamWriter streamWriter = File.AppendText(filename))
            {
                streamWriter.WriteLine(message.TrimEnd('\r', '\n'));
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (    
                (e.ColumnIndex == dataGridView1.Columns["PhoneName"].Index) || 
                (e.ColumnIndex == dataGridView1.Columns["LocalName"].Index) || 
                (e.ColumnIndex == dataGridView1.Columns["RemoteName"].Index)
                )
            {
                dataGridView1.BeginEdit(true);
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (update_active) return;

            if (e.ColumnIndex == dataGridView1.Columns["PhoneName"].Index)
            {
                Functions.changePhoneDeviceName(dataGridView1.Rows[e.RowIndex].Cells["PhoneID"].Value.ToString(), dataGridView1.Rows[e.RowIndex].Cells["PhoneName"].Value.ToString());
            }
            else if (e.ColumnIndex == dataGridView1.Columns["LocalName"].Index)
            {
                Functions.changePhoneName(dataGridView1.Rows[e.RowIndex].Cells["LocalNR"].Value.ToString(), dataGridView1.Rows[e.RowIndex].Cells["LocalName"].Value.ToString());
            }
            else if (e.ColumnIndex == dataGridView1.Columns["RemoteName"].Index)
            {
                Functions.changePhoneName(dataGridView1.Rows[e.RowIndex].Cells["RemoteNR"].Value.ToString(), dataGridView1.Rows[e.RowIndex].Cells["RemoteName"].Value.ToString());
            }

            updateDataGridView();
        }
    }
}
