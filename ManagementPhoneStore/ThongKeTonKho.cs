using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;
using DTO;
using Service;

namespace ManagementPhoneStore
{
    public partial class ThongKeTonKho : Form
    {

        private ThongKeService service = ThongKeService.Instance;
        Dictionary<int, List<ThongKeTonKhoDTO>> data;
        public ThongKeTonKho()
        {
            InitializeComponent();
        }

        private void ThongKeTonKho_Load(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text;
            DateTime fromDate = datePickerFrom.Value;
            DateTime toDate = datePickerTo.Value;
            data = service.FilterTonKho(searchTerm,fromDate,toDate);
            BindDataToGrid(data);
        }
        private void BindDataToGrid(Dictionary<int, List<ThongKeTonKhoDTO>> data)
        {
        
            this.dataGridView.Rows.Clear();

            int index = 1;
            foreach (var item in data)
            {
                int maSp = item.Key;
                var productList = item.Value;
                int tonDauKy = productList.Sum(p => p.Tondauky);
                int nhapTrongKy = productList.Sum(p => p.Nhaptrongky);
                int xuatTrongKy = productList.Sum(p => p.Xuattrongky);
                int tonCuoiKy = productList.Sum(p => p.Tondauky);

                string tenSP = productList.FirstOrDefault()?.Tensanpham ?? "N/A";
                this.dataGridView.Rows.Add(index++, maSp, tenSP, tonDauKy, nhapTrongKy, xuatTrongKy, tonCuoiKy);
            }
        }


        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            try
            {
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("ThongKeTonKho");

                    // Thiết lập tiêu đề cột
                    worksheet.Cell(1, 1).Value = "STT";
                    worksheet.Cell(1, 2).Value = "Mã Sản Phẩm";
                    worksheet.Cell(1, 3).Value = "Tên Sản Phẩm";
                    worksheet.Cell(1, 4).Value = "Tồn Đầu Kỳ";
                    worksheet.Cell(1, 5).Value = "Nhập Trong Kỳ";
                    worksheet.Cell(1, 6).Value = "Xuất Trong Kỳ";
                    worksheet.Cell(1, 7).Value = "Tồn Cuối Kỳ";

                    // Ghi dữ liệu
                    int row = 2; // Bắt đầu từ dòng thứ 2 vì dòng 1 là tiêu đề
                    int stt = 1;

                    foreach (var kvp in data)
                    {
                        int maSP = kvp.Key;
                        var thongKeList = kvp.Value;

                        // Tính toán tồn đầu kỳ, nhập trong kỳ, xuất trong kỳ, tồn cuối kỳ
                        int tonDauKy = thongKeList.Sum(x => x.Tondauky);
                        int nhapTrongKy = thongKeList.Sum(x => x.Toncuoiky);
                        int xuatTrongKy = thongKeList.Sum(x => x.Xuattrongky);
                        int tonCuoiKy = thongKeList.Sum(x => x.Toncuoiky);

                        // Lấy tên sản phẩm từ bản ghi đầu tiên
                        string tenSP = thongKeList.FirstOrDefault()?.Tensanpham ?? "N/A";

                        worksheet.Cell(row, 1).Value = stt++;
                        worksheet.Cell(row, 2).Value = maSP;
                        worksheet.Cell(row, 3).Value = tenSP;
                        worksheet.Cell(row, 4).Value = tonDauKy;
                        worksheet.Cell(row, 5).Value = nhapTrongKy;
                        worksheet.Cell(row, 6).Value = xuatTrongKy;
                        worksheet.Cell(row, 7).Value = tonCuoiKy;

                        row++;
                    }

                    // Định dạng bảng
                    var range = worksheet.Range(1, 1, row - 1, 7); // Vùng dữ liệu từ cột 1 đến cột 7
                    range.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    range.Style.Border.InsideBorder = XLBorderStyleValues.Thin;

                    // Lưu file Excel
                    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                    {
                        saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
                        saveFileDialog.Title = "Lưu file Excel";
                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            // Lưu file Excel
                            workbook.SaveAs(saveFileDialog.FileName);
                            MessageBox.Show("Xuất file Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xuất Excel: " + ex.Message);
            }
        }

        private void button7_Click_1(object sender, EventArgs e)
        {

        }

        private void datePickerFrom_ValueChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void ApplyFilters()
        {
            string searchTerm = txtSearch.Text;
            DateTime fromDate = datePickerFrom.Value;
            Console.WriteLine(fromDate.ToString());
            DateTime toDate = datePickerTo.Value;

            var data = service.FilterTonKho(searchTerm, fromDate, toDate);
            BindDataToGrid(data);
        }

        private void datePickerTo_ValueChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }
    }
}
