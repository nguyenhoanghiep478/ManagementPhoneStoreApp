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
using Entity;
using Service;
using Service.impl;

namespace ManagementPhoneStore
{
    public partial class PhanQuyenGUI : Form
    {
        private INhomQuyenService nhomQuyenService = NhomQuyenService.Instace;
        private List<NhomQuyen> nhomQuyens;
        private string searchType = "all";
        public PhanQuyenGUI()
        {
            InitializeComponent();
            LoadData();
            LoadFieldSelect();
            this.FormBorderStyle = FormBorderStyle.None; // Loại bỏ viền form
            this.TopLevel = false;
        }
        private void LoadData()
        {
            nhomQuyens = nhomQuyenService.GetAll();
            this.listView1.Items.Clear();
            foreach (var item in nhomQuyens)
            {
               if(item.Trangthai == 1)
                {
                    ListViewItem item1 = new ListViewItem(item.Manhomquyen.ToString());
                    item1.SubItems.Add(item.Tennhomquyen);
                    this.listView1.Items.Add(item1);
                }
            }
        }

        private void LoadFieldSelect()
        {
            comboBox1.Items.Clear();
            comboBox1.DrawMode = DrawMode.OwnerDrawFixed;

            comboBox1.Items.Add("Toàn bộ");
            comboBox1.Items.Add("Mã nhóm quyền");
            comboBox1.Items.Add("Tên nhóm quyền");

            comboBox1.SelectedIndex = 0;
        }
        private void PhanQuyenGUI_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (PhanQuyenDialog dialog = new PhanQuyenDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
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
                    MessageBox.Show("Vui lòng chọn nhóm quyền cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Lấy mục được chọn từ ListView
                ListViewItem selectedItem = listView1.SelectedItems[0];
                int maNhomQuyen = int.Parse(selectedItem.Text);

                // Xác nhận trước khi xóa
                DialogResult confirmResult = MessageBox.Show(
                    "Bạn có chắc chắn muốn xóa nhóm quyền này?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirmResult == DialogResult.Yes)
                {
                    // Lấy khu vực kho cần xóa
                    int index = this.nhomQuyenService.getIndexByMaNhomQuyen(maNhomQuyen);
                    if (index != -1)
                    {
                        var nhomQuyen = this.nhomQuyenService.GetByIndex(index);

                        // Gọi hàm xóa trong Service
                        if (this.nhomQuyenService.Delete(nhomQuyen))
                        {
                            // Cập nhật giao diện ListView
                            listView1.Items.Remove(selectedItem);
                            MessageBox.Show("Xóa nhóm quyền thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Xóa nhóm quyền thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy nhóm quyền để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi khi xóa nhóm quyền: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem có mục nào được chọn trong ListView không
                if (listView1.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn nhóm quyền cần cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Lấy mục được chọn từ ListView
                ListViewItem selectedItem = listView1.SelectedItems[0];
                int maNhomQuyen = int.Parse(selectedItem.Text);

                // Xác nhận trước khi xóa
                DialogResult confirmResult = MessageBox.Show(
                    "Bạn có chắc chắn muốn cập nhật khu vực kho này?",
                    "Xác nhận cập nhật",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirmResult == DialogResult.Yes)
                {
                    // Lấy khu vực kho cần xóa
                    int index = this.nhomQuyenService.getIndexByMaNhomQuyen(maNhomQuyen);
                    if (index != -1)
                    {
                        NhomQuyen nhomquyen = this.nhomQuyenService.GetByIndex(index);
                        using (PhanQuyenDialog dialog = new PhanQuyenDialog(nhomquyen))
                        {          
                            if (dialog.ShowDialog() == DialogResult.OK)
                            {
                                LoadData();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy nhóm quyền để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi khi cập nhật nhóm quyền: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                // Tạo workbook mới
                using (var workbook = new XLWorkbook())
                {
                    // Tạo worksheet
                    var worksheet = workbook.Worksheets.Add("Danh sách nhóm quyền");

                    // Thêm tiêu đề cột
                    worksheet.Cell(1, 1).Value = "Mã nhóm quyền";
                    worksheet.Cell(1, 2).Value = "Tên nhóm quyền";

                    // Định dạng tiêu đề cột
                    var headerRange = worksheet.Range(1, 1, 1, 2);
                    headerRange.Style.Font.Bold = true;
                    headerRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                    // Thêm dữ liệu từ ListView
                    int currentRow = 2; // Bắt đầu từ dòng thứ 2
                    foreach (ListViewItem item in listView1.Items)
                    {
                        worksheet.Cell(currentRow, 1).Value = item.SubItems[0].Text; // Mã nhóm quyền
                        worksheet.Cell(currentRow, 2).Value = item.SubItems[1].Text; // Tên nhóm quyền
                        currentRow++;
                    }

                    // Định dạng cột vừa khít nội dung
                    worksheet.Columns().AdjustToContents();

                    // Hiển thị hộp thoại lưu file
                    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                    {
                        saveFileDialog.Filter = "Excel Files|*.xlsx";
                        saveFileDialog.Title = "Lưu file Excel";
                        saveFileDialog.FileName = "DanhSachNhomQuyen.xlsx";

                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            workbook.SaveAs(saveFileDialog.FileName);
                            MessageBox.Show("Xuất file Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi xuất Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string value = textBox1.Text.Trim();


            if (searchType == "all" || string.IsNullOrEmpty(value))
            {
                var allItems = nhomQuyenService.GetAll();
                loadDataTable(allItems);
                return;
            }

            var result = nhomQuyenService.Search(searchType,value);

            loadDataTable(result);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = comboBox1.SelectedItem.ToString();

            // Gán giá trị type dựa trên mục được chọn
            switch (selectedItem)
            {
                case "Mã nhóm quyền":
                    searchType = "manhomquyen";
                    break;
                case "Tên nhóm quyền":
                    searchType = "tennhomquyen";
                    break;
                default:
                    searchType = "all";
                    break;
            }


            if (searchType == "all")
            {
                var allItems = nhomQuyenService.GetAll();
                loadDataTable(allItems);
            }
        }

        private void loadDataTable(List<NhomQuyen> filterData)
        {
            this.listView1.Items.Clear();
            if(filterData != null)
            {
                foreach (var item in filterData)
                {
                    if (item.Trangthai == 1)
                    {
                        ListViewItem item1 = new ListViewItem(item.Manhomquyen.ToString());
                        item1.SubItems.Add(item.Tennhomquyen);
                        this.listView1.Items.Add(item1);
                    }
                }
            }
           
        }

        private void button7_Click(object sender, EventArgs e)
        {
            LoadData();
            this.comboBox1.SelectedIndex = 0;
            this.textBox1.Text = String.Empty;
        }
    }
}
