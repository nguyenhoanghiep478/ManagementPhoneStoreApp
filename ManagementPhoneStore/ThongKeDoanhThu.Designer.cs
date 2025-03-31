using System;
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
            this.tabNgayDenNgay = new System.Windows.Forms.TabPage();
            this.tabTungNgay = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxMonth = new System.Windows.Forms.ComboBox();
            this.comboBoxYear = new System.Windows.Forms.ComboBox();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonThongKe = new System.Windows.Forms.Button();
            this.buttonXuatExcel = new System.Windows.Forms.Button();
            this.dataGridViewthangInNam = new System.Windows.Forms.DataGridView();
            this.button3 = new System.Windows.Forms.Button();
            this.buttonThongKeThangInNam = new System.Windows.Forms.Button();
            this.buttonXuatExcelThangInNam = new System.Windows.Forms.Button();
            this.comboBoxYearFrom = new System.Windows.Forms.ComboBox();
            this.comboBoxYearTo = new System.Windows.Forms.ComboBox();
            this.comboBoxYearToMonth = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.buttonThongKeNam = new System.Windows.Forms.Button();
            this.buttonXuatExcelNam = new System.Windows.Forms.Button();
            this.chartNam = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartthangInNam = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dataGridViewNam = new System.Windows.Forms.DataGridView();
            this.tabTungThang = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.tabTheoNam = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabTungNgay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewthangInNam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartNam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartthangInNam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNam)).BeginInit();
            this.tabTungThang.SuspendLayout();
            this.tabTheoNam.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabNgayDenNgay
            // 
            this.tabNgayDenNgay.Location = new System.Drawing.Point(4, 25);
            this.tabNgayDenNgay.Name = "tabNgayDenNgay";
            this.tabNgayDenNgay.Size = new System.Drawing.Size(1090, 703);
            this.tabNgayDenNgay.TabIndex = 3;
            this.tabNgayDenNgay.Text = "Thống kê từ ngày đến ngày";
            this.tabNgayDenNgay.UseVisualStyleBackColor = true;
            // 
            // tabTungNgay
            // 
            this.tabTungNgay.Controls.Add(this.label2);
            this.tabTungNgay.Controls.Add(this.label1);
            this.tabTungNgay.Controls.Add(this.comboBoxMonth);
            this.tabTungNgay.Controls.Add(this.comboBoxYear);
            this.tabTungNgay.Controls.Add(this.chart);
            this.tabTungNgay.Controls.Add(this.dataGridView);
            this.tabTungNgay.Controls.Add(this.button1);
            this.tabTungNgay.Controls.Add(this.buttonThongKe);
            this.tabTungNgay.Controls.Add(this.buttonXuatExcel);
            this.tabTungNgay.Location = new System.Drawing.Point(4, 25);
            this.tabTungNgay.Name = "tabTungNgay";
            this.tabTungNgay.Size = new System.Drawing.Size(1467, 744);
            this.tabTungNgay.TabIndex = 2;
            this.tabTungNgay.Text = "Thống kê từng ngày trong tháng";
            this.tabTungNgay.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(365, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Chọn năm";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(133, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Chọn tháng";
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
            this.comboBoxMonth.Location = new System.Drawing.Point(213, 20);
            this.comboBoxMonth.Name = "comboBoxMonth";
            this.comboBoxMonth.Size = new System.Drawing.Size(120, 24);
            this.comboBoxMonth.TabIndex = 1;
            this.comboBoxMonth.SelectedIndexChanged += new System.EventHandler(this.comboBoxMonth_SelectedIndexChanged);
            // 
            // comboBoxYear
            // 
            this.comboBoxYear.Location = new System.Drawing.Point(438, 20);
            this.comboBoxYear.Name = "comboBoxYear";
            this.comboBoxYear.Size = new System.Drawing.Size(100, 24);
            this.comboBoxYear.TabIndex = 2;
            // 
            // chart
            // 
            this.chart.Location = new System.Drawing.Point(20, 81);
            this.chart.Name = "chart";
            this.chart.Size = new System.Drawing.Size(1425, 292);
            this.chart.TabIndex = 5;
            this.chart.Click += new System.EventHandler(this.chart_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.EnableHeadersVisualStyles = false;
            this.dataGridView.Location = new System.Drawing.Point(15, 389);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.Size = new System.Drawing.Size(1430, 328);
            this.dataGridView.TabIndex = 6;
            this.dataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellContentClick_1);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(665, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 43);
            this.button1.TabIndex = 9;
            this.button1.Text = "Làm mới";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonThongKe
            // 
            this.buttonThongKe.Location = new System.Drawing.Point(559, 10);
            this.buttonThongKe.Name = "buttonThongKe";
            this.buttonThongKe.Size = new System.Drawing.Size(100, 43);
            this.buttonThongKe.TabIndex = 3;
            this.buttonThongKe.Text = "Thống kê";
            this.buttonThongKe.UseVisualStyleBackColor = true;
            this.buttonThongKe.Click += new System.EventHandler(this.buttonThongKe_Click);
            // 
            // buttonXuatExcel
            // 
            this.buttonXuatExcel.Location = new System.Drawing.Point(773, 10);
            this.buttonXuatExcel.Name = "buttonXuatExcel";
            this.buttonXuatExcel.Size = new System.Drawing.Size(100, 43);
            this.buttonXuatExcel.TabIndex = 4;
            this.buttonXuatExcel.Text = "Xuất Excel";
            this.buttonXuatExcel.UseVisualStyleBackColor = true;
            this.buttonXuatExcel.Click += new System.EventHandler(this.buttonXuatExcel_Click);
            // 
            // dataGridViewthangInNam
            // 
            this.dataGridViewthangInNam.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewthangInNam.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewthangInNam.EnableHeadersVisualStyles = false;
            this.dataGridViewthangInNam.Location = new System.Drawing.Point(25, 408);
            this.dataGridViewthangInNam.Name = "dataGridViewthangInNam";
            this.dataGridViewthangInNam.RowHeadersWidth = 51;
            this.dataGridViewthangInNam.RowTemplate.Height = 24;
            this.dataGridViewthangInNam.Size = new System.Drawing.Size(1425, 328);
            this.dataGridViewthangInNam.TabIndex = 6;
            this.dataGridViewthangInNam.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellContentClick_1);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(592, 16);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 38);
            this.button3.TabIndex = 9;
            this.button3.Text = "Làm mới";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // buttonThongKeThangInNam
            // 
            this.buttonThongKeThangInNam.Location = new System.Drawing.Point(469, 16);
            this.buttonThongKeThangInNam.Name = "buttonThongKeThangInNam";
            this.buttonThongKeThangInNam.Size = new System.Drawing.Size(100, 38);
            this.buttonThongKeThangInNam.TabIndex = 3;
            this.buttonThongKeThangInNam.Text = "Thống kê";
            this.buttonThongKeThangInNam.UseVisualStyleBackColor = true;
            this.buttonThongKeThangInNam.Click += new System.EventHandler(this.buttonThongKeThangInNam_Click);
            // 
            // buttonXuatExcelThangInNam
            // 
            this.buttonXuatExcelThangInNam.Location = new System.Drawing.Point(713, 16);
            this.buttonXuatExcelThangInNam.Name = "buttonXuatExcelThangInNam";
            this.buttonXuatExcelThangInNam.Size = new System.Drawing.Size(100, 38);
            this.buttonXuatExcelThangInNam.TabIndex = 4;
            this.buttonXuatExcelThangInNam.Text = "Xuất Excel";
            this.buttonXuatExcelThangInNam.UseVisualStyleBackColor = true;
            this.buttonXuatExcelThangInNam.Click += new System.EventHandler(this.buttonXuatExcelThangInNam_Click);
            // 
            // comboBoxYearFrom
            // 
            this.comboBoxYearFrom.Location = new System.Drawing.Point(211, 27);
            this.comboBoxYearFrom.Name = "comboBoxYearFrom";
            this.comboBoxYearFrom.Size = new System.Drawing.Size(107, 24);
            this.comboBoxYearFrom.TabIndex = 7;
            this.comboBoxYearFrom.SelectedIndexChanged += new System.EventHandler(this.comboBoxYearFrom_SelectedIndexChanged);
            // 
            // comboBoxYearTo
            // 
            this.comboBoxYearTo.Location = new System.Drawing.Point(418, 27);
            this.comboBoxYearTo.Name = "comboBoxYearTo";
            this.comboBoxYearTo.Size = new System.Drawing.Size(100, 24);
            this.comboBoxYearTo.TabIndex = 8;
            this.comboBoxYearTo.SelectedIndexChanged += new System.EventHandler(this.comboBoxYearTo_SelectedIndexChanged);
            // 
            // comboBoxYearToMonth
            // 
            this.comboBoxYearToMonth.Location = new System.Drawing.Point(312, 20);
            this.comboBoxYearToMonth.Name = "comboBoxYearToMonth";
            this.comboBoxYearToMonth.Size = new System.Drawing.Size(107, 24);
            this.comboBoxYearToMonth.TabIndex = 7;
            this.comboBoxYearToMonth.SelectedIndexChanged += new System.EventHandler(this.comboBoxYearFrom_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(665, 16);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 44);
            this.button2.TabIndex = 9;
            this.button2.Text = "Làm mới";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonThongKeNam
            // 
            this.buttonThongKeNam.Location = new System.Drawing.Point(559, 16);
            this.buttonThongKeNam.Name = "buttonThongKeNam";
            this.buttonThongKeNam.Size = new System.Drawing.Size(100, 44);
            this.buttonThongKeNam.TabIndex = 3;
            this.buttonThongKeNam.Text = "Thống kê";
            this.buttonThongKeNam.UseVisualStyleBackColor = true;
            this.buttonThongKeNam.Click += new System.EventHandler(this.buttonThongKeNam_Click);
            // 
            // buttonXuatExcelNam
            // 
            this.buttonXuatExcelNam.Location = new System.Drawing.Point(773, 16);
            this.buttonXuatExcelNam.Name = "buttonXuatExcelNam";
            this.buttonXuatExcelNam.Size = new System.Drawing.Size(100, 44);
            this.buttonXuatExcelNam.TabIndex = 4;
            this.buttonXuatExcelNam.Text = "Xuất Excel";
            this.buttonXuatExcelNam.UseVisualStyleBackColor = true;
            this.buttonXuatExcelNam.Click += new System.EventHandler(this.buttonXuatExcelNam_Click);
            // 
            // chartNam
            // 
            this.chartNam.Location = new System.Drawing.Point(18, 80);
            this.chartNam.Name = "chartNam";
            this.chartNam.Size = new System.Drawing.Size(1427, 300);
            this.chartNam.TabIndex = 0;
            this.chartNam.Click += new System.EventHandler(this.chartNam_Click);
            // 
            // chartthangInNam
            // 
            this.chartthangInNam.Location = new System.Drawing.Point(20, 92);
            this.chartthangInNam.Name = "chartthangInNam";
            this.chartthangInNam.Size = new System.Drawing.Size(1425, 300);
            this.chartthangInNam.TabIndex = 0;
            this.chartthangInNam.Click += new System.EventHandler(this.chartNam_Click);
            // 
            // dataGridViewNam
            // 
            this.dataGridViewNam.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewNam.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewNam.EnableHeadersVisualStyles = false;
            this.dataGridViewNam.Location = new System.Drawing.Point(20, 399);
            this.dataGridViewNam.Name = "dataGridViewNam";
            this.dataGridViewNam.RowHeadersWidth = 51;
            this.dataGridViewNam.RowTemplate.Height = 24;
            this.dataGridViewNam.Size = new System.Drawing.Size(1425, 328);
            this.dataGridViewNam.TabIndex = 6;
            this.dataGridViewNam.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellContentClick_1);
            // 
            // tabTungThang
            // 
            this.tabTungThang.Controls.Add(this.label5);
            this.tabTungThang.Controls.Add(this.chartthangInNam);
            this.tabTungThang.Controls.Add(this.dataGridViewthangInNam);
            this.tabTungThang.Controls.Add(this.comboBoxYearToMonth);
            this.tabTungThang.Controls.Add(this.button3);
            this.tabTungThang.Controls.Add(this.buttonThongKeThangInNam);
            this.tabTungThang.Controls.Add(this.buttonXuatExcelThangInNam);
            this.tabTungThang.Location = new System.Drawing.Point(4, 25);
            this.tabTungThang.Name = "tabTungThang";
            this.tabTungThang.Size = new System.Drawing.Size(1467, 744);
            this.tabTungThang.TabIndex = 1;
            this.tabTungThang.Text = "Thống kê từng tháng trong năm";
            this.tabTungThang.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(185, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "Chọn năm thống kê";
            // 
            // tabTheoNam
            // 
            this.tabTheoNam.Controls.Add(this.label4);
            this.tabTheoNam.Controls.Add(this.label3);
            this.tabTheoNam.Controls.Add(this.chartNam);
            this.tabTheoNam.Controls.Add(this.dataGridViewNam);
            this.tabTheoNam.Controls.Add(this.comboBoxYearFrom);
            this.tabTheoNam.Controls.Add(this.comboBoxYearTo);
            this.tabTheoNam.Controls.Add(this.button2);
            this.tabTheoNam.Controls.Add(this.buttonThongKeNam);
            this.tabTheoNam.Controls.Add(this.buttonXuatExcelNam);
            this.tabTheoNam.Location = new System.Drawing.Point(4, 25);
            this.tabTheoNam.Name = "tabTheoNam";
            this.tabTheoNam.Padding = new System.Windows.Forms.Padding(3);
            this.tabTheoNam.Size = new System.Drawing.Size(1467, 744);
            this.tabTheoNam.TabIndex = 0;
            this.tabTheoNam.Text = "Thống kê theo năm";
            this.tabTheoNam.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(153, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = "Từ năm";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(352, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Đến năm";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabTheoNam);
            this.tabControl.Controls.Add(this.tabTungThang);
            this.tabControl.Controls.Add(this.tabTungNgay);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1475, 773);
            this.tabControl.TabIndex = 0;
            this.tabControl.Dock = DockStyle.Fill; // Đảm bảo TabControl chiếm toàn bộ form
            this.tabTheoNam.Dock = DockStyle.Fill;
            this.tabTungNgay.Dock = DockStyle.Fill;
            this.tabTungThang.Dock = DockStyle.Fill;

     
            // 
            // ThongKeDoanhThu
            // 
            this.ClientSize = new System.Drawing.Size(1475, 773);
            this.Controls.Add(this.tabControl);
            this.Name = "ThongKeDoanhThu";
            this.Text = "Thống Kê Doanh Thu";
            this.tabTungNgay.ResumeLayout(false);
            this.tabTungNgay.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewthangInNam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartNam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartthangInNam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNam)).EndInit();
            this.tabTungThang.ResumeLayout(false);
            this.tabTungThang.PerformLayout();
            this.tabTheoNam.ResumeLayout(false);
            this.tabTheoNam.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TabPage tabNgayDenNgay;
        private TabPage tabTungNgay;
        private Label label2;
        private Label label1;
        private ComboBox comboBoxMonth;
        private ComboBox comboBoxYear;
        private ComboBox comboBoxYearTo;
        private ComboBox comboBoxYearFrom;
        private ComboBox comboBoxYearToMonth;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartNam;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartthangInNam;
        private DataGridView dataGridView;
        private System.Windows.Forms.DataGridView dataGridViewNam;
        private System.Windows.Forms.DataGridView dataGridViewthangInNam;
        private TabPage tabTungThang;
        private TabPage tabTheoNam;
        private TabControl tabControl;
        private Button button1;
        private Button buttonThongKe;
        private Button buttonXuatExcel;
        private Button button2;
        private Button buttonThongKeNam;
        private Button buttonXuatExcelNam;
        private Button button3;
        private Button buttonThongKeThangInNam;
        private Button buttonXuatExcelThangInNam;
        private Label label4;
        private Label label3;
        private Label label5;
    }
}