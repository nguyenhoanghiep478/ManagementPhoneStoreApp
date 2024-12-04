using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entity;
using Service.impl;
using Service;
using ClosedXML.Excel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace ManagementPhoneStore
{
    public partial class KhuVucKhoForm : Form
    {
        private readonly IKhuVucKhoService khuVucKhoService = KhuVucKhoService.Instance;
        private readonly ISanPhamService sanPhamService = SanPhamService.Instance;
        private string searchType = "all";

        private List<KhuVucKho> listKvk;
        private List<SanPham> listSanPham;

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void KhuVucKhoForm_Load(object sender, EventArgs e)
        {
            listKvk = khuVucKhoService.GetAll();
            listSanPham = sanPhamService.GetAll();
            comboBox1.MeasureItem += new MeasureItemEventHandler(ComboBox_MeasureItem);
            comboBox1.DrawItem += new DrawItemEventHandler(ComboBox_DrawItem);
            LoadDataTable(listKvk);
            LoadFieldSelect();
            this.FormBorderStyle = FormBorderStyle.None; // Loại bỏ viền form
            this.TopLevel = false;
        }
        private void LoadDataTable(List<KhuVucKho> result)
        {
            listView1.Items.Clear();
            listView1.View = View.Details;
            foreach (var kvk in result)
            {
                if (kvk.Trangthai == 1)
                {
                    ListViewItem item = new ListViewItem(kvk.Makhuvuc.ToString());
                    item.SubItems.Add(kvk.Tenkhuvuc.ToString());
                    item.SubItems.Add(kvk.Ghichu.ToString());
                    listView1.Items.Add(item);

                }
            }
            listView1.OwnerDraw = true;
            listView1.DrawColumnHeader += listView_DrawColumnHeader;
            listView1.DrawSubItem += listView_DrawSubItem;
        }
        private void ComboBox_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = 36;  // Điều chỉnh chiều cao mục của ComboBox
        }

        private void ComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            // Lấy ComboBox đang được vẽ
            ComboBox comboBox = sender as ComboBox;
            if (comboBox != null && e.Index >= 0)
            {
                string itemText = comboBox.Items[e.Index].ToString();

                StringFormat stringFormat = new StringFormat()
                {
                    LineAlignment = StringAlignment.Center
                };

                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                {
                    e.Graphics.FillRectangle(Brushes.CornflowerBlue, e.Bounds);
                    e.Graphics.DrawString(itemText, e.Font, Brushes.White, e.Bounds, stringFormat);
                }
                else
                {
                    e.Graphics.FillRectangle(Brushes.White, e.Bounds);
                    e.Graphics.DrawString(itemText, e.Font, Brushes.Black, e.Bounds, stringFormat);
                }
            }
        }
        private void listView_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            using (Brush headerBrush = new SolidBrush(Color.FromArgb(235, 235, 235)))
            {
                e.Graphics.FillRectangle(headerBrush, e.Bounds);
            }

            using (Font customFont = new Font("Arial", 9, FontStyle.Bold))
            {
                TextFormatFlags flags = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter;
                TextRenderer.DrawText(e.Graphics, e.Header.Text, customFont, e.Bounds, Color.Black, flags);
            }

            if (e.ColumnIndex < listView1.Columns.Count - 1)
            {
                using (Pen pen = new Pen(Color.LightGray, 1))
                {
                    e.Graphics.DrawLine(pen, e.Bounds.Right - 1, e.Bounds.Top, e.Bounds.Right - 1, e.Bounds.Bottom);
                }
            }
        }

        private void listView_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            e.DrawDefault = true;
        }
        private void LoadFieldSelect()
        {
            comboBox1.Items.Clear();
            comboBox1.DrawMode = DrawMode.OwnerDrawFixed;
            // Thêm các lựa chọn
            comboBox1.Items.Add("Toàn bộ");
            comboBox1.Items.Add("Mã khu vực kho");
            comboBox1.Items.Add("Tên khu vực kho");
            comboBox1.Items.Add("Ghi chú");
            comboBox1.Items.Add("Trạng thái");

            // Đặt lựa chọn mặc định (tùy chọn)
            comboBox1.SelectedIndex = 0; // Chọ
        }

        private void flowPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void listView2_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void label2_Click_2(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void loadSanphamTheoKhuVucKho(int makhuvuc)
        {  
            var listSanPham = sanPhamService.GetByMakhuvuc(makhuvuc);

           
            
            createItemWithHeader(flowLayoutPanel1, "Danh sách sản phẩm có ở kho: ", listSanPham);


            // Nếu không có sản phẩm, hiển thị thông báo
            if (listSanPham.Count == 0)
            {
                Label noItemLabel = new Label
                {
                    Text = "Không có sản phẩm trong khu vực này.",
                    AutoSize = true,
                    ForeColor = Color.Red
                };
                flowLayoutPanel1.Controls.Add(noItemLabel);
            }

        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];
                string makhuvuc = selectedItem.Text;

                int makhuvucInt = int.Parse(makhuvuc);
                loadSanphamTheoKhuVucKho(makhuvucInt);
            }
            else
            {

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            listKvk = khuVucKhoService.GetAll();
            listSanPham = sanPhamService.GetAll();
            LoadDataTable(listKvk);

            loadSanphamTheoKhuVucKho(1);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = comboBox1.SelectedItem.ToString();

            // Gán giá trị type dựa trên mục được chọn
            switch (selectedItem)
            {
                case "Mã khu vực kho":
                    searchType = "makhuvuc";
                    break;
                case "Tên khu vực kho":
                    searchType = "tenkhuvuc";
                    break;
                case "Ghi chú":
                    searchType = "ghichu";
                    break;
                case "Trạng thái":
                    searchType = "trangthai";
                    break;
                default: 
                    searchType = "all";
                    break;
            }


            if (searchType == "all")
            {
                var allItems = khuVucKhoService.GetAll();
                LoadDataTable(allItems); 
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (KhuVucKhoDialog dialog = new KhuVucKhoDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Lấy thông tin từ dialog
                        string tenKhuVuc = dialog.TenKhuVuc;
                        string ghiChu = dialog.GhiChu;

                        // Tạo đối tượng mới
                        KhuVucKho newKhuVuc = new KhuVucKho
                        {
                            Makhuvuc = khuVucKhoService.getAutoIncrement(),
                            Tenkhuvuc = tenKhuVuc,
                            Ghichu = ghiChu,
                            Trangthai = 1
                        };


                        khuVucKhoService.Add(newKhuVuc);


                        listKvk = khuVucKhoService.GetAll();
                        LoadDataTable(listKvk);

                        MessageBox.Show("Thêm khu vực kho thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi thêm khu vực kho: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem có mục nào được chọn trong ListView không
                if (listView1.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn khu vực kho cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Lấy mục được chọn từ ListView
                ListViewItem selectedItem = listView1.SelectedItems[0];
                int makhuvuc = int.Parse(selectedItem.Text); 

                // Xác nhận trước khi xóa
                DialogResult confirmResult = MessageBox.Show(
                    "Bạn có chắc chắn muốn xóa khu vực kho này?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirmResult == DialogResult.Yes)
                {
                    // Lấy khu vực kho cần xóa
                    int index = KhuVucKhoService.Instance.GetIndexByMaKVK(makhuvuc);
                    if (index != -1)
                    {
                        var kvk = KhuVucKhoService.Instance.GetByIndex(index);

                        // Gọi hàm xóa trong Service
                        if (KhuVucKhoService.Instance.Delete(kvk, index))
                        {
                            // Cập nhật giao diện ListView
                            listView1.Items.Remove(selectedItem);
                            MessageBox.Show("Xóa khu vực kho thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Xóa khu vực kho thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy khu vực kho để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi khi xóa khu vực kho: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                // Tạo workbook mới
                using (var workbook = new XLWorkbook())
                {
                    // Tạo một worksheet
                    var worksheet = workbook.Worksheets.Add("KhuVucKho");

                    // Đặt tiêu đề cột
                    worksheet.Cell(1, 1).Value = "Mã khu vực";
                    worksheet.Cell(1, 2).Value = "Tên khu vực";
                    worksheet.Cell(1, 3).Value = "Ghi chú";
                    worksheet.Cell(1, 4).Value = "Trạng thái";

                    // Định dạng tiêu đề
                    var headerRange = worksheet.Range("A1:D1");
                    headerRange.Style.Font.Bold = true;
                    headerRange.Style.Fill.BackgroundColor = XLColor.LightBlue;
                    headerRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                    // Duyệt qua danh sách khu vực kho và thêm vào file Excel
                    int currentRow = 2;
                    foreach (var kvk in KhuVucKhoService.Instance.GetAll())
                    {
                        worksheet.Cell(currentRow, 1).Value = kvk.Makhuvuc;
                        worksheet.Cell(currentRow, 2).Value = kvk.Tenkhuvuc;
                        worksheet.Cell(currentRow, 3).Value = kvk.Ghichu;
                        worksheet.Cell(currentRow, 4).Value = kvk.Trangthai == 1 ? "Hoạt động" : "Không hoạt động";
                        currentRow++;
                    }

                    // Tự động điều chỉnh kích thước cột
                    worksheet.Columns().AdjustToContents();

                    // Hộp thoại lưu file
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
                MessageBox.Show($"Lỗi khi xuất file Excel: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string value = textBox1.Text.Trim();

            // Nếu "all", hiển thị toàn bộ danh sách
            if (searchType == "all" || string.IsNullOrEmpty(value))
            {
                var allItems = khuVucKhoService.GetAll();
                LoadDataTable(allItems); // Hiển thị toàn bộ
                loadSanphamTheoKhuVucKho(1);
                return;
            }

            // Tìm kiếm theo type và value
            if(searchType.Equals( "makhuvuc"))
            {
                bool isNumber = int.TryParse(value, out int number);
                if (!isNumber)
                {
                    MessageBox.Show($"Tìm theo mã kho chỉ có thể nhập số", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.textBox1.Text = string.Empty;
                    return;
                }
            }
            var result = khuVucKhoService.Search(value, searchType);
            if(result.Count > 0)
            {
                loadSanphamTheoKhuVucKho((int)result[0].Makhuvuc);
            }
           

            // Hiển thị kết quả tìm kiếm
            LoadDataTable(result);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn khu vực kho cần cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ListViewItem selectedItem = listView1.SelectedItems[0];
            int maKvk = int.Parse(selectedItem.Text);

            int index = khuVucKhoService.GetIndexByMaKVK(maKvk);
            KhuVucKho kvk = khuVucKhoService.GetByIndex(index);

            using (KhuVucKhoDialog khuVucKhoDialog = new KhuVucKhoDialog(kvk))
            {
                try
                {
                    if (khuVucKhoDialog.ShowDialog() == DialogResult.OK)
                    {
                        string tenKhuVuc = khuVucKhoDialog.TenKhuVuc;
                        string ghiChu = khuVucKhoDialog.GhiChu;

                        kvk.Tenkhuvuc = tenKhuVuc;
                        kvk.Ghichu = ghiChu;

                        this.khuVucKhoService.Update(kvk);
                        listKvk = khuVucKhoService.GetAll();
                        LoadDataTable(listKvk);

                        MessageBox.Show("Cập nhật khu vực kho thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }catch(Exception ex)
                {
                    MessageBox.Show($"Lỗi khi cập nhật khu vực kho: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
    }
}
