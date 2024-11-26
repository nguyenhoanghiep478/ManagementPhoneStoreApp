using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using Service;

namespace ManagementPhoneStore
{
    public partial class ThongKeDoanhThu : UserControl
    {
        private ThongKeService thongKeService = ThongKeService.Instance;
        private List<ThongKeTungNgayTrongThangDTO> thongKeTungNgayTrongThangs;
        private List<ThongKeDoanhThuDTO> thongKeYearToYear;
        private List<ThongKeTheoThangDTO> thongKeMonthInYear;
        int month = DateTime.Now.Month;
        int year = DateTime.Now.Year;
        int yearFrom = DateTime.Now.Year;
        int yearTo = DateTime.Now.Year;
        int monthInYear = DateTime.Now.Year;
        public ThongKeDoanhThu()
        {
            
            this.Dock = DockStyle.Fill;
            InitializeComponent();
            LoadYearCombobox();
            LoadDataDateInMonth();
            LoadDataYearToYear();
            LoadDataMonthInYear();
        }

        private void LoadDataMonthInYear()
        {
            this.comboBoxYearToMonth.SelectedItem = monthInYear;
            thongKeMonthInYear = thongKeService.GetThongKeTheoThang(monthInYear);
            this.thongKeMonthInYear.Sort((a, b) => a.Thang.CompareTo(b.Thang));
            LoadDataGridViewMonthInYear();
            LoadChartDataMonthInYear();
        }
        private void LoadDataGridViewMonthInYear()
        {
            this.dataGridViewthangInNam.DataSource = thongKeMonthInYear;
            AdjustDataGridViewHeight(dataGridViewthangInNam);
        }
        private void LoadChartDataMonthInYear()
        {
            this.chartthangInNam.Series.Clear();

            if (chartthangInNam.ChartAreas.Count == 0)
            {
                chartthangInNam.ChartAreas.Add(new System.Windows.Forms.DataVisualization.Charting.ChartArea("Default"));
            }
            var seriesVon = new System.Windows.Forms.DataVisualization.Charting.Series("Vốn")
            {
                ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column
            };
            var seriesDoanhThu = new System.Windows.Forms.DataVisualization.Charting.Series("Doanh thu")
            {
                ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column
            };
            var seriesLoiNhuan = new System.Windows.Forms.DataVisualization.Charting.Series("Lợi nhuận")
            {
                ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column
            };

            if (thongKeMonthInYear == null || thongKeMonthInYear.Count == 0)
            {
                return;
            }

            foreach (var item in thongKeMonthInYear)
            {
                seriesVon.Points.AddXY(item.Thang, item.Chiphi);
                seriesDoanhThu.Points.AddXY(item.Thang, item.DoanhthuThang);
                seriesLoiNhuan.Points.AddXY(item.Thang, item.LoinhuanThang);
            }

            this.chartthangInNam.Series.Add(seriesVon);
            this.chartthangInNam.Series.Add(seriesDoanhThu);
            this.chartthangInNam.Series.Add(seriesLoiNhuan);


            this.chartthangInNam.ChartAreas[0].AxisX.Title = "Tháng";
            this.chartthangInNam.ChartAreas[0].AxisY.Title = "Số tiền (VNĐ)";
            this.chartthangInNam.ChartAreas[0].AxisX.Interval = 1;
            chartthangInNam.ChartAreas[0].AxisY.Minimum = Double.NaN; 
            chartthangInNam.ChartAreas[0].AxisY.Maximum = Double.NaN; 
            chartthangInNam.ChartAreas[0].RecalculateAxesScale(); 
            chartthangInNam.Invalidate();
        }

        private void LoadDataDateInMonth()
        {
            this.comboBoxMonth.SelectedIndex = month - 1;
            this.comboBoxYear.SelectedItem = year;
            this.thongKeTungNgayTrongThangs = thongKeService.GetThongKeTungNgayTrongThang(month,year);
            LoadDataGridView();
            LoadDataChart();
           
   
        }
        private void LoadYearCombobox()
        {
           for(int i = 0; i < 7; i++)
            {
                this.comboBoxYear.Items.Add(year - i);
                this.comboBoxYearFrom.Items.Add(year - i);
                this.comboBoxYearTo.Items.Add(year - i);
                this.comboBoxYearToMonth.Items.Add(year - i);
            }
        }

        private void LoadDataYearToYear()
        {
            this.thongKeYearToYear = thongKeService.GetDoanhThuTheoTungNam(yearFrom, yearTo);
            this.comboBoxYearFrom.SelectedItem = yearFrom;
            this.comboBoxYearTo.SelectedItem = yearTo;
            LoadDataGridViewNam();
            LoadChartNam();
        }

        private void LoadDataGridViewNam()
        {
            dataGridViewNam.DataSource = thongKeYearToYear;
            AdjustDataGridViewHeight(dataGridViewNam);
        }

        private void LoadChartNam()
        {
            chartNam.Series.Clear();

            if (chartNam.ChartAreas.Count == 0)
            {
                chartNam.ChartAreas.Add(new System.Windows.Forms.DataVisualization.Charting.ChartArea("Default"));
            }
            var seriesVon = new System.Windows.Forms.DataVisualization.Charting.Series("Vốn")
            {
                ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column
            };
            var seriesDoanhThu = new System.Windows.Forms.DataVisualization.Charting.Series("Doanh thu")
            {
                ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column
            };
            var seriesLoiNhuan = new System.Windows.Forms.DataVisualization.Charting.Series("Lợi nhuận")
            {
                ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column
            };

            if (thongKeYearToYear == null || thongKeYearToYear.Count == 0)
            {
                return;
            }

            foreach (var item in thongKeYearToYear)
            {
                seriesVon.Points.AddXY(item.Thoigian, item.Von);
                seriesDoanhThu.Points.AddXY(item.Thoigian, item.Doanhthu);
                seriesLoiNhuan.Points.AddXY(item.Thoigian, item.Loinhuan);
            }

            chartNam.Series.Add(seriesVon);
            chartNam.Series.Add(seriesDoanhThu);
            chartNam.Series.Add(seriesLoiNhuan);


            chartNam.ChartAreas[0].AxisX.Title = "Ngày";
            chartNam.ChartAreas[0].AxisY.Title = "Số tiền (VNĐ)";
            chartNam.ChartAreas[0].AxisX.Interval = 1;
        }

        private void LoadDataGridView()
        {
         
                dataGridView.DataSource = thongKeTungNgayTrongThangs;
                 AdjustDataGridViewHeight(dataGridView);
            
        }

        private void LoadDataChart()
        {
            chart.Series.Clear();

            if (chart.ChartAreas.Count == 0)
            {
                chart.ChartAreas.Add(new System.Windows.Forms.DataVisualization.Charting.ChartArea("Default"));
            }
            var seriesVon = new System.Windows.Forms.DataVisualization.Charting.Series("Vốn")
            {
                ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column
            };
            var seriesDoanhThu = new System.Windows.Forms.DataVisualization.Charting.Series("Doanh thu")
            {
                ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column
            };
            var seriesLoiNhuan = new System.Windows.Forms.DataVisualization.Charting.Series("Lợi nhuận")
            {
                ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column
            };

            if (thongKeTungNgayTrongThangs == null || thongKeTungNgayTrongThangs.Count == 0)
            {
                return;
            }

            foreach (var item in thongKeTungNgayTrongThangs)
            {
                seriesVon.Points.AddXY(item.Ngay, item.Chiphi);
                seriesDoanhThu.Points.AddXY(item.Ngay, item.DoanhthuNgay);
                seriesLoiNhuan.Points.AddXY(item.Ngay, item.LoinhuanNgay);
            }

            chart.Series.Add(seriesVon);
            chart.Series.Add(seriesDoanhThu);
            chart.Series.Add(seriesLoiNhuan);

         
            chart.ChartAreas[0].AxisX.Title = "Ngày";
            chart.ChartAreas[0].AxisY.Title = "Số tiền (VNĐ)";
            chart.ChartAreas[0].AxisX.Interval = 1;
            chart.ChartAreas[0].AxisY.Minimum = Double.NaN;
            chart.ChartAreas[0].AxisY.Maximum = Double.NaN;
            chart.ChartAreas[0].RecalculateAxesScale();
        }

        private void comboBoxMonth_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonThongKe_Click(object sender, EventArgs e)
        {
           
            if (comboBoxMonth.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn tháng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra ComboBox Year
            if (comboBoxYear.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn năm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy giá trị từ ComboBox
            month = comboBoxMonth.SelectedIndex + 1;
            year = int.Parse(comboBoxYear.SelectedItem.ToString());
            LoadDataDateInMonth();
        }

        private void buttonXuatExcel_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu DataGridView không có dữ liệu
            if (dataGridView.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Hiển thị hộp thoại lưu file
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
                saveFileDialog.Title = "Lưu file Excel";
                saveFileDialog.FileName = "ThongKeDoanhThu.xlsx";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Gọi hàm xuất Excel
                        ExportToExcel(dataGridView, saveFileDialog.FileName);
                        MessageBox.Show("Xuất file Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Đã xảy ra lỗi khi xuất file Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void ExportToExcel(DataGridView dgv, string filePath)
        {
            using (var workbook = new ClosedXML.Excel.XLWorkbook())
            {
                // Tạo một worksheet
                var worksheet = workbook.Worksheets.Add("Thống Kê Doanh Thu");

                // **Tiêu đề tổng quát** (Nếu cần thiết)
                worksheet.Cell(1, 1).Value = "Báo cáo thống kê doanh thu";
                worksheet.Range("A1:D1").Merge(); // Gộp các cột từ A đến D
                worksheet.Cell(1, 1).Style.Font.Bold = true;
                worksheet.Cell(1, 1).Style.Font.FontSize = 16;
                worksheet.Cell(1, 1).Style.Alignment.Horizontal = ClosedXML.Excel.XLAlignmentHorizontalValues.Center;

                // Ghi tiêu đề cột
                for (int col = 0; col < dgv.Columns.Count; col++)
                {
                    worksheet.Cell(2, col + 1).Value = dgv.Columns[col].HeaderText;
                    worksheet.Cell(2, col + 1).Style.Font.Bold = true; // Làm đậm tiêu đề
                    worksheet.Cell(2, col + 1).Style.Fill.BackgroundColor = ClosedXML.Excel.XLColor.LightGray; // Màu nền tiêu đề
                    worksheet.Cell(2, col + 1).Style.Alignment.Horizontal = ClosedXML.Excel.XLAlignmentHorizontalValues.Center;
                }

                // Ghi dữ liệu từ DataGridView vào Excel
                for (int row = 0; row < dgv.Rows.Count; row++)
                {
                    for (int col = 0; col < dgv.Columns.Count; col++)
                    {
                        worksheet.Cell(row + 3, col + 1).Value = dgv.Rows[row].Cells[col].Value?.ToString() ?? "";
                    }
                }

                // Tùy chỉnh định dạng toàn bộ bảng
                var range = worksheet.RangeUsed();
                range.Style.Border.OutsideBorder = ClosedXML.Excel.XLBorderStyleValues.Thin;
                range.Style.Border.InsideBorder = ClosedXML.Excel.XLBorderStyleValues.Thin;
                range.Style.Alignment.Vertical = ClosedXML.Excel.XLAlignmentVerticalValues.Center;

                // Lưu file
                workbook.SaveAs(filePath);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            month = DateTime.Now.Month;
            year = DateTime.Now.Year;
            LoadDataDateInMonth();
        }

        private void chartNam_Click(object sender, EventArgs e)
        {

        }

        private void buttonThongKeNam_Click(object sender, EventArgs e)
        {
            if (comboBoxYearFrom.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn năm bắt đầu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra ComboBox Year
            if (comboBoxYearTo.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn năm kết thúc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            // Lấy giá trị từ ComboBox
            yearFrom = int.Parse(comboBoxYearFrom.SelectedItem.ToString());
            yearTo = int.Parse(comboBoxYearTo.SelectedItem.ToString());

            if(yearFrom > yearTo)
            {
                MessageBox.Show("Năm bắt đầu phải nhỏ hơn năm kết thúc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                yearFrom = DateTime.Now.Year;
                yearTo = DateTime.Now.Year;
                LoadDataYearToYear();
                return;
            }

            LoadDataYearToYear();
        }
        private void AdjustDataGridViewHeight(DataGridView dataGridView)
        {
            // Đặt chiều cao mặc định khi không có dữ liệu
            int defaultHeight = 50;

            // Nếu có dữ liệu trong DataGridView
            if (dataGridView.Rows.Count > 0)
            {
                int rowHeight = dataGridView.Rows[0].Height; // Chiều cao của mỗi hàng
                int totalHeight = (dataGridView.Rows.Count * rowHeight) + dataGridView.ColumnHeadersHeight;

                // Giới hạn chiều cao tối đa (nếu cần)
                int maxHeight = 300; // Ví dụ: Giới hạn tối đa 300 pixel
                dataGridView.Height = Math.Min(totalHeight, maxHeight);
            }
            else
            {
                // Không có dữ liệu, đặt chiều cao mặc định
                dataGridView.Height = defaultHeight;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            yearFrom = DateTime.Now.Year;
            yearTo = DateTime.Now.Year;

            LoadDataYearToYear();
        }

        private void buttonXuatExcelNam_Click(object sender, EventArgs e)
        {
            if (dataGridViewNam.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Hiển thị hộp thoại lưu file
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
                saveFileDialog.Title = "Lưu file Excel";
                saveFileDialog.FileName = "ThongKeTheoNam.xlsx";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Gọi hàm xuất Excel
                        ExportToExcel(dataGridViewNam, saveFileDialog.FileName);
                        MessageBox.Show("Xuất file Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Đã xảy ra lỗi khi xuất file Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void comboBoxYearTo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxYearFrom_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonThongKeThangInNam_Click(object sender, EventArgs e)
        {
            if (comboBoxYearToMonth.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn năm bắt đầu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            monthInYear = int.Parse(comboBoxYearToMonth.SelectedItem.ToString());         

            LoadDataMonthInYear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           monthInYear = DateTime.Now.Year;
            LoadDataMonthInYear();
        }

        private void buttonXuatExcelThangInNam_Click(object sender, EventArgs e)
        {
            if (dataGridViewthangInNam.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Hiển thị hộp thoại lưu file
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
                saveFileDialog.Title = "Lưu file Excel";
                saveFileDialog.FileName = "ThongKeTungThangTrongNam.xlsx";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Gọi hàm xuất Excel
                        ExportToExcel(dataGridViewthangInNam, saveFileDialog.FileName);
                        MessageBox.Show("Xuất file Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Đã xảy ra lỗi khi xuất file Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void chart_Click(object sender, EventArgs e)
        {

        }
    }
}
