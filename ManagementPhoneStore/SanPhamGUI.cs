using ClosedXML.Excel;
using Entity;
using ManagementPhoneStore;
using Service;
using Service.impl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class SanPhamGUI : Form
    {
        private SanPhamService sanPhamService = SanPhamService.Instance;
        private HeDieuHanhService heDieuHanhService = new HeDieuHanhService();
        private ThuongHieuService thuongHieuService = ThuongHieuService.Instance;
        private XuatXuService xuatXuService = new XuatXuService();
        private KhuVucKhoService khuVucKhoService = KhuVucKhoService.Instance;
        public SanPhamGUI()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            LoadDanhSachSanPham();
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Tất cả");
            comboBox1.SelectedIndex = 0;
            comboBox1.MeasureItem += new MeasureItemEventHandler(ComboBox_MeasureItem);
            comboBox1.DrawItem += new DrawItemEventHandler(ComboBox_DrawItem);
            comboBox1.Items.AddRange(khuVucKhoService.GetAll().Where(khuvuc => khuvuc.Trangthai == 1).Select(khuvuc => khuvuc.Tenkhuvuc).ToArray());
        }
        private void LoadDanhSachSanPham()
        {
            xuatXuService.GetAll();
            listView1.Items.Clear();    
            List<SanPham> sanPhams = sanPhamService.GetAll();
            listView1.View = View.Details;
            foreach (SanPham sanPham in sanPhams)
            {
                if (sanPham.Trangthai == true)
                {
                    ListViewItem item = new ListViewItem(sanPham.Masp.ToString());
                    item.SubItems.Add(sanPham.Tensp.ToString());
                    item.SubItems.Add(sanPham.Soluongton.ToString());
                    item.SubItems.Add(thuongHieuService.GetTenThuongHieu((int)sanPham.Thuonghieu).ToString());
                    item.SubItems.Add(heDieuHanhService.selectById((int)sanPham.Hedieuhanh).Tenhedieuhanh.ToString());
                    item.SubItems.Add(sanPham.Kichthuocman.ToString() + " inch");
                    item.SubItems.Add(sanPham.Chipxuly.ToString());
                    item.SubItems.Add(sanPham.Dungluongpin.ToString() + " mAh");
                    item.SubItems.Add(xuatXuService.GetTenXuatXu((int)sanPham.Xuatxu));
                    int kvkIndex = khuVucKhoService.GetIndexByMaKVK((int)sanPham.Khuvuckho);
                    item.SubItems.Add(khuVucKhoService.GetByIndex(kvkIndex).Tenkhuvuc.ToString());
                    listView1.Items.Add(item);
                }
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                LoadDanhSachSanPham();
            }
            else
            {
                LoadDanhSachSanPham();
                List<ListViewItem> filteredItems = new List<ListViewItem>();

                foreach (ListViewItem item in listView1.Items)
                {
                    string columnValue = item.SubItems[9].Text;

                    if (columnValue.Equals(comboBox1.Text))
                    {
                        filteredItems.Add(item);
                    }
                }

                listView1.Items.Clear();

                listView1.Items.AddRange(filteredItems.ToArray());
            }
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



        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals(""))
            {
                LoadDanhSachSanPham();
            }
            List<ListViewItem> filteredItems = new List<ListViewItem>();

            foreach (ListViewItem item in listView1.Items)
            {
                string columnValue = item.SubItems[1].Text.ToLower().Trim();

                if (columnValue.Contains(textBox1.Text))
                {
                    filteredItems.Add(item);
                }
            }

            listView1.Items.Clear();

            listView1.Items.AddRange(filteredItems.ToArray());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SanPhamDialog sanPhamDialog = new SanPhamDialog("them",0);
            sanPhamDialog.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                var selectedItem = listView1.SelectedItems[0];
                int masp;

                if (int.TryParse(selectedItem.SubItems[0].Text, out masp))
                {
                    SanPhamDialog sanPhamDialog = new SanPhamDialog("sua", masp);
                    sanPhamDialog.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Mã sản phẩm không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn dòng nào trong danh sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                var selectedItem = listView1.SelectedItems[0];
                int masp;

                if (int.TryParse(selectedItem.SubItems[0].Text, out masp))
                {
                    SanPhamDialog sanPhamDialog = new SanPhamDialog("chitiet", masp);
                    sanPhamDialog.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Mã sản phẩm không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn dòng nào trong danh sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                var selectedItem = listView1.SelectedItems[0];
                int masp;

                if (int.TryParse(selectedItem.SubItems[0].Text, out masp))
                {
                    DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này?", "Xác nhận xóa",
                                                          MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        sanPhamService.Delete(sanPhamService.GetByMaSP(masp));
                        LoadDanhSachSanPham();
                    }
                }
                else
                {
                    MessageBox.Show("Mã sản phẩm không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn dòng nào trong danh sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                var selectedItem = listView1.SelectedItems[0];
                int masp;

                if (int.TryParse(selectedItem.SubItems[0].Text, out masp))
                {
                    SanPhamXemDS sanPhamXemDS=new SanPhamXemDS(masp);
                    sanPhamXemDS.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Mã sản phẩm không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn dòng nào trong danh sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            LoadDanhSachSanPham();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Files|*.xlsx";
            saveFileDialog.Title = "Save as Excel File";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.AddWorksheet("Sheet1");

                    int row = 1;
                    foreach (ListViewItem item in listView1.Items)
                    {
                        for (int col = 0; col < item.SubItems.Count; col++)
                        {
                            worksheet.Cell(row, col + 1).Value = item.SubItems[col].Text;
                        }
                        row++;
                    }

                    workbook.SaveAs(saveFileDialog.FileName);
                }

                MessageBox.Show("Dữ liệu đã được xuất ra Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
