using System.Drawing;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Drawing.Charts;

using System.Windows.Controls;
namespace ManagementPhoneStore
{
    partial class ThongKeTongQuanGUI
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
            this.overviewPanel = new System.Windows.Forms.Panel();
            this.chartPanel = new System.Windows.Forms.Panel();
            this.dataGridPanel = new System.Windows.Forms.Panel();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comboBoxMonth = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxYear = new System.Windows.Forms.ComboBox();
            this.dataGridPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // overviewPanel
            // 
            this.overviewPanel.BackColor = System.Drawing.Color.White;
            this.overviewPanel.Location = new System.Drawing.Point(13, 12);
            this.overviewPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.overviewPanel.Name = "overviewPanel";
            this.overviewPanel.Size = new System.Drawing.Size(1173, 123);
            this.overviewPanel.TabIndex = 0;
            this.overviewPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.overviewPanel_Paint_2);
            // 
            // chartPanel
            // 
            this.chartPanel.BackColor = System.Drawing.Color.White;
            this.chartPanel.Location = new System.Drawing.Point(13, 148);
            this.chartPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chartPanel.Name = "chartPanel";
            this.chartPanel.Size = new System.Drawing.Size(1173, 369);
            this.chartPanel.TabIndex = 1;
            this.chartPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.chartPanel_Paint);
            // 
            // dataGridPanel
            // 
            this.dataGridPanel.BackColor = System.Drawing.Color.White;
            this.dataGridPanel.Controls.Add(this.dataGridView);
            this.dataGridPanel.Location = new System.Drawing.Point(13, 529);
            this.dataGridPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridPanel.Name = "dataGridPanel";
            this.dataGridPanel.Size = new System.Drawing.Size(1173, 148);
            this.dataGridPanel.TabIndex = 2;
            // 
            // dataGridView
            // 
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.Size = new System.Drawing.Size(1173, 148);
            this.dataGridView.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Ngày";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Vốn";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Doanh thu";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Lợi nhuận";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // comboBoxMonth
            // 
            this.comboBoxMonth.FormattingEnabled = true;
            this.comboBoxMonth.Location = new System.Drawing.Point(1195, 34);
            this.comboBoxMonth.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxMonth.Name = "comboBoxMonth";
            this.comboBoxMonth.Size = new System.Drawing.Size(160, 24);
            this.comboBoxMonth.TabIndex = 3;
            this.comboBoxMonth.SelectedIndexChanged += new System.EventHandler(this.comboBoxMonth_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1195, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Tháng";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1195, 71);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Năm";
            this.label2.UseWaitCursor = true;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // comboBoxYear
            // 
            this.comboBoxYear.FormattingEnabled = true;
            this.comboBoxYear.Location = new System.Drawing.Point(1195, 95);
            this.comboBoxYear.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxYear.Name = "comboBoxYear";
            this.comboBoxYear.Size = new System.Drawing.Size(160, 24);
            this.comboBoxYear.TabIndex = 5;
            this.comboBoxYear.Text = "Năm";
            this.comboBoxYear.UseWaitCursor = true;
            this.comboBoxYear.SelectedIndexChanged += new System.EventHandler(this.comboBoxYear_SelectedIndexChanged);
            // 
            // ThongKeTongQuanGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1384, 702);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxYear);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxMonth);
            this.Controls.Add(this.dataGridPanel);
            this.Controls.Add(this.chartPanel);
            this.Controls.Add(this.overviewPanel);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ThongKeTongQuanGUI";
            this.Text = "Thống Kê Tổng Quan";
            this.Load += new System.EventHandler(this.ThongKe_Load);
            this.dataGridPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Panel CreateGUISummaryBox(string title, string value, string iconPath, int x)
        {
            System.Windows.Forms.Panel summaryBox = new System.Windows.Forms.Panel
            {
                Size = new System.Drawing.Size(250, 80),
                Location = new Point(x, 10),
                BackColor = Color.LightBlue,
                BorderStyle = BorderStyle.FixedSingle
            };

            PictureBox icon = new PictureBox
            {
                Size = new System.Drawing.Size(40, 40),
                Location = new Point(10, 20),
                ImageLocation = iconPath,
                SizeMode = PictureBoxSizeMode.Zoom
            };

            System.Windows.Forms.Label titleLabel = new System.Windows.Forms.Label
            {
                Text = title,
                Location = new Point(60, 10),
                Font = new Font("Arial", 9, FontStyle.Bold),
                AutoSize = true
            };

            System.Windows.Forms.Label valueLabel = new System.Windows.Forms.Label
            {
                Text = value,
                Location = new Point(60, 35),
                Font = new Font("Arial", 12, FontStyle.Bold),
                ForeColor = Color.DarkBlue,
                AutoSize = true
            };

            summaryBox.Controls.Add(icon);
            summaryBox.Controls.Add(titleLabel);
            summaryBox.Controls.Add(valueLabel);

            return summaryBox;
        }

       


        

       


     
        #endregion

        private System.Windows.Forms.Panel overviewPanel;
        private System.Windows.Forms.Panel chartPanel;
        private System.Windows.Forms.Panel dataGridPanel;
        private System.Windows.Forms.DataGridView dataGridView;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.ComboBox comboBoxMonth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxYear;
        private System.Windows.Forms.TabControl tabControl1;
    }
}