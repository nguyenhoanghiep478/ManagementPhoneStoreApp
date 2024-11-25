using System.Windows.Forms;

namespace ManagementPhoneStore
{
    partial class ThongKeDoanhThu
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabTheoNam = new System.Windows.Forms.TabPage();
            this.tabTungThang = new System.Windows.Forms.TabPage();
            this.tabTungNgay = new System.Windows.Forms.TabPage();
            this.comboBoxMonth = new System.Windows.Forms.ComboBox();
            this.comboBoxYear = new System.Windows.Forms.ComboBox();
            this.buttonThongKe = new System.Windows.Forms.Button();
            this.buttonXuatExcel = new System.Windows.Forms.Button();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabNgayDenNgay = new System.Windows.Forms.TabPage();
            this.tabControl.SuspendLayout();
            this.tabTungNgay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabTheoNam);
            this.tabControl.Controls.Add(this.tabTungThang);
            this.tabControl.Controls.Add(this.tabTungNgay);
            this.tabControl.Controls.Add(this.tabNgayDenNgay);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(900, 600);
            this.tabControl.TabIndex = 0;
            // 
            // tabTheoNam
            // 
            this.tabTheoNam.Location = new System.Drawing.Point(4, 25);
            this.tabTheoNam.Name = "tabTheoNam";
            this.tabTheoNam.Size = new System.Drawing.Size(892, 571);
            this.tabTheoNam.TabIndex = 0;
            this.tabTheoNam.Text = "Thống kê theo năm";
            this.tabTheoNam.UseVisualStyleBackColor = true;
            // 
            // tabTungThang
            // 
            this.tabTungThang.Location = new System.Drawing.Point(4, 25);
            this.tabTungThang.Name = "tabTungThang";
            this.tabTungThang.Size = new System.Drawing.Size(892, 571);
            this.tabTungThang.TabIndex = 1;
            this.tabTungThang.Text = "Thống kê từng tháng";
            this.tabTungThang.UseVisualStyleBackColor = true;
            // 
            // tabTungNgay
            // 
            this.tabTungNgay.Controls.Add(this.comboBoxMonth);
            this.tabTungNgay.Controls.Add(this.comboBoxYear);
            this.tabTungNgay.Controls.Add(this.buttonThongKe);
            this.tabTungNgay.Controls.Add(this.buttonXuatExcel);
            this.tabTungNgay.Controls.Add(this.chart);
            this.tabTungNgay.Controls.Add(this.dataGridView);
            this.tabTungNgay.Location = new System.Drawing.Point(4, 25);
            this.tabTungNgay.Name = "tabTungNgay";
            this.tabTungNgay.Size = new System.Drawing.Size(892, 571);
            this.tabTungNgay.TabIndex = 2;
            this.tabTungNgay.Text = "Thống kê từng ngày";
            this.tabTungNgay.UseVisualStyleBackColor = true;
            // 
            // comboBoxMonth
            // 
            this.comboBoxMonth.FormattingEnabled = true;
            this.comboBoxMonth.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.comboBoxMonth.Location = new System.Drawing.Point(20, 20);
            this.comboBoxMonth.Name = "comboBoxMonth";
            this.comboBoxMonth.Size = new System.Drawing.Size(120, 24);
            this.comboBoxMonth.TabIndex = 1;
            // 
            // comboBoxYear
            // 
            this.comboBoxYear.FormattingEnabled = true;
            this.comboBoxYear.Items.AddRange(new object[] {
            "2023",
            "2022",
            "2021",
            "2020"});
            this.comboBoxYear.Location = new System.Drawing.Point(160, 20);
            this.comboBoxYear.Name = "comboBoxYear";
            this.comboBoxYear.Size = new System.Drawing.Size(100, 24);
            this.comboBoxYear.TabIndex = 2;
            // 
            // buttonThongKe
            // 
            this.buttonThongKe.Location = new System.Drawing.Point(280, 20);
            this.buttonThongKe.Name = "buttonThongKe";
            this.buttonThongKe.Size = new System.Drawing.Size(100, 30);
            this.buttonThongKe.TabIndex = 3;
            this.buttonThongKe.Text = "Thống kê";
            this.buttonThongKe.UseVisualStyleBackColor = true;
            // 
            // buttonXuatExcel
            // 
            this.buttonXuatExcel.Location = new System.Drawing.Point(400, 20);
            this.buttonXuatExcel.Name = "buttonXuatExcel";
            this.buttonXuatExcel.Size = new System.Drawing.Size(100, 30);
            this.buttonXuatExcel.TabIndex = 4;
            this.buttonXuatExcel.Text = "Xuất Excel";
            this.buttonXuatExcel.UseVisualStyleBackColor = true;
            // 
            // chart
            // 
            this.chart.Location = new System.Drawing.Point(20, 60);
            this.chart.Name = "chart";
            this.chart.Size = new System.Drawing.Size(800, 300);
            this.chart.TabIndex = 5;
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.dataGridView.EnableHeadersVisualStyles = false;
            this.dataGridView.Location = new System.Drawing.Point(20, 367);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.Size = new System.Drawing.Size(800, 204);
            this.dataGridView.TabIndex = 6;
            this.dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill ;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Ngày";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 125;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Vốn";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 125;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Doanh thu";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 125;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Lợi nhuận";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 125;
            // 
            // tabNgayDenNgay
            // 
            this.tabNgayDenNgay.Location = new System.Drawing.Point(4, 25);
            this.tabNgayDenNgay.Name = "tabNgayDenNgay";
            this.tabNgayDenNgay.Size = new System.Drawing.Size(892, 571);
            this.tabNgayDenNgay.TabIndex = 3;
            this.tabNgayDenNgay.Text = "Thống kê từ ngày đến ngày";
            this.tabNgayDenNgay.UseVisualStyleBackColor = true;
            // 
            // ThongKeDoanhThu
            // 
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.tabControl);
            this.Name = "ThongKeDoanhThu";
            this.Text = "Thống Kê Tổng Quan";
            this.tabControl.ResumeLayout(false);
            this.tabTungNgay.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl tabControl;
        private TabPage tabTheoNam;
        private TabPage tabTungThang;
        private TabPage tabTungNgay;
        private TabPage tabNgayDenNgay;

        private ComboBox comboBoxMonth;
        private ComboBox comboBoxYear;
        private Button buttonThongKe;
        private Button buttonXuatExcel;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private DataGridView dataGridView;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
    }
}