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
    public partial class PhieuNhapPanel : UserControl
    {
        private SanPhamService sanPhamService = SanPhamService.Instance;
        private NhanVienService nvService = NhanVienService.Instance;
        private NhaChungCapService nccService = NhaChungCapService.Instance;
        private DungLuongRamService dlramService = new DungLuongRamService();
        private DungLuongRomService dlromService = new DungLuongRomService();
        private PhieuNhapService pnService = PhieuNhapService.Instance;
        private PhienBanSanPhamService pbspService = PhienBanSanPhamService.Instance;
        private MauSacService mausacService = new MauSacService();
        private NhanVien nvnhap = new NhanVien();
        
        private List<ChiTietPhieuNhap> chitietpn = new List<ChiTietPhieuNhap>();
        private Dictionary<int, List<ChiTietSanPham>> chitietsanpham = new Dictionary<int, List<ChiTietSanPham>>();
        private int maphieunhap;
        private string tennv;
        private int manv;
        private int rowPhieuSelect = -1;
        private List<PhienBanSanPham> ch = new List<PhienBanSanPham>();
        private List<SanPham> sp = new List<SanPham>();
        private List<String> listmaimei = new List<String>();
        private List<PhieuNhap> listPhieu = new List<PhieuNhap>();

        public PhieuNhapPanel(int manhanvien)
        {
            manv = manhanvien;
           
            string ten = nvService.GetNameById(manv);
            tennv = ten;
            InitializeComponent();
            //ResizeButtonImage(addbutton, GUI.Properties.Resources.plus, 60, 60);
            //ResizeButtonImage(detail, GUI.Properties.Resources.info, 60, 60);
            //ResizeButtonImage(cancel, GUI.Properties.Resources.remove, 60, 60);
            //ResizeButtonImage(export, GUI.Properties.Resources.sheets, 60, 60);
            //ResizeButtonImage(resetbutton, GUI.Properties.Resources.refresh, 60, 60);



            listPhieu = pnService.GetAll();
            dateStart.Value = DateTime.Now;
            dateEnd.Value = DateTime.Now;
            LoadPhieuNhapTable1(listPhieu);
            LoadEmployeeDropdown();
            LoadNhaCungCapDropdown();

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

        private void LoadPhieuNhapTable1(List<PhieuNhap> listPhieuNhap)
        {

            dataGridView1.Rows.Clear();
            for (int i = 0; i < listPhieuNhap.Count; i++)
            {
                var phieuNhap = listPhieuNhap[i];


                string supplierName = nccService.GetTenNhaCungCap(phieuNhap.Manhacungcap);
                string creatorName = nvService.GetNameById(Convert.ToInt32(phieuNhap.Nguoitao));

                string formattedTime = Formater.FormatTime(phieuNhap.Thoigian);
                string formattedTotal = Formater.FormatVND(phieuNhap.Tongtien);

                dataGridView1.Rows.Add(
                    i + 1,
                    phieuNhap.Maphieunhap,
                    supplierName,
                    creatorName,
                    formattedTime,
                    formattedTotal
                );
            }

        }
        private void LoadNhaCungCapDropdown()
        {
            try
            {

                var nhaCungCapList = nccService.GetAll();

                var allOption = new NhaCungCap { Manhacungcap = 0, Tennhacungcap = "Tất cả" };

                comboBox2.Items.Clear();

                comboBox2.Items.Add(allOption);

                comboBox2.Items.AddRange(nhaCungCapList.ToArray());

                comboBox2.SelectedIndex = 0;

                comboBox2.DisplayMember = "Tennhacungcap";
                comboBox2.ValueMember = "Manhacungcap";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load suppliers: " + ex.Message);
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
                int ncc = (int)((comboBox2.SelectedIndex == 0) ? 0 : nccService.GetByIndex(comboBox2.SelectedIndex - 1).Manhacungcap);
                int nv = (int)((comboBox3.SelectedIndex == 0) ? 0 : nvService.GetByIndex(comboBox3.SelectedIndex - 1).Manv);
                string input = !string.IsNullOrEmpty(textBox1.Text) ? textBox1.Text : "";


                DateTime timeStart = dateStart.Value;


                DateTime timeEnd = dateEnd.Value;

                string minPrice = textBox2.Text;
                string maxPrice = textBox3.Text;
                var phieuNhapList = pnService.GetAll();
                phieuNhapList = pnService.FilterPhieuNhap(type, input, ncc, nv, timeStart, timeEnd, minPrice, maxPrice);
                LoadPhieuNhapTable1(phieuNhapList);
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
            dateStart.Value = DateTime.Now.AddDays(-1).AddHours(-1); ;
            dateEnd.Value = DateTime.Now.AddDays(-1);


            dateS.Text = "";
            dateE.Text = "";

            comboBox2.SelectedIndex = comboBox2.Items.Count > 0 ? 0 : -1;
            comboBox3.SelectedIndex = comboBox3.Items.Count > 0 ? 0 : -1;
            comboBox1.SelectedIndex = comboBox1.Items.Count > 0 ? 0 : -1;

            textBox3.Text = "";
            textBox2.Text = "";
            textBox1.Text = "";

            List<PhieuNhap> phieuNhaplist = pnService.GetAll();
            LoadPhieuNhapTable1(phieuNhaplist);
        }


        public void SetPanel(UserControl newPanel)
        {
            Console.WriteLine("Switching to a new panel...");
            this.Controls.Clear();
            newPanel.Dock = DockStyle.Fill;
            this.Controls.Add(newPanel);

        }

        private void Action_Performed(object sender, EventArgs e)
        {
            var source = sender as Button;

            if (source == addbutton)
            {
                ThemPhieuPanel nhapKho = new ThemPhieuPanel(tennv,manv);
                SetPanel(nhapKho);
            }
            else if (source == detail)
            {
                int index = GetRowSelected();
                if (index != -1)
                {
                    var chiTietDialog = new ChiTietPhieuDialog(listPhieu[index]);

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
                        if (!pnService.checkCancelPn(pn.Maphieunhap))
                        {
                            MessageBox.Show("Sản phẩm trong phiếu này đã được xuất đi không thể hủy phiếu này!");
                        }
                        else
                        {
                            int cancelResult = pnService.cancelPhieuNhap(pn.Maphieunhap);
                            if (cancelResult == 0)
                            {
                                MessageBox.Show("Hủy phiếu không thành công!");
                            }
                            else
                            {
                                MessageBox.Show("Hủy phiếu thành công!");
                                LoadPhieuNhapTable1(pnService.GetAll());
                            }
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
                        saveFileDialog.FileName = "PhieuNhapExport.xlsx";

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
                MessageBox.Show("Vui lòng chọn phiếu nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return index;
        }
        private void ExportToExcel(DataGridView dataGridView, string filePath)
        {

            var workbook = new XSSFWorkbook();
            var sheet = workbook.CreateSheet("PhieuNhap");

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

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
