using Entity;
using NPOI.XSSF.UserModel;
using Service;
using Service.impl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
namespace GUI
{
    public partial class PhieuXuatPanel:UserControl
    {
        private SanPhamService sanPhamService = SanPhamService.Instance;
        private NhanVienService nvService = NhanVienService.Instance;
        private KhachHangService khService = new KhachHangService();
        private DungLuongRamService dlramService = new DungLuongRamService();
        private DungLuongRomService dlromService = new DungLuongRomService();
        private PhieuXuatService pxService = PhieuXuatService.Instance;
        private PhienBanSanPhamService pbspService = new PhienBanSanPhamService();
        private MauSacService mausacService = new MauSacService();

        private NhanVien nvnhap = new NhanVien();

        private List<ChiTietPhieuXuatDialog> chitietpn = new List<ChiTietPhieuXuatDialog>();
        private Dictionary<int, List<ChiTietSanPham>> chitietsanpham = new Dictionary<int, List<ChiTietSanPham>>();

        private int rowPhieuSelect = -1;
        private List<PhienBanSanPham> ch = new List<PhienBanSanPham>();
      
        private List<String> listmaimei = new List<String>();
        private List<PhieuXuat> listPhieu = new List<PhieuXuat>();

        private int manv;
        private int maphieuxuat;
        private string tennv;
        public PhieuXuatPanel(int manhanvien)
        {
            manv = manhanvien;
            string tennvien = nvService.GetNameById(manhanvien);
            tennv = tennvien;

            InitializeComponent();


            listPhieu = pxService.GetAll();
            var khachList = khService.getAll();
         
            dateEnd.Value = DateTime.Now;
            LoadphieuXuatTable1(listPhieu);
            LoadKhacHangDropdown();
            LoadEmployeeDropdown();


            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            addbutton.Click += Action_Performed;
            detail.Click += Action_Performed;
            cancel.Click += Action_Performed;
            export.Click += Action_Performed;


            comboBox2.SelectedIndexChanged += (s, e) => Filter();
            comboBox3.SelectedIndexChanged += (s, e) => Filter();
            textBox1.TextChanged += (s, e) => Filter();
            textBox2.TextChanged += (s, e) => Filter();
            textBox3.TextChanged += (s, e) => Filter();

            dateStart.ValueChanged += dateStart_ValueChanged;
            dateEnd.ValueChanged += dateEnd_ValueChanged;
            dateStart.ValueChanged += (s, e) => Filter();
            dateEnd.ValueChanged += (s, e) => Filter();
            resetbutton.Click += ResetForm;
            comboBox1.SelectedIndex = 0;
            comboBox1.MeasureItem += new MeasureItemEventHandler(ComboBox_MeasureItem);
            comboBox1.DrawItem += new DrawItemEventHandler(ComboBox_DrawItem);
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
        private void Export_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public static class Formater
        {
            public static string FormatTime(DateTime dateTime)
            {
                return dateTime.ToString("dd/MM/yyyy HH:mm:ss");
            }
            public static string FormatVND(long amount)
            {
                return string.Format("{0:N0} VND", amount);
            }
        }

        private void dateStart_ValueChanged(object sender, EventArgs e)
        {

            dateS.Text = dateStart.Value.ToString("dd-MM-yyyy");
        }
        private void dateEnd_ValueChanged(object sender, EventArgs e)
        {

            dateE.Text = dateEnd.Value.ToString("dd-MM-yyyy");
        }

        private void LoadphieuXuatTable1(List<PhieuXuat> listPhieuXuat)
        {

            dataGridView1.Rows.Clear();
            for (int i = 0; i < listPhieuXuat.Count; i++)
            {
                var phieuXuat = listPhieuXuat[i];
                string customerName = khService.getTenKhachHang((int)phieuXuat.Makh);
                string creatorName = nvService.GetNameById(Convert.ToInt32(phieuXuat.Nguoitaophieuxuat));

                string formattedTime = Formater.FormatTime(phieuXuat.Thoigian);
                string formattedTotal = Formater.FormatVND((long)phieuXuat.Tongtien);

                dataGridView1.Rows.Add(
                    i + 1,
                    (int)phieuXuat.Maphieuxuat,
                    customerName,
                    creatorName,
                    formattedTime,
                    formattedTotal
                );
            }

        }
        private void LoadKhacHangDropdown()
        {
            try
            {
                var khachList = khService.getAll();
                var allOption = new KhachHang { MakH = 0, TenKhachHang = "Tất cả" };
                comboBox2.Items.Clear();

                comboBox2.Items.Add(allOption);

                comboBox2.Items.AddRange(khachList.ToArray());

                comboBox2.SelectedIndex = 0;

                comboBox2.DisplayMember = "TenKhachHang";
                comboBox2.ValueMember = "MakH";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load: " + ex.Message);
            }
        }



        private void LoadEmployeeDropdown()
        {
            try
            {
                var nhanVienList = nvService.GetAll();

                var allOption = new NhanVien { Manv = 0, Hoten = "Tất cả" };

                comboBox3.Items.Clear();

                comboBox3.Items.Add(allOption);

                comboBox3.Items.AddRange(nhanVienList.ToArray());

                comboBox3.SelectedIndex = 0;

                comboBox3.DisplayMember = "Hoten";
                comboBox3.ValueMember = "Manv";   // Value to be used internally
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load employees: " + ex.Message);
            }
        }

        public bool ValidateSelectDate()
        {

            DateTime? timeStart = dateStart.Value;
            DateTime? timeEnd = dateEnd.Value;

            DateTime currentDate = DateTime.Now;

            if (timeStart.HasValue && timeStart > currentDate)
            {
                MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày hiện tại", "Lỗi !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateStart.Value = DateTime.Now;
                return false;
            }

            if (timeEnd.HasValue && timeEnd > currentDate)
            {
                MessageBox.Show("Ngày kết thúc không được lớn hơn ngày hiện tại", "Lỗi !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateEnd.Value = DateTime.Now;
                return false;
            }

            if (timeStart.HasValue && timeEnd.HasValue && timeStart > timeEnd)
            {
                MessageBox.Show("Ngày kết thúc phải lớn hơn ngày bắt đầu", "Lỗi !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateEnd.Value = timeStart.Value;
                return false;
            }

            return true;
        }


        public void Filter()
        {
            if (ValidateSelectDate())
            {
                int type = this.comboBox1.SelectedIndex;
                int kh = (int)((comboBox2.SelectedIndex == 0) ? 0 : khService.getByIndex(comboBox2.SelectedIndex - 1).MakH);
                int nv = (int)((comboBox3.SelectedIndex == 0) ? 0 : nvService.GetByIndex(comboBox3.SelectedIndex - 1).Manv);
                string input = !string.IsNullOrEmpty(textBox1.Text) ? textBox1.Text : "";


                DateTime timeStart = dateStart.Value;


                DateTime timeEnd = dateEnd.Value;

                string minPrice = textBox2.Text;
                string maxPrice = textBox3.Text;
                var phieuXuatList = pxService.GetAll();
                phieuXuatList = pxService.FilterPhieuXuat(type, input, kh, nv, timeStart, timeEnd, minPrice, maxPrice);
                LoadphieuXuatTable1(phieuXuatList);
            }

        }
        private void OnPropertyChange(object sender, PropertyChangedEventArgs e)
        {
            try
            {
                Filter();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public void ResetForm(object sender, EventArgs e)
        {
            dateStart.Value = new DateTime(1900, 1, 1);
            dateEnd.Value = DateTime.Now;

            dateS.Text = "";
            dateE.Text = "";

            comboBox2.SelectedIndex = comboBox2.Items.Count > 0 ? 0 : -1;
            comboBox3.SelectedIndex = comboBox3.Items.Count > 0 ? 0 : -1;
            comboBox1.SelectedIndex = comboBox1.Items.Count > 0 ? 0 : -1;

            textBox3.Text = "";
            textBox2.Text = "";
            textBox1.Text = "";

            List<PhieuXuat> phieuXuatlist = pxService.GetAll();
            LoadphieuXuatTable1(phieuXuatlist);
        }
        public void SetPanel(UserControl newPanel)
        {
            Console.WriteLine("Switching to a new panel...");

            if (this.Controls.Contains(tableLayoutPanel1))
            {
                this.Controls.Remove(tableLayoutPanel1);
            }

            newPanel.Dock = DockStyle.Fill;
            this.Controls.Add(newPanel);

        }

        private void Action_Performed(object sender, EventArgs e)
        {
            var source = sender as Button;

            if (source == addbutton)
            {
                var nhapKho = new ThemPhieuXuat(tennv, manv);
                SetPanel(nhapKho);
            }

            else if (source == detail)
            {
                int index = GetRowSelected();
                if (index != -1)
                {
                    var chiTietDialog = new ChiTietPhieuXuatDialog(listPhieu[index]);


                }
            }

            else if (source == cancel)
            {
                int index = GetRowSelected();
                if (index != -1)
                {
                    var confirmResult = MessageBox.Show(
                        "Bạn có chắc chắn muốn huỷ phiếu?\nThao tác này không thể hoàn tác nên hãy suy nghĩ kỹ!",
                        "Huỷ phiếu",
                        MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Information);

                    if (confirmResult == DialogResult.OK)
                    {
                        var pn = listPhieu[index];
                      
                            int cancelResult = pxService.cancelPhieuXuat(pn.Maphieuxuat);
                            if (cancelResult == 0)
                            {
                                MessageBox.Show("Hủy phiếu không thành công!");
                            }
                            else
                            {
                                MessageBox.Show("Hủy phiếu thành công!");
                                LoadphieuXuatTable1(pxService.GetAll());
                            }
                        
                    }
                }
            }
        
            
            else if (source == export)
            {
                try
                {
                    // File save dialog
                    using (var saveFileDialog = new SaveFileDialog())
                    {
                        saveFileDialog.Filter = "Excel Files|*.xlsx";
                        saveFileDialog.Title = "Save as Excel File";
                        saveFileDialog.FileName = "phieuXuatExport.xlsx";

                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            ExportToExcel(dataGridView1, saveFileDialog.FileName);
        MessageBox.Show("Xuất dữ liệu thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
}
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xuất dữ liệu thất bại: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private int GetRowSelected()
        {
            int index = -1;

            if (dataGridView1.SelectedRows.Count > 0)
            {
                index = dataGridView1.SelectedRows[0].Index;
            }
            else
            {
                MessageBox.Show("Vui lòng chọn phiếu xuất", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return index;
        }
        private void ExportToExcel(DataGridView dataGridView, string filePath)
        {

            var workbook = new XSSFWorkbook();
            var sheet = workbook.CreateSheet("phieuXuat");

            var headerRow = sheet.CreateRow(0);
            for (int i = 0; i < dataGridView.Columns.Count; i++)
            {
                var cell = headerRow.CreateCell(i);
                cell.SetCellValue(dataGridView.Columns[i].HeaderText);
            }

            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                var dataRow = sheet.CreateRow(i + 1);
                for (int j = 0; j < dataGridView.Columns.Count; j++)
                {
                    var cell = dataRow.CreateCell(j);

                    var value = dataGridView.Rows[i].Cells[j].Value;
                    cell.SetCellValue(value?.ToString() ?? string.Empty);
                }
            }

            using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                workbook.Write(fileStream);
            }
        }

        private void ResizeButtonImage(Button button, Image originalImage, int width, int height)
        {
            var resizedImage = new Bitmap(originalImage, new Size(width, height));
            button.Image = resizedImage;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            // Ensure the DateTimePicker is focused
            dateStart.Focus();

            // Use reflection to invoke the protected Show() method
            var method = typeof(DateTimePicker).GetMethod("Show", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            if (method != null)
            {
                method.Invoke(dateStart, null);
            }
        }

        private void detail_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void resetbutton_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void addbutton_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}